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
using StyleCF;

namespace PrintCf
{
    /// <summary>
    /// Interaction logic for Pr_YeuCauTT.xaml
    /// </summary>
    public partial class Pr_YeuCauTT : Page
    {
        public Pr_YeuCauTT()
        {
            InitializeComponent();
        }

        public void Page_Load(HoaDon hd, decimal khd, decimal tra)
        {
            TenQuan.Text = "Cafe " + informationQ._tenQuan;
            DiaChi.Text = "Địa chỉ: " + informationQ._diaChi;
            SDT.Text = "Điện thoại: " + informationQ._phone;
            Ban.Text = "Bàn: " + hd.TenBan;
            ThuNgan.Text = "Thu ngân: " + NhanVienModel.getNameNv(hd.MaNV);
            Ngay.Text = onlyDate(hd.Ngay);
            GVao.Text = onlyTime(hd.GMo);
            TienNuoc.Text = string.Format("{0:0.00}", hd.TienNuoc);
            VAT.Text = hd.VAT.ToString();
            Giamgia.Text = hd.GiamGia.ToString();
            TongTien.Text = string.Format("{0:0.00}", hd.TongTien);
            Tiente.Text = informationQ._tienTe;
            dataGrid.ItemsSource = MatHanginHoaDon.getList(hd.SoHD);
        }

        public string onlyDate(DateTime ng)
        {
            if(ng == null)
                return "--/--/--";
            return ng.ToString("dd/MM/yyyy");
        }

        public string onlyTime(TimeSpan ng)
        {
            if(ng == null)
                return "--:--:--";
            return string.Format("{0:D2}:{1:D2}:{2:D2}", ng.Hours, ng.Minutes, ng.Seconds);
        }
    }
}
