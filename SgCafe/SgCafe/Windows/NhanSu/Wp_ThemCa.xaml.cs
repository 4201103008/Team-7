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
    /// Interaction logic for Wp_ThemCa.xaml
    /// </summary>
    public partial class Wp_ThemCa : Window
    {
        private bool _ck = false;

        private Wp_ThemCa()
        {
            InitializeComponent();
        }

        public static bool f_ThemCa()
        {
            Wp_ThemCa _win = new Wp_ThemCa();
            _win.ShowDialog();

            if (_win._ck)
            {
                TextRange gc = new TextRange(_win.ghiChu.Document.ContentStart, _win.ghiChu.Document.ContentEnd);

                ThongBaoHT.f_ThongBao(CaLamList.AddCa(_win.ten.Text, _win.batdau.SelectedTime, _win.ketthuc.SelectedTime, gc.Text), "Thêm ca làm");

                return true;
            }
            return false;
        }

        private void ten_KeyUp(object sender, KeyEventArgs e)
        {
            if (ten.Text.Length > 0)
                BtOK.IsEnabled = true;
            else
                BtOK.IsEnabled = false;
        }

        private void BtHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtOK_Click(object sender, RoutedEventArgs e)
        {
            _ck = true;

            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_ck)
            {
                if(CaLamModel.CheckTen(ten.Text))
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
                else if (CaLamModel.CheckTrK(batdau.SelectedTime, ketthuc.SelectedTime))
                {
                    MessageBoxCF.Show("Lổi", "Thời gian làm bị trùng với ca làm khác!", MessageBoxImage.Error, MessageBoxButton.OK);
                    e.Cancel = true;
                    _ck = false;
                }
            }
        }
    }
}