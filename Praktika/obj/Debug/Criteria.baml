   M S B A M L   `   `   `  ����C  ?Praktika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PraktikaPraktika  5   	       Praktika.Criteria   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Praktika     5   	   X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2230, Culture=neutral, PublicKeyToken=df2a72020bd7962af bMaterialDesignThemes.MahApps, Version=0.1.6.2230, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   -   5          � Title$  Под критерии��5
   	   $	��600��6   $	��800��6+   $��16(�67   $��Verdana)�6E   ���#8FA3AD � WindowStartupLocation$ CenterScreen=�6o   .��5      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5       6!   �� 5!      6!   �� 5"      6!   �� 5#      6!   �� 5$      6!   �� 5%      6!   �� 5&      6!   �� 5'      6!   .+�5+   
   �� -   5        $��lbl_kind_criteria_ID��5+      $��1��6-   $��1��6:   $��3��6J   $&�� Главный критерий:��6^   $
��Left=�6z   $��16(�6�   $��Center=�6�   $��	0,14,0,12q�6�   �� 5,   
   -   5        $��cb_kind_criteria_ID��5,      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 ����� �� 
IsReadOnly . $��4��6w   $��1��6�   $��3��6�   $��30��6�   $��	0,12,0,10q�6�   6  �� 5.   
   -   5        $��lbl_Prikaz_ob_Ovolen��5.      $��0��6-   $��1��6:   $��11��6J   $��Под критерии��6_   $��Center=�6v   $��24(�6�   $��Center=�6�   &   System.Windows.Controls.DataGrid  5/   
   -   5          Name$ dg_Criteria��5/         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6)      AutoGenerateColumns . 	   
IsReadOnly	 . $��1��6j   $��2��6z   $��11��6�   $��4��6�   
   ColumnHeaderStyle
 50      �� 51       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�52      ��  �� Property � �� �� Value$
 Bold"�64   �� 53       � ��$ Center=�6<   �� 54       � ��$ Center=�6C   �� 55       � ��
 �����64   �� 56       � ��
 �����63   �� 57       � ��$ 10, 10, 0, 10q�6/   58      5:      �� 5<   
   -   5        $��lbl_Name_criteria��5<      $��6��6+   $��1��68   $��3��6H   $(��"Название критерия:��6\   $
��Left=�6y   $��16(�6�   $��Center=�6�   �� 5=   
   -   5        $��tb_Name_criteria��5=      
 �����6  0MaterialDesignThemes.Wpf.BottomDashedLineAdorner   Brush
 �   ����#F1F1F1$��6��6�   $��4��6�   $��3��6  $��30��6"  ��6�   �� *SelectedItem.Name_criteria+ �� ElementName$ dg_Criteria��6.  �� 5?   
   -   5        $��lbl_Name_range��5?      $��7��6'   $��1��64   $��3��6D   $��Ранжирование:��6X   $
��Left=�6p   $��16(�6�   $��Center=�6�   %  Xceed.Wpf.Toolkit.IntegerUpDown  5@   
   -	   5        $��
tb_ranging��5@   e   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$ N0��6   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 0X�6/      Minimum$ 0X�69      	Increment$ 1X�6E      Maximum$ 200000X�6S   
�������$��7��6�   $��4��6�   $��3��6�   $��30��6�   ,	  &Xceed.Wpf.Toolkit.Primitives.InputBase 	  Text 6�   �� *SelectedItem.ranging+$ dg_Criteria��6�   �� 5G   
   -
   5        $��
lbl_Search��5G      $��8��6#   $��1��60   $��2��6@   $��Поиск:��6T   $
��Left=�6e   $��16(�6�   $��Center=�6�   �� 5H   
   -   5        $��	tb_Search��5H      
 �����
 �   ����#F1F1F1$��8��6�   $��3��6�   $��3��6�   $��30��6�   $��0,9,0,13q�6�   �� 5J   
   -   5        $��	bt_Search��5J   |    � ToolTip$ 
Поиск��6   +
  %MaterialDesignThemes.Wpf.ButtonAssist 
  CornerRadius$ 10��6"   ���#607D8B���#607D8B$��
Поиск��6�   $��7��6�   $��8��6�   $��2��6�   $��30��6�   $��0,12,0,0q�6�   �� 5K   
   -   5        $��	chbFilter��5K   �   $ 25��6   -  'MaterialDesignThemes.Wpf.CheckBoxAssist   CheckBoxSize$ 25Q�6A   
����  �$��Center=�6�   $��14(�6�   ���	#FF000000$
��Auto��6�   $ Фильтрация��6�   $��Verdana)�6�   $��Фильтрация��6  $��10��6$  $��8��65  $��2��6B  $��0,0,0,14q�6n  6�  �� 5M   
   -   5        $��	bt_Insert��5M      $ Добавить��6   $ 10��6%   ���#607D8B���#607D8B$��Добавить��6�   $��1��6�   $��9��6�   $��2��6�   $��30��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   �� 5N   
   -   5        $��	bt_Update��5N      $ Изменить��6   $ 10��6%   ���#607D8B���#607D8B$��Изменить��6�   $��5��6�   $��9��6�   $��3��6�   $��30��6�   6�   �� 5O   
   -   5        $��	bt_Delete��5O   ~   $ Удалить��6   $ 10��6$   ���#607D8B���#607D8B$��Удалить��6�   $��10��6�   $��9��6�   $��2��6�   $��30��6�   6�   �� 5P   
   -   5        $��bt_MainWindow��5P   �   $ Главное меню��6   $ 10��6*   ���#607D8B���#607D8B$��Главное меню��6�   $��5��6�   $��10��6�   $��3��6�   $��30��6�   6�   5R      5S      