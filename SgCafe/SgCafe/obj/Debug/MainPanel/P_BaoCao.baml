   M S B A M L   `   `   `  ����A  =SgCafe, Version=1.5.2.3, Culture=neutral, PublicKeyToken=null3clr-namespace:SgCafe.MainPanelSgCafe.MainPanel  5          SgCafe.MainPanel.P_BaoCao   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:SgCafe.MainPanel     5      -   5        $
��PaBC��5        N� Title$  P_BaoCao��5	      .��5
      � $��5q�6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��300 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��2��6    �� CornerRadius$ 5��62   $��0,0,0,0q�6C   ��5      �� 5       �� Color$ White��6"    �� Opacity$	 0.5Q�60   ._�5      �� $��	10,7,10,7q�6   $
��Wrap=�6+    �� TextAlignment$ Center=�6?   $��Xem Báo Cáo��6V   5      � 5   
   $��1��6   $��0��6   .+�5      �� -   5         ��Name$	 xoa��5      $
��Xóa��6"   {�.  $��Center=�6B   $	��120��6_   $��23��6k   $��Center=�6w   6�   5      �� 5   
   -   5         ��Name$ listBC��5      $��2��6#   $��0��6H   $��0q�6X   ��60   �� 	 �� View	 5      �� 5      .P�5       �� $��Tiêu Đề��6%   
 �� Width$	
 150��66    �� DisplayMemberBinding 6B   �� *TieuDe+�� 5!      $��Ngày��6%   $	
 150��63    6?   �� *	NgayGio+5"      5$      �� 5%   
   $��1��6   $��1��6   $��2��6/   $��	10,10,0,0q�6@   $ 5��6S   ��5&      �� 5'      $ White��6"   $	 0.5Q�60   ._�5)      � .+�5*      �� $
��Left=�6   $��	10,15,0,0q�67   $
��Wrap=�6J   $��Tiêu đề:��6^   $	��Top=�6n   �� 5+      -   5         ��Name$ tieude��5+      $�� ��6(   $��	70,10,5,0q�63   $	��Top=�6F    J� RenderTransformOrigin$ 0.316,1.077&�6^   �� 5,      $
��Left=�6   $��	10,45,0,0q�67   $
��Wrap=�6J   $��Người gửi:��6^   $	��Top=�6p   �� 5-      -   5        $ nv��5-      $�� ��6$   $��	70,40,5,0q�6/   $	��Top=�6B   $ 0.316,1.077&�6Z   �� 5.      $
��Left=�6   $��	10,75,0,0q�67   $
��Wrap=�6J   $��Ngày:��6^   $	��Top=�6k   �� 5/      -   5        $
 ngay��5/      $�� ��6&   $��	70,70,5,0q�61   $	��Top=�6D   $ 0.316,1.077&�6\   �� 50      $��10,110,10,10q�6   $ 5��6/   ��51      �� 52      $ White��6*   $	 0.5Q�68   ._�54      ,� -   5         ,�Name$ noiDung��54   /   55      56      57      58      59      