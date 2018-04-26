using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCf;

namespace InforCf
{
    public class NhaCCList
    {
        private static List<NhaCC> _listN = null;

        public static List<NhaCC> getList
        {
            get
            {
                if (_listN == null)
                    _listN = NhaCCModel.LoadA();

                return _listN;
            }
        }

        public static decimal? AddNCC(string ten, string diachi, string sdt, string fax, string mail, string maSoThue)
        {
            NhaCC cc = new NhaCC();
            cc.TenNCC = ten;
            cc.DiaChi = diachi;
            cc.SDT = sdt;
            cc.Fax = fax;
            cc.Email = mail;
            cc.MaSoThue = maSoThue;
            cc.Xoa = false;

            if (NhaCCModel.ThemRef(ref cc))
            {
                _listN.Add(cc);

                return cc.MaNCC;
            }

            return null;
        }

        public static string getName(decimal ma)
        {
            if(_listN == null)
                _listN = NhaCCModel.LoadA();
            NhaCC n = _listN.FirstOrDefault(x => x.MaNCC == ma);
            if(n != null)
                return n.TenNCC;

            return NhaCCModel.DocTen(ma);
        }

        public static bool AddRef(string ten, string diachi, string sdt, string fax, string mail, string maSoThue, List<vw_CungCapCT> ct)
        {
            NhaCC cc = new NhaCC();
            cc.TenNCC = ten;
            cc.DiaChi = diachi;
            cc.SDT = sdt;
            cc.Fax = fax;
            cc.Email = mail;
            cc.MaSoThue = maSoThue;
            cc.Xoa = false;

            if (NhaCCModel.AddRef(ref cc, ct))
            {
                _listN.Add(cc);

                return true;
            }
            return false;
        }

        public static bool EditNCC(decimal ma, string ten, string diachi, string sdt, string fax, string mail, string maSoThue, bool key, List<vw_CungCap> ct)
        {
            if (NhaCCModel.DualSua(ma, ten, diachi, sdt, fax, mail, maSoThue, key, ct))
            {
                NhaCC cc = _listN.FirstOrDefault(x => x.MaNCC == ma);

                cc.TenNCC = ten;
                cc.DiaChi = diachi;
                cc.SDT = sdt;
                cc.Fax = fax;
                cc.Email = mail;
                cc.MaSoThue = maSoThue;

                return true;
            }
            return false;
        }

        public static bool DeleteNCC(decimal ma)
        {
            if (NhaCCModel.XoaAt(ma))
            {
                _listN.RemoveAt(_listN.FindIndex(x => x.MaNCC == ma));

                return true;
            }
            return false;
        }
    }
}
