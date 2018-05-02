using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCf;

namespace InforCf
{
    public sealed class BanList
    {
        private static List<Ban> _listB = null;

        public static List<Ban> getList
        {
            get
            {
                if (_listB == null)
                    _listB = BanModel.LoadBan();

                return _listB;
            }
        }

        public static List<Ban> getBanTrong
        {
            get
            {
                return (from p in getList
                        where p.SoHD == null
                        select p).ToList<Ban>();
            }
        }

        public static List<Ban> getBanDD
        {
            get
            {
                return (from p in getList
                        where p.SoHD != null
                        select p).ToList<Ban>();
            }
        }

        public static bool AddBan(string tenB, string ghiC)
        {
            Ban b = new Ban();
            b.TenBan = tenB;
            b.GhiChu = ghiC;

            if (BanModel.ThemBanRef(ref b))
            {
                int id = _listB.FindIndex(x => String.Compare(x.TenBan, tenB) > 0);
                if (id < 0)
                    _listB.Add(b);
                else
                    _listB.Insert(id, b);

                return true;
            }
            return false;
        }

        public static bool DeleteBan(string tenB)
        {
            if(BanModel.XoaBan(tenB))
            {
                _listB.RemoveAt(_listB.FindIndex(x => x.TenBan == tenB));

                return true;
            }
            return false;
        }

        public static bool OpenBan(string ten, decimal so)
        {
            if(BanModel.Mo(ten, so))
            {
                Ban b = _listB.FirstOrDefault(x => x.TenBan == ten);

                b.SoHD = so;

                return true;
            }
            return false;
        }

        public static bool ChuyenBan(string bc, string ct)
        {
            if(HoaDonModel.ChuyenBan(bc, ct))
            {
                Ban banc = _listB.FirstOrDefault(x => x.TenBan == bc);
                Ban banm = _listB.FirstOrDefault(x => x.TenBan == ct);
                banm.SoHD = banc.SoHD;
                banc.SoHD = null;

                return true;
            }

            return false;
        }

        public static string tatBan
        {
            set
            {
                Ban b = _listB.FirstOrDefault(x => x.TenBan == value);
                b.SoHD = null;
            }
        }

        public static HoaDon checkHD(string ban)
        {
            Ban b = _listB.FirstOrDefault(x => x.TenBan == ban);
            return HoaDonList.getList.Single(x => x.SoHD == b.SoHD);
        }
    }
}
