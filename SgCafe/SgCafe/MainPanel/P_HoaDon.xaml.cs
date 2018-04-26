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
using System.Globalization;
using InforCf;
using DataCf;

namespace SgCafe.MainPanel
{
    public class cvTimeM2 : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values[0] != null)
                return LBMN.onlyTime((TimeSpan)values[0]);
            TimeSpan t = (TimeSpan)values[1];
            return string.Format("{0:00}:{1:00}:{2:00}", t.Hours, t.Minutes, t.Seconds);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class cvNhanVien : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return NhanVienModel.getNameNv((decimal)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }

    public class cvGio : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
                return "_ _:_ _:_ _";
            return LBMN.onlyTime((TimeSpan)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }

    public class cvTrangThai : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(((byte)value) == 1)
                return "Đã thanh toán";
            else
                return "Chưa thanh toán";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }
    /// <summary>
    /// Interaction logic for P_HoaDon.xaml
    /// </summary>
    public partial class P_HoaDon : Page
    {
        private static P_HoaDon _page = null;
        public static P_HoaDon getPage
        {
            get
            {
                if(_page == null)
                    _page = new P_HoaDon();
                return _page;
            }
        }

        public P_HoaDon()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listHoaDon.ItemsSource = HoaDonList.getList;
        }
    }
}
