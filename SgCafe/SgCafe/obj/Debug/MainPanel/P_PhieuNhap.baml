   M S B A M L   `   `   `  ����A  =SgCafe, Version=1.5.2.3, Culture=neutral, PublicKeyToken=null3clr-namespace:SgCafe.MainPanelSgCafe.MainPanel  5      "    SgCafe.MainPanel.P_PhieuNhap   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:SgCafe.MainPanel     5      -   5          N� Title$  P_PhieuNhap��5	       � 	Resources 5
      !   SgCafe.MainPanel.cvNhanVien   converNhanVien#   SgCafe.MainPanel.cvTrangThai2  convertTrangtT   SgCafe.MainPanel.cvNhaCC  convertNhaCC�� 5   
   %W   &	        &	      &	 &       5      6     5      6!     5      6   5      .��5      � $��5q�6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��32 �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� CornerRadius$ 5��6   $��0,0,0,0q�6/   ��5      �� 5       �� Color$ White��6"    �� Opacity$	 0.5Q�60   ._�5      �� $��	10,7,10,7q�6   $
��Wrap=�6+    �� TextAlignment$ Center=�6?   $%��Danh Sách Phiếu Nhập Hàng��6V   5      � 5   
   $��1��6   .+�5#      �� -   5         ��Name$
 them��5#      $��Thêm Mới��6#   $
��Left=�66   $��0,4,0,0q�6Q   $��75��6b   $��23��6m   $	��Top=�6y   6�   �� 5$      -   5        $	 sua��5$      {�.  $��Chỉnh Sửa��64   $
��Left=�6H   $��90,4,0,0q�6c   $��75��6u   $��23��6�   $	��Top=�6�   6�   �� 5%      -   5        $	 xoa��5%      {�.  $
��Xóa��64   $
��Left=�6B   $��	180,4,0,0q�6]   $��75��6p   $��23��6{   $	��Top=�6�   6�   �� 5&      -   5        $	 inP��5&      {�.  $��In Lại��64   $
��Left=�6E   $��	270,4,0,0q�6`   $��75��6s   $��23��6~   $	��Top=�6�   6�   5'      �� 5(   
   -   5         ��Name$
 dmPN��5(      $��0q�6!   $��2��6D   ��6,   �� 	 �� View	 5)      �� 5*      .P�5+      �� $��Số phiếu��6%   
 �� Width$	
 110��67    �� DisplayMemberBinding 6C   �� *	SoPhieu+ �� StringFormat$ 000000000000000���� 5,      $��Ngày��6%   $
 80��63    6>   �� *	NgayLap+$ 
dd/MM/yyyy���� 5-      $��Tổng tiền��6%   $	
 140��68    6D   �� *
TongTien+$
 0.00���� 5.      $��Nhân viên��6%   $	
 200��68    6D   �� *MaNV+ �� 	Converter# [  �� 5/      $��Nhà cung cấp��6%   $	
 250��6;    6G   �� *MaNCC+# [ �� 50      $��Trạng thái��6%   $	
 120��69    6E   �� *	TrangThai+# [ 51      53      54      55      