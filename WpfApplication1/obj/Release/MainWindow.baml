   M S B A M L   `   `   `  ���� T  PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls   WpfApplication1    WpfApplication1.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  :d2http://schemas.microsoft.com/expression/blend/2008  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  -   (   "MahApps.Metro.Controls.MetroWindow   Name$  metroWindow�� � Title$2 ,Учёт пациентов больницы��   	TitleCaps .     TitlebarHeight$ 40�� � 
ResizeMode$ CanMinimize=�$	��800��$	��600��
�������   EnableDWMDropShadow .  � WindowStartupLocation$ CenterScreen=� � 	Resources    GridPacientsOpen �� TargetProperty	 �� 
TargetName<  6System.Windows.Media.Animation.EasingThicknessKeyFrame
 p� KeyTime p� Value  GridPacientsClose  GridCardsOpen  GridCardsClose  GridDoctorsOpen  GridDoctorsClose  RightPanelOpen   EasingFunction4  .System.Windows.Media.Animation.ExponentialEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode  RightPanelClose  RightPanelEditOpen 	 RightPanelEditClose 
 RightPanelTerOpen  RightPanelTerClose  BotPanelDelOpen  BotPanelDelClose��%G  &	        &	 e     &	 �     &	 ,    &	 �    &	 �    &	 W    &	 �    &	 l    &		     &	
 �    &	     &	 �    &	 4    �� .��r� $ (FrameworkElement.Margin)�$	 Grid_Pacient��.	�  $
 0:0:0.2��$ 0,30,0,0q��� .��r� $ (FrameworkElement.Margin)�$	 Grid_Pacient��.	�  $
 0:0:0.2��$ 0,0,0,0q��� .��r� $ (FrameworkElement.Margin)�$	 
Grid_Cards��.	�  $
 0:0:0.2��$ 0,30,0,0q��� .��r� $ (FrameworkElement.Margin)�$	 
Grid_Cards��.	�  $
 0:0:0.2��$ 0,0,0,0q��� .��r� $ (FrameworkElement.Margin)�$	 Grid_Doctors��.	�  $
 0:0:0.2��$ 0,30,0,0q��� .��r� $ (FrameworkElement.Margin)�$	 Grid_Doctors��.	�  $
 0:0:0.2��$ 0,0,0,0q��� .��r� $ (FrameworkElement.Margin)�$	 PanelAddPacient��.	�  $
 0��$ 
0,0,-345,0q�  $
 0:0:0.2��$ 0q�   $ EaseOut=��� .��r� $ (FrameworkElement.Margin)�$	 PanelAddPacient��.	�  $
 0��$ 0q�  $
 0:0:0.2��$ 
0,0,-345,0q��� .��r� $ (FrameworkElement.Margin)�$	 PanelEditPacient��.	�  $
 0��$ 
0,0,-345,0q�  $
 0:0:0.2��$ 0q�   $ EaseOut=��� .��r� $ (FrameworkElement.Margin)�$	 PanelEditPacient��.	�  $
 0��$ 0q�  $
 0:0:0.2��$ 
0,0,-345,0q��� .��r� $ (FrameworkElement.Margin)�$	 PanelAddTerapy��.	�  $
 0��$ 
0,0,-345,0q�  $
 0:0:0.2��$ 0q�   $ EaseOut=��� .��r� $ (FrameworkElement.Margin)�$	 PanelAddTerapy��.	�  $
 0��$ 0q�  $
 0:0:0.2��$ 
0,0,-345,0q��� .��r� $ (FrameworkElement.Margin)�$	 PanelDeletePacient��.	�  $
 0��$ 	0,0,0,-70q�  $
 0:0:0.3��$ 0,0,0,0q�   $ EaseOut=��� .��r� $ (FrameworkElement.Margin)�$	 PanelDeletePacient��.	�  $
 0��$ 0,0,0,0q�  $
 0:0:0.2��$ 	0,0,0,-70q� � Triggers :�  :� RoutedEvent$ FrameworkElement.Loaded��.��� .+��� -    ��Name$ PanelAddPacient��$��Right=�$	��340�����	#FF004D40 K� ZIndex$	 100��$��
0,0,-345,0q�$	��571�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     	Direction$	 180Q�   ShadowDepth$ 1Q�   
BlurRadius$ 4Q�.+��� $��50�� �� Orientation$ 
Horizontal=�.+��� -   
�������$
��Left=�$
��Wrap=�$	����$��Center=�$��	15,0,15,0q�$��./Resources/#FontAwesome)�$��20(� � Cursor$
 Hand���� $
��Wrap=�
�������$+��%Добавление пациента��$��Center=�$��16(��� $ 
Horizontal=�.+��� -    ��Name$ txtfamp��*   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Фамилия��$��23�� �� TextWrapping$
 Wrap=�$	��150��$
��Left=�$��Center=�$��10q��� -   $ txtnamep��$ Имя��$��23��$
 Wrap=�$�� ��$	��150��$
��Left=�$��Center=�$��10q��� $ 
Horizontal=�.+��� -   $ txtotchp��$ Отчество��$��23��$
 Wrap=�$�� ��$	��150��$��Center=�$��10q��� -    ��Name$ cmbpolp��$	��120��$��Center=�$��40,0,0,0q� �� SelectedIndex$ 0��.@��� $��жен���� $��муж���� $ 
Horizontal=�.+��� -   $ 	txtphonep��$ Телефон��$��23��$
 Wrap=�$�� ��$	��150��$��Center=�$��10q�(  "System.Windows.Controls.DatePicker  -	     Name$ dpbirth��$	��120��$��Center=�$��40,0,0,0q��� $ 
Horizontal=�.+��� -
   $ 
txtadressp��$ 
Адрес��$��23��$
 Wrap=�$�� ��$	��150��$��Center=�$��10q��� -   $ cmbcityp��$	��120��$��Center=�$��40,0,0,0q�$ 0��.@��� $��
Минск���� $ 
Horizontal=�.+��� -   $ 
txtpalatep��$ Палата��$��23��$
 Wrap=�$�� ��$	��150��$��Center=�$��10q��� -   $ departament_list��$	��120��$��Center=�$��40,0,0,0q� �� SelectedValuePath �� *ID_Departament+�� $ 
Horizontal=�.+�  -   $ 	dpdateinp��$	��120��$��Center=�$��210,10,0,10q�   SelectedDateFormat$ Short=��� $ 
Horizontal=�.+��� -     ��Name$  btnAddPacient��$��Добавить��$��75��$��50,20,20,20q�$��12(����	#FF689F38
�������  ButtonStyleGreen#���  $
 Hand���� -   $  btnAddPacientCancel��$��Отмена��$��75��$��70,20,20,20q�$��12(����	#FF689F38
�������#���  $
 Hand���� -   $ PanelEditPacient��$��Right=�$	��340�����#004D40$ 3��$��
0,0,-345,0q�   $	 180Q�$ 1Q�$ 4Q�.+��� $��50��$ 
Horizontal=�.+��� 
�������$
��Left=�$
��Wrap=�$	����$��Center=�$��	15,0,15,0q�$��./Resources/#FontAwesome)�$��20(�$
 Hand���� $
��Wrap=�
�������$3��-Редактирование пациента��$��Center=�$��16(��� $ 
Horizontal=�.+��� $ Фамилия��$��23��$
 Wrap=�$�� ��$	��150��$
��Left=�$��Center=�$��10q��� $ Имя��$��23��$
 Wrap=�$�� ��$	��150��$
��Left=�$��Center=�$��10q��� $ 
Horizontal=�.+��� $ Отчество��$��23��$
 Wrap=�$�� ��$	��150��$��Center=�$��10q��� $	��120��$��Center=�$��40,0,0,0q��� $ 
Horizontal=�.+��� $ Телефон��$��23��$
 Wrap=�$�� ��$	��150��$��Center=�$��10q�  $	��120��$��Center=�$��40,0,0,0q��� $ 
Horizontal=�.+��� $ 
Адрес��$��23��$
 Wrap=�$�� ��$	��150��$��Center=�$��10q��� $	��120��$��Center=�$��40,0,0,0q��� $ 
Horizontal=�.+��� $ Палата��$��23��$
 Wrap=�$�� ��$	��150��$��Center=�$��10q��� $	��120��$��Center=�$��40,0,0,0q��� $ 
Horizontal=�.+��� $ 
Время��$��23��$
 Wrap=�$�� ��$	��150��$��Center=�$��10q�  $	��120��$��Center=�$��40,0,0,0q�$ Short=��� $ 
Horizontal=�.+��� $��Сохранить��$��78��$��50,20,20,20q�$��12(����	#FF689F38
�������#���  $
 Hand���� -   $��Отмена��$��75��$��70,20,20,20q�$��12(����	#FF689F38
�������#���  $
 Hand���� -   $ PanelAddTerapy��$��Right=�$	��571��$	��340�����#004D40$ 3��$��
0,0,-345,0q�   $	 180Q�$ 1Q�$ 4Q�.+��� $��50��$ 
Horizontal=�.+��� 
�������$
��Left=�$
��Wrap=�$	����$��Center=�$��	15,0,15,0q�$��./Resources/#FontAwesome)�$��20(�$
 Hand���� $
��Wrap=�
�������$3��-Назначение обследования��$��Center=�$��16(��� $ 
Horizontal=�.+��� $ Номер карты��$��23��$
 Wrap=�$�� ��$	��150��$
��Left=�$��Center=�$��10q��� $ 
Horizontal=�.+��� $ 
Время��$��23��$
 Wrap=�$�� ��$	��150��$��Center=�$��10q�  $	��120��$��Center=�$��40,0,0,0q�$ Short=��� $ 
Horizontal=�.+��� $ Процедура��$��70��$
 Wrap=�$�� ��$��Center=�$��10q�$	��320���� $ 
Horizontal=�.+��� $ Анализы��$��70��$
 Wrap=�$�� ��$��Center=�$��10q�$	��320���� $ 
Horizontal=�.+��� $ 
Отчёт��$��70��$
 Wrap=�$�� ��$��Center=�$��10q�$	��320���� $ 
Horizontal=�.+��� $��Добавить��$��78��$��50,20,20,20q�$��12(����	#FF689F38
�������#���  $
 Hand���� -   $��Отмена��$��75��$��70,20,20,20q�$��12(����	#FF689F38
�������#���  $
 Hand���� $��54��$	��Top=����	#FF004D40$ 2��$ 
Horizontal=�.+��� $��54��$��	450,0,0,0q�$ 
Horizontal=�$��Right=�.+��� -   $	����
�������$��	10,0,20,0q�$��Right=�$��Center=�$��./Resources/#FontAwesome)�$��20(�$
 Hand���� $��54��$ 
Horizontal=�$��90,0,0,0q�$��Right=�.+��� -   $ 
txt_search��$ Поиск...��$
 Wrap=�$�� ��$��Center=�$	��160��+   %MahApps.Metro.Controls.ControlsHelper!   FocusBorderBrush
! �����" �� 
CaretBrush" �	#FFCCCCCC�� -   $	����$��Center=�$��40��$��./Resources/#FontAwesome)����	#FFCCCCCC$��0,1,1,1q�#���  
����������	#FF689F38$
 Hand��4	   .MahApps.Metro.Controls.MetroAnimatedTabControl	  -   # 	 Name$# metroTabControl��$��Stretch=�$ 2��$��0,0,0,0q�.@��� -   $ ��Name$$ Item_0�����	#FF004D40���� $��50��$
��Left=�$ 
Horizontal=�$
 Hand��.+��� $	����
�������$��10,0,0,0q�$
��Left=�$��Center=�$��./Resources/#FontAwesome)�$��20(��� $��ПАЦИЕНТЫ��
�������$��Center=�$
 Hand��.��� ���	#FFE5E5E5$��0,0,0,0q�$��Stretch=�.+��� -   $ 	PanelNavi��$ 
Horizontal=�$��Stretch=�$��30�����	#FFECEFF1$��0q�$	��Top=�.+��� -   $ 
Horizontal=�$��Stretch=�$
 Hand��$��0,0,0,0q�.+��� $
��Wrap=�$	����$��Center=�$��	15,0,10,0q�$��FontAwesome)�$��16(�$
 Hand��% � ToolTip$'% !Добавить пациента�����	#FF689F38�� $
��Wrap=�
���   �$'��!Добавить пациента��$��Center=�$
 Hand��$��Segoe UI Light)��� -   $��30��$ 
Horizontal=�$��Stretch=�$
 Hand��.+��� $
��Wrap=�$	����$��Center=�$��	15,0,10,0q�$��FontAwesome)�$��16(�$
 Hand���� $
��Wrap=����	#FF41617C$��Изменение��$��Center=�$��Segoe UI Light)��� -   $��30��$ 
Horizontal=�$��Stretch=�$
 Hand��.+��� $
��Wrap=�$	����$��Center=�$��	15,0,10,0q�$��FontAwesome)�$��16(�$
 Hand�����	#FFEF5350�� $
��Wrap=�
���   �$%��Удалить пациента��$��Center=�$��Segoe UI Light)�&
   System.Windows.Controls.DataGrid
  -   & 
 Name$& Grid_Pacient��' 
  AutoGenerateColumns' .  $��Stretch=�$��0,0,0,0q����	#FFECEFF1( 
  GridLinesVisibility$	( All=�) 
  
IsReadOnly) . * J� RenderTransformOrigin$* 0.5,0.5&�+ 
  Columns+ 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn,   Header$	, №��-   Width5  /System.Windows.Controls.DataGridLengthConverter$- 50 1  +System.Windows.Controls.DataGridBoundColumn.   Binding. �� *
ID_Pacient+  $, Фамилия��$- 90 . �� *	FamiliyaP+  $, Имя��$- 90 . �� *NameP+  $, Отчество��$- 90 . �� *
OtchestvoP+  $, Пол��$- 50 . �� *Pol+  $, Дата Рождения��$- 91 . �� *	DateBirth+/ �� StringFormat$/ 
dd.MM.yyyy��  $, 
Город��$- 75 . �� *City+  $, 
Адрес��$	- 175 . �� *Adress+  $, Телефон��$	- 110 . �� *Phone+  $%, Дата поступления��$	- 103 . �� *DateIn+$/ 
dd.MM.yyyy���� -   $$ Item_1�����	#FF004D40���� $��50��$
��Left=�$ 
Horizontal=�.+��� $
��Wrap=�$	����
�������$��0,0,0,0q�$��Center=�$��./Resources/#FontAwesome)�$��20(��� $��
КАРТЫ��
�������$��Center=�.��� ���	#FFE5E5E5.+��� -    $ 
PanelNavi1��$ 
Horizontal=�$��Stretch=�$��30�����	#FFECEFF1$��0q�$	��Top=�.+��� -!   $ 
Horizontal=�$��Stretch=�$
 Hand��$��0,0,0,0q�.+��� $
��Wrap=�$	����$��Center=�$��	15,0,10,0q�$��FontAwesome)�$��16(�$
 Hand��$'% !Добавить пациента�����	#FF689F38�� $
��Wrap=�
���   �$'��!Добавить пациента��$��Center=�$
 Hand��$��Segoe UI Light)��� -"   $��30��$ 
Horizontal=�$��Stretch=�$
 Hand��.+��� $
��Wrap=�$	����$��Center=�$��	15,0,10,0q�$��FontAwesome)�$��16(�$
 Hand�����	#FF41617C$* -12.562,5.125&��� $
��Wrap=�
���   �$��Изменение��$��Center=�$��Segoe UI Light)��� -#   $��30��$ 
Horizontal=�$��Stretch=�$
 Hand��.+��� $
��Wrap=�$	����$��Center=�$��	15,0,10,0q�$��FontAwesome)�$��16(�$
 Hand�����	#FFEF5350�� $
��Wrap=�
���   �$%��Удалить пациента��$��Center=�$��Segoe UI Light)�
  -$   $& 
Grid_Cards��' .  $��Stretch=�$��0,0,0,0q����	#FFECEFF1$	( All=�) . $* 0.5,0.5&�z�V� .~��� �� �� T� +   $	, №��$- 40 . �� *	ID_Card+  $, Фамилия��$- 95 . �� *	FamiliyaP+  $, Имя��$- 95 . �� *NameP+  $, Отчество��$- 90 . �� *
OtchestvoP+  $, Палата��$- 75 . �� *NumberPalate+  $, Отделение��$- 90 . �� *	NameDep+  $, Док.Фамилия��$	- 120 . �� *Familiya_Doc+  $, Док.Имя��$- 90 . �� *	NameDoc+  $, Должность��$- 90 . �� *
Function+�� ���	#FF004D40���� $��50��$
��Left=�$ 
Horizontal=�.+��� $
��Wrap=�$	����
�������$��0,0,0,0q�$��Center=�$��./Resources/#FontAwesome)�$��20(��� $��
ВРАЧИ��
�������$��Center=�.��� ���	#FFE5E5E5.+�
  -%   $& Grid_Doctors��' .  $��Stretch=�$��0,0,0,0q����	#FFECEFF1$	( All=�) . $* 0.5,0.5&�+   $	, №��$- 40 . �� *	ID_Doctor+  $, Фамилия��$- 90 . �� *Familiya_Doc+  $, Имя��$- 90 . �� *	NameDoc+  $, Отчество��$- 90 . �� *Otchestvo_Doc+  $, Должность��$	- 100 . �� *
Function+  $, Кабинет��$- 80 . �� *	Cabinet+  $, Отделение��$- 90 . �� *	NameDep+  $, Телефон��$	- 165 . �� *
PhoneDoc+�� ���	#FF004D40���� $��50��$
��Left=�$ 
Horizontal=�.+��� $
��Wrap=�$	����
�������$��0,0,0,0q�$��Center=�$��./Resources/#FontAwesome)�$��20(��� $��ПАЛАТЫ��
�������$��Center=�.��� ���	#FFE5E5E5�� ���	#FF004D40���� -&   $��50��$
��Left=�$ 
Horizontal=�.+��� $
��Wrap=�$	����
�������$��0,0,0,0q�$��Center=�$��./Resources/#FontAwesome)�$��20(��� $��ЛЕЧЕНИЕ��
�������$��Center=�.��� ���	#FFE5E5E5�� -'   $ PanelDeletePacient��$��Stretch=�$ 
Horizontal=����	#FFAED581$ 3��$��65��$��Bottom=�$��	0,0,0,-70q�.+��� $
��Wrap=�$��Center=�$A��;Введите личный номер пациента №��$��90,0,0,0q�$��14(�
��������� -(   $ txtIDpacientDel��$
 Wrap=�$��Center=�$�� ��$	��130��$��20,0,0,0q��� -)   $��Удалить�����	#FFEF5350$��Center=�$��75��$��30,0,0,0q�
�������  	ButtonRed#���  