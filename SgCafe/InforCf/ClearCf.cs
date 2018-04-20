using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InforCf
{
    public class ClearCf
    {
        /// <summary>
        /// tự động dọn rác trong hệ thống
        /// </summary>
        public static void SystemAuto()
        {
            if(informationQ._autoClear > 0)
            {
                DateTime n = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-informationQ._autoClear);

                ChamCongList.AutoBC();
                HoaDonList.ClearHD(n);
                PhieuNhapList.ClearPN(n);
                PhieuThuChiList.ClearP(n);
                BaoCaoList.ClearBC(n);
            }
        }
    }
}
