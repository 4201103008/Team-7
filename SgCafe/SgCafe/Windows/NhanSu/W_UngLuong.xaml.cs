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
    /// Interaction logic for UngLuong.xaml
    /// </summary>
    public partial class W_UngLuong : Window
    {
        public bool _ck = false;

        private byte _cs = 3;

        public W_UngLuong()
        {
            InitializeComponent();
        }

        public static bool f_UngLuong()
        {
            W_UngLuong _win = new W_UngLuong();
            ChamCongList.AutoBC();
            _win.ShowDialog();

            if(_win._ck)
            {
                return ThongBaoHT.f_ThongBao(TruLuongModel.ThemLuong(((NhanVien)_win.nhanVien.SelectedItem).MaNV, decimal.Parse(_win.soTien.Text), "Ứng lương"), "Ứng lương");
            }
            return false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            nhanVien.ItemsSource = NhanVienList.getnotAD;
        }

        private void checkBt()
        {
            if(_cs == 0)
                BtOK.IsEnabled = true;
            else
                BtOK.IsEnabled = false;
        }

        private void nhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(nhanVien.SelectedIndex != -1)
                Ktbit.ganTR(ref _cs, 0, false);
            else
                Ktbit.ganTR(ref _cs, 0, true);
            checkBt();
        }

        private void soTien_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            LBMN.isMuberic(e);
        }

        private void soTien_KeyUp(object sender, KeyEventArgs e)
        {
            if(soTien.Text.Length > 0 && decimal.Parse(soTien.Text) > 0)
                Ktbit.ganTR(ref _cs, 1, false);
            else
                Ktbit.ganTR(ref _cs, 1, true);
            checkBt();
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

        private void soTien_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(soTien.Text.Length > 0 && decimal.Parse(soTien.Text) == 0)
                soTien.Text = string.Empty;
        }

        private void soTien_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(soTien.Text.Length == 0)
                soTien.Text = "0.00";
        }
    }
}
