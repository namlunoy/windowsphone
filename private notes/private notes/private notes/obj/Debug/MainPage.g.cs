﻿#pragma checksum "D:\work\Projects x\private notes\private notes\private notes\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CEB6E44EF42B5E2BD7D692821AF8E6D5"
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


namespace private_notes {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Media.Animation.Storyboard HideNewPass;
        
        internal System.Windows.Media.Animation.Storyboard HidePass;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal GoogleAds.AdView ads;
        
        internal System.Windows.Controls.Grid pass;
        
        internal System.Windows.Controls.PasswordBox passx;
        
        internal System.Windows.Controls.Grid newpass;
        
        internal System.Windows.Controls.PasswordBox newpass1;
        
        internal System.Windows.Controls.PasswordBox newpass2;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/private%20notes;component/MainPage.xaml", System.UriKind.Relative));
            this.HideNewPass = ((System.Windows.Media.Animation.Storyboard)(this.FindName("HideNewPass")));
            this.HidePass = ((System.Windows.Media.Animation.Storyboard)(this.FindName("HidePass")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ads = ((GoogleAds.AdView)(this.FindName("ads")));
            this.pass = ((System.Windows.Controls.Grid)(this.FindName("pass")));
            this.passx = ((System.Windows.Controls.PasswordBox)(this.FindName("passx")));
            this.newpass = ((System.Windows.Controls.Grid)(this.FindName("newpass")));
            this.newpass1 = ((System.Windows.Controls.PasswordBox)(this.FindName("newpass1")));
            this.newpass2 = ((System.Windows.Controls.PasswordBox)(this.FindName("newpass2")));
        }
    }
}

