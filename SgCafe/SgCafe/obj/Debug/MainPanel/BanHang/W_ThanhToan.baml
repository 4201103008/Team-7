   M S B A M L   `   `   `  ����A  =SgCafe, Version=1.5.2.3, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SgCafe.MainPanel.BanHangSgCafe.MainPanel.BanHang  5   	   *    $SgCafe.MainPanel.BanHang.W_ThanhToan   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:SgCafe.MainPanel.BanHang     5   	   c _DevExpress.Xpf.Ribbon.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon  5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  6J   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  6�     � Title$  Xác nhận thanh toán��5	   	   $	��300��6%   $	��400��62    � 
ResizeMode$ NoResize=�6>    � WindowStartupLocation$ CenterScreen=�6T    � 	Resources 5
      )   #SgCafe.MainPanel.BanHang.cvisEbleCS 
  cvEble)   #SgCafe.MainPanel.BanHang.cvTinhTien  
cvTinhTien�� 5   
   %:   &	        &	        5      6     5      6   5      ��5      �� 5   
    �� ResourceKey$ wd_ScWindows��6   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��55 �6   .+�5   
   � $��0��6   .+�5      �� $��	-1,0,-1,5q�6    �� CornerRadius$ 0,0,5,5��6(     	clBack1WP#���  6?   ._�5      � .+�5      � $	��100��6   $	��100��6'   $��	20,60,0,0q�64   $
��Left=�6G   $	��Top=�6b   ��5      �� 5       �� ImageSource$% /SgCafe;component/Icon/LyCF.gif��6)   5       �� 5!      $��0,10,0,0q�6    $
��Wrap=�62   $*��$Bạn có muốn thanh toán không?��6F   $	��Top=�6k   $��16(�6�   ���	#FFB05A5A �� TextAlignment$ Center=�6�   �� 5"      $
��Left=�6    $��
150,50,0,0q�6;   $
��Wrap=�6O   $
��Bàn��6c   $	��Top=�6n   $��14(�6�   �� 5#      -   5        	 ��Name$		 ban��5#       $
��Left=�6-   $��
200,50,0,0q�6H   $
��Wrap=�6\   $	��Top=�6p   $��14(�6�   �� 5$      $
��Left=�6    $��
150,90,0,0q�6;   $
��Wrap=�6O   $��Tổng tiền��6c   $	��Top=�6t   $��13.333(�6�   �� 5%      -   5        
 ��Name$

 tong��5%      $��23��6,   $��220,89,20,0q�68    �� TextWrapping$
 Wrap=�6M   $��0��6a   $	��Top=�6j    �� 
IsReadOnly . 6�   �� 5&      $
��Left=�6    $��150,120,0,0q�6;   $
��Wrap=�6P   $��Khách đưa��6d   $	��Top=�6u   $��13.333(�6�   �� 5'      -   5        $
 khachdua��5'      $��23��60   $��220,119,20,0q�6<   $
 Wrap=�6R   $
��0.00��6f   $	��Top=�6r   6�   �� 5(      $
��Left=�6    $��150,150,0,0q�6;   $
��Wrap=�6P   $��Trả lại��6d   $	��Top=�6s   $��13.333(�6�   �� 5)      -   5        $	
 tra��5)      $��23��6+   $��220,149,20,0q�67   $
 Wrap=�6M   $	��Top=�6a    . .��6�   .��5*      `�  `� 	Converter# [ 6'    `� UpdateSourceTrigger$ PropertyChanged=�6O   .1�5+      ��  �� ElementName$
 tong��6&    �� Path$
 Text�69   �� 5,      $ khachdua��6&   $
 Text�6=   5-      5.      5/      50      51      �� 52   
   $��50��6   $��Bottom=�6   $ 5��68   $��
-1,0,-1,-3q�6I   $��1��6]     	clBack2WP#���  6j   ._�53      � .+�54      �� -   5         ��Name$
 BtIn��54      $��Đóng Bill và In��6v   $��0,13,230,13q�6�   $��Right=�6�   $	��100��6�   {�6'   �� *Text+ �� 	Converter# [  $	 tra��6�   �� 55      -   5        $
 BtOK��55      $��Đóng Bill��6v   $��0,13,120,13q�6�   $��Right=�6�   $	��100��6�   {�6'   �� *Text+# [  $	 tra��6�   �� 56      -   5        $ BtHuy��56      $��Hủy��6(   $��
0,13,10,13q�66   $��Right=�6J   $	��100��6f   6r   57      58      59      5:      