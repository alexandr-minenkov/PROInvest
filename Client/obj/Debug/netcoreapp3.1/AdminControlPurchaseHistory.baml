   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5      (    "Client.AdminControlPurchaseHistory   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:Client     5      .��5	      � -   5          �Name$  MainGrid��5	       � ColumnDefinitions 5
   
   �� 5      $��1* �6   6,    � RowDefinitions 5   
   �� 5      $	��450 �6   6+   .+�5   
   �� $%��История операций��6   $��Center=�6+   $��20(�6H   $��DemiBold"�6V   $��0 5 0 0q�6l   6   �� 5   
   $��0��6   $��21 50 20 50q�6!   
�������$��Stretch=�6I    �� CornerRadius$ 12��6e   ._�5      &   System.Windows.Controls.DataGrid  -   5          Name$ historyGrid��5      
�������   
IsReadOnly$
 True��6?      AutoGenerateColumns$ False��6Q      CanUserReorderColumns$ False��6m      CanUserResizeColumns$ False��6�   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Пользователь��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6?   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   ��  �� Path$ login�  5      $
 Дата��6)   $	 165 67    6D   �� $
 date�  5      $
 Проект��6)   $	 125 69    6E   �� $ project�  5      $
 Цена($)��6)   $	 105 6:    6F   �� $
 cost�  5      $
 Кол-во(шт)��6)   $	 105 6=    6I   �� $ count�  5      $
 Сумма($)��6)   $	 105 6;    6G   �� $	 sum�5      5      �� 5   
   -   5         ��Name$ clearTableButton��5      $%��Очистить таблицу��6+   $��Right=�6e   $��Bottom=�6�   $��	0,0,20,10q�6�   5!      5"      