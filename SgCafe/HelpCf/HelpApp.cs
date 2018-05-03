using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpCf
{
    class HelpApp
    {
        public int ma { get; set; }
        public string ten { get; set; }
        public Uri nd { get; set; }

        public HelpApp(int i, string t, string k)
        {
            ma = i;
            ten = t;
            nd = new Uri(k, UriKind.RelativeOrAbsolute);
        }
    }

    public class NameHelp
    {
        public int ma { get; set; }
        public string ten { get; set; }
    }
}
