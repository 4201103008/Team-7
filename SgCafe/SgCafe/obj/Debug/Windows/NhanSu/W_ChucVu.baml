   M S B A M L   `   `   `  ����A  =SgCafe, Version=1.5.2.3, Culture=neutral, PublicKeyToken=null=#clr-namespace:SgCafe.Windows.NhanSuSgCafe.Windows.NhanSu  5   	   $    SgCafe.Windows.NhanSu.W_ChucVu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:SgCafe.Windows.NhanSu     5   	   -   5           wd_ScWindows#��[  5        � Title$  Danh sách chức vụ��5   	   $	��400��6#   $	��720��60    � WindowStartupLocation$ CenterScreen=�6S    � 	Resources 5	      $   SgCafe.Windows.NhanSu.qlNhanSu  QLNhanSu!   SgCafe.Windows.NhanSu.qlBan 	 QLBan"   SgCafe.Windows.NhanSu.qlCaCV  QLCa"   SgCafe.Windows.NhanSu.qlHang 
 QLHang"   SgCafe.Windows.NhanSu.qlNhap 
 QLNhap$   SgCafe.Windows.NhanSu.qlthuChi  QLThuChi"   SgCafe.Windows.NhanSu.qlXuat 
 QLXuat��%�   &	       &	      &	 &     &	 9     &	 L     &	 _     &	 r       5
   
   6     5   
   6     5   
   6     5   
   6     5   
   6     5   
   6     5   
   6   5      .��5      � .+�5   
   �� $��
-1,0,-1,-3q�6    �� CornerRadius$ 0,0,5,5��6%     	clBack1WP#���  6<   ._�5      � .+�5      �� -   5         ��Name$
 them��5      $��Thêm Mới��6+   $
��Left=�6>   $��10,8,0,0q�6Y   $	��Top=�6k   $��75��6�   6�   �� 5      -   5        $	 sua��5      {�.  $��Chỉnh Sửa��6<   $
��Left=�6P   $��	100,8,0,0q�6k   $��75��6~   $��23��6�   $	��Top=�6�   6�   �� 5      -   5        $	 xoa��5      {�.  $
��Xóa��6<   $
��Left=�6J   $��	190,8,0,0q�6e   $��75��6x   $��23��6�   $	��Top=�6�   6�   �� 5      -   5         ��Name$ listCV��5      $��10,40,10,10q�6k   ��6/   ��  �� UpdateSourceTrigger$ PropertyChanged=� �� View 5      �� 5      .P�5   "   �� $��Tên chức vụ��61    �� Width$	 200��6F   	 �� DisplayMemberBinding	 6R   �� *TenCV+�� 5   "   $��
Nhân sự��61   $ 70��6B   	 6M   �� *QL+
 �� 	Converter#
 [ �� 5   "   $��Ca, Chức vụ��61   $ 70��6F   	 6Q   �� *QL+#
 [ �� 5   "   $
��Bàn��61   $ 70��6>   	 6I   �� *QL+#
 [ �� 5   "   $��Hàng��61   $ 70��6?   	 6J   �� *QL+#
 [ �� 5    "   $��Thu Chi��61   $ 70��6B   	 6M   �� *QL+#
 [ �� 5!   "   $��
Bán hàng��61   $ 70��6C   	 6N   �� *QL+#
 [ �� 5"   "   $��Nhập��61   $ 70��6?   	 6J   �� *QL+#
 [ 5#      5%      5&      5'      5(      5)      