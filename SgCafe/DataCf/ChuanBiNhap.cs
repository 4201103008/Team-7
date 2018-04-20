using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCf
{
    public class pnSapNhap
    {
        public decimal MaHang { get; set; }
        public string TenHang { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaNhap { get; set; }
    }

    public class NhapCungCap
    {
        public decimal MaHang { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaNhap { get; set; }
    }
}
