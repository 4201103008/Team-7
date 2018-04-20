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
using SgCafe.MainPanel.NhapHang;
using InforCf;
using StyleCF;
using PrintCf;
using DataCf;
using System.Globalization;

namespace SgCafe.MainPanel
{
    public class cvTrangThai2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(((bool)value) == true)
                return "Đã thanh toán";
            else
                return "Chưa thanh toán";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }
    public class cvNhaCC : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return NhaCCList.getName((decimal)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }
    /// <summary>
    /// Interaction logic for P_PhieuNhap.xaml
    /// </summary>
    public partial class P_PhieuNhap : Page
    {
        private static P_PhieuNhap _page = null;
        public static P_PhieuNhap getPage
        {
            get
            {
                if(_page == null)
                    _page = new P_PhieuNhap();
                return _page;
            }
        }

        public P_PhieuNhap()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dmPN.ItemsSource = PhieuNhapList.getList;
            //TuNgay.SelectedDate = DateTime.Now.AddDays(1-DateTime.Now.Day);
            //DenNgay.SelectedDate = DateTime.Now;
        }

        private void them_Click(object sender, RoutedEventArgs e)
        {
            W_AddPNhap.f_LapPhieu();
            dmPN.Items.Refresh();
        }

        private void sua_Click(object sender, RoutedEventArgs e)
        {
            W_EditPNhap.f_SuaPhieu((DataCf.PhieuNhap)dmPN.SelectedItem);
            dmPN.Items.Refresh();
        }

        private void Xoa(decimal so)
        {
            ThongBaoHT.f_ThongBao(PhieuNhapList.DeleteP(so), "Xóa phiếu nhập");
            dmPN.Items.Refresh();
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult _R = MessageBoxCF.Show("Xác nhận xóa phiếu nhập", "Bạn có chắc chắn muốn xóa phiếu nhập này không?", MessageBoxImage.Question, MessageBoxButton.YesNo);
            if(_R == MessageBoxResult.Yes)
                Xoa(((DataCf.PhieuNhap)dmPN.SelectedItem).SoPhieu);
        }

        private void dmPN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dmPN.SelectedIndex != -1)
            {
                if(((DataCf.PhieuNhap)dmPN.SelectedItem).TrangThai == false)
                {
                    inP.IsEnabled = false;
                    if(((DataCf.PhieuNhap)dmPN.SelectedItem).MaNV == informationTk.MaNhanVien)
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
                else
                {
                    sua.IsEnabled = false;
                    xoa.IsEnabled = false;
                    inP.IsEnabled = true;
                }
            }
            else
            {
                sua.IsEnabled = false;
                xoa.IsEnabled = false;
                inP.IsEnabled = false;
            }
        }

        private void inP_Click(object sender, RoutedEventArgs e)
        {
            PhieuNhap p = (DataCf.PhieuNhap)dmPN.SelectedItem;
            Pr_PhieuNhap.f_In(p, MatHangList.LoadofNhap(p.SoPhieu, p.MaNCC));
        }
    }
}
