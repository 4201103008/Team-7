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
using PrintCf;

namespace SgCafe.MainPanel.ThuChi
{
    /// <summary>
    /// Interaction logic for W_AddPChi.xaml
    /// </summary>
    public partial class W_AddPhieu : Window
    {
        private int _ck = 0;
        /// <summary>
        /// bit 0 ly do
        /// bit 1 so tien
        /// </summary>
        private byte _cs = 3;

        public W_AddPhieu()
        {
            InitializeComponent();
        }

        public static bool f_Tao(bool _l)
        {
            W_AddPhieu _win = new W_AddPhieu();
            string ph;
            if(_l)
            {
                ph = "phiếu chi";
                _win.Title = "Tạo phiếu chi";
                _win.ld.Text = "Lý do chi:";
                _win.ng.Text = "Người nhận:";
            }
            else
                ph = "phiếu thu";

            _win.ShowDialog();

            TextRange gc = new TextRange(_win.noidung.Document.ContentStart, _win.noidung.Document.ContentEnd);

            if(_win._ck == 1)
            {
                return ThongBaoHT.f_ThongBao(PhieuThuChiList.AddPhieu(_l, _win.lyDo.Text, gc.Text, _win.nguoinhan.Text, _win.diaChi.Text, decimal.Parse(_win.soTien.Text)), "Tạo " + ph);
            }
            else if(_win._ck == 2)
            {
                PhieuThuChi p = PhieuThuChiList.AddBack(_l, _win.lyDo.Text, gc.Text, _win.nguoinhan.Text, _win.diaChi.Text, decimal.Parse(_win.soTien.Text));
                if(p != null)
                {
                    Pr_PhieuThuChi.f_In(p, _l);
                    return true;
                }
                else

                    return ThongBaoHT.f_ThongBao(false, "Tạo " + ph);
            }

            return false;
        }

        private void soTien_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            LBMN.isMuberic(e);
        }

        private void checkBtOk()
        {
            if(_cs == 0)
            {
                BtIn.IsEnabled = true;
                BtOK.IsEnabled = true;
            }
            else
            {
                BtIn.IsEnabled = false;
                BtOK.IsEnabled = false;
            }
        }

        private void soTien_KeyUp(object sender, KeyEventArgs e)
        {
            if(soTien.Text.Length > 0 && decimal.Parse(soTien.Text) > 0)
            {
                Ktbit.ganTR(ref _cs, 1, false);
            }
            else
            {
                Ktbit.ganTR(ref _cs, 1, true);
            }

            checkBtOk();
        }

        private void lyDo_KeyUp(object sender, KeyEventArgs e)
        {
            if(lyDo.Text.Length > 0)
            {
                Ktbit.ganTR(ref _cs, 0, false);
            }
            else
            {
                Ktbit.ganTR(ref _cs, 0, true);
            }

            checkBtOk();
        }

        private void BtIn_Click(object sender, RoutedEventArgs e)
        {
            _ck = 2;
            Close();
        }

        private void BtOK_Click(object sender, RoutedEventArgs e)
        {
            _ck = 1;
            Close();
        }

        private void BtHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
