   M S B A M L   `   `   `  ����A  =SgCafe, Version=1.5.2.3, Culture=neutral, PublicKeyToken=null3clr-namespace:SgCafe.MainPanelSgCafe.MainPanel  5      !    SgCafe.MainPanel.P_NhanVien   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:SgCafe.MainPanel     5        N� Title$  
P_NhanVien��5	       � 	Resources 5
      "   SgCafe.MainPanel.cvTenChucVu   ConvertTenCV!   SgCafe.MainPanel.cvGioiTinh  ConvertGioiTinh�� 5   
   %:   &	        &	        5      6      5      6   5      .��5      � $��5q�6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��32 �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� CornerRadius$ 5��6   $��0,0,0,0q�6/   ��5      �� 5       �� Color$ White��6"    �� Opacity$	 0.5Q�60   ._�5      �� $��	10,7,10,7q�6   $
��Wrap=�6+    �� TextAlignment$ Center=�6?   $��Danh Sách Nhân Viên��6V   5      � 5   
   $��1��6   .+�5      �� -   5         ��Name$
 them��5      $��Thêm Mới��6#   $
��Left=�66   $��0,4,0,0q�6Q   $��75��6b   $��23��6m   $	��Top=�6y   6�   �� 5      -   5        $	 sua��5      {�.  $��Chỉnh Sửa��64   $
��Left=�6H   $��90,4,0,0q�6c   $��75��6u   $��23��6�   $	��Top=�6�   6�   �� 5      -   5        $	 xoa��5      {�.  $
��Xóa��64   $
��Left=�6B   $��	180,4,0,0q�6]   $��75��6p   $��23��6{   $	��Top=�6�   6�   �� 5       -   5        $ saplich��5       {�.  $��Sắp Lịch��68   $��Right=�6K   $��	0,4,115,0q�6g   $	��100��6z   $��23��6�   $	��Top=�6�   6�   �� 5!      -   5        $ doicv��5!      {�.  $��Đổi Chức Vụ��66   $��Right=�6L   $��0,4,0,0q�6h   $	��100��6y   $��23��6�   $	��Top=�6�   6�   5"      �� 5#   
   -   5         ��Name$ listNV��5#      $��2��6_   ��6#   �� 	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� View
 5$      �� 5%      .P�5&      �� $��Tên nhân viên��6%    �� Width$	 200��6<    �� DisplayMemberBinding 6H   �� *TenNV+�� 5'      $��Chức vụ��6%   $ 80��66    6A   �� *MaCV+ �� 	Converter# [  �� 5(      $��
Lương ca��6%   $	 100��67    6C   �� *
MucLuong+�� 5)      $	��SDT��6%   $ 90��62    6=   �� *SDT+�� 5*      $��Địa chỉ��6%   $	 200��66    6B   �� *DiaChi+�� 5+      $��Giới tính��6%   $ 50��68    6C   �� *
GioiTinh+# [ �� 5,      $��Ngày vào làm��6%   $	 140��6;    6G   �� *	NgayLam+�� 5-      $��Ghi chú��6%   $	 300��66    6B   �� *GhiChu+5.      50      51      52      