﻿#pragma checksum "D:\work\Projects x\NarutoOST\NarutoOST\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D831317C334E5916BBDBDFEB85C67D4A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GoogleAds;
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


namespace NarutoOST {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Media.Animation.Storyboard TitleRunning;
        
        internal System.Windows.Media.Animation.Storyboard Loading;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Media.ImageBrush background;
        
        internal System.Windows.Controls.ListBox lv1;
        
        internal System.Windows.Controls.ListBox lv2;
        
        internal System.Windows.Controls.ListBox lv3;
        
        internal GoogleAds.AdView ads;
        
        internal System.Windows.Controls.TextBlock title;
        
        internal System.Windows.Controls.Border loading;
        
        internal System.Windows.Controls.Image image;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/NarutoOST;component/MainPage.xaml", System.UriKind.Relative));
            this.TitleRunning = ((System.Windows.Media.Animation.Storyboard)(this.FindName("TitleRunning")));
            this.Loading = ((System.Windows.Media.Animation.Storyboard)(this.FindName("Loading")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.background = ((System.Windows.Media.ImageBrush)(this.FindName("background")));
            this.lv1 = ((System.Windows.Controls.ListBox)(this.FindName("lv1")));
            this.lv2 = ((System.Windows.Controls.ListBox)(this.FindName("lv2")));
            this.lv3 = ((System.Windows.Controls.ListBox)(this.FindName("lv3")));
            this.ads = ((GoogleAds.AdView)(this.FindName("ads")));
            this.title = ((System.Windows.Controls.TextBlock)(this.FindName("title")));
            this.loading = ((System.Windows.Controls.Border)(this.FindName("loading")));
            this.image = ((System.Windows.Controls.Image)(this.FindName("image")));
        }
    }
}

