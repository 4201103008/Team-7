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

namespace SgCafe.Windows.TroGiup
{
    /// <summary>
    /// Interaction logic for NPhatTrien.xaml
    /// </summary>
    public partial class W_NPhatTrien : Window
    {
        private static W_NPhatTrien _win = null;

        private W_NPhatTrien()
        {
            InitializeComponent();
        }

        public static void f_Show()
        {
            if(_win == null)
            {
                _win = new W_NPhatTrien();
                _win.Show();
            }
            else
                _win.Activate();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _win = null;
        }
    }
}
