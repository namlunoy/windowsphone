﻿#pragma checksum "E:\work\Projects x\Guu\Guu\Guu\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5A157B0824BE0A046BF1406CEBE50E25"
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
using Microsoft.Phone.Shell;
using SlideView.Library;
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


namespace Guu {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Media.Animation.Storyboard TimKiem_Hien;
        
        internal System.Windows.Media.Animation.Storyboard TimKiem_An;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton rateButton;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton backButton;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton forwardButton;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton shareButton;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal SlideView.Library.SlideView slideView;
        
        internal System.Windows.Controls.Grid MenuPart;
        
        internal System.Windows.Controls.ListBox listCategory;
        
        internal System.Windows.Controls.Grid MainPart;
        
        internal Microsoft.Phone.Controls.WebBrowser web;
        
        internal System.Windows.Controls.Grid loadingView;
        
        internal System.Windows.Controls.Grid grid;
        
        internal System.Windows.Controls.TextBox txtTimkiem;
        
        internal System.Windows.Controls.TextBlock title;
        
        internal GoogleAds.AdView adsBanner;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Guu;component/MainPage.xaml", System.UriKind.Relative));
            this.TimKiem_Hien = ((System.Windows.Media.Animation.Storyboard)(this.FindName("TimKiem_Hien")));
            this.TimKiem_An = ((System.Windows.Media.Animation.Storyboard)(this.FindName("TimKiem_An")));
            this.rateButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("rateButton")));
            this.backButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("backButton")));
            this.forwardButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("forwardButton")));
            this.shareButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("shareButton")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.slideView = ((SlideView.Library.SlideView)(this.FindName("slideView")));
            this.MenuPart = ((System.Windows.Controls.Grid)(this.FindName("MenuPart")));
            this.listCategory = ((System.Windows.Controls.ListBox)(this.FindName("listCategory")));
            this.MainPart = ((System.Windows.Controls.Grid)(this.FindName("MainPart")));
            this.web = ((Microsoft.Phone.Controls.WebBrowser)(this.FindName("web")));
            this.loadingView = ((System.Windows.Controls.Grid)(this.FindName("loadingView")));
            this.grid = ((System.Windows.Controls.Grid)(this.FindName("grid")));
            this.txtTimkiem = ((System.Windows.Controls.TextBox)(this.FindName("txtTimkiem")));
            this.title = ((System.Windows.Controls.TextBlock)(this.FindName("title")));
            this.adsBanner = ((GoogleAds.AdView)(this.FindName("adsBanner")));
        }
    }
}

