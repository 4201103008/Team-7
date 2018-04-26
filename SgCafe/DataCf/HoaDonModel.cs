using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.IO;
using System.Windows;
using System.Transactions;

namespace DataCf
{
    public class HoaDonModel : CFConnectinString
    {
        /// <summary>
        /// Gán thuộc tính SoHD của bàn có SoHD = soHD truyền vào = null
        /// Xóa tất cả các dòng trong bảng BanHang có SoHD = soHD
        /// Xóa HoaDon có SoHD = soHD
        /// </summary>
        /// <param name="soHD">số hóa đơn cần xóa</param>
        /// <returns></returns>
        public static bool XoaHD(decimal soHD)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                bool rt = true;

                using(var tran = new TransactionScope())
                {
                    try
                    {
                        Ban n = db.Bans.Single(x => x.SoHD == soHD);
                        n.SoHD = null;

                        IEnumerable<BanHang> bh = from ban in db.BanHangs
                                                  where ban.SoHD.Equals(soHD)
                                                  select ban;

                        db.BanHangs.DeleteAllOnSubmit(bh);

                        HoaDon hd = db.HoaDons.Single(kh => kh.SoHD == soHD);
                        db.HoaDons.DeleteOnSubmit(hd);
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

        /// <summary>
        /// Xóa dòng dự liệu tương ứng với soHD và maH trong bảng BanHang
        /// </summary>
        /// <param name="soHD">số hóa đơn</param>
        /// <param name="maH">mã hàng</param>
        /// <returns></returns>
        public static bool XoaDU(decimal soHD, decimal maH) //sai
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    BanHang hd = db.BanHangs.Single(kh => kh.SoHD == soHD && kh.MaHang == maH);
                    db.BanHangs.DeleteOnSubmit(hd);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static List<HoaDon> LoadHD()
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return (from p in db.HoaDons
                        orderby p.Ngay descending
                        select p).ToList<HoaDon>();
            }
        }

        /// <summary>
        /// tính tổng tiền tất cả hóa đơn có ThangThai = 1 và
        /// Ngay nằm trong khoảng thời gian từ dau đên cuoi
        /// </summary>
        /// <param name="dau">ngày bắt đầu</param>
        /// <param name="cuoi">ngày kết thúc</param>
        /// <returns></returns>
        public static decimal Tke(DateTime dau, DateTime cuoi)
        {
            Table<HoaDon> HoaDons = db.GetTable<HoaDon>();
            var a = from k in HoaDons where k.Ngay >= dau && k.Ngay <= cuoi && k.TrangThai == 1 select k;
            decimal tong = 0;
            foreach(var tinh in a)
            {
                tong += tinh.TongTien;
            }
            return tong;
        }

        /// <summary>
        /// Thêm hóa đơn mới vào bảng HoaDon
        /// 
        /// Ngay = ngày hiệu tại
        /// GMo = giờ hiện tại
        /// GDong = null
        /// TrangThai = 0
        /// TienNuoc = 0
        /// VAT = vat
        /// GiamGia = giamGia
        /// TongTien = 0
        /// TenBan = tenBan
        /// MaNV = maNV
        /// 
        /// sau đó return lại SoHD của hóa đơn vừa chèn vào
        /// </summary>
        /// <param name="tenban">tên bàn</param>
        /// <param name="vat">thuế VAT</param>
        /// <param name="giamgia">giảm giá</param>
        /// <param name="maNV">mã người dùng</param>
        /// <returns></returns>
        public static decimal? ThemHD(string tenban, byte vat, byte giamgia, decimal maNV)
        {
            HoaDon hd = new HoaDon();
            hd.Ngay = DateTime.Today;
            hd.GMo = DateTime.Now.TimeOfDay;
            hd.GDong = null;
            hd.TrangThai = 0;
            hd.TienNuoc = 0;
            hd.VAT = vat; //vat
            hd.GiamGia = giamgia; // giamgia
            hd.TongTien = 0;
            hd.MaNV = maNV; //maNV
            hd.TenBan = tenban; //tenban

            try
            {
                db.HoaDons.InsertOnSubmit(hd);
                db.SubmitChanges();
            }
            catch
            {
                return null;
            }
            return hd.SoHD;
        }

