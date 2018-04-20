using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCf;

namespace InforCf
{
    public class nvSapLich : Ktbit, ItFSapLich
    {
        public nvSapLich()
        {
            MaCa = 0;
            TenCa = string.Empty;
            SL = 0;
        }

        public static List<nvSapLich> getLich(decimal ma)
        {
            var ls = from p in CaLamList.getList
                     join q in NhanVienModel.Getlich(ma)
                     on p.MaCa equals q.MaCa
                     into temp
                     from q in temp.DefaultIfEmpty(new vw_SapLich
                     {
                         MaCa = p.MaCa,
                         TenCa = p.TenCa,
                         MaNV = ma,
                         LN = 0
                     })
                     select new nvSapLich
                     {
                         MaCa = p.MaCa,
                         TenCa = p.TenCa,
                         SL = q.LN ?? 0
                     };

            return ls.ToList<nvSapLich>();
        }

        public int MaCa { get; set; }
        public string TenCa { get; set; }
        private byte SL = 0;

        public byte LN
        {
            get
            {
                return SL;
            }
            set
            {
                SL = value;
            }
        }

        public bool CN
        {
            get
            {
                return kiemTra(SL, 0);
            }
            set
            {
                ganTR(ref SL, 0, value);
            }
        }

        public bool T2
        {
            get
            {
                return kiemTra(SL, 1);
            }
            set
            {
                ganTR(ref SL, 1, value);
            }
        }

        public bool T3
        {
            get
            {
                return kiemTra(SL, 2);
            }
            set
            {
                ganTR(ref SL, 2, value);
            }
        }

        public bool T4
        {
            get
            {
                return kiemTra(SL, 3);
            }
            set
            {
                ganTR(ref SL, 3, value);
            }
        }

        public bool T5
        {
            get
            {
                return kiemTra(SL, 4);
            }
            set
            {
                ganTR(ref SL, 4, value);
            }
        }

        public bool T6
        {
            get
            {
                return kiemTra(SL, 5);
            }
            set
            {
                ganTR(ref SL, 5, value);
            }
        }

        public bool T7
        {
            get
            {
                return kiemTra(SL, 6);
            }
            set
            {
                ganTR(ref SL, 6, value);
            }
        }
    }
}
