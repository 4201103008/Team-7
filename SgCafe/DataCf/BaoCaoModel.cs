using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataCf
{
    public class BaoCaoModel : CFConnectinString
    {
        public static List<BaoCao> LoadA()
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                IEnumerable<BaoCao> c = from k in db.BaoCaos
                                        select k;
                return c.ToList<BaoCao>();
            }
        }

        public static List<vw_BaoCao> LoadV()
        {
            using (DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                IEnumerable<vw_BaoCao> b = from p in db.vw_BaoCaos
                                           select p;
                return b.ToList<vw_BaoCao>();
            }
        }

        public static bool isDoc(decimal ma)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    BaoCao bc = db.BaoCaos.Single(x => x.MaBC == ma);
                    bc.TrangThai = true;

                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static string DocND(decimal ma)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return db.BaoCaos.Single(x => x.MaBC == ma).NoiDung;
            }
        }

        public static List<BaoCao> LoadC()
        {
            IEnumerable<BaoCao> c = from k in db.BaoCaos
                                    where k.TrangThai == false
                                    select k;
            return c.ToList<BaoCao>();
        }

        public static bool ThemN(string tieuDe, string noiDung, DateTime ngayGio, decimal maNV)
        {
            BaoCao k = new BaoCao();
            k.TieuDe = tieuDe;
            k.NoiDung = noiDung;
            k.NgayGio = ngayGio;
            k.TrangThai = false;
            k.MaNV = maNV;

            try
            {
                db.BaoCaos.InsertOnSubmit(k);
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool ThemT(string tieuDe, string noiDung, DateTime ngayGio, string tenTK) //sai
        {
            TaiKhoan tk = db.TaiKhoans.Single(x => x.TenTK == tenTK);

            BaoCao k = new BaoCao();
            k.TieuDe = tieuDe;
            k.NoiDung = noiDung;
            k.NgayGio = ngayGio;
            k.TrangThai = false;
            k.MaNV = tk.MaNV;

            try
            {
                db.BaoCaos.InsertOnSubmit(k);
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool AddRef(ref BaoCao k)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    db.BaoCaos.InsertOnSubmit(k);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static bool Xoa(decimal maBC)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                BaoCao x = db.BaoCaos.Single(p => p.MaBC == maBC);

                try
                {
                    db.BaoCaos.DeleteOnSubmit(x);
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
                    IEnumerable<BaoCao> hd = from p in db.BaoCaos
                                             where p.NgayGio < n
                                             select p;
                    List<decimal> de = hd.ToList().ConvertAll(x => x.MaBC);
                    db.BaoCaos.DeleteAllOnSubmit(hd);
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
                    IEnumerable<BaoCao> hd = from p in db.BaoCaos
                                             where p.NgayGio < n
                                             select p;
                    if(hd != null)
                        b = true;
                    db.BaoCaos.DeleteAllOnSubmit(hd);
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
