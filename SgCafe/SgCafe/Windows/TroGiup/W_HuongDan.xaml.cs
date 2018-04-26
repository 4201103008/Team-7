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
using System.IO;
using Microsoft.Win32;
using System.Windows.Markup;
using HelpCf;
using InforCf;
using System.Xml;

namespace SgCafe.Windows.TroGiup
{
    /// <summary>
    /// Interaction logic for W_HuongDan.xaml
    /// </summary>
    public partial class W_HuongDan : Window
    {
        private W_HuongDan()
        {
            InitializeComponent();
        }

        private static W_HuongDan _win = null;

        public static void f_Show()
        {
            if(_win == null)
            {
                _win = new W_HuongDan();
                _win.Show();
            }
            else
                _win.Activate();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _win = null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listDs.ItemsSource = LoadHelp.ListName;
        }

        private void listDs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listDs.SelectedIndex != -1)
                noiDung.Document = LoadHelp.loadHelp(((NameHelp)listDs.SelectedItem).ma);
        }

        public static bool IsFlowDocument(string xamlString)
        {
            if(xamlString == null || xamlString == "")
                throw new ArgumentNullException();

            if(xamlString.StartsWith("<") && xamlString.EndsWith(">"))
            {
                XmlDocument xml = new XmlDocument();
                try
                {
                    xml.LoadXml(string.Format("<Root>{0}</Root>", xamlString));
                    return true;
                }
                catch(XmlException)
                {
                    return false;
                }
            }
            return false;
        }

        public static FlowDocument toFlowDocument(string xamlString)
        {
            if(IsFlowDocument(xamlString))
            {
                var stringReader = new StringReader(xamlString);
                var xmlReader = System.Xml.XmlReader.Create(stringReader);

                return XamlReader.Load(xmlReader) as FlowDocument;
            }
            else
            {
                Paragraph myParagraph = new Paragraph();
                myParagraph.Inlines.Add(new Run(xamlString));
                FlowDocument myFlowDocument = new FlowDocument();
                myFlowDocument.Blocks.Add(myParagraph);

                return myFlowDocument;
            }
        }
    }
}
