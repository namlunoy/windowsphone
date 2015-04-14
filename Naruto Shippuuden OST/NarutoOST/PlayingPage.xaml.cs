using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Threading;
using NarutoOST.Models;
using Microsoft.Phone.BackgroundAudio;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Tasks;
using System.Collections.ObjectModel;
using Windows.Storage;
using Windows.Storage.Streams;
using System.IO.IsolatedStorage;
using System.Diagnostics;
using vservWindowsPhone;

namespace NarutoOST
{
    public partial class PlayingPage : PhoneApplicationPage
    {
        private Song selectedSong;
        private bool _isPlaying = true;
        public static ObservableCollection<Song> selectedList = null;

        public bool IsPlaying
        {
            get { return _isPlaying; }
            set
            {
                _isPlaying = value;
                if (_isPlaying)
                    playButton.ImageSource = Helper<Song>.GetImageSource("/Assets/_pause.png", UriKind.Relative);
                else playButton.ImageSource = Helper<Song>.GetImageSource("/Assets/_play.png", UriKind.Relative);
            }
        }
        public PlayingPage()
        {
            if (MainPage.AdsCount != 0)
            {
                if (Helper<Song>.random.Next(10) % 2 == 0)
                {
                    Helper<Song>.RequestAds();
                }
                else
                {
                    Helper<Song>.LoadVserv(LayoutRoot);
                }
            }
            else {
                MainPage.AdsCount++;
            }

            BackgroundAudioPlayer.Instance.PlayStateChanged += Instance_PlayStateChanged;
            InitializeComponent();

            ImagePlaying.Completed += runcomplete2;


        }

        private void VMB_VservAdNoFill(object sender, EventArgs e)
        {
            Helper<Song>.RequestAds();
        }
        void billboard_ReceivedAd(object sender, GoogleAds.AdEventArgs e)
        {
            billboard.ShowAd();
        }


        void Instance_PlayStateChanged(object sender, EventArgs e)
        {
            switch (BackgroundAudioPlayer.Instance.PlayerState)
            {
                case PlayState.BufferingStarted:
                    Loading.Visibility = System.Windows.Visibility.Visible;
                    break;
                case PlayState.BufferingStopped:
                    Loading.Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case PlayState.Error:
                    playButton.ImageSource = Helper<Song>.GetImageSource("/Assets/_play.png", UriKind.Relative);
                    MessageBox.Show("Error!");
                    break;
                case PlayState.FastForwarding:
                    Loading.Visibility = System.Windows.Visibility.Visible;
                    playButton.ImageSource = Helper<Song>.GetImageSource("/Assets/_play.png", UriKind.Relative);
                    break;
                case PlayState.Paused:
                    Loading.Visibility = System.Windows.Visibility.Collapsed;
                    playButton.ImageSource = Helper<Song>.GetImageSource("/Assets/_play.png", UriKind.Relative);
                    break;
                case PlayState.Playing:
                    Loading.Visibility = System.Windows.Visibility.Collapsed;
                    playButton.ImageSource = Helper<Song>.GetImageSource("/Assets/_pause.png", UriKind.Relative);
                    break;
                case PlayState.Rewinding:
                    Loading.Visibility = System.Windows.Visibility.Visible;
                    playButton.ImageSource = Helper<Song>.GetImageSource("/Assets/_play.png", UriKind.Relative);
                    break;
                case PlayState.Shutdown:
                    Loading.Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case PlayState.Stopped:
                    Loading.Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case PlayState.TrackEnded:
                    clickNext(nextButton, new RoutedEventArgs());
                    break;
                case PlayState.TrackReady:
                    break;
                case PlayState.Unknown:
                    // MessageBox.Show("Unknown");
                    break;
                default:
                    // MessageBox.Show("Unknown!");
                    break;
            }
        }

        private void runcomplete2(object sender, EventArgs e) { ImagePlaying.Begin(); }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //background.Source = new BitmapImage(new Uri(MainPage.bacgroundImage, UriKind.Relative));
            if (MainPage.selectedSong != null)
            {
                selectedSong = MainPage.selectedSong;
                MainPage.selectedSong = null;
                switch (selectedSong.Loai)
                {
                    case 1:
                        lv.ItemsSource = MainPage.list1;
                        selectedList = MainPage.list1;
                        break;
                    case 2:
                        lv.ItemsSource = MainPage.list2;
                        selectedList = MainPage.list2;
                        break;
                    case 3:
                        lv.ItemsSource = MainPage.list3;
                        selectedList = MainPage.list3;
                        break;

                    default:
                        break;
                }


                PlaySelectedSong();

            }
        }

