using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Transactions;

namespace DataCf
{
    public class TruLuongModel : CFConnectinString
    {
        public static decimal Cong(decimal maCong)
        {
            var n = from k in db.TruLuongs
                    where k.MaCong.Equals(maCong)
                    select k;

            decimal tong = 0;

            foreach(var m in n)
            {
                tong += m.SoTien;
            }

            return tong;
        }

        public static TruLuong Doc(decimal maT)
        {
            return db.TruLuongs.Single(x => x.MaT == maT);
        }

        public static bool Sua(decimal maT, decimal maCong, byte ngay, decimal tien, string lyDo)
        {
            TruLuong m = db.TruLuongs.Single(x => x.MaT == maT);

            try
            {
                m.MaT = maT;
                m.MaCong = maCong;
                m.NgayThu = ngay;
                m.SoTien = tien;
                m.LyDoTru = lyDo;

                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool Them(decimal maCong, byte ngay, decimal tien, string lyDo)
        {
            TruLuong t = new TruLuong();
            t.MaCong = maCong;
            t.NgayThu = ngay;
            t.SoTien = tien;
            t.LyDoTru = lyDo;

            try
            {
                db.TruLuongs.InsertOnSubmit(t);
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool ThemLuong(decimal maNV, decimal tien, string lyDo)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    BangCong bc;
                    TienCong tc;

                    if(db.BangCongs.Any(x => x.Thang == ((byte)DateTime.Now.Month) && x.Nam == DateTime.Now.Year))
                        bc = db.BangCongs.Single(x => x.Thang == ((byte)DateTime.Now.Month) && x.Nam == DateTime.Now.Year);
                    else
                    {
                        bc = new BangCong();
                        bc.Thang = ((byte)DateTime.Now.Month);
                        bc.Nam = DateTime.Now.Year;
                        bc.LuongPhaiTra = 0;
                        db.BangCongs.InsertOnSubmit(bc);
                    }

                    if(db.TienCongs.Any(x => x.MaBC == bc.MaBC && x.MaNV == maNV))
                        tc = db.TienCongs.Single(x => x.MaBC == bc.MaBC && x.MaNV == maNV);
                    else
                    {
                        tc = new TienCong();
                        tc.MaBC = bc.MaBC;
                        tc.MaNV = maNV;
                        tc.TinhTrang = false;
                        tc.TienLuong = 0;
                        db.TienCongs.InsertOnSubmit(tc);
                    }

                    TruLuong tl = new TruLuong();
                    tl.LyDoTru = lyDo;
                    tl.MaCong = tc.MaCong;
                    tl.NgayThu = (byte)DateTime.Now.Day;
                    tl.SoTien = tien;

                    db.TruLuongs.InsertOnSubmit(tl);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static bool Xoa(decimal maT)
        {
            TruLuong n = db.TruLuongs.Single(kh => kh.MaT == maT);

            try
            {
                db.TruLuongs.DeleteOnSubmit(n);
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
