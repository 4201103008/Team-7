   M S B A M L   `   `   `  ����A  =SgCafe, Version=1.5.2.3, Culture=neutral, PublicKeyToken=null3clr-namespace:SgCafe.MainPanelSgCafe.MainPanel  5      !    SgCafe.MainPanel.P_TaiKhoan   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:SgCafe.MainPanel     5      -   5          N� Title$  
P_TaiKhoan��5	       � 	Resources 5
      !   SgCafe.MainPanel.cvNhanVien   ConverNhanVien�� 5   
   %   &	          5      6   5      .��5      � $��5q�6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��32 �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� CornerRadius$ 5��6   $��0,0,0,0q�6/   ��5      �� 5       �� Color$ White��6"    �� Opacity$	 0.5Q�60   ._�5      �� $��	10,7,10,7q�6   $
��Wrap=�6+    �� TextAlignment$ Center=�6?   $��Danh Sách Tài Khoản��6V   5      � 5   
   $��1��6   .+�5      �� -   5         ��Name$
 them��5      $��Thêm Mới��6#   $
��Left=�66   $��0,0,0,5q�6Q   $��75��6b   $��23��6m   $��Bottom=�6y   6�   �� 5      -   5        $	 sua��5      $��Chỉnh Sửa��6"   {�.  $
��Left=�6H   $��90,4,0,0q�6c   $��75��6u   $��23��6�   $	��Top=�6�   6�   �� 5      -   5        $	 xoa��5      $
��Xóa��6"   {�.  $
��Left=�6B   $��	180,4,0,0q�6]   $��75��6p   $��23��6{   $	��Top=�6�   6�   5      �� 5    
   -   5         ��Name$
 dmTK��5       $��0q�6!   $��2��6,   ��69   �� 	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� View
 5!      �� 5"      .P�5#      �� $��Tên tài khoản��6%    �� Width$	 200��6c    �� DisplayMemberBinding 6<   �� *TenTK+6c   �� 5$      $��Mật khẩu��6%   $	 200��6`    67   �� *	MatKhau+6`   �� 5%      $��Nhân Viên��6%   $	 300��68    6D   �� *TenNV+�� 5&      $��Chức Vụ��6%   $	 200��66    6B   �� *TenCV+5'      5)      5*      5+      