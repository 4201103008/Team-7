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
using StyleCF;
using DataCf;

namespace SgCafe.Windows.NhanSu
{
    /// <summary>
    /// Interaction logic for Wp_SuaCa.xaml
    /// </summary>
    public partial class Wp_SuaCa : Window
    {
        private int _ma;
        private bool _ck = false;

        public Wp_SuaCa()
        {
            InitializeComponent();
        }

        public static bool f_SuaCa(Ca _cs)
        {
            Wp_SuaCa _win = new Wp_SuaCa();
            _win._ma = _cs.MaCa;
            _win.maCa.Text = _cs.MaCa.ToString();
            _win.tenCa.Text = _cs.TenCa;
            _win.batdau.SelectedTime = _cs.BatDau;
            _win.ketthuc.SelectedTime = _cs.KetThuc;
            _win.ghiChu.AppendText(_cs.GhiChu);

            _win.ShowDialog();

            if (_win._ck)
            {
                TextRange gc = new TextRange(_win.ghiChu.Document.ContentStart, _win.ghiChu.Document.ContentEnd);

                ThongBaoHT.f_ThongBao(CaLamList.EditCa(int.Parse(_win.maCa.Text), _win.tenCa.Text, _win.batdau.SelectedTime, _win.ketthuc.SelectedTime, gc.Text), "Sửa ca làm");

                return true;
            }
            return false;
        }

        private void tenCa_KeyUp(object sender, KeyEventArgs e)
        {
            if (tenCa.Text.Length > 0)
                BtOK.IsEnabled = true;
            else
                BtOK.IsEnabled = false;
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_ck)
            {
                if (CaLamModel.CheckTED(_ma, tenCa.Text))
                {
                    MessageBoxCF.Show("Lổi", "Trùng tên ca!", MessageBoxImage.Error, MessageBoxButton.OK);
                    e.Cancel = true;
                    _ck = false;
                }
                else if (batdau.SelectedTime > ketthuc.SelectedTime)
                {
                    MessageBoxCF.Show("Lổi", "Thời gian kết thúc ca sớm hơn thời gian bắt đầu!", MessageBoxImage.Error, MessageBoxButton.OK);
                    e.Cancel = true;
                    _ck = false;
                }
                else if (CaLamModel.CheckTrC(_ma, batdau.SelectedTime, ketthuc.SelectedTime))
                {
                    MessageBoxCF.Show("Lổi", "Thời gian làm bị trùng với ca làm khác!", MessageBoxImage.Error, MessageBoxButton.OK);
                    e.Cancel = true;
                    _ck = false;
                }
            }
        }
    }
}
