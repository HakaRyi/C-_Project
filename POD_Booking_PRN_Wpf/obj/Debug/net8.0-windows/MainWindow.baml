   M S B A M L   `   `   `  ����N  JPOD_Booking_PRN_Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:POD_Booking_PRN_WpfPOD_Booking_PRN_Wpf  5   	   $    POD_Booking_PRN_Wpf.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:POD_Booking_PRN_Wpf     5   	   -   5          � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65   .��5
      � .+�5   
   �� $
��Left=�6   $	��435��6/   
���   �
����� �$��Center=�5   !   $	��166��6<    K� ZIndex$ 1��5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6#      	Direction$ 0Q�61      ShadowDepth$ 10Q�6?      Opacity$	 0.6Q�6P      
BlurRadius$ 12Q�6^   5      �� 5   
   $��Center=�6   $��76��61   
���   �$	��Top=�5   #   $	��800��6;   
����ح�$ 0��5   %   �� 5   
   $
��Menu��6   $��30(�6   $
��Left=�6-   $��66��6H   $��	35,10,0,0q�6T   $	��Top=�6g   $ 2��5      $��91��6"   $��.VnBahamasBH)�6-   �� 5   
   -   5        	 ��Name$	 btnBuilding��5      $��Manage Building��5      $ 2��5      $��16(�5      $��0q�5      $��	.VnCooper)�5      
������ $
��Left=�5      $��53��6,   $��	5,108,0,0q�68   $	��Top=�6K   $	��161��6c   6o   �� 5    
   -   5        $	 btnRoom��5       $��Manage Room��5!      $��0q�5"      $ 2��5#      $��16(�5$      $��	.VnCooper)�5%      
������ $��	0,259,0,0q�5'      $
��Left=�5(      $��53��6(   $	��Top=�64   $	��161��6L   6X   �� 5)   
   -   5        $	 btnUser��5)      $��Manage User��5*      $ 2��5+      $��0q�5,      $��16(�5-      $��	.VnCooper)�5.      
������ $
��Left=�50      $��53��6(   $��	0,180,0,0q�64   $	��Top=�6G   $	��161��6_   6k   �� 51   
   $��.VnBahamasBH)�6   $��40(�52      
 �� TextAlignment$
 Center=�6"   $��76��53      $��	166,0,0,0q�6    $
��Wrap=�63   $��WELCOME TO BEYOND DESK��6G   $	��Top=�6e   $	��634��6}   �� 54   
   $
��Left=�6   $	��407��6/   $��
161,76,0,0q�6<   
���   �$	��Top=�6_   $	��639��6w    J� Opacity$	 0.8Q�6�   ��55      �� 56       �� ImageSource$ /blueCity.png��6   59      �� 5:   
   ���	#FFCAC3C3$
��Left=�5<      $	��211��6(   $��180,101,0,0q�65   
���   �$	��Top=�6Y   $	��610��6q   $
 0.75Q�6}    �� RadiusX$ 20��6�    �� RadiusY$ 20��6�   �� 5=   
   $
��Left=�6   $��14(�5>      $
 Justify=�5?      $
��Bold"�5@      
���   �$	��200��5A      $��193,141,0,0q�6!   $
��Wrap=�66   $����Beyond Desk is dedicated to transforming the way you work by offering a seamless and efficient workspace booking experience. We provide access to a wide variety of workspaces tailored to your needs. Our mission is to empower your productivity by connecting you with inspiring environments, flexible schedules, and all the amenities you require. At Beyond Desk, we believe that where you work influences how you work, and we are here to help you unlock your full potential. Choose Beyond Desk and elevate your work experience to a whole new level of convenience and innovation��6J   $	��Top=�6�  $	��581��6�  �� 5B   
   $��.VnBahamasBH)�6   $��35(�5C      ���#FFD700$��Why Choose Beyond Desk ��5E      $
��Left=�6,   $��64��6G   $��
253,72,0,0q�6S   $	��Top=�6g   $	��501��6    5F        5G      $ Black��6#   $ 5Q�61   $ 2Q�6@   $	 0.7Q�6P   5I      �� 5J   
   -   5        $	 
btnBookNow��5J      $��B O O K N O W��5K      $��16(�5L      $��	ExtraBold"�5M      
�������
���"�"�
����  �$
��Left=�5Q      $��53��6,   $��374,359,0,0q�68   $	��Top=�6M   $	��214��6e   6q   5R      5S      