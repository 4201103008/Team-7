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
using InforCf;
using DataCf;
using PrintCf;

namespace SgCafe.MainPanel.NhapHang
{
    /// <summary>
    /// Interaction logic for W_EditPNhap.xaml
    /// </summary>
    public partial class W_EditPNhap : Window
    {
        private int c = 0;
        private List<pnSapNhap> _listH = new List<pnSapNhap>();
        private List<vw_CungCapC> _listC = new List<vw_CungCapC>();
        private decimal _tt = 0;

        private W_EditPNhap()
        {
            InitializeComponent();
        }

        public static bool f_SuaPhieu(PhieuNhap pc)
        {
            W_EditPNhap _win = new W_EditPNhap();

            _win.LoadPN(pc);

            _win.ShowDialog();

            if(_win.c == 1)
            {
                ThongBaoHT.f_ThongBao(PhieuNhapList.EditPN(pc.SoPhieu, false, ((DataCf.NhaCC)_win.NhaCungCap.SelectedItem).MaNCC, _win._tt, _win._listH), "Lưu phiếu nhập");
            }
            else if(_win.c == 2)
            {
                ThongBaoHT.f_ThongBao(PhieuNhapList.EditPN(pc.SoPhieu, true, ((DataCf.NhaCC)_win.NhaCungCap.SelectedItem).MaNCC, _win._tt, _win._listH), "Thanh toán phiếu nhập");
            }
            else if(_win.c == 3)
            {
                PhieuNhap pn = PhieuNhapList.EditBack(pc.SoPhieu, ((DataCf.NhaCC)_win.NhaCungCap.SelectedItem).MaNCC, _win._tt, _win._listH);
                if(pn != null)
                {
                    Pr_PhieuNhap.f_In(pn, _win._listH);
                }
            }
            else
                return false;
            return true;
        }

        private void LoadPN(PhieuNhap pn)
        {
            NhaCungCap.ItemsSource = NhaCCList.getList;
            NhaCungCap.SelectedIndex = NhaCCList.getList.FindIndex(x => x.MaNCC == pn.MaNCC);
            Ngay.Text = pn.NgayLap.ToString("dd/MM/yyyy");
            soPhieu.Text = string.Format("{0:000000000000000}", pn.SoPhieu);
            MaSoThue.Text = NhaCCList.getList.Find(x => x.MaNCC == pn.MaNCC).MaSoThue;
            _listC = MatHangList.LoadCC(pn.MaNCC);
            _listH = MatHangList.LoadofNhap(pn.SoPhieu, pn.MaNCC);
            listMH.ItemsSource = _listC;
            listHinP.ItemsSource = _listH;
            _tt = pn.TongTien;
            tongTien.Text = string.Format("{0:0.00}", _tt);
        }

        private void RefeshW()
        {
            listHinP.ItemsSource = _listH;
            if(_tt > 0)
            {
                BtIn.IsEnabled = true;
                BtLuu.IsEnabled = true;
                BtTT.IsEnabled = true;
            }
            else
            {
                BtIn.IsEnabled = false;
                BtLuu.IsEnabled = false;
                BtTT.IsEnabled = false;
            }
            tongTien.Text = string.Format("{0:0.00}", _tt);
            listHinP.Items.Refresh();
        }

        private void NhaCungCap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(NhaCungCap.SelectedIndex != -1)
            {
                _listC = MatHangList.LoadCC(((DataCf.NhaCC)NhaCungCap.SelectedItem).MaNCC);
                MaSoThue.Text = ((DataCf.NhaCC)NhaCungCap.SelectedItem).MaSoThue;
            }
            else
            {
                TimKiem.Text = "Tìm kiếm";
                MaSoThue.Text = string.Empty;
                _listC.Clear();
            }
            _listH.Clear();
            _tt = 0;
            listMH.ItemsSource = _listC;
            listMH.Items.Refresh();
            RefeshW();
        }

        private void listHinP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listHinP.SelectedIndex != -1)
            {
                giam.IsEnabled = true;
                xoa.IsEnabled = true;
            }
            else
            {
                giam.IsEnabled = false;
                xoa.IsEnabled = false;
            }
        }

        private void listMH_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listMH.SelectedIndex != -1)
            {
                them.IsEnabled = true;
            }
            else
            {
                them.IsEnabled = false;
            }
        }

        private void them_Click(object sender, RoutedEventArgs e)
        {
            vw_CungCapC mh = (vw_CungCapC)listMH.SelectedItem;
            pnSapNhap c = _listH.Find(x => x.MaHang == mh.MaHang);
            int so = int.Parse(comboBSoLuong.Text);
            if(c == null)
            {
                c = new pnSapNhap();
                c.MaHang = mh.MaHang;
                c.TenHang = mh.TenHang;
                c.GiaNhap = mh.GiaNhap;
                c.DonViTinh = mh.DonViTinh;
                c.SoLuong = so;

                _listH.Add(c);
            }
            else
            {
                c.SoLuong += so;
            }
            _tt += so * mh.GiaNhap;
            RefeshW();
        }

        private void giam_Click(object sender, RoutedEventArgs e)
        {
            pnSapNhap m = (pnSapNhap)listHinP.SelectedItem;
            pnSapNhap c = _listH.Find(x => x.MaHang == m.MaHang);
            if(c != null)
            {
                int s = int.Parse(comboBSoLuong.Text);
                if(c.SoLuong <= s)
                {
                    _tt -= c.SoLuong * c.GiaNhap;
                    _listH.Remove(c);
                }
                else
                {
                    _tt -= s * c.GiaNhap;
                    c.SoLuong -= s;
                }
            }
            RefeshW();
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            pnSapNhap m = (pnSapNhap)listHinP.SelectedItem;
            pnSapNhap c = _listH.Find(x => x.MaHang == m.MaHang);
            if(c != null)
            {
                _tt -= c.SoLuong * c.GiaNhap;
                _listH.Remove(c);
            }
            RefeshW();
        }

        private void TimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            if(TimKiem.Text.Length == 0)
            {
                listMH.ItemsSource = _listC;
            }
            else
            {
                listMH.ItemsSource = from p in _listC
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

        private void BtIn_Click(object sender, RoutedEventArgs e)
        {
            c = 3;

            Close();
        }

        private void BtTT_Click(object sender, RoutedEventArgs e)
        {
            c = 2;

            Close();
        }

        private void BtLuu_Click(object sender, RoutedEventArgs e)
        {
            c = 1;

            Close();
        }

        private void BtHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
