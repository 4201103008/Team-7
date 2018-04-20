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

namespace SgCafe.MainPanel.NhanVien
{
    /// <summary>
    /// Interaction logic for W_SapLich.xaml
    /// </summary>
    public partial class W_SapLich : Window
    {
        private bool _sp = false;
        private List<nvSapLich> _sl;

        private W_SapLich()
        {
            InitializeComponent();
        }

        public static bool f_SapLich(DataCf.NhanVien nv)
        {
            W_SapLich _win = new W_SapLich();

            _win.maNV.Text = nv.MaNV.ToString();
            _win.tenNV.Text = nv.TenNV.ToString();
            _win._sl = nvSapLich.getLich(nv.MaNV);

            _win.ShowDialog();

            if(_win._sp)
            {
                ThongBaoHT.f_ThongBao(NhanVienModel.EditLam(nv.MaNV, _win._sl.Cast<ItFSapLich>().ToList()), "Sắp lịch làm việc cho nhân viên " + nv.TenNV);

                return true;
            }

            return false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataLich.ItemsSource = _sl;
        }

        private void BtOK_Click(object sender, RoutedEventArgs e)
        {
            _sp = true;

            Close();
        }

        private void BtHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
