﻿#pragma checksum "..\..\..\..\Windows\NhanSu\W_UngLuong.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "560F47A21F8EFBE2B7AC9B1E5059F96F2A7730D9"
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
    /// W_UngLuong
    /// </summary>
    public partial class W_UngLuong : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\Windows\NhanSu\W_UngLuong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox nhanVien;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Windows\NhanSu\W_UngLuong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox soTien;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Windows\NhanSu\W_UngLuong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtOK;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Windows\NhanSu\W_UngLuong.xaml"
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
            System.Uri resourceLocater = new System.Uri("/SgCafe;component/windows/nhansu/w_ungluong.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\NhanSu\W_UngLuong.xaml"
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
            
            #line 8 "..\..\..\..\Windows\NhanSu\W_UngLuong.xaml"
            ((SgCafe.Windows.NhanSu.W_UngLuong)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nhanVien = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\..\..\Windows\NhanSu\W_UngLuong.xaml"
            this.nhanVien.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.nhanVien_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.soTien = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\..\..\Windows\NhanSu\W_UngLuong.xaml"
            this.soTien.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.soTien_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 20 "..\..\..\..\Windows\NhanSu\W_UngLuong.xaml"
            this.soTien.KeyUp += new System.Windows.Input.KeyEventHandler(this.soTien_KeyUp);
            
            #line default
            #line hidden
            
            #line 20 "..\..\..\..\Windows\NhanSu\W_UngLuong.xaml"
            this.soTien.GotKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.soTien_GotKeyboardFocus);
            
            #line default
            #line hidden
            
            #line 20 "..\..\..\..\Windows\NhanSu\W_UngLuong.xaml"
            this.soTien.LostKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.soTien_LostKeyboardFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtOK = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Windows\NhanSu\W_UngLuong.xaml"
            this.BtOK.Click += new System.Windows.RoutedEventHandler(this.BtOK_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtHuy = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\Windows\NhanSu\W_UngLuong.xaml"
            this.BtHuy.Click += new System.Windows.RoutedEventHandler(this.BtHuy_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

