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

namespace SgCafe.Windows.HeThong
{
    /// <summary>
    /// Interaction logic for CaiDat.xaml
    /// </summary>
    public partial class W_CaiDat : Window
    {
        private bool _k = false;

        private W_CaiDat()
        {
            InitializeComponent();
        }

        public static void f_CaiDat()
        {
            W_CaiDat _win = new W_CaiDat();

            _win.ShowDialog();

            if(_win._k)
            {
                informationQ._tenQuan = _win.tenquan.Text;
                informationQ._diaChi = _win.diachi.Text;
                informationQ._phone = _win.sdt.Text;
                informationQ._thueVAT = byte.Parse(_win.vat.Text);
                informationQ._giamGia = byte.Parse(_win.giamgia.Text);
                informationQ._autoClear = byte.Parse(_win.xoadlcs.Text);
                informationQ._truKoPhep = decimal.Parse(_win.trutheo.Text);
                informationQ._nkpTruTheo = _win.sotien.IsChecked == true;
                informationQ._tienTe = _win.tiente.Text;
                informationQ._thongBao = _win.thongbao.IsChecked == true;
            }
        }

        private void sotien_Checked(object sender, RoutedEventArgs e)
        {
            kh.Text = "$";
        }

        private void phantram_Checked(object sender, RoutedEventArgs e)
        {
            kh.Text = "%";
        }

        private void Window_Loaded (object sender, RoutedEventArgs e)
        {
            tenquan.Text = informationQ._tenQuan;
            diachi.Text = informationQ._diaChi;
            sdt.Text = informationQ._phone;
            vat.Text = informationQ._thueVAT.ToString();
            giamgia.Text = informationQ._giamGia.ToString();
            thongbao.IsChecked = informationQ._thongBao;
            xoadlcs.Text = informationQ._autoClear.ToString();
            tiente.Text = informationQ._tienTe;

            if (informationQ._autoClear > 0)
            {
                xdlc.IsChecked = true;
            }
            else
            {
                xdlc.IsChecked = false;
            }

            trutheo.Text = informationQ._truKoPhep.ToString();
            if(informationQ._nkpTruTheo)
            {
                sotien.IsChecked = true;
                phantram.IsChecked = false;
            }
            else
            {
                sotien.IsChecked = false;
                phantram.IsChecked = true;
            }
        }

        private void sdt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            LBMN.isMuberic(e);
        }

        private void vat_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            LBMN.isMuberic(e);
        }

        private void giamgia_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            LBMN.isMuberic(e);
        }

        private void xoadlcs_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            LBMN.isMuberic(e);
        }

        private void trutheo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            LBMN.isMuberic(e);
        }

        private void BtOK_Click(object sender, RoutedEventArgs e)
        {
            _k = true;

            Close();
        }

        private void BtHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void xoadlcs_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (xoadlcs.IsEnabled)
                xoadlcs.Text = informationQ._autoClear.ToString();
            else
                xoadlcs.Text = "0";
        }

        private void tiente_KeyUp(object sender, KeyEventArgs e)
        {
            if (sotien.IsChecked == true)
                kh.Text = tiente.Text;
        }
    }
}
