﻿#pragma checksum "E:\work\Projects x\NarutoOST\NarutoOST\PlayingPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "413B406CA9F35A024787BD16BB37206D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Coding4Fun.Toolkit.Controls;
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
    
    
    public partial class PlayingPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Media.Animation.Storyboard ImagePlaying;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Image background;
        
        internal System.Windows.Shapes.Ellipse image;
        
        internal Coding4Fun.Toolkit.Controls.RoundButton shareButton;
        
        internal Coding4Fun.Toolkit.Controls.RoundButton favoriteButton;
        
        internal Coding4Fun.Toolkit.Controls.RoundButton reportButton;
        
        internal Coding4Fun.Toolkit.Controls.RoundButton backButton;
        
        internal Coding4Fun.Toolkit.Controls.RoundButton playButton;
        
        internal Coding4Fun.Toolkit.Controls.RoundButton nextButton;
        
        internal Coding4Fun.Toolkit.Controls.RoundButton reviewButton;
        
        internal System.Windows.Controls.TextBlock title;
        
        internal System.Windows.Controls.TextBlock buffering;
        
        internal System.Windows.Controls.ListBox lv;
        
        internal System.Windows.Controls.ProgressBar Loading;
        
        internal GoogleAds.AdView ads;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/NarutoOST;component/PlayingPage.xaml", System.UriKind.Relative));
            this.ImagePlaying = ((System.Windows.Media.Animation.Storyboard)(this.FindName("ImagePlaying")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.background = ((System.Windows.Controls.Image)(this.FindName("background")));
            this.image = ((System.Windows.Shapes.Ellipse)(this.FindName("image")));
            this.shareButton = ((Coding4Fun.Toolkit.Controls.RoundButton)(this.FindName("shareButton")));
            this.favoriteButton = ((Coding4Fun.Toolkit.Controls.RoundButton)(this.FindName("favoriteButton")));
            this.reportButton = ((Coding4Fun.Toolkit.Controls.RoundButton)(this.FindName("reportButton")));
            this.backButton = ((Coding4Fun.Toolkit.Controls.RoundButton)(this.FindName("backButton")));
            this.playButton = ((Coding4Fun.Toolkit.Controls.RoundButton)(this.FindName("playButton")));
            this.nextButton = ((Coding4Fun.Toolkit.Controls.RoundButton)(this.FindName("nextButton")));
            this.reviewButton = ((Coding4Fun.Toolkit.Controls.RoundButton)(this.FindName("reviewButton")));
            this.title = ((System.Windows.Controls.TextBlock)(this.FindName("title")));
            this.buffering = ((System.Windows.Controls.TextBlock)(this.FindName("buffering")));
            this.lv = ((System.Windows.Controls.ListBox)(this.FindName("lv")));
            this.Loading = ((System.Windows.Controls.ProgressBar)(this.FindName("Loading")));
            this.ads = ((GoogleAds.AdView)(this.FindName("ads")));
        }
    }
}

