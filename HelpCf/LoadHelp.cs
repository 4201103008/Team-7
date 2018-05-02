using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Documents;

namespace HelpCf
{
    public class LoadHelp
    {
        private static List<HelpApp> _help = null;
        private static int _count { get; set; }

        private static void AddHelp(string ten, string dc)
        {
            _help.Add(new HelpApp(_count++, ten, dc));
        }

        private static void NapHelp()
        {
            _help = new List<HelpApp>();
            _count = 0;
            AddHelp("Giới thiệu", @"/HelpCf;component/Help/0Gioi_thieu/gioithieu.xaml");
            AddHelp("Làm quen với Sg Cafe", @"/HelpCf;component/Help/1Lam_quen/lamquen.xaml");
            AddHelp("Cài đặt", @"/HelpCf;component/Help/2Cai_dat/caidat.xaml");
            AddHelp("Quản lý bàn", @"/HelpCf;component/Help/3Ban/ban.xaml");
            AddHelp("Quản lý ca làm", @"/HelpCf;component/Help/4Ca_lam/calam.xaml");
            AddHelp("Quản lý chức vụ", @"/HelpCf;component/Help/5Chuc_vu/chucvu.xaml");
            AddHelp("Quản lý nhân viên", @"/HelpCf;component/Help/6Nhan_vien/nhanvien.xaml");
            AddHelp("Quản lý nhà cung cấp", @"/HelpCf;component/Help/7NhaCC/nhacc.xaml");
            AddHelp("Quản lý mặt hàng", @"/HelpCf;component/Help/8Mat_hang/mathang.xaml");
            AddHelp("Quản lý tài khoản", @"/HelpCf;component/Help/9Tai_khoan/taikhoan.xaml");
            AddHelp("Hóa đơn và bán hàng", @"/HelpCf;component/Help/10Hoa_don_ban_hang/hoadon.xaml");
            AddHelp("Phiếu nhập hàng", @"/HelpCf;component/Help/11Phieu_nhap_hang/phieunhap.xaml");
            AddHelp("Phiếu thu, phiếu chi", @"/HelpCf;component/Help/12Phieu_thu_chi/thuchi.xaml");
            AddHelp("Chấm công", @"/HelpCf;component/Help/13Cham_cong/chamcong.xaml");
            AddHelp("Trừ lương, ứng lương", @"/HelpCf;component/Help/14Tru_luong_ung_luong/truung.xaml");
            AddHelp("Tính lương cho nhân viên", @"/HelpCf;component/Help/15Tinh_luong/tinhluong.xaml");
            AddHelp("Báo cáo", @"/HelpCf;component/Help/16Bao_cao/baocao.xaml");
            AddHelp("Thông kê", @"/HelpCf;component/Help/17Thong_ke/thongke.xaml");
        }

        public static Uri FindH(int m)
        {
            if(_help.Any(x => x.ma == m))
                return _help.Find(x => x.ma == m).nd;
            return null;
        }

        public static FlowDocument loadHelp(int i)
        {
            return Application.LoadComponent(FindH(i)) as FlowDocument;
        }

        public static List<NameHelp> ListName
        {
            get
            {
                if(_help == null)
                    NapHelp();
                return _help.ConvertAll(x => new NameHelp { ma = x.ma, ten = x.ten }).ToList<NameHelp>();
            }
        }
        
        public static void GiaiPhong()
        {
            _help = null;
        }
    }
}
