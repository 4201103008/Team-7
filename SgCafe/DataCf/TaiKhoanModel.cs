using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataCf
{
    public class TaiKhoanModel : CFConnectinString
    {
        /// <summary>
        /// load toàn bộ tên tài khoản có trong CSDL
        /// </summary>
        /// <returns>danh sách tên tài khoản</returns>
        public static List<string> LoadNameAll()
        {
            IEnumerable<string> tk = from p in db.TaiKhoans
                                     select p.TenTK;
            return tk.ToList<string>();
        }

        public static List<vw_ListTaiKhoan> LoadListTK()
        {
            IEnumerable<vw_ListTaiKhoan> tk = from p in db.vw_ListTaiKhoans
                                              select p;
            return tk.ToList<vw_ListTaiKhoan>();
        }

        public static List<TaiKhoan> LoadTK()
        {
            IEnumerable<TaiKhoan> tk = from p in db.TaiKhoans
                                       select p;
            return tk.ToList<TaiKhoan>();
        }

        public static List<vw_TaiKhoanC> LoadTKC()
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return (from p in db.vw_TaiKhoanCs
                        select p).ToList<vw_TaiKhoanC>();
            }
        }

        /// <summary>
        /// kiểm tra mật khẩu có đúng hay không
        /// </summary>
        /// <param name="tenTK">tên tài khoản</param>
        /// <param name="matKhau">mật khẩu</param>
        /// <returns></returns>
        public static bool KiemTraMK(string tenTK, string matKhau)
        {
            return db.ft_KiemTraMk(tenTK, matKhau);
        }

        public static bool KiemTrefMK(string tenTK, string matKhau, ref string _tentk, ref string _tennd, ref byte _ql, ref decimal _manv)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                vw_TtTk _nd = db.vw_TtTks.Single(x => x.TenTK == tenTK);

                if(_nd.MatKhau == matKhau)
                {
                    _tentk = tenTK;
                    _tennd = _nd.TenND;
                    _ql = _nd.QL;
                    _manv = _nd.MaNV;

                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// đọc thông tin của tài khoản
        /// </summary>
        /// <param name="tenTK">tên tài khoản</param>
        /// <returns></returns>
        public static TaiKhoan Doc(string tenTK)
        {
            return db.TaiKhoans.Single(x => x.TenTK == tenTK);
        }

        public static decimal getMaNV(string tenTK)
        {
            return db.TaiKhoans.Single(x => x.TenTK == tenTK).MaNV;
        }

        public static byte QTC(string ten)
        {
            vw_TaiKhoan tk = db.vw_TaiKhoans.Single(x => x.TenTK == ten);

            return tk.QL;
        }

        public static vw_TaiKhoan SelectTK(string ten)
        {
            vw_TaiKhoan tk = db.vw_TaiKhoans.Single(x => x.TenTK == ten);

            return tk;
        }

        public static string GetTenNV(string tenTK)
        {
            var tk = from p in db.TaiKhoans
                     join q in db.NhanViens on p.MaNV equals q.MaNV
                     where p.TenTK == tenTK
                     select q.TenNV;
            return tk.ToString();
        }

        /// <summary>
        /// Đổi mật khẩu
        /// </summary>
        /// <param name="tenTk"></param>
        /// <param name="mkMoi"></param>
        /// <returns></returns>
        public static bool DoiMk(string tenTk, string mkMoi)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                TaiKhoan tk = db.TaiKhoans.Single(x => x.TenTK == tenTk);
                tk.MatKhau = mkMoi;

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

        public static bool AddTkM(string tenTk, string mKhau, decimal maNv)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                TaiKhoan tk = new TaiKhoan();

                try
                {
                    tk.TenTK = tenTk;
                    tk.MatKhau = mKhau;
                    tk.MaNV = maNv;

                    db.TaiKhoans.InsertOnSubmit(tk);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }

                return true;
            }
        }

        public static bool AddRef(ref TaiKhoan tk)
        {
            try
            {
                db.TaiKhoans.InsertOnSubmit(tk);
                db.SubmitChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static List<TaiKhoan> LoadnotAd()
        {
            var t = from tk in db.TaiKhoans
                    where tk.TenTK != "Administrator"
                    select tk;

            return t.ToList<TaiKhoan>();
        }

        /// <summary>
        /// Xóa tài khoản
        /// </summary>
        /// <param name="tentk"></param>
        /// <returns></returns>
        public static bool DeleteTk(string tentk)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    TaiKhoan a = db.TaiKhoans.Single(tk => tk.TenTK == tentk);
                    db.TaiKhoans.DeleteOnSubmit(a);
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }


        public static bool EditTk(string tentk, string tenm, string mk)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                try
                {
                    TaiKhoan t = new TaiKhoan();
                    TaiKhoan a = db.TaiKhoans.Single(tk => tk.TenTK == tentk);
                    t.MaNV = a.MaNV;
                    t.TenTK = tenm;
                    t.MatKhau = mk;
                    db.TaiKhoans.DeleteOnSubmit(a);
                    db.SubmitChanges();
                    db.TaiKhoans.InsertOnSubmit(t);
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
