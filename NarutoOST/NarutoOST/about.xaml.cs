using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace NarutoOST
{
    //banner: ca-app-pub-6921176146936171/7928994641
    //billboard: ca-app-pub-6921176146936171/1882461045
    public partial class about : PhoneApplicationPage
    {
        public about()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MarketplaceSearchTask marketplaceSearchTask = new MarketplaceSearchTask();
            marketplaceSearchTask.SearchTerms = "conghoang";
            marketplaceSearchTask.Show();
        }

        private void clickEmail(object sender, RoutedEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = "feedback from Naruto OST";
            emailComposeTask.To = "conghoang123@outlook.com";
            emailComposeTask.Show();
        }

        private void clickRate(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }

        private void clickShare(object sender, RoutedEventArgs e)
        {
            try
            {
                ShareLinkTask link = new ShareLinkTask();
                link.LinkUri = new Uri("http://www.windowsphone.com/en-us/store/app/naruto-characters/5da71cbf-6f39-4a12-84d6-8790d47bebee");
                link.Show();
            }
            catch (Exception)
            {

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://www.windowsphone.com/s?appid=40297e29-1e44-401e-b25f-ceb14a655c64", UriKind.Absolute);
            webBrowserTask.Show();
        }
    }
}