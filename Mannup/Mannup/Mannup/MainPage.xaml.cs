using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Mannup.Resources;
using Mannup.Model;
using System.Diagnostics;
using System.Windows.Media;
using Microsoft.Phone.Tasks;


namespace Mannup
{
    public partial class MainPage : PhoneApplicationPage
    {
        GoogleAds.InterstitialAd googleAds;
        public MainPage()
        {
            InitializeComponent();
            web.Navigate(new Uri("http://mannup.vn/"));

            MyData.LoadData();
            listCategory.ItemsSource = MyData.ListCategory;
         

        }

        int count = 0;

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi ứng dụng?", "Thoát?", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void selectCategory(object sender, SelectionChangedEventArgs e)
        {
           if(listCategory.SelectedItem != null){
               Category c = listCategory.SelectedItem as Category;
               web.Navigate(c.Url);
               slideView.SelectedIndex = 1;
               title.Text = c.Title;
               listCategory.SelectedItem = null;
           }
        }

        private void swiped(object sender, EventArgs e)
        {
            if (slideView.SelectedIndex != 1)
                ApplicationBar.Mode = ApplicationBarMode.Minimized;
            else
                ApplicationBar.Mode = ApplicationBarMode.Default;
        }

        private void updateBar()
        {
            ((ApplicationBarIconButton)this.ApplicationBar.Buttons[1]).IsEnabled = web.CanGoBack;
            ((ApplicationBarIconButton)this.ApplicationBar.Buttons[2]).IsEnabled = web.CanGoForward;              
        }
        #region Xử lý quảng cáo
        bool ads_ok = false;
        void ads_FailedToReceiveAd(object sender, GoogleAds.AdErrorEventArgs e)
        {
            ads_ok = false;
            Debug.WriteLine("ko có quảng cáo!");
        }

        void ads_ReceivedAd(object sender, GoogleAds.AdEventArgs e)
        {
            googleAds.ShowAd();
            Debug.WriteLine("Có quảng cáo!");
        }


        #endregion


        #region Xử lý web browser

        private void web_Navigating(object sender, NavigatingEventArgs e)
        {
            loadingView.Visibility = System.Windows.Visibility.Visible;

        }

        private void web_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            loadingView.Visibility = System.Windows.Visibility.Collapsed;
            MessageBox.Show("Có lỗi khi tải trang này! Vui lòng quay lại sau!");
        }

        Uri currentUri;
        Random r = new Random();
        private void web_Navigated(object sender, NavigationEventArgs e)
        {
            currentUri = e.Uri;
            count++;
            loadingView.Visibility = System.Windows.Visibility.Collapsed;
            updateBar();

            if (count % 4 == 0)
            {
                ads_ok = true;

                //Hiển thị quảng cáo
                googleAds = new GoogleAds.InterstitialAd(Helper.BillboardId);
                googleAds.ReceivedAd += ads_ReceivedAd;
                googleAds.FailedToReceiveAd += ads_FailedToReceiveAd;

                GoogleAds.AdRequest ggAdRequest = new GoogleAds.AdRequest();
                ggAdRequest.Gender = GoogleAds.UserGender.Male;
                googleAds.LoadAd(ggAdRequest);
            }
        }


        #endregion

        private void Click_TimKiem(object sender, RoutedEventArgs e)
        {
            web.Navigate(new Uri("http://mannup.vn/?s=" + txtTimkiem.Text));
            TimKiem_An.Begin();
        }

        #region Xử lý các Application Bar

        private void Click_Rate(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }
        private void Click_Back(object sender, EventArgs e)
        {
            web.GoBack();
        }

        private void Click_Forward(object sender, EventArgs e)
        {
            web.GoForward();
        }

        private void Click_Share(object sender, EventArgs e)
        {
            try
            {
                ShareLinkTask link = new ShareLinkTask();
                link.LinkUri = currentUri;
              
                link.Title = "Tạp chí Mann Up trên Windows Phone!";
                link.Show();
            }
            catch (Exception)
            {

            }
        }
        private void Click_Search(object sender, EventArgs e)
        {
            TimKiem_Hien.Begin();
        }

        private void Click_ThongTin(object sender, EventArgs e)
        {

        }

        private void Click_TapChiKhac(object sender, EventArgs e)
        {
            MarketplaceSearchTask marketplaceSearchTask = new MarketplaceSearchTask();
            marketplaceSearchTask.SearchTerms = "mGame";
            marketplaceSearchTask.Show();
        }
        #endregion

    }
}