﻿#pragma checksum "..\..\..\MainPanel\P_MatHang.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E3B325BE80BB854A45E4C4E845BC037212B40198"
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
    /// P_MatHang
    /// </summary>
    public partial class P_MatHang : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\MainPanel\P_MatHang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboLoai;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\MainPanel\P_MatHang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button themMoi;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\MainPanel\P_MatHang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sua;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\MainPanel\P_MatHang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button xoa;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\MainPanel\P_MatHang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listMatHang;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\MainPanel\P_MatHang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listCungCap;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\MainPanel\P_MatHang.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock;
        
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
            System.Uri resourceLocater = new System.Uri("/SgCafe;component/mainpanel/p_mathang.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainPanel\P_MatHang.xaml"
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
            this.comboLoai = ((System.Windows.Controls.ComboBox)(target));
            
            #line 36 "..\..\..\MainPanel\P_MatHang.xaml"
            this.comboLoai.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboLoai_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.themMoi = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\MainPanel\P_MatHang.xaml"
            this.themMoi.Click += new System.Windows.RoutedEventHandler(this.themMoi_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.sua = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\MainPanel\P_MatHang.xaml"
            this.sua.Click += new System.Windows.RoutedEventHandler(this.chinhSua_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.xoa = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\MainPanel\P_MatHang.xaml"
            this.xoa.Click += new System.Windows.RoutedEventHandler(this.xoa_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.listMatHang = ((System.Windows.Controls.ListView)(target));
            
            #line 45 "..\..\..\MainPanel\P_MatHang.xaml"
            this.listMatHang.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listMatHang_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.listCungCap = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.textBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
