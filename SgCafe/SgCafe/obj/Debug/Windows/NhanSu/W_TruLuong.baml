   M S B A M L   `   `   `  ����A  =SgCafe, Version=1.5.2.3, Culture=neutral, PublicKeyToken=null=#clr-namespace:SgCafe.Windows.NhanSuSgCafe.Windows.NhanSu  5   	   &     SgCafe.Windows.NhanSu.W_TruLuong   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:SgCafe.Windows.NhanSu     5   	   -   5           wd_ScWindows#��[  5        � Title$  Trừ lương��5   	   $	��300��6   $	��300��6(    � WindowStartupLocation$ CenterScreen=�6K   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��55 �6   .+�5   
   � $��0��6   .+�5      �� $��	-1,0,-1,5q�6    �� CornerRadius$ 0,0,5,5��6(     	clBack1WP#���  6?   ._�5      � .+�5      �� $
��Left=�6    $��	10,19,0,0q�6;   $
��Wrap=�6N   $��Nhân viên��6b   $	��Top=�6s   �� 5      -   5         ��Name$ nhanVien��5       �� DisplayMemberPath$ TenNV��6I   $��
80,15,10,0q�6c   $	��Top=�6w   ��61   �� 6�   �� 5      $
��Left=�6    $��	10,53,0,0q�6;   $
��Wrap=�6N   $��Số tiền trừ��6b   $	��Top=�6u   �� 5      -   5         ��Name$ soTien��5      $��23��6.   $��
80,50,10,0q�6:    �� TextWrapping$
 Wrap=�6N   $
��0.00��6b   $	��Top=�6n   6�   �� 5      $
��Left=�6    $��	10,89,0,0q�6;   $
��Wrap=�6N   $��Lý do trừ��6b   $	��Top=�6s   �� 5      -   5         ��Name$
 lyDo��5   "   $��80,85,10,10q�60   5      5      5      �� 5   
   $��50��6   $��Bottom=�6   $ 5��68   $��
-1,0,-1,-3q�6I   $��1��6]     	clBack2WP#���  6j   ._�5      � .+�5      �� -   5        	 ��Name$
	 BtOK��5      $��Trừ��6'   {�.  $��0,13,120,13q�6G   $��Right=�6\   $	��100��6x   6�   �� 5      -   5        $	 BtHuy��5      $��Hủy��6(   $��
0,13,10,13q�66   $��Right=�6J   $	��100��6f   6r   5      5      5       5!      