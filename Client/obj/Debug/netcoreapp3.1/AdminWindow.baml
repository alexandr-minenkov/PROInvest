   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5   	       Client.AdminWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Client     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  AdminWindow��5	   	   $	��600��6   $
��1055��6*    � WindowStartupLocation$ CenterScreen=�67   .��5
      � 
������� � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��255 �6   �� 5      $��* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ 
PrimaryMid=�6#   $��2��65   $��Stretch=�6I   .��5      � .+�5      �� $��	PROInvest��6   $
��Left=�6-   $��Center=�6H   $��88, 5, 5, 5q�6c   $
��Bold"�6x   $��15(�6�   $��Titillium Web)�6�   6�   �� 5      -   5        $��Right=�5   5   $��28��6Q   $��95��6]   $��5q�6h   .��5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Logout=�62   $��22��6@   $��15��6L   $��0 0 3 0q�6W   �� 5      $��
Выйти��6$   5      5      5      5      � 5   
   $��Stretch=�6   $��1��6-      PrimaryHueMidBrush#��[  6:    5       �� 5!      $��70 �6    �� 5"      $
��326* �6    .+�5$      � $��0��6   
�������.+�5%      �� $��Center=�6   $��	/logo.png��65   5&      �� 5'      $��Stretch=�6   $��Disabled=�69   $
��Auto=�6b   $��1��6�   .��5(      �� -   5         ��Name$
 Menu��5(      $��10q�6+   5)      5*      �� 5+   
   -   5        $ StackPanelMain��5+      $��1��6-   $��1��6:   $��Stretch=�6J   5-      5.      5/      