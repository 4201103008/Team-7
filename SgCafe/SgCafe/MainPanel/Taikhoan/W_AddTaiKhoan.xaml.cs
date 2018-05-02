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

namespace SgCafe.MainPanel.Taikhoan
{
    /// <summary>
    /// Interaction logic for W_AddTaiKhoan.xaml
    /// </summary>
    public partial class W_AddTaiKhoan : Window
    {
        public bool _kt = false;

        public W_AddTaiKhoan()
        {
            InitializeComponent();
        }

        public static void f_AddTaiKhoan()
        {
            W_AddTaiKhoan _win = new W_AddTaiKhoan();
            _win.ShowDialog();

            if (_win._kt)
            {
                ThongBaoHT.f_ThongBao(TaiKhoanList.AddNTk(_win.taikhoan.Text, _win.matkhau.Text, (vw_NhanVienCV) _win.nhanvien.SelectedItem), "Thêm tài khoản");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.nhanvien.ItemsSource = from p in NhanVienList.getListQL
                                        where !TaiKhoanList.getList.Any(x => x.MaNV == p.MaNV) && p.QL > 0
                                        select p;
        }

        private void nhanvien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (nhanvien.SelectedIndex != -1)
            {
                taikhoan.IsEnabled = true;
                matkhau.IsEnabled = true;
            }
        }

        private void CheckTao()
        {
            if (taikhoan.Text.Length > 0 && matkhau.Text.Length > 4)
                BtOK.IsEnabled = true;
            else
                BtOK.IsEnabled = false;
        }

        private void taikhoan_KeyUp(object sender, KeyEventArgs e)
        {
            CheckTao();
        }

        private void matkhau_KeyUp(object sender, KeyEventArgs e)
        {
            CheckTao();
        }

        private void BtOK_Click(object sender, RoutedEventArgs e)
        {
            _kt = true;

            Close();
        }

        private void BtHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
