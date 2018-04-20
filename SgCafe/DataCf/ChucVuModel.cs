using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCf
{
    public class ChucVuModel : CFConnectinString
    {
        public static bool UpTen(int macv, string ten)
        {
            var a = from p in db.ChucVus where p.MaCV == macv select p;

            ChucVu b = new ChucVu();
            try
            {
                ChucVu tam = db.ChucVus.Single(p => p.MaCV == macv);
                b.TenCV = ten;
                db.SubmitChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public static bool DeleteCV(int macv)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                ChucVu a = db.ChucVus.Single(k => k.MaCV == macv);

                try
                {
                    db.ChucVus.DeleteOnSubmit(a);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static int CheckNVC(int macv)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return (from p in db.NhanViens
                        where p.MaCV == macv
                        select p).Count();
            }
        }

        public static bool UpCV(int macv, string tencv, byte ql) //sai
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                ChucVu b = db.ChucVus.Single(x => x.MaCV == macv);
                b.TenCV = tencv;
                b.QL = ql;

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

        public static bool UpQl(int macv, byte ql)
        {
            var a = from p in db.ChucVus where p.MaCV == macv select p;
            ChucVu b = new ChucVu();
            try
            {
                ChucVu tam = db.ChucVus.Single(p => p.MaCV == macv);
                b.QL = ql;
                db.SubmitChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public static bool AddCV(string tencv, byte ql)
        {
            ChucVu b = new ChucVu();
            b.TenCV = tencv;
            b.QL = ql;

            try
            {
                db.ChucVus.InsertOnSubmit(b);
                db.SubmitChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public static bool AddRef(ref ChucVu c)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    db.ChucVus.InsertOnSubmit(c);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static List<ChucVu> LoadCV()
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                IEnumerable<ChucVu> a = from p in db.ChucVus
                                        select p;
                return a.ToList<ChucVu>();
            }
        }

        public static NhanVien LoadNV(int macv)
        {
            var a = from p in db.NhanViens where p.MaCV == macv select p;
            NhanVien b = db.NhanViens.Single(k => k.MaCV == macv);
            return b;
        }
    }
}

