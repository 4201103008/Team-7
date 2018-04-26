using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataCf;

namespace InforCf
{
    public class informationTk : Ktbit
    {
        private static string tenkt = string.Empty;
        private static string tennv = string.Empty;
        private static decimal manv;

        private static string matkhau = string.Empty;

        private static byte _tt = 0;

        private static byte _ql = 0;

        public static Window cs;

        public static string TenTaiKhoan
        {
            get
            {
                return tenkt;
            }
        }

        public static string TenNhanVien
        {
            get
            {
                return tennv;
            }
        }

        public static decimal MaNhanVien
        {
            get
            {
                return manv;
            }
        }

        public static bool qlNhanSu
        {
            get
            {
                return kiemTra(_ql, 0);
            }
            set
            {
                _ql = ganBit(_ql, 0, value);
            }
        }

        public static bool qlCaLamChucVu
        {
            get
            {
                return kiemTra(_ql, 1);
            }
            set
            {
                _ql = ganBit(_ql, 1, value);
            }
        }

        public static bool qlBan
        {
            get
            {
                return kiemTra(_ql, 2);
            }
            set
            {
                _ql = ganBit(_ql, 2, value);
            }
        }

        public static bool qlMatHangNhaCC
        {
            get
            {
                return kiemTra(_ql, 3);
            }
            set
            {
                _ql = ganBit(_ql, 3, value);
            }
        }

        public static bool qlThuChi
        {
            get
            {
                return kiemTra(_ql, 4);
            }
            set
            {
                _ql = ganBit(_ql, 4, value);
            }
        }

        public static bool qlBanHang
        {
            get
            {
                return kiemTra(_ql, 5);
            }
            set
            {
                _ql = ganBit(_ql, 5, value);
            }
        }

        public static bool qlNhapHang
        {
            get
            {
                return kiemTra(_ql, 6);
            }
            set
            {
                _ql = ganBit(_ql, 6, value);
            }
        }

        public static bool qlKhachHang
        {
            get
            {
                return kiemTra(_ql, 7);
            }
            set
            {
                _ql = ganBit(_ql, 7, value);
            }
        }

        public static bool dDangNhap
        {
            get
            {
                return kiemTra(_tt, 0);
            }
            set
            {
                _tt = ganBit(_tt, 0, value);
            }
        }

        public static bool isAd
        {
            get
            {
                return kiemTra(_tt, 1);
            }
            set
            {
                _tt = ganBit(_tt, 1, value);
            }
        }

        public static void dangxuattk()
        {
            tenkt = string.Empty;
            tennv = string.Empty;
            matkhau = string.Empty;
            _tt = 0;
            _ql = 0;
        }

        public static bool dangnhaptk(string ten, string mk)
        {
            if (TaiKhoanModel.KiemTrefMK(ten, mk, ref tenkt, ref tennv, ref _ql, ref manv))
            {
                matkhau = mk;

                if (ten == "Administrator")
                    isAd = true;
                else
                    isAd = false;

                dDangNhap = true;

                return true;
            }
            return false;
        }

        public static bool doimk(string mk)
        {
            bool t = TaiKhoanModel.DoiMk(tenkt, mk);

            if(t) matkhau = mk;

            return t;
        }

        public static bool kt_matKhau(string mk)
        {
            if (matkhau == mk)
                return true;
            else
                return false;
        }
    }
}