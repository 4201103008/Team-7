using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace StyleCF.Control
{
    /// <summary>
    /// Interaction logic for RTFB.xaml
    /// </summary>
    public partial class RTFB : UserControl
    {
        public RTFB()
        {
            InitializeComponent();
        }

        public TextRange SpText
        {
            get
            {
                return new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);
            }
        }

        public FlowDocument DoText
        {
            get
            {
                return RichTextBox.Document;
            }
        }

        private void Fonttype_DropDownClosed(object sender, EventArgs e)
        {
            string fontName = (string) Fonttype.SelectedItem;

            if (fontName != null)
            {
                RichTextBox.Selection.ApplyPropertyValue(System.Windows.Controls.RichTextBox.FontFamilyProperty, fontName);
                RichTextBox.Focus();
            }
        }

        private void Fontheight_DropDownClosed(object sender, EventArgs e)
        {
            string fontHeight = (string) Fontheight.SelectedItem;

            if (fontHeight != null)
            {
                RichTextBox.Selection.ApplyPropertyValue(System.Windows.Controls.RichTextBox.FontSizeProperty, fontHeight);
                RichTextBox.Focus();
            }
        }

        private void TagLeft()
        {
            RightJustify.IsChecked = false;
            CenterJustify.IsChecked = false;
            LeftJustify.IsChecked = true;
            Justify.IsChecked = false;
        }

        private void TagCenter()
        {
            RightJustify.IsChecked = false;
            CenterJustify.IsChecked = true;
            LeftJustify.IsChecked = false;
            Justify.IsChecked = false;
        }

        private void TagRight()
        {
            RightJustify.IsChecked = true;
            CenterJustify.IsChecked = false;
            LeftJustify.IsChecked = false;
            Justify.IsChecked = false;
        }

        private void TagJustify()
        {
            RightJustify.IsChecked = false;
            CenterJustify.IsChecked = false;
            LeftJustify.IsChecked = false;
            Justify.IsChecked = true;
        }

        private void LeftJustify_Click(object sender, RoutedEventArgs e)
        {
            if (LeftJustify.IsChecked == true)
            {
                TagLeft();
            }
        }

        private void CenterJustify_Click(object sender, RoutedEventArgs e)
        {
            if (CenterJustify.IsChecked == true)
            {
                TagCenter();
            }
        }

        private void RightJustify_Click(object sender, RoutedEventArgs e)
        {
            if (RightJustify.IsChecked == true)
            {
                TagRight();
            }
        }

        private void Justify_Click(object sender, RoutedEventArgs e)
        {
            if (Justify.IsChecked == true)
            {
                TagJustify();
            }
        }

        private void Rtfb_Loaded(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(RichTextBox.Selection.Start, RichTextBox.Selection.End);
            Fonttype.SelectedValue = range.GetPropertyValue(FlowDocument.FontFamilyProperty).ToString();
            Fontheight.SelectedValue = range.GetPropertyValue(FlowDocument.FontSizeProperty).ToString();
            
            RichTextBox.Focus();
        }

        private void RichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            string fontName = (string) Fonttype.SelectedValue;
            string fontHeight = (string) Fontheight.SelectedValue;
            TextRange range = new TextRange(RichTextBox.Selection.Start, RichTextBox.Selection.End);
        }

        private void RichTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            // Ctrl + B
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.B))
            {
                if (bold.IsChecked == true)
                {
                    bold.IsChecked = false;
                }
                else
                {
                    bold.IsChecked = true;
                }
            }

            // Ctrl + I
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.I))
            {
                if (italic.IsChecked == true)
                {
                    italic.IsChecked = false;
                }
                else
                {
                    italic.IsChecked = true;
                }
            }

            // Ctrl + U
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.U))
            {
                if (underline.IsChecked == true)
                {
                    underline.IsChecked = false;
                }
                else
                {
                    underline.IsChecked = true;
                }
            }
        }

        private void RichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            // markierten Text holen
            TextRange selectionRange = new TextRange(RichTextBox.Selection.Start, RichTextBox.Selection.End);


            if (selectionRange.GetPropertyValue(FontWeightProperty).ToString() == "Bold")
            {
                bold.IsChecked = true;
            }
            else
            {
                bold.IsChecked = false;
            }

            if (selectionRange.GetPropertyValue(FontStyleProperty).ToString() == "Italic")
            {
                italic.IsChecked = true;
            }
            else
            {
                italic.IsChecked = false;
            }

            if (selectionRange.GetPropertyValue(Inline.TextDecorationsProperty) == TextDecorations.Underline)
            {
                underline.IsChecked = true;
            }
            else
            {
                underline.IsChecked = false;
            }

            if (selectionRange.GetPropertyValue(FlowDocument.TextAlignmentProperty).ToString() == "Left")
            {
                TagLeft();
            }

            if (selectionRange.GetPropertyValue(FlowDocument.TextAlignmentProperty).ToString() == "Center")
            {
                TagCenter();
            }

            if (selectionRange.GetPropertyValue(FlowDocument.TextAlignmentProperty).ToString() == "Right")
            {
                TagRight();
            }

            if (selectionRange.GetPropertyValue(FlowDocument.TextAlignmentProperty).ToString() == "Justify")
            {
                TagJustify();
            }
            
            // Get selected font and height and update selection in ComboBoxes
            Fonttype.SelectedValue = selectionRange.GetPropertyValue(FlowDocument.FontFamilyProperty).ToString();
            Fontheight.SelectedValue = selectionRange.GetPropertyValue(FlowDocument.FontSizeProperty).ToString();
        }
    }
}
