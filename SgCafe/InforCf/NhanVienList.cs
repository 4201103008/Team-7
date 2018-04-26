using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCf;

namespace InforCf
{
    public class NhanVienList
    {
        private static List<NhanVien> _listNv = null;

        public static List<NhanVien> getList
        {
            get
            {
                if (_listNv == null)
                    _listNv = NhanVienModel.LoadNV();

                return _listNv;
            }
        }

        public static List<NhanVien> getnotAD
        {
            get
            {
                if(_listNv == null)
                    _listNv = NhanVienModel.LoadNV();

                return (from p in _listNv
                        where p.MaCV != null
                        select p).ToList<NhanVien>();
            }
        }

        public static List<vw_NhanVienCV> getListQL
        {
            get
            {
                if(_listNv == null)
                    _listNv = NhanVienModel.LoadNV();

                IEnumerable<vw_NhanVienCV> a = from p in _listNv
                                               join q in ChucVuList.getList
                                               on p.MaCV equals q.MaCV
                                               select new vw_NhanVienCV
                                               {
                                                   MaNV = p.MaNV,
                                                   TenNV = p.TenNV,
                                                   TenCV = q.TenCV,
                                                   QL = q.QL
                                               };

                return a.ToList<vw_NhanVienCV>();
            }
        }

        public static string getName(decimal? ma)
        {
            if (ma != null)
                return getList.Find(x => x.MaNV == (ma ?? 0)).TenNV;
            else
                return string.Empty;
        }

        public static bool AddNV(string tenNV, decimal mucluong, string sdt, bool gioitinh, string diachi, string ghichu, int maCV, List<nvSapLich> sl)
        {
            NhanVien a = new NhanVien();
            a.TenNV = tenNV;
            a.MucLuong = mucluong;
            a.SDT = sdt;
            a.GioiTinh = gioitinh;
            a.DiaChi = diachi;
            a.NgayLam = DateTime.Now;
            a.GhiChu = ghichu;
            a.MaCV = maCV;
            a.Xoa = false;

            if(NhanVienModel.DualAdd(ref a, sl.Cast<ItFSapLich>().ToList()))
            {
                _listNv.Add(a);

                return true;
            }

            return false;
        }

        public static bool EditCV(decimal maNV, int maCV)
        {
            if(NhanVienModel.SuaCV(maNV, maCV))
            {
                NhanVien nv = _listNv.FirstOrDefault(x => x.MaNV == maNV);

                nv.MaCV = maCV;

                return true;
            }

            return false;
        }
        

        public static bool EditNV(decimal maNV, string tenNV, decimal mucluong, string sdt, bool gioitinh, string diachi, string ghichu, int maCV, List<nvSapLich> sl)
        {
            if(NhanVienModel.DualSua(maNV, tenNV, mucluong, sdt, gioitinh, diachi, ghichu, maCV, sl.Cast<ItFSapLich>().ToList()))
            {
                NhanVien b = _listNv.FirstOrDefault(x => x.MaNV == maNV);

                b.TenNV = tenNV;
                b.MucLuong = mucluong;
                b.SDT = sdt;
                b.GioiTinh = gioitinh;
                b.DiaChi = diachi;
                b.GhiChu = ghichu;
                b.MaCV = maCV;

                return true;
            }

            return false;
        }

        public static bool DeleteNV(decimal ma)
        {
            string tk = string.Empty;
            if(NhanVienModel.XoaS(ma, ref tk))
            {
                _listNv.RemoveAt(_listNv.FindIndex(x => x.MaNV == ma));
                if(tk.Length > 0)
                    TaiKhoanList.isDeleted(tk);
                return true;
            }

            return false;
        }
    }
}