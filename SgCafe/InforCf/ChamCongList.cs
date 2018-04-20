using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCf;
using System.Threading;

namespace InforCf
{
    public class ChamCongList
    {
        private static List<BangCong> _listB = null;
        public static  int _a = 0;

        public static List<BangCong> getBC
        {
            get
            {
                if(_listB == null)
                    _listB = BangCongModel.LoadBang();
                return _listB;
            }
        }

        public static bool AddBCNow()
        {
            if(!BangCongModel.CoBC((byte)DateTime.Now.Month, DateTime.Now.Year))
            {
                BangCong bc = new BangCong();
                bc.Thang = (byte)DateTime.Now.Month;
                bc.Nam = DateTime.Now.Year;
                if(BangCongModel.AddRef(ref bc))
                {
                    _listB.Add(bc);
                    return true;
                }
                return false;
            }
            return true;
        }

        public static void AutoBC()
        {
            if(_a != DateTime.Now.Day)
            {
                BangCong bc = new BangCong();
                if(BangCongModel.AutoAFBC(NhanVienList.getnotAD, CaLamList.getList, ref bc))
                {
                    if(_listB != null)
                        _listB.Add(bc);
                }
                _a = DateTime.Now.Day;
            }
        }
        
        public static void AutoRefresh()
        {
            _a = DateTime.Now.Day;
            AutoBC();
        }
    }
}
