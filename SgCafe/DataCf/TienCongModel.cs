using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Linq;

namespace DataCf
{
    public class TienCongModel : CFConnectinString
    {

        public List<TienCong> Doc(decimal maC)
        {
            IEnumerable<TienCong> TienCongs = db.GetTable<TienCong>();
            var c = from k in TienCongs where k.MaCong.Equals(maC) select k;
            return c.ToList<TienCong>();
        }

        public static bool ThemC(decimal maNV, decimal maBC)
        {
            IEnumerable<TienCong> TienCongs = db.GetTable<TienCong>();
            TienCong k = new TienCong();
            k.MaNV = maNV;
            k.MaBC = maBC;
            k.TienCongLam = 0;
            k.TienTru = 0;
            k.TienLuong = 0;
            k.TinhTrang = false;
            try
            {
                db.TienCongs.InsertOnSubmit(k);
                db.SubmitChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }



        public static decimal Tim(decimal maNV, decimal maBC)
        {
            IEnumerable<TienCong> TienCongs = db.GetTable<TienCong>();
            var c = from k in TienCongs where k.MaBC.Equals(maBC) && k.MaNV.Equals(maNV) select k;
            TienCong a = c.Single();
            return a.MaCong;
        }

        public static decimal TimNT(decimal maNV, byte thang, int nam)
        {
            IEnumerable<TienCong> TienCongs = db.GetTable<TienCong>();
            IEnumerable<BangCong> BangCongs = db.GetTable<BangCong>();
            var c = from k in TienCongs
                    join l in BangCongs on k.MaBC equals l.MaBC
                    where k.MaNV.Equals(maNV) && l.Thang.Equals(thang) && l.Nam.Equals(nam)
                    select k;
            TienCong a = c.Single();
            return a.MaCong;
        }

        public static List<TienCong> XemLuong(decimal maBC)
        {
            IEnumerable<TienCong> TienCongs = db.GetTable<TienCong>();
            IEnumerable<TienCong> c = from k in db.TienCongs where k.MaBC.Equals(maBC) select k;
            return c.ToList<TienCong>();
        }

        public static bool TraCongC(decimal maC)
        {
            IEnumerable<TienCong> TienCongs = db.GetTable<TienCong>();
            var c = from k in TienCongs where k.MaCong.Equals(maC) select k;
            foreach(var k in c)
                k.TinhTrang = true;
            db.SubmitChanges();
            return true;
        }

        public static bool TraCongT(decimal maNV, decimal maC)
        {
            IEnumerable<TienCong> TienCongs = db.GetTable<TienCong>();
            var c = from k in TienCongs where k.MaCong.Equals(maC) && k.MaNV.Equals(maNV) select k;
            foreach(var k in c)
                k.TinhTrang = true;
            db.SubmitChanges();
            return true;
        }

        public static int ChuaTLuong(decimal maNV)
        {
            return (from k in db.TienCongs
                    where k.MaNV == maNV && k.TinhTrang == false
                    select k).Count();
        }

        public static decimal TinhLuong(decimal maNV)
        {
            return (from k in db.TienCongs
                    where k.MaNV == maNV && k.TinhTrang == false
                    select k.TienLuong).ToList().Sum();
        }

        public static void Xoa(decimal maC)
        {
            IEnumerable<TienCong> TienCongs = db.GetTable<TienCong>();
            IEnumerable<Ca> Cas = db.GetTable<Ca>();

            var cc = from k in Cas
                     where k.MaCa.Equals(maC)
                     select k;

            foreach(var k in cc)
            {
                db.Cas.DeleteOnSubmit(k);
                db.SubmitChanges();
            }

            var tc = from h in TienCongs
                     where h.MaCong.Equals(maC)
                     select h;

            foreach(var h in tc)
            {
                db.TienCongs.DeleteOnSubmit(h);
                db.SubmitChanges();
            }
        }

        public static List<ft_TinhLuongResult> ftTinhLuong(decimal mbc)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return db.ft_TinhLuong(mbc).ToList<ft_TinhLuongResult>();
            }
        }
    }
}
