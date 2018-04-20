using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCf;

namespace InforCf
{
    public class informationQ
    {
        private static string _tq = HangSoModel.Doc("TenQuan");
        private static string _dc = HangSoModel.Doc("DiaChi");
        private static string _sdt = HangSoModel.Doc("SDT");
        private static byte _vat = byte.Parse(HangSoModel.Doc("VAT"));
        private static byte _gg = byte.Parse(HangSoModel.Doc("GiamGia"));
        private static byte _ac = byte.Parse(HangSoModel.Doc("AutoClear"));
        private static bool _nkpt = byte.Parse(HangSoModel.Doc("NKPTruTheo")) == 1 ? true : false;
        private static decimal _tkp = decimal.Parse(HangSoModel.Doc("TruKoPhep"));
        private static string _tt = HangSoModel.Doc("TienTe");
        private static bool _tb = byte.Parse(HangSoModel.Doc("ThongBao")) == 1 ? true : false;

        public static string _tenQuan
        {
            get
            {
                return _tq;
            }
            set
            {
                if (_tq != value)
                    if (HangSoModel.UpHs("TenQuan", value))
                        _tq = value;
            }
        }

        public static string _diaChi
        {
            get
            {
                return _dc;
            }
            set
            {
                if (_dc != value)
                    if (HangSoModel.UpHs("DiaChi", value))
                        _dc = value;
            }
        }

        public static string _phone
        {
            get
            {
                return _sdt;
            }
            set
            {
                if (_sdt != value)
                    if (HangSoModel.UpHs("SDT", value))
                        _sdt = value;
            }
        }

        public static byte _thueVAT
        {
            get
            {
                return _vat;
            }
            set
            {
                if (_vat != value)
                    if (HangSoModel.UpHs("VAT", value.ToString()))
                        _vat = value;
            }
        }

        public static byte _giamGia
        {
            get
            {
                return _gg;
            }
            set
            {
                if (_gg != value)
                    if (HangSoModel.UpHs("GiamGia", value.ToString()))
                        _gg = value;
            }
        }

        public static byte _autoClear
        {
            get
            {
                return _ac;
            }
            set
            {
                if (_ac != value)
                    if (HangSoModel.UpHs("AutoClear", value.ToString()))
                        _ac = value;
            }
        }

        public static bool _nkpTruTheo
        {
            get
            {
                return _nkpt;
            }
            set
            {
                if (_nkpt != value)
                    if (HangSoModel.UpHs("NKPTruTheo", value == true ? "1" : "0"))
                        _nkpt = value;
            }
        }

        public static bool _thongBao
        {
            get
            {
                return _tb;
            }
            set
            {
                if (_tb != value)
                    if (HangSoModel.UpHs("ThongBao", value == true ? "1" : "0"))
                        _tb = value;
            }
        }

        public static decimal _truKoPhep
        {
            get
            {
                return _tkp;
            }
            set
            {
                if (_tkp != value)
                    if (HangSoModel.UpHs("TruKoPhep", value.ToString()))
                        _tkp = value;
            }
        }

        public static string _tienTe
        {
            get
            {
                return _tt;
            }
            set
            {
                if (_tt != value)
                    if (HangSoModel.UpHs("TienTe", value))
                        _tt = value;
            }
        }
    }
}