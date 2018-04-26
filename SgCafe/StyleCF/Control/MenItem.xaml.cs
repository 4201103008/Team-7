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

namespace StyleCF.Control
{
    public enum mnloai
    {
        banhang,
        phieunhap,
        chamcong,
        thongke,
        mathang,
        nhanvien,
        thuchi,
        tinhluong,
        taikhoan,
        nhacc,
        hoadon
    }

    public partial class MenItem : UserControl
    {
        private mnloai _l;
        private string _t;

        public string tieude
        {
            get
            {
                return _t;
            }
            set
            {
                ten.Text = value;
                _t = value;
            }
        }

        public mnloai loai
        {
            get
            {
                return _l;
            }
            set
            {
                _l = value;
                BitmapImage _anh = new BitmapImage();
                _anh.BeginInit();
                switch (value)
                {
                    case mnloai.banhang:
                        _anh.UriSource = new Uri("/StyleCF;component/Icon/menuntg/BanHang.png", UriKind.Relative);
                        break;
                    case mnloai.chamcong:
                        _anh.UriSource = new Uri("/StyleCF;component/Icon/menuntg/ChamCong.png", UriKind.Relative);
                        break;
                    case mnloai.hoadon:
                        _anh.UriSource = new Uri("/StyleCF;component/Icon/menuntg/sach.png", UriKind.Relative);
                        break;
                    case mnloai.mathang:
                        _anh.UriSource = new Uri("/StyleCF;component/Icon/menuntg/MatHang.png", UriKind.Relative);
                        break;
                    case mnloai.nhacc:
                        _anh.UriSource = new Uri("/StyleCF;component/Icon/menuntg/NhapHang.png", UriKind.Relative);
                        break;
                    case mnloai.nhanvien:
                        _anh.UriSource = new Uri("/StyleCF;component/Icon/menuntg/NhanVien.jpg", UriKind.Relative);
                        break;
                    case mnloai.phieunhap:
                        _anh.UriSource = new Uri("/StyleCF;component/Icon/menuntg/NhaCC.jpg", UriKind.Relative);
                        break;
                    case mnloai.taikhoan:
                        _anh.UriSource = new Uri("/StyleCF;component/Icon/menuntg/TruLuong.png", UriKind.Relative);
                        break;
                    case mnloai.thongke:
                        _anh.UriSource = new Uri("/StyleCF;component/Icon/menuntg/TinhLuong.jpg", UriKind.Relative);
                        break;
                    case mnloai.thuchi:
                        _anh.UriSource = new Uri("/StyleCF;component/Icon/menuntg/ThuChi.png", UriKind.Relative);
                        break;
                    default: //tinhluong
                        _anh.UriSource = new Uri("/StyleCF;component/Icon/menuntg/NhanVien.jpg", UriKind.Relative);
                        break;
                }
                _anh.EndInit();
                this.hinh.Source = _anh;
            }
        }

        public MenItem()
        {
            InitializeComponent();
        }
    }
}
