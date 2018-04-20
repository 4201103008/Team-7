using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using StyleCF;
using InforCf;
using SgCafe.Windows.TroGiup;

namespace SgCafe
{
    /// <summary>
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        private bool cs = true;

        public DangNhap()
        {
            InitializeComponent();
        }

        private void BtThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClosingWin(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (informationTk.dDangNhap == false)
            {
                MessageBoxResult _R = MessageBoxCF.Show("Thoát", "Bạn có chắc chắn muốn thoát không?", MessageBoxImage.Question, MessageBoxButton.YesNo);
                if (_R == MessageBoxResult.No)
                    e.Cancel = true;
            }
        }

        private void dangnhapp()
        {
            if (passwordBox.Password.Length == 0)
            {
                thongbao.Text = "Mật khẩu trống, vui lòng kiểm tra lại!";
                goto intgbao;
            }
            else if (passwordBox.Password.Length < 5)
            {
                thongbao.Text = "Độ dài mật khẩu không đủ, mật khẩu tối thiểu phải 5 ký tự!";
                goto intgbao;
            }
            else
            {
                bool ds = informationTk.dangnhaptk(comTaiKhoan.SelectedValue.ToString(), passwordBox.Password.ToString());
                if (ds)
                {
                    informationTk.dDangNhap = true;
                    App._win = new CSChinh();
                    App._win.Show();
                    this.Close();
                    goto hoanthanh;
                }
                else
                {
                    thongbao.Text = "Mật khẩu sai, vui lòng kiểm tra lại!";
                    goto intgbao;
                }
            }
            intgbao:
            {
                cs = false;
                Storyboard s = (Storyboard)trang.TryFindResource("loidn");
                s.Begin();
            }
            hoanthanh:;
        }

        private void BtDangNhap_Click(object sender, RoutedEventArgs e)
        {
            dangnhapp();
        }

        private void thulai()
        {
            Storyboard s = (Storyboard)trang.TryFindResource("tuldn");
            passwordBox.Password = "";
            cs = true;
            s.Begin();
        }

        private void thu_Click(object sender, RoutedEventArgs e)
        {
            thulai();
        }

        private void passwordBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (cs)
                    dangnhapp();
                else
                    thulai();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comTaiKhoan.ItemsSource = TaiKhoanList.getName;
        }

        private void btHuongDan_Click(object sender, RoutedEventArgs e)
        {
            W_HuongDan.f_Show();
        }

        private void btNhom_Click(object sender, RoutedEventArgs e)
        {
            W_NPhatTrien.f_Show();
        }

        private void btThongTin_Click(object sender, RoutedEventArgs e)
        {
            W_ThongTin.f_Show();
        }
    }
}