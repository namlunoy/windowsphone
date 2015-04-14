using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using YES_or_NO.UserControls;
using Microsoft.Phone.Tasks;
using GoogleAds;
using System.Net.NetworkInformation;

namespace YES_or_NO
{
    public partial class ListPage : PhoneApplicationPage
    {
        private InterstitialAd interstitialAd;
        public ListPage()
        {
            InitializeComponent();

            Loaded += ListPage_Loaded;
            
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


        private void OnAdReceived(object sender, AdEventArgs e)
        {interstitialAd.ShowAd(); }

        void ListPage_Loaded(object sender, RoutedEventArgs e)
        {
            ApplyListBox();

            list.SelectionChanged += list_SelectionChanged;
        }

        void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // MessageBox.Show("choj: " + list.SelectedIndex);
            if (e != null && list.SelectedIndex >= 0)
            {
                SetPopup(list.SelectedIndex);
                //
            }
        }

        void SetPopup(int index)
        {
            popup.Visibility = System.Windows.Visibility.Visible;
           
            Decision d = MainPage.ListDecision[index];
            content.Text = d.Content;
            txtTime.Text = d.Time.ToLongDateString();
            result.Text = d.Result;
            switch (d.YourChoice)
            {
                case Choices.YES:
                    txtYES.Visibility = Visibility.Visible;
                    txtNO.Visibility = Visibility.Collapsed;
                    txtThink.Visibility = Visibility.Collapsed;
                    break;
                case Choices.NO:
                    txtYES.Visibility = Visibility.Collapsed;
                    txtNO.Visibility = Visibility.Visible;
                    txtThink.Visibility = Visibility.Collapsed;
                    break;
                default:
                    txtYES.Visibility = Visibility.Collapsed;
                    txtNO.Visibility = Visibility.Collapsed;
                    txtThink.Visibility = Visibility.Visible;
                    break;
            }

        }

        private async void clickDelete(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("are you sure to delete this?", "note!", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                MainPage.ListDecision.RemoveAt(list.SelectedIndex);
                await FileHelper<Decision>.writeXMLAsync(MainPage.ListDecision, "data.xml");
                ApplyListBox();
            }
            popup.Visibility = System.Windows.Visibility.Collapsed;
            list.SelectedItem = null;
        }

        private void clickCancel(object sender, RoutedEventArgs e)
        {
            popup.Visibility = System.Windows.Visibility.Collapsed;
            list.SelectedItem = null;
        }

        void ApplyListBox()
        {
            list.Items.Clear();
            for (int i = 0; i < MainPage.ListDecision.Count; i++)
            {
                var s = new Item(MainPage.ListDecision[i], i);
                s.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                list.Items.Add(s);
            }
        }

        private void clickShare(object sender, RoutedEventArgs e)
        {
            ShareStatusTask link = new ShareStatusTask();
            Decision d = MainPage.ListDecision[list.SelectedIndex];
            link.Status ="Problem:\n "+ d.Content + "\nMy choice is: " + d.YourChoice + "\nTime: " + d.Time.ToShortDateString()+"\nResult: "+d.Result;
            link.Show();
        }


        bool isEditing = false;
        private void clickAddResult(object sender, RoutedEventArgs e)
        {
            if(isEditing == false)
            {
                isEditing = true;
                editButton.Content = "save";
                result.IsReadOnly = false;
            }
            else
            {
                isEditing = false;
                editButton.Content = "edit result";
                result.IsReadOnly = true;
                Decision d = MainPage.ListDecision[list.SelectedIndex];
                d.Result = result.Text;
                FileHelper<Decision>.writeXMLAsync(MainPage.ListDecision,"data.xml");
            }
        }

    }
}