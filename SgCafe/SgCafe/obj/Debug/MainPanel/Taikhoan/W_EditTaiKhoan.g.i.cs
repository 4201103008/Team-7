﻿#pragma checksum "..\..\..\..\MainPanel\Taikhoan\W_EditTaiKhoan.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15C65BD4E5F4AF884F97BCCE636B3A2144C7ACBE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SgCafe.MainPanel.Taikhoan;
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


namespace SgCafe.MainPanel.Taikhoan {
    
    
    /// <summary>
    /// W_EditTaiKhoan
    /// </summary>
    public partial class W_EditTaiKhoan : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\MainPanel\Taikhoan\W_EditTaiKhoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox taikhoan;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\MainPanel\Taikhoan\W_EditTaiKhoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox matkhau;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\MainPanel\Taikhoan\W_EditTaiKhoan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtOK;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\MainPanel\Taikhoan\W_EditTaiKhoan.xaml"
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
            System.Uri resourceLocater = new System.Uri("/SgCafe;component/mainpanel/taikhoan/w_edittaikhoan.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MainPanel\Taikhoan\W_EditTaiKhoan.xaml"
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
            this.taikhoan = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\..\MainPanel\Taikhoan\W_EditTaiKhoan.xaml"
            this.taikhoan.KeyUp += new System.Windows.Input.KeyEventHandler(this.taikhoan_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.matkhau = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\..\..\MainPanel\Taikhoan\W_EditTaiKhoan.xaml"
            this.matkhau.KeyUp += new System.Windows.Input.KeyEventHandler(this.matkhau_KeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtOK = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\MainPanel\Taikhoan\W_EditTaiKhoan.xaml"
            this.BtOK.Click += new System.Windows.RoutedEventHandler(this.BtOK_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtHuy = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\MainPanel\Taikhoan\W_EditTaiKhoan.xaml"
            this.BtHuy.Click += new System.Windows.RoutedEventHandler(this.BtHuy_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
