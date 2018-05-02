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
using StyleCF;
using InforCf;

namespace SgCafe.Windows.HeThong
{
    /// <summary>
    /// Interaction logic for DoiMatKhau.xaml
    /// </summary>
    public partial class W_DoiMatKhau : Window
    {
        private bool _dt = false;

        private ImageSource _ck = LBMN.getBMI("/SgCafe;component/Icon/Check/CheckNT.png");
        private ImageSource _uc = LBMN.getBMI("/SgCafe;component/Icon/Check/UncheckNT.png");

        public W_DoiMatKhau()
        {
            InitializeComponent();
        }

        public static bool f_DoiMatKhau()
        {
            W_DoiMatKhau _dm = new W_DoiMatKhau();
            _dm.ShowDialog();

            if (_dm._dt)
            {
                informationTk.doimk(_dm.mkmoi.Password);

                return true;
            }

            return false;
        }

        private void mkcu_KeyUp(object sender, KeyEventArgs e)
        {
            if (informationTk.kt_matKhau(mkcu.Password))
            {
                mkmoi.IsEnabled = true;
                checkmkc.Source = _ck;
            }
            else
            {
                checkmkc.Source = _uc;
                mkmoi.IsEnabled = false;
                nlmk.IsEnabled = false;
                BtOK.IsEnabled = false;
            }
        }

        private void mkmoi_KeyUp(object sender, KeyEventArgs e)
        {
            if (mkmoi.Password.Length >= 5)
            {
                nlmk.IsEnabled = true;
                checkmkm.Source = _ck;
            }
            else
            {
                checkmkm.Source = _uc;
                nlmk.IsEnabled = false;
                BtOK.IsEnabled = false;
            }
        }

        private void nlmk_KeyUp(object sender, KeyEventArgs e)
        {
            if (nlmk.Password == mkmoi.Password)
            {
                BtOK.IsEnabled = true;
                checkmkl.Source = _ck;
            }
            else
            {
                checkmkl.Source = _uc;
                BtOK.IsEnabled = false;
            }
        }

        private void BtOK_Click(object sender, RoutedEventArgs e)
        {
            _dt = true;

            this.Close();
        }

        private void BtHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}