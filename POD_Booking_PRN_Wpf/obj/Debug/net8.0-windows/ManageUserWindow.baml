   M S B A M L   `   `   `  ����N  JPOD_Booking_PRN_Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:POD_Booking_PRN_WpfPOD_Booking_PRN_Wpf  5   	   *    $POD_Booking_PRN_Wpf.ManageUserWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:POD_Booking_PRN_Wpf     5   	     � Title$  ManageUserWindow��5   	   $	��600��6"   $	��800��6/   
������ � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   �� $��User Management��6   $��24(�6*   $
��Bold"�68   $��Center=�6J   $��0,10,0,0q�6g   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridUsers��5         AutoGenerateColumns$ False��6*   $��
5,64,5,250q�6F      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ User ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *
UseridId+6S     5      $ 
VIP Status��6%   $ * 6Q    69   �� *Vip+6Q     5      $ Email��6%   $ * 6N    64   �� *Email+6N     5      $
 Name��6%   $ * 6L    63   �� *Name+6L     5      $ Phone��6%   $ * 6N    64   �� *Phone+6N     5      $ Username��6%   $ * 6T    67   �� *
Username+6T     5      $ Role ID��6%   $ * 6Q    66   �� *RoleId+6Q     5      $ Password��6%   $ * 6T    67   �� *
Password+6T   5      �� 5   
   $��User ID:��6   $
��Left=�6#   $��Bottom=�6>   $��
10,10,0,50q�6Y   �� 5   
   -   5         ��Name$ 	txtUserId��5      $
��Left=�6%   $��Bottom=�6@   $	��120��6[   $��	80,0,0,50q�6g   	 �� 
IsReadOnly$
	 True��6z   �� 5   
   $��VIP Status:��6   $
��Left=�6&   $��Bottom=�6A   $��10,10,0,100q�6\   �� 5    
   -   5        $ txtVipStatus��5       $
��Left=�6(   $��Bottom=�6C   $	��200��6^   $��
80,0,0,100q�6j   �� 5"   
   $��Email:��6   $
��Left=�6!   $��Bottom=�6<   $��10,10,0,150q�6W   �� 5#   
   -   5        $ txtUserEmail��5#      $
��Left=�6(   $��Bottom=�6C   $	��200��6^   $��
80,0,0,150q�6j   �� 5%   
   $��Phone:��6   $
��Left=�6!   $��Bottom=�6<   $��350,10,0,150q�6W   �� 5&   
   -   5        $ txtUserPhone��5&      $
��Left=�6(   $��Bottom=�6C   $	��200��6^   $��420,0,0,150q�6j   �� 5(   
   $��Name:��6   $
��Left=�6    $��Bottom=�6;   $��350,10,0,100q�6V   �� 5)   
   -   5        $ txtUserName��5)      $
��Left=�6'   $��Bottom=�6B   $	��200��6]   $��420,0,0,100q�6i   �� 5+   
   $��	Password:��6   $
��Left=�6$   $��Bottom=�6?   $��350,10,0,50q�6Z   �� 5,   
   -   5        $ txtPassword��5,      $
��Left=�6'   $��Bottom=�6B   $	��200��6]   $��
420,0,0,50q�6i   �� 5.   
   $��	Username:��6   $
��Left=�6$   $��Bottom=�6?   $��10,10,0,200q�6Z   �� 5/   
   -   5        $ txtUsername��5/      $
��Left=�6'   $��Bottom=�6B   $	��200��6]   $��
80,0,0,200q�6i   �� 51   
   $��Role ID:��6   $
��Left=�6#   $��Bottom=�6>   $��350,10,0,200q�6Y   �� 52   
   -	   5        $ 	txtRoleId��52      $
��Left=�6%   $��Bottom=�6@   $	��200��6[   $��420,0,0,200q�6g   �� 54   
   -
   5        $	��Add��54      $��75��6   $��Right=�6*   $��Bottom=�6F   $��	0,0,20,10q�6a   6t   �� 55   
   -   5        $��Update��55      $��75��6"   $��Right=�6-   $��Bottom=�6I   $��
0,0,100,10q�6d   6x   �� 56   
   -   5        $��Delete��56      $��75��6"   $��Right=�6-   $��Bottom=�6I   $��
0,0,180,10q�6d   6x   �� 57   
   -   5        $��Close��57      $��75��6!   $
��Left=�6,   $��Bottom=�6G   $��	10,0,0,10q�6b   6u   �� 58   
   -   5        $��Room Management��58      $	��118��6+   $��27��67   $��Right=�6C   $	��Top=�6_   $��10q�6w   6�   59      5;      