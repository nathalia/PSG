   M S B A M L   `   `   `  ����^  ZMicrosoft.Samples.Kinect.WpfViewers, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null�^clr-namespace:Microsoft.Samples.Kinect.WpfViewers;assembly=Microsoft.Samples.Kinect.WpfViewers#Microsoft.Samples.Kinect.WpfViewers  5   	    SkeletalTracking!   SkeletalTracking.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   mmy^clr-namespace:Microsoft.Samples.Kinect.WpfViewers;assembly=Microsoft.Samples.Kinect.WpfViewers     5   	   -   5          � Title$  
MainWindow��5   	   $	��600��6   $	��800��6)    � WindowState$ 	Maximized=�5   "   .��5      �� -   5        $��
MainCanvas��5      .+�5   
   ;   5Microsoft.Samples.Kinect.WpfViewers.KinectColorViewer  -   5        $��kinectColorViewer1��5   W    �� Left$ 0��6   
 �� Top$ 0��6/   $	��640��6>   $	��480��6J   5   /Microsoft.Samples.Kinect.WpfViewers.ImageViewer   Kinect 5	      ��  �� ElementName$ kinectSensorChooser1�� �� Path$ Kinect�A� 5
   
   -   5        $��leftHand��5
   @   $	 161��6   $ 96��6$   $��18��64   $��18��6Q   ���	#FF4D298D J� Opacity$ 1Q�6m   
�������6y   A� 5   
   -   5        $��	rightHand��5   Q   $	 282��6   $ 96��6$   ���	#FF4D298D$��18��6E   $��18��6b   $ 1Q�6m   
�������6y   =   7Microsoft.Samples.Kinect.WpfViewers.KinectSensorChooser  5   
   -   5        $��kinectSensorChooser1��5   D   $	 250��6!   $	 380��63   $	��328��6`   A� 5   
   -   5        $
��head��5   P   $	 226��6   $ 0��6$   ���	#FF4DFF00$��18��6D   $ 1Q�6\   
�������$��18��6w   A� 5   
   -   5        $��rightShoulder��5   Q   $	 161��6   $ 36��6$   ���	#FFE31A2C$��18��6E   $ 1Q�6f   
�������$��18��6�   A� 5   
   -	   5        $��leftShoulder��5   K   $	 282��6   $ 36��6$   
���  ��$��18��6?   $ 1Q�6_   
�������$��18��6z   A� 5   
   -
   5        $��
rightElbow��5   Q   $	 161��6   $ 67��6$   ���	#FF9393A7$��18��6E   $ 1Q�6c   
�������$��18��6~   A� 5   
   -   5        $��	leftElbow��5   Q   $	 282��6   $ 67��6$   ���	#FF9393A7$��18��6E   $ 1Q�6b   
�������$��18��6}   A� 5   
   -   5        $��rightTrocanter��5   R   $	 190��6   $	 130��6$   ���	#FF2CACE3$��18��6F   $ 1Q�6h   
�������$��18��6�   A� 5   
   -   5        $��leftTrocanter��5   R   $	 264��6   $	 130��6$   ���	#FF2CACE3$��18��6F   $ 1Q�6g   
�������$��18��6�   A� 5   
   -   5        $��rightMaleolo��5   R   $	 161��6   $	 266��6$   ���	#FF0E376C$��18��6F   $ 1Q�6f   
�������$��18��6�   A� 5   
   -   5        $��leftMaleolo��5   R   $	 282��6   $	 266��6$   ���	#FF0E376C$��18��6F   $ 1Q�6e   
�������$��18��6�   A� 5   
   -   5        $��rightPavilhao��5   P   $	 161��6   $ 0��6$   ���	#FF4DFF00$��18��6D   $ 1Q�6e   
�������$��18��6�   A� 5   
   -   5        $��leftPavilhao��5   P   $	 282��6   $ 0��6$   ���	#FF4DFF00$��18��6D   $ 1Q�6d   
�������$��18��6   A� 5   
   -   5        $��apofises��5   Q   $	 226��6   $ 49��6$   ���	#FFFAFF00$��18��6E   $ 1Q�6a   
�������$��18��6|   A� 5   
   -   5        $��crista��5   Q   $	 226��6   $ 96��6$   ���	#FFFAFF00$��18��6E   $ 1Q�6_   
�������$��18��6z   A� 5   
   -   5        $��	rightKnee��5   R   $	 161��6   $	 210��6$   ���	#FFEB0E6C$��18��6F   $ 1Q�6c   
�������$��18��6~   A� 5   
   -   5        $��leftKnee��5   R   $	 282��6   $	 210��6$   ���	#FFEB0E6C$��18��6F   $ 1Q�6b   
�������$��18��6}   5      5      