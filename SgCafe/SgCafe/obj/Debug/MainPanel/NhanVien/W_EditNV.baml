   M S B A M L   `   `   `  ����A  =SgCafe, Version=1.5.2.3, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SgCafe.MainPanel.NhanVienSgCafe.MainPanel.NhanVien  5   	   (    "SgCafe.MainPanel.NhanVien.W_EditNV   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:SgCafe.MainPanel.NhanVien     5   	      wd_ScWindows#��[  5        � Title$"  Sửa thông tin nhân viên��5   	   $	��400��6)   $	��600��66    � WindowStartupLocation$ CenterScreen=�6B   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $	��300 �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��55 �6   .+�5   
   �� $��0��6   $��-1,0,5,5q�6    �� CornerRadius$ 0,0,5,0��60     	clBack1WP#���  6G   ._�5      � .+�5      �� $
��Left=�6   $��	10,13,0,0q�67   $
��Wrap=�6J   $��Mã NV:��6^   $	��Top=�6l   �� 5      -   5         ��Name$
 maNV��5      $��23��6(   $��
70,10,10,0q�64    �� TextWrapping$
 Wrap=�6H   $	��Top=�6\    �� 
IsReadOnly . 6t   �� 5      $
��Left=�6   $��	10,53,0,0q�67   $
��Wrap=�6J   $��Tên NV:��6^   $	��Top=�6m   �� 5      -   5        $ tenNV��5      $��23��6)   $��
70,50,10,0q�65   $
 Wrap=�6I   $	��Top=�6]   6u   �� 5      $
��Left=�6   $��	10,93,0,0q�67   $
��Wrap=�6J   $��Giới tính:��6^   $	��Top=�6p   �� 5      -   5         ��Name$ gioitinh��5      $��
70,90,10,0q�6-   $	��Top=�6A   .@�5      �� $	��Nam��6#   �� 5      $
��Nữ��6#   5      �� 5      $
��Left=�6   $��
10,133,0,0q�67   $
��Wrap=�6K   $��Lương ca:��6_   $	��Top=�6p   �� 5      -   5        $ luong��5      $��23��6)   	 �� 	MaxLength$	 18��65   $��70,130,10,0q�6D   $
 Wrap=�6Y   $	��Top=�6m   $��0��6�   6�   �� 5      $
��Left=�6   $��
10,173,0,0q�67   $
��Wrap=�6K   $��Ngày vào làm:��6_   $	��Top=�6t   �� 5       -   5        $ ngayvl��5       $��23��6*   $��100,170,10,0q�66   $
 Wrap=�6L   $	��Top=�6`    . 6x   �� 5!      $
��Left=�6   $��
10,213,0,0q�67   $
��Wrap=�6K   $��	Ghi chú:��6_   $	��Top=�6o   �� 5"      -   5        
 ��Name$
 ghiChu��5"      $��70,210,10,10q�6.   5#      5$      �� 5%   
   $��1��6   $��5,0,-1,5q�6!   $ 0,0,0,5��63   #���  6J   ._�5&      � .+�5'      �� $
��Left=�6   $��	10,13,0,0q�67   $
��Wrap=�6J   $��Chúc vụ:��6^   $	��Top=�6n   �� 5(      -   5        $ chucVu��5(      $��
90,10,10,0q�6+   $	��Top=�6?    �� DisplayMemberPath$ TenCV��6�   ��6W   ��  �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5)      $
��Left=�6   $��	10,53,0,0q�67   $
��Wrap=�6J   $��Địa chỉ:��6^   $	��Top=�6n   �� 5*      -   5        $ diaChi��5*      $��23��6*   $��
90,50,10,0q�66   $
 Wrap=�6J   $	��Top=�6^   �� 5+      $
��Left=�6   $��	10,93,0,0q�67   $
��Wrap=�6J   $��Số điện thoại:��6^   $	��Top=�6t   �� 5,      -	   5        $	 sdt��5,      $��23��6'   $	 11��63   $��
90,90,10,0q�6B   $
 Wrap=�6V   $	��Top=�6j   6�   &   System.Windows.Controls.DataGrid  5-      -
   5          Name$ dataLich��5-      $��Disabled=�6-      CanUserReorderColumns .     CanUserResizeRows .     RowHeaderWidth$ 0Q�6�      AutoGenerateColumns .  $��10,130,10,10q�6�      CanUserAddRows .     CanUserDeleteRows .  ��6  �� $ PropertyChanged=�   Columns 5.      4  .System.Windows.Controls.DataGridTemplateColumn  5/      -   5        	tenca��,  &System.Windows.Controls.DataGridColumn   Header$ Ca làm��5/   @      Width5  /System.Windows.Controls.DataGridLengthConverter$	 112 6P      CellTemplate 50      �� 51   "   .R�52   &   �� $��2,0,0,0q�60   ��6A   �� *TenCa+53   #   55      4  .System.Windows.Controls.DataGridCheckBoxColumn  56      $ Cn��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *CN+  57      $ T2��61    6=   �� *T2+  58      $ T3��61    6=   �� *T3+  59      $ T4��61    6=   �� *T4+  5:      $ T5��61    6=   �� *T5+  5;      $ T6��61    6=   �� *T6+  5<      $ T7��61    6=   �� *T7+5>      5?      5@      �� 5A   
   $��50��6   $��Bottom=�6   $ 5��68   $��
-1,0,-1,-3q�6I   $��1��6]   $��2��6j     	clBack2WP#���  6~   ._�5B      � .+�5C      �� -   5         ��Name$
 BtOK��5C      $��Sửa��6'   $��0,13,120,13q�65   $��Right=�6J   $	��100��6f   6r   �� 5D      -   5        $ BtHuy��5D      $��Hủy��6(   $��
0,13,10,13q�66   $��Right=�6J   $	��100��6f   6r   5E      5F      5G      5H      