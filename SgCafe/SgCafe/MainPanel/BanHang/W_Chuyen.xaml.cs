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
using InforCf;
using DataCf;

namespace SgCafe.MainPanel.BanHang
{
    /// <summary>
    /// Interaction logic for W_Chuyen.xaml
    /// </summary>
    public partial class W_Chuyen : Window
    {
        private bool _ck = false;

        public W_Chuyen()
        {
            InitializeComponent();
        }

        public static bool f_Chuyen(string tb)
        {
            W_Chuyen _win = new W_Chuyen();

            _win.ShowDialog();

            if(_win._ck)
            {
                ThongBaoHT.f_ThongBao(HoaDonList.ChuyenBan(tb, ((Ban)_win.ban.SelectedItem).TenBan), "Chuyển bàn");
                return true;
            }

            return false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ban.ItemsSource = BanList.getBanTrong;
        }

        private void ban_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ban.SelectedIndex != -1)
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
