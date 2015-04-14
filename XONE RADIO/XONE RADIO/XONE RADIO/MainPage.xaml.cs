using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using XONE_RADIO.Resources;
using Mannup.Model;

namespace XONE_RADIO
{
    public partial class MainPage : PhoneApplicationPage
    {
        Uri currentUrl;
        int count = 0;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            if (Helper.CheckNetwork())
            {
                // Sample code to localize the ApplicationBar
                //BuildLocalizedApplicationBar();
                web.Navigate(new Uri("http://www.xonefm.com/"));

                web.Navigated += web_Navigated;
                web.Navigating += web_Navigating;
                
            }
            else
            {
                MessageBox.Show("Xin lỗi! Bạn phải kết nối với Internet trước!");
                Application.Current.Terminate();
            }
            
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ứng dụng?", "Thoát?", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                Application.Current.Terminate();
        }

        void web_Navigating(object sender, NavigatingEventArgs e)
        {
            loadView.Visibility = System.Windows.Visibility.Visible;
        }
        GoogleAds.InterstitialAd ads;
        void web_Navigated(object sender, NavigationEventArgs e)
        {
            loadView.Visibility = System.Windows.Visibility.Collapsed;
            count++;
            if (count % 3 == 0)
            {
                ads = new GoogleAds.InterstitialAd(Helper.BillboardId);
                ads.ReceivedAd += ads_ReceivedAd;
                ads.LoadAd(new GoogleAds.AdRequest());
            }
        }
        void ads_ReceivedAd(object sender, GoogleAds.AdEventArgs e)
        {
            ads.ShowAd();
        }

        private void web_LoadCompleted(object sender, NavigationEventArgs e)
        {

        }

    }
}