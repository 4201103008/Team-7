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
using System.Windows.Media.Animation;
using InforCf;
using DataCf;
using StyleCF;

namespace SgCafe.MainPanel.MatHang
{
    /// <summary>
    /// Interaction logic for W_EditMH.xaml
    /// </summary>
    public partial class W_EditMH : Window
    {
        private bool _ck = false;
        private decimal mah;
        private bool knl = true;
        /// <summary>
        /// bit 0 ten hang
        /// bit 1 don vi tinh
        /// bit 2 gia nhập
        /// </summary>
        private byte _cs = 0;

        private List<DataCf.vw_CungCap> _liNCC;

        public W_EditMH()
        {
            InitializeComponent();
        }

        public static bool f_SuaMH(DataCf.MatHang mh, List<vw_CungCap> cc)
        {
            W_EditMH _win = new W_EditMH();

            _win.mah = mh.MaHang;
            _win.maHang.Text = mh.MaHang.ToString();
            _win.tenHang.Text = mh.TenHang;
            _win.donVi.Text = mh.DonViTinh;
            _win.nguyenLieu.IsChecked = mh.Loai <= 0;
            _win.sanPham.IsChecked = mh.Loai >= 0;
            _win.giaBan.Text = string.Format("{0:0.00}", mh.GiaBan);
            _win.ghiChu.AppendText(mh.GhiChu);
            _win._liNCC = cc;
            _win.reLoad();
            if(mh.Loai == 1)
                _win.csNL.Width = new GridLength(10);

            _win.ShowDialog();

            if (_win._ck)
            {
                int loai = 0;
                if (_win.nguyenLieu.IsChecked == true)
                    loai--;
                if (_win.sanPham.IsChecked == true)
                    loai++;
                TextRange gc = new TextRange(_win.ghiChu.Document.ContentStart, _win.ghiChu.Document.ContentEnd);
                decimal? ban;
                if (loai >= 0)
                    ban = decimal.Parse(_win.giaBan.Text);
                else
                    ban = null;

                ThongBaoHT.f_ThongBao(MatHangList.EditMH(mh.MaHang, _win.tenHang.Text, _win.donVi.Text, ban, loai, gc.Text, (List<vw_CungCap>)_win._liNCC), "Sửa mặt hàng");
                return true;
            }
            return false;
        }

        public static bool f_SuaKhoa(DataCf.MatHang mh, int t, List<vw_CungCap> cc)
        {
            W_EditMH _win = new W_EditMH();

            _win.mah = mh.MaHang;
            _win.maHang.Text = mh.MaHang.ToString();
            _win.tenHang.Text = mh.TenHang;
            _win.donVi.Text = mh.DonViTinh;
            _win.nguyenLieu.IsChecked = mh.Loai <= 0;
            _win.sanPham.IsChecked = mh.Loai >= 0;
            _win.giaBan.Text = string.Format("{0:0.00}", mh.GiaBan);
            _win.ghiChu.AppendText(mh.GhiChu);
            _win._liNCC = cc;
            _win.reLoad();
            if(mh.Loai == 1)
                _win.csNL.Width = new GridLength(10);
            if(t <= 0)
                _win.KhoaNL();
            if(t >= 0)
                _win.KhoaSP();
            _win.ShowDialog();

            if(_win._ck)
            {
                int loai = 0;
                if(_win.nguyenLieu.IsChecked == true)
                    loai--;
                if(_win.sanPham.IsChecked == true)
                    loai++;
                TextRange gc = new TextRange(_win.ghiChu.Document.ContentStart, _win.ghiChu.Document.ContentEnd);
                decimal? ban = null;
                if(t >= 0 && loai >= 0)
                    ban = decimal.Parse(_win.giaBan.Text);

                ThongBaoHT.f_ThongBao(MatHangList.EditKhoa(mh.MaHang, _win.tenHang.Text, _win.donVi.Text, ban, loai, t, gc.Text, (List<vw_CungCap>)_win._liNCC), "Sửa mặt hàng");
                return true;
            }
            return false;
        }

        private void KhoaSP()
        {
            sanPham.IsEnabled = false;
            giaBan.IsEnabled = false;
        }

        private void KhoaNL()
        {
            nguyenLieu.IsEnabled = false;
            knl = false;
        }

        private void nglRun()
        {
            Storyboard s;
            if (nguyenLieu.IsChecked == true)
                s = this.PnC.FindResource("isngl") as Storyboard;
            else
                s = this.PnC.FindResource("notngl") as Storyboard;
            s.Begin(this);
        }

