﻿#pragma checksum "..\..\..\..\Windows\NhanSu\Wp_SuaCa.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77307DD976D6846B8897CF4016B401DEA94BE3D6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SgCafe.Windows.NhanSu;
using StyleCF.Control;
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


namespace SgCafe.Windows.NhanSu {
    
    
    /// <summary>
    /// Wp_SuaCa
    /// </summary>
    public partial class Wp_SuaCa : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Windows\NhanSu\Wp_SuaCa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox maCa;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Windows\NhanSu\Wp_SuaCa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tenCa;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Windows\NhanSu\Wp_SuaCa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal StyleCF.Control.TimeCf batdau;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Windows\NhanSu\Wp_SuaCa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal StyleCF.Control.TimeCf ketthuc;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Windows\NhanSu\Wp_SuaCa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox ghiChu;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Windows\NhanSu\Wp_SuaCa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtOK;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Windows\NhanSu\Wp_SuaCa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtHuy;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SgCafe;component/windows/nhansu/wp_suaca.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\NhanSu\Wp_SuaCa.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\Windows\NhanSu\Wp_SuaCa.xaml"
            ((SgCafe.Windows.NhanSu.Wp_SuaCa)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.maCa = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tenCa = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\..\..\Windows\NhanSu\Wp_SuaCa.xaml"
            this.tenCa.KeyUp += new System.Windows.Input.KeyEventHandler(this.tenCa_KeyUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.batdau = ((StyleCF.Control.TimeCf)(target));
            return;
            case 5:
            this.ketthuc = ((StyleCF.Control.TimeCf)(target));
            return;
            case 6:
            this.ghiChu = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 7:
            this.BtOK = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\Windows\NhanSu\Wp_SuaCa.xaml"
            this.BtOK.Click += new System.Windows.RoutedEventHandler(this.BtOK_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BtHuy = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\Windows\NhanSu\Wp_SuaCa.xaml"
            this.BtHuy.Click += new System.Windows.RoutedEventHandler(this.BtHuy_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

