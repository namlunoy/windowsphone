using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Guu.Resources;
using Microsoft.Phone.Tasks;
using Mannup.Model;
using System.Diagnostics;

namespace Guu
{
    public partial class MainPage : PhoneApplicationPage
    {
        GoogleAds.InterstitialAd googleAds;
        public MyData myData { get; set; }
        public MainPage()
        {
            if (Helper.CheckNetwork())
            {
                InitializeComponent();
                web.Navigate(new Uri("http://guu.vn/"));

                myData = new MyData();
                myData.LoadData();
                listCategory.ItemsSource = myData.ListCategory;
            }
            else
            {
                MessageBox.Show("Xin lỗi! Bạn cần kết nối Internet trước!");
                Application.Current.Terminate();
            }
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
            if (listCategory.SelectedItem != null)
            {
                Category c = listCategory.SelectedItem as Category;
                web.Navigate(c.Url);
                slideView.SelectedIndex = 1;
                foreach (var item in myData.ListCategory)
                    item.IsSelected = false;
                //c.IsSelected = true;
                myData.ListCategory[listCategory.SelectedIndex].IsSelected = true;
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
            if(txtTimkiem.Text.Length > 0)
                web.Navigate(new Uri("https://www.google.com.vn/search?q=site%3Aguu.vn+" + txtTimkiem.Text));
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

                link.Title = "Tạp chí Guu.vn trên Windows Phone!";
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

        private void adsBanner_FailedToReceiveAd(object sender, GoogleAds.AdErrorEventArgs e)
        {
            Debug.WriteLine("Banner load fail!");
        }

    }
}