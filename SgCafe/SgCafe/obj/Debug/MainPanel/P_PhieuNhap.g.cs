﻿#pragma checksum "..\..\..\MainPanel\P_PhieuNhap.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5D00F4F67E773E2EC705D3EBC8BC3C1410FCBD63"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SgCafe.MainPanel;
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


namespace SgCafe.MainPanel {
    
    
    /// <summary>
    /// P_PhieuNhap
    /// </summary>
    public partial class P_PhieuNhap : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\MainPanel\P_PhieuNhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button them;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\MainPanel\P_PhieuNhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sua;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\MainPanel\P_PhieuNhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button xoa;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\MainPanel\P_PhieuNhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button inP;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\MainPanel\P_PhieuNhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView dmPN;
        
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
            System.Uri resourceLocater = new System.Uri("/SgCafe;component/mainpanel/p_phieunhap.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainPanel\P_PhieuNhap.xaml"
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
            
            #line 9 "..\..\..\MainPanel\P_PhieuNhap.xaml"
            ((SgCafe.MainPanel.P_PhieuNhap)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.them = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\MainPanel\P_PhieuNhap.xaml"
            this.them.Click += new System.Windows.RoutedEventHandler(this.them_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.sua = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\MainPanel\P_PhieuNhap.xaml"
            this.sua.Click += new System.Windows.RoutedEventHandler(this.sua_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.xoa = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\MainPanel\P_PhieuNhap.xaml"
            this.xoa.Click += new System.Windows.RoutedEventHandler(this.xoa_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.inP = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\MainPanel\P_PhieuNhap.xaml"
            this.inP.Click += new System.Windows.RoutedEventHandler(this.inP_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dmPN = ((System.Windows.Controls.ListView)(target));
            
            #line 40 "..\..\..\MainPanel\P_PhieuNhap.xaml"
            this.dmPN.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dmPN_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
