using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Naruto_Wikia.Resources;
using Microsoft.Phone.Net.NetworkInformation;
using GoogleAds;

namespace Naruto_Wikia
{
    public partial class MainPage2 : PhoneApplicationPage
    {
        // Constructor

        Uri HomePageUri;
        private InterstitialAd interstitialAd;
        public MainPage2()
        {
            InitializeComponent();

            browser.LoadCompleted += browser_LoadCompleted;
            browser.Navigating += browser_Navigating;
            browser.Navigated += browser_Navigated;
            browser.NavigationFailed += browser_NavigationFailed;

            Loaded += MainPage2_Loaded;


            interstitialAd = new InterstitialAd("ca-app-pub-6921176146936171/2383282248");
            interstitialAd.ReceivedAd += OnAdReceived;

            AdRequest adRequest = new AdRequest();
            interstitialAd.LoadAd(adRequest);
        }
        private void OnAdReceived(object sender, AdEventArgs e)
        {
            //Debug.WriteLine("Ad received successfully");
            interstitialAd.ShowAd();
        }

        void MainPage2_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainPage.selectedChuyenMuc == null)
                HomePageUri = new Uri("http://naruto.wikia.com/wiki/Special:Search");
            else
                HomePageUri = MainPage.selectedChuyenMuc.HomeUri;

                browser.Navigate(HomePageUri);
        }

        void browser_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            clickSearch(sender, e);
        }

        void browser_Navigated(object sender, NavigationEventArgs e)
        {
            Loadedx();
        }

        void browser_Navigating(object sender, NavigatingEventArgs e)
        {
            Loading("Loading...");
        }

        void Loading(string mess)
        {
            loading.Visibility = System.Windows.Visibility.Visible;
            txt.Text = mess;
        }

        void Loadedx()
        {
            loading.Visibility = System.Windows.Visibility.Collapsed;
        }

        void browser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if (backButton != null)
                backButton.IsEnabled = browser.CanGoBack;
            if (forwardButton != null)
                forwardButton.IsEnabled = browser.CanGoForward;
        }

        private void clickBack(object sender, EventArgs e)
        {
            if (browser.CanGoBack)
                browser.GoBack();
            else MessageBox.Show("ended!");

        }

        private void clickForward(object sender, EventArgs e)
        {
            if (browser.CanGoForward)
                browser.GoForward();
            else MessageBox.Show("ended!");
        }

        private void clickHome(object sender, EventArgs e)
        { browser.Navigate(HomePageUri); }

        private void clickSearch(object sender, EventArgs e)
        { 
            
            browser.Navigate(new Uri("http://naruto.wikia.com/wiki/Special:Search")); 
        
        }
    }
}