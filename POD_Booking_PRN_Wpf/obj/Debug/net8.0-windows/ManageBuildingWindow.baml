   M S B A M L   `   `   `  ����N  JPOD_Booking_PRN_Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:POD_Booking_PRN_WpfPOD_Booking_PRN_Wpf  5   	   .    (POD_Booking_PRN_Wpf.ManageBuildingWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:POD_Booking_PRN_Wpf     5   	   -   5          � Title$  BuildingManagementWindow��5	   	   $	��600��6*   $	��800��67   
����ح� � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � .+�5   
   �� $��Building Management��6   $��24(�6.   $
��Bold"�6<   $��Center=�6N   $��0,10,0,0q�6k   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridBuildings��5         AutoGenerateColumns$ False��6.   $��10,64,10,290q�6J      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Building ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *
BuildingId+6Y     5      $
 Name��6%   $ * 6L    63   �� *Name+6L     5      $ Address��6%   $ * 6R    66   �� *	Address+6R     5      $ Location��6%   $ * 6T    67   �� *
Location+6T     5      $ Description��6%   $ * 6Z    6:   �� *Description+6Z   5      �� 5   
   $��Building ID:��6   $
��Left=�6'   $��Bottom=�6B   $��	17,0,0,92q�6]   �� 5   
   -   5         ��Name$ txtBuildingID��5      $
��Left=�6)   $��Bottom=�6D   $	��120��6_   $��
106,0,0,96q�6k   	 �� 
IsReadOnly$
	 True��6   �� 5   
   $��Name:��6   $
��Left=�6    $��Bottom=�6;   $��
10,0,0,131q�6V   �� 5   
   -   5        $ txtName��5      $
��Left=�6#   $��Bottom=�6>   $	��200��6Y   $��106,0,0,135q�6e   �� 5    
   $��Address:��6   $
��Left=�6#   $��Bottom=�6>   $��
10,0,0,168q�6Y   �� 5!   
   -   5        $ 
txtAddress��5!      $
��Left=�6&   $��Bottom=�6A   $	��200��6\   $��106,0,0,172q�6h   �� 5#   
   $��	Location:��6   $
��Left=�6$   $��Bottom=�6?   $��350,0,0,168q�6Z   �� 5$   
   -   5        $ txtLocation��5$      $
��Left=�6'   $��Bottom=�6B   $	��200��6]   $��455,0,0,172q�6i   �� 5&   
   $��Description:��6   $
��Left=�6'   $��Bottom=�6B   $��350,0,0,131q�6]   �� 5'   
   -   5        $ txtDescription��5'      $
��Left=�6*   $��Bottom=�6E   $	��200��6`   $��455,0,0,135q�6l   �� 5)   
   -   5        $	��Add��5)      $��Right=�6   $��Bottom=�6;   $��75��6V   $��	0,0,90,10q�6a   6t   �� 5*   
   -	   5        $��Update��5*      $��Right=�6"   $��Bottom=�6>   $��75��6Y   $��
0,0,170,10q�6d   6x   �� 5+   
   -
   5        $��Delete��5+      $��Right=�6"   $��Bottom=�6>   $��75��6Y   $��
0,0,250,10q�6d   6x   �� 5,   
   -   5        $��Close��5,      $
��Left=�6!   $��75��6<   $��
715,0,0,10q�6G   $��Bottom=�6[   6v   5-      5.      