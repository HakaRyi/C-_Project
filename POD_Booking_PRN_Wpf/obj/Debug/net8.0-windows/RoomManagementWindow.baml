   M S B A M L   `   `   `  ����N  JPOD_Booking_PRN_Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:POD_Booking_PRN_WpfPOD_Booking_PRN_Wpf  5   	   .    (POD_Booking_PRN_Wpf.RoomManagementWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:POD_Booking_PRN_Wpf     5   	   -   5          � Title$  RoomManagementWindow��5	   	   $	��600��6&   $	��800��63   
������ � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � .+�5   
   �� $��Room Management��6   $��24(�6*   $
��Bold"�68   $
��Left=�6J   $��
313,10,0,0q�6e   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridRooms��5         AutoGenerateColumns$ False��6*   $��10,64,10,290q�6F      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Room ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *RoomId+6Q     5      $ Availability��6%   $ * 6\    6;   �� *Availability+6\     5      $ Available Date��6%   $ * 6~    6=   �� *AvailebleDate+ �� StringFormat$ {0:dd/MM/yyyy}��6~     5      $ Capacity��6%   $ * 6T    67   �� *
Capacity+6T     5      $ Description��6%   $ * 6Z    6:   �� *Description+6Z     5      $
 Name��6%   $ * 6L    63   �� *Name+6L     5      $ Price��6%   $ * 6d    64   �� *Price+$ {0:C}��6d     5      $ Building ID��6%   $ * 6Y    6:   �� *
BuildingId+6Y     5      $ Type ID��6%   $ * 6Q    66   �� *TypeId+6Q   5      �� 5   
   $��Room ID:��6   $
��Left=�6#   $��Bottom=�6>   $��	17,0,0,92q�6Y   �� 5   
   -   5        	 ��Name$	 	txtRoomID��5      $
��Left=�6%   $��Bottom=�6@   $	��120��6[   $��
106,0,0,96q�6g   
 �� 
IsReadOnly$

 True��6{   �� 5!   
   $��Availability:��6   $
��Left=�6(   $��Bottom=�6C   $��
10,0,0,131q�6^   �� 5"   
   -   5        $	 txtAvailability��5"      $
��Left=�6+   $��Bottom=�6F   $	��200��6a   $��106,0,0,135q�6m   �� 5$   
   $��Available Date:��6   $
��Left=�6*   $��Bottom=�6E   $��
10,0,0,168q�6`   (  "System.Windows.Controls.DatePicker  5%   
   -   5          Name$ dtpAvailableDate��5%      $
��Left=�6/   $��Bottom=�6J   $	��200��6e   $��106,0,0,172q�6q   �� 5'   
   $��	Capacity:��6   $
��Left=�6$   $��Bottom=�6?   $��350,0,0,168q�6Z   �� 5(   
   -   5        $	 txtCapacity��5(      $
��Left=�6'   $��Bottom=�6B   $	��200��6]   $��455,0,0,172q�6i   �� 5*   
   $��Description:��6   $
��Left=�6'   $��Bottom=�6B   $��350,0,0,131q�6]   �� 5+   
   -   5        $	 txtDescription��5+      $
��Left=�6*   $��Bottom=�6E   $	��200��6`   $��455,0,0,135q�6l   �� 5-   
   $��Name:��6   $
��Left=�6    $��Bottom=�6;   $��
10,0,0,207q�6V   �� 5.   
   -   5        $	 txtName��5.      $
��Left=�6#   $��Bottom=�6>   $	��200��6Y   $��106,0,0,211q�6e   �� 50   
   $��Price:��6   $
��Left=�6!   $��Bottom=�6<   $��
350,0,0,92q�6W   �� 51   
   -	   5        $	 txtPrice��51      $
��Left=�6$   $��Bottom=�6?   $	��200��6Z   $��
455,0,0,96q�6f   �� 53   
   $��Building ID:��6   $
��Left=�6'   $��Bottom=�6B   $��
10,0,0,247q�6]   �� 54   
   -
   5        $	 txtBuildingId��54      $
��Left=�6)   $��Bottom=�6D   $	��200��6_   $��106,0,0,251q�6k   �� 56   
   $��Type ID:��6   $
��Left=�6#   $��Bottom=�6>   $��350,0,0,247q�6Y   �� 57   
   -   5        $	 	txtTypeId��57      $
��Left=�6%   $��Bottom=�6@   $	��200��6[   $��455,0,0,251q�6g   �� 59   
   -   5         ��Name$ btnAdd��59      $	��Add��6!   $��Right=�6/   $��Bottom=�6K   $��75��6f   $��	0,0,90,10q�6q   6�   �� 5:   
   -   5        $ 	btnUpdate��5:      $��Update��6$   $��Right=�65   $��Bottom=�6Q   $��75��6l   $��
0,0,170,10q�6w   6�   �� 5;   
   -   5        $ 	btnDelete��5;      $��Delete��6$   $��Right=�65   $��Bottom=�6Q   $��75��6l   $��
0,0,250,10q�6w   6�   �� 5<   
   -   5        $��Close��5<      $
��Left=�6!   $��75��6<   $��
715,0,0,10q�6G   $��Bottom=�6[   6v   �� 5=   
   -   5        $ btnBook��5=      $
��Book��5>      $
��Left=�6   $��20��67   $��680,318,0,0q�6C   $	��Top=�6X   $	��110��6p   6|   5?      5@      