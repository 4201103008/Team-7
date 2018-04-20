using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StyleCF;
using SgCafe.Windows;
using SgCafe.Windows.HeThong;
using SgCafe.Windows.HoatDong;
using SgCafe.Windows.NhanSu;
using SgCafe.Windows.TroGiup;
using InforCf;
using StyleCF.Control;
using System.Windows.Resources;

namespace SgCafe
{
    public class LBMN
    {
        public static string onlyDate(DateTime ng)
        {
            if(ng == null)
                return "--/--/--";
            return ng.ToString("dd/MM/yyyy");
        }

        public static string onlyTime(TimeSpan ng)
        {
            if(ng == null)
                return "--:--:--";
            return string.Format("{0:D2}:{1:D2}:{2:D2}", ng.Hours, ng.Minutes, ng.Seconds);
        }

        public static void isMuberic(TextCompositionEventArgs e)
        {
            if(!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        public static BitmapImage getBMI(string link)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(link, UriKind.RelativeOrAbsolute);
            logo.EndInit();

            return logo;
        }

        public static Brush getBru(string _d)
        {
            Uri resourceUri = new Uri(_d, UriKind.RelativeOrAbsolute);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            var brush = new ImageBrush();
            brush.ImageSource = temp;
            return brush;
        }
    }
}
