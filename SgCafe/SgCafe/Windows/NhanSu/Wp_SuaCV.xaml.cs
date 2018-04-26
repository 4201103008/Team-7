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

namespace SgCafe.Windows.NhanSu
{
    /// <summary>
    /// Interaction logic for Wp_SuaCV.xaml
    /// </summary>
    public partial class Wp_SuaCV : Window
    {
        private bool _ck = false;
        public Wp_SuaCV()
        {
            InitializeComponent();
        }

        public static bool f_SuaCV(ChucVu c)
        {
            Wp_SuaCV _win = new Wp_SuaCV();
            _win.maCV.Text = c.MaCV.ToString();
            _win.tenCV.Text = c.TenCV;
            _win.qlnhansu.IsChecked = Ktbit.kiemTra(c.QL, 0);
            _win.qlcalamcv.IsChecked = Ktbit.kiemTra(c.QL, 1);
            _win.qlban.IsChecked = Ktbit.kiemTra(c.QL, 2);
            _win.qlthuchi.IsChecked = Ktbit.kiemTra(c.QL, 3);
            _win.qlmathangncc.IsChecked = Ktbit.kiemTra(c.QL, 4);
            _win.qlbanhang.IsChecked = Ktbit.kiemTra(c.QL, 5);
            _win.qlnhaphang.IsChecked = Ktbit.kiemTra(c.QL, 6);

            _win.ShowDialog();

            if (_win._ck)
            {
                byte b = Ktbit.taoByteC(_win.qlnhansu.IsChecked == true, _win.qlcalamcv.IsChecked == true, _win.qlban.IsChecked == true, _win.qlthuchi.IsChecked == true, _win.qlmathangncc.IsChecked == true, _win.qlbanhang.IsChecked == true, _win.qlnhaphang.IsChecked == true, false);

                ThongBaoHT.f_ThongBao(ChucVuList.EditCV(c.MaCV, _win.tenCV.Text, b), "Sửa chức vụ");

                return true;
            }
            return false;
        }

        private void tenCV_KeyUp(object sender, KeyEventArgs e)
        {
            if (tenCV.Text.Length > 0)
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
