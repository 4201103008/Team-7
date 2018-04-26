using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace DataCf
{
    public class PhieuThuChiModel : CFConnectinString
    {
        public static List<PhieuThuChi> LoadPhieu()
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return (from pc in db.PhieuThuChis
                        orderby pc.Ngay descending
                        select pc).ToList<PhieuThuChi>();
            }
        }

        public static List<vw_PhieuChi> LoadPhieuChi()
        {
            IEnumerable<vw_PhieuChi> p = from pc in db.vw_PhieuChis
                                         select pc;

            return p.ToList<vw_PhieuChi>();
        }

        public static List<vw_PhieuThu> LoadPhieuThu()
        {
            IEnumerable<vw_PhieuThu> q = from pt in db.vw_PhieuThus
                                         select pt;

            return q.ToList<vw_PhieuThu>();
        }

        public static List<PhieuThuChi> Doc(decimal soP)
        {
            var tc = from sop in db.PhieuThuChis
                     where sop.SoPhieu.Equals(soP)
                     select sop;
            return tc.ToList<PhieuThuChi>();
        }

        public static bool SuaPhieu(decimal soP, string lydo, string noidung, string nguoinhan, string diachi, decimal sotien, decimal manv)
        {
            var a = from s in db.PhieuThuChis
                    where s.SoPhieu.Equals(soP)
                    select s;
            try
            {
                foreach(var s in a)
                {
                    s.LyDo = lydo;
                    s.NoiDung = noidung;
                    s.NguoiNhan = nguoinhan;
                    s.DiaChi = diachi;
                    s.SoTien = sotien;
                    s.MaNV = manv;
                    db.SubmitChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static Decimal TkChi(DateTime dau, DateTime cuoi)
        {
            var a = from ptc in db.PhieuThuChis
                    where ptc.Ngay >= dau && ptc.Ngay <= cuoi && ptc.Loai == true
                    select ptc;
            decimal tong = 0;
            foreach(var t in a)
            {
                tong += t.SoTien;
            }
            return tong;
        }

        public static Decimal TkThu(DateTime dau, DateTime cuoi)
        {
            var a = from ptc in db.PhieuThuChis
                    where ptc.Ngay >= dau && ptc.Ngay <= cuoi && ptc.Loai == false
                    select ptc;

            decimal tong = 0;

            foreach(var t in a)
            {
                tong += t.SoTien;
            }
            return tong;
        }

        public static bool ThemPhieu(bool loai, string lydo, string noidung, string nguoinhan, string diachi, decimal sotien, decimal manv)
        {
            PhieuThuChi ptc = new PhieuThuChi();
            ptc.Loai = loai;
            ptc.LyDo = lydo;
            ptc.NoiDung = noidung;
            ptc.NguoiNhan = nguoinhan;
            ptc.DiaChi = diachi;
            ptc.SoTien = sotien;
            ptc.MaNV = manv;
            try
            {
                db.PhieuThuChis.InsertOnSubmit(ptc);
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool AddRef(ref PhieuThuChi ptc)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    db.PhieuThuChis.InsertOnSubmit(ptc);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static bool XoaPhieu(decimal soPhieu)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    PhieuThuChi xoa = db.PhieuThuChis.Single(x => x.SoPhieu == soPhieu);
                    db.PhieuThuChis.DeleteOnSubmit(xoa);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static List<decimal> ClearRtu(DateTime n)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    IEnumerable<PhieuThuChi> hd = from p in db.PhieuThuChis
                                                  where p.Ngay < n
                                                  select p;
                    List<decimal> de = hd.ToList().ConvertAll(x => x.SoPhieu);
                    db.PhieuThuChis.DeleteAllOnSubmit(hd);
                    db.SubmitChanges();
                    return de;
                }
                catch
                {
                    return null;
                }
            }
        }

        public static bool ClearnotR(DateTime n)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                bool b = false;
                try
                {
                    IEnumerable<PhieuThuChi> hd = from p in db.PhieuThuChis
                                                  where p.Ngay < n
                                                  select p;
                    if(hd != null)
                        b = true;
                    db.PhieuThuChis.DeleteAllOnSubmit(hd);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return b;
            }
        }
    }
}