using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCf;

namespace InforCf
{
    public class TaiKhoanList
    {
        private static List<vw_TaiKhoanC> _listTk = null;

        public static List<vw_TaiKhoanC> getList
        {
            get
            {
                if(_listTk == null)
                    _listTk = TaiKhoanModel.LoadTKC();

                return _listTk;
            }
        }

        public static IEnumerable<vw_TaiKhoanC> getNotAd
        {
            get
            {
                if(_listTk == null)
                    _listTk = TaiKhoanModel.LoadTKC();

                return _listTk.Where(p => p.TenTK != "Administrator");
            }
        }

        public static List<string> getName
        {
            get
            {
                if(_listTk == null)
                    _listTk = TaiKhoanModel.LoadTKC();

                return (from p in _listTk
                        select p.TenTK).ToList<string>();
            }
        }

        public static List<vw_ListTaiKhoan> getListL
        {
            get
            {
                return (from p in getList
                        join q in NhanVienList.getList
                        on p.MaNV equals q.MaNV
                        join f in ChucVuList.getList
                        on q.MaCV equals f.MaCV
                        select new vw_ListTaiKhoan
                        {
                            TenTK = p.TenTK,
                            MatKhau = p.MatKhau,
                            TenNV = q.TenNV,
                            TenCV = f.TenCV
                        }).ToList<vw_ListTaiKhoan>();
            }
        }
        public static decimal getMaNV(string tenTk)
        {
            if(_listTk == null)
                _listTk = TaiKhoanModel.LoadTKC();

            return _listTk.Find(x => x.TenTK == tenTk).MaNV;
        }


        public static bool AddNTk(string tenTk, string mKhau, vw_NhanVienCV mnv)
        {
            if(TaiKhoanModel.AddTkM(tenTk, mKhau, mnv.MaNV))
            {
                vw_TaiKhoanC tk = new vw_TaiKhoanC();
                tk.TenTK = tenTk;
                tk.MatKhau = mKhau;
                tk.MaNV = mnv.MaNV;
                tk.TenNV = mnv.TenNV;
                tk.TenCV = mnv.TenCV;
                tk.Ql = mnv.QL;

                _listTk.Insert(0, tk);
                return true;
            }
            return false;
        }

        public static bool checkName(string m)
        {
            return _listTk.Any(x => x.TenTK == m);
        }

        public static bool EditTaiK(string tenTk, string tm, string mKhau)
        {
            if(tenTk == tm)
            {
                if(TaiKhoanModel.DoiMk(tenTk, mKhau))
                {
                    _listTk.Find(x => x.TenTK == tenTk).MatKhau = mKhau;

                    return true;
                }
            }
            else if(TaiKhoanModel.EditTk(tenTk, tm, mKhau))
            {
                vw_TaiKhoanC tk = _listTk.FirstOrDefault(x => x.TenTK == tenTk);
                tk.TenTK = tm;
                tk.MatKhau = mKhau;
                return true;
            }

            return false;
        }

        public static bool DeleteTK(string tentk)
        {
            if(TaiKhoanModel.DeleteTk(tentk))
            {
                _listTk.RemoveAt(_listTk.FindIndex(x => x.TenTK == tentk));

                return true;
            }
            return false;
        }

        public static void isDeleted(string tentk)
        {
            if(_listTk != null)
            {
                int id = _listTk.FindIndex(x => x.TenTK.Equals(tentk));
                if(id > 0)
                    _listTk.RemoveAt(id);
            }
        }

        public static void isDeletedM(decimal ma)
        {
            _listTk.RemoveAt(_listTk.FindIndex(x => x.MaNV == ma));
        }
    }
}
