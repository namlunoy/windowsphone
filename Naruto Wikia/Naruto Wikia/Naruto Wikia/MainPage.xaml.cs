using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Net.NetworkInformation;
using GoogleAds;

namespace Naruto_Wikia
{
    public partial class MainPage : PhoneApplicationPage
    {
        public List<ChuyenMuc> ListMedia = new List<ChuyenMuc>();
        public List<ChuyenMuc> ListArticles = new List<ChuyenMuc>();
        public List<ChuyenMuc> ListOther = new List<ChuyenMuc>();
        public static ChuyenMuc selectedChuyenMuc = null;
     
        private InterstitialAd interstitialAd;

        public static bool checkNetworkConnection()
        {
            var ni = NetworkInterface.NetworkInterfaceType;

            bool IsConnected = false;
            if ((ni == NetworkInterfaceType.Wireless80211) || (ni == NetworkInterfaceType.MobileBroadbandCdma) || (ni == NetworkInterfaceType.MobileBroadbandGsm))
                IsConnected = true;
            else if (ni == NetworkInterfaceType.None)
                IsConnected = false;
            return IsConnected;

        
        }

        public MainPage()
        {
            InitializeComponent(); 
            if (!checkNetworkConnection())
            {
                MessageBox.Show("Need connect to the internet!");
                Application.Current.Terminate();
            }
           
            ListMedia.Add(ChuyenMucTH.VIDEOS);
            ListMedia.Add(ChuyenMucTH.ANIME);
            ListMedia.Add(ChuyenMucTH.PHOTOS);
            ListMedia.Add(ChuyenMucTH.MANGA);
            ListMedia.Add(ChuyenMucTH.GAMES);

            ListArticles.Add(ChuyenMucTH.CHARACTERS);
            ListArticles.Add(ChuyenMucTH.JUTSU);
            ListArticles.Add(ChuyenMucTH.TOOLS);
            ListArticles.Add(ChuyenMucTH.LOCATIONS);

            ListOther.Add(ChuyenMucTH.QUESTIONS);


            listboxMedia.ItemsSource = ListMedia;
            listboxArticles.ItemsSource = ListArticles;
            listboxOthers.ItemsSource = ListOther;


            interstitialAd = new InterstitialAd("ca-app-pub-6921176146936171/2383282248");
            interstitialAd.ReceivedAd += OnAdReceived;


            AdRequest adRequest = new AdRequest();
            interstitialAd.LoadAd(adRequest);
        }
        private void OnAdReceived(object sender, AdEventArgs e)
        {
           // Debug.WriteLine("Ad received successfully");
            interstitialAd.ShowAd();
        }
        private void selectChuyenMuc(object sender, SelectionChangedEventArgs e)
        {
            ListBox l = (ListBox)sender;
            if (e != null && e.AddedItems != null && e.AddedItems.Count > 0)
            {
                selectedChuyenMuc = (ChuyenMuc)e.AddedItems[0];
                if (selectedChuyenMuc != null)
                    this.NavigationService.Navigate(new Uri("/MainPage2.xaml", UriKind.Relative));
            }

            if (l != null)
                l.SelectedItem = null;
        }

        private void clickAbout(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/about.xaml", UriKind.Relative));
        }

        private void clickSearch(object sender, EventArgs e)
        {
            selectedChuyenMuc = null;
            this.NavigationService.Navigate(new Uri("/MainPage2.xaml", UriKind.Relative));
        }
    }
}