using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCf;

namespace InforCf
{
    public class HoaDonList
    {
        private static List<HoaDon> _listH = null;

        public static List<HoaDon> getList
        {
            get
            {
                if(_listH == null)
                    _listH = HoaDonModel.LoadHD();

                return _listH;
            }
        }

        public static IEnumerable<HoaDon> getFNow
        {
            get
            {
                if(_listH == null)
                    _listH = HoaDonModel.LoadHD();

                return from p in _listH
                       where p.TrangThai == 1 && p.Ngay.Date == DateTime.Now.Date
                       select p;
            }
        }

        public static HoaDon getHD(decimal so)
        {
            if(_listH == null)
                _listH = HoaDonModel.LoadHD();

            return _listH.Find(x => x.SoHD == so);
        }

        public static HoaDon AddHD(string ban)
        {
            HoaDon hd = new HoaDon();

            hd.Ngay = DateTime.Now.Date;
            hd.GMo = DateTime.Now.TimeOfDay;
            hd.TrangThai = 0;
            hd.TienNuoc = 0;
            hd.TongTien = 0;
            hd.VAT = informationQ._thueVAT;
            hd.GiamGia = informationQ._giamGia;
            hd.TenBan = ban;
            hd.MaNV = informationTk.MaNhanVien;

            if(HoaDonModel.ThemRef(ref hd))
            {
                _listH.Insert(0, hd);
                BanList.OpenBan(ban, hd.SoHD);
                MatHanginHoaDon.setHD(hd.SoHD);
                return hd;
            }

            return null;
        }

        public static bool AddMH(decimal shd, decimal ma, int sl)
        {
            if(MatHanginHoaDon.AddMH(shd, ma, sl))
            {
                HoaDon hd = _listH.FirstOrDefault(x => x.SoHD == shd);
                hd.TienNuoc += sl * MatHangList.getGiaBan(ma);
                decimal u = (100 - (decimal)hd.GiamGia) / 100;
                decimal v = ((decimal)hd.VAT + 100) / 100;
                hd.TongTien = (hd.TienNuoc * u)*v;

                return true;
            }
            return false;
        }
        
        public static bool GiamMH(decimal shd, decimal ma, int sl)
        {
            int? t = MatHanginHoaDon.VinegarHD(shd, ma, sl);

            if(t == null)
                return false;
            else
            {
                HoaDon hd = _listH.FirstOrDefault(x => x.SoHD == shd);

                if(t > 0)
                    hd.TienNuoc -= sl * MatHangList.getGiaBan(ma);
                else
                    hd.TienNuoc -= (sl + (t ?? 0)) * MatHangList.getGiaBan(ma);
                
                decimal u = (100 - (decimal)hd.GiamGia) / 100;
                decimal v = ((decimal)hd.VAT + 100) / 100;
                hd.TongTien = (hd.TienNuoc * u) * v;
            }
            return true;
        }

        public static bool XoaMH(decimal shd, decimal ma)
        {
            int? t = MatHanginHoaDon.DeleteHD(shd, ma);

            if(t == null)
                return false;
            else
            {
                HoaDon hd = _listH.FirstOrDefault(x => x.SoHD == shd);

                hd.TienNuoc -= ((decimal)t) * MatHangList.getGiaBan(ma);
                
                decimal u = (100 - (decimal)hd.GiamGia) / 100;
                decimal v = ((decimal)hd.VAT + 100) / 100;
                hd.TongTien = (hd.TienNuoc * u) * v;
            }
            return true;
        }
        
        public static bool ChuyenBan(string bc, string ct)
        {
            if(BanList.ChuyenBan(bc, ct))
            {
                HoaDon hd = _listH.FirstOrDefault(x => x.TenBan == bc);
                hd.TenBan = ct;

                return true;
            }

            return false;
        }
        
        public static bool EditGG(decimal sh, byte gg)
        {
            if(HoaDonModel.CheckGG(sh, gg))
            {
                HoaDon hd = _listH.FirstOrDefault(x => x.SoHD == sh);
                hd.GiamGia = gg;
                decimal u = (100 - (decimal)gg) / 100;
                decimal v = ((decimal)hd.VAT + 100) / 100;
                hd.TongTien = (hd.TienNuoc * u) * v;
            }
            return true;
        }
        
        public static bool GopBan(string bc, string ct)
        {
            decimal? fto = null;
            decimal? fro = null;
            if(HoaDonModel.NewGopBan(bc, ct, ref fto, ref fro))
            {
                if(fto == null || fro == null)
                    return false;

                HoaDon hdi = _listH.FirstOrDefault(x => x.SoHD == fro);
                HoaDon hde = _listH.FirstOrDefault(x => x.SoHD == fto);

                hde.TienNuoc += hdi.TienNuoc;
                decimal u = (100 - (decimal)hde.GiamGia) / 100;
                decimal v = ((decimal)hde.VAT + 100) / 100;
                hde.TongTien = (hde.TienNuoc * u) * v;
                BanList.tatBan = bc;
                MatHanginHoaDon.clearH = hdi.SoHD;
                _listH.Remove(hdi);

                return true;
            }

            return false;
        }

        public static bool ThanhToan(decimal so)
        {
            if(HoaDonModel.DongBanHD(so))
            {
                HoaDon hd = _listH.FirstOrDefault(x => x.SoHD == so);
                hd.TrangThai = 1;
                hd.GDong = DateTime.Now.TimeOfDay;
                BanList.tatBan = hd.TenBan;

                return true;
            }
            return false;
        }

        public static bool HuyHD(decimal so)
        {
            if(HoaDonModel.XoaHD(so))
            {
                HoaDon hd = _listH.FirstOrDefault(x => x.SoHD == so);
                BanList.tatBan = hd.TenBan;
                _listH.Remove(hd);
                MatHanginHoaDon.HuyHD(so);
                return true;
            }
            return false;
        }

        public static bool ClearHD(DateTime n)
        {
            if(_listH != null)
            {
                List<decimal> de = HoaDonModel.ClearRtu(n);
                foreach(decimal d in de)
                {
                    _listH.RemoveAt(_listH.FindIndex(x => x.SoHD == d));
                }
                if(de.Count > 0)
                    return true;
                else
                    return false;
            }
            else
                return HoaDonModel.ClearnotR(n);
        }
    }
}
