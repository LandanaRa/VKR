   M S B A M L   `   `   `  ����C  ?Praktika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PraktikaPraktika  5   	       Praktika.Sopostavl   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Praktika     5   	   X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2230, Culture=neutral, PublicKeyToken=df2a72020bd7962af bMaterialDesignThemes.MahApps, Version=0.1.6.2230, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   -   5          � Title$   Сопоставление��5
   	   $	��663��6   $	��711��6,   $��Verdana)�68   ���#8FA3AD � WindowStartupLocation$ CenterScreen=�6b   .��5      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5       6!   �� 5!      6!   �� 5"      6!   �� 5#      6!   �� 5$      6!   �� 5%      6!   �� 5&      6!   .+�5+   
   �� -   5        $��lbl_Zag��5+   %   $��Verdana)�6   $��0��64   $��1��6A   $��11��6Q   $O��IСопоставление лабораторий с критериями��6f   $��Center=�6�   $��24(�6�   $��Center=�6�   �� 5-   
   -   5        $��lbl_ID_Training_Area��5-   "   {�. $��1��6>   $��1��6K   $��3��6[   $��Территория:��6o   $
��Left=�6�   $��14(�6�   $��Center=�6�   $��	0,14,0,12q�6�   �� 5.   
   -   5        $��cb_ID_Training_Area��5.      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 ����� �� 
IsReadOnly . {�. $��3��6�   $��1��6�   $��3��6�   $��30��6�   $��	0,12,0,10q�6�   6  &   System.Windows.Controls.DataGrid  50   
   -   5        $��dg_Sopostavl��50         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6'      AutoGenerateColumns .    
IsReadOnly . $��1��6g   $��3��6w   $��11��6�   $��4��6�   	   ColumnHeaderStyle	 51      �� 52      
 �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"
  6   .�53      ��  �� Property � �� �� Value$
 Bold"�64   �� 54       � ��$ Center=�6<   �� 55       � ��$ Center=�6C   �� 56       � ��
 �����64   �� 57       � ��
 �����63   �� 58       � ��$ 10, 10, 0, 10q�6/   59      5;      �� 5=   
   -   5        $!��lbl_ID_Territory_Аudiences��5=   #   {�.  $��1��6E   $��7��6R   $��3��6b   $��Аудитория:��6v   $
��Left=�6�   $��14(�6�   $��Center=�6�   $��	0,14,0,12q�6�   �� 5>   
   -   5        $ ��cb_ID_Territory_Аudiences��5>      
 ����� . {�.  $��9��6�   $��1��6�   $��3��6�   $��30��6�   $��	0,12,0,10q�6�   6  �� 5@   
   -   5        $��lbl_ID_Material_Provision��5@   #   {�.  $��2��6D   $��3��6Q   $��3��6a   $��МО:��6u   $
��Left=�6�   $��14(�6�   $��Center=�6�   $��	0,14,0,12q�6�   �� 5A   
   -	   5        $��cb_ID_Material_Provision��5A      
 ����� . {�.  $��4��6�   $��2��6�   $��5��6�   $��30��6�   $��	0,12,0,10q�6�   6  �� 5C   
   -
   5        $��lbl_ID_Criteria��5C   #   {�.  $��7��6:   $��0��6G   $��3��6W   $��Подкритерий:��6k   $
��Left=�6�   $��14(�6�   $��Center=�6�   $��
10,14,0,12q�6�   �� 5D   
   -   5        $��cb_ID_Criteria��5D      
 ����� . {�.  $��2��6�   $��7��6�   $��3��6�   $��30��6�   $��
20,12,0,10q�6�    �� SelectedValue 6  �� *SelectedItem.criteria_ID+ �� ElementName$ dg_Sopostavl��5E   7   �� 5G   
   -   5        $��
lbl_ocenka��5G   #   {�.  $��7��65   $��6��6B   $��3��6R   $��Оценка:��6f   $
��Left=�6x   $��14(�6�   $��Center=�6�   $��	0,14,0,12q�6�   %  Xceed.Wpf.Toolkit.IntegerUpDown  5H   
   -   5        $��	cb_ocenka��5H   w   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$ N0��6   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 0X�6/      	Increment$ 1X�69   {�.     Minimum$ 0X�6Y      Maximum$ 200000X�6e   
�������$��9��6�   $��7��6�   $��3��6�   $��30��6  ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   Text 6�   �� *SelectedItem.ocenka+$ dg_Sopostavl��6  �� 5J   
   -   5        $��bt_Sopostav��5J   �    � ToolTip$ Сопоставить��6   +	  %MaterialDesignThemes.Wpf.ButtonAssist 	  CornerRadius$ 10��6'   ���#607D8B���#607D8B$��Сопоставить��6�   $��1��6�   $��8��6�   $��3��6�   $��30��6�   6�   �� 5K   
   -   5        $��	bt_Update��5K   �   $ Сопоставить��6   $ 10��6'   ���#607D8B���#607D8B$��Изменить��6�   $��5��6�   $��8��6�   $��3��6�   $��30��6�   6�   �� 5L   
   -   5        $��	bt_Delete��5L   �   $ Сопоставить��6   $ 10��6'   ���#607D8B���#607D8B$��Удалить��6�   $��9��6�   $��8��6�   $��3��6�   $��30��6�   6�   �� 5O   
   -   5        $��	tb_Search��5O   �   
 �����6
  0MaterialDesignThemes.Wpf.BottomDashedLineAdorner 
  Brush
 �   ����#F1F1F1$��9��6�   $��0��6�   $��3��6�   $��30��6�   $��
10,9,20,13q�6�   �� 5P   
   -   5        $��	bt_Search��5P   "   $ 
Поиск��6   $��
Поиск��63   $ 10��6D   ���#607D8B���#607D8B$��3��6�   $��9��6�   $��2��6�   $��30��6�   $��	0,12,0,10q�6�   �� 5Q   
   -   5        $��	chbFilter��5Q   �   $ 25��6   -  'MaterialDesignThemes.Wpf.CheckBoxAssist   CheckBoxSize$ 25Q�6A   
����  �$��12(�6�   $
��Auto��6�   $ Фильтрация��6�   $��Verdana)�6�   $��Фильтрация��6�   $��6��6�   $��9��6   $��2��6  $��0,0,0,14q�69  �� 5S   
   -   5        $��bt_MainWindow��5S   �   $ Главное меню��6   $ 10��6(   ���#607D8B���#607D8B$��Главное меню��6�   $��9��6�   $��10��6�   $��3��6�   $��30��6�   6�   5T      5U      