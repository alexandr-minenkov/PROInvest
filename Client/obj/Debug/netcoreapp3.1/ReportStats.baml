   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5      A =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient 5         Client.ReportStats   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      &localclr-namespace:Client     5      .��5
      � .+�5   
   �� -   5          ��Name$  reportContent��5      .+�5      �� $e��_График изменения цен на акции за последние 6 месяцев��6   $��16(�6S   $��DemiBold"�6a   $��10q�6w   $��Center=�6�   6�   �� 5   
   -   5         ��Name$ borderChart��5      $	��300��6&   $	��600��63   $��0 10 0 0q�6?   ._�5      #   LiveCharts.Wpf.CartesianChart  &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�6E      Series 6!   �� *SeriesCollection+   AxisY 5         LiveCharts.Wpf.Axis     Title$ Цена��6      LabelFormatter 6,   �� *
YFormatter+6T      AxisX 5        $ 
Месяц��6      Labels 6-   �� *Labels+6I   5      5      �� 5      -   5        	 ��Name$
	 user��5      $
��User��6&   $��	180 0 0 0q�62   $
��Left=�6E   6b   �� 5      -   5        $
	 date��5      $
��Date��6&   $��	180 0 0 0q�62   $
��Left=�6E   6b   �� 5      -   5        $		 com��5      $��@PROInvest company��6%   $��	180 0 0 0q�6?   $
��Left=�6R   6o   5      �� 5   
   -   5        
 ��Name$
 buttonReport��5      $'��!Распечатать отчет��6B   $��	80 60 0 0q�6^   $��Center=�6q   $��Bottom=�6�   6�   5       5!      