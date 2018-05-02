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
using SgCafe.MainPanel.BanHang;
using InforCf;
using DataCf;
using System.Globalization;
using System.ComponentModel;
using System.Windows.Threading;
using StyleCF;

namespace SgCafe.MainPanel
{
    public class cvMuCPThem : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)((HoaDon)values[0] != null) && ((int)values[1] != -1);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class cvctThanhToan : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values[0] != null)
            {
                string a = values[1] as string;
                if(a.Length > 0)
                    return (bool)(decimal.Parse(a) > 0);
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class cvsGiamGia: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string a = values[0] as string;
            string b = values[1] as string;
            decimal s = 0;
            if(a.Length > 0)
                s += decimal.Parse(a);
            if(b.Length > 0)
                s *= decimal.Parse(b) / 100;
            else
                s = 0;
            return string.Format("{0:0.00}", s);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class cvsThue : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string a = values[0] as string;
            string b = values[1] as string;
            string c = values[2] as string;
            decimal s = 0;
            if(a.Length > 0)
                s += decimal.Parse(a);
            if(b.Length > 0)
                s -= decimal.Parse(b);
            if(c.Length > 0)
                s *= decimal.Parse(c) / 100;
            else
                s = 0;
            return string.Format("{0:0.00}", s);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class cvTimeM : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values[0] != null)
                return (TimeSpan)values[1];
            else
                return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class Ticker : INotifyPropertyChanged
    {
        public Ticker()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, object e)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Now"));
        }

        public TimeSpan Now
        {
            get
            {
                return DateTime.Now.TimeOfDay;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class cvListMH : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return MatHanginHoaDon.getList((decimal)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }

    public class cvTime : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null)
                return DateTime.Now.TimeOfDay;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }

    public class cvBatC : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)((HoaDon)value != null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }
    
    public class cvGiXo : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)((int)value != -1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }
    /// <summary>
    /// Interaction logic for P_BanHang.xaml
    /// </summary>
    public partial class P_BanHang : Page
    {
        private static P_BanHang _page = null;

        public P_BanHang()
        {
            InitializeComponent();

            listMatHang.ItemsSource = MatHangList.getListSP;
            listban.ItemsSource = BanList.getList;
            listFHD.ItemsSource = HoaDonList.getFNow;
        }

        public static P_BanHang getPage
        {
            get
            {
                if(_page == null)
                    _page = new P_BanHang();
                return _page;
            }
        }

        private void buttonChuyen_Click(object sender, RoutedEventArgs e)
        {
            W_Chuyen.f_Chuyen(((Ban)listban.SelectedItem).TenBan);
            checkBan();
        }

        private void buttonGop_Click(object sender, RoutedEventArgs e)
        {
            W_Gop.f_Gop(((Ban)listban.SelectedItem).TenBan);
            checkBan();
        }

        private void thanhToan_Click(object sender, RoutedEventArgs e)
        {
            W_ThanhToan.f_ThanhToan(BanList.checkHD(((Ban)listban.SelectedItem).TenBan));
            checkBan();
            listFHD.ItemsSource = HoaDonList.getFNow;
        }

        private void HuyHDCT(decimal so)
        {
            ThongBaoHT.f_ThongBao(HoaDonList.HuyHD(so), "Hủy hóa đơn");
            checkBan();
        }

        private void HuyHD_Click(object sender, RoutedEventArgs e)
        {
            if(listban.SelectedIndex != -1 && ((Ban)listban.SelectedItem).SoHD != null)
            {
                MessageBoxResult _R = MessageBoxCF.Show("Xác nhận hủy hóa đơn", "Bạn có chắc chắn muốn xóa hủy hóa đơn này không?", MessageBoxImage.Question, MessageBoxButton.YesNo);
                if(_R == MessageBoxResult.Yes)
                    HuyHDCT(((Ban)listban.SelectedItem).SoHD ?? 0);
            }
        }

        private void Text_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            LBMN.isMuberic(e);
        }

        private void listban_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            checkBan();
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            switch (locBan.SelectedIndex)
            {
                case 1:
                    listban.ItemsSource = BanList.getBanTrong;
                    break;
                case 2:
                    listban.ItemsSource = BanList.getBanDD;
                    break;
                default:
                    listban.ItemsSource = BanList.getList;
                    break;
            }

            listban.Items.Refresh();
        }

        private void TimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            if(TimKiem.Text.Length == 0)
            {
                listMatHang.ItemsSource = MatHangList.getListSP;
            }
            else
            {
                listMatHang.ItemsSource = from p in MatHangList.getListSP
                                          where p.TenHang.ToLower().Contains(TimKiem.Text.ToLower())
                                          select p;
            }
        }

        private void TimKiem_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(TimKiem.Text == "Tìm kiếm")
                TimKiem.Text = string.Empty;
        }

        private void TimKiem_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(TimKiem.Text.Length == 0)
                TimKiem.Text = "Tìm kiếm";
        }

        private void checkBan()
        {
            if(listban.SelectedIndex != -1)
            {
                if(((Ban)listban.SelectedItem).SoHD != null)
                    grHoaDon.DataContext = HoaDonList.getHD(((Ban)listban.SelectedItem).SoHD ?? 0);
                else
                    grHoaDon.DataContext = null;
            }
        }

        private void OpenBan(string tenb)
        {
            HoaDon hd = HoaDonList.AddHD(tenb);
            if(hd != null)
            {
                grHoaDon.DataContext = hd;
            }
        }

        private void BanItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(((Ban)listban.SelectedItem).SoHD == null)
            {
                OpenBan(((Ban)listban.SelectedItem).TenBan);
            }
        }

        private void moBan_Click(object sender, RoutedEventArgs e)
        {
            OpenBan(((Ban)listban.SelectedItem).TenBan);
        }

        private void buttonThem_Click(object sender, RoutedEventArgs e)
        {
            HoaDonList.AddMH(((Ban)listban.SelectedItem).SoHD ?? 0, ((DataCf.MatHang)listMatHang.SelectedItem).MaHang, int.Parse(comboBSoLuong.Text));
            listMHinHD.Items.Refresh();
        }

        private void buttonGiam_Click(object sender, RoutedEventArgs e)
        {
            HoaDonList.GiamMH(((Ban)listban.SelectedItem).SoHD ?? 0, ((vw_BanHang)listMHinHD.SelectedItem).MaHang, int.Parse(comboBSoLuong.Text));
            listMHinHD.Items.Refresh();
        }

        private void buttonXoa_Click(object sender, RoutedEventArgs e)
        {
            HoaDonList.XoaMH(((Ban)listban.SelectedItem).SoHD ?? 0, ((vw_BanHang)listMHinHD.SelectedItem).MaHang);
            listMHinHD.Items.Refresh();
        }

        private void giamGia_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(giamGia.Text.Length > 0 && int.Parse(giamGia.Text) == 0)
                giamGia.Text = string.Empty;
        }

        private void giamGia_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(giamGia.Text.Length == 0)
                giamGia.Text = "0";
            if(listban.SelectedIndex != -1 && ((Ban)listban.SelectedItem).SoHD != null)
            {
                HoaDonList.EditGG(((Ban)listban.SelectedItem).SoHD ?? 0, byte.Parse(giamGia.Text));
            }
        }

        private void listban_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if(listban.SelectedIndex != -1)
            {
                if(((Ban)listban.SelectedItem).SoHD == null)
                {
                    moBan.IsEnabled = true;
                    gopBan.IsEnabled = chuyenBan.IsEnabled = dongBan.IsEnabled = false;
                }
                else
                {
                    moBan.IsEnabled = false;
                    gopBan.IsEnabled = chuyenBan.IsEnabled = true;
                    dongBan.IsEnabled = thanhToan.IsEnabled;
                }
            }
            else
            {
                moBan.IsEnabled = dongBan.IsEnabled = gopBan.IsEnabled = chuyenBan.IsEnabled = false;
            }
        }
    }
}