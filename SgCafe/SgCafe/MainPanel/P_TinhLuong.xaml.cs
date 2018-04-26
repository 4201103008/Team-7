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

namespace SgCafe.MainPanel
{
    /// <summary>
    /// Interaction logic for P_TinhLuong.xaml
    /// </summary>
    public partial class P_TinhLuong : Page
    {
        private List<ft_TinhLuongResult> _listTL = null;
        private static P_TinhLuong _page = null;
        public P_TinhLuong()
        {
            InitializeComponent();
        }

        public static P_TinhLuong getPage
        {
            get
            {
                if(_page == null)
                    _page = new P_TinhLuong();
                return _page;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listBangLuong.ItemsSource = ChamCongList.getBC;
        }

        private void listBangLuong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listBangLuong.SelectedIndex != -1)
            {
                _listTL = TienCongModel.ftTinhLuong(((BangCong)listBangLuong.SelectedItem).MaBC);
                listTL.ItemsSource = _listTL;
                tongluong.Text = string.Format("{0:0.00}", _listTL.Sum(x => x.TienLuong));
            }
        }
    }
}
