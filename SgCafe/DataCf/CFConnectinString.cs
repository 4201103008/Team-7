using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCf
{
    public class CFConnectinString
    {
        protected static string ConnectionString = @"server=DESKTOP-GIDAJV6\BINH; database = QLCF ;Integrated Security=True";
        private static DataLQDataContext _db = null;

        protected static DataLQDataContext db
        {
            get
            {
                if(_db == null)
                    _db = new DataLQDataContext(ConnectionString);
                return _db;
            }
        }
    }
}
