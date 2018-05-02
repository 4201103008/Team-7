using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCf
{
    public class ThongKeModel : CFConnectinString
    {
        public static List<vw_DoanhThu> AllDoanhThu()
        {
            return (from p in db.vw_DoanhThus
                    select p).ToList<vw_DoanhThu>();
        }

        public static List<vw_DoanhThu> fDoanhThu(DateTime d, DateTime c)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return (from p in db.vw_DoanhThus
                        where d <= p.Ngay && p.Ngay <= c
                        select p).ToList<vw_DoanhThu>();
            }
        }

        public static List<vw_DoUong> AllMatHang()
        {
            return (from p in db.vw_DoUongs
                    select p).ToList<vw_DoUong>();
        }

        public static List<vw_DoUong> fMatHang(DateTime d, DateTime c)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                return (from p in db.vw_DoUongs
                        where d <= p.Ngay && p.Ngay <= c
                        select p).ToList<vw_DoUong>();
            }
        }
    }
}
