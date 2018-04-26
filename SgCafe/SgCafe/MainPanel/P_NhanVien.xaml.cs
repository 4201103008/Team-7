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
using SgCafe.MainPanel.NhanVien;
using System.Globalization;
using InforCf;
using StyleCF;

namespace SgCafe.MainPanel
{
    public class cvTenChucVu : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ChucVuList.getTenCV((int) value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }

    public class cvGioiTinh : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "Nam" : "Nữ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }

    /// <summary>
    /// Interaction logic for P_NhanVien.xaml
    /// </summary>
    public partial class P_NhanVien : Page
    {
        private static P_NhanVien _page = null;
        public static P_NhanVien getPage
        {
            get
            {
                if(_page == null)
                    _page = new P_NhanVien();
                return _page;
            }
        }

        public P_NhanVien()
        {
            InitializeComponent();

            listNV.ItemsSource = NhanVienList.getList;
        }

        private void them_Click(object sender, RoutedEventArgs e)
        {
            W_AddNV.f_AddNV();
            listNV.Items.Refresh();
        }

        private void sua_Click(object sender, RoutedEventArgs e)
        {
            W_EditNV.f_EditNV((DataCf.NhanVien)listNV.SelectedItem);
            listNV.Items.Refresh();
        }

        private void XoaNV(decimal ma)
        {
            ThongBaoHT.f_ThongBao(NhanVienList.DeleteNV(ma), "Xóa nhân viên");
            listNV.Items.Refresh();
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult _R = MessageBoxCF.Show("Xác nhận xóa nhân viên", "Bạn có chắc chắn muốn xóa nhân viên này không?", MessageBoxImage.Question, MessageBoxButton.YesNo);
            if(_R == MessageBoxResult.Yes)
                XoaNV(((DataCf.NhanVien)listNV.SelectedItem).MaNV);
        }

        private void saplich_Click(object sender, RoutedEventArgs e)
        {
            W_SapLich.f_SapLich((DataCf.NhanVien)listNV.SelectedItem);
            listNV.Items.Refresh();
        }

        private void doicv_Click(object sender, RoutedEventArgs e)
        {
            W_DoiCV.f_DoiCV((DataCf.NhanVien)listNV.SelectedItem);
            listNV.Items.Refresh();
        }

        private void listNV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listNV.SelectedIndex != -1)
            {
                sua.IsEnabled = xoa.IsEnabled = saplich.IsEnabled = doicv.IsEnabled = true;
            }
            else
            {
                sua.IsEnabled = xoa.IsEnabled = saplich.IsEnabled = doicv.IsEnabled = false;
            }
        }
    }
}
