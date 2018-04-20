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
using SgCafe.MainPanel.Taikhoan;
using DataCf;
using InforCf;
using StyleCF;
using System.Globalization;

namespace SgCafe.MainPanel
{
    /// <summary>
    /// Interaction logic for P_TaiKhoan.xaml
    /// </summary>
    public partial class P_TaiKhoan : Page
    {
        private static P_TaiKhoan _page = null;

        private P_TaiKhoan()
        {
            InitializeComponent();
        }

        public static P_TaiKhoan getPage
        {
            get
            {
                if(_page == null)
                    _page = new P_TaiKhoan();
                else
                    _page.dmTK.Items.Refresh();
                return _page;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dmTK.ItemsSource = TaiKhoanList.getNotAd;
        }

        private void them_Click(object sender, RoutedEventArgs e)
        {
            W_AddTaiKhoan.f_AddTaiKhoan();
            dmTK.ItemsSource = TaiKhoanList.getNotAd;
            dmTK.Items.Refresh();
        }

        private void sua_Click(object sender, RoutedEventArgs e)
        {
            W_EditTaiKhoan.f_EditTaiKhoan((vw_TaiKhoanC) dmTK.SelectedItem);
            dmTK.Items.Refresh();
        }

        private void XoaTaiK(string tentk)
        {
            ThongBaoHT.f_ThongBao(TaiKhoanList.DeleteTK(tentk), "Xóa tài khoản");
            dmTK.ItemsSource = TaiKhoanList.getNotAd;
            dmTK.Items.Refresh();
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult _R = MessageBoxCF.Show("Xác nhận xóa tài khoản", "Bạn có chắc chắn muốn xóa tài khoản " + ((vw_TaiKhoanC) dmTK.SelectedItem).TenTK + " không?", MessageBoxImage.Question, MessageBoxButton.YesNo);
            if (_R == MessageBoxResult.Yes)
                XoaTaiK(((vw_TaiKhoanC) dmTK.SelectedItem).TenTK);
        }

        private void dmTK_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dmTK.SelectedIndex != -1)
            {
                sua.IsEnabled = true;
                xoa.IsEnabled = true;
            }
            else
            {
                sua.IsEnabled = false;
                xoa.IsEnabled = false;
            }
        }
    }
}
