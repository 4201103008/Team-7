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

namespace SgCafe.MainPanel.NhanVien
{
    /// <summary>
    /// Interaction logic for W_DoiCV.xaml
    /// </summary>
    public partial class W_DoiCV : Window
    {
        private bool _ck = false;

        private W_DoiCV()
        {
            InitializeComponent();
        }

        public static bool f_DoiCV(DataCf.NhanVien nv)
        {
            W_DoiCV _win = new W_DoiCV();

            _win.maNV.Text = nv.MaNV.ToString();
            _win.tenNv.Text = nv.TenNV;
            _win.chucVu.ItemsSource = ChucVuList.getList;
            _win.chucVu.SelectedIndex = ChucVuList.getList.FindIndex(x => x.MaCV == nv.MaCV);

            _win.ShowDialog();

            if(_win._ck)
            {
                ThongBaoHT.f_ThongBao(NhanVienList.EditCV(nv.MaNV, ((ChucVu)_win.chucVu.SelectedItem).MaCV), "Đổi chức vụ cho nhân viên " + nv.TenNV);
                return true;
            }
            return false;
        }

        private void chucVu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(chucVu.SelectedIndex != -1)
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
