﻿#pragma checksum "..\..\Set.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F10B3AD53F753A5C5081D03E4312B6C1"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.33440
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace timeToShutdown {
    
    
    /// <summary>
    /// Set
    /// </summary>
    public partial class Set : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\Set.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid maingrid;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Set.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button close;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Set.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid setMain;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Set.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel firstLine;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\Set.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle Original;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Set.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle SkyBlue;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Set.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle GreenYellow;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Set.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle Pink;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Set.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle Levender;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Set.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle Khaki;
        
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
            System.Uri resourceLocater = new System.Uri("/timeToShutdown;component/set.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Set.xaml"
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
            
            #line 4 "..\..\Set.xaml"
            ((timeToShutdown.Set)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.maingrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.close = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\Set.xaml"
            this.close.Click += new System.Windows.RoutedEventHandler(this.close_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.setMain = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.firstLine = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.Original = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 38 "..\..\Set.xaml"
            this.Original.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Select_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SkyBlue = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 39 "..\..\Set.xaml"
            this.SkyBlue.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Select_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.GreenYellow = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 41 "..\..\Set.xaml"
            this.GreenYellow.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Select_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Pink = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 45 "..\..\Set.xaml"
            this.Pink.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Select_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Levender = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 47 "..\..\Set.xaml"
            this.Levender.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Select_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Khaki = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 49 "..\..\Set.xaml"
            this.Khaki.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Select_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

