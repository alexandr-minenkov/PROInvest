   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5          Client.ReportShares   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:Client     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��1* �6   6,    � RowDefinitions 5   
   �� 5      $	��450 �6   6+   .+�5   
   �� $��0��6   $	��400��6!   $��
50 50 50 0q�6.   
�������$��Stretch=�6Y    �� CornerRadius$ 12��6u    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6$      Color$ 	LightGray��64      ShadowDepth$ 5Q�6F   ._�5      �� -   5         ��Name$ reportContent��5      .+�5      �� $��Мои активы��6   $��23(�6.   $��25q�6<   $��Center=�6H   6g   &   System.Windows.Controls.DataGrid  5      -   5          Name$ 
sharesGrid��5      
�������$	��250��6F   $��center=�6S   $��Center=�6n   	   
IsReadOnly$
	 True��6�   
   AutoGenerateColumns$
 False��6�      CanUserReorderColumns$ False��6�      CanUserResizeColumns$ False��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Проект��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 155 6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   ��  �� Path$ nameProject�  5      $ Акции(шт)��6-   $	 120 6@    6L   �� $ 
countShare�  5      $ Цена(р)��6-   $	 120 6>    6J   �� $ сostShares�  5      $ Стоимость(р)��6-   $	 150 6C    6O   �� $ 
valueShare�5      �� 5      -   5         ��Name$
 user��5      $
��User��6*   $��	180 0 0 0q�66   $
��Left=�6I   6f   �� 5      -   5        $
 date��5      $
��Date��6*   $��	180 0 0 0q�66   $
��Left=�6I   6f   �� 5       -   5        $	 com��5       $��@PROInvest company��6)   $��	180 0 0 0q�6C   $
��Left=�6V   6s   5!      5#      �� 5$   
   -   5         ��Name$ buttonUpdate��5$      $��Распечатать��6A   $��Right=�6W   $��0 50 125 20q�6s   $��Bottom=�6�   6�   5'      5)      