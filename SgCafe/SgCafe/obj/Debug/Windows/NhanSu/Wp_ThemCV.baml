   M S B A M L   `   `   `  ����A  =SgCafe, Version=1.5.2.3, Culture=neutral, PublicKeyToken=null=#clr-namespace:SgCafe.Windows.NhanSuSgCafe.Windows.NhanSu  5   	   %    SgCafe.Windows.NhanSu.Wp_ThemCV   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:SgCafe.Windows.NhanSu     5   	      wd_ScWindows#��[  5        � Title$  Thêm chức vụ��5   	   $	��350��6   $	��300��6+    � WindowStartupLocation$ CenterScreen=�67   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��55 �6   .+�5   
   � $��0��6   .+�5      �� $��	-1,0,-1,5q�6    �� CornerRadius$ 0,0,5,5��6(     	clBack1WP#���  6?   ._�5      � .+�5      �� $
��Left=�6    $��	10,13,0,0q�6;   $
��Wrap=�6N   $��Tên chức vụ:��6b   $	��Top=�6v   �� 5      -   5         ��Name$	 ten��5      $��23��6+   $��
90,10,10,0q�67    �� TextWrapping$
 Wrap=�6K   $	��Top=�6_   6w   �� 5      $
��Left=�6    $��	10,53,0,0q�6;   $
��Wrap=�6N   $2��,Các quyền quản trị của chức vụ:��6b   $	��Top=�6�   �� 5      -   5         ��Name$ qlnhansu��5       d� 	IsChecked$ FalseY�61   $#��Quyền quản lý nhân sự��6C   $
��Left=�6c   $��	30,80,0,0q�6~   $	��Top=�6�   �� 5      -   5        $ 	qlcalamcv��5      $ FalseY�62   $0��*Quyền quản lý ca làm và chức vụ��6D   $
��Left=�6n   $��
30,105,0,0q�6�   $	��Top=�6�   �� 5      -   5        $ qlban��5      $ FalseY�6.   $��Quyền quản lý bàn��6@   $
��Left=�6\   $��
30,130,0,0q�6w   $	��Top=�6�   �� 5      -   5        $ qlmathangncc��5      $ FalseY�65   $8��2Quyền quản lý mặt hàng và nhà cung cấp��6G   $
��Left=�6x   $��
30,155,0,0q�6�   $	��Top=�6�   �� 5      -   5        $ qlthuchi��5      $ FalseY�61   $0��*Quyền quản lý phiêu thu, phiếu chi��6C   $
��Left=�6p   $��
30,180,0,0q�6�   $	��Top=�6�   �� 5      -   5        $ 	qlbanhang��5      $ FalseY�62   $#��Quyền quản lý bán hàng��6D   $
��Left=�6e   $��
30,205,0,0q�6�   $	��Top=�6�   �� 5      -   5        $ 
qlnhaphang��5      $ FalseY�63   $%��Quyền quản lý nhập hàng��6E   $
��Left=�6g   $��
30,230,0,0q�6�   $	��Top=�6�   5      5      5      �� 5   
   $��50��6   $��Bottom=�6   $ 5��68   $��
-1,0,-1,-3q�6I   $��1��6]     	clBack2WP#���  6j   ._�5      � .+�5       �� -	   5         ��Name$
 BtOK��5       $��Thêm��6'   {�.  $��0,13,120,13q�6H   $��Right=�6]   $	��100��6y   6�   �� 5!      -
   5        $ BtHuy��5!      $��Hủy��6(   $��
0,13,10,13q�66   $��Right=�6J   $	��100��6f   6r   5"      5#      5$      5%      