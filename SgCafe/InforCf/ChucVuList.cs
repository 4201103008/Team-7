using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCf;

namespace InforCf
{
    public class ChucVuList
    {
        private static List<ChucVu> _listC = null;

        public static List<ChucVu> getList
        {
            get
            {
                if (_listC == null)
                    _listC = ChucVuModel.LoadCV();

                return _listC;
            }
        }

        public static string getTenCV(int ma)
        {
            return getList.Find(x => x.MaCV == ma).TenCV;
        }
        
        public static bool AddCV(string tencv, byte ql)
        {
            ChucVu c = new ChucVu();
            c.TenCV = tencv;
            c.QL = ql;

            if (ChucVuModel.AddRef(ref c))
            {
                _listC.Add(c);

                return true;
            }
            return false;
        }

        public static bool EditCV(int maCV, string tencv, byte ql)
        {
            if (ChucVuModel.UpCV(maCV, tencv, ql))
            {
                ChucVu a = _listC.FirstOrDefault(x => x.MaCV == maCV);
                a.TenCV = tencv;
                a.QL = ql;

                return true;
            }
            return false;
        }

        public static bool DeleteCV(int maCV)
        {
            if(ChucVuModel.DeleteCV(maCV))
            {
                _listC.RemoveAt(_listC.FindIndex(x => x.MaCV == maCV));

                return true;
            }
            return false;
        }
    }
}
