   M S B A M L   `   `   `  ����A  =SgCafe, Version=1.5.2.3, Culture=neutral, PublicKeyToken=null3clr-namespace:SgCafe.MainPanelSgCafe.MainPanel  5      "    SgCafe.MainPanel.P_TinhLuong   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:SgCafe.MainPanel     5      -   5          N� Title$  P_TinhLuong��5	      .��5
      � $��5q�6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��160 �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� CornerRadius$ 5��6   $��2��6/   $��30��6C   $	��Top=�6O   ��5      �� 5       �� Color$ White��6"    �� Opacity$	 0.5Q�60   ._�5      �� $��	10,7,10,7q�6   $
��Wrap=�6+    �� TextAlignment$ Center=�6?   $#��Tính Lương Cho Nhân Viên��6V   5      � 5   
   $��0��6   $��1��6    5      �� 5      $��20 �6    �� 5      $��* �6    �� 5      $��50 �6    .+�5      �� $
��10,0q�6   $
��Wrap=�6&   $ Center=�6:   $��Bảng Lương��6Q   $	��Top=�6c   �� 5       -   5         ��Name$ listBangLuong��5       $��Disabled=�6.   $��1��6d   $��0q�6�   ��6q   ��  �� View 5!      �� 5"      .P�5#      �� $��Tháng��6)   	 �� Width$	 60��68   
 �� DisplayMemberBinding
 6C   �� *Thang+�� 5$      $
��Năm��6)   $		 100��66   
 6B   �� *Nam+5%      5'      � 5(      $��2��6   .+�5)      �� $
��Left=�6   $��5,0,0,25q�67   $
��Wrap=�6I   $!��Tổng lương phải trả��6]   $��Bottom=�6x   �� 5*      -   5         ��Name$ 	tongluong��5*      $��0q�6-    �� TextWrapping$
 Wrap=�68   $��0��6L   $��24��6U   $��Bottom=�6a   5+      5,      �� 5-   
   -   5        $��listTL��5-      $��1��6!   $��1��61   $��10,0,0,0q�6>   ��6P   ��  5.      �� 5/      .P�50      �� $��Nhân viên��6%   $		 200��68   
 6D   �� *TenNV+�� 51      $��Đi làm��6%   $	 80��65   
 6@   �� *	SCDiLam+�� 52      $��Nghỉ��6%   $	 80��63   
 6>   �� *SCNghi+�� 53      $��Nghỉ không phép��6%   $		 120��6>   
 6J   �� *
SCKoPhep+�� 54      $��Tiền công��6%   $		 100��68   
 6D   �� *TienCongLam+ �� StringFormat$
 0.00���� 55      $#��Trừ lương & ứng lương��6%   $		 150��6H   
 6T   �� *	TienTru+$
 0.00���� 56      $��Tổng tiền��6%   $		 150��68   
 6D   �� *	TienLuong+$
 0.00��57      59      5:      5;      