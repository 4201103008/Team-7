   M S B A M L   `   `   `  ����A  =SgCafe, Version=1.5.2.3, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SgCafe.MainPanel.NhanVienSgCafe.MainPanel.NhanVien  5   	   '    !SgCafe.MainPanel.NhanVien.W_DoiCV   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:SgCafe.MainPanel.NhanVien     5   	      wd_ScWindows#��[  5        � Title$  Thay đổi chức vụ��5   	   $	��220��6"   $	��250��6/    � WindowStartupLocation$ CenterScreen=�6;   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��55 �6   .+�5   
   � $��0��6   .+�5      �� $��	-1,0,-1,5q�6    �� CornerRadius$ 0,0,5,5��6(     	clBack1WP#���  6?   ._�5      � .+�5      �� $
��Left=�6    $��	10,13,0,0q�6;   $
��Wrap=�6N   $��Mã NV:��6b   $	��Top=�6p   �� 5      -   5         ��Name$
 maNV��5      $��23��6,   $��
60,10,10,0q�68    �� TextWrapping$
 Wrap=�6L   $	��Top=�6`    �� 
IsReadOnly . 6x   �� 5      $
��Left=�6    $��	10,53,0,0q�6;   $
��Wrap=�6N   $��Tên NV:��6b   $	��Top=�6q   �� 5      -   5        $ tenNv��5      $��23��6-   $��
60,50,10,0q�69   $
 Wrap=�6M   $	��Top=�6a    . 6y   �� 5      $
��Left=�6    $��	10,93,0,0q�6;   $
��Wrap=�6N   $��Chúc vụ:��6b   $	��Top=�6r   �� 5      -   5         ��Name$ chucVu��5       �� DisplayMemberPath$ TenCV��6k   $��
60,90,10,0q�6�   $	��Top=�6�   ��6/   �� 	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   5      5      5      �� 5   
   $��50��6   $��Bottom=�6   $ 5��68   $��
-1,0,-1,-3q�6I   $��1��6]     	clBack2WP#���  6j   ._�5      � .+�5      �� -   5        
 ��Name$

 BtOK��5      $��Đổi��6'   $��0,13,120,13q�65   $��Right=�6J   $	��100��6f   6r   �� 5      -   5        $
 BtHuy��5      $��Hủy��6(   $��
0,13,10,13q�66   $��Right=�6J   $	��100��6f   6r   5      5      5       5!      