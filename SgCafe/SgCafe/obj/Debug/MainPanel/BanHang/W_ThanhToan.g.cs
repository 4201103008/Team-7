﻿#pragma checksum "..\..\..\..\MainPanel\BanHang\W_ThanhToan.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D71DD04537EB18B5E4A4E60FF521CE1D411CBFAB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Core;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.ConditionalFormatting;
using DevExpress.Xpf.Core.DataSources;
using DevExpress.Xpf.Core.Serialization;
using DevExpress.Xpf.Core.ServerMode;
using DevExpress.Xpf.DXBinding;
using DevExpress.Xpf.Ribbon;
using SgCafe.MainPanel.BanHang;
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


namespace SgCafe.MainPanel.BanHang {
    
    
    /// <summary>
    /// W_ThanhToan
    /// </summary>
    public partial class W_ThanhToan : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\..\MainPanel\BanHang\W_ThanhToan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ban;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\MainPanel\BanHang\W_ThanhToan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tong;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\MainPanel\BanHang\W_ThanhToan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox khachdua;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\MainPanel\BanHang\W_ThanhToan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tra;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\MainPanel\BanHang\W_ThanhToan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtIn;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\MainPanel\BanHang\W_ThanhToan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtOK;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\MainPanel\BanHang\W_ThanhToan.xaml"
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
            System.Uri resourceLocater = new System.Uri("/SgCafe;component/mainpanel/banhang/w_thanhtoan.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MainPanel\BanHang\W_ThanhToan.xaml"
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
            this.ban = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.tong = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.khachdua = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\..\MainPanel\BanHang\W_ThanhToan.xaml"
            this.khachdua.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.khachdua_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\..\MainPanel\BanHang\W_ThanhToan.xaml"
            this.khachdua.GotKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.khachdua_GotKeyboardFocus);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\..\MainPanel\BanHang\W_ThanhToan.xaml"
            this.khachdua.LostKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.khachdua_LostKeyboardFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tra = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.BtIn = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\..\MainPanel\BanHang\W_ThanhToan.xaml"
            this.BtIn.Click += new System.Windows.RoutedEventHandler(this.BtIn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtOK = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\MainPanel\BanHang\W_ThanhToan.xaml"
            this.BtOK.Click += new System.Windows.RoutedEventHandler(this.BtOK_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtHuy = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\..\MainPanel\BanHang\W_ThanhToan.xaml"
            this.BtHuy.Click += new System.Windows.RoutedEventHandler(this.BtHuy_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

