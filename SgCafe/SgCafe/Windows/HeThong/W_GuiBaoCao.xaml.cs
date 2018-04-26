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
using System.Windows.Markup;
using DataCf;
using InforCf;
using StyleCF;

namespace SgCafe.Windows.HeThong
{
    /// <summary>
    /// Interaction logic for GuiBaoCao.xaml
    /// </summary>
    public partial class W_GuiBaoCao : Window
    {
        private bool _ck = false;

        public W_GuiBaoCao()
        {
            InitializeComponent();
        }

        public static void f_SendBC()
        {
            W_GuiBaoCao _win = new W_GuiBaoCao();

            _win.ShowDialog();

            if(_win._ck)
            {
                ThongBaoHT.f_ThongBao(BaoCaoList.AddBC(_win.tieude.Text, XamlWriter.Save(_win.documen.DoText)), "Gửi");
            }
        }

        private void checkND()
        {
            if (tieude.Text.Length == 0 || documen.SpText.Text.Length == 0)
                BtOK.IsEnabled = false;
            else
                BtOK.IsEnabled = true;
        }

        private void documen_KeyUp(object sender, KeyEventArgs e)
        {
            checkND();
        }

        private void tieude_KeyUp(object sender, KeyEventArgs e)
        {
            checkND();
        }

        private void BtOK_Click(object sender, RoutedEventArgs e)
        {
            _ck = true;

            Close();
        }

        private void BtHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
