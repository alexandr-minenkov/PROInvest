   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5          Client.UserControlShares   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:Client     5      .��5	      � -   5          �Name$  MainGrid��5	       � ColumnDefinitions 5
   
   �� 5      $��1* �6   6,    � RowDefinitions 5   
   �� 5      $	��450 �6   6+   .+�5   
   �� $��0��6   $	��400��6!   $��
50 50 50 0q�6.   
�������$��Stretch=�6Y    �� CornerRadius$ 12��6u    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6$      Color$ 	LightGray��64      ShadowDepth$ 5Q�6F   ._�5      �� .+�5      �� $��Мои активы��6   $��23(�6*   $��25q�68   $��Center=�6D   6c   &   System.Windows.Controls.DataGrid  5      -   5          Name$ 
sharesGrid��5      
�������$	��250��6B   $��center=�6O   $��Center=�6j   	   
IsReadOnly$
	 True��6�   
   AutoGenerateColumns$
 False��6�      CanUserReorderColumns$ False��6�      CanUserResizeColumns$ False��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Проект��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 155 69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   ��  �� Path$ nameProject�  5      $ Акции(шт)��6)   $	 120 6<    6H   �� $ 
countShare�  5      $ Цена($)��6)   $	 120 6:    6F   �� $ сostShares�  5      $ Стоимость($)��6)   $	 150 6?    6K   �� $ 
valueShare�5      �� 5      -   5         ��Name$ buttonUpdate��5      $��Обновить��6J   $
��Left=�6]   $��	75 10 0 0q�6x   $��Bottom=�6�   6�   5       5"      �� 5#   
   -   5        $ 
buttonSell��5#      $��Продать��6>   $��Right=�6P   $��0 10 125 27q�6l   $��Bottom=�6�   6�   5'      5(      