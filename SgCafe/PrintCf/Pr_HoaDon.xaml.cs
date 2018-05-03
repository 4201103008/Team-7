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

namespace PrintCf
{
    public class cvTinhTt : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format("{0:0.00}", ((int)values[0] * (decimal)values[1]));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Interaction logic for Pr_HoaDon.xaml
    /// </summary>
    public partial class Pr_HoaDon : Page
    {
        public Pr_HoaDon()
        {
            InitializeComponent();
        }

        public static void f_In(HoaDon hd, decimal khd, decimal tra)
        {
            using(null)
            {
                Pr_HoaDon _page = new Pr_HoaDon();
                _page.Page_Load(hd, khd, tra);
                PrintDialog a = new PrintDialog();
                a.PrintVisual(_page, "In Hóa Đơn");
            }
        }

        public void Page_Load(HoaDon hd, decimal khd, decimal tra)
        {
            TenQuan.Text = "Cafe " + informationQ._tenQuan;
            DiaChi.Text = "Địa chỉ: " + informationQ._diaChi;
            SDT.Text = "Điện thoại: " + informationQ._phone;
            SoHD.Text = "Số Hóa Đơn: " + string.Format("{0:000000000000000}", hd.SoHD);
            Ban.Text = "Bàn: " + hd.TenBan;
            ThuNgan.Text = "Thu ngân: " + NhanVienModel.getNameNv(hd.MaNV);
            Ngay.Text = "Ngày: " + onlyDate(hd.Ngay);
            GVao.Text = "Giờ vào: " + onlyTime(hd.GMo);
            GRa.Text = "Giờ ra: " + onlyTime(hd.GDong ?? DateTime.Now.TimeOfDay);
            TienNuoc.Text = string.Format("{0:0.00}", hd.TienNuoc);
            VAT.Text = hd.VAT.ToString();
            Giamgia.Text = hd.GiamGia.ToString();
            TongTien.Text = string.Format("{0:0.00}", hd.TongTien);
            Khachdua.Text = string.Format("{0:0.00}", khd);
            tralai.Text = string.Format("{0:0.00}", tra);
            Tiente.Text = informationQ._tienTe;
            dmThu.ItemsSource = MatHanginHoaDon.getList(hd.SoHD);
        }

        public static string onlyDate(DateTime ng)
        {
            if(ng == null)
                return "--/--/--";
            return ng.ToString("dd/MM/yyyy");
        }

        public static string onlyTime(TimeSpan ng)
        {
            if(ng == null)
                return "--:--:--";
            return string.Format("{0:D2}:{1:D2}:{2:D2}", ng.Hours, ng.Minutes, ng.Seconds);
        }
    }
}
