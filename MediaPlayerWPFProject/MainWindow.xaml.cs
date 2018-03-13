using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using Microsoft.Win32;
 
using System.Windows.Threading;
using System.Reflection;

namespace MediaPlayerWPFProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Amr Ashraf Ismail Sedky
    /// 
    /// 
    public partial class MainWindow : Window
    {
        DispatcherTimer DT;

        public MainWindow()
        {
            InitializeComponent();
            DT = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 1)
            };
            DT.Tick += DT_Tick;
            SoundBar.Value = 100;
            
        }
        private bool OpenMedia()
        {
            bool isOpend = false;
            OpenFileDialog browser = new OpenFileDialog();
            browser.Filter = "videos files (*.mp4)|*.mp4|(*.AVI)|*.AVI|(*.wma)|*.wma|Sound (*.mp3)|*.mp3";
            bool? result = browser.ShowDialog();
            if (result == true)
            {
                _MainMediaPlayer.Source = new Uri(browser.FileName);
                Title = browser.SafeFileName;
                _MainMediaPlayer.Play();
                DT.Start();
                isOpend =  true;
            }
            return isOpend;
        }
        private void MediaSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            _MainMediaPlayer.Position = new TimeSpan(0, 0, (int)MediaSlider.Value);
        }
        private void DT_Tick(object sender, EventArgs e)
        {
            LblTime.Content = String.Format("{0:hh\\:mm\\:ss}", _MainMediaPlayer.Position);
            MediaSlider.Value = _MainMediaPlayer.Position.TotalSeconds;
            if (_MainMediaPlayer.NaturalDuration.HasTimeSpan)
            {
                TaskProgressInfo.ProgressValue = _MainMediaPlayer.Position.TotalSeconds / _MainMediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            }
            
            BtnTask.ImageSource = PlayPause.Source;
        }
        private void PlayMedia(Button btn)
        {
            bool result = false;
            if (_MainMediaPlayer.Source == null)
            {
                result = OpenMedia();
                if (result == true)
                {
                    btn.Name = "Pause";
                    string Pausepath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"imgs\Pause.png");
                    PlayPause.Source = new BitmapImage(new Uri(Pausepath));
                }
            }
            else
            {
                btn.Name = "Pause";
                string Pausepath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"imgs\Pause.png");
                PlayPause.Source = new BitmapImage(new Uri(Pausepath));
            }
        }
        private void MediaControl_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource.GetType() == typeof(Button))
            {
                Button btn = ((Button)e.OriginalSource);
                switch (btn.Name)
                {
                    case "Play":
                        _MainMediaPlayer.Play();
                        PlayMedia(btn);

                        break;
                    case "Pause":
                        _MainMediaPlayer.Pause();
                        btn.Name = "Play";
                        string Playpath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"imgs\Play.Png");
                        PlayPause.Source = new BitmapImage(new Uri(Playpath));
                        break;
                    case "Stop":
                        _MainMediaPlayer.Stop();
                        break;
                    case "FF":
                        _MainMediaPlayer.SpeedRatio += 0.5;
                        break;
                    case "Rewind":
                        _MainMediaPlayer.SpeedRatio -= 0.5;
                        break;
                    case "FullScreen":
                         Height = SystemParameters.MaximizedPrimaryScreenHeight;
                        Width = SystemParameters.MaximizedPrimaryScreenWidth;
                        break;
                    case "PlayList":
                        TVPList.Visibility = Visibility.Visible;
                        break;
                    case "Open":
                        bool result = OpenMedia();
                        if (result == true)
                        {
                             Play.Name = "Pause";
                            string Pausepath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"imgs\Pause.png");
                            PlayPause.Source = new BitmapImage(new Uri(Pausepath));
                        }

                        break;
                }
            }
        }
        private void _MainMediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            MediaSlider.Maximum = _MainMediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            LblAllTime.Content = _MainMediaPlayer.NaturalDuration.TimeSpan;
            if (_MainMediaPlayer.HasVideo)
            {

                string VideoIconpath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"imgs\video.ico");
                TaskProgressInfo.Overlay = new BitmapImage(new Uri(VideoIconpath));
            }
            else
            {
                string MusicIconpath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"imgs\music.png");
                TaskProgressInfo.Overlay = new BitmapImage(new Uri(MusicIconpath));
            }
        }

        private void SoundBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _MainMediaPlayer.Volume = SoundBar.Value / 100;
        }

      
        private void TreeView_MouseEnter(object sender, MouseEventArgs e)
        {
            //TVPList.Visibility = Visibility.Visible;
        }

        private void TreeView_MouseLeave(object sender, MouseEventArgs e)
        {
            //TVPList.Visibility = Visibility.Collapsed;

        }

      

        private void MI_AddSongs_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog browser = new OpenFileDialog()
            {
                Multiselect = true,
                Title="Select Media to Add To Playlist",
                Filter= "videos files(*.mp4) | *.mp4 | (*.AVI) | *.AVI | (*.wma) | *.wma | Sound(*.mp3) | *.mp3"

            };
            browser.ShowDialog();
           
             foreach(string element in browser.FileNames)
             {
                PlayListRoot.Items.Add( new TreeViewItem { Header = element 
                 

                });
             }
             
            foreach(TreeViewItem element in PlayListRoot.Items)
            {
                 
                element.ToolTip = "Double Click to Run";
                element.MouseDoubleClick += Element_MouseDoubleClick;
            }
        }

        private void Element_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _MainMediaPlayer.Source = new Uri( ((TreeViewItem)sender).Header.ToString());
            _MainMediaPlayer.Play();
            Play.Name = "Pause";
            string Pausepath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"imgs\Pause.png");
            PlayPause.Source = new BitmapImage(new Uri(Pausepath));
        }

        private void PlayListToShow_MouseEnter(object sender, MouseEventArgs e)
        {
            TVPList.Visibility = Visibility.Visible;
        }

        private void PlayListToShow_MouseLeave(object sender, MouseEventArgs e)
        {
            TVPList.Visibility = Visibility.Collapsed;
        }
    }
}
