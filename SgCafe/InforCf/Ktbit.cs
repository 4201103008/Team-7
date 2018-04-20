using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InforCf
{
    public class Ktbit
    {
        public static bool kiemTra(byte _a, byte i)
        {
            byte _b  = 1;
            _b <<= i;
            return (_a & _b) != 0;
        }
        public static byte ganBit(byte _a, byte i, bool _g)
        {
            byte _b = 1;
            _b <<= i;
            if (_g)
                _a = (byte) (_a | _b);
            else
            {
                _b = (byte)~_b;
                _a = (byte)(_a & _b);
            }
            return _a;
        }

        public static void ganTR(ref byte _a, byte i, bool _g)
        {
            byte _b = 1;
            _b <<= i;
            if (_g)
                _a = (byte)(_a | _b);
            else
            {
                _b = (byte)~_b;
                _a = (byte)(_a & _b);
            }
        }

        public static byte taoByteC(bool s0, bool s1, bool s2, bool s3, bool s4, bool s5, bool s6, bool s7)
        {
            byte bt = new byte();

            ganTR(ref bt, 0, s0);
            ganTR(ref bt, 1, s1);
            ganTR(ref bt, 2, s2);
            ganTR(ref bt, 3, s3);
            ganTR(ref bt, 4, s4);
            ganTR(ref bt, 5, s5);
            ganTR(ref bt, 6, s6);
            ganTR(ref bt, 7, s7);

            return bt;
        }
    }
}
