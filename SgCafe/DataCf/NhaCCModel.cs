using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Transactions;

namespace DataCf
{
    public class NhaCCModel : CFConnectinString
    {
        public static bool CungCap(decimal maN, decimal maH, decimal gia)
        {
            Table<CungCap> CungCaps = db.GetTable<CungCap>();
            CungCap a = new CungCap();
            a.MaHang = maH;
            a.MaNCC = maN;
            a.GiaNhap = gia;
            try
            {
                db.CungCaps.InsertOnSubmit(a);
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static NhaCC Doc(decimal maN) //sai chua sua
        {
            Table<NhaCC> NhaCCs = db.GetTable<NhaCC>();
            NhaCC b = new NhaCC();
            var c = from k in NhaCCs
                    where k.MaNCC.Equals(maN)
                    select k;
            NhaCC ncc = NhaCCs.Single();
            return ncc;
        }

        public static string DocTen(decimal maN) //moi
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                NhaCC ncc = db.NhaCCs.Single(x => x.MaNCC == maN);
                if(ncc != null)
                    return ncc.TenNCC;
                return string.Empty;
            }
        }

        public static void DoRac()
        {
            Table<NhaCC> NhaCCs = db.GetTable<NhaCC>();
            Table<PhieuNhap> PhieuNhaps = db.GetTable<PhieuNhap>();
            var n = from k in NhaCCs
                    join l in PhieuNhaps on k.MaNCC equals l.MaNCC
                    where k.Xoa == true && k.MaNCC != l.MaNCC
                    select k;
            NhaCCs.DeleteAllOnSubmit(n);
            db.SubmitChanges();
        }

