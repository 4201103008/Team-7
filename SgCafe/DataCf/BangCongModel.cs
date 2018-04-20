using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCf
{
    public class BangCongModel : CFConnectinString
    {
        public static BangCong DocBC(decimal mabc)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                BangCong a = db.BangCongs.Single(k => k.MaBC == mabc);
                return a;
            }
        }

        public static bool ThemBC(byte th, int na)
        {
            BangCong a = new BangCong();
            a.Thang = th;
            a.Nam = na;
            a.SoNgay = 0;
            a.LuongPhaiTra = 0;
            try
            {
                db.BangCongs.InsertOnSubmit(a);
                db.SubmitChanges();
            }
            catch(Exception)
            {
                return false;

            }
            return true;
        }

        public static bool AutoAFBC(List<NhanVien> nv, List<Ca> cl, ref BangCong a)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    int mo = DateTime.Now.Month;
                    int ye = DateTime.Now.Year;
                    if(!db.BangCongs.Any(x => x.Thang == mo && x.Nam == ye))
                    {
                        a.Thang = (byte)mo;
                        a.Nam = ye;
                        a.SoNgay = 0;
                        a.LuongPhaiTra = 0;
                        db.BangCongs.InsertOnSubmit(a);
                        db.SubmitChanges();

                        foreach(NhanVien n in nv)
                        {
                            TienCong tc = new TienCong();
                            tc.MaNV = n.MaNV;
                            tc.MaBC = a.MaBC;
                            tc.TienCongLam = 0;
                            tc.TienTru = 0;
                            tc.TienLuong = 0;
                            tc.TinhTrang = false;
                            db.TienCongs.InsertOnSubmit(tc);
                            db.SubmitChanges();
                            foreach(Ca c in cl)
                            {
                                ChamCong cal = new ChamCong();
                                cal.MaCong = tc.MaCong;
                                cal.MaCa = c.MaCa;
                                cal.NgayThu = 1;
                                cal.TinhTrang = 0;
                                db.ChamCongs.InsertOnSubmit(cal);
                                db.SubmitChanges();
                            }
                        }
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
                return false;
            }
        }

        public static bool AutoCa(int mac)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    int mo = DateTime.Now.Month;
                    int ye = DateTime.Now.Year;
                    if(db.BangCongs.Any(x => x.Thang == mo && x.Nam == ye))
                    {
                        BangCong bc = db.BangCongs.Single(x => x.Thang == mo && x.Nam == ye);
                        IEnumerable<TienCong> tc = from p in db.TienCongs
                                                   where p.MaBC == bc.MaBC
                                                   select p;
                        foreach(TienCong n in tc)
                        {
                            ChamCong cal = new ChamCong();
                            cal.MaCong = n.MaCong;
                            cal.MaCa = mac;
                            cal.NgayThu = 1;
                            cal.TinhTrang = 0;

                            db.ChamCongs.InsertOnSubmit(cal);
                        }

                        db.SubmitChanges();
                        return false;
                    }
                }
                catch { }
                return true;
            }
        }

        public static bool ThemFB(byte th, int na) //sai
        {
            BangCong a = new BangCong();
            a.Thang = th;
            a.Nam = na;
            a.SoNgay = 0;
            a.LuongPhaiTra = 0;
            var c = from k in db.NhanViens where k.Xoa == false select k;
            NhanVien d = db.NhanViens.Single(i => i.Xoa == false);

            try
            {
                db.BangCongs.InsertOnSubmit(a);
                db.SubmitChanges();
            }
            catch(Exception)
            {
                return false;

            }
            return true;
        }

        public static bool AddRef(ref BangCong a)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    db.BangCongs.InsertOnSubmit(a);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static decimal Tim(byte th, int na) // sai
        {
            BangCong a = db.BangCongs.Single(p => p.Thang == th && p.Nam == na);
            return a.MaBC;
        }

        public static void AutoAdd() // sai
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                if(db.BangCongs.Any(x => x.Thang == ((byte)DateTime.Now.Month) && x.Nam == DateTime.Now.Year))
                {
                    BangCong a = new BangCong();
                    a.Thang = (byte)DateTime.Now.Month;
                    a.Nam = DateTime.Now.Year;
                    a.SoNgay = 0;
                    a.LuongPhaiTra = 0;
                    db.BangCongs.InsertOnSubmit(a);
                    db.SubmitChanges();
                }
            }
        }

        public static bool CoBC(byte th, int na) // sai
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return (from p in db.BangCongs
                        where p.Thang == th && p.Nam == na
                        select p).ToList<BangCong>().Any();
            }
        }

        public static List<BangCong> LoadBang()
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return db.BangCongs.ToList<BangCong>();
            }
        }

        public static bool XoaBC(decimal maBC) //sai
        {
            return db.ft_XoaBC(maBC);
        }

    }
}

    