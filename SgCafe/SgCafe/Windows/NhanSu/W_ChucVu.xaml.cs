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
using SgCafe.Windows.NhanSu;
using InforCf;
using DataCf;
using StyleCF;
using System.Globalization;

namespace SgCafe.Windows.NhanSu
{
    public class qlNhanSu : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Ktbit.kiemTra((byte)value, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }

    public class qlCaCV : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Ktbit.kiemTra((byte)value, 1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }

    public class qlBan : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Ktbit.kiemTra((byte)value, 2);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }

    public class qlHang : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Ktbit.kiemTra((byte)value, 3);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }

    public class qlthuChi : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Ktbit.kiemTra((byte)value, 4);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }

    public class qlXuat : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Ktbit.kiemTra((byte)value, 5);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }

    public class qlNhap : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Ktbit.kiemTra((byte)value, 6);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }

    /// <summary>
    /// Interaction logic for ChucVu.xaml
    /// </summary>
    public partial class W_ChucVu : Window
    {
        public W_ChucVu()
        {
            InitializeComponent();
        }

        public static void f_ChucVu()
        {
            W_ChucVu _win = new W_ChucVu();
            _win.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listCV.ItemsSource = ChucVuList.getList;
        }

        private void them_Click(object sender, RoutedEventArgs e)
        {
            Wp_ThemCV.f_ThemCV();
            listCV.Items.Refresh();
        }

        private void sua_Click(object sender, RoutedEventArgs e)
        {
            Wp_SuaCV.f_SuaCV((ChucVu)listCV.SelectedItem);
            listCV.Items.Refresh();
        }

        private void XoaCV(int maC)
        {
            ThongBaoHT.f_ThongBao(ChucVuList.DeleteCV(maC), "Xóa chức vụ");

            listCV.Items.Refresh();
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            int ma = ((ChucVu)listCV.SelectedItem).MaCV;
            int so = ChucVuModel.CheckNVC(ma);
            if(so > 0)
            {
                MessageBoxCF.Show("Không thể xóa", "Có " + so + " nhân viên đang giữ chức vụ này!\nHãy xóa hoặc đổi chức vụ cho những nhân viên này trước rồi quay lại đây để xóa nó.", MessageBoxImage.Warning, MessageBoxButton.OK);
            }
            else
            {
                MessageBoxResult _R = MessageBoxCF.Show("Xác nhận xóa chức vụ", "Bạn có chắc chắn muốn xóa chức vụ này không?", MessageBoxImage.Question, MessageBoxButton.YesNo);
                if(_R == MessageBoxResult.Yes)
                    XoaCV(ma);
            }
        }

        private void listCV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listCV.SelectedIndex != -1)
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
