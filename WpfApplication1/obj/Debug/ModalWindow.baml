   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.4.3.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   J FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1 5   	   !   WpfApplication1.ModalWindow   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	     � Title$0  *Поиск визитов пациента��5	   	    � WindowStartupLocation$ CenterScreen=�6(   $	��155��6M      AccentColorBrush#���   6Z   $	��275��6�    � 
ResizeMode$ NoResize=�6�    � WindowStyle$ ThreeDBorderWindow=�6�   $��Disabled=�6�    J� Effect 5
      3  -System.Windows.Media.Effects.DropShadowEffect  5   
      
BlurRadius$ 10Q�6      ShadowDepth$ 2Q�6+      Color$ 	#BF000000��6;   .��5      � $��10q�6    J� 	AllowDrop . 	 � RowDefinitions	 5   
   �� 5      $��20 �6   �� 5      $��26 �6   �� 5      $
��Auto �6   .+�5   
   �� 
�������:8Введите личный номер пациента:6G   �� 5   
   -   5        $��txt_search_visit��5      $��1��6*   $	��250��67   .��6F   5      � 5   
   $��2��6   $��0,20,0,0q�6!   $��Center=�63   .+�5      �� -   5        
 �� 	IsDefault
 . $��60��5   ;   $��0,0,80,0q�6I   ���	#FF689F38
�������$��12(�6�   .��6�   OK6�   �� 5       �� IsCancel . $��60��6%   $��0q�63   ���	#FF689F38
�������$��12(�6h   .��6v   Отмена6~   5      5      5      