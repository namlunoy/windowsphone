using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using private_notes.Resources;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Net.NetworkInformation;
//ca-app-pub-6921176146936171/8964429042
namespace private_notes
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        GoogleAds.InterstitialAd ad;
        public string password;
        public static bool isLogin = false;
        public static ListNote listNote = new ListNote();

        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

            Loaded += MainPage_Loaded;
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                ad = new GoogleAds.InterstitialAd("ca-app-pub-6921176146936171/8964429042");
                GoogleAds.AdRequest request = new GoogleAds.AdRequest();
                //ad.LoadAd(request);
                ad.ReceivedAd += ad_ReceivedAd;
            }
            else
            {
                ads.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isLogin)
            {
                 password = await Helper.ReadFile("password.txt");
                 if (password.Length < 1)
                {
                    //MessageBox.Show("Set your password first!");
                    newpass.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    pass.Visibility = System.Windows.Visibility.Visible;
                }

                 listNote.Notes = await Helper.readXMLAsync("data.xml");
            }

        }

        void ad_ReceivedAd(object sender, GoogleAds.AdEventArgs e)
        {
            ad.ShowAd();
        }

        private void clickLike(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }

        private void clickNewNote(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/NewNote.xaml", UriKind.Relative));
        }

        private void clickMyNotes(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MyNotes.xaml", UriKind.Relative));
        }

        private void clickSettings(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }

        private void clickAbout(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/about.xaml", UriKind.Relative));
        }


        //Lap pass moi
        private async void clickOKNewPassword(object sender, RoutedEventArgs e)
        {
            if (newpass1.Password.Equals(newpass2.Password))
            {
                await Helper.WriteToFile(newpass1.Password, "password.txt");
                isLogin = true;
                HideNewPass.Begin();
            }
            else
            {
                MessageBox.Show("Please retype your password!");
            }
        }


        //Kieerm tra pass word
        private void clickOKNhapPassword(object sender, RoutedEventArgs e)
        {
            if (passx.Password.Equals(password))
            {
                HidePass.Begin();
            }
            else
            {
                passx.Password = "";
                MessageBox.Show("Wrong password!");
            }
        }


    }
}