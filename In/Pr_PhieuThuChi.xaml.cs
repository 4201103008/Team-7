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
    /// Interaction logic for Pr_PhieuChi.xaml
    /// </summary>
    public partial class Pr_PhieuThuChi : Page
    {
        public Pr_PhieuThuChi()
        {
            InitializeComponent();
        }

        public static void f_In(PhieuThuChi ptc, bool l)
        {
            using(null)
            {
                Pr_PhieuThuChi _page = new Pr_PhieuThuChi();
                _page.Page_Load(ptc, l);
                PrintDialog a = new PrintDialog();
                if(l)
                    a.PrintVisual(_page, "In Phiếu Chi");
                else
                    a.PrintVisual(_page, "In Phiếu Thu");
            }
        }

        private void Page_Load (PhieuThuChi ptc, bool loai)
        {
            TenQuan.Text = "Cafe " + informationQ._tenQuan;
            DiaChi.Text = "Địa chỉ: " + informationQ._diaChi;
            SDT.Text = "Điện thoại: " + informationQ._phone;
            TenQuan.Text = "Cafe " + informationQ._tenQuan;
            DiaChi.Text = "Địa chỉ: " + informationQ._diaChi;
            SDT.Text = "Điện thoại: " + informationQ._phone;
            DcNN.Text = "Địa chỉ: " + ptc.DiaChi;
            SoHD.Text = "Số Phiếu: " + string.Format("{0:0000000000}", ptc.SoPhieu);
            ThuNgan.Text = "Nhân viên: " + NhanVienModel.getNameNv(ptc.MaNV);
            Ngay.Text = "Ngày: " + onlyDate(ptc.Ngay);
            if(loai)
            {
                ten.Text = "Phiếu Chi Tiền";
                Lydo.Text = "Lý do chi: " + ptc.LyDo;
                NguoiNhan.Text = "Người nhận: " + ptc.NguoiNhan;
                nguoi.Text = "Người nhận";
                sotien.Text = "Số tiền chi:";
            }
            else
            {
                ten.Text = "Phiếu Thu Tiền";
                Lydo.Text = "Lý do thu: " + ptc.LyDo;
                NguoiNhan.Text = "Người nộp: " + ptc.NguoiNhan;
                nguoi.Text = "Người nộp";
                sotien.Text = "Số tiền thu:";
            }
            Tien.Text = string.Format("{0:0.00}", ptc.SoTien);
            NoiDung.Text = "Nội dung: " + ptc.NoiDung;
            donvi.Text = informationQ._tienTe;
        }

        public static string onlyDate(DateTime ng)
        {
            if(ng == null)
                return "--/--/--";
            return ng.ToString("dd/MM/yyyy");
        }
    }
}
