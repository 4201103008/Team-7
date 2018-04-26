using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataCf
{
    public class NhanVienModel : CFConnectinString
    {
        public static List<NhanVien> LoadNV()
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                IEnumerable<NhanVien> a = from p in db.NhanViens
                                          where p.Xoa == false && p.MaCV != null
                                          select p;

                return a.ToList<NhanVien>();
            }
        }

        public static List<vw_NhanVienCV> LoadNVisQL()
        {
            var n = from p in db.TaiKhoans
                    select p.MaNV;

            IEnumerable<vw_NhanVienCV> a = from p in db.vw_NhanVienCVs
                                           where p.QL > 0 && !(from f in db.TaiKhoans
                                                               select f.MaNV).Contains(p.MaNV)
                                           select p;

            return a.ToList<vw_NhanVienCV>();
        }

        public static string getNameNv(decimal ma)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return db.NhanViens.Single(x => x.MaNV == ma).TenNV;
            }
        }

        public static bool Xoa(decimal maNV)
        {
            NhanVien nv = db.NhanViens.Single(x => x.MaNV == maNV);
            try
            {
                nv.Xoa = true;
                db.SubmitChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public static bool XoaS(decimal maNV, ref string tentk)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    TaiKhoan tk = db.TaiKhoans.Single(x => x.MaNV == maNV);
                    if(tk != null)
                    {
                        tentk = tk.TenTK;
                        db.TaiKhoans.DeleteOnSubmit(tk);
                    }
                    IEnumerable<Lam> lm = from p in db.Lams
                                          where p.MaNV == maNV
                                          select p;
                    db.Lams.DeleteAllOnSubmit(lm);
                    IEnumerable<ChamCong> cc = from p in db.ChamCongs
                                               join q in db.TienCongs
                                               on p.MaCong equals q.MaCong
                                               where q.MaNV == maNV
                                               select p;
                    db.ChamCongs.DeleteAllOnSubmit(cc);
                    IEnumerable<TruLuong> tl = from p in db.TruLuongs
                                               join q in db.TienCongs
                                               on p.MaCong equals q.MaCong
                                               where q.MaNV == maNV
                                               select p;
                    db.TruLuongs.DeleteAllOnSubmit(tl);
                    db.SubmitChanges();
                    IEnumerable<TienCong> tc = from p in db.TienCongs
                                               where p.MaNV == maNV
                                               select p;
                    db.TienCongs.DeleteAllOnSubmit(tc);
                    db.SubmitChanges();
                    NhanVien nv = db.NhanViens.Single(x => x.MaNV == maNV);
                    if(!db.PhieuThuChis.Any(x => x.MaNV == maNV) && !db.BaoCaos.Any(x => x.MaNV == maNV)
                        && !db.PhieuNhaps.Any(x => x.MaNV == maNV) && !db.HoaDons.Any(x => x.MaNV == maNV))
                        db.NhanViens.DeleteOnSubmit(nv);
                    else
                        nv.Xoa = true;
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static bool Them(string tenNV, decimal mucluong, string sdt, bool gioitinh, string diachi, DateTime ngay, int maCV)
        {
            NhanVien a = new NhanVien();
            a.TenNV = tenNV;
            a.MucLuong = mucluong;
            a.SDT = sdt;
            a.GioiTinh = gioitinh;
            a.DiaChi = diachi;
            a.NgayLam = ngay;
            a.MaCV = maCV;
            a.Xoa = false;

            try
            {
                db.NhanViens.InsertOnSubmit(a);
                db.SubmitChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public static bool ThemN(string tenNV, decimal mucluong, string sdt, bool gioitinh, string diachi, DateTime ngay, string ghichu, int maCV)
        {
            NhanVien a = new NhanVien();
            a.TenNV = tenNV;
            a.MucLuong = mucluong;
            a.SDT = sdt;
            a.GioiTinh = gioitinh;
            a.DiaChi = diachi;
            a.NgayLam = ngay;
            a.GhiChu = ghichu;
            a.MaCV = maCV;
            a.Xoa = false;

            try
            {
                db.NhanViens.InsertOnSubmit(a);
                db.SubmitChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public static bool AddRef(ref NhanVien a)
        {
            try
            {
                db.NhanViens.InsertOnSubmit(a);
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool AddLam(List<Lam> l)
        {
            try
            {
                db.Lams.InsertAllOnSubmit(l);
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool DualAdd(ref NhanVien a, List<ItFSapLich> lc)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                bool rt = true;

                using(var tran = new TransactionScope())
                {
                    try
                    {
                        db.NhanViens.InsertOnSubmit(a);
                        db.SubmitChanges();
                        decimal ma = a.MaNV;

                        List<Lam> _lv = lc.ConvertAll<Lam>(x => new Lam
                        {
                            MaCa = x.MaCa,
                            MaNV = ma,
                            LN = x.LN
                        });

                        db.Lams.InsertAllOnSubmit(_lv);
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

        public static bool EditLam(decimal ma, List<ItFSapLich> lc)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    IEnumerable<Lam> ls = from p in db.Lams
                                          where p.MaNV == ma
                                          select p;
                    db.Lams.DeleteAllOnSubmit(ls);
                    ls.Distinct();
                    ls = lc.ConvertAll<Lam>(x => new Lam
                    {
                        MaCa = x.MaCa,
                        MaNV = ma,
                        LN = x.LN
                    });

                    db.Lams.InsertAllOnSubmit(ls);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static List<vw_SapLich> Getlich(decimal ma)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                IEnumerable<vw_SapLich> li = from p in db.vw_SapLiches
                                             where p.MaNV == ma
                                             select p;

                return li.ToList<vw_SapLich>();
            }
        }

        public static List<NhanVien> LoadD()
        {
            var a = from p in db.NhanViens
                    where p.Xoa == true
                    select p;

            return a.ToList<NhanVien>();
        }

        public static void Dorac() //sai
        {
            var a = from p in db.NhanViens
                    where p.Xoa == true
                    select p;

            foreach(var m in a)
            {
                NhanVien k = db.NhanViens.Single(l => l.Xoa == true);

                db.NhanViens.DeleteOnSubmit(k);
                db.SubmitChanges();
            }
        }

        public static bool SuaCV(decimal maNV, int macv)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    NhanVien b = db.NhanViens.Single(p => p.MaNV == maNV);
                    b.MaCV = macv;
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static bool Sua(decimal maNV, string tenNV, decimal mucluong, string sdt, bool gioitinh, string diachi, int macv) //sai
        {
            NhanVien b = db.NhanViens.Single(p => p.MaNV == maNV);

            try
            {
                b.TenNV = tenNV;
                b.MucLuong = mucluong;
                b.SDT = sdt;
                b.GioiTinh = gioitinh;
                b.DiaChi = diachi;
                b.MaCV = macv;

                db.SubmitChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public static bool DualSua(decimal ma, string tenNV, decimal mucluong, string sdt, bool gioitinh, string diachi, string ghiChu, int macv, List<ItFSapLich> lc) //sai
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                bool rt = true;

                using(var tran = new TransactionScope())
                {
                    NhanVien b = db.NhanViens.Single(p => p.MaNV == ma);

                    try
                    {
                        b.TenNV = tenNV;
                        b.MucLuong = mucluong;
                        b.SDT = sdt;
                        b.GioiTinh = gioitinh;
                        b.DiaChi = diachi;
                        b.GhiChu = ghiChu;
                        b.MaCV = macv;

                        IEnumerable<Lam> ls = from p in db.Lams
                                              where p.MaNV == ma
                                              select p;
                        db.Lams.DeleteAllOnSubmit(ls);
                        ls.Distinct();
                        ls = lc.ConvertAll<Lam>(x => new Lam
                        {
                            MaCa = x.MaCa,
                            MaNV = ma,
                            LN = x.LN
                        });

                        db.Lams.InsertAllOnSubmit(ls);
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

        public static bool KhoiPhuc(decimal manv)
        {
            var a = from p in db.NhanViens where p.MaNV == manv select p;
            NhanVien b = new NhanVien();
            try
            {
                NhanVien tam = db.NhanViens.Single(p => p.MaNV == manv);
                b.Xoa = false;
                db.SubmitChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
    }
}

