using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataCf
{
    public class PhieuNhapModel : CFConnectinString
    {
        public static List<PhieuNhap> LoadCT()
        {
            var a = from p in db.PhieuNhaps
                    where p.TrangThai == false
                    select p;
            return a.ToList<PhieuNhap>();
        }

        public static List<PhieuNhap> LoadDP()
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return (from p in db.PhieuNhaps
                        orderby p.NgayLap descending
                        select p).ToList<PhieuNhap>();
            }
        }

        public static bool XoaNL(decimal soP, decimal maH)
        {
            try
            {
                PhieuNhap b = db.PhieuNhaps.Single(k => k.SoPhieu == soP);
                db.PhieuNhaps.DeleteOnSubmit(b);
                db.SubmitChanges();
                Nhap c = db.Nhaps.Single(k => k.SoPhieu == soP);
                db.Nhaps.DeleteOnSubmit(c);
                db.SubmitChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public static bool AddNL(decimal Sop, decimal Mah, int soluong)
        {
            var a = from p in db.PhieuNhaps
                    where p.SoPhieu == Sop
                    select p;
            try
            {
                if(a != null)
                {
                    Nhap b = new Nhap();
                    b.SoLuong = (byte)(b.SoLuong + soluong);
                    db.SubmitChanges();
                }
                else
                {
                    PhieuNhap d = new PhieuNhap();
                    d.SoPhieu = Sop;
                    db.PhieuNhaps.InsertOnSubmit(d);
                    Nhap m = new Nhap();
                    m.SoPhieu = Sop;
                    m.MaHang = Mah;
                    m.SoLuong = soluong;
                    db.Nhaps.InsertOnSubmit(m);
                }
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public static bool Xoa(decimal sophieu) //sai
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    IEnumerable<Nhap> c = from p in db.Nhaps
                                          where p.SoPhieu == sophieu
                                          select p;

                    db.Nhaps.DeleteAllOnSubmit(c);
                    db.SubmitChanges();

                    PhieuNhap b = db.PhieuNhaps.Single(k => k.SoPhieu == sophieu);
                    db.PhieuNhaps.DeleteOnSubmit(b);
                    db.SubmitChanges();
                }
                catch(Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public static decimal tk(DateTime dau, DateTime cuoi)
        {
            var a = from k in db.PhieuNhaps where (k.NgayLap >= dau && k.NgayLap <= cuoi) && (k.TrangThai == true) select k;
            decimal tong = 0;
            foreach(var m in a)
            {
                tong += m.TongTien;
            }
            return tong;
        }

        public static bool ThemP(DateTime ngay, decimal maCC, decimal maNV)
        {
            PhieuNhap pn = new PhieuNhap();
            pn.NgayLap = ngay;
            pn.TrangThai = false;
            pn.TongTien = 0;
            pn.MaNV = maNV;
            pn.MaNCC = maCC;

            try
            {
                db.PhieuNhaps.InsertOnSubmit(pn);
                db.SubmitChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public static bool ThemRef(ref PhieuNhap pn, List<pnSapNhap> nh)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                bool rt = true;

                using(var tran = new TransactionScope())
                {
                    try
                    {
                        db.PhieuNhaps.InsertOnSubmit(pn);
                        db.SubmitChanges();

                        decimal so = pn.SoPhieu;

                        List<Nhap> _lv = nh.ConvertAll<Nhap>(x => new Nhap
                        {
                            MaHang = x.MaHang,
                            SoPhieu = so,
                            SoLuong = x.SoLuong
                        });

                        db.Nhaps.InsertAllOnSubmit(_lv);
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

        public static bool SuaP(decimal sop, bool tt, decimal ma, List<pnSapNhap> nh)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                bool rt = true;

                using(var tran = new TransactionScope())
                {
                    try
                    {
                        IEnumerable<Nhap> np = from p in db.Nhaps
                                               where p.SoPhieu == sop
                                               select p;

                        db.Nhaps.DeleteAllOnSubmit(np);

                        db.SubmitChanges();

                        PhieuNhap b = db.PhieuNhaps.Single(k => k.SoPhieu == sop);

                        b.TrangThai = tt;
                        b.MaNCC = ma;

                        db.SubmitChanges();

                        List<Nhap> _lv = nh.ConvertAll<Nhap>(x => new Nhap
                        {
                            MaHang = x.MaHang,
                            SoPhieu = sop,
                            SoLuong = x.SoLuong
                        });

                        db.Nhaps.InsertAllOnSubmit(_lv);
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

        public static List<DataCf.pnSapNhap> LoadMHF(decimal so, decimal ma)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                IEnumerable<pnSapNhap> rt = from p in db.Nhaps
                                            join q in db.vw_CungCapCs
                                            on p.MaHang equals q.MaHang
                                            where p.SoPhieu == so && q.MaNCC == ma
                                            select new pnSapNhap
                                            {
                                                MaHang = p.MaHang,
                                                TenHang = q.TenHang,
                                                DonViTinh = q.DonViTinh,
                                                GiaNhap = q.GiaNhap,
                                                SoLuong = p.SoLuong
                                            };

                return Enumerable.ToList<DataCf.pnSapNhap>(rt);
            }
        }

        public static IEnumerable<Nhap> LoadNhap(decimal so)
        {
            return from p in db.Nhaps
                   where p.SoPhieu == so
                   select p;
        }

        public static decimal ThanhToan(decimal soP)
        {
            PhieuNhap a = db.PhieuNhaps.Single(k => k.SoPhieu == soP);
            a.TrangThai = true;
            db.PhieuNhaps.InsertOnSubmit(a);
            db.SubmitChanges();
            return a.TongTien;
        }

        public static PhieuNhap Doc(decimal soP)
        {
            PhieuNhap a = db.PhieuNhaps.Single(k => k.SoPhieu == soP);
            return a;
        }

        public static bool GiamNL(decimal soP, decimal maH, int soLuong)
        {
            Nhap a = db.Nhaps.Single(k => k.SoPhieu == soP);
            try
            {
                if(soLuong > a.SoLuong)
                {
                    db.Nhaps.DeleteOnSubmit(a);
                    db.SubmitChanges();
                }
                else
                {
                    a.SoLuong = (byte)(a.SoLuong - soLuong);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static List<decimal> ClearRtu(DateTime n)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    IEnumerable<PhieuNhap> hd = from p in db.PhieuNhaps
                                                where p.TrangThai == true && p.NgayLap < n
                                                select p;
                    List<decimal> de = hd.ToList().ConvertAll(x => x.SoPhieu);
                    db.Nhaps.DeleteAllOnSubmit(db.Nhaps.Where(x => hd.Any(p => p.SoPhieu == x.SoPhieu)));
                    db.SubmitChanges();
                    db.PhieuNhaps.DeleteAllOnSubmit(hd);
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
                    IEnumerable<PhieuNhap> hd = from p in db.PhieuNhaps
                                                where p.TrangThai == true && p.NgayLap < n
                                                select p;
                    if(hd != null)
                        b = true;
                    db.Nhaps.DeleteAllOnSubmit(db.Nhaps.Where(x => hd.Any(p => p.SoPhieu == x.SoPhieu)));
                    db.SubmitChanges();
                    db.PhieuNhaps.DeleteAllOnSubmit(hd);
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
