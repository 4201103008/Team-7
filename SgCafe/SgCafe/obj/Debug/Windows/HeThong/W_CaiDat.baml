   M S B A M L   `   `   `  ����A  =SgCafe, Version=1.5.2.3, Culture=neutral, PublicKeyToken=null?$clr-namespace:SgCafe.Windows.HeThongSgCafe.Windows.HeThong  5   	   B >StyleCF, Version=1.5.2.3, Culture=neutral, PublicKeyToken=nullB.clr-namespace:StyleCF.Control;assembly=StyleCFStyleCF.Control 5   	   %    SgCafe.Windows.HeThong.W_CaiDat   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:SgCafe.Windows.HeThong     5   	   BControl.clr-namespace:StyleCF.Control;assembly=StyleCF     5   	   -   5           wd_ScWindows#��[  5        � Title$  Cài Đặt��5	   	   $	��470��6   $	��350��6&    � WindowStartupLocation$ CenterScreen=�6I   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��55 �6   .+�5   
   � $��0��6   .+�5      �� $��	-1,0,-1,5q�6    �� CornerRadius$ 0,0,5,5��6(     	clBack1WP#���  6?   ._�5      � $��5q�6   .+�5      �� $��Disabled=�6#   $��Hidden=�6L   .��5      �  5      �� 5   "   $
��Auto �60   �� 5   "   $��10 �60   .+�5      �� $
��Left=�6(   $��5,10,0,0q�6C   $
��Wrap=�6U   $��
Tên quán��6i   $	��Top=�6y   �� 5      -   5         ��Name$ tenquan��5   &    �� 	MaxLength$	 500��67   $��	60,7,10,0q�6G    �� TextWrapping$
 Wrap=�6Z   $	��Top=�6n   �� 5      $
��Left=�6(   $��5,40,0,0q�6C   $
��Wrap=�6U   $��Địa chỉ��6i   $	��Top=�6x   �� 5      -   5        $ diachi��5   &   $	 500��66   $��
60,37,10,0q�6F   $
 Wrap=�6Z   $	��Top=�6n   �� 5      $
��Left=�6(   $��5,70,0,0q�6C   $
��Wrap=�6U   $	��SDT��6i   $	��Top=�6t   �� 5      -   5        $	 sdt��5   &   $ 12��63   $��
60,67,10,0q�6B   $
 Wrap=�6V   $	��Top=�6j   6�   �� 5      $
��Left=�6(   $��	5,100,0,0q�6C   $
��Wrap=�6V   $��
Thuế VAT��6j   $	��Top=�6z   �� 5      -   5        $	 vat��5   &   $ 2��63   $��
60,97,30,0q�6A   $
 Wrap=�6U   $	��Top=�6i   6�   �� 5       $��
0,100,15,0q�6(   $
��Wrap=�6<   $��%��6P   $	��Top=�6Y   $��Right=�6q   �� 5!      $
��Left=�6(   $��	5,130,0,0q�6C   $
��Wrap=�6V   $��Giảm giá��6j   $	��Top=�6z   �� 5"      -   5        $ giamgia��5"   &   $ 2��67   $��60,127,30,0q�6F   $
 Wrap=�6[   $	��Top=�6o   6�   �� 5#      $��
0,130,15,0q�6(   $
��Wrap=�6<   $��%��6P   $	��Top=�6Y   $��Right=�6q   �� 5$      $
��Left=�6(   $��	5,180,0,0q�6C   $
��Wrap=�6V   $+��%Tự động xóa dữ liệu cũ sau��6j   $	��Top=�6�   d� 5%      -   5         d�Name$
 xdlc��5%   +     AnimatedSwitch#��[ 69   $��
0,177,10,0q�6a   $��22��6u   $	��Top=�6�   $��Right=�6�   $��58��6�   �� 5&      -   5        $ xoadlcs��5&   &   $ 2��67   $
��Left=�6E   $��24��6`   $��154,177,0,0q�6l   $
 Wrap=�6�   $	��Top=�6�   $��30��6�   {�6�   �� *	IsChecked+ �� ElementName$
 xdlc��6  �� 5'      $
��Left=�6(   $��190,180,0,0q�6C   $
��Wrap=�6X   $��tháng��6l   $	��Top=�6y   �� 5(      $
��Left=�6(   $��	5,210,0,0q�6C   $
��Wrap=�6V   $+��%Trừ lương khi nghỉ không phép��6j   $	��Top=�6�   �� 5)      -	   5        $ trutheo��5)   &   $��175,207,30,0q�67   $
 Wrap=�6M   $	��Top=�6a   6y   �� 5*      -
   5        	 ��Name$	 kh��5*   (   $��
0,210,15,0q�64   $
��Wrap=�6H   $��%��6\   $	��Top=�6e   $��Right=�6}   �� 5+      -   5        
 ��Name$
 groupBox��5+   '   $��
Trừ theo��69   $��60,230,10,0q�6K   $	��Top=�6`   $��80��6x   .��5,   "   � $��6,10,0,0q�6'   .+�5-   &   	� -   5         	�Name$ phantram��5-   2   $$��Phần trăm lương cơ bản��6D   $��0,0,0,0q�6e   $
��Left=�6v   $	��Top=�6�   6�   	� 5.   &   -   5        $ sotien��5.   2   $��Số tiền cụ thể��6B   $��0,20,0,0q�6[   $	��Top=�6m   $
��Left=�6�   6�   5/   #   50      �� 51      $
��Left=�6(   $��	5,330,0,0q�6C   $
��Wrap=�6V   $��Đơn vị tiền tệ��6j   $	��Top=�6�   �� 52      -   5        $ tiente��52   &   $ 4��66   $��90,327,10,0q�6D   $
 Wrap=�6Y   $	��Top=�6m   6�   �� 53      -   5         ��Name$ thongbao��53   '   $0��*Cho phép phần mềm hiện thông báo!��69   $��
5,360,10,0q�6f   $	��Top=�6z   54      55      56      57      58      �� 59   
   $��50��6   $��Bottom=�6   $ 5��68   $��
-1,0,-1,-3q�6I   $��1��6]     	clBack2WP#���  6j   ._�5:      � .+�5;      �� -   5         ��Name$
 BtOK��5;      $
��Lưu��6'   $��0,13,120,13q�65   $��Right=�6J   $	��100��6f   6r   �� 5<      -   5        $ BtHuy��5<      $��Hủy��6(   $��
0,13,10,13q�66   $��Right=�6J   $	��100��6f   6r   5=      5>      5?      5@      