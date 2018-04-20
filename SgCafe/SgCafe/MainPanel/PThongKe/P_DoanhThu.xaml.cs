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
using System.Globalization;

namespace SgCafe.MainPanel.PThongKe
{
    public class SumDoanhThu : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string a = values[0] as string;
            string b = values[1] as string;
            decimal so = 0;
            if(a.Length > 0)
                so += decimal.Parse(a);
            if(b.Length > 0)
                so += decimal.Parse(b);
            return string.Format("{0:0.00}", so);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public partial class P_DoanhThu : Page
    {
        private static P_DoanhThu _page = null;
        private List<vw_DoanhThu> _list = null;

        public P_DoanhThu()
        {
            InitializeComponent();
        }

        public static P_DoanhThu getPage
        {
            get
            {
                if(_page == null)
                {
                    _page = new P_DoanhThu();
                    _page.Page_Loaded();
                }
                return _page;
            }
        }

        private List<vw_DoanhThu> getListDT
        {
            get
            {
                if(_list == null)
                    return null;
                return (from p in _list
                        orderby p.Ngay ascending
                        select p).ToList<vw_DoanhThu>();
            }
        }

        private decimal TongThu
        {
            get
            {
                if(_list == null)
                    return 0;
                return _list.Where(x => x.Loai == 0).ToList().Sum(x => x.SoTien) ?? 0;
            }
        }

        private decimal TongChi
        {
            get
            {
                if(_list == null)
                    return 0;
                return _list.Where(x => x.Loai == 1).ToList().Sum(x => x.SoTien) ?? 0;
            }
        }

        public class DoanhThuNgay
        {
            public DateTime Ngay { get; set; }
            public decimal LoiNhuan { get; set; }
        }

        public List<DoanhThuNgay> getDoanhThu
        {
            get
            {
                if(_list == null)
                    return null;
                return (from p in _list
                        group p by p.Ngay into g
                        orderby g.Key ascending
                        select new DoanhThuNgay
                        {
                            Ngay = g.Key,
                            LoiNhuan = g.Sum(x => x.SoTien) ?? 0
                        }).ToList<DoanhThuNgay>();
            }
        }

        private void LoadND()
        {
            listDoanhThu.ItemsSource = getListDT;
            listNgay.ItemsSource = getDoanhThu;
            tbChi.Text = string.Format("{0:0.00}", TongChi);
            tbThu.Text = string.Format("{0:0.00}", TongThu);
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
            _list = ThongKeModel.fDoanhThu(TuNgay.SelectedDate ?? DateTime.Now, DenNgay.SelectedDate ?? DateTime.Now);
            LoadND();
        }

        private void Page_Loaded()
        {
            DateTime a = DateTime.Now.AddDays(1 - DateTime.Now.Day);
            DateTime b = DateTime.Now.Date;
            TuNgay.SelectedDate = a;
            DenNgay.SelectedDate = b;
            _list = ThongKeModel.fDoanhThu(a, b);
            LoadND();
        }
    }
}
