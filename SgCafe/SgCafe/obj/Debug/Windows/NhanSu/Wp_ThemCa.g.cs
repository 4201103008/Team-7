﻿#pragma checksum "..\..\..\..\Windows\NhanSu\Wp_ThemCa.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64720A8AF0329ABF353F67419E44CE70B1F2C020"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Xpf.DXBinding;
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
    /// Wp_ThemCa
    /// </summary>
    public partial class Wp_ThemCa : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\Windows\NhanSu\Wp_ThemCa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ten;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Windows\NhanSu\Wp_ThemCa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox ghiChu;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Windows\NhanSu\Wp_ThemCa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal StyleCF.Control.TimeCf batdau;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Windows\NhanSu\Wp_ThemCa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal StyleCF.Control.TimeCf ketthuc;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Windows\NhanSu\Wp_ThemCa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtOK;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Windows\NhanSu\Wp_ThemCa.xaml"
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
            System.Uri resourceLocater = new System.Uri("/SgCafe;component/windows/nhansu/wp_themca.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\NhanSu\Wp_ThemCa.xaml"
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
            
            #line 10 "..\..\..\..\Windows\NhanSu\Wp_ThemCa.xaml"
            ((SgCafe.Windows.NhanSu.Wp_ThemCa)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ten = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\..\..\Windows\NhanSu\Wp_ThemCa.xaml"
            this.ten.KeyUp += new System.Windows.Input.KeyEventHandler(this.ten_KeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ghiChu = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 4:
            this.batdau = ((StyleCF.Control.TimeCf)(target));
            return;
            case 5:
            this.ketthuc = ((StyleCF.Control.TimeCf)(target));
            return;
            case 6:
            this.BtOK = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\Windows\NhanSu\Wp_ThemCa.xaml"
            this.BtOK.Click += new System.Windows.RoutedEventHandler(this.BtOK_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtHuy = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\Windows\NhanSu\Wp_ThemCa.xaml"
            this.BtHuy.Click += new System.Windows.RoutedEventHandler(this.BtHuy_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