        private void selectAnotherSong(object sender, SelectionChangedEventArgs e)
        {
            ListBox l = (ListBox)sender;
            if (l != null && e != null && e.AddedItems != null && e.AddedItems.Count > 0)
            {
                Song s = e.AddedItems[0] as Song;
                if (s != null)
                {
                    selectedSong = s;
                    PlaySelectedSong();
                }
                //l.SelectedItem = null;
            }
        }



        private void PlaySelectedSong()
        {
            BackgroundAudioPlayer.Instance.Track = selectedSong.GetAudiTrack;
            IsPlaying = true;
            ImagePlaying.Begin();
            image.Fill = Helper<Song>.GetImage();
            title.Text = selectedSong.Name + " - " + selectedSong.Author;
            MainPage.mainTitle.Text = title.Text;

            if (selectedSong.IsInFavorite)
            {
                favoriteButton.ImageSource = new BitmapImage(new Uri("/Assets/_heart_1.png", UriKind.Relative));
            }
            else
            {
                favoriteButton.ImageSource = new BitmapImage(new Uri("/Assets/_heart_0.png", UriKind.Relative));
            }
        }


        private void clickPlayPause(object sender, RoutedEventArgs e)
        {
            if (IsPlaying)
                BackgroundAudioPlayer.Instance.Pause();
            else BackgroundAudioPlayer.Instance.Play();
            IsPlaying = !IsPlaying;
        }
        private void clickReport(object sender, RoutedEventArgs e)
        {
            EmailComposeTask task = new EmailComposeTask();
            task.To = "namlunoy@gmail.com";
            task.Subject = "Naruto OST : Report!";
            task.Body = "Broken song: " + selectedSong.Name;
            task.Show();
        }
        private void clickShare(object sender, RoutedEventArgs e)
        {
            ShareLinkTask task = new ShareLinkTask();
            task.LinkUri = selectedSong.LinkUri;
            task.Title = selectedSong.Name + " (Naruto OST - on Windows Phone)";
            task.Show();
        }
        private void clickBack(object sender, RoutedEventArgs e)
        {
            int index = selectedList.IndexOf(selectedSong);
            if (index >= 0 && index < selectedList.Count)
            {
                if (index == 0)
                    index = selectedList.Count - 1;
                else index--;
                lv.SelectedIndex = index;
            }
        }

        private void clickNext(object sender, RoutedEventArgs e)
        {
            int index = selectedList.IndexOf(selectedSong);
            if (index >= 0 && index < selectedList.Count)
            {
                if (index == (selectedList.Count - 1))
                    index = 0;
                else index++;
                lv.SelectedIndex = index;
            }
        }




        private void clickFavorite(object sender, RoutedEventArgs e)
        {
            if (selectedSong.IsInFavorite)
            {
                //Loại khỏi list
                MainPage.list3.Remove(selectedSong);
                selectedSong.IsInFavorite = false;
                Helper<Song>.writeXMLAsync(MainPage.list3, "data.xml");
                favoriteButton.ImageSource = new BitmapImage(new Uri("/Assets/_heart_0.png", UriKind.Relative));
                foreach (var item in MainPage.AllSong)
                {
                    if (item.Name.Equals(selectedSong.Name))
                    {
                        item.IsInFavorite = false;
                        break;
                    }
                }
            }
            else
            {
                //Them vào list
                MainPage.list3.Add(selectedSong.CloneFavorite());
                Helper<Song>.writeXMLAsync(MainPage.list3, "data.xml");
                favoriteButton.ImageSource = new BitmapImage(new Uri("/Assets/_heart_1.png", UriKind.Relative));
            }
        }

        private async void clickDownload(object sender, RoutedEventArgs e)
        {

        }

        private void clickReview(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask task = new MarketplaceReviewTask();
            task.Show();
        }

        public GoogleAds.InterstitialAd billboard { get; set; }

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