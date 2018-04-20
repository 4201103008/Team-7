using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SgCafe;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Microsoft.Shell;
using System.Threading;
using InforCf;

namespace SgCafe
{
    class App : System.Windows.Application, ISingleInstanceApp
    {

        private bool _contentLoaded;

        public static Window _win = null;

        public App()
        {
            Thread t = new Thread(new ThreadStart(ClearCf.SystemAuto));
            t.Start();
        }

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if(_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SgCafe;component/Resource.xaml", System.UriKind.Relative);
            System.Windows.Application.LoadComponent(this, resourceLocater);
        }

        private const string Unique = "SgCafe16hvg05";

        /// <summary>
        /// Application Entry Point.
        /// </summary>
        [System.STAThreadAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public static void Main()
        {
            if(SingleInstance<App>.InitializeAsFirstInstance(Unique))
            {
                SgCafe.App app = new SgCafe.App();
                app.InitializeComponent();
                _win = new DangNhap();
                app.Run(_win);
                SingleInstance<App>.Cleanup();
            }
        }

        public bool SignalExternalCommandLineArgs(System.Collections.Generic.IList<string> args)
        {
            return true;
        }
    }
}
