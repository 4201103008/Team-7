using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCf;

namespace InforCf
{
    public class BaoCaoList
    {
        private static List<BaoCao> _listB = null;

        private static List<vw_BaoCao> _listV = null;

        public static List<BaoCao> getList
        {
            get
            {
                if (_listB == null)
                    _listB = BaoCaoModel.LoadA();

                return _listB;
            }
        }

        public static List<vw_BaoCao> getListV
        {
            get
            {
                if (_listV == null)
                    _listV = BaoCaoModel.LoadV();

                return _listV;
            }
        }

        public static bool AddBC(string tieuDe, string noiDung)
        {
            BaoCao k = new BaoCao();
            k.TieuDe = tieuDe;
            k.NoiDung = noiDung;
            k.NgayGio = DateTime.Now;
            k.TrangThai = false;
            k.MaNV = TaiKhoanList.getMaNV(informationTk.TenTaiKhoan);

            if(BaoCaoModel.AddRef(ref k))
            {
                if(_listV != null)
                {
                    vw_BaoCao bc = new vw_BaoCao();
                    bc.MaBC = k.MaBC;
                    bc.MaNV = k.MaNV;
                    bc.NgayGio = DateTime.Now;
                    bc.TieuDe = tieuDe;
                    bc.TrangThai = false;

                    _listV.Add(bc);
                }

                return true;
            }
            return false;
        }

        public static bool isDoc(decimal ma)
        {
            if(!_listV.Find(x => x.MaBC == ma).TrangThai)
            {
                if(BaoCaoModel.isDoc(ma))
                    return true;
            }
            return false;
        }

        public static bool DeleteBC(decimal ma)
        {
            if(BaoCaoModel.Xoa(ma))
            {
                if(_listV != null)
                    _listV.RemoveAt(_listV.FindIndex(x => x.MaBC == ma));
                return true;
            }
            return false;
        }

        public static bool ClearBC(DateTime n)
        {
            if(_listV != null)
            {
                List<decimal> de = BaoCaoModel.ClearRtu(n);
                foreach(decimal d in de)
                {
                    _listV.RemoveAt(_listV.FindIndex(x => x.MaBC == d));
                }
                if(de.Count > 0)
                    return true;
                else
                    return false;
            }
            else
                return BaoCaoModel.ClearnotR(n);
        }
    }
}
