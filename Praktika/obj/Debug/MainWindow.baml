   M S B A M L   `   `   `  ����C  ?Praktika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PraktikaPraktika  5   	       Praktika.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Praktika     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2230, Culture=neutral, PublicKeyToken=df2a72020bd7962af bMaterialDesignThemes.MahApps, Version=0.1.6.2230, Culture=neutral, PublicKeyToken=df2a72020bd7962a@design1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   -   5          � Title$  Главное меню��5	   	   $	��600��6   $	��800��6+   $��Verdana)�67   ���#8FA3AD � WindowStartupLocation$ CenterScreen=�6a   .��5
      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� -   5        $��lbl_MainWindow��5      $��0��6&   $��2��63   $��2��6C   $��Главное меню��6W   $��Center=�6n   $��24(�6�   $��Center=�6�   $��Verdana)�6�   �� 5#   
   -   5        $��bt_Kind_criteria��5#   �   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6   ���#607D8B���#607D8B$��16(�6d   $
��Auto��6r    � ToolTip$7 1Переход в главные критерии��6�   $%��Главные критерии��6�   $��2��6�   $��1��6�   $��2��6�   $��Verdana)�6
  $	��230��6  $��
10,25,0,29q�6J  �� 5$   
   -   5        $��bt_Criteria��5$   �   $ 10��6   ���#607D8B���#607D8B$��16(�6b   $
��Auto��6p   $/ )Переход в под критерии��6~   $��Под критерии��6�   $��2��6�   $��2��6�   $��2��6�   $��Verdana)�6�   $	��230��6  $��
10,10,0,44q�67  �� 5%   
   -   5        $��bt_Sopostavlenie��5%   �   $ 10��6   ���#607D8B���#607D8B$��16(�6b   $
��Auto��6p   $a [Переход в сопоставление лабораторий с критериями��6~   $ ��Сопоставление��6�   $��2��6�   $��3��6�   $��2��6  $��Verdana)�6  $	��230��61  $��
10,10,0,44q�6=  6Q  �� 5&   
   -   5        $��bt_Tabel��5&   �   $ 10��6   ���#607D8B���#607D8B$��16(�6b   $
��Auto��6p   $$ Переход в табель��6~   $��Табель��6�   $��2��6�   $��4��6�   $��2��6�   $��Verdana)�6�   $	��230��6  $��
10,10,0,44q�6  6"  �� 5'   
   -   5        $��bt_Exit��5'   �   $ 10��6   ���#607D8B���#607D8B$��16(�6c   $
��Auto��6q   $ 
Выход��6   $��
Выход��6�   $��2��6�   $��5��6�   $��2��6�   $��Verdana)�6�   $	��230��6�   $��
10,20,0,30q�6  5*      5+      