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

namespace NarutoCharecters3
{
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

            emailComposeTask.Subject = "feedback from Naruto Battles";
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
    }
}