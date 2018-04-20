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
    /// Interaction logic for W_EditTaiKhoan.xaml
    /// </summary>
    public partial class W_EditTaiKhoan : Window
    {
        public bool _kt = false;
        private string ten;

        public W_EditTaiKhoan()
        {
            InitializeComponent();
        }

        public static void f_EditTaiKhoan(vw_TaiKhoanC tk)
        {
            W_EditTaiKhoan _win = new W_EditTaiKhoan();

            _win.ten = tk.TenTK;
            _win.taikhoan.Text = tk.TenTK;
            _win.matkhau.Text = tk.MatKhau;

            _win.ShowDialog();

            if(_win._kt)
            {
                ThongBaoHT.f_ThongBao(TaiKhoanList.EditTaiK(tk.TenTK, _win.taikhoan.Text, _win.matkhau.Text), "Sửa thông tin tài khoản");
            }
        }

        private void matkhau_KeyUp(object sender, KeyEventArgs e)
        {
            if (matkhau.Text.Length < 5)
                BtOK.IsEnabled = false;
            else
                BtOK.IsEnabled = true;
        }

        private void taikhoan_KeyUp(object sender, KeyEventArgs e)
        {
            if(taikhoan.Text == ten || (taikhoan.Text.Length > 0 && !TaiKhoanList.checkName(taikhoan.Text)))
                BtOK.IsEnabled = true;
            else
                BtOK.IsEnabled = false;
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
