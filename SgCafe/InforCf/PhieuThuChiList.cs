using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCf;

namespace InforCf
{
    public class PhieuThuChiList
    {
        private static List<PhieuThuChi> _listP = null;

        public static List<PhieuThuChi> getList
        {
            get
            {
                if(_listP == null)
                    _listP = PhieuThuChiModel.LoadPhieu();
                return _listP;
            }
        }

        public static IEnumerable<PhieuThuChi> getThu
        {
            get
            {
                if(_listP == null)
                    _listP = PhieuThuChiModel.LoadPhieu();
                return _listP.Where(x => x.Loai == false);
            }
        }

        public static IEnumerable<PhieuThuChi> getChi
        {
            get
            {
                if(_listP == null)
                    _listP = PhieuThuChiModel.LoadPhieu();
                return _listP.Where(x => x.Loai == true);
            }
        }

        public static bool AddPhieu(bool loai, string lydo, string noidung, string nguoinhan, string diachi, decimal sotien)
        {
            PhieuThuChi ph = new PhieuThuChi();

            ph.DiaChi = diachi;
            ph.Loai = loai;
            ph.LyDo = lydo;
            ph.MaNV = TaiKhoanList.getMaNV(informationTk.TenTaiKhoan);
            ph.Ngay = DateTime.Now.Date;
            ph.NguoiNhan = nguoinhan;
            ph.NoiDung = noidung;
            ph.SoTien = sotien;

            if(PhieuThuChiModel.AddRef(ref ph))
            {
                _listP.Insert(0, ph);

                return true;
            }

            return false;
        }

        public static PhieuThuChi AddBack(bool loai, string lydo, string noidung, string nguoinhan, string diachi, decimal sotien)
        {
            PhieuThuChi ph = new PhieuThuChi();

            ph.DiaChi = diachi;
            ph.Loai = loai;
            ph.LyDo = lydo;
            ph.MaNV = TaiKhoanList.getMaNV(informationTk.TenTaiKhoan);
            ph.Ngay = DateTime.Now.Date;
            ph.NguoiNhan = nguoinhan;
            ph.NoiDung = noidung;
            ph.SoTien = sotien;

            if(PhieuThuChiModel.AddRef(ref ph))
            {
                _listP.Insert(0, ph);

                return ph;
            }

            return null;
        }

        public static bool DeleteP(decimal so)
        {
            if(PhieuThuChiModel.XoaPhieu(so))
            {
                _listP.RemoveAt(_listP.FindIndex(x => x.SoPhieu == so));
                return true;
            }
            return false;
        }

        public static bool ClearP(DateTime n)
        {
            if(_listP != null)
            {
                List<decimal> de = PhieuThuChiModel.ClearRtu(n);
                foreach(decimal d in de)
                {
                    _listP.RemoveAt(_listP.FindIndex(x => x.SoPhieu == d));
                }
                if(de.Count > 0)
                    return true;
                else
                    return false;
            }
            else
                return PhieuThuChiModel.ClearnotR(n);
        }
    }
}
