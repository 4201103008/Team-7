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
using StyleCF;

namespace SgCafe.MainPanel.NhanVien
{
    /// <summary>
    /// Interaction logic for W_AddNV.xaml
    /// </summary>
    public partial class W_AddNV : Window
    {
        private bool _ck = false;
        private List<nvSapLich> _sl;
        /// <summary>
        /// bit 0 ten nv
        /// bit 1 luong
        /// bit 2 cv
        /// </summary>
        private byte _cs = 7;

        private W_AddNV()
        {
            InitializeComponent();
        }

        public static bool f_AddNV()
        {
            W_AddNV _win = new W_AddNV();

            _win.ShowDialog();

            if(_win._ck)
            {
                TextRange gc = new TextRange(_win.ghiChu.Document.ContentStart, _win.ghiChu.Document.ContentEnd);
                if (NhanVienList.AddNV(_win.tenNV.Text, decimal.Parse(_win.luong.Text), _win.sdt.Text, _win.gioitinh.SelectedIndex == 0, _win.diaChi.Text, gc.Text, ((ChucVu)_win.chucVu.SelectedItem).MaCV, _win._sl))
                {
                    ThongBaoHT.f_ThongBao(true, "Thêm nhân viên");
                    return true;
                }
                else
                {
                    ThongBaoHT.f_ThongBao(false, "Thêm nhân viên");
                    return false;
                }
            }

            return false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            chucVu.ItemsSource = ChucVuList.getList;

            _sl = CaLamList.getList.ConvertAll<nvSapLich>(x => new nvSapLich
            {
                MaCa = x.MaCa,
                TenCa = x.TenCa
            });
            dataLich.ItemsSource = _sl;
        }

        private void Text_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            LBMN.isMuberic(e);
        }

        private void luong_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            LBMN.isMuberic(e);
        }

        private void luong_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (luong.Text.Length > 0 && decimal.Parse(luong.Text) == 0)
                luong.Text = "";
        }

        private void luong_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (luong.Text.Length == 0)
                luong.Text = "0";
        }

        private void checkBtOk()
        {
            if (_cs == 0)
                BtOK.IsEnabled = true;
            else
                BtOK.IsEnabled = false;
        }

        private void tenNV_KeyUp(object sender, KeyEventArgs e)
        {
            if (tenNV.Text.Length > 0)
            {
                Ktbit.ganTR(ref _cs, 0, false);
            }
            else
            {
                Ktbit.ganTR(ref _cs, 0, true);
            }

            checkBtOk();
        }

        private void luong_KeyUp(object sender, KeyEventArgs e)
        {
            if (luong.Text.Length > 0 && decimal.Parse(luong.Text) > 0)
            {
                Ktbit.ganTR(ref _cs, 1, false);
            }
            else
            {
                Ktbit.ganTR(ref _cs, 1, true);
            }

            checkBtOk();
        }

        private void chucVu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(chucVu.SelectedIndex != -1)
            {
                Ktbit.ganTR(ref _cs, 2, false);
            }
            else
            {
                Ktbit.ganTR(ref _cs, 2, true);
            }

            checkBtOk();
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
