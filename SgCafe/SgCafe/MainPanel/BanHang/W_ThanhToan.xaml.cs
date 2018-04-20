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
using PrintCf;
using InforCf;
using DataCf;
using System.Globalization;

namespace SgCafe.MainPanel.BanHang
{
    public class cvTinhTien : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string a = values[0] as string;
            string b = values[1] as string;
            decimal so = 0;
            if(a.Length > 0)
                so -= decimal.Parse(a);
            if(b.Length > 0)
                so += decimal.Parse(b);
            return string.Format("{0:0.00}", so);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class cvisEbleCS : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string a = value as string;
            if(a.Length > 0)
                return (bool)(decimal.Parse(a) >= 0);
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }
    /// <summary>
    /// Interaction logic for W_ThanhToan.xaml
    /// </summary>
    public partial class W_ThanhToan : Window
    {
        private byte _ck = 0;
        public W_ThanhToan()
        {
            InitializeComponent();
        }

        public static bool f_ThanhToan(DataCf.HoaDon hd)
        {
            W_ThanhToan _win = new W_ThanhToan();

            _win.tong.Text = string.Format("{0:0.00}", hd.TongTien);
            _win.ban.Text = hd.TenBan;

            _win.ShowDialog();

            if(_win._ck == 1)
            {
                ThongBaoHT.f_ThongBao(HoaDonList.ThanhToan(hd.SoHD), "Thanh toán");
            }
            else if(_win._ck == 2)
            {
                if(HoaDonList.ThanhToan(hd.SoHD))
                {
                    Pr_HoaDon.f_In(hd, decimal.Parse(_win.khachdua.Text), decimal.Parse(_win.tra.Text));
                }
            }

            return false;
        }

        private void khachdua_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            LBMN.isMuberic(e);
        }

        private void khachdua_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(khachdua.Text.Length > 0 && decimal.Parse(khachdua.Text) == 0)
                khachdua.Text = string.Empty;
        }

        private void khachdua_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(khachdua.Text.Length == 0)
                khachdua.Text = "0.00";
        }

        private void BtIn_Click(object sender, RoutedEventArgs e)
        {
            _ck = 2;
            Close();
        }

        private void BtOK_Click(object sender, RoutedEventArgs e)
        {
            _ck = 1;

            Close();
        }

        private void BtHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}