   M S B A M L   `   `   `  ����B  >StyleCF, Version=1.5.2.3, Culture=neutral, PublicKeyToken=null5clr-namespace:StyleCF.ResourcesStyleCF.Resources  5      a ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes 5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   
DataGrCoHe �� 
TargetType=   7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value �� 
TargetType J� SnapsToDevicePixels  DataGRRo)  #System.Windows.Controls.DataGridRow ��Name?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid � ColumnDefinitions	 � RowDefinitions?  9System.Windows.Controls.Primitives.DataGridCellsPresenter
   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter   DetailsVisibility$   SelectiveScrollingOrientation;  5System.Windows.Controls.SelectiveScrollingOrientation   Vertical �� ConverterParameter&   System.Windows.Controls.DataGrid#   RowDetailsScrollingConverter �� 	Converter �� RelativeSource �� AncestorType:  4System.Windows.Controls.Primitives.DataGridRowHeader7  1System.Windows.Controls.DataGridHeadersVisibility
   Row!   HeadersVisibilityConverter  DataGrCe*	  $System.Windows.Controls.DataGridCell ��Name F�Name �� Stretch  	PrintGrid  
DataGrRoHe ��Name   SelectAllCommand �� 
ResourceId �� TypeInTargetAssembly
   AllG
  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter 
 Name   Column ��Name  �� CanContentScroll! ��Name" �� ScrollableHeight# � Maximum$ �� Orientation  MyScrollBar% �� ViewportHeight& �� ViewportSize*' �� #ComputedVerticalScrollBarVisibility( � Value) �� Mode* �� ScrollableWidth+ �� ViewportWidth,, �� %ComputedHorizontalScrollBarVisibility- �� Triggers. P� Property/ P� Value3  -Microsoft.Windows.Themes.DataGridHeaderBorder0 J� IsMouseOver1   	IsHovered2   	IsPressed3   IsRowSelected4   
IsSelected5   Orientation6 �� Padding7   SeparatorVisibility8   SeparatorVisibility9 �� Orientation  bool2VisibilityConverter�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      )localclr-namespace:StyleCF.Resources  5      gMicrosoft_Windows_ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero  5        5      �� 5   
   $# /StyleCF;component/Color.xaml?�6   %�  &	        &	 \    &	 S    'd� �    &	     7   7  7  7  &	 E    7  �� 5      "   6   .�5   
   ��  � ��$ Center=�65   �� 5   
    � ��$ 35��6#   �� 5   
    � ��$ 14(�6%   �� 5   
    �@  SeparatorBrush
 �  ��6+   �� 5   
    � �� 5      �� 5      "   6"   .R�5      � .+�5      �� # z 6+   $	��Top=�6g   5      5      5      5      �� 5      "  6   .�5   
   ��  � ��
 �����6'   �� 5   
    �@J�SnapsToDevicePixels . 60   �� 5   
    �@=�ErrorTemplate 65   Z� �� 5   
    �@ ValidationErrorTemplate 5       �� 5!      .R�5"      �� $��2,0,0,0q�6    $��Center=�5#      #��z��5$      $��!��5%      5&      5(      �� 5)   
    � �� 5*      �� 5+      "  6"   .R�5,      �� $ 
DGR_Border��6    . ._�5.         5/      �� 50   "   $
��Auto �63   �� 51   "   $��* �63   	 53      �� 54   "   $��* �60   �� 55   "   $
��Auto �60   .+�57        $��1��65   #��z
 58       # z 59       #��z��6\     5:      $��1��67   $��1��5;   "   #y�z 5@   "    5<   "   �� *AreRowDetailsFrozen+# Z # Z  �� "  5@   "     5A      $��2��60   $ Vertical=�5B      #��z��5F   q   y�5C      �� *HeadersVisibility+# Z # Z  �� "  5F   q   5G      5H      5I      5K      5L      �� 5N      " 	 6   .�5O   
   ��  � �� 5P      �� 5Q      " 	 6"   .R�5R      �� # z 6'   5S      5U      5V      �� 5X      " d�6   .�5Y   
   ��  � ��$ 3q�6$   �� 5Z   
    � �� 5[      �� 5\      " d�6"   .R�5]      � .+�5^      �� $ contentPresenter��6+   #��z��5_      #��z��5`      #��z��5a      #��z��5b      #��z��5c      F� 5d      $ DefaultPath��6   $	��Top=�5e      "����        р�� ��j �    ��� 	
