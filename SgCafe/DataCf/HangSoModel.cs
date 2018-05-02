using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCf
{
    public class HangSoModel : CFConnectinString
    {
        public static List<HangSo> Load()
        {
            IEnumerable<HangSo> tk = from p in db.HangSos
                                     select p;
            return tk.ToList();
        }

        public static string Doc(string khoa)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                HangSo tk = db.HangSos.Single(x => x.Ten == khoa);

                return tk.GiaTri;
            }
        }

        public static bool UpHs(string khoa, string giatri)
        {
            using(DataLQDataContext db = new DataLQDataContext(ConnectionString))
            {
                HangSo tk = db.HangSos.Single(x => x.Ten == khoa);
                tk.GiaTri = giatri;

                try
                {
                    db.SubmitChanges();
                }
                catch
                {
                    return false;
                }

                return true;
            }
        }
    }
}
