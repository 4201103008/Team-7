using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace DataCf
{
    public class ChamCongModel : CFConnectinString
    {
        /// <summary>
        /// Load các dòng trong bảng  ChamCong có MaCong = maC truyền vào
        /// </summary>
        /// <param name="MaC"></param>
        /// <returns></returns>
        public List<ChamCong> LoadC(decimal MaC)
        {
                Table<ChamCong> ChamCongs = db.GetTable<ChamCong>();
                List<ChamCong> e = new List<ChamCong>();
                var c = from k in ChamCongs
                        where k.MaCong.Equals(MaC)
                        select k;
                e = c.ToList<ChamCong>();
                return e;
        }

        /// <summary>
        /// Load toàn bộ các dòng trong bảng ChamCong có
        /// ChamCong.MaCong = TienCong.MaCong và TienCong.MaBC = maBC
        /// </summary>
        /// <param name="maBC"></param>
        /// <returns></returns>
        public static List<ChamCong> LoadA(decimal maBC)
        {
            Table<ChamCong> ChamCongs = db.GetTable<ChamCong>();
            Table<TienCong> TienCongs = db.GetTable<TienCong>();
            List<ChamCong> c = new List<ChamCong>();
            var query = from k in ChamCongs
                        join l in TienCongs on k.MaCong equals l.MaCong
                        where l.MaCong.Equals(0)
                        select k;
            c = query.ToList<ChamCong>();
            return c;
        }

        /// <summary>
        /// Thêm dòng dữ liệu mới vào bảng ChamCong với:
        /// 
        /// MaCong = maC
        /// MaCa = maCa
        /// NgayThu = ngay
        /// TrangThai = tt
        /// </summary>
        /// <param name="maC">mã công</param>
        /// <param name="maCa">mã ca</param>
        /// <param name="ngay">ngày thứ báo nhiêu</param>
        /// <param name="tt">trạng thái</param>
        /// <returns></returns>
        public static bool ChamC(decimal maC, int maCa, byte ngay, byte tt)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    if(db.ChamCongs.Any(x => x.MaCong == maC && x.MaCa == maCa && x.NgayThu == ngay))
                    {
                        ChamCong k = db.ChamCongs.Single(x => x.MaCong == maC && x.MaCa == maCa && x.NgayThu == ngay);
                        k.TinhTrang = tt;
                    }
                    else
                    {
                        ChamCong k = new ChamCong();
                        k.MaCong = maC;
                        k.MaCa = maCa;
                        k.NgayThu = ngay;
                        k.TinhTrang = tt;
                        db.ChamCongs.InsertOnSubmit(k);
                    }
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Xóa các dong trong bảng ChamCong có MaCong = maC truyền vào
        /// </summary>
        /// <param name="maC">mã công cần xóa</param>
        /// <returns></returns>
        public static bool XoaC(decimal maC)
        {
            Table<ChamCong> ChamCongs = db.GetTable<ChamCong>();
            var query = from cc in ChamCongs where cc.MaCong == maC select cc;
            try
            {
                ChamCongs.DeleteAllOnSubmit(query);
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static List<vw_ChamCong> LoadChamCong()
        {
            IEnumerable<vw_ChamCong> ls = from p in db.vw_ChamCongs
                                          orderby p.MaCong ascending
                                          select p;
            return ls.ToList<vw_ChamCong>();
        }

        public static List<vw_ChamCong> LoadChamCong(decimal ma)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                IEnumerable<vw_ChamCong> ls = from p in db.vw_ChamCongs
                                              where p.MaBC == ma
                                              orderby p.MaCong ascending
                                              select p;
                return ls.ToList<vw_ChamCong>();
            }
        }
    }
}
