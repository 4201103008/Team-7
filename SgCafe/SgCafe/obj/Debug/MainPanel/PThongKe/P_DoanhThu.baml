   M S B A M L   `   `   `  ����A  =SgCafe, Version=1.5.2.3, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SgCafe.MainPanel.PThongKeSgCafe.MainPanel.PThongKe  5      *    $SgCafe.MainPanel.PThongKe.P_DoanhThu   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:SgCafe.MainPanel.PThongKe     5      -   5          N�Name$  _this��5       N� Title$ 
P_DoanhThu��5	       � 	Resources 5
      +   %SgCafe.MainPanel.PThongKe.SumDoanhThu   cvSumDoanhThu��%   &	          5   
   6   5      .��5      � $��0q�6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��250 �6   .+�5   
   � $��0��6   .+�5      �� $
��Left=�6   $��	160,8,0,0q�63   $
��Wrap=�6F   $��
Từ ngày��6Z   $	��Top=�6i   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ TuNgay��5      $
��Left=�6)   $	��101��6D   $��	220,4,0,0q�6P   $	��Top=�6c   6{   �� 5      $
��Left=�6   $��	330,8,0,0q�63   $
��Wrap=�6F   $��Đến ngày��6Z   $	��Top=�6j     5      -   5        $ DenNgay��5      $
��Left=�6*   $	��101��6E   $��	390,4,0,0q�6Q   $	��Top=�6d   6|   �� 5      -   5         ��Name$ btXem��5      {�.  $	��Xem��66   $
��Left=�6D   $��	500,4,0,0q�6_   $	��Top=�6r   $��74��6�   6�   �� 5      -   5         ��Name$ listDoanhThu��5      $��	0,32,10,0q�6-   ��6@   �� *	getListDT+ �� ElementName$ _this�� �� UpdateSourceTrigger$ PropertyChanged=�	 �� View	 5      �� 5      .P�5      �� $��Ngày��6)   
 �� Width$
 80��67    �� DisplayMemberBinding 6B   �� *Ngay+ �� StringFormat$ 
dd/MM/yyyy���� 5      $��Số tiền��6)   $	
 150��6:    6F   �� *SoTien+$
 0.00���� 5      $��Nhân viên��6)   $	
 150��6<    6H   �� *TenNV+�� 5      $��
Nội dung��6)   $	
 400��6;    6G   �� *LyDo+5      5!      5"      � 5#   
   $��1��6   .+�5$      �� $��0,8,0,0q�6   $
��Wrap=�6)   $ ��Doanh Thu Tính Theo Ngày��6=   $	��Top=�6]    �� TextAlignment$ Center=�6u   �� 5%      -   5        $ listNgay��5%      $��
0,32,0,100q�6)   $��Disabled=�6=   ��6s   �� *getDoanhThu+$ _this��	 5&      �� 5'      .P�5(      �� $��Ngày��6)   $
 90��67    6B   �� *Ngay+$ 
dd/MM/yyyy���� 5)      $��Lợi Nhuận��6)   $	
 160��6<    6H   �� *
LoiNhuan+$
 0.00��5*      5,      �� 5-      $
��Left=�6   $��	10,0,0,63q�63   $
��Wrap=�6F   $��
Tổng thu��6Z   $��Bottom=�6j   �� 5.      $
��Left=�6   $��	10,0,0,33q�63   $
��Wrap=�6F   $��
Tổng chi��6Z   $��Bottom=�6j   �� 5/      -   5         ��Name$ tbThu��5/      $��23��6%    �� 
IsReadOnly . $��	70,0,0,60q�6C    �� TextWrapping$
 Wrap=�6V   $��Bottom=�6�   ��6j   �� *	TongThu+$ _this��$
 0.00��6�   �� 50      -   5        $ tbChi��50      $��23��6%    . $��	70,0,0,30q�6C   $
 Wrap=�6V   $��Bottom=�6�   ��6j   �� *	TongChi+$ _this��$
 0.00��6�   �� 51      $
��Left=�6   $��10,0,0,3q�63   $
��Wrap=�6E   $��Lợi nhuận��6Y   $��Bottom=�6j   �� 52      -	   5        $ loinhuan��52       . $��70,0,0,0q�6:   $
 Wrap=�6L   $��Bottom=�6`   .��6{   ��53      `� 54       `� 	Converter# [  6#   .1�55      �� $ tbChi��6"    �� Path$
 Text�66   �� 56      $ tbThu��6"   $
 Text�66   57      .��58       59      5:      5;      5<      