   M S B A M L   `   `   `  ����A  =SgCafe, Version=1.5.2.3, Culture=neutral, PublicKeyToken=null=#clr-namespace:SgCafe.Windows.NhanSuSgCafe.Windows.NhanSu  5   	   B >StyleCF, Version=1.5.2.3, Culture=neutral, PublicKeyToken=nullB.clr-namespace:StyleCF.Control;assembly=StyleCFStyleCF.Control 5   	   $    SgCafe.Windows.NhanSu.Wp_SuaCa   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:SgCafe.Windows.NhanSu     5   	   BControl.clr-namespace:StyleCF.Control;assembly=StyleCF     5   	   -   5           wd_ScWindows#��[  5        � Title$  Sửa thông tin ca làm��5	   	   $	��350��6&   $	��300��63    � WindowStartupLocation$ CenterScreen=�6X   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��55 �6   .+�5   
   � $��0��6   .+�5      �� $��	-1,0,-1,5q�6    �� CornerRadius$ 0,0,5,5��6(     	clBack1WP#���  6?   ._�5      � .+�5      �� $
��Left=�6    $��	10,13,0,0q�6;   $
��Wrap=�6N   $��Mã ca:��6b   $	��Top=�6p   �� 5      -   5         ��Name$
 maCa��5       �� 
IsReadOnly . $��23��6>   $��
65,10,10,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   �� 5      $
��Left=�6    $��	10,53,0,0q�6;   $
��Wrap=�6N   $��Tên ca:��6b   $	��Top=�6q   �� 5      -   5        $ tenCa��5      $��23��6-   $��
65,50,10,0q�69   $
 Wrap=�6M   $	��Top=�6a   6y   �� 5      $
��Left=�6    $��	10,93,0,0q�6;   $
��Wrap=�6N   $��Thời gian bắt đầu:��6b   $	��Top=�6|   �� 5      $
��Left=�6    $��
10,133,0,0q�6;   $
��Wrap=�6O   $��Thời gian kết thúc:��6c   $	��Top=�6~     StyleCF.Control.TimeCf  5      -   5          Name$ batdau��5   %   $��23��65   $��120,90,10,0q�6A   $	��Top=�6V     5      -   5        $ ketthuc��5   %   $��23��66   $��120,130,10,0q�6B   $	��Top=�6X   �� 5      $
��Left=�6    $��
10,173,0,0q�6;   $
��Wrap=�6O   $��	Ghi chú:��6c   $	��Top=�6s   �� 5      -   5         ��Name$ ghiChu��5   "   $��65,170,10,5q�62   5      5      5      �� 5   
   $��50��6   $��Bottom=�6   $ 5��68   $��
-1,0,-1,-3q�6I   $��1��6]     	clBack2WP#���  6j   ._�5       � .+�5!      �� -   5        	 ��Name$
	 BtOK��5!      $��Sửa��6'   $��0,13,120,13q�65   $��Right=�6J   $	��100��6f   6r   �� 5"      -   5        $	 BtHuy��5"      $��Hủy��6(   $��
0,13,10,13q�66   $��Right=�6J   $	��100��6f   6r   5#      5$      5%      5&      