   M S B A M L   `   `   `  ����B  >StyleCF, Version=1.5.2.3, Culture=neutral, PublicKeyToken=null5clr-namespace:StyleCF.ResourcesStyleCF.Resources  5      a ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes 5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source=   7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Padding �� CornerRadius	 �� Color
 �� Opacity J� SnapsToDevicePixels)  #System.Windows.Controls.DataGridRow?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid � ColumnDefinitions � RowDefinitions?  9System.Windows.Controls.Primitives.DataGridCellsPresenter   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter   DetailsVisibility$   SelectiveScrollingOrientation;  5System.Windows.Controls.SelectiveScrollingOrientation   Vertical �� ConverterParameter&   System.Windows.Controls.DataGrid#   RowDetailsScrollingConverter �� 	Converter �� RelativeSource �� AncestorType:  4System.Windows.Controls.Primitives.DataGridRowHeader7  1System.Windows.Controls.DataGridHeadersVisibility
   Row!   HeadersVisibilityConverter*	  $System.Windows.Controls.DataGridCell �� Triggers P� Property P� Value �� 
TargetName   SelectCellDG ��Name F�Name �� Stretch  ��Name!   SelectAllCommand" �� 
ResourceId# �� TypeInTargetAssembly
$   AllG
  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter% 
 Name&   Column' ��Name( �� CanContentScroll) ��Name* �� ScrollableHeight+ � Maximum, �� Orientation  MyScrollBar- �� ViewportHeight. �� ViewportSize*/ �� #ComputedVerticalScrollBarVisibility0 � Value1 �� Mode2 �� ScrollableWidth3 �� ViewportWidth,4 �� %ComputedHorizontalScrollBarVisibility5 �� Triggers�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      )localclr-namespace:StyleCF.Resources  5      gMicrosoft_Windows_ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero  5        5      �� 5   
   $# /StyleCF;component/Color.xaml?�6   �� 5   
   $ Dictionary_CheckBox.xaml?�6   %�  '         '  v    '	      7   'd� O    '  d    �� 5
      "   6   .�5   
   ��  � �� 5      �� 5      "   6"   .R�5      � .+�5      �� $ columnHeaderBorder��6!   $ 5,0,5,0q�5      ���	#FFC1C1C1$ 5,5,0,0��69   ��5      �� 5   "   $	 White��62   $	
 0.5Q�6@   ._�5      �� #��z��6/   #��z��5      # z 5      5      5      5      5      5      �� 5      "  6   .�5   
   ��  �@ ValidationErrorTemplate 5       �� 5!      .R�5"      �� $��2,0,0,0q�6    $��Center=�5#      
���  ��$��!��5%      5&      5(      �� 5)   
    � �� 5*      �� 5+      "  6"   .R�5,      �� $ 
DGR_Border��6   #��z��5-      #��z��5.       . ��50      �� 51      $	 White��6.   $	
 0.5Q�6<   ._�53         54      �� 55   "   $
��Auto �63   �� 56   "   $��* �63    58      �� 59   "   $��* �60   �� 5:   "   $
��Auto �60   .+�5<        $��1��65   #��z 5=       # z 5>         5?      $��1��67   $��1��5@   "   #y�z 5E   "    5A   "   �� *AreRowDetailsFrozen+# Z # Z  �� "  5E   "     5F      $��2��60   $ Vertical=�5G      y�5H      �� *HeadersVisibility+# Z # Z  �� "  5L      5M      5N      5P      5Q      �� 5S      " 	 6   .�5T   
   ��  � �� 5U      �� 5V      " 	 6"   .R�5W      �� $ border��6   
������  . ._�5Z      �� # z 6+   5[       5\      P� 5]       �@	 
IsSelected . . �5^      �� $ border��6%   8    � ��6O   5_      5a      5c      5d      �� 5f      " d�6   .�5g   
   ��  � �� 5h      �� 5i      " d�6"   .R�5j      � .+�5k      �� $ contentPresenter��6+   #��z��5l      #��z��5m      #��z��5n      #��z��5o      #��z��5p      F� 5q      $ DefaultPath��6   $	��Top=�5r      "����        р�� ��j �    ��� 	
�������$
 Fill=�5u      F� 5v      $ CheckedPath��6   $	��Top=�5w      "����        р��     ���j ��� 	
�������$
 Fill=�5z      $y�	Collapsed=�5{      5|      5}      5      5�      �� 5�      "  6   .�5�   
   ��  � �� 5�      �� 5�      "  6"   .R�5�      �� $ 5��5�       . $��1q�5�   )   ��5�      �� 5�      $	 White��6.   $	
 0.5Q�6<   ��5�      �� 5�      $	 	#FFE0D8D8��6.   $	
 0.8Q�6@   ._�5�      �� $  DG_ScrollViewer��6'   |�.  ��5�      �� 5�   "   " ��62   .R�5�   &   �  5�   *   �� 5�   .   $
��Auto �6?   �� 5�   .   $��* �6?   �� 5�   .   $
��Auto �6?    5�   *   �� 5�   .   $
��Auto �6<   �� 5�   .   $��* �6<   �� 5�   .   $
��Auto �6<   .+�5�   *   �� #��Z! 5�      |�.  ��5�   1   �� *CellsPanelHorizontalOffset+ �� "  ��5�      C� *�� $"" DataGridSelectAllButtonStyle��"#  +y�5�      �� *HeadersVisibility+# Z$ # Z  �� "  
  5�   *   $!% PART_ColumnHeadersPresenter��6I   $��1��5�   +   y�5�   +   �� *HeadersVisibility+# Z& # Z  �� "  �� 5�   *   $!' PART_ScrollContentPresenter��6A   $��1��5�   #   $��2��5�   #   #( z��5�   #   �� 5�   *   $) PART_VerticalScrollBar��64   $��1��5�      $��2��5�      #+ z* 5�      $, Vertical=�5�      #���  5�      #. z- 5�      #y�z/ 5�      0 5�      �� *VerticalOffset+$1 OneWay=� �� *TemplatedParent+� 5�   *   $��2��6/   $��1��6<    5�   .   �� 5�   2   ��6C   �� **(NonFrozenColumnsViewportHorizontalOffset+ �� "  �� 5�   2   $��* �6C   .+�5�   .   �� $) PART_HorizontalScrollBar��68   $��1��5�      #+ z2 5�      $, 
Horizontal=�5�      #. z3 5�      #y�z4 5�      0 5�      �� *HorizontalOffset+$1 OneWay=� �� *TemplatedParent+5�   +   5�   '   5�   #   .��5�      �� # z 6-   5�      5�      5�      5�      5 5�   
   P� 5�       �@��
IsGrouping . . �5�      ��  � �� . 6B   5�      5�      5�      