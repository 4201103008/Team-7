﻿using System;
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

namespace SgCafe.MainPanel.NhaCC
{
    /// <summary>
    /// Interaction logic for W_EditNCC.xaml
    /// </summary>
    public partial class W_EditNCC : Window
    {
        private bool _ck = false;
        private bool ukey = true;
        /// <summary>
        /// bit 0 ten ncc
        /// bit 1 ma so thue
        /// bit 2 dia chi
        /// bit 3 sdt
        /// </summary>
        private byte _cs = 7;

        private List<DataCf.vw_CungCap> _liNCC = new List<DataCf.vw_CungCap>();

        public W_EditNCC()
        {
            InitializeComponent();
        }

        public static bool f_SuaNCC(DataCf.NhaCC nh, bool k, List<vw_CungCap> cc)
        {
            W_EditNCC _win = new W_EditNCC();

            _win.maNCC.Text = nh.MaNCC.ToString();
            _win.tenNCC.Text = nh.TenNCC;
            _win.maST.Text = nh.MaSoThue;
            _win.diaChi.Text = nh.DiaChi;
            _win.sdt.Text = nh.SDT;
            _win.fax.Text = nh.Fax;
            _win.email.Text = nh.Email;
            _win._liNCC = cc;
            _win.ukey = !k;
            _win.reLoad();

            _win.ShowDialog();

            if (_win._ck)
            {
                return ThongBaoHT.f_ThongBao(NhaCCList.EditNCC(nh.MaNCC, _win.tenNCC.Text, _win.diaChi.Text, _win.sdt.Text, _win.fax.Text, _win.email.Text, _win.maST.Text, k, _win._liNCC), "Sửa nhà cung cấp");
            }
            return false;
        }

        private void checkBtOk()
        {
            if (_cs == 0)
                BtOK.IsEnabled = true;
            else
                BtOK.IsEnabled = false;
        }

        private void Text_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            LBMN.isMuberic(e);
        }

        private void tenNCC_KeyUp(object sender, KeyEventArgs e)
        {
            if (tenNCC.Text.Length > 0)
            {
                Ktbit.ganTR(ref _cs, 0, false);
            }
            else
            {
                Ktbit.ganTR(ref _cs, 0, true);
            }

            checkBtOk();
        }

        private void maST_KeyUp(object sender, KeyEventArgs e)
        {
            if (maST.Text.Length == 10)
            {
                Ktbit.ganTR(ref _cs, 1, false);
            }
            else
            {
                Ktbit.ganTR(ref _cs, 1, true);
            }

            checkBtOk();
        }

        private void diaChi_KeyUp(object sender, KeyEventArgs e)
        {
            if (diaChi.Text.Length > 0)
            {
                Ktbit.ganTR(ref _cs, 2, false);
            }
            else
            {
                Ktbit.ganTR(ref _cs, 2, true);
            }

            checkBtOk();
        }

        private void sdt_KeyUp(object sender, KeyEventArgs e)
        {
            if (sdt.Text.Length >= 10)
            {
                Ktbit.ganTR(ref _cs, 3, false);
            }
            else
            {
                Ktbit.ganTR(ref _cs, 3, true);
            }

            checkBtOk();
        }

        private void reLoad()
        {
            matHang.ItemsSource = from p in MatHangList.getList
                                  where !(_liNCC.Any(x => x.MaHang == p.MaHang))
                                  select p;
            cungcap.ItemsSource = _liNCC;
        }

        private void cungcap_Loaded(object sender, RoutedEventArgs e)
        {
            reLoad();
        }

        private void checkCC()
        {
            if (matHang.SelectedIndex != -1 && giaNhap.Text.Length > 0 && decimal.Parse(giaNhap.Text) > 0)
            {
                them.IsEnabled = true;
            }
            else
            {
                them.IsEnabled = false;
            }
        }

        private void matHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            checkCC();
        }

        private void giaNhap_KeyUp(object sender, KeyEventArgs e)
        {
            checkCC();
        }

        private void cungcap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ukey)
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
        }

        private void them_Click(object sender, RoutedEventArgs e)
        {
            vw_CungCap ct = new vw_CungCap();
            ct.MaHang = (((DataCf.MatHang)matHang.SelectedItem).MaHang);
            ct.TenHang = (((DataCf.MatHang)matHang.SelectedItem).TenHang);
            ct.GiaNhap = decimal.Parse(giaNhap.Text);
            _liNCC.Add(ct);
            reLoad();
            cungcap.Items.Refresh();
            matHang.Items.Refresh();
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            _liNCC.Remove((DataCf.vw_CungCap)cungcap.SelectedItem);
            reLoad();
            cungcap.Items.Refresh();
            matHang.Items.Refresh();
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