        private void nguyenLieu_Click(object sender, RoutedEventArgs e)
        {
            nglRun();
            if (nguyenLieu.IsChecked != true && sanPham.IsChecked != true)
            {
                sanPham.IsChecked = true;
                checkGiaB();
            }
        }

        private void sanPham_Click(object sender, RoutedEventArgs e)
        {
            if (sanPham.IsChecked == true)
            {
                giaBan.IsEnabled = true;
            }
            else
            {
                if (nguyenLieu.IsChecked != true)
                {
                    nguyenLieu.IsChecked = true;
                    nglRun();
                }

                giaBan.IsEnabled = false;
            }

            checkGiaB();
        }

        private void checkGiaB()
        {
            if (sanPham.IsChecked == true && (giaBan.Text.Length == 0 || decimal.Parse(giaBan.Text) == 0))
            {
                Ktbit.ganTR(ref _cs, 2, true);
            }
            else
            {
                Ktbit.ganTR(ref _cs, 2, false);
            }

            checkBtOk();
        }

        private void checkBtOk()
        {
            if (_cs == 0)
                BtOK.IsEnabled = true;
            else
                BtOK.IsEnabled = false;
        }

        private void tenHang_KeyUp(object sender, KeyEventArgs e)
        {
            if (tenHang.Text.Length > 0)
            {
                Ktbit.ganTR(ref _cs, 0, false);
            }
            else
            {
                Ktbit.ganTR(ref _cs, 0, true);
            }

            checkBtOk();
        }

        private void donVi_KeyUp(object sender, KeyEventArgs e)
        {
            if (donVi.Text.Length > 0)
            {
                Ktbit.ganTR(ref _cs, 1, false);
            }
            else
            {
                Ktbit.ganTR(ref _cs, 1, true);
            }

            checkBtOk();
        }

        private void donVi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (donVi.SelectedIndex != -1)
            {
                Ktbit.ganTR(ref _cs, 1, false);
            }
            else
            {
                Ktbit.ganTR(ref _cs, 1, true);
            }

            checkBtOk();
        }

        private void giaBan_KeyUp(object sender, KeyEventArgs e)
        {
            checkGiaB();
        }

        private void Text_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            LBMN.isMuberic(e);
        }

        private void reLoad()
        {
            nhaCC.ItemsSource = from p in NhaCCList.getList
                                where !(_liNCC.Any(x => x.MaNCC == p.MaNCC))
                                select p;
            cungcap.ItemsSource = _liNCC;
        }

        private void cungcap_Loaded(object sender, RoutedEventArgs e)
        {
            reLoad();
        }

        private void checkCC()
        {
            if (nhaCC.SelectedIndex != -1 && giaNhap.Text.Length > 0 && decimal.Parse(giaNhap.Text) > 0)
            {
                them.IsEnabled = true;
            }
            else
            {
                them.IsEnabled = false;
            }
        }

        private void nhaCC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            checkCC();
        }

        private void giaNhap_KeyUp(object sender, KeyEventArgs e)
        {
            checkCC();
        }

        private void cungcap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(knl)
                if(cungcap.SelectedIndex != -1)
                {
                    xoa.IsEnabled = true;
                }
                else
                {
                    xoa.IsEnabled = false;
                }
        }

        private void them_Click(object sender, RoutedEventArgs e)
        {
            vw_CungCap a = new vw_CungCap();
            a.MaHang = mah;
            a.MaNCC = ((DataCf.NhaCC)nhaCC.SelectedItem).MaNCC;
            a.TenNCC = ((DataCf.NhaCC)nhaCC.SelectedItem).TenNCC;
            a.GiaNhap = decimal.Parse(giaNhap.Text);
            _liNCC.Add(a);
            reLoad();
            giaNhap.Text = "0";
            cungcap.Items.Refresh();
            nhaCC.Items.Refresh();
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            _liNCC.Remove((DataCf.vw_CungCap)cungcap.SelectedItem);
            reLoad();
            cungcap.Items.Refresh();
            nhaCC.Items.Refresh();
        }

        private void giaNhap_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (giaNhap.Text.Length > 0 && decimal.Parse(giaNhap.Text) == 0)
                giaNhap.Text = "";
        }

        private void giaNhap_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (giaNhap.Text.Length == 0)
                giaNhap.Text = "0";
        }

        private void giaBan_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (giaBan.Text.Length > 0 && decimal.Parse(giaBan.Text) == 0)
                giaBan.Text = "";
        }

        private void giaBan_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (giaBan.Text.Length == 0)
                giaBan.Text = "0";
        }

        private void BtOK_Click(object sender, RoutedEventArgs e)
        {
            _ck = true;

            Close();
        }

        private void BtHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}