using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCf;

namespace InforCf
{
    public class PhieuNhapList
    {
        private static List<PhieuNhap> _listPN = null;

        public static List<PhieuNhap> getList
        {
            get
            {
                if(_listPN == null)
                    _listPN = PhieuNhapModel.LoadDP();

                return _listPN;
            }
        }
        

        public static bool AddPhieu(decimal mancc, decimal tt, bool tr, List<DataCf.pnSapNhap> s)
        {
            PhieuNhap pn = new PhieuNhap();

            pn.TrangThai = tr;
            pn.MaNCC = mancc;
            pn.NgayLap = DateTime.Now.Date;
            pn.MaNV = informationTk.MaNhanVien;

            if(PhieuNhapModel.ThemRef(ref pn, s.Cast<pnSapNhap>().ToList()))
            {
                pn.TongTien = tt;
                if(_listPN != null)
                    _listPN.Insert(0, pn);
                return true;
            }
            return false;
        }

        public static PhieuNhap AddBack(decimal mancc, decimal tt, List<pnSapNhap> s)
        {
            PhieuNhap pn = new PhieuNhap();

            pn.TrangThai = true;
            pn.MaNCC = mancc;
            pn.NgayLap = DateTime.Now.Date;
            pn.MaNV = informationTk.MaNhanVien;

            if(PhieuNhapModel.ThemRef(ref pn, s.Cast<pnSapNhap>().ToList()))
            {
                pn.TongTien = tt;
                if(_listPN != null)
                    _listPN.Insert(0, pn);
                return pn;
            }
            return null;
        }

        public static bool EditPN(decimal so, bool tt, decimal ma, decimal ti, List<pnSapNhap> s)
        {
            if(PhieuNhapModel.SuaP(so, tt, ma, s))
            {
                PhieuNhap p = _listPN.FirstOrDefault(x => x.SoPhieu == so);
                p.TrangThai = tt;
                p.MaNCC = ma;
                p.TongTien = ti;

                return true;
            }
            return false;
        }

        public static PhieuNhap EditBack(decimal so, decimal ma, decimal ti, List<pnSapNhap> s)
        {
            if(PhieuNhapModel.SuaP(so, true, ma, s))
            {
                PhieuNhap p = _listPN.FirstOrDefault(x => x.SoPhieu == so);
                p.TrangThai = true;
                p.MaNCC = ma;
                p.TongTien = ti;

                return p;
            }
            return null;
        }

        public static bool DeleteP(decimal so)
        {
            if(PhieuNhapModel.Xoa(so))
            {
                _listPN.RemoveAt(_listPN.FindIndex(x => x.SoPhieu == so));

                return true;
            }
            return false;
        }

        public static bool ClearPN(DateTime n)
        {
            if(_listPN != null)
            {
                List<decimal> de = PhieuNhapModel.ClearRtu(n);
                foreach(decimal d in de)
                {
                    _listPN.RemoveAt(_listPN.FindIndex(x => x.SoPhieu == d));
                }
                if(de.Count > 0)
                    return true;
                else
                    return false;
            }
            else
                return PhieuNhapModel.ClearnotR(n);
        }
    }
}
