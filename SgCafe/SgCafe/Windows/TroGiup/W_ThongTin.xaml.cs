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
using System.Windows.Shapes;
using System.Reflection;
using System.Resources;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace SgCafe.Windows.TroGiup
{
    public class AssemblyInfo
    {
        // The assembly information values.
        public string Title = "", Description = "", Company = "",
        Product = "", Copyright = "", Trademark = "",
        AssemblyVersion = "", FileVersion = "", Guid = "",
        NeutralLanguage = "";
        public bool IsComVisible = false;
        
        public static T GetAssemblyAttribute<T>(Assembly assembly) where T : Attribute
        {
            // Get attributes of this type.
            object[] attributes = assembly.GetCustomAttributes(typeof(T), true);
            // If we didn't get anything, return null.
            if ((attributes == null) || (attributes.Length == 0)) return null;
            // Convert the first attribute value into the desired type and return it.
            return (T)attributes[0];
        }

        public AssemblyInfo() : this(Assembly.GetExecutingAssembly())
        {
        }

        public AssemblyInfo(Assembly assembly)
        {
            // Get values from the assembly.
            AssemblyTitleAttribute titleAttr = GetAssemblyAttribute<AssemblyTitleAttribute>(assembly);
            if (titleAttr != null) Title = titleAttr.Title;
            AssemblyDescriptionAttribute assemblyAttr = GetAssemblyAttribute<AssemblyDescriptionAttribute>(assembly);
            if (assemblyAttr != null) Description = assemblyAttr.Description;
            AssemblyCompanyAttribute companyAttr = GetAssemblyAttribute<AssemblyCompanyAttribute>(assembly);
            if (companyAttr != null) Company = companyAttr.Company;
            AssemblyProductAttribute productAttr = GetAssemblyAttribute<AssemblyProductAttribute>(assembly);
            if (productAttr != null) Product = productAttr.Product;
            AssemblyCopyrightAttribute copyrightAttr = GetAssemblyAttribute<AssemblyCopyrightAttribute>(assembly);
            if (copyrightAttr != null) Copyright = copyrightAttr.Copyright;
            AssemblyTrademarkAttribute trademarkAttr = GetAssemblyAttribute<AssemblyTrademarkAttribute>(assembly);
            if (trademarkAttr != null) Trademark = trademarkAttr.Trademark;
            AssemblyVersion = assembly.GetName().Version.ToString();
            AssemblyFileVersionAttribute fileVersionAttr = GetAssemblyAttribute<AssemblyFileVersionAttribute>(assembly);
            if (fileVersionAttr != null) FileVersion = fileVersionAttr.Version;
            GuidAttribute guidAttr = GetAssemblyAttribute<GuidAttribute>(assembly);
            if (guidAttr != null) Guid = guidAttr.Value;
            NeutralResourcesLanguageAttribute languageAttr = GetAssemblyAttribute<NeutralResourcesLanguageAttribute>(assembly);
            if (languageAttr != null) NeutralLanguage = languageAttr.CultureName;
            ComVisibleAttribute comAttr = GetAssemblyAttribute<ComVisibleAttribute>(assembly);
            if (comAttr != null) IsComVisible = comAttr.Value;
        }
    }
    /// <summary>
    /// Interaction logic for ThongTin.xaml
    /// </summary>
    public partial class W_ThongTin : Window
    {
        private W_ThongTin()
        {
            InitializeComponent();
        }

        private static W_ThongTin _win = null;

        public static void f_Show()
        {
            if(_win == null)
            {
                _win = new W_ThongTin();
                _win.Show();
            }
            else
                _win.Activate();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _win = null;
        }

        private AssemblyInfo tt = new AssemblyInfo();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //tenPm.Content = tt.Title;
            //phienban.Content = tt.FileVersion;
        }
    }
}
