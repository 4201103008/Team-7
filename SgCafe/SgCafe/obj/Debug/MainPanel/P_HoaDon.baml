   M S B A M L   `   `   `  ����A  =SgCafe, Version=1.5.2.3, Culture=neutral, PublicKeyToken=null3clr-namespace:SgCafe.MainPanelSgCafe.MainPanel  5          SgCafe.MainPanel.P_HoaDon   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:SgCafe.MainPanel     5      -   5          N� Title$  P_HoaDon��5	       � 	Resources 5
      !   SgCafe.MainPanel.cvNhanVien   converNhanVien"   SgCafe.MainPanel.cvTrangThai  convertTrangtT   SgCafe.MainPanel.cvGio  	converGio   SgCafe.MainPanel.cvTimeM2  	converMut   SgCafe.MainPanel.Ticker 
 Ticker�� 5   
   %�   &	        &	      &	 &     &	 9     &	 L       5      6     5      6      5      6     5      6     5      6   5      .��5      � $��5q�6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� CornerRadius$ 5��6   $��0,0,0,0q�6/   ��5      �� 5       �� Color$ White��6"    �� Opacity$	 0.5Q�60   ._�5      �� $��	10,7,10,7q�6   $
��Wrap=�6+    �� TextAlignment$ Center=�6?   $&�� Danh Sách Hóa Đơn Bán Hàng��6V   5      �� 5&   
   -   5         ��Name$ 
listHoaDon��5&      $��0,5,0,0q�6c   $��2��6t   ��6'   ��  �� UpdateSourceTrigger$ PropertyChanged=�	 �� View	 5'      �� 5(      .P�5)      �� $��Số Hóa Đơn��6%   
 �� Width$	
 110��69    �� DisplayMemberBinding 6E   �� *SoHD+ �� StringFormat$ 000000000000000���� 5*      $��Ngày��6%   $
 80��63    6>   �� *Ngay+$ 
dd/MM/yyyy���� 5+      $��Tiền nước��6%   $	
 100��68    6D   �� *
TienNuoc+$
 0.00���� 5,      $��Tổng tiền��6%   $	
 100��68    6D   �� *
TongTien+$
 0.00���� 5-      $��Nhân viên��6%   $	
 160��68    6D   �� *MaNV+ �� 	Converter# [  �� 5.      $��Trạng thái��6%   $	
 120��69    6E   �� *	TrangThai+# [ �� 5/      $
��Bàn��6%   $
 85��62    6=   �� *TenBan+�� 50      $��VAT(%)��6%   $
 60��65    6@   �� *VAT+�� 51      $��Giảm giá(%)��6%   $
 80��6:    6E   �� *	GiamGia+�� 52      $��
Giờ mở��6%   $
 80��65    6@   �� *GMo+# [ �� 53      $��Giờ đóng��6%   $
 80��67    6B   �� *GDong+# [ 5;      5=      5>      5?      