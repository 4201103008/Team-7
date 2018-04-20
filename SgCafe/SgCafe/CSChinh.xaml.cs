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
using StyleCF;
using SgCafe.Windows;
using SgCafe.MainPanel.ThuChi;
using SgCafe.MainPanel.NhapHang;
using SgCafe.Windows.HeThong;
using SgCafe.Windows.HoatDong;
using SgCafe.Windows.NhanSu;
using SgCafe.Windows.TroGiup;
using InforCf;
using SgCafe.MainPanel;
using StyleCF.Control;
using System.Windows.Resources;
using DataCf;

namespace SgCafe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CSChinh : Window
    {
        //private bool cl = true;
        private int[] _index = new int[13];
        private int _count = 0;
        
        public CSChinh()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (informationTk.dDangNhap == true)
            {
                MessageBoxResult _R = MessageBoxCF.Show("Thoát", "Bạn có chắc chắn muốn thoát không?", MessageBoxImage.Question, MessageBoxButton.YesNo);
                if (_R == MessageBoxResult.No)
                    e.Cancel = true;
            }
        }
        
        private void btbanHang()
        {
            frame.NavigationService.Navigate(P_BanHang.getPage);
        }

        private void btbaoCao()
        {
            frame.NavigationService.Navigate(P_BaoCao.getPage);
        }

        private void btchamCong()
        {
            frame.NavigationService.Navigate(P_ChamCong.getPage);
        }

        private void btHoaDon()
        {
            frame.NavigationService.Navigate(P_HoaDon.getPage);
        }

        private void btmatHang(int st)
        {
            frame.NavigationService.Navigate(P_MatHang.getPage(st));
        }

        private void btnhaCC()
        {
            frame.NavigationService.Navigate(P_NhaCC.getPage);
        }

        private void btnhanVien()
        {
            frame.NavigationService.Navigate(P_NhanVien.getPage);
        }

        private void btphieuNhap()
        {
            frame.NavigationService.Navigate(P_PhieuNhap.getPage);
        }

        private void btpThuChi()
        {
            frame.NavigationService.Navigate(P_PThuChi.getPage);
        }

        private void bttaiKhoan()
        {
            frame.NavigationService.Navigate(P_TaiKhoan.getPage);
        }

        private void btthongKe(int i)
        {
            frame.NavigationService.Navigate(P_ThongKe.getPage(i));
        }

        private void bttinhLuong()
        {
            frame.NavigationService.Navigate(P_TinhLuong.getPage);
        }


        private void BanHang_Selected(object sender, RoutedEventArgs e)
        {
            btbanHang();
        }

        private void HoaDon_Selected(object sender, RoutedEventArgs e)
        {
            btHoaDon();
        }

        private void PhieuNhap_Selected(object sender, RoutedEventArgs e)
        {
            btphieuNhap();
        }

        private void ChamCong_Selected(object sender, RoutedEventArgs e)
        {
            btchamCong();
        }

        private void ThongKe_Selected(object sender, RoutedEventArgs e)
        {
            btthongKe(-1);
        }

        private void mnnguyenlieu_Click(object sender, RoutedEventArgs e)
        {
            MenuNhanh.SelectedIndex = _index[11];
            btmatHang(0);
        }

        private void mnsanpham_Click(object sender, RoutedEventArgs e)
        {
            MenuNhanh.SelectedIndex = _index[11];
            btmatHang(1);
        }

        private void mnncahai_Click(object sender, RoutedEventArgs e)
        {
            MenuNhanh.SelectedIndex = _index[11];
            btmatHang(2);
        }

        private void MatHang_Selected(object sender, RoutedEventArgs e)
        {
            btmatHang(2);
        }

        private void NhaCungCap_Selected(object sender, RoutedEventArgs e)
        {
            btnhaCC();
        }

        private void ThuChi_Selected(object sender, RoutedEventArgs e)
        {
            btpThuChi();
        }

        private void TinhLuong_Selected(object sender, RoutedEventArgs e)
        {
            bttinhLuong();
        }

        private void UngLuong_Selected(object sender, RoutedEventArgs e)
        {
            W_UngLuong.f_UngLuong();
        }

        private void TruLuong_Selected(object sender, RoutedEventArgs e)
        {
            W_TruLuong.f_TruLuong();
        }

        private void NhanVien_Selected(object sender, RoutedEventArgs e)
        {
            btnhanVien();
        }

        private void TaiKhoan_Selected(object sender, RoutedEventArgs e)
        {
            bttaiKhoan();
        }

        private List<ListBoxItem> getlistmn()
        {
            List<ListBoxItem> _k = new List<ListBoxItem>();
            ListBoxItem _it;

            if (!informationTk.qlBan)
            {
                mndsban.IsEnabled = false;
            }

            if (informationTk.qlBanHang)
            {
                _it = new ListBoxItem();
                _it.Name = "BanHang";
                _it.Content = "Bán Hàng";
                _it.Background = LBMN.getBru(@"/SgCafe;component/Icon/menuntg/BanHang.png");
                _it.Selected += new RoutedEventHandler(BanHang_Selected);
                _k.Add(_it);
                _index[0] = _count++;

                _it = new ListBoxItem();
                _it.Name = "HoaDon";
                _it.Content = "Hóa Đơn";
                _it.Background = LBMN.getBru(@"/SgCafe;component/Icon/menuntg/HoaDon.png");
                _it.Selected += new RoutedEventHandler(HoaDon_Selected);
                _k.Add(_it);
                _index[1] = _count++;
            }
            else
            {
                mnbanhang.IsEnabled = false;
                mnhoadon.IsEnabled = false;
            }

            if (informationTk.qlNhapHang)
            {
                _it = new ListBoxItem();
                _it.Name = "PhieuNhap";
                _it.Content = "Phiếu Nhập";
                _it.Background = LBMN.getBru(@"/SgCafe;component/Icon/menuntg/NhapHang.jpg");
                _it.Selected += new RoutedEventHandler(PhieuNhap_Selected);
                _k.Add(_it);
                _index[2] = _count++;
            }
            else
            {
                mnphieunhap.IsEnabled = false;
                mnnhaphang.IsEnabled = false;
            }

            if (informationTk.qlThuChi)
            {
                _it = new ListBoxItem();
                _it.Name = "ThuChi";
                _it.Content = "Thu Chi";
                _it.Background = LBMN.getBru(@"/SgCafe;component/Icon/menuntg/ThuChi.png");
                _it.Selected += new RoutedEventHandler(ThuChi_Selected);
                _k.Add(_it);
                _index[3] = _count++;
            }
            else
            {
                mnphieuthuchi.IsEnabled = false;
            }

            if (informationTk.qlNhanSu)
            {
                _it = new ListBoxItem();
                _it.Name = "ChamCong";
                _it.Content = "Chấm Công";
                _it.Background = LBMN.getBru(@"/SgCafe;component/Icon/menuntg/ChamCong.png");
                _it.Selected += new RoutedEventHandler(ChamCong_Selected);
                _k.Add(_it);
                _index[4] = _count++;

                _it = new ListBoxItem();
                _it.Name = "TinhLuong";
                _it.Content = "Tính Lương";
                _it.Background = LBMN.getBru(@"/SgCafe;component/Icon/menuntg/TinhLuong.jpg");
                _it.Selected += new RoutedEventHandler(TinhLuong_Selected);
                _k.Add(_it);
                _index[5] = _count++;

                _it = new ListBoxItem();
                _it.Name = "UngLuong";
                _it.Content = "Ứng Lương";
                _it.Background = LBMN.getBru(@"/SgCafe;component/Icon/menuntg/UngLuong.png");
                _it.Selected += new RoutedEventHandler(UngLuong_Selected);
                _k.Add(_it);
                _index[6] = _count++;

                _it = new ListBoxItem();
                _it.Name = "TruLuong";
                _it.Content = "Trừ Lương";
                _it.Background = LBMN.getBru(@"/SgCafe;component/Icon/menuntg/TruLuong.png");
                _it.Selected += new RoutedEventHandler(TruLuong_Selected);
                _k.Add(_it);
                _index[7] = _count++;

                _it = new ListBoxItem();
                _it.Name = "NhanVien";
                _it.Content = "Nhân Viên";
                _it.Background = LBMN.getBru(@"/SgCafe;component/Icon/menuntg/NhanVien.jpg");
                _it.Selected += new RoutedEventHandler(NhanVien_Selected);
                _k.Add(_it);
                _index[8] = _count++;
            }
            else
            {
                mnnhansu.IsEnabled = false;
            }

            if (informationTk.isAd)
            {
                _it = new ListBoxItem();
                _it.Name = "ThongKe";
                _it.Content = "Thông Kê";
                _it.Background = LBMN.getBru(@"/SgCafe;component/Icon/menuntg/ThongKe.png");
                _it.Selected += new RoutedEventHandler(ThongKe_Selected);
                _k.Add(_it);
                _index[9] = _count++;

                _it = new ListBoxItem();
                _it.Name = "TaiKhoan";
                _it.Content = "Tài Khoản";
                _it.Background = LBMN.getBru(@"/SgCafe;component/Icon/menuntg/TaiKhoan.png");
                _it.Selected += new RoutedEventHandler(TaiKhoan_Selected);
                _k.Add(_it);
                _index[10] = _count++;

                mnsendbc.IsEnabled = false;
            }
            else
            {
                mnquantri.IsEnabled = false;
                mncaidat.IsEnabled = false;
                mncalam.IsEnabled = false;
                mnchucvu.IsEnabled = false;
            }

            if (informationTk.qlMatHangNhaCC)
            {
                _it = new ListBoxItem();
                _it.Name = "MatHang";
                _it.Content = "Mặt Hàng";
                _it.Background = LBMN.getBru(@"/SgCafe;component/Icon/menuntg/MatHang.png");
                _it.Selected += new RoutedEventHandler(MatHang_Selected);
                _k.Add(_it);
                _index[11] = _count++;

                _it = new ListBoxItem();
                _it.Name = "NhaCC";
                _it.Content = "Nhà Cung Cấp";
                _it.Background = LBMN.getBru(@"/SgCafe;component/Icon/menuntg/NhaCC.png");
                _it.Selected += new RoutedEventHandler(NhaCungCap_Selected);
                _k.Add(_it);
                _index[12] = _count++;
            }
            else
            {
                mnkhohang.IsEnabled = false;
            }

            if(!informationTk.qlBan && !informationTk.qlThuChi && !informationTk.qlNhapHang && !informationTk.qlBanHang)
                hoatdong.IsEnabled = false;

            return _k;
        }

        

        private void mnthoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DangXuat()
        {
            informationTk.dangxuattk();
            App._win = new DangNhap();
            App._win.Show();
            this.Close();
        }

        private void mndangxuat_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult _R = MessageBoxCF.Show("Đăng Xuất", "Bạn có chắc chắn muốn đăng xuất không?", MessageBoxImage.Question, MessageBoxButton.YesNo);
            if (_R == MessageBoxResult.Yes)
                DangXuat();
        }

        private void mncaidat_Click(object sender, RoutedEventArgs e)
        {
            W_CaiDat.f_CaiDat();
            loadTitle();
        }

        private void mnsendbc_Click(object sender, RoutedEventArgs e)
        {
            W_GuiBaoCao.f_SendBC();
        }

        private void mndoimk_Click(object sender, RoutedEventArgs e)
        {
            if(W_DoiMatKhau.f_DoiMatKhau())
                DangXuat();
        }

        private void dsban_Click(object sender, RoutedEventArgs e)
        {
            W_DSBan.f_DsBan();
        }

        private void banhang_Click(object sender, RoutedEventArgs e)
        {
            if(MenuNhanh.SelectedIndex != _index[0])
                MenuNhanh.SelectedIndex = _index[0];
            else
                btbanHang();
        }

        private void hoadon_Click(object sender, RoutedEventArgs e)
        {
            if(MenuNhanh.SelectedIndex != _index[1])
                MenuNhanh.SelectedIndex = _index[1];
            else
                btHoaDon();
        }

        private void mnphieunhap_Click(object sender, RoutedEventArgs e)
        {
            if(MenuNhanh.SelectedIndex != _index[2])
                MenuNhanh.SelectedIndex = _index[2];
            else
                btphieuNhap();
        }

        private void mnphieuthu_Click(object sender, RoutedEventArgs e)
        {
            W_AddPhieu.f_Tao(false);
        }

        private void mnphieuchi_Click(object sender, RoutedEventArgs e)
        {
            W_AddPhieu.f_Tao(true);
        }

        private void mnnhanvien_Click(object sender, RoutedEventArgs e)
        {
            if(MenuNhanh.SelectedIndex != _index[8])
                MenuNhanh.SelectedIndex = _index[8];
            else
                btnhanVien();
        }

        private void mncalam_Click(object sender, RoutedEventArgs e)
        {
            W_CaLam.f_CaLam();
        }

        private void mnchucvu_Click(object sender, RoutedEventArgs e)
        {
            W_ChucVu.f_ChucVu();
        }

        private void mnungluong_Click(object sender, RoutedEventArgs e)
        {
            if(MenuNhanh.SelectedIndex != _index[6])
                MenuNhanh.SelectedIndex = _index[6];
            else
                W_UngLuong.f_UngLuong();
        }

        private void mntruluong_Click(object sender, RoutedEventArgs e)
        {
            if(MenuNhanh.SelectedIndex != _index[7])
                MenuNhanh.SelectedIndex = _index[7];
            else
                W_TruLuong.f_TruLuong();
        }

        private void mnchamcong_Click(object sender, RoutedEventArgs e)
        {
            if(MenuNhanh.SelectedIndex != _index[3])
                MenuNhanh.SelectedIndex = _index[3];
            else
                btchamCong();
        }

        private void mntinhluong_Click(object sender, RoutedEventArgs e)
        {
            if(MenuNhanh.SelectedIndex != _index[5])
                MenuNhanh.SelectedIndex = _index[5];
            else
                bttinhLuong();
        }

        private void mnnhacc_Click(object sender, RoutedEventArgs e)
        {
            if(MenuNhanh.SelectedIndex != _index[12])
                MenuNhanh.SelectedIndex = _index[12];
            else
                btnhaCC();
        }

        private void mnnhaphang_Click(object sender, RoutedEventArgs e)
        {
            W_AddPNhap.f_LapPhieu();
        }

        private void mntaikhoan_Click(object sender, RoutedEventArgs e)
        {
            if(MenuNhanh.SelectedIndex != _index[10])
                MenuNhanh.SelectedIndex = _index[10];
            else
                bttaiKhoan();
        }

        private void mnxembc_Click(object sender, RoutedEventArgs e)
        {
            btbaoCao();
        }

        private void mnthongkedoanhthu_Click(object sender, RoutedEventArgs e)
        {
            MenuNhanh.SelectedIndex = _index[9];
            btthongKe(0);
        }

        private void mnthongkemathang_Click(object sender, RoutedEventArgs e)
        {
            MenuNhanh.SelectedIndex = _index[9];
            btthongKe(1);
        }

        private void mnhuongdan_Click(object sender, RoutedEventArgs e)
        {
            W_HuongDan.f_Show();
        }

        private void mnphattrien_Click(object sender, RoutedEventArgs e)
        {
            W_NPhatTrien.f_Show();
        }

        private void mnabout_Click(object sender, RoutedEventArgs e)
        {
            W_ThongTin.f_Show();
        }

        private void mnthuchi_Click(object sender, RoutedEventArgs e)
        {
            if(MenuNhanh.SelectedIndex != _index[3])
                MenuNhanh.SelectedIndex = _index[3];
            else
                btpThuChi();
        }

        public void loadTitle()
        {
            this.Title = "Quản lý quán cafe " + informationQ._tenQuan;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadTitle();
            MenuNhanh.ItemsSource = getlistmn();
            //frame.NavigationService.Navigate(P_Hello.getPage);
        }
    }
}