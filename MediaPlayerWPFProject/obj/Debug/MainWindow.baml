   M S B A M L   `   `   `  ����P  LMediaPlayerWPFProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MediaPlayerWPFProjectMediaPlayerWPFProject  5   	   &     MediaPlayerWPFProject.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:MediaPlayerWPFProject     5   	   -   5        $��AppMainWindow��5	   	     � Title$  
MainWindow��5   	   $	��458��6   $��800.85��6)    � Icon$ imgs/HawklOGO.png��5   
   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��Auto �6   $	��389��6*   .+�5   
   r� -   5         r�Name$ _MainMediaPlayer��5   &    r� Stretch$
 Fill=�6    r� LoadedBehavior$ Manual=�6@    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��0��6�   $��2��6�   $��4,0,0,0q�6�   �� 5   
   -   5        $��MediaSlider��5   (   $	��Top=�6   $��
0,315,0,56q�6k   $��1��6�   ]� 5   
   $��203,331,81,0q�6   $ 0.5,0.5&�6*   $��1��6J   $��Center=�6W   $	��509��6t   .+�5      c� -   5        $��TBMediaControl��5   +   $	��Top=�6   $��50��6A   $��Center=�5   <   $��Right=�5      $	��509��62   
������ .@�5      �� -   5         ��Name$
 Stop��5      .��5      �� $��imgs/STOP.png��6    � ToolTip 5      _� 5      .��5      �� $
��Bold"�6(   Stop Button6G   5      5      �� 5      -   5        $ FF��5      .��5       �� $��imgs/FF.png��6    5!      _� 5"      .��5#      �� $
��Bold"�6(   Fast Forward Button6O   5$      5&      �� 5(      -   5        $ Rewind��5(      .��5)      �� $��imgs/Rewind.png��6    5*      _� 5+      .��5,      �� $
��Bold"�6(   Rewind Button6I   5-      5/      �� 50      -   5        $
 Play��50      .��51      �� -	   5        $��	PlayPause��51      $��imgs/Play.png��6.    52      _� 53      .��54      �� $
��Bold"�6(   Play/Pause Button6M   55      57      �� 58      -
   5        	 ��Name$	 LblTime��58      $��54��6d   ��6)   �� *
Position+
 �� ElementName$
 _MainMediaPlayer��6d   �� 59      -   5        $	 
LblAllTime��59      $��54��6g   ��6,   �� *
Position+$
 _MainMediaPlayer��6g   �� 5:      -   5        $��SoundBar��5:       � Maximum$	 100Q�6)   $��82��67   $��0,10,0,5q�6B    5;      _� 5<      .��5=      �� 
Volume Bar64   5>      5@      �� 5A      -   5        $ 
FullScreen��5A      .��5B      �� $��imgs/fullscreen.png��6    5C      _� 5D      .��5E      �� $
��Bold"�6)   Full Screen Mode6O   5F      5H      �� 5I      -   5        $ PlayList��5I      $��	0,10,0,11q�6,   $��24��6?   $��24��6K   .��5K      �� $��imgs/Playlist.png��6   $��14��67   $��24��6C    5L      _� 5M      .��5N      �� $
��Bold"�6)   Open Play List6L   5O      5Q      �� 5R      -   5        $
 Open��5R      $��	0,10,0,11q�6(   $��24��6>   $��24��6J   .��5T      �� $��imgs/open.png��6   $��14��63   $��18��6?    5U      _� 5V      .��5W      �� $
��Bold"�6)   
Open Media6H   5X      5Z      5[      5\      ]� 5^   
   -   5        $��PlayListToShow��5^   .   
������ $
��Left=�6D   $	��348��6_   ��.  $��4,5,0,0q�6�   $��2��6�   $	��Top=�6�   $	��246��6�   .+�5_      R� -   5        $��TVPList��5_      $
��Left=�6(   $	��384��6C   $��2��6P   $	��Top=�6a   $	��206��6y   $y�	Collapsed=�6�   $��	0,0,0,-36q�6�   .@�5a      Q� -   5        $��PlayListRoot��5a      $��	Play List��63    � ContextMenu 5b      �� 5c      .@�5d      m� -   5        $��MI_AddSongs��5d   (   $��	Add Songs��6<   6O   5e       5g      _� 5h      .��5i      �� Click Right To Deal With Me6F   5j      5l      5n      5p      5t       � TaskbarItemInfo 5v      *  $System.Windows.Shell.TaskbarItemInfo  5w   
   -   5        TaskProgressInfo��   ProgressValue$ 0Q�5w   4      ProgressState$ Normal=�6F      ThumbButtonInfos 5y      4  .System.Windows.Shell.ThumbButtonInfoCollection  *  $System.Windows.Shell.ThumbButtonInfo  5z         ImageSource$ imgs/STOP.png��6&      Description$ 
Stop Media��6B     5{      -   5        BtnTask��$ Pause Media��5}   &   5~      5�      5�      