        public static bool ThemRef(ref HoaDon hd)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    db.HoaDons.InsertOnSubmit(hd);
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
        /// Thêm hóa đơn mới vào bảng HoaDon
        /// 
        /// Ngay = ngày hiệu tại
        /// GMo = giờ hiện tại
        /// GDong = null
        /// TrangThai = 0
        /// TienNuoc = 0
        /// VAT = vat
        /// GiamGia = giamGia
        /// TongTien = 0
        /// TenBan = tenBan
        /// MaNV = maNV
        /// 
        /// sau đó lấy SoHD của hóa đơn vừa thêm vào update bàn có TenBan = tenBan dữ liệu Ban.SoHD = SoHD vừa thêm vào
        /// </summary>
        /// <param name="tenban">tên bàn</param>
        /// <param name="vat">vat</param>
        /// <param name="giamgia">giảm giá</param>
        /// <param name="maNV">mã nhân viên</param>
        /// <returns></returns>
        public static bool ThemFB(string tenban, byte vat, byte giamgia, decimal maNV)
        {
            Table<HoaDon> HoaDons = db.GetTable<HoaDon>();
            Table<Ban> Bans = db.GetTable<Ban>();
            HoaDon hd = new HoaDon();
            hd.Ngay = DateTime.Today;
            hd.GMo = DateTime.Now.TimeOfDay;
            hd.GDong = null;
            hd.TrangThai = 0;
            hd.TienNuoc = 0;
            hd.VAT = vat;
            hd.GiamGia = giamgia;
            hd.TongTien = 0;
            hd.MaNV = maNV;
            hd.TenBan = tenban;

            try
            {
                HoaDons.InsertOnSubmit(hd);
                db.SubmitChanges();
                Ban h = Bans.Single(kh => kh.TenBan == "A");
                h.SoHD = hd.SoHD;
                db.SubmitChanges();

            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Thêm mặt hàng vào hóa đơn, thêm và bảng BanHang dòng dữ liệu có SoHD = soHD và MaHang = maH.
        /// nếu dòng này đã tồn tại thì cộng thêm soLuong truyền vào cho SoLuong đang có trong bảng
        /// nếu chưa tồn tại thì thêm mới
        /// </summary>
        /// <param name="soHD"></param>
        /// <param name="maH"></param>
        /// <param name="soLuong"></param>
        public static bool ThemDU(decimal soHD, decimal maH, int soLuong) //sai
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    if(db.BanHangs.Any(x => x.SoHD == soHD && x.MaHang == maH))
                    {
                        BanHang bh = db.BanHangs.Single(kh => kh.SoHD == soHD && kh.MaHang == maH);
                        bh.SoLuong += soLuong;
                    }
                    else
                    {
                        BanHang temp = new BanHang();
                        temp.SoHD = soHD;
                        temp.MaHang = maH;
                        temp.SoLuong = soLuong;
                        db.BanHangs.InsertOnSubmit(temp);
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
        /// Load các dòng có liên quan đến soHD truyền vào trong view vw_BanHang
        /// </summary>
        /// <param name="soHD">số hóa đơn</param>
        /// <returns></returns>
        public static List<vw_BanHang> LoadDU(decimal soHD)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                IEnumerable<vw_BanHang> a = from p in db.vw_BanHangs
                                            where p.SoHD == soHD
                                            select p;
                return a.ToList<vw_BanHang>();
            }
        }

        /// <summary>
        /// Lấy a = SoHD của bàn có TenBan = canGop
        /// Gán SoHD của bàn canGop = null
        /// Lấy b = SoHD của bàn có TenBan = gopDen
        /// Copy các dòng có SoHD = a trong trong bảng BanHang và thêm mới với SoHD = b sau đó xóa các dòng có SoHD = a
        /// Xoa dóng trong bảng HoaDon có SoHd = a
        /// </summary>
        /// <param name="cangop">bàn cần gộp</param>
        /// <param name="gopden">bàn gộp đến</param>
        public static void GopBan(string cangop, string gopden)
        {
            Ban cg = db.Bans.Single(kh => kh.TenBan.Equals(cangop));
            Ban gd = db.Bans.Single(kh => kh.TenBan.Equals(gopden));

            IEnumerable<BanHang> bh = from k in db.BanHangs
                                      where k.SoHD == cg.SoHD
                                      select k;

            foreach(var x in bh)
            {
                ThemDU((decimal)gd.SoHD, x.MaHang, x.SoLuong);
            }
            db.BanHangs.DeleteAllOnSubmit(bh);
            HoaDon hd = db.HoaDons.Single(kh => kh.SoHD == cg.SoHD);
            db.HoaDons.DeleteOnSubmit(hd);
            cg.SoHD = null;
            db.SubmitChanges();
        }

        public static bool NewGopBan(string cangop, string gopden, ref decimal? fto, ref decimal? fro)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                bool rt = true;

                using(var tran = new TransactionScope())
                {
                    try
                    {
                        Ban cg = db.Bans.Single(kh => kh.TenBan.Equals(cangop));
                        Ban gd = db.Bans.Single(kh => kh.TenBan.Equals(gopden));
                        if(gd.SoHD == null || cg.SoHD == null)
                        {
                            tran.Dispose();
                            return false;
                        }
                        fro = cg.SoHD;
                        fto = gd.SoHD;
                        if(gd.SoHD != cg.SoHD)
                        {
                            IEnumerable<BanHang> bh = from k in db.BanHangs
                                                      where k.SoHD == cg.SoHD
                                                      select k;
                            foreach(BanHang x in bh)
                            {
                                if(db.BanHangs.Any(p => p.SoHD == gd.SoHD && p.MaHang == x.MaHang))
                                {
                                    BanHang banh = db.BanHangs.Single(kh => kh.SoHD == gd.SoHD && kh.MaHang == x.MaHang);
                                    banh.SoLuong += x.SoLuong;
                                }
                                else
                                {
                                    BanHang temp = new BanHang();
                                    temp.SoHD = gd.SoHD ?? 0;
                                    temp.MaHang = x.MaHang;
                                    temp.SoLuong = x.SoLuong;
                                    db.BanHangs.InsertOnSubmit(temp);
                                }
                            }

                            db.BanHangs.DeleteAllOnSubmit(bh);
                            HoaDon hd = db.HoaDons.Single(kh => kh.SoHD == cg.SoHD);
                            db.HoaDons.DeleteOnSubmit(hd);
                        }
                        cg.SoHD = null;
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

        /// <summary>
        /// Giảm đồ uống trong HoaDon (giảm trong bảng BanHang)
        /// Nếu SoLuong của dòng cần giảm đang có trong bảng  - soLuong truyền vào <= 0 thì xóa luôn dòng dữ liệu đó
        /// Ngược lại thì giảm SoLuong trong dòng đó xuống một lượng là soLuong truyền vào
        /// </summary>
        /// <param name="soHD">số hóa đơn</param>
        /// <param name="maH">mã hàng</param>
        /// <param name="soluong">số lượng</param>
        /// <returns></returns>
        public static bool GiamDU(decimal soHD, decimal maH, int soluong)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                BanHang a = db.BanHangs.Single(kh => kh.SoHD == soHD && kh.MaHang == maH);

                if(a == null)
                {
                    return false;
                }
                else
                {
                    try
                    {
                        int _temp = a.SoLuong - soluong;
                        if(_temp <= 0)
                            db.BanHangs.DeleteOnSubmit(a);
                        else
                            a.SoLuong = _temp;

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

        public static bool CheckGG(decimal soHD, byte gg)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    HoaDon a = db.HoaDons.Single(kh => kh.SoHD == soHD);
                    a.GiamGia = gg;

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
        /// Lấy  a = SoHD của bàn có TenBan là tenBan truyền vào sau đó update SoHD của bàn đó = null
        /// Tiếp theo: update bảng HoaDon có SoHD = a vừa lấy đk
        /// HoaDon.TrangThai = 1
        /// HoaDon.GDong = giờ hiện tại
        /// </summary>
        /// <param name="tenBan">tền bàn</param>
        /// <returns></returns>
        public static bool DongBanTen(string tenBan)
        {
            try
            {
                Ban bn = db.Bans.Single(kh => kh.TenBan.Equals(tenBan));
                bn.SoHD = null;
                HoaDon hd = db.HoaDons.Single(kh => kh.TenBan.Equals(tenBan));

                if(hd == null)
                    return false;
                hd.TrangThai = 1;
                hd.GDong = DateTime.Now.TimeOfDay;
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// update bảng HoaDon có SoHD = soHD tuyền vào
        /// HoaDon.TrangThai = 1
        /// HoaDon.GDong = giờ hiện tại
        /// và update bảng Ban có SoHD = soHD tuyền vào là
        /// Ban.SoHD = null
        /// </summary>
        /// <param name="soHD">số hóa đơn</param>
        /// <returns></returns>
        public static bool DongBanHD(decimal soHD)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    HoaDon hd = db.HoaDons.Single(kh => kh.SoHD == soHD);
                    hd.TrangThai = 1;
                    hd.GDong = DateTime.Now.TimeOfDay;

                    Ban b = db.Bans.Single(kh => kh.SoHD == soHD);
                    if(b == null)
                        return false;
                    b.SoHD = null;
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
        /// đọc dòng dữ liệu trong bảng HoaDon có SoHD = soHD
        /// </summary>
        /// <param name="soHD">số hóa đơn</param>
        /// <returns></returns>
        public List<HoaDon> Doc(decimal soHD)
        {
            Table<HoaDon> HoaDons = db.GetTable<HoaDon>();
            var hd = from k in HoaDons where k.SoHD == soHD select k;
            return hd.ToList<HoaDon>();
        }

        /// <summary>
        /// gán thuộc tính SoHD của banMoi = SoHD của banCu và SoHD của bàn củ = null
        /// sau đó lấy SoHD đó update bảng HoaDon thuộc tính TenBan trong hóa đơn đó = banMoi
        /// </summary>
        /// <param name="BanCu">bàn củ</param>
        /// <param name="BanMoi">bàn mới</param>
        public static bool ChuyenBan(string BanCu, string BanMoi)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    Ban bcu = db.Bans.Single(kh => kh.TenBan == BanCu);
                    Ban bmoi = db.Bans.Single(kh => kh.TenBan == BanMoi);
                    bmoi.SoHD = bcu.SoHD;
                    bcu.SoHD = null;
                    HoaDon hd = db.HoaDons.Single(kh => kh.SoHD == bmoi.SoHD);
                    hd.TenBan = BanMoi;
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
                    IEnumerable<HoaDon> hd = from p in db.HoaDons
                                             where p.TrangThai == 1 && p.Ngay < n
                                             select p;
                    List<decimal> de = hd.ToList().ConvertAll(x => x.SoHD);
                    db.BanHangs.DeleteAllOnSubmit(db.BanHangs.Where(x => hd.Any(p => p.SoHD == x.SoHD)));
                    db.SubmitChanges();
                    db.HoaDons.DeleteAllOnSubmit(hd);
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
                    IEnumerable<HoaDon> hd = from p in db.HoaDons
                                             where p.TrangThai == 1 && p.Ngay < n
                                             select p;
                    if(hd != null)
                        b = true;
                    db.BanHangs.DeleteAllOnSubmit(db.BanHangs.Where(x => hd.Any(p => p.SoHD == x.SoHD)));
                    db.SubmitChanges();
                    db.HoaDons.DeleteAllOnSubmit(hd);
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
