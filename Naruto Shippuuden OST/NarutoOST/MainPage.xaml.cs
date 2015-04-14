using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using NarutoOST.Models;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using vservWindowsPhone;

namespace NarutoOST
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static ObservableCollection<Song> AllSong = new ObservableCollection<Song>();
        public static ObservableCollection<Song> list1 = new ObservableCollection<Song>();
        public static ObservableCollection<Song> list2 = new ObservableCollection<Song>();
        public static ObservableCollection<Song> list3 = new ObservableCollection<Song>();
        public static int AdsCount = 0;
        public static String bacgroundImage = "";
        public static Song selectedSong = null;
        public static TextBlock mainTitle = null;

        GoogleAds.InterstitialAd billboard;
       
        public MainPage()
        {
            InitializeComponent();

            if (Helper<Song>.CheckInternet())
            {

                loading.Visibility = System.Windows.Visibility.Visible;
                Helper<Song>.DoneRequest += Helper_DoneRequest;
                Helper<Song>.Request("http://conghoang.byethost15.com/naruto_shippuuden_ost/listsong.xml");

        
                if (Helper<Song>.random.Next(10) % 2 == 0)
                {
                    Helper<Song>.RequestAds();
                }
                else
                {
                    Helper<Song>.LoadVserv(LayoutRoot);
                }

                TitleRunning.Completed += runcomplete;
                TitleRunning.Begin();
                mainTitle = title;
                Loading.Begin();
                Loading.Completed += Loading_Completed;

               
            }
            else
            {
                MessageBox.Show("You need connect to the internet!");
                Application.Current.Terminate();
            }

        }

        void VMB_VservAdNoFill(object sender, EventArgs e)
        {
            Helper<Song>.RequestAds();
        }

        void billboard_ReceivedAd(object sender, GoogleAds.AdEventArgs e)
        {
            billboard.ShowAd();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            bacgroundImage = "/Assets/bg" + Helper<Song>.Rand.Next(1, 7) + ".jpg";
            background.ImageSource = new BitmapImage(new Uri(bacgroundImage, UriKind.Relative));
        }

        void Loading_Completed(object sender, EventArgs e)
        {
            Loading.Begin();
        }


        private void runcomplete(object sender, EventArgs e) { TitleRunning.Begin(); }


        async void Helper_DoneRequest(object sender, string e)
        {
            //Debug.WriteLine(e);
            //Dispatcher.BeginInvoke(() => txt.Text = e);
            AllSong = Helper<Song>.PairXML(e);
            list3 = await Helper<Song>.readXMLAsync("data.xml");
            foreach (Song s in AllSong)
            {
                if (list3.Contains(s))
                {
                    s.IsInFavorite = true;
                }
                switch (s.Loai)
                {
                    case 1:
                        s.STT = list1.Count + 1;
                        list1.Add(s);
                        break;
                    case 2:
                        s.STT = list2.Count + 1;
                        list2.Add(s);
                        break;
                }
            }

            Dispatcher.BeginInvoke(() =>
            {
                lv1.ItemsSource = list1;
                lv2.ItemsSource = list2;
                lv3.ItemsSource = list3;
                loading.Visibility = System.Windows.Visibility.Collapsed;
            });
        }

        private void selectSong(object sender, SelectionChangedEventArgs e)
        {
            ListBox l = (ListBox)sender;
            if (l != null && e != null && e.AddedItems != null && e.AddedItems.Count > 0)
            {
                Song s = e.AddedItems[0] as Song;
                if (s != null)
                {
                    this.NavigationService.Navigate(new Uri("/PlayingPage.xaml", UriKind.Relative));
                    selectedSong = s;
                }
                l.SelectedItem = null;
            }
        }

        private void clickAboutPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/about.xaml", UriKind.Relative));
        }

        private void ads_FailedToReceiveAd(object sender, GoogleAds.AdErrorEventArgs e)
        {
            ads.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void ads_ReceivedAd(object sender, GoogleAds.AdEventArgs e)
        {
            ads.Visibility = System.Windows.Visibility.Visible;
        }
    }
}