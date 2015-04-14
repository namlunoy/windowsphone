using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MyQuiz.Resources;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Windows.Storage;
using Windows.ApplicationModel;
using System.Diagnostics;
using Microsoft.Phone.Tasks;
using System.Net.NetworkInformation;

namespace MyQuiz
{
    public partial class MainPage : PhoneApplicationPage
    {

        GoogleAds.InterstitialAd ad;

        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;

            //DataHelper<Quiz>.ResetFiles();
            Loading.Begin();
            
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                ad = new GoogleAds.InterstitialAd("ca-app-pub-6921176146936171/2383282248");
                GoogleAds.AdRequest re = new GoogleAds.AdRequest();
                ad.ReceivedAd += ad_ReceivedAd;
                ad.LoadAd(re);
            }
        }

        void ad_ReceivedAd(object sender, GoogleAds.AdEventArgs e)
        {
            ad.ShowAd();
        }

    

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        { await Category.LoadCategoriesAsync(); }

        private void clickTest(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (Category.ListCategories.Count == 0)
                MessageBox.Show("you have not add any categories yet!");
            else
                this.NavigationService.Navigate(new Uri("/PreTestingPage.xaml", UriKind.Relative));
        }

        private void clickAdd(object sender, System.Windows.Input.GestureEventArgs e)
        { this.NavigationService.Navigate(new Uri("/AddingPage.xaml", UriKind.Relative)); }

        private void clickSearch(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (Category.ListCategories.Count == 0)
                MessageBox.Show("you have not add any categories yet!");
            else this.NavigationService.Navigate(new Uri("/SearchPage.xaml", UriKind.Relative));
        }

        private void clickSetting(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (Category.ListCategories.Count == 0)
                MessageBox.Show("you have not add any categories yet!");
            else this.NavigationService.Navigate(new Uri("/SettingPage.xaml", UriKind.Relative));
        }


        private void clickRate(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }

        private void clickShare(object sender, EventArgs e)
        {
            ShareLinkTask shareLinke = new ShareLinkTask();
            shareLinke.LinkUri = new Uri("http://www.windowsphone.com/s?appid=f25a54ed-012c-4920-b057-1524fcabe504");
            shareLinke.Message = "Try this app!";
            shareLinke.Title = "my quizzes!";
            shareLinke.Show();
        }

        private void clickAbout(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
        }


    }
}