using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Windows;
using System.Transactions;

namespace DataCf
{
    public class CaLamModel : CFConnectinString
    {
        public static bool AddCa(string tenCa, System.TimeSpan batDau, System.TimeSpan ketThuc, string ghiChu)
        {
            Ca st = new Ca();
            st.TenCa = tenCa;
            st.BatDau = batDau;
            st.KetThuc = ketThuc;
            st.GhiChu = ghiChu;

            try
            {
                db.Cas.InsertOnSubmit(st);
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool AddRef(ref Ca st)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    db.Cas.InsertOnSubmit(st);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static bool CheckTen(string ten)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return (from p in db.Cas
                        where p.TenCa == ten
                        select p).Count() > 0;
            }
        }

        public static bool CheckTED(int maC, string ten)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return (from p in db.Cas
                        where p.MaCa != maC && p.TenCa == ten
                        select p).Count() > 0;
            }
        }

        public static bool CheckTrL(TimeSpan d, TimeSpan c)
        {
            return db.ft_KtraTGCa(d, c);
        }

        public static bool CheckTrK(TimeSpan d, TimeSpan c)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return (from p in db.Cas
                        where d <= p.KetThuc && c >= p.BatDau
                        select p).Count() > 0;
            }
        }

        public static bool CheckTrC(int maC, TimeSpan d, TimeSpan c)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return (from p in db.Cas
                        where p.MaCa != maC && d <= p.KetThuc && c >= p.BatDau
                        select p).Count() > 0;
            }
        }

        public static int CheckLamCa(int maCa)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    return (from p in db.Lams
                            where p.MaCa == maCa
                            select p).Count();
                }
                catch
                {
                    return -1;
                }
            }
        }

        public static int CheckCong(int maCa)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    int c = (from p in db.ChamCongs
                              where p.MaCa == maCa && p.TinhTrang != 0
                              select p).Count();
                    if(c == 0 && db.ChamCongs.Any(x => x.MaCa == maCa))
                        c = -1;
                    return c;
                }
                catch
                {
                    return -2;
                }
            }
        }

        public static bool DeleteCaBC(int maCa)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                IEnumerable<Lam> l = from p in db.Lams
                                     where p.MaCa == maCa
                                     select p;
                IEnumerable<ChamCong> h = from p in db.ChamCongs
                                          where p.MaCa == maCa
                                          select p;
                Ca c = db.Cas.Single(x => x.MaCa == maCa);

                bool rt = true;

                using(var tran = new TransactionScope())
                {
                    try
                    {
                        db.Lams.DeleteAllOnSubmit(l);
                        db.ChamCongs.DeleteAllOnSubmit(h);
                        db.Cas.DeleteOnSubmit(c);
                        db.SubmitChanges();
                    }
                    catch
                    {
                        rt = false;
                    }
                    tran.Complete();
                }

                return rt;
            }
        }

        public static bool DeleteCa(int maCa)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                Ca c = db.Cas.Single(x => x.MaCa == maCa);

                try
                {
                    db.Cas.DeleteOnSubmit(c);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static List<Ca> LoadCa()
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                IEnumerable<Ca> a = from p in db.Cas
                                    select p;

                return a.ToList<Ca>();
            }
        }

        public static bool UpCa(int maCa, string tenCa, System.TimeSpan batDau, System.TimeSpan ketThuc, string ghiChu)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                Ca st = db.Cas.Single(x => x.MaCa == maCa);

                st.TenCa = tenCa;
                st.BatDau = batDau;
                st.KetThuc = ketThuc;
                st.GhiChu = ghiChu;

                try
                {
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static List<Ca> LoadCaNV(decimal maNV)
        {
            IEnumerable<Ca> a = from p in db.NhanViens
                                join q in db.Lams on p.MaNV equals q.MaNV
                                join f in db.Cas on q.MaCa equals f.MaCa
                                where p.MaNV == maNV
                                select f;

            return a.ToList<Ca>();
        }

        public static bool UpLich(decimal maNV, int maCa, byte Ln)
        {
            Lam lm = db.Lams.Single(x => x.MaCa == maCa && x.MaNV == maNV);

            lm.LN = Ln;

            try
            {
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool ThemLich(decimal maNV, int maCV, byte LN)
        {
            Lam st = new Lam();

            st.MaNV = maNV;
            st.MaCa = maCV;
            st.LN = LN;

            try
            {
                db.Lams.InsertOnSubmit(st);
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static List<vw_LichLam> LoadLich(decimal maNV)
        {
            IEnumerable<vw_LichLam> a = from p in db.vw_LichLams
                                        where p.MaNV == maNV
                                        select p;

            return a.ToList<vw_LichLam>();
        }

        public static List<vw_LichLam> LoadLichA()
        {
            IEnumerable<vw_LichLam> a = from p in db.vw_LichLams
                                        select p;

            return a.ToList<vw_LichLam>();
        }

        public static bool XoaLich(decimal maNV, int maCa)
        {
            Lam lm = db.Lams.Single(x => x.MaCa == maCa && x.MaNV == maNV);

            try
            {
                db.Lams.DeleteOnSubmit(lm);
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
     }
}
