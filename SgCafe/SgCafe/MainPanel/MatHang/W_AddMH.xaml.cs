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
    /// Interaction logic for W_AddMH.xaml
    /// </summary>
    public partial class W_AddMH : Window
    {
        private bool _ck = false;
        /// <summary>
        /// bit 0 ten hang
        /// bit 1 don vi tinh
        /// bit 2 gia nhập
        /// </summary>
        private byte _cs = 7;

        private List<DataCf.vw_CungCapHang> _liNCC = new List<DataCf.vw_CungCapHang>();

        private W_AddMH()
        {
            InitializeComponent();
        }

        public static bool f_ThemMH()
        {
            W_AddMH _win = new W_AddMH();

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

                bool c = MatHangList.AddRef(_win.tenHang.Text, _win.donVi.Text, ban, loai, gc.Text, _win._liNCC);

                ThongBaoHT.f_ThongBao(c, "Thêm mặt hàng");

                return c;
            }
            return false;
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
            if(tenHang.Text.Length > 0)
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
            if(donVi.Text.Length > 0)
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
            if(donVi.SelectedIndex != -1)
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
            if(nhaCC.SelectedIndex != -1 && giaNhap.Text.Length > 0 && decimal.Parse(giaNhap.Text) > 0)
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
            vw_CungCapHang a = new vw_CungCapHang();
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
            _liNCC.Remove((DataCf.vw_CungCapHang) cungcap.SelectedItem);
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