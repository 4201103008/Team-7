   M S B A M L   `   `   `  ����A  =SgCafe, Version=1.5.2.3, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SgCafe.MainPanel.TaikhoanSgCafe.MainPanel.Taikhoan  5   	   -    'SgCafe.MainPanel.Taikhoan.W_AddTaiKhoan   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:SgCafe.MainPanel.Taikhoan     5   	   -   5           wd_ScWindows#��[  5        � Title$  Tạo tài khoản��5   	   $	��300��6   $	��500��6,    � WindowStartupLocation$ CenterScreen=�6O   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $	��250 �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��55 �6   .+�5   
   �� $��0��6   $��2��6    �� CornerRadius$ 0,0,5,5��62   $��
-1,0,-1,10q�6I     	clBack1WP#���  6]   ._�5      �� $��	10,7,10,7q�6   $
��Wrap=�6+    �� TextAlignment$ Center=�6?   $7��1Thông tin chi tiết người dùng, nhân viên��6V   5      �� 5   
   $��1��6   $��-1,0,5,5q�6   $ 0,5,5,0��60   #���  6G   ._�5      � .+�5      �� $
��Left=�6   $��	10,13,0,0q�67   $
��Wrap=�6J   $��Nhân viên:��6^   $	��Top=�6p   �� 5      -   5         ��Name$ nhanvien��5      $��
80,10,10,0q�6-   $	��Top=�6A    �� DisplayMemberPath$ TenNV��6q   ��6Y   �� 6�   �� 5      $
��Left=�6   $��	10,53,0,0q�67   $
��Wrap=�6J   $)��#Thông tin chi tiết tài khoản:��6^   $	��Top=�6�   �� 5      $
��Left=�6   $��	10,83,0,0q�67   $
��Wrap=�6J   $��Tài khoản:��6^   $	��Top=�6p   �� 5      -   5         ��Name$ taikhoan��5      	 �� 	MaxLength$	 50��6,   $��23��6;   $��
70,80,10,0q�6G   
 �� TextWrapping$

 Wrap=�6[   $	��Top=�6o   {�.  6�   �� 5      $
��Left=�6   $��
10,123,0,0q�67   $
��Wrap=�6K   $��Mật khẩu:��6_   $	��Top=�6p   �� 5      -   5        $ matkhau��5      $	 50��6+   $��23��6:   $��70,120,10,0q�6F   $

 Wrap=�6[   $	��Top=�6o   {�.  6�   5      5       �� 5!   
   $��1��6   $��5,0,-1,5q�6!   $ 5,0,0,5��63   $��1��6J   #���  6W   ._�5"      � .+�5#      �� $
��Left=�6   $��	10,13,0,0q�67   $
��Wrap=�6J   $��Mã NV:��6^   $	��Top=�6l   �� 5$      -   5        $
 maNV��5$      $��23��6(   $��
60,10,10,0q�64   $

 Wrap=�6H   $	��Top=�6\    �� 
IsReadOnly . ��6�   ��  �� Path$ SelectedItem.MaNV� �� ElementName$ nhanvien���� 5%      $
��Left=�6   $��	10,53,0,0q�67   $
��Wrap=�6J   $��Tên NV:��6^   $	��Top=�6m   �� 5&      -   5        $ tenNV��5&      $��23��6)   $��
60,50,10,0q�65   $

 Wrap=�6I   $	��Top=�6]    . ��6�   �� $ SelectedItem.TenNV�$ nhanvien���� 5'      $
��Left=�6   $��	10,93,0,0q�67   $
��Wrap=�6J   $��Chức vụ:��6^   $	��Top=�6n   �� 5(      -   5        $ chucVu��5(      $��23��6*   $��
60,90,10,0q�66   $

 Wrap=�6J   $	��Top=�6^    . ��6�   �� $ SelectedItem.TenCV�$ nhanvien��5)      5*      �� 5+   
   $��50��6   $��Bottom=�6   $ 5��68   $��
-1,0,-1,-3q�6I   $��2��6]   $��2��6j     	clBack2WP#���  6~   ._�5,      � .+�5-      �� -   5         ��Name$
 BtOK��5-      $��Tạo Tài Khoản��6'   $��0,13,120,13q�6?   $��Right=�6T   $	��100��6p   {�.  6�   �� 5.      -	   5        $ BtHuy��5.      $��Hủy��6(   $��
0,13,10,13q�66   $��Right=�6J   $	��100��6f   6r   5/      50      51      52      