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
using DataCf;

namespace SgCafe.MainPanel.PThongKe
{
    public partial class P_DoUong : Page
    {
        private static P_DoUong _page = null;

        private P_DoUong()
        {
            InitializeComponent();
        }

        public static P_DoUong getPage
        {
            get
            {
                if(_page == null)
                {
                    _page = new P_DoUong();
                    _page.Page_Loaded();
                }
                return _page;
            }
        }

        private bool CheckDateSelect()
        {
            if(TuNgay.SelectedDate != null && DenNgay.SelectedDate != null && TuNgay.SelectedDate <= DenNgay.SelectedDate)
            {
                btXem.IsEnabled = true;
                return false;
            }
            else
            {
                btXem.IsEnabled = false;
                return true;
            }
        }

        private void TuNgay_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CheckDateSelect() && DenNgay.SelectedDate != null)
                TuNgay.SelectedDate = DenNgay.SelectedDate;
        }

        private void DenNgay_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CheckDateSelect() && TuNgay.SelectedDate != null)
                DenNgay.SelectedDate = TuNgay.SelectedDate;
        }

        private void btXem_Click(object sender, RoutedEventArgs e)
        {
            listMatHang.ItemsSource = ThongKeModel.fMatHang(TuNgay.SelectedDate ?? DateTime.Now, DenNgay.SelectedDate ?? DateTime.Now);
        }

        private void Page_Loaded()
        {
            DateTime a = DateTime.Now.AddDays(1 - DateTime.Now.Day);
            DateTime b = DateTime.Now.Date;
            TuNgay.SelectedDate = a;
            DenNgay.SelectedDate = b;
            listMatHang.ItemsSource = ThongKeModel.fMatHang(a, b);
        }
    }
}
