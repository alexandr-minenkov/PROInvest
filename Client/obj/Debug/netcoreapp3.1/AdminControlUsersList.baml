   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5      "    Client.AdminControlUsersList   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:Client     5      .��5	      � -   5          �Name$  MainGrid��5	       � ColumnDefinitions 5
   
   �� 5      $��1* �6   6,    � RowDefinitions 5   
   �� 5      $	��450 �6   6+   .+�5   
   �� $��0��6   $��21 50 20 50q�6!   
��� � �$��Stretch=�6I    �� CornerRadius$ 12��6e   ._�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	usersGrid��5      
�������   
IsReadOnly$
 True��6=      AutoGenerateColumns$ False��6O      CanUserReorderColumns$ False��6k      CanUserResizeColumns$ False��6�   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Фамилия��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6:   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   ��  �� Path$ surname�  5      $
 Имя��6)   $	 105 66    6B   �� $
 name�  5      $
 
Логин��6)   $	 115 68    6D   �� $ login�  5      $
 Пароль��6)   $	 115 69    6E   �� $ password�  5      $
 Эл. почта��6)   $	 150 6<    6H   �� $ email�  5      $
 Доступ��6)   $	 130 69    6E   �� $ access�5      5      �� 5   
   -   5        $8��2Изменить роль пользователя��5      $��Right=�6U   $��Bottom=�6q   $��	0,0,20,10q�6�   �� 5   
   -   5        $-��'Удалить пользователя��5      $��Right=�6O   $��Bottom=�6k   $��
0,0,260,10q�6�   �� 5   
   -   5        $��Обновить��5      $
��Left=�6?   $��Bottom=�6Z   $��	21,0,0,10q�6u   5"      5#      