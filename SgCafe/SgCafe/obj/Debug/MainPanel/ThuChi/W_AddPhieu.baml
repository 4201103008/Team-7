   M S B A M L   `   `   `  ����A  =SgCafe, Version=1.5.2.3, Culture=neutral, PublicKeyToken=nullA%clr-namespace:SgCafe.MainPanel.ThuChiSgCafe.MainPanel.ThuChi  5   	   (    "SgCafe.MainPanel.ThuChi.W_AddPhieu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:SgCafe.MainPanel.ThuChi     5   	      wd_ScWindows#��[  5        � Title$  Tạo phiếu thu��5   	   $	��450��6   $	��350��6,    � WindowStartupLocation$ CenterScreen=�68   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��55 �6   .+�5   
   � $��0��6   .+�5      �� $��	-1,0,-1,5q�6    �� CornerRadius$ 0,0,5,5��6(     	clBack1WP#���  6?   ._�5      � .+�5      �� -   5        $��ld��5       $
��Left=�6*   $��	10,13,0,0q�6E   $
��Wrap=�6X   $��Lý do thu:��6l   $	��Top=�6~   �� 5      -   5         ��Name$
 lyDo��5      $��23��6,   $��
80,10,10,0q�68    �� TextWrapping$
 Wrap=�6L   $	��Top=�6`   6x   �� 5      -   5        $��ng��5       $
��Left=�6*   $��	10,53,0,0q�6E   $
��Wrap=�6X   $��Người nộp:��6l   $	��Top=�6~   �� 5      -   5        $ 	nguoinhan��5      $��23��61   $��
80,50,10,0q�6=   $
 Wrap=�6Q   $	��Top=�6e   �� 5      $
��Left=�6    $��	10,93,0,0q�6;   $
��Wrap=�6N   $��Địa chỉ:��6b   $	��Top=�6r   �� 5      -   5        $ diaChi��5      $��23��6.   $��
80,90,10,0q�6:   $
 Wrap=�6N   $	��Top=�6b   �� 5      $
��Left=�6    $��
10,133,0,0q�6;   $
��Wrap=�6O   $��Số tiền:��6c   $	��Top=�6s   �� 5      -   5        $ soTien��5      $��23��6.   $��80,130,10,0q�6:   $
 Wrap=�6O   $	��Top=�6c   6�   �� 5      $
��Left=�6    $��
10,173,0,0q�6;   $
��Wrap=�6O   $��Diễn giải:��6c   $	��Top=�6u   �� 5      -   5         ��Name$ noidung��5   "   $��10,193,10,10q�63   5      5      5      �� 5   
   $��50��6   $��Bottom=�6   $ 5��68   $��
-1,0,-1,-3q�6I   $��1��6]     	clBack2WP#���  6j   ._�5      � .+�5       �� -   5         ��Name$
 BtIn��5       $��Lập và In��6'   {�.  $��0,13,230,13q�6M   $��Right=�6b   $	��100��6~   6�   �� 5!      -	   5        $
 BtOK��5!      $��Lập Phiếu��6'   {�.  $��0,13,120,13q�6M   $��Right=�6b   $	��100��6~   6�   �� 5"      -
   5        $ BtHuy��5"      $��Hủy��6(   $��
0,13,10,13q�66   $��Right=�6J   $	��100��6f   6r   5#      5$      5%      5&      