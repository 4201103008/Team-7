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
using SgCafe.MainPanel.MatHang;
using InforCf;
using DataCf;
using StyleCF;
using System.Globalization;

namespace SgCafe.MainPanel
{
    public class LoaiMHcv : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int c = (int)value;
            switch(c)
            {
                case -1:
                    return "Nguyên liệu";
                case 1:
                    return "Sản phẩm";
                default:
                    return "Cả hai";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }
    /// <summary>
    /// Interaction logic for P_MatHang.xaml
    /// </summary>
    public partial class P_MatHang : Page
    {
        private static bool _bk;
        private static P_MatHang _page = null;

        public P_MatHang()
        {
            InitializeComponent();
        }

        public static P_MatHang getPage(int st)
        {
            if(_page == null)
            {
                _page = new P_MatHang();
            }
            _bk = false;
            switch(st)
            {
                case 0:
                    _page.Load_ListNL();
                    break;
                case 1:
                    _page.Load_ListSP();
                    break;
                default:
                    _page.Load_ListAll();
                    break;
            }
            _page.comboLoai.SelectedIndex = st;
            _bk = true;
            return _page;
        }

        private void Load_ListAll()
        {
            listMatHang.ItemsSource = MatHangList.getList;
        }

        private void Load_ListNL()
        {
            listMatHang.ItemsSource = from p in MatHangList.getList
                                      where p.Loai <= 0
                                      select p;
        }

        private void Load_ListSP()
        {
            listMatHang.ItemsSource = from p in MatHangList.getList
                                      where p.Loai >= 0
                                      select p;
        }


        private void comboLoai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(_bk)
            {
                switch (comboLoai.SelectedIndex)
                {
                    case 0:
                        Load_ListNL();
                        break;
                    case 1:
                        Load_ListSP();
                        break;
                    default:
                        Load_ListAll();
                        break;
                }
                listMatHang.Items.Refresh();
            }
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            listMatHang.Items.Refresh();
        }

        private void themMoi_Click(object sender, RoutedEventArgs e)
        {
            W_AddMH.f_ThemMH();
            listMatHang.Items.Refresh();
        }

        private void chinhSua_Click(object sender, RoutedEventArgs e)
        {
            bool n = MatHangModel.CheckPNCTT(((DataCf.MatHang)listMatHang.SelectedItem).MaHang);
            bool s = MatHangModel.CheckHDCTT(((DataCf.MatHang)listMatHang.SelectedItem).MaHang);
            if(n || s)
            {
                string st1 = string.Empty;
                string st2 = string.Empty;
                int k = 0;
                if(n)
                {
                    st1 += "phiếu nhập";
                    st2 += "nguyên liệu";
                    k--;
                }
                if(s)
                {
                    if(n)
                    {
                        st1 = st1 + " và ";
                        st2 = st2 + " và ";
                    }
                    st1 += "hóa đơn";
                    st2 += "sản phẩm";
                    k++;
                }
                if(informationQ._thongBao)
                    MessageBoxCF.Show("Thông báo", "Mặt hàng này có liên quan đến một số " + st1 + " chưa thanh toán, nên các chức năng sửa đổi liên quan đến " + st2 + " sẽ bị khóa!", MessageBoxImage.Information, MessageBoxButton.OK);
                if(W_EditMH.f_SuaKhoa((DataCf.MatHang)listMatHang.SelectedItem, k, (List<vw_CungCap>)listCungCap.ItemsSource))
                    checkCCMH();
            }
            else
            {
                if(W_EditMH.f_SuaMH((DataCf.MatHang)listMatHang.SelectedItem, (List<vw_CungCap>)listCungCap.ItemsSource))
                    checkCCMH();
            }
            listMatHang.Items.Refresh();
        }

        private void XoaMH(decimal ma)
        {
            ThongBaoHT.f_ThongBao(MatHangList.DeleteMH(ma), "Xóa mặt hàng");
            listMatHang.Items.Refresh();
            checkCCMH();
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            if(MatHangModel.CheckPNCTT(((DataCf.MatHang)listMatHang.SelectedItem).MaHang) || MatHangModel.CheckHDCTT(((DataCf.MatHang)listMatHang.SelectedItem).MaHang))
            {
                MessageBoxResult _R = MessageBoxCF.Show("Chặn", "Mặt hàng này có liên quan đến hóa đơn hoặc phiếu nhập chưa thanh toán!", MessageBoxImage.Stop, MessageBoxButton.OK);
            }
            else
            {
                MessageBoxResult _R = MessageBoxCF.Show("Xác nhận xóa mặt hàng", "Bạn có chắc chắn muốn xóa mặt hàng này không?", MessageBoxImage.Question, MessageBoxButton.YesNo);
                if(_R == MessageBoxResult.Yes)
                    XoaMH(((DataCf.MatHang)listMatHang.SelectedItem).MaHang);
            }
        }

        private void checkCCMH()
        {
            if (listMatHang.SelectedIndex == -1)
            {
                xoa.IsEnabled = false;
                sua.IsEnabled = false;
                listCungCap.ItemsSource = null;
            }
            else
            {
                xoa.IsEnabled = true;
                sua.IsEnabled = true;
                listCungCap.ItemsSource = MatHangModel.LoadCC(((DataCf.MatHang)listMatHang.SelectedItem).MaHang);
            }

            listCungCap.Items.Refresh();
        }
        
        private void listMatHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            checkCCMH();
        }
    }
}