        public static List<vw_CungCapC> LoadCCap(decimal ma)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return (from p in db.vw_CungCapCs
                        where p.MaNCC == ma
                        select p).ToList<vw_CungCapC>();
            }
        }

        public static IEnumerable<CungCap> LoadCungCap(decimal ma)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return from p in db.CungCaps
                       where p.MaNCC == ma
                       select p;
            }
        }

        public static IEnumerable<NhapCungCap> LoadNhapCungCap(decimal so, decimal ma)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return from p in db.CungCaps
                       join q in db.Nhaps
                       on p.MaHang equals q.MaHang
                       where p.MaNCC == ma && q.SoPhieu == so
                       select new NhapCungCap
                       {
                           MaHang = p.MaHang,
                           GiaNhap = p.GiaNhap,
                           SoLuong = q.SoLuong
                       };
            }
        }

        public static bool KhoiPhuc(decimal maN)
        {
            Table<NhaCC> NhaCCs = db.GetTable<NhaCC>();
            var n = from k in NhaCCs
                    where k.MaNCC == maN
                    select k;
            try
            {
                foreach(var k in n)
                    k.Xoa = false;
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static List<NhaCC> LoadA()
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                IEnumerable<NhaCC> e = from l in db.NhaCCs
                                       where l.Xoa == false
                                       select l;
                return e.ToList<NhaCC>();
            }
        }

        public static List<vw_CungCap> LoadCC(decimal maN)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                IEnumerable<vw_CungCap> n = from k in db.vw_CungCaps
                                            where k.MaNCC == maN
                                            select k;
                return n.ToList<vw_CungCap>();
            }
        }

        public static List<NhaCC> LoadRac()
        {
            Table<NhaCC> NhaCCs = db.GetTable<NhaCC>();
            List<NhaCC> d = new List<NhaCC>();
            var a = from k in NhaCCs
                    where k.Xoa == true
                    select k;
            return a.ToList<NhaCC>();
        }

        public static bool Sua(decimal maNhaCC, string ten, string diachi, string sdt, string fax, string mail, string maSoThue)
        {
            NhaCC k = db.NhaCCs.Single(x => x.MaNCC == maNhaCC);

            k.TenNCC = ten;
            k.DiaChi = diachi;
            k.SDT = sdt;
            k.Fax = fax;
            k.Email = mail;
            k.MaSoThue = maSoThue;

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

        public static bool DualSua(decimal maN, string ten, string diachi, string sdt, string fax, string mail, string maSoThue, bool key, List<vw_CungCap> d)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                bool rt = true;

                using(var tran = new TransactionScope())
                {
                    try
                    {
                        NhaCC k = db.NhaCCs.Single(x => x.MaNCC == maN);

                        k.TenNCC = ten;
                        k.DiaChi = diachi;
                        k.SDT = sdt;
                        k.Fax = fax;
                        k.Email = mail;
                        k.MaSoThue = maSoThue;

                        IEnumerable<CungCap> cc = from p in db.CungCaps
                                                  where p.MaNCC == maN
                                                  select p;
                        if(key)
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

                        IEnumerable<CungCap> ci = from p in d
                                                  where !cc.Any(x => x.MaNCC == maN && x.MaHang == p.MaHang)
                                                  select new CungCap
                                                  {
                                                      MaHang = p.MaHang,
                                                      MaNCC = maN,
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

        public static bool Them(string ten, string diachi, string sdt, string fax, string mail, string maSoThue)
        {
            NhaCC NCC = new NhaCC();
            NCC.TenNCC = ten;
            NCC.DiaChi = diachi;
            NCC.SDT = sdt;
            NCC.Fax = fax;
            NCC.Email = mail;
            NCC.MaSoThue = maSoThue;
            NCC.Xoa = false;

            try
            {
                db.NhaCCs.InsertOnSubmit(NCC);
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool ThemRef(ref NhaCC NCC)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    db.NhaCCs.InsertOnSubmit(NCC);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static bool AddRef(ref NhaCC NCC, List<vw_CungCapCT> liC)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                bool rt = true;

                using(var tran = new TransactionScope())
                {
                    try
                    {
                        db.NhaCCs.InsertOnSubmit(NCC);
                        db.SubmitChanges();
                        decimal ma = NCC.MaNCC;
                        List<CungCap> liCc = liC.ConvertAll(x => new CungCap
                        {
                            MaHang = x.MaHang,
                            MaNCC = ma,
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

        public static bool CheckPhieu(decimal ma)
        {
            return (from p in db.PhieuNhaps
                    where p.MaNCC == ma
                    select p).Count() > 0;
        }

        public static bool XoaAt(decimal maN) //sai
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                bool rt = true;

                using(var tran = new TransactionScope())
                {
                    NhaCC N = db.NhaCCs.Single(kh => kh.MaNCC.Equals(maN));

                    try
                    {
                        if(db.PhieuNhaps.Any(x => x.MaNCC == maN))
                        {
                            N.Xoa = true;
                        }
                        else
                        {
                            IEnumerable<CungCap> cc = from p in db.CungCaps
                                                      where p.MaNCC == maN
                                                      select p;
                            db.CungCaps.DeleteAllOnSubmit(cc);
                            db.NhaCCs.DeleteOnSubmit(N);
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

        public static bool XoaKQT(decimal maN) //sai
        {
            bool rt = true;

            using(var tran = new TransactionScope())
            {
                IEnumerable<PhieuNhap> pn = from p in db.PhieuNhaps
                                            where p.MaNCC == maN
                                            select p;
                IEnumerable<CungCap> cc = from p in db.CungCaps
                                          where p.MaNCC == maN
                                          select p;
                NhaCC N = db.NhaCCs.Single(kh => kh.MaNCC.Equals(maN));

                try
                {
                    if(pn.Count() > 0)
                    {
                        IEnumerable<Nhap> cn = from p in db.Nhaps
                                               where pn.Any(x => x.SoPhieu == p.SoPhieu)
                                               select p;
                        db.Nhaps.DeleteAllOnSubmit(cn);
                        db.PhieuNhaps.DeleteAllOnSubmit(pn);
                    }
                    db.CungCaps.DeleteAllOnSubmit(cc);
                    db.NhaCCs.DeleteOnSubmit(N);
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

        public static bool XoaT(decimal maN)
        {
            try
            {
                NhaCC N = db.NhaCCs.Single(kh => kh.MaNCC == maN);
                N.Xoa = true;
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool CheckPNCCC(decimal mah)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return (from p in db.PhieuNhaps
                        where p.MaNCC == mah && p.TrangThai == false
                        select p).Any();
            }
        }

        /// <summary>
        /// xóa vĩnh viễn nhà cung cấp có maN đua vào
        /// </summary>
        /// <param name="maN"></param>
        /// <returns></returns>
        public static bool XoaVV(decimal maN) //sai
        {
            bool rt = true;

            using(var tran = new TransactionScope())
            {
                IEnumerable<PhieuNhap> pn = from p in db.PhieuNhaps
                                            where p.MaNCC == maN
                                            select p;
                IEnumerable<Nhap> cn = from p in db.Nhaps
                                       where pn.Any(x => x.SoPhieu == p.SoPhieu)
                                       select p;
                IEnumerable<CungCap> cc = from p in db.CungCaps
                                          where p.MaNCC == maN
                                          select p;
                NhaCC N = db.NhaCCs.Single(kh => kh.MaNCC.Equals(maN));

                try
                {
                    db.Nhaps.DeleteAllOnSubmit(cn);
                    db.PhieuNhaps.DeleteAllOnSubmit(pn);
                    db.CungCaps.DeleteAllOnSubmit(cc);
                    db.NhaCCs.DeleteOnSubmit(N);
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
