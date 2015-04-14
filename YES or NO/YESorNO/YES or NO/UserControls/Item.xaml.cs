using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace YES_or_NO.UserControls
{
    public partial class Item : UserControl
    {
        private Decision decision;

        public Item(Decision d, int i)
        {
            InitializeComponent();
            decision = d;
            txtContent.Text = d.Content;
            txtDate.Text = d.Time.ToShortDateString();
            bg.Visibility = (i % 2 == 0) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed; 

            switch (d.YourChoice)
            {
                case Choices.YES:
                    txtYES.Visibility = System.Windows.Visibility.Visible;
                    break;
                case Choices.NO:
                    txtNO.Visibility = System.Windows.Visibility.Visible;
                    break;
                default:
                    txtThink.Visibility = System.Windows.Visibility.Visible;
                    break;
            }

            Loaded += Item_Loaded;
        }

        void Item_Loaded(object sender, RoutedEventArgs e)
        {
            if (txtContent.ActualHeight > txtContent.MaxHeight)
                more.Visibility = System.Windows.Visibility.Visible;
            else more.Visibility = System.Windows.Visibility.Collapsed;
        }

    }
}
