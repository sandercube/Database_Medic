   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.4.3.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   J FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1 5   	   )   #WpfApplication1.Window_Add_Schedule   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	     � Title$   ��5	   	    � WindowStartupLocation$ CenterScreen=�6      AccentColorBrush#���   67    � 
ResizeMode$ NoResize=�6g    � WindowStyle$ ThreeDBorderWindow=�6}   $��Disabled=�6�   $	��400��6�   $	��400��6�    J� Effect 5
      3  -System.Windows.Media.Effects.DropShadowEffect  5   
      
BlurRadius$ 10Q�6      ShadowDepth$ 2Q�6+      Color$ 	#BF000000��6;   .��5      � .+�5   
   �� -   5         ��Name$ btn_Add_Schedule��5      $��Добавить��6+   $��
30,0,30,70q�6>   $��Bottom=�6R   $��31��6m   ���	#FF689F38
�������  ButtonStyleGreen#���  6�   	 � Cursor$
	 Hand��6�   6�   �� 5   
   -   5        $ btn_Cancel_Schedule��5      $��Отмена��6.   $��
30,0,30,25q�6?   $��Bottom=�6S   $��31��6n   ���	#FF689F38
�������#���  6�   $
	 Hand��6�   6�   �� 5   
   $��0q�6   $	��Top=�6    $��Center=�68   .+�5      �� $+��%Добавить расписание��6   
�������$��18(�6F   $��Center=�6T   $��0q�6q   5      �� 5   
   $	��394��6   $	��371��6!   $��0,45,0,0q�6.   $	��Top=�6@   .+�5      �� $��10q�6   
 �� Orientation$
 
Horizontal=�6%   $	��Top=�6>   $��Right=�6V   .+�5      �� 
�������$��№ Врача��6/   $��20,0,0,0q�6>   $��14(�6P   $��Center=�6^   $��Right=�6y   �� 5      -   5         ��Name$ txt_id_doctor��5      $��	15,0,20,0q�61   $	��200��6D   $��Center=�6P   $��Right=�6k   $��23��6�   6�   5      �� 5      $��30,10,10,10q�6   $
 
Horizontal=�6.   $	��Top=�6G   $��Right=�6_   .+�5      �� 
�������$��Дата приёма��6/   $��10,0,0,0q�6B   $��14(�6T   $��Right=�6b   $��Center=�6~   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dp_schedule��5      $��	15,0,20,0q�62   $	��200��6E   $��Center=�6Q      SelectedDateFormat$
 Long=�6l   $��23��6�   6�   5      �� 5      $��
0,10,10,10q�6   $
 
Horizontal=�6-   $	��Top=�6F   $��Right=�6^   .+�5      �� 
�������$!��Время работы С:��6/   $��20,0,0,0q�6F   $��14(�6X   $��Center=�6f   $��Right=�6�   �� 5      -   5        $ txt_time_on��5      $��	15,0,20,0q�6/   $	��200��6B   $��Center=�6N   $��Right=�6i   $��23��6�   6�   5      �� 5       $��
0,10,10,10q�6   $
 
Horizontal=�6-   $	��Top=�6F   $��Right=�6^   .+�5!      �� 
�������$#��Время работы ДО:��6/   $��20,0,0,0q�6G   $��14(�6Y   $��Center=�6g   $��Right=�6�   �� 5"      -   5        $ txt_time_off��5"      $��	15,0,20,0q�60   $	��200��6C   $��Center=�6O   $��Right=�6j   $��23��6�   6�   5#      5$      5%      5&      