﻿#pragma checksum "D:\work\Projects x\YES or NO\YESorNO\YES or NO\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "26791861FDFC553B038E9FF8F3CF3C27"
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


namespace YES_or_NO {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal GoogleAds.AdView ads;
        
        internal System.Windows.Controls.TextBox content;
        
        internal System.Windows.Controls.Grid confirmPopup;
        
        internal System.Windows.Controls.TextBlock warning;
        
        internal System.Windows.Controls.Grid saySomething;
        
        internal System.Windows.Controls.TextBlock somthingToSay;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/YES%20or%20NO;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ads = ((GoogleAds.AdView)(this.FindName("ads")));
            this.content = ((System.Windows.Controls.TextBox)(this.FindName("content")));
            this.confirmPopup = ((System.Windows.Controls.Grid)(this.FindName("confirmPopup")));
            this.warning = ((System.Windows.Controls.TextBlock)(this.FindName("warning")));
            this.saySomething = ((System.Windows.Controls.Grid)(this.FindName("saySomething")));
            this.somthingToSay = ((System.Windows.Controls.TextBlock)(this.FindName("somthingToSay")));
        }
    }
}

