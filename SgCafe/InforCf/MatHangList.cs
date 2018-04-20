using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCf;

namespace InforCf
{
    public class MatHangList
    {
        private static List<MatHang> _listM = null;

        public static List<MatHang> getList
        {
            get
            {
                if(_listM == null)
                    _listM = MatHangModel.LoadA();

                return _listM;
            }
        }

        public static List<MatHang> getListSP
        {
            get
            {
                return (from p in getList
                        where p.Loai >= 0
                        select p).ToList<MatHang>();
            }
        }

        public static decimal getGiaBan(decimal mh)
        {
            return getListSP.FirstOrDefault(x => x.MaHang == mh).GiaBan ?? 0;
        }

        public static decimal? AddMH(string tenH, string donVi, decimal? giaBan, int loai, string ghiChu)
        {
            MatHang k = new MatHang();
            k.TenHang = tenH;
            k.DonViTinh = donVi;
            k.GiaBan = giaBan;
            k.Loai = loai;
            k.GhiChu = ghiChu;
            k.SoLuong = 0;
            k.Xoa = false;

            if(MatHangModel.ThemRef(ref k))
            {
                _listM.Add(k);

                return k.MaHang;
            }

            return null;
        }

        public static bool AddRef(string tenH, string donVi, decimal? giaBan, int loai, string ghiChu, List<vw_CungCapHang> mh)
        {
            MatHang k = new MatHang();
            k.TenHang = tenH;
            k.DonViTinh = donVi;
            k.GiaBan = giaBan;
            k.Loai = loai;
            k.GhiChu = ghiChu;
            k.SoLuong = 0;
            k.Xoa = false;

            bool tk;

            if(loai <= 0)
            {
                tk = MatHangModel.AddRef(ref k, mh);
            }
            else
            {
                tk = MatHangModel.ThemRef(ref k);
            }

            if(tk)
            {
                _listM.Add(k);

                return true;
            }
            return false;
        }

        public static bool EditMH(decimal ma, string tenH, string donVi, decimal? giaBan, int loai, string ghiChu, List<vw_CungCap> d)
        {
            if(MatHangModel.DuadSuaCt(ma, tenH, donVi, giaBan, loai, ghiChu, d))
            {
                MatHang k = _listM.FirstOrDefault(x => x.MaHang == ma);

                k.TenHang = tenH;
                k.DonViTinh = donVi;
                k.GiaBan = giaBan;
                k.Loai = loai;
                k.GhiChu = ghiChu;

                return true;
            }
            return false;
        }

        public static bool EditKhoa(decimal ma, string tenH, string donVi, decimal? giaBan, int loai, int key, string ghiChu, List<vw_CungCap> d)
        {
            if(MatHangModel.DuadSuaKhoa(ma, tenH, donVi, giaBan, loai, key, ghiChu, d))
            {
                MatHang k = _listM.FirstOrDefault(x => x.MaHang == ma);

                k.TenHang = tenH;
                k.DonViTinh = donVi;
                if(key < 0)
                    k.GiaBan = giaBan;
                k.Loai = loai;
                k.GhiChu = ghiChu;

                return true;
            }
            return false;
        }

        public static bool DeleteMH(decimal ma)
        {
            if(MatHangModel.XoaAt(ma))
            {
                _listM.RemoveAt(_listM.FindIndex(x => x.MaHang == ma));
                return true;
            }
            return false;
        }

        /// <summary>
        /// khong lay ten nha cc
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public static List<vw_CungCapC> LoadCC(decimal ma)
        {
            if(_listM == null)
                return NhaCCModel.LoadCCap(ma);
            else
            {
                try
                {
                    return (from p in _listM
                            join q in NhaCCModel.LoadCungCap(ma)
                            on p.MaHang equals q.MaHang
                            select new vw_CungCapC
                            {
                                MaHang = p.MaHang,
                                TenHang = p.TenHang,
                                MaNCC = ma,
                                TenNCC = string.Empty,
                                DonViTinh = p.DonViTinh,
                                GiaNhap = q.GiaNhap
                            }).ToList<vw_CungCapC>();
                }
                catch
                {
                    return NhaCCModel.LoadCCap(ma);
                }
            }
        }
        
        public static List<pnSapNhap> LoadofNhap(decimal so, decimal ma)
        {
            if(_listM == null)
                return PhieuNhapModel.LoadMHF(so, ma);
            else
            {
                try
                {
                    return (from p in _listM
                            join q in NhaCCModel.LoadNhapCungCap(so, ma)
                            on p.MaHang equals q.MaHang
                            select new pnSapNhap
                            {
                                MaHang = p.MaHang,
                                TenHang = p.TenHang,
                                DonViTinh = p.DonViTinh,
                                GiaNhap = q.GiaNhap,
                                SoLuong = q.SoLuong
                            }).ToList<pnSapNhap>();
                }
                catch
                {
                    return PhieuNhapModel.LoadMHF(so, ma);
                }
            }
        }
    }
}