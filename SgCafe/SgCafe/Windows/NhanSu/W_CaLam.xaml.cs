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
using SgCafe.Windows.NhanSu;
using InforCf;
using StyleCF;
using DataCf;

namespace SgCafe.Windows.NhanSu
{
    /// <summary>
    /// Interaction logic for CaLam.xaml
    /// </summary>
    public partial class W_CaLam : Window
    {
        private W_CaLam()
        {
            InitializeComponent();
        }

        public static void f_CaLam()
        {
            W_CaLam _win = new W_CaLam();

            _win.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listCa.ItemsSource = CaLamList.getList;
        }

        private void them_Click(object sender, RoutedEventArgs e)
        {
            Wp_ThemCa.f_ThemCa();

            listCa.Items.Refresh();
        }

        private void sua_Click(object sender, RoutedEventArgs e)
        {
            Wp_SuaCa.f_SuaCa((Ca)listCa.SelectedItem);

            listCa.Items.Refresh();
        }

        private void XoaCa(int maC, bool b)
        {
            ThongBaoHT.f_ThongBao(CaLamList.DeleteCa(maC, b), "Xóa ca làm");

            listCa.Items.Refresh();
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            bool bc = false;
            int ma = ((Ca)listCa.SelectedItem).MaCa;
            int l = CaLamModel.CheckLamCa(ma);
            int c = CaLamModel.CheckCong(ma);
            string tb = "Có ";
            if (l > 0)
            {
                bc = true;
                tb += l + " nhân viên đang làm việc trong ca này";
            }
            if(c > 0)
            {
                bc = true;
                if(l > 0)
                    tb += " và ";
                tb += c + " công chấm cho ca này";
            }
            MessageBoxResult _R;
            if (bc)
            {
                tb += ".\nBạn còn muốn xóa nó không?";
                _R = MessageBoxCF.Show("Cảnh báo", tb, MessageBoxImage.Warning, MessageBoxButton.YesNo);
            }
            else
                _R = MessageBoxCF.Show("Xác nhận xóa ca làm", "Bạn có chắc chắn muốn xóa ca làm này không?", MessageBoxImage.Question, MessageBoxButton.YesNo);
            if(c == -1) bc = true;
            if (_R == MessageBoxResult.Yes)
                XoaCa(ma, bc);
        }

        private void listCa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listCa.SelectedIndex != -1)
            {
                sua.IsEnabled = true;
                xoa.IsEnabled = true;
            }
            else
            {
                sua.IsEnabled = false;
                xoa.IsEnabled = false;
            }
        }
    }
}
