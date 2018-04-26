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
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Drawing;

namespace StyleCF
{
    /// <summary>
    /// Interaction logic for MSGB.xaml
    /// </summary>
    public partial class MSGB : Window
    {

        private MessageBoxImage FImage = MessageBoxImage.Information;
        private MessageBoxButton FButton = MessageBoxButton.OK;
        private MessageBoxResult FResult = MessageBoxResult.None;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool MessageBeep(uint type);

        public MSGB()
        {
            InitializeComponent();
        }

        public static MessageBoxResult ShowCore
            (
                string _title = "",
                string _message = "",
                MessageBoxImage _icon = MessageBoxImage.Information,
                MessageBoxButton _button = MessageBoxButton.OK
            )
        {
            MSGB _wmb = new MSGB();

            _wmb.Title = _title;
            _wmb.textBlock.Text = _message;

            _wmb.FImage = _icon;
            _wmb.FButton = _button;
            
            MessageBeep(0);
            _wmb.ShowDialog();

            return _wmb.FResult;
        }

        private void Wind_Loaded(object sender, RoutedEventArgs e)
        {
            Stackpan.Cursor = Cursors.Arrow;
            this.SetupButtonImage();
            this.SetupButton();
        }

        private void SetupButton()
        {
            if (FButton == MessageBoxButton.OK)
            {
                this.CreateButton("btnOK", "OK");
            }
            else if (FButton == MessageBoxButton.OKCancel)
            {
                this.CreateButton("btnOK", "OK");
                this.CreateButton("btnCancel", "Cancel");
            }
            else if (FButton == MessageBoxButton.YesNo)
            {
                this.CreateButton("btnYes", "Yes");
                this.CreateButton("btnNo", "No");
            }
            else if (FButton == MessageBoxButton.YesNoCancel)
            {
                this.CreateButton("btnYes", "Yes");
                this.CreateButton("btnNo", "No");
                this.CreateButton("btnCancel", "Cancel");
            }

            var border = new Border();
            border.Width = 10;
            Stackpan.Children.Add(border);
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.Name == "btnOK")
                FResult = MessageBoxResult.OK;
            else if (button.Name == "btnCancel")
                FResult = MessageBoxResult.Cancel;
            else if (button.Name == "btnYes")
                FResult = MessageBoxResult.Yes;
            else if (button.Name == "btnNo")
                FResult = MessageBoxResult.No;

            this.Close();
        }

        private void CreateButton(string name, string caption)
        {
            var button = new Button();
            button.Name = name;
            button.Width = 80;
            button.Content = caption;
            button.Margin = new Thickness(15, 10, 5, 10);

            button.Click += new RoutedEventHandler(button_Click);

            Stackpan.Children.Add(button);

            if (FResult == MessageBoxResult.None)
            {
                if ((name == "btnOK") || (name == "btnYes"))
                    Keyboard.Focus(button);
            }
            else if (FResult == MessageBoxResult.OK)
            {
                if (name == "btnOK")
                    Keyboard.Focus(button);
            }
            else if (FResult == MessageBoxResult.Cancel)
            {
                if (name == "btnCancel")
                    Keyboard.Focus(button);
            }
            else if (FResult == MessageBoxResult.Yes)
            {
                if (name == "btnYes")
                    Keyboard.Focus(button);
            }
            else if (FResult == MessageBoxResult.No)
            {
                if (name == "btnNo")
                    Keyboard.Focus(button);
            }
        }

        private void SetupButtonImage()
        {
            switch (FImage)
            {
                case MessageBoxImage.Asterisk:
                    image.Source = SystemIcons.Asterisk.ToImageSource();
                    break;
                case MessageBoxImage.Error:
                    image.Source = SystemIcons.Error.ToImageSource();
                    break;
                case MessageBoxImage.Question:
                    image.Source = SystemIcons.Question.ToImageSource();
                    break;
                case MessageBoxImage.Warning:
                    image.Source = SystemIcons.Warning.ToImageSource();
                    break;
                default:
                    image.Source = null;
                    break;
            }
            image.Width = 32;
            image.Height = 32;
        }
    }
}