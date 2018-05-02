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
using SgCafe.MainPanel.NhaCC;
using InforCf;
using DataCf;
using StyleCF;

namespace SgCafe.MainPanel
{
    /// <summary>
    /// Interaction logic for P_NhaCC.xaml
    /// </summary>
    public partial class P_NhaCC : Page
    {
        private static P_NhaCC _page = null;

        public P_NhaCC()
        {
            InitializeComponent();

            listNCC.ItemsSource = NhaCCList.getList;
        }

        public static P_NhaCC getPage
        {
            get
            {
                if (_page == null)
                    _page = new P_NhaCC();
                
                return _page;
            }
        }

        private void themMoi_Click(object sender, RoutedEventArgs e)
        {
            W_AddNCC.f_ThemNCC();
            listNCC.Items.Refresh();
        }

        private void chinhSua_Click(object sender, RoutedEventArgs e)
        {
            if(NhaCCModel.CheckPNCCC(((DataCf.NhaCC)listNCC.SelectedItem).MaNCC))
            {
                if(informationQ._thongBao)
                    MessageBoxCF.Show("Thông báo", "Nhà cung cấp này có liên quan đến một số phiếu nhập chưa thanh toán, nên chức năng xóa hàng sẽ bị khóa!", MessageBoxImage.Information, MessageBoxButton.OK);
                if(W_EditNCC.f_SuaNCC((DataCf.NhaCC)listNCC.SelectedItem, true, (List<vw_CungCap>)listCungCap.ItemsSource))
                    checkNCC();
            }
            else
            {
                if(W_EditNCC.f_SuaNCC((DataCf.NhaCC)listNCC.SelectedItem, false, (List<vw_CungCap>)listCungCap.ItemsSource))
                    checkNCC();
            }
            listNCC.Items.Refresh();
        }

        private void XoaNCC(decimal ma)
        {
            ThongBaoHT.f_ThongBao(NhaCCList.DeleteNCC(ma), "Xóa nhà cung cấp");
            listNCC.Items.Refresh();
            checkNCC();
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            if(NhaCCModel.CheckPNCCC(((DataCf.NhaCC)listNCC.SelectedItem).MaNCC))
            {
                MessageBoxResult _R = MessageBoxCF.Show("Chặn", "Nhà cung cấp này có liên quan đến phiếu nhập chưa thanh toán!", MessageBoxImage.Stop, MessageBoxButton.OK);
            }
            else
            {
                MessageBoxResult _R = MessageBoxCF.Show("Xác nhận xóa nhà cung cấp", "Bạn có chắc chắn muốn xóa nhà cung cấp này không?", MessageBoxImage.Question, MessageBoxButton.YesNo);
                if(_R == MessageBoxResult.Yes)
                    XoaNCC(((DataCf.NhaCC)listNCC.SelectedItem).MaNCC);
            }
        }

        private void checkNCC()
        {
            if (listNCC.SelectedIndex != -1)
            {
                xoa.IsEnabled = true;
                sua.IsEnabled = true;
                listCungCap.ItemsSource = NhaCCModel.LoadCC(((DataCf.NhaCC)listNCC.SelectedItem).MaNCC);
            }
            else
            {
                xoa.IsEnabled = false;
                sua.IsEnabled = false;
                listCungCap.ItemsSource = null;
            }

            listCungCap.Items.Refresh();
        }

        private void listNCC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            checkNCC();
        }
    }
}
