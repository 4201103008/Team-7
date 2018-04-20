using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCf;

namespace InforCf
{
    public class MatHanginHoaDon
    {
        private static List<vw_BanHang> _listBH = null;
        private static decimal? _sohd = null;

        public static List<vw_BanHang> getList(decimal ma)
        {
            if(_sohd != ma)
            {
                _listBH = HoaDonModel.LoadDU(ma);
                _sohd = ma;
            }

            return _listBH;
        }

        public static decimal clearH
        {
            set
            {
                if(_sohd == value)
                {
                    _listBH = null;
                    _sohd = null;
                }
            }
        }

        public static bool HuyHD(decimal so)
        {
            clearH = so;
            return true;
        }

        public static void setHD(decimal so)
        {
            _sohd = so;
            _listBH = new List<vw_BanHang>();
        }

        public static bool AddMH(decimal shd, decimal ma, int sl)
        {
            if(HoaDonModel.ThemDU(shd, ma, sl))
            {
                if(_sohd != shd)
                {
                    _listBH = HoaDonModel.LoadDU(shd);
                    _sohd = shd;
                }

                vw_BanHang m = _listBH.FirstOrDefault(x => x.MaHang == ma);

                if(m == null)
                {
                    MatHang h = MatHangList.getListSP.Single(x => x.MaHang == ma);

                    m = new vw_BanHang()
                    {
                        MaHang = ma,
                        TenHang = h.TenHang,
                        GiaBan = h.GiaBan,
                        SoHD = shd,
                        SoLuong = sl,
                        DonViTinh = h.DonViTinh
                    };

                    _listBH.Add(m);
                }
                else
                    m.SoLuong += sl;

                return true;
            }
            return false;
        }

        public static int? VinegarHD(decimal sh, decimal ma, int sl)
        {
            if(HoaDonModel.GiamDU(sh, ma, sl))
            {
                if(_sohd != sh)
                {
                    _listBH = HoaDonModel.LoadDU(sh);
                    _sohd = sh;
                }

                vw_BanHang m = _listBH.FirstOrDefault(x => x.MaHang == ma);

                int temp = m.SoLuong - sl;
                if(temp <= 0)
                    _listBH.Remove(m);
                else
                    m.SoLuong = temp;
                return temp;
            }
            return null;
        }

        public static int? DeleteHD(decimal sh, decimal ma)
        {
            if(HoaDonModel.XoaDU(sh, ma))
            {
                if(_sohd != sh)
                {
                    _listBH = HoaDonModel.LoadDU(sh);
                    _sohd = sh;
                }

                vw_BanHang m = _listBH.FirstOrDefault(x => x.MaHang == ma);
                if(m == null)
                    return null;
                int temp = m.SoLuong;
                _listBH.Remove(m);

                return temp;
            }
            return null;
        }
    }
}
