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
using System.Windows.Markup;
using System.IO;
using System.Xml;
using DataCf;
using InforCf;
using StyleCF;

namespace SgCafe.MainPanel
{
    /// <summary>
    /// Interaction logic for P_BaoCao.xaml
    /// </summary>
    public partial class P_BaoCao : Page
    {
        private static P_BaoCao _page = null;

        private P_BaoCao()
        {
            InitializeComponent();
        }

        public static P_BaoCao getPage
        {
            get
            {
                if (_page == null)
                    _page = new P_BaoCao();

                return _page;
            }
        }

        private void LoadND()
        {
            try
            {
                if (listBC.SelectedIndex != -1)
                {
                    BaoCaoList.isDoc(((vw_BaoCao)listBC.SelectedItem).MaBC);
                    tieude.Content = ((vw_BaoCao)listBC.SelectedItem).TieuDe;
                    nv.Content = NhanVienList.getName(((vw_BaoCao)listBC.SelectedItem).MaNV ?? null);
                    ngay.Content = ((vw_BaoCao)listBC.SelectedItem).NgayGio.ToString();
                    noiDung.Document = (FlowDocument)XamlReader.Load(new XmlTextReader(new StringReader(BaoCaoModel.DocND(((vw_BaoCao)listBC.SelectedItem).MaBC))));
                }
                else
                {
                    tieude.Content = string.Empty;
                    nv.Content = string.Empty;
                    ngay.Content = string.Empty;
                    noiDung.Document.Blocks.Clear();
                }
            }
            catch { }
        }

        private void listBC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listBC.SelectedIndex != -1)
            {
                xoa.IsEnabled = true;
            }
            else
            {
                xoa.IsEnabled = false;
            }
            LoadND();
        }

        private void XoaBC(decimal ma)
        {
            ThongBaoHT.f_ThongBao(BaoCaoList.DeleteBC(ma), "Xóa báo cáo");
            listBC.Items.Refresh();
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult _R = MessageBoxCF.Show("Xác nhận xóa báo cáo", "Bạn có chắc chắn muốn xóa báo cáo này không?", MessageBoxImage.Question, MessageBoxButton.YesNo);
            if (_R == MessageBoxResult.Yes)
                XoaBC(((BaoCao)listBC.SelectedItem).MaBC);
        }

        private void PaBC_Loaded(object sender, RoutedEventArgs e)
        {
            listBC.ItemsSource = BaoCaoList.getListV;
        }
    }
}
