using StyleCF;
using System.Windows;
using InforCf;

namespace SgCafe
{
    class ThongBaoHT
    {
        public static bool f_ThongBao(bool t, string nd)
        {
            if (informationQ._thongBao)
            {
                if (t)
                {
                    MessageBoxCF.Show("Thông báo", nd + " thành công", MessageBoxImage.Asterisk, MessageBoxButton.OK);
                }
                else
                    MessageBoxCF.Show("Lổi", nd + " thất bại!", MessageBoxImage.Error, MessageBoxButton.OK);
            }
            return t;
        }
    }
}
