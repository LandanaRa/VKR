   M S B A M L   `   `   `  ����C  ?Praktika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PraktikaPraktika  5   	       Praktika.Tabel   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Praktika     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2230, Culture=neutral, PublicKeyToken=df2a72020bd7962af bMaterialDesignThemes.MahApps, Version=0.1.6.2230, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   -   5          � Title$  Табель��5	   	   $	��600��6   $��Verdana)�6%   ���#8FA3AD$	��800��6O    � WindowStartupLocation$ CenterScreen=�6[   .��5
      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5       6!   �� 5!      6!   �� 5"      6!   �� 5#      6!   �� 5$      6!   �� 5%      6!   �� 5&      6!   .+�5*   
   �� -   5        $��lbl_Prikaz_ob_Ovolen��5*      $��0��6-   $��1��6:   $��11��6J   $��Табель��6_   $��Center=�6p   $��24(�6�   $��Center=�6�   &   System.Windows.Controls.DataGrid  5+   
   -   5        $��dg_Tabel��5+         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6#      AutoGenerateColumns .    
IsReadOnly . $��1��6c   $��1��6s   $��11��6�   $��8��6�      ColumnHeaderStyle 5,      �� 5-       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5.      �� 	 �� Property	 � ��
 �� Value$

 Bold"�64   �� 5/      	 � ��$
 Center=�6<   �� 50      	 � ��$
 Center=�6C   �� 51      	 � ��

 �����64   �� 52      	 � ��

 �����63   �� 53      	 � ��$
 10, 10, 0, 10q�6/   54      56      �� 58   
   -   5        $��bt_MainWindow��58   �   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6   ���#607D8B���#607D8B$��16(�6j    � ToolTip$ Главное меню��6y   $��Главное меню��6�   $��5��6�   $��10��6�   $��3��6�   $��30��6�   $��10,10,24, 0q�6�   6  5:      5;      