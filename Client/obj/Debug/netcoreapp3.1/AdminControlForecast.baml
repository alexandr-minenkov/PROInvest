   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5      !    Client.AdminControlForecast   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5       localclr-namespace:Client  5        � 	Resources  5
         listTemplate �� CornerRadius J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   Color   ShadowDepth �� Path �� StringFormat  listPanelTemplate��%=  &	        &	     �� 5   
   .R�5      �� $ 12��6   
����İ� 5        5      $ 12Q�6(   $ 	LightBlue��68   $ 5Q�6J   ._�5      �� $��3q�6   .+�5      �� $��16(�6    
���   �$��30��6]   $	��125��6i   $
��Bold"�6u   $
��Left=�6�   $	��Top=�6�   $��15, 0, 0, 0q�6�   ��6.   �� $ Title�6�   �� 5      $$��Стоимость акций:��6    
���   �$��DemiBold"�6K   $��Normal$�6a   $��13(�6t   $
��Left=�6�   $	��Top=�6�   $��
5, 1, 0, 0q�6�   $��20��6�   $	��120��6�   �� 5      $��16(�6    
���2�2�$��DemiBold"�6y   $��Normal$�6�   $��Center=�6�   $	��Top=�6�   $��
5, 0, 0, 0q�6�   $��25��6�   $	��135��6�   ��6.   �� $ 	ShareCost�$ $ {0}��6�   5      5      5      �� 5   
   .R�5      � 5      5      .��5      � .+�5   
   �� $��15, 15, 15, 160q�6   ._�5    
   �� -   5         ��Name$ projectsList��5       $	��320��6   #��[  5!      #��[ 5"      $��Disabled=�5#      5$      �� 5%   
   -   5        	 ��Name$	 textBoxIncrease��5%      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$,
 &Цена поднимется на(%):��6+    % !MaterialDesignFloatingHintTextBox#��[ 6c   $
��Left=�6�   $��Bottom=�6�   $��25, 0, 0, 65q�6�    �� TextWrapping$
 Wrap=�6�   $��35��6�   $	��133��6
  �� 5&   
   -   5        $	 textBoxDecrease��5&      $$
 Цена упадет на(%):��6+   #��[ 6_   $
��Left=�6�   $��Bottom=�6�   $��175, 0, 0, 65q�6�   $
 Wrap=�6�   $��35��6�   $	��105��6  �� 5'   
   -   5         ��Name$ calculateForecast��5'      $��Рассчитать��6L   $
��Left=�6a   $��310, 0, 0 ,62q�6|   $��Bottom=�6�   �� 5)   
   -   5         ��Name$ result��5)      $`��ZВ данные момент наиболее выгодны акции компании: ��6$   $y�Hidden=�6]   $��Right=�6q   $��17(�6�   $
��Bold"�6�   $��Bottom=�6�   $��20��6�   $��
0 0 100 41q�6�   6�   �� 5*   
   -   5        $ 	buttonBuy��5*      $y�Hidden=�6<   $��Купить��6P   $��Right=�6a   $��0, 40, 310, 5q�6}   $��Bottom=�6�   5,      5-      