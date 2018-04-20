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
using DataCf;
using InforCf;
using StyleCF;

namespace SgCafe.Windows.HoatDong
{
    /// <summary>
    /// Interaction logic for W_ThemBan.xaml
    /// </summary>
    public partial class Wp_ThemBan : Window
    {
        private bool _ck = false;

        private Wp_ThemBan()
        {
            InitializeComponent();
        }

        public static void f_ThemBan()
        {
            Wp_ThemBan _win = new Wp_ThemBan();

            _win.ShowDialog();

            if(_win._ck)
            {
                TextRange gc = new TextRange(_win.ghichu.Document.ContentStart, _win.ghichu.Document.ContentEnd);

                ThongBaoHT.f_ThongBao(BanList.AddBan(_win.ten.Text, gc.Text), "Thêm bàn");
            }
        }

        private void ten_KeyUp(object sender, KeyEventArgs e)
        {
            if (ten.Text.Length > 0)
                BtOK.IsEnabled = true;
            else
                BtOK.IsEnabled = false;
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
