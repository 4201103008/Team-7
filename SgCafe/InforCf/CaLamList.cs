using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCf;
using System.Threading;

namespace InforCf
{
    class ThreadAutoAddCC
    {
        public Thread Td { get; set; }

        public int Ma { get; set; }
    }

    public class CaLamList
    {
        private static List<Ca> _listC = null;
        private static List<ThreadAutoAddCC> atAddCC = new List<ThreadAutoAddCC>();

        public static List<Ca> getList
        {
            get
            {
                if (_listC == null)
                    _listC = CaLamModel.LoadCa();

                return _listC;
            }
        }

        public static bool AddCa(string tenCa, System.TimeSpan batDau, System.TimeSpan ketThuc, string ghiChu)
        {
            Ca b = new Ca();
            b.TenCa = tenCa;
            b.BatDau = batDau;
            b.KetThuc = ketThuc;
            b.GhiChu = ghiChu;
            
            if (CaLamModel.AddRef(ref b))
            {
                _listC.Add(b);
                ThreadAutoAddCC t = new ThreadAutoAddCC();
                t.Ma = b.MaCa;
                t.Td = new Thread(AutoAddCC);
                atAddCC.Add(t);
                t.Td.Start(b.MaCa);

                return true;
            }
            return false;
        }

        private static void AutoAddCC(object obj)
        {
            int ma = (int)obj;
            if(BangCongModel.AutoCa(ma))
                ChamCongList.AutoRefresh();
            atAddCC.RemoveAt(atAddCC.FindIndex(x => x.Ma == ma));
        }

        public static bool EditCa(int maCa, string tenCa, System.TimeSpan batDau, System.TimeSpan ketThuc, string ghiChu)
        {
            if(CaLamModel.UpCa(maCa, tenCa, batDau, ketThuc, ghiChu))
            {
                Ca b = _listC.FirstOrDefault(x => x.MaCa == maCa);

                b.TenCa = tenCa;
                b.BatDau = batDau;
                b.KetThuc = ketThuc;
                b.GhiChu = ghiChu;

                return true;
            }
            return false;
        }

        private static void ClearDL(int ma)
        {
            if(atAddCC.Any(x => x.Ma == ma))
            {
                ThreadAutoAddCC t = atAddCC.Find(x => x.Ma == ma);
                t.Td.Abort();
                atAddCC.Remove(t);
            }
        }

        public static bool DeleteCa(int maCa, bool bc)
        {
            ClearDL(maCa);
            bool a;
            if (bc)
                a = CaLamModel.DeleteCaBC(maCa);
            else
                a = CaLamModel.DeleteCa(maCa);
            if (a)
            {
                _listC.RemoveAt(_listC.FindIndex(x => x.MaCa == maCa));

                return true;
            }
            return false;
        }
    }
}
