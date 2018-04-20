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
using StyleCF;
using DataCf;

namespace SgCafe.Windows.HoatDong
{
    /// <summary>
    /// Interaction logic for DSBan.xaml
    /// </summary>
    public partial class W_DSBan : Window
    {
        public W_DSBan()
        {
            InitializeComponent();
        }

        public static void f_DsBan()
        {
            W_DSBan ds = new W_DSBan();

            ds.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listBan.ItemsSource = BanList.getList;
        }

        private void listBan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBan.SelectedIndex != -1)
                xoa.IsEnabled = true;
            else
                xoa.IsEnabled = false;
        }

        private void them_Click(object sender, RoutedEventArgs e)
        {
            Wp_ThemBan.f_ThemBan();
            listBan.Items.Refresh();
        }

        private void XoaBan(string teb)
        {
            ThongBaoHT.f_ThongBao(BanList.DeleteBan(teb), "Xóa bàn");

            listBan.Items.Refresh();
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult _R = MessageBoxCF.Show("Xác nhận xóa bàn", "Bạn có chắc chắn muốn xóa bàn này không?", MessageBoxImage.Question, MessageBoxButton.YesNo);
            if (_R == MessageBoxResult.Yes)
                XoaBan(((Ban) listBan.SelectedItem).TenBan);
        }
    }
}
