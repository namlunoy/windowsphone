﻿#pragma checksum "D:\work\Projects x\MyQuiz\MyQuiz\MyQuiz\AddingPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "035DA6F6B7FC4639652C67271BA7623A"
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


namespace MyQuiz {
    
    
    public partial class AddingPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Primitives.Popup popupNewCategory;
        
        internal System.Windows.Controls.TextBox txtNewCategoryName;
        
        internal System.Windows.Controls.Image quizImage;
        
        internal GoogleAds.AdView ads;
        
        internal System.Windows.Controls.TextBox txtQuestion;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Controls.ListPicker listbox;
        
        internal System.Windows.Controls.TextBox txtA;
        
        internal System.Windows.Controls.RadioButton rdioA;
        
        internal System.Windows.Controls.TextBox txtB;
        
        internal System.Windows.Controls.RadioButton rdioB;
        
        internal System.Windows.Controls.TextBox txtC;
        
        internal System.Windows.Controls.RadioButton rdioC;
        
        internal System.Windows.Controls.TextBox txtD;
        
        internal System.Windows.Controls.RadioButton rdioD;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MyQuiz;component/AddingPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.popupNewCategory = ((System.Windows.Controls.Primitives.Popup)(this.FindName("popupNewCategory")));
            this.txtNewCategoryName = ((System.Windows.Controls.TextBox)(this.FindName("txtNewCategoryName")));
            this.quizImage = ((System.Windows.Controls.Image)(this.FindName("quizImage")));
            this.ads = ((GoogleAds.AdView)(this.FindName("ads")));
            this.txtQuestion = ((System.Windows.Controls.TextBox)(this.FindName("txtQuestion")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.listbox = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("listbox")));
            this.txtA = ((System.Windows.Controls.TextBox)(this.FindName("txtA")));
            this.rdioA = ((System.Windows.Controls.RadioButton)(this.FindName("rdioA")));
            this.txtB = ((System.Windows.Controls.TextBox)(this.FindName("txtB")));
            this.rdioB = ((System.Windows.Controls.RadioButton)(this.FindName("rdioB")));
            this.txtC = ((System.Windows.Controls.TextBox)(this.FindName("txtC")));
            this.rdioC = ((System.Windows.Controls.RadioButton)(this.FindName("rdioC")));
            this.txtD = ((System.Windows.Controls.TextBox)(this.FindName("txtD")));
            this.rdioD = ((System.Windows.Controls.RadioButton)(this.FindName("rdioD")));
        }
    }
}

