﻿#pragma checksum "D:\work\Projects x\Naruto Wikia\Naruto Wikia\Naruto Wikia\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8943DDB8A84303498A416D340FA197BC"
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


namespace Naruto_Wikia {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.ListBox listboxArticles;
        
        internal System.Windows.Controls.ListBox listboxMedia;
        
        internal System.Windows.Controls.ListBox listboxOthers;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Naruto%20Wikia;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.listboxArticles = ((System.Windows.Controls.ListBox)(this.FindName("listboxArticles")));
            this.listboxMedia = ((System.Windows.Controls.ListBox)(this.FindName("listboxMedia")));
            this.listboxOthers = ((System.Windows.Controls.ListBox)(this.FindName("listboxOthers")));
        }
    }
}

