﻿#pragma checksum "E:\work\Project Competition\MyQuiz\MyQuiz\MyQuiz\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "284E94D26CAF80DEFFE4067678AB0707"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace MyQuiz {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Media.Animation.Storyboard Loading;
        
        internal System.Windows.Media.Animation.Storyboard loadTest;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid grid;
        
        internal System.Windows.Controls.Grid grid1;
        
        internal System.Windows.Controls.Grid grid2;
        
        internal System.Windows.Controls.Grid grid3;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/MyQuiz;component/MainPage.xaml", System.UriKind.Relative));
            this.Loading = ((System.Windows.Media.Animation.Storyboard)(this.FindName("Loading")));
            this.loadTest = ((System.Windows.Media.Animation.Storyboard)(this.FindName("loadTest")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.grid = ((System.Windows.Controls.Grid)(this.FindName("grid")));
            this.grid1 = ((System.Windows.Controls.Grid)(this.FindName("grid1")));
            this.grid2 = ((System.Windows.Controls.Grid)(this.FindName("grid2")));
            this.grid3 = ((System.Windows.Controls.Grid)(this.FindName("grid3")));
        }
    }
}

