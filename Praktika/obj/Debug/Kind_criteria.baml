   M S B A M L   `   `   `  ����C  ?Praktika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PraktikaPraktika  5   	       Praktika.Kind_criteria   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2230, Culture=neutral, PublicKeyToken=df2a72020bd7962af bMaterialDesignThemes.MahApps, Version=0.1.6.2230, Culture=neutral, PublicKeyToken=df2a72020bd7962a@design1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   $localclr-namespace:Praktika   5   	   -   5          � Title$  Критерии��5
   
   $	��600��6   $	��800��6(   $��16(�64   $��Verdana)�6B   ���#8FA3AD � WindowStartupLocation$ CenterScreen=�6l   .��5      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5       6!   �� 5!      6!   �� 5"      6!   �� 5#      6!   �� 5$      6!   �� 5%      6!   �� 5&      6!   �� 5'      6!   .+�5+   
   �� -   5        $��
lbl_Rezume��5+   %   $��Verdana)�6   $��0��67   $��1��6D   $��11��6T   $��Критерии��6i   $��Center=�6|   $��16(�6�   $��Center=�6�   &   System.Windows.Controls.DataGrid  5,   
   -   5        $��dg_Kind_criteria��5,         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6+      AutoGenerateColumns .    
IsReadOnly . $��1��6k   $��1��6{   $��11��6�   $��4��6�      ColumnHeaderStyle 5-      �� 5.       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5/      �� 	 �� Property	 � ��
 �� Value$

 Bold"�64   �� 50      	 � ��$
 Center=�6<   �� 51      	 � ��$
 Center=�6C   �� 52      	 � ��

 �����64   �� 53      	 � ��

 �����63   �� 54      	 � ��$
 10, 10, 0, 10q�6/   55      57      �� 59   
   -   5        $��lbl_kriteria��59   %   $��Verdana)�6   $��5��69   $��1��6F   $��3��6V   $(��"Название критерия:��6j   $
��Left=�6�   $��14(�6�   $��Center=�6�   �� 5:   
   -   5        $��tb_Kriteria��5:   '   $��Verdana)�6   .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �����6  0MaterialDesignThemes.Wpf.BottomDashedLineAdorner   Brush
 �   ����#F1F1F1$��5��6�   $��3��6  $��4��6  $��30��6/   �� 	MaxLength$ 40��6;  $��
36,13,25,8q�6z  ��6�   �� *$"SelectedItem.Name_of_kind_criteria+ �� ElementName$ dg_Kind_criteria��6z  �� 5<   
   -   5        $��
lbl_Search��5<   %   $��Verdana)�6   $��8��67   $��1��6D   $��2��6T   $��Поиск:��6h   $
��Left=�6y   $��14(�6�   $��Center=�6�   �� 5>   
   -   5        $��	tb_Search��5>   �   
 �����
 �   ����#F1F1F1$��8��6�   $��3��6�   $��4��6�   $��30��6�   $��
36,8,25,14q�6�   �� 5?   
   -   5        $��	bt_Search��5?   �   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6   ���#607D8B���#607D8B$
��Auto��6c    � ToolTip$ 
Поиск��6q   $��Verdana)�6�   $��
Поиск��6�   $��7��6�   $��8��6�   $��2��6�   $��	0,10,0,10q�6  �� 5@   
   -	   5        $��	chbFilter��5@   �   $ 25��6   -  'MaterialDesignThemes.Wpf.CheckBoxAssist   CheckBoxSize$ 25Q�69   
����  �$��Center=�6s   $��16(�6�   $
��Auto��6�   $ Фильтрация��6�   $��Verdana)�6�   $��Фильтрация��6�   $��10��6�   $��8��6  $��2��6  $��0,0,0,14q�6F  �� 5B   
   -
   5        $��	bt_Insert��5B   �   $ 10��6   ���#607D8B���#607D8B$
��Auto��6c   $ Добавить��6q   $��Verdana)�6�   $��Добавить��6�   $��1��6�   $��9��6�   $��2��6�   $��	0,10,0,10q�6	  �� 5C   
   -   5        $��	bt_Update��5C   �   $ 10��6   ���#607D8B���#607D8B$��16(�6c   $
��Auto��6q   $ Изменить��6   $��Verdana)�6�   $��Изменить��6�   $��5��6�   $��9��6�   $��3��6�   $��	0,10,0,10q�6  �� 5D   
   -   5        $��	bt_Delete��5D   �   $ 10��6   ���#607D8B���#607D8B$��16(�6b   $
��Auto��6p   $ Удалить��6~   $��Verdana)�6�   $��Удалить��6�   $��10��6�   $��9��6�   $��2��6�   $��	0,10,0,10q�6  �� 5E   
   -   5        $��bt_MainWindow��5E   �   $ 10��6   ���#607D8B���#607D8B$��16(�6c   $
��Auto��6q   $ Главное меню��6   $��Verdana)�6�   $��Главное меню��6�   $��5��6�   $��10��6�   $��3��6�   $��0,10,0,5q�6'  5J      5K      