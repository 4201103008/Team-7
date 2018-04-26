using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCf
{
    public class BanModel : CFConnectinString
    {
        public static Ban Doc(string tenBan)
        {
            Ban a = db.Bans.Single(x => x.TenBan == tenBan);

            return a;
        }

        public static bool Dong(decimal soHD)
        {
            try
            {
                Ban b = db.Bans.Single(x => x.SoHD == soHD);

                b.SoHD = null;

                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool Mo(string teb, decimal soHD)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    Ban b = db.Bans.Single(x => x.TenBan == teb);

                    b.SoHD = soHD;

                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static List<Ban> LoadBan()
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                IEnumerable<Ban> ds = from p in db.Bans
                                      select p;

                return ds.ToList<Ban>();
            }
        }

        public static bool ThemBan(string tenBan, string ghiC)
        {
            Ban b = new Ban();
            b.TenBan = tenBan;
            b.GhiChu = ghiC;

            try
            {
                db.Bans.InsertOnSubmit(b);
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool ThemBanRef(ref Ban b)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    db.Bans.InsertOnSubmit(b);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static bool XoaBan(string tenB)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                Ban b = db.Bans.Single(x => x.TenBan == tenB);

                try
                {
                    db.Bans.DeleteOnSubmit(b);
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
}
