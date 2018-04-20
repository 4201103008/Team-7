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
    /// Interaction logic for Wp_ThemCV.xaml
    /// </summary>
    public partial class Wp_ThemCV : Window
    {
        private bool _ck = false;

        public Wp_ThemCV()
        {
            InitializeComponent();
        }

        public static bool f_ThemCV()
        {
            Wp_ThemCV _win = new Wp_ThemCV();

            _win.ShowDialog();

            if(_win._ck)
            {
                byte b = Ktbit.taoByteC(_win.qlnhansu.IsChecked == true, _win.qlcalamcv.IsChecked == true, _win.qlban.IsChecked == true, _win.qlthuchi.IsChecked == true, _win.qlmathangncc.IsChecked == true, _win.qlbanhang.IsChecked == true, _win.qlnhaphang.IsChecked == true, false);

                ThongBaoHT.f_ThongBao(ChucVuList.AddCV(_win.ten.Text, b), "Thêm chức vụ");

                return true;
            }
            return false;
        }

        private void ten_KeyUp(object sender, KeyEventArgs e)
        {
            if(ten.Text.Length > 0)
            {
                BtOK.IsEnabled = true;
            }
            else
            {
                BtOK.IsEnabled = false;
            }
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
