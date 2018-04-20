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
using System.Windows.Navigation;
using System.Windows.Shapes;
using InforCf;

namespace SgCafe.MainPanel
{
    /// <summary>
    /// Interaction logic for P_Hello.xaml
    /// </summary>
    public partial class P_Hello : Page
    {
        private static P_Hello _page = null;

        private P_Hello()
        {
            InitializeComponent();
        }

        public static P_Hello getPage
        {
            get
            {
                if(_page == null)
                    _page = new P_Hello();
                return _page;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _Title.Text = "Chào " + informationTk.TenNhanVien;
        }
    }
}
