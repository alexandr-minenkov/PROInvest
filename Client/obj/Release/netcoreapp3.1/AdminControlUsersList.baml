   M S B A M L   `   `   `  ���� A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  "    Client.AdminControlUsersList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     &localclr-namespace:Client     .��� -     �Name$  MainGrid�� � ColumnDefinitions �� $��1* � � RowDefinitions �� $	��450 �.+��� $��0��$��50 50 50 50q�
��� � �$��Stretch=� �� CornerRadius$ 12��._�&   System.Windows.Controls.DataGrid  -     Name$ 	usersGrid��
�������   
IsReadOnly$
 True��   AutoGenerateColumns$ False��   CanUserReorderColumns$ False��   CanUserResizeColumns$ False��	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 Фамилия��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ surname�  $
 Имя��$	 105  �� $
 name�  $
 
Логин��$	 115  �� $ login�  $
 Пароль��$	 115  �� $ password�  $
 Эл. почта��$	 150  �� $ email��� -   $8��2Изменить роль пользователя��$��Right=�$��Bottom=�$��	0,0,50,10q