   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5   	       Client.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	    localclr-namespace:Client  5   	     � Title$  Client��5	   	   $	��600��6   $	��800��6%    � WindowStyle$ 
ToolWindow=�61    � 
ResizeMode$ NoResize=�6J    � WindowStartupLocation$ CenterScreen=�6`    � WindowState$ Normal=�6�    � Cursor$ Arrow��6�   .��5
      � 
�������.+�5   
   �� $&�� Добро пожаловать!��6   $��Center=�6,   $��	0,0,0,420q�6I   $��Center=�6\   $	��300��6w   $
��Bold"�6�   $��30(�6�   �� 5   
   $��	PROInvest��6   $��Center=�6%   $��Center=�6B   $��0, 0, 0, 330q�6]   $��20(�6s   $��Titillium Web)�6�   6�   �� 5   
   $I��C''Ваши инвестиции - в надежных руках!''��6   $��Italic$�6C   $��Center=�6V   $��Center=�6s   $��0, 0, 0, 285q�6�   $��13(�6�   6�   �� 5   
      PrimaryHueDarkBrush#���   6   $	��400��6E   $��15,100,15,0q�6T   
�������$��Center=�6|    �� Padding$ 30q�6�   $	��450��6�    �� CornerRadius$ 20��6�   $��2��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 30Q�6$   
   Color$
 	LightGray��64      ShadowDepth$ 5Q�6F   ._�5      �� .+�5      �� $ ��Вход в аккаунт��6   $��25(�62   $��Medium"�6@   $��0 0 0 20q�6T   6h   �� 5      -   5         ��Name$ textBoxLogin��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Введите логин��60    % !MaterialDesignFloatingHintTextBox#��[ 6_   G� 5      -   5         G�Name$ passwordBox��5      $! Введите пароль��63    ) %MaterialDesignFloatingHintPasswordBox#��[ 6c   $ IBeam��6�   �� 5      -   5        $��
Войти��5      $	��1.5q�6C   ���#123db5   MaterialDesignOutlinedButton#��[ 6o   
�������
���   �$��0,30,0,0q�6�   $	��200��6�   �� 5      -   5        $*��$Зарегистрироваться��5      $	��1.5q�66   $��Center=�6f   $��0,10,0,0q�6�   $	��200��6�   �� 5      -   5         ��Name$ buttonForgottenPass��5      $ ��Забыли пароль?��6X     MaterialDesignFlatButton#��[ 6q   $	��1.5q�6�   $��Center=�6�   $��0,10,0,0q�6�   $	��200��6�   5      5      �� 5   
   $��Center=�6   $��0, 300, 0, 0q�60   5      5       5!      