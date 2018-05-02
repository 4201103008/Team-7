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
using System.Globalization;
using System.ComponentModel;
using DataCf;
using InforCf;
using System.Collections.ObjectModel;
using System.Reflection;
using StyleCF;
using System.Collections.Specialized;

namespace SgCafe.MainPanel
{
    public class cvMauCC : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int a = (int)value;
            SolidColorBrush co = new SolidColorBrush();
            switch(a)
            {
                case 1:
                    co.Color = Color.FromArgb(255, 87, 240, 108);
                    break;
                case 2:
                    co.Color = Color.FromArgb(255, 226, 226, 99);
                    break;
                case 3:
                    co.Color = Color.FromArgb(255, 189, 77, 72);
                    break;
                default:
                    co.Color = Color.FromArgb(255, 240, 240, 240);
                    break;
            }
            co.Opacity = 0.9;
            return co;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("");
        }
    }

    public class ChamCongDS : INotifyPropertyChanged
    {
        public decimal MaCong { get; set; }
        public decimal MaNV { get; set; }
        public string TenNV { get; set; }
        public int MaCa { get; set; }
        public string TenCa { get; set; }
        public int[] Lich { get; set; }

        public void UpdateLich(int c, int gt)
        {
            if(Lich[c - 1] != gt)
            {
                if(ChamCongModel.ChamC(MaCong, MaCa, (byte)c, (byte)gt))
                    Lich[c - 1] = gt;
                else
                    MessageBoxCF.Show("Lổi", "Lổi khi chấm công!", MessageBoxImage.Error, MessageBoxButton.OK);
                OnPropertyChanged("Lich");
            }
        }

        public void UpdateLich(int c)
        {
            int gt = (Lich[c - 1] + 1) % 4;
            if(ChamCongModel.ChamC(MaCong, MaCa, (byte)c, (byte)gt))
                Lich[c - 1] = gt;
            else
                MessageBoxCF.Show("Lổi", "Lổi khi chấm công!", MessageBoxImage.Error, MessageBoxButton.OK);
            OnPropertyChanged("Lich");
        }
        
        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public partial class P_ChamCong : Page
    {
        public static List<ChamCongDS> _list = null;
        private static P_ChamCong _page = null;
        public static P_ChamCong getPage
        {
            get
            {
                if(_page == null)
                {
                    ChamCongList.AutoBC();
                    _page = new P_ChamCong();
                }
                return _page;
            }
        }

        public P_ChamCong()
        {
            InitializeComponent();
        }

        private int[] ConvertInt(List<vw_ChamCong> a, int sn)
        {
            int[] li = new int[sn];
            li = Enumerable.Repeat(0, sn).ToArray();
            foreach(vw_ChamCong i in a)
                li[i.NgayThu - 1] = i.TinhTrang;
            return li;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listBangLuong.ItemsSource = ChamCongList.getBC;
        }

        private void SeoSMonth(int m)
        {
            for(int i = 29; i < 33; i++)
            {
                if(i <= m + 1)
                    dataLich.Columns[i].Visibility = Visibility.Visible;
                else
                    dataLich.Columns[i].Visibility = Visibility.Hidden;
            }
        }

        private void kolich_Click(object sender, RoutedEventArgs e)
        {
            _list[dataLich.Items.IndexOf(dataLich.SelectedCells[0].Item)].UpdateLich(dataLich.SelectedCells[0].Column.DisplayIndex - 1, 0);
        }

        private void dilam_Click(object sender, RoutedEventArgs e)
        {
            _list[dataLich.Items.IndexOf(dataLich.SelectedCells[0].Item)].UpdateLich(dataLich.SelectedCells[0].Column.DisplayIndex - 1, 1);
        }

        private void nghi_Click(object sender, RoutedEventArgs e)
        {
            _list[dataLich.Items.IndexOf(dataLich.SelectedCells[0].Item)].UpdateLich(dataLich.SelectedCells[0].Column.DisplayIndex - 1, 2);
        }

        private void kophep_Click(object sender, RoutedEventArgs e)
        {
            _list[dataLich.Items.IndexOf(dataLich.SelectedCells[0].Item)].UpdateLich(dataLich.SelectedCells[0].Column.DisplayIndex - 1, 3);
        }

        private void dataLich_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(dataLich.SelectedCells.Count > 0 && dataLich.Items.IndexOf(dataLich.SelectedCells[0].Item) > -1 && dataLich.SelectedCells[0].Column.DisplayIndex > 1)
            {
                _list[dataLich.Items.IndexOf(dataLich.SelectedCells[0].Item)].UpdateLich(dataLich.SelectedCells[0].Column.DisplayIndex - 1);
            }
        }

        private void listBangLuong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listBangLuong.SelectedIndex != -1)
            {
                _list = ChamCongModel.LoadChamCong(((BangCong)listBangLuong.SelectedItem).MaBC).GroupBy(g => new { g.MaBC, g.MaCa, g.MaCong, g.MaNV, g.TenCa, g.TenNV }).ToList().ConvertAll(x => new ChamCongDS
                {
                    MaCong = x.Key.MaCong,
                    MaNV = x.Key.MaNV,
                    TenNV = x.Key.TenNV,
                    MaCa = x.Key.MaCa,
                    TenCa = x.Key.TenCa,
                    Lich = ConvertInt(x.ToList<vw_ChamCong>(), ((BangCong)listBangLuong.SelectedItem).SoNgay)
                });
                SeoSMonth(((BangCong)listBangLuong.SelectedItem).SoNgay);
                dataLich.ItemsSource = _list;
            }
        }

        private void dataLich_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(dataLich.SelectedCells.Count > 0 && dataLich.Items.IndexOf(dataLich.SelectedCells[0].Item) > -1 && dataLich.SelectedCells[0].Column.DisplayIndex > 1)
            {
                kolich.IsEnabled = dilam.IsEnabled = nghi.IsEnabled = kophep.IsEnabled = true;
            }
            else
            {
                kolich.IsEnabled = dilam.IsEnabled = nghi.IsEnabled = kophep.IsEnabled = false;
            }
        }
    }
}
