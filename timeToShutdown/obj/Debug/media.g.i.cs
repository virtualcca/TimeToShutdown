﻿#pragma checksum "..\..\media.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "35CBE4F3D79DE0AB6946DEE50F53F832"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34003
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
    /// media
    /// </summary>
    public partial class media : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\media.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement mediaElement1;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\media.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.BeginStoryboard sbm;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\media.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.MediaTimeline mediatimeline;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\media.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Play;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\media.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid playGrid;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\media.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider Slider1;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\media.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\media.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Open_MenuItem;
        
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
            System.Uri resourceLocater = new System.Uri("/timeToShutdown;component/media.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\media.xaml"
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
            this.mediaElement1 = ((System.Windows.Controls.MediaElement)(target));
            
            #line 7 "..\..\media.xaml"
            this.mediaElement1.MediaOpened += new System.Windows.RoutedEventHandler(this.mediaElement1_MediaOpened_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.sbm = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 3:
            this.mediatimeline = ((System.Windows.Media.MediaTimeline)(target));
            
            #line 15 "..\..\media.xaml"
            this.mediatimeline.CurrentTimeInvalidated += new System.EventHandler(this.mediatimeline_CurrentTimeInvalidated_1);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Play = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.playGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.Slider1 = ((System.Windows.Controls.Slider)(target));
            return;
            case 7:
            this.text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Open_MenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 38 "..\..\media.xaml"
            this.Open_MenuItem.Click += new System.Windows.RoutedEventHandler(this.Open_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