�������$
 Fill=�5h      F� 5i      $ CheckedPath��6   $	��Top=�5j      "����        р��     ���j ��� 	
�������$
 Fill=�5m      $y�	Collapsed=�5n      5o      5p      5r      5s      �� 5t      "  6   .�5u   
   ��   �@ RowDetailsVisibilityMode$ VisibleWhenSelected=�65   �� 5v   
    � �� . 6:   �� 5w   
    �@��PanningMode$
 Both=�65   �� 5x   
    �@��IsFlicksEnabled .  63   �� 5y   
    �@ ColumnHeaderStyle8   6.   �� 5z   
    �@ RowHeaderStyle8  6+   �� 5{   
    �@ RowStyle8  6%   �� 5|   
    �@ 	CellStyle8  6&   �� 5}   
    � �� 5~      �� 5      "  6"   .R�5�      �� $ DG_ScrollViewer��6#   |�.  ��5�      �� 5�      " ��6.   .R�5�   "   �  5�   &   �� 5�   *   $
��Auto �6;   �� 5�   *   $��* �6;   �� 5�   *   $
��Auto �6;   	 5�   &   �� 5�   *   $
��Auto �68   �� 5�   *   $��* �68   �� 5�   *   $
��Auto �68   .+�5�   &   �� #��Z 5�      |�.  ��5�   -   �� *CellsPanelHorizontalOffset+ �� "  ��5�      C� *�� $" DataGridSelectAllButtonStyle��"  +y�5�      �� *HeadersVisibility+# Z # Z  �� "  
  5�   &   $! PART_ColumnHeadersPresenter��6E   $��1��5�   +   y�5�   +   �� *HeadersVisibility+# Z # Z  �� "  �� 5�   &   $! PART_ScrollContentPresenter��6=   $��1��5�   #   $��2��5�   #   #  z��5�   #   �� 5�   &   $! PART_VerticalScrollBar��60   $��1��5�      $��2��5�      ## z" 5�      $$ Vertical=�5�      #���  5�      #& z% 5�      #y�z' 5�      ( 5�      �� *VerticalOffset+$) OneWay=� �� *TemplatedParent+� 5�   &   $��2��6+   $��1��68    5�   *   �� 5�   .   ��6?   �� **(NonFrozenColumnsViewportHorizontalOffset+ �� "  �� 5�   .   $��* �6?   .+�5�   *   �� $! PART_HorizontalScrollBar��64   $��1��5�      ## z* 5�      $$ 
Horizontal=�5�      #& z+ 5�      #y�z, 5�      ( 5�      �� *HorizontalOffset+$) OneWay=� �� *TemplatedParent+5�   '   5�   #   5�      .��5�      �� # z 6)   5�      5�      5�      - 5�   
   P� 5�      . �@��
IsGrouping/ . . �5�      ��  � �� . 6B   5�      5�      �� 5�      "  6   .�5�   
   ��  � ��$ 25��6"   �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      � .+�5�        #1 z0 6H   #2 z��5�   6   #4 z3 5�   6   $5 
Horizontal=�5�   6   #6 z��5�   6   #8 z7 5�   6   ._�5�      �� $9 
Horizontal=�6)   .+�5�   "   �� $��Center=�63   # z 6N   �� 5�   "    .  #��z��5�   k   ��5�      �� *ValidationErrorTemplate+ �� "  y�5�      �� *(Validation.HasError)+8    �� "  5�   k   5�      5�      5�      5�      5�      5�      5�      