using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCf
{
    public interface ItFSapLich
    {
        int MaCa { get; set; }
        string TenCa { get; set; }
        byte LN { get; set; }

        bool CN { get; set; }
        bool T2 { get; set; }
        bool T3 { get; set; }
        bool T4 { get; set; }
        bool T5 { get; set; }
        bool T6 { get; set; }
        bool T7 { get; set; }
    }
}
