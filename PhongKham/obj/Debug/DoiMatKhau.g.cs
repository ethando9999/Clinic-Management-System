﻿#pragma checksum "..\..\DoiMatKhau.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B65A927DFEAA1E6006D40B6F08EDEA185EA990C8A92750B081493D023BA28A9E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PhongKham;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace PhongKham {
    
    
    /// <summary>
    /// DoiMatKhau
    /// </summary>
    public partial class DoiMatKhau : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\DoiMatKhau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\DoiMatKhau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassword2;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\DoiMatKhau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassword1;
        
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
            System.Uri resourceLocater = new System.Uri("/PhongKham;component/doimatkhau.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DoiMatKhau.xaml"
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
            
            #line 20 "..\..\DoiMatKhau.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Xacnhan_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.txtPassword2 = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 29 "..\..\DoiMatKhau.xaml"
            this.txtPassword2.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TextBox_MouseDown2);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtPassword1 = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 30 "..\..\DoiMatKhau.xaml"
            this.txtPassword1.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TextBox_MouseDown1);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 31 "..\..\DoiMatKhau.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Trove_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

