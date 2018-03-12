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
using System.IO;
using System.Windows.Threading;
namespace MediaPlayerWPFProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
        private void OpenMedia()
        {
            OpenFileDialog browser = new OpenFileDialog();
            browser.Filter = "videos files (*.mp4)|*.mp4|(*.AVI)|*.AVI|(*.wma)|*.wma|Sound (*.mp3)|*.mp3";
            bool? result = browser.ShowDialog();
            if (result == true)
            {
                _MainMediaPlayer.Source = new Uri(browser.FileName);
                Title = browser.SafeFileName;
                _MainMediaPlayer.Play();
                DT.Start();
            }
            Icon = new BitmapImage(new Uri(@"C:\Users\Amr\Pictures\HawklOGO.png"));
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
        private void MediaControl_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource.GetType() == typeof(Button))
            {
                Button btn = ((Button)e.OriginalSource);
                switch (btn.Name)
                {
                    case "Play":
                        _MainMediaPlayer.Play();
                        if (_MainMediaPlayer.Source == null)
                        {
                            OpenMedia();
                        }

                        btn.Name = "Pause";
                        PlayPause.Source = new BitmapImage(new Uri(@"D:\WPF\Pause.png"));

                        break;
                    case "Pause":
                        _MainMediaPlayer.Pause();
                        btn.Name = "Play";
                        PlayPause.Source = new BitmapImage(new Uri(@"D:\WPF\Play.png"));
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
                }
            }
        }
        private void _MainMediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            MediaSlider.Maximum = _MainMediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            if (_MainMediaPlayer.HasVideo)
            {
                TaskProgressInfo.Overlay = new BitmapImage(new Uri(@"D:\WPF\video.ico"));
            }
            else
            {
                TaskProgressInfo.Overlay = new BitmapImage(new Uri(@"D:\WPF\music.png"));
            }
        }

        private void SoundBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _MainMediaPlayer.Volume = SoundBar.Value / 100;
        }

        private void AppMainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //TBMediaControl.Width = AppMainWindow.ActualWidth;
        }

        private void BtnTask_Click(object sender, EventArgs e)
        {
            
        }

        private void TreeView_MouseEnter(object sender, MouseEventArgs e)
        {
            TVPList.Visibility = Visibility.Visible;
        }

        private void TreeView_MouseLeave(object sender, MouseEventArgs e)
        {
            TVPList.Visibility = Visibility.Hidden;

        }

        private void PlayList_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
