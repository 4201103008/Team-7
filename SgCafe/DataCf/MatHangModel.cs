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
    public class MatHangModel : CFConnectinString
    {
        public static MatHang Doc(decimal maH)
        {
            Table<MatHang> MatHangs = db.GetTable<MatHang>();
            MatHang c = MatHangs.Single(k => k.MaHang.Equals(maH));
            return c;
        }

        public static bool KiemTraX(decimal ma)
        {
            return db.Nhaps.Any(x => x.MaHang == ma) && db.BanHangs.Any(x => x.MaHang == ma);
        }

        public static bool CungCap(List<CungCap> a)
        {
            try
            {
                db.CungCaps.InsertAllOnSubmit(a);
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool DuadSua(decimal maH, string tenH, string donVi, decimal? giaBan, int loai, string ghichu, List<vw_CungCap> d)
        {
            bool rt = true;

            using(var tran = new TransactionScope())
            {
                MatHang k = db.MatHangs.Single(x => x.MaHang == maH);
                k.TenHang = tenH;
                k.DonViTinh = donVi;
                k.GiaBan = giaBan;
                k.Loai = loai;
                k.GhiChu = ghichu;

                IEnumerable<CungCap> cc = from p in db.CungCaps
                                          where p.MaHang == maH
                                          select p;

                try
                {
                    db.CungCaps.DeleteAllOnSubmit(cc);
                    if(loai <= 0)
                    {
                        List<DataCf.CungCap> listCC = d.ConvertAll(x => new CungCap
                        {
                            MaHang = maH,
                            MaNCC = x.MaNCC,
                            GiaNhap = x.GiaNhap
                        });

                        db.CungCaps.InsertAllOnSubmit(listCC);
                    }
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

        public static bool DuadSuaCt(decimal maH, string tenH, string donVi, decimal? giaBan, int loai, string ghichu, List<vw_CungCap> d)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                bool rt = true;

                using(var tran = new TransactionScope())
                {
                    try
                    {
                        MatHang k = db.MatHangs.Single(x => x.MaHang == maH);
                        k.TenHang = tenH;
                        k.DonViTinh = donVi;
                        k.GiaBan = giaBan;
                        k.Loai = loai;
                        k.GhiChu = ghichu;

                        IEnumerable<CungCap> cc = from p in db.CungCaps
                                                  where p.MaHang == maH
                                                  select p;

                        if(loai == 1)
                            db.CungCaps.DeleteAllOnSubmit(cc);
                        else
                        {
                            IEnumerable<CungCap> cd = from p in cc
                                                      where !d.Any(x => x.MaNCC == p.MaNCC)
                                                      select p;

                            db.CungCaps.DeleteAllOnSubmit(cd);

                            IEnumerable<CungCap> cu = from p in cc
                                                      where d.Any(x => x.MaNCC == p.MaNCC && x.GiaNhap != p.GiaNhap)
                                                      select p;

                            foreach(CungCap u in cu)
                            {
                                u.GiaNhap = d.Single(x => x.MaNCC == u.MaNCC).GiaNhap;
                            }

                            IEnumerable<CungCap> ci = from p in d
                                                      where !cc.Any(x => x.MaHang == maH && x.MaNCC == p.MaNCC)
                                                      select new CungCap
                                                      {
                                                          MaHang = maH,
                                                          MaNCC = p.MaNCC,
                                                          GiaNhap = p.GiaNhap
                                                      };

                            db.CungCaps.InsertAllOnSubmit(ci);
                        }
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

        public static bool DuadSuaKhoa(decimal maH, string tenH, string donVi, decimal? giaBan, int loai, int key, string ghichu, List<vw_CungCap> d)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                bool rt = true;

                using(var tran = new TransactionScope())
                {
                    try
                    {
                        MatHang k = db.MatHangs.Single(x => x.MaHang == maH);
                        k.TenHang = tenH;
                        k.DonViTinh = donVi;
                        if(key < 0)
                            k.GiaBan = giaBan;
                        k.Loai = loai;
                        k.GhiChu = ghichu;

                        IEnumerable<CungCap> cc = from p in db.CungCaps
                                                  where p.MaHang == maH
                                                  select p;


                        if(key > 0)
                        {
                            if(loai == 1)
                                db.CungCaps.DeleteAllOnSubmit(cc);
                            else
                            {
                                IEnumerable<CungCap> cd = from p in cc
                                                          where !d.Any(x => x.MaNCC == p.MaNCC)
                                                          select p;

                                db.CungCaps.DeleteAllOnSubmit(cd);

                                IEnumerable<CungCap> cu = from p in cc
                                                          where d.Any(x => x.MaNCC == p.MaNCC && x.GiaNhap != p.GiaNhap)
                                                          select p;

                                foreach(CungCap u in cu)
                                {
                                    u.GiaNhap = d.Single(x => x.MaNCC == u.MaNCC).GiaNhap;
                                }
                            }
                        }

                        IEnumerable<CungCap> ci = from p in d
                                                  where !cc.Any(x => x.MaHang == maH && x.MaNCC == p.MaNCC)
                                                  select new CungCap
                                                  {
                                                      MaHang = maH,
                                                      MaNCC = p.MaNCC,
                                                      GiaNhap = p.GiaNhap
                                                  };

                        db.CungCaps.InsertAllOnSubmit(ci);

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

        public static bool UpCungCap(decimal ma, List<vw_CungCap> d)
        {
            IEnumerable<CungCap> cc = from p in db.CungCaps
                                      where p.MaHang == ma
                                      select p;
            List<DataCf.CungCap> listCC = d.ConvertAll(x => new CungCap
            {
                MaHang = ma,
                MaNCC = x.MaNCC,
                GiaNhap = x.GiaNhap
            });

            try
            {
                db.CungCaps.DeleteAllOnSubmit(cc);
                db.CungCaps.InsertAllOnSubmit(listCC);
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static void DoRac()
        {
            IEnumerable<MatHang> MatHangs = db.GetTable<MatHang>();
            var ds = from k in MatHangs
                     where k.Xoa = true
                     select k;
            db.MatHangs.DeleteAllOnSubmit(ds);
            db.SubmitChanges();
        }

        public static bool KhoiPhuc(decimal maH)
        {
            MatHang a = db.MatHangs.Single(x => x.MaHang.Equals(maH));
            a.Xoa = false;
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

        public static List<vw_CungCap> LoadCC(decimal maH)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                IEnumerable<vw_CungCap> a = from p in db.vw_CungCaps
                                            where p.MaHang == maH
                                            select p;
                return a.ToList<vw_CungCap>();
            }
        }

        public static List<MatHang> LoadA()
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                IEnumerable<MatHang> c = from k in db.MatHangs
                                         where k.Xoa == false
                                         select k;
                return c.ToList<MatHang>();
            }
        }

        public static List<MatHang> LoadNL()
        {
            IEnumerable<MatHang> MatHangs = db.GetTable<MatHang>();
            List<MatHang> e = new List<MatHang>();
            var c = from k in MatHangs
                    where k.Loai <= 0 && k.Xoa == false
                    select k;
            e = c.ToList<MatHang>();
            return e;
        }

        public static List<MatHang> LoadRac()
        {
            IEnumerable<MatHang> MatHangs = db.GetTable<MatHang>();
            List<MatHang> e = new List<MatHang>();
            var c = from k in MatHangs
                    where k.Xoa == true
                    select k;
            e = c.ToList<MatHang>();
            return e;
        }

        public static List<MatHang> LoadSP()
        {
            IEnumerable<MatHang> MatHangs = db.GetTable<MatHang>();
            List<MatHang> e = new List<MatHang>();
            var c = from k in MatHangs
                    where k.Loai >= 0 && k.Xoa == false
                    select k;
            e = c.ToList<MatHang>();
            return e;
        }

        public static List<MatHang> TimKiem(string chuoitk)
        {
            IEnumerable<MatHang> MatHangs = db.GetTable<MatHang>();
            List<MatHang> e = new List<MatHang>();
            var c = from k in MatHangs
                    where k.TenHang == chuoitk
                    select k;
            e = c.ToList<MatHang>();
            return e;
        }

        public static bool Sua(decimal maH, string tenH, string donVi, decimal? giaBan, int loai, string ghichu)
        {
            MatHang k = db.MatHangs.Single(x => x.MaHang == maH);

            try
            {
                k.TenHang = tenH;
                k.DonViTinh = donVi;
                k.GiaBan = giaBan;
                k.Loai = loai;
                k.GhiChu = ghichu;

                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool Them(string tenH, string donVi, decimal giaBan, int loai, string ghiChu)
        {
            MatHang k = new MatHang();
            k.TenHang = tenH;
            k.DonViTinh = donVi;
            k.GiaBan = giaBan;
            k.Loai = loai;
            k.GhiChu = ghiChu;
            k.SoLuong = 0;
            k.Xoa = false;

            try
            {
                db.MatHangs.InsertOnSubmit(k);
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool ThemRef(ref MatHang k)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    db.MatHangs.InsertOnSubmit(k);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static bool AddRef(ref MatHang k, List<vw_CungCapHang> mh)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                bool rt = true;

                using(var tran = new TransactionScope())
                {
                    try
                    {
                        db.MatHangs.InsertOnSubmit(k);
                        db.SubmitChanges();
                        decimal ma = k.MaHang;
                        List<CungCap> liCc = mh.ConvertAll(x => new CungCap
                        {
                            MaHang = ma,
                            MaNCC = x.MaNCC,
                            GiaNhap = x.GiaNhap
                        });
                        db.CungCaps.InsertAllOnSubmit(liCc);
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

        public static bool XoaT(decimal maH)
        {
            MatHang k = db.MatHangs.Single(x => x.MaHang == maH);
            k.Xoa = true;

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

        public static bool XoaVV(decimal maH) //sai
        {
            bool rt = true;

            using(var tran = new TransactionScope())
            {
                IEnumerable<CungCap> cc = from p in db.CungCaps
                                          where p.MaHang == maH
                                          select p;
                IEnumerable<Nhap> nh = from p in db.Nhaps
                                       where p.MaHang == maH
                                       select p;
                IEnumerable<BanHang> bh = from p in db.BanHangs
                                          where p.MaHang == maH
                                          select p;
                MatHang mh = db.MatHangs.Single(x => x.MaHang == maH);
                try
                {
                    db.CungCaps.DeleteAllOnSubmit(cc);
                    db.Nhaps.DeleteAllOnSubmit(nh);
                    db.BanHangs.DeleteAllOnSubmit(bh);
                    db.MatHangs.DeleteOnSubmit(mh);
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

        public static bool CheckPNCTT(decimal mah)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return (from p in db.Nhaps
                        join q in db.PhieuNhaps
                        on p.SoPhieu equals q.SoPhieu
                        where p.MaHang == mah && q.TrangThai == false
                        select q).Any();
            }
        }

        public static bool CheckHDCTT(decimal mah)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return (from p in db.BanHangs
                        join q in db.HoaDons
                        on p.SoHD equals q.SoHD
                        where p.MaHang == mah && q.TrangThai == 0
                        select q).Any();
            }
        }

        public static bool XoaAt(decimal maH) //sai
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                bool rt = true;

                using(var tran = new TransactionScope())
                {
                    try
                    {
                        MatHang mh = db.MatHangs.Single(x => x.MaHang == maH);

                        if(db.Nhaps.Any(p => p.MaHang == maH) || db.BanHangs.Any(p => p.MaHang == maH))
                            mh.Xoa = true;
                        else
                        {
                            IEnumerable<CungCap> cc = from p in db.CungCaps
                                                      where p.MaHang == maH
                                                      select p;
                            db.CungCaps.DeleteAllOnSubmit(cc);
                            db.MatHangs.DeleteOnSubmit(mh);
                        }
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
	}
}
