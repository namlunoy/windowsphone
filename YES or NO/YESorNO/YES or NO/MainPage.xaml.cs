using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using YES_or_NO.Resources;
using Microsoft.Phone.Tasks;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GoogleAds;
using System.Net.NetworkInformation;

namespace YES_or_NO
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        List<string> listWarning = new List<string>();
        List<string> listConfirmYES = new List<string>();
        List<string> listConfirmNO = new List<string>();
        public static List<Decision> ListDecision = new List<Decision>();
        private InterstitialAd interstitialAd;

        private bool _choice = false;

        public static Random rand = new Random();

      
        private string getString(List<string> l)
        {
            if (l.Count > 0)
            {
                int i = rand.Next(l.Count);
                //MessageBox.Show(i.ToString());
                return l[i];
            }
            return "";
        }

        public MainPage()
        {
            InitializeComponent();

            listWarning.Add("You sure that you can live with this choice, this decision for the rest of your life?");
            listWarning.Add("Are you really want this? Is this your dream?");
            listWarning.Add("Is this the thing you alway dream about?");
            listWarning.Add("Are you truly happy to do this?");
            listWarning.Add("Will you do this when you was eight?");
            listWarning.Add("Will  your idol make the same choice at this situation?");
            listWarning.Add("This decision come from your heart?");
            listWarning.Add("If tomorrow is doomsday you still do this?");
            listWarning.Add("This is your ideal or the others?");
            listWarning.Add("It will make your dream come true?");
            listWarning.Add("will you do it whatever it take?");

            listConfirmYES.Add("This is your own decision, you take all consequence by yourself, God does not involve with it!");
            listConfirmYES.Add("Now nothing can stop you! Keep moving forward!");
            listConfirmYES.Add("If this is your dream, so you have made the right choice!");
            listConfirmYES.Add("Congratulation! You have made one more step to your dream!");
            listConfirmYES.Add("Follow your heart always is the right choice!");
            listConfirmYES.Add("If you say so! Let's do this right now!");

            listConfirmNO.Add("Yeah! Don't decide too fast! Let think more carefully, but we dont have much time!");
            listConfirmNO.Add("You have made the right choice! We need think about this more carefully!");
            listConfirmNO.Add("OK! Maybe we should take more advices from someone has experiences about this!");


            Loaded += MainPage_Loaded;
           // NetworkInterface s;
           
            if (NetworkInterface.GetIsNetworkAvailable())
            {

                interstitialAd = new InterstitialAd("ca-app-pub-6921176146936171/2383282248");
                interstitialAd.ReceivedAd += OnAdReceived;
                AdRequest adRequest = new AdRequest();
                interstitialAd.LoadAd(adRequest);
            }
            else
            {
                ads.Visibility = System.Windows.Visibility.Collapsed;
            }


        }
        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            ListDecision = await FileHelper<Decision>.readXMLAsync("data.xml");
            ListDecision.Sort();
        }
        private void OnAdReceived(object sender, AdEventArgs e)
        {
            interstitialAd.ShowAd();
        }
    

        private void ClickChoice(bool choice)
        {
            if (content.Text.Length < 3)
            {
                MessageBox.Show("Your content is too short!");
            }
            else
            {
                _choice = choice;
                confirmPopup.Visibility = System.Windows.Visibility.Visible;
                warning.Text = getString(listWarning);
            }
        }

        private void clickYES(object sender, RoutedEventArgs e)
        { ClickChoice(true); }

        private void clickNO(object sender, RoutedEventArgs e)
        { ClickChoice(false); }

        private void Confirm(bool confirm)
        {


            Decision newDecision = new Decision();
            newDecision.Content = content.Text.Trim();
            newDecision.Time = DateTime.Now;

            if (confirm == true)
                newDecision.YourChoice = _choice ? Choices.YES : Choices.NO;
            else
                newDecision.YourChoice = Choices.THINKING;

            //Add to database
            ListDecision.Add(newDecision);
            ListDecision.Sort();

            FileHelper<Decision>.writeXMLAsync(ListDecision, "data.xml");

            //Hiện thị chữ
            confirmPopup.Visibility = System.Windows.Visibility.Collapsed;
            saySomething.Visibility = System.Windows.Visibility.Visible;
            somthingToSay.Text = confirm ? getString(listConfirmYES) : getString(listConfirmNO);
        }

        private void Confirm_YES(object sender, RoutedEventArgs e)
        { Confirm(true); }

        private void Confirm_NO(object sender, RoutedEventArgs e)
        { Confirm(false); }

        private void clickOK(object sender, RoutedEventArgs e)
        {
            saySomething.Visibility = System.Windows.Visibility.Collapsed;
            content.Text = "";
        }
        #region Bar button
        private void clickRate(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }

        private void clickShare(object sender, EventArgs e)
        {
            try
            {
                ShareStatusTask link = new ShareStatusTask();
                link.Status = "";
                link.Show();
            }
            catch (Exception)
            {

            }
        }

        private void clickAbout(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/about.xaml", UriKind.Relative));
        }

        private void clickAll(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/ListPage.xaml", UriKind.Relative));
        }
        #endregion




    }
}