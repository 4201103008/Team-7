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
using SgCafe.MainPanel.ThuChi;
using InforCf;
using DataCf;
using PrintCf;
using StyleCF;

namespace SgCafe.MainPanel
{
    /// <summary>
    /// Interaction logic for P_PThuChi.xaml
    /// </summary>
    public partial class P_PThuChi : Page
    {
        private static P_PThuChi _page = null;
        public static P_PThuChi getPage
        {
            get
            {
                if(_page == null)
                    _page = new P_PThuChi();
                return _page;
            }
        }

        public P_PThuChi()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dmThu.ItemsSource = PhieuThuChiList.getThu;
            dmChi.ItemsSource = PhieuThuChiList.getChi;
        }

        private void themT_Click(object sender, RoutedEventArgs e)
        {
            W_AddPhieu.f_Tao(false);
            dmThu.ItemsSource = PhieuThuChiList.getThu;
            dmThu.Items.Refresh();
        }

        private void XoaPhieu(decimal so, string me)
        {
            ThongBaoHT.f_ThongBao(PhieuThuChiList.DeleteP(so), me);
        }

        private void xoaT_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult _R = MessageBoxCF.Show("Xác nhận xóa phiếu thu", "Bạn có chắc chắn muốn xóa phiếu thu này không?", MessageBoxImage.Question, MessageBoxButton.YesNo);
            if(_R == MessageBoxResult.Yes)
                XoaPhieu(((PhieuThuChi)dmThu.SelectedItem).SoPhieu, "Xóa phiếu thu");
        }

        private void themC_Click(object sender, RoutedEventArgs e)
        {
            W_AddPhieu.f_Tao(true);
            dmChi.ItemsSource = PhieuThuChiList.getChi;
            dmChi.Items.Refresh();
        }

        private void xoaC_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult _R = MessageBoxCF.Show("Xác nhận xóa phiếu chi", "Bạn có chắc chắn muốn xóa phiếu chi này không?", MessageBoxImage.Question, MessageBoxButton.YesNo);
            if(_R == MessageBoxResult.Yes)
                XoaPhieu(((PhieuThuChi)dmChi.SelectedItem).SoPhieu, "Xóa phiếu thu");
        }

        private void inT_Click(object sender, RoutedEventArgs e)
        {
            Pr_PhieuThuChi.f_In((PhieuThuChi)dmThu.SelectedItem, false);
        }

        private void inC_Click(object sender, RoutedEventArgs e)
        {
            Pr_PhieuThuChi.f_In((PhieuThuChi)dmChi.SelectedItem, true);
        }

        private void dmThu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dmThu.SelectedIndex != -1)
            {
                inT.IsEnabled = true;
                if(((PhieuThuChi)dmThu.SelectedItem).MaNV == informationTk.MaNhanVien)
                    xoaT.IsEnabled = true;
                else
                    xoaT.IsEnabled = false;
            }
            else
            {
                inT.IsEnabled = false;
                xoaT.IsEnabled = false;
            }
        }

        private void dmChi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dmChi.SelectedIndex != -1)
            {
                inC.IsEnabled = true;
                if(((PhieuThuChi)dmChi.SelectedItem).MaNV == informationTk.MaNhanVien)
                    xoaC.IsEnabled = true;
                else
                    xoaC.IsEnabled = false;
            }
            else
            {
                inC.IsEnabled = false;
                xoaC.IsEnabled = false;
            }
        }
    }
}
