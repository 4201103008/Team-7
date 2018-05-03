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

namespace PrintCf
{
    /// <summary>
    /// Interaction logic for Pr_PhieuNhap.xaml
    /// </summary>
    public partial class Pr_PhieuNhap : Page
    {
        public Pr_PhieuNhap()
        {
            InitializeComponent();
        }

        public static void f_In(PhieuNhap hd, List<pnSapNhap> ds)
        {
            Pr_PhieuNhap _page = new Pr_PhieuNhap();
            _page.Page_Load(hd, ds);
            PrintDialog a = new PrintDialog();
            a.PrintVisual(_page, "In Phiếu Nhập");
        }

        public void Page_Load(PhieuNhap hd, List<pnSapNhap> ds)
        {
            TenQuan.Text = "Cafe " + informationQ._tenQuan;
            NhaCC.Text = "Nhà cung cấp: " + NhaCCList.getName(hd.MaNCC);
            DiaChi.Text = "Địa chỉ: " + informationQ._diaChi;
            SDT.Text = "Điện thoại: " + informationQ._phone;
            SoHD.Text = "Số Phiếu: " + string.Format("{0:000000000000000}", hd.SoPhieu);
            ThuNgan.Text = "Thu ngân: " + NhanVienModel.getNameNv(hd.MaNV);
            Ngay.Text = "Ngày: " + onlyDate(hd.NgayLap);
            TongTien.Text = string.Format("{0:0.00}", hd.TongTien);
            Tiente.Text = informationQ._tienTe;
            dmThu.ItemsSource = ds;
        }

        public static string onlyDate(DateTime ng)
        {
            if(ng == null)
                return "--/--/--";
            return ng.ToString("dd/MM/yyyy");
        }
    }
}
