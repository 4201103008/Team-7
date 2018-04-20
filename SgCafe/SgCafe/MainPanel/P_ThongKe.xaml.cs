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
using SgCafe.MainPanel.PThongKe;

namespace SgCafe.MainPanel
{
    /// <summary>
    /// Interaction logic for P_ThongKe.xaml
    /// </summary>
    public partial class P_ThongKe : Page
    {
        private static P_ThongKe _page = null;

        public static P_ThongKe getPage(int i)
        {
            if(_page == null)
                _page = new P_ThongKe();
            switch(i)
            {
                case 0:
                    _page.cbSelectLoai.SelectedIndex = 0;
                    break;
                case 1:
                    _page.cbSelectLoai.SelectedIndex = 1;
                    break;
                default:
                    break;
            }

            _page.checkSelect();

            return _page;
        }

        private P_ThongKe()
        {
            InitializeComponent();
        }
        
        private void selectDoanhThu()
        {
            frame.NavigationService.Navigate(P_DoanhThu.getPage);
        }

        private void selectMatHang()
        {
            frame.NavigationService.Navigate(P_DoUong.getPage);
        }

        private void checkSelect()
        {
            switch(cbSelectLoai.SelectedIndex)
            {
                case 1:
                    selectMatHang();
                    break;
                default:
                    selectDoanhThu();
                    break;
            }
        }

        private void cbSelectLoai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            checkSelect();
        }
    }
}
