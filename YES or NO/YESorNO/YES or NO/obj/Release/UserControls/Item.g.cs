﻿#pragma checksum "D:\work\Projects x\YES or NO\YESorNO\YES or NO\UserControls\Item.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A2A81221D8A2089BB9131DA5F35AD8DF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace YES_or_NO.UserControls {
    
    
    public partial class Item : System.Windows.Controls.UserControl {
        
        internal System.Windows.Shapes.Rectangle bg;
        
        internal System.Windows.Controls.TextBlock txtContent;
        
        internal System.Windows.Controls.TextBlock more;
        
        internal System.Windows.Controls.TextBlock txtDate;
        
        internal System.Windows.Controls.Grid txtYES;
        
        internal System.Windows.Controls.Grid txtNO;
        
        internal System.Windows.Controls.Grid txtThink;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/YES%20or%20NO;component/UserControls/Item.xaml", System.UriKind.Relative));
            this.bg = ((System.Windows.Shapes.Rectangle)(this.FindName("bg")));
            this.txtContent = ((System.Windows.Controls.TextBlock)(this.FindName("txtContent")));
            this.more = ((System.Windows.Controls.TextBlock)(this.FindName("more")));
            this.txtDate = ((System.Windows.Controls.TextBlock)(this.FindName("txtDate")));
            this.txtYES = ((System.Windows.Controls.Grid)(this.FindName("txtYES")));
            this.txtNO = ((System.Windows.Controls.Grid)(this.FindName("txtNO")));
            this.txtThink = ((System.Windows.Controls.Grid)(this.FindName("txtThink")));
        }
    }
}

