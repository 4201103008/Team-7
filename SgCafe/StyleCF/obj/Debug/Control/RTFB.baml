   M S B A M L   `   `   `  ����B  >StyleCF, Version=1.5.2.3, Culture=neutral, PublicKeyToken=null1clr-namespace:StyleCF.ControlStyleCF.Control  5          StyleCF.Control.RTFB   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:StyleCF.Control     5      -   5          >�Name$
  Rtfb��5       � 	Resources 5	       �� MergedDictionaries �� Source   FontListKlasse S� 
ObjectType  StyleCF.Control.FontList  FontHeightKlasse   StyleCF.Control.FontHeight�� 5
   
    5      �� 5      $( "/StyleCF;component/ThemeStyle.xaml?�6%   %D   &	        &	      S� 5      "  6N   S� 5      "  6P   5      .��5      � -   5        $��mainRB��5      $	��298��6    � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��* �6   .+�5   
   � $��0��6   .+�5      c� -   5         c�Name$ toolBar��5      .@�5      �� -   5         ��Name$ ToolStripButtonCut��5      $��ApplicationCommands.Cut��65    � ToolTip$	 Cut��6W   .��5      �� $��Image\Cut.png��6   $
��None=�63   5      �� 5      -   5        $ ToolStripButtonCopy��5      $��ApplicationCommands.Copy��66   $
 Copy��6Y   .��5      �� $��Image\Copy.png��6   $
��None=�64   5      �� 5      -   5        $ ToolStripButtonPaste��5      $��ApplicationCommands.Paste��67   $ Paste��6[   .��5       �� $��Image\Paste.png��6   $
��None=�65   5!      �� 5"      �� 5#      -   5        $ ToolStripButtonUndo��5#      $��ApplicationCommands.Undo��66   $
 Undo��6Y   .��5$      �� $��Image\Undo.png��6   $
��None=�64   5%      �� 5&      -   5        $ ToolStripButtonRedo��5&      $��ApplicationCommands.Redo��66   $
 Redo��6Y   .��5'      �� $��Image\Redo.png��6   $
��None=�64   5(      �� 5)      d� 5*      -	   5        	 d�Name$
	 bold��5*      $ ��EditingCommands.ToggleBold��6-   $
 Bold��6�   $��22��6�   ��6R   �� 
 �� ElementName$
 RichTextBox��.��5+      �� $
��Bold"�6    $��Times New Roman)�62   $��14(�6O   B6`   5,      d� 5-      -
   5        $	 italic��5-      $"��EditingCommands.ToggleItalic��6/   $ Italic��6�   $��22��6�   ��6V   �� $
 RichTextBox��.��5.      �� $��Italic$�6    $��Times New Roman)�63   $��14(�6P   I6a   5/      d� 50      -   5        $	 	underline��50      $%��EditingCommands.ToggleUnderline��62   $ 	Underline��6�   $��22��6�   ��6\   �� $
 RichTextBox��.��51      �� $��	Underline{�6    $��Times New Roman)�6<   $��14(�6Y   U6j   52      �� 53      �� 54      -   5         ��Name$ Fonttype��54      $	��1,0q�6-   $	��150��6:   $ Font Family��6F   ��6\   ��  �� Mode$ OneWay=� �� Source# [  6�   �� 55      -   5        $ 
Fontheight��55      $	��1,0q�6/   $��50��6<   $ 	Font Size��6G   ��6[   �� $ OneWay=�# [ 6�   �� 56      d� 57      -   5        $	 LeftJustify��57      $��EditingCommands.AlignLeft��64   $ 
Align Left��6�   $��22��6�   ��6X   �� $
 RichTextBox��.��58      �� $��Image/TextLeftJustify.png��6   $��16��6?   $��16��6J   59      d� 5:      -   5        $	 CenterJustify��5:      $!��EditingCommands.AlignCenter��66   $ Align Center��6�   $��22��6�   ��6\   �� $
 RichTextBox��.��5;      �� $��Image/TextCenter.png��6   $��16��6:   $��16��6E   5<      d� 5=      -   5        $	 RightJustify��5=      $ ��EditingCommands.AlignRight��65   $ Align Right��6�   $��22��6�   ��6Z   �� $
 RichTextBox��.��5>      �� $ ��Image/TextRightJustify.png��6   $��16��6@   $��16��6K   5?      d� 5@      -   5        $	 Justify��5@      $"��EditingCommands.AlignJustify��60   $ Align Justify��6�   $��22��6�   ��6W   �� $
 RichTextBox��.��5A      �� $��Image/TextJustify.png��6   $��16��6;   $��16��6F   5B      �� 5C      �� 5D      -   5        $ ToolStripButtonBulletList��5D      $#��EditingCommands.ToggleBullets��6<   $ Bullets��6�   $��22��6�   ��6d   �� $
 RichTextBox��.��5E      �� $��Image\BulletList.png��6   $
��None=�6:   5F      �� 5G      -   5        $  ToolStripButtonNumbersList��5G      $%��EditingCommands.ToggleNumbering��6=   $ Numbers��6�   $��22��6�   ��6g   �� $
 RichTextBox��.��5H      �� $��Image\NumbersList.png��6   $
��None=�6;   5I      �� 5J      �� 5K      -   5        $ ToolStripButtonIndent��5K      $)��#EditingCommands.IncreaseIndentation��68   $ Increase Indent��6�   $��22��6�   ��6f   �� $
 RichTextBox��.��5L      �� $��Image\Indent.png��6   $
��None=�66   5M      �� 5N      -   5        $! ToolStripButtonIndentDelete��5N      $)��#EditingCommands.DecreaseIndentation��6>   $ Decrease Indent��6�   $��22��6�   ��6l   �� $
 RichTextBox��.��5O      �� $��Image\IndentRemove.png��6   $
��None=�6<   5P      5Q      5R      �� 5S   
   -   5        $��RichTextBox��5S      $��1��6)   $��0,5,0,0q�66    �� 	IsEnabled . " �� VerticalScrollBarVisibility$
 Auto=�6c    �� AcceptsReturn .  �� 
AcceptsTab . 6�   5T      5U      