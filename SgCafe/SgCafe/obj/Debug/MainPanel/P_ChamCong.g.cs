﻿#pragma checksum "..\..\..\MainPanel\P_ChamCong.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DA14E26BEEF87951241E0C4E76782923682D8ACB"
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
    /// P_ChamCong
    /// </summary>
    public partial class P_ChamCong : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\MainPanel\P_ChamCong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listBangLuong;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\MainPanel\P_ChamCong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button kolich;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\MainPanel\P_ChamCong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dilam;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\MainPanel\P_ChamCong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nghi;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\MainPanel\P_ChamCong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button kophep;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\MainPanel\P_ChamCong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataLich;
        
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
            System.Uri resourceLocater = new System.Uri("/SgCafe;component/mainpanel/p_chamcong.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainPanel\P_ChamCong.xaml"
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
            
            #line 9 "..\..\..\MainPanel\P_ChamCong.xaml"
            ((SgCafe.MainPanel.P_ChamCong)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.listBangLuong = ((System.Windows.Controls.ListView)(target));
            
            #line 41 "..\..\..\MainPanel\P_ChamCong.xaml"
            this.listBangLuong.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listBangLuong_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.kolich = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\MainPanel\P_ChamCong.xaml"
            this.kolich.Click += new System.Windows.RoutedEventHandler(this.kolich_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dilam = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\MainPanel\P_ChamCong.xaml"
            this.dilam.Click += new System.Windows.RoutedEventHandler(this.dilam_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.nghi = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\MainPanel\P_ChamCong.xaml"
            this.nghi.Click += new System.Windows.RoutedEventHandler(this.nghi_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.kophep = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\MainPanel\P_ChamCong.xaml"
            this.kophep.Click += new System.Windows.RoutedEventHandler(this.kophep_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dataLich = ((System.Windows.Controls.DataGrid)(target));
            
            #line 56 "..\..\..\MainPanel\P_ChamCong.xaml"
            this.dataLich.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.dataLich_SelectedCellsChanged);
            
            #line default
            #line hidden
            
            #line 56 "..\..\..\MainPanel\P_ChamCong.xaml"
            this.dataLich.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dataLich_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

