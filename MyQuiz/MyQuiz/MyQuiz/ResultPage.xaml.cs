using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MyQuiz.Usercontrols;
using System.Net.NetworkInformation;

namespace MyQuiz
{
    public partial class ResultPage : PhoneApplicationPage
    {
        GoogleAds.InterstitialAd ad;

        public ResultPage()
        {
            InitializeComponent();

            Loaded += ResultPage_Loaded;

            if (!NetworkInterface.GetIsNetworkAvailable())
                ads.Visibility = System.Windows.Visibility.Collapsed;
            else
            {
                ad = new GoogleAds.InterstitialAd("ca-app-pub-6921176146936171/2383282248");
                GoogleAds.AdRequest re = new GoogleAds.AdRequest();
                ad.ReceivedAd += ad_ReceivedAd;
                ad.LoadAd(re);
            }
        }

        void ad_ReceivedAd(object sender, GoogleAds.AdEventArgs e)
        { ad.ShowAd(); }

        void ResultPage_Loaded(object sender, RoutedEventArgs e)
        {
            int stt = 1;
            int dung = 0;
            foreach (var q in TestingPage.listQuiz)
            {
                Question Q = new Question(q);
                Q.STT = stt.ToString();
                stt++;
                Q.HideEditPanel();
                if (q.KetQua) dung++;
                stack.Children.Add(Q);
            }
            result.Text = String.Format("result:  {0}/{1}",dung,TestingPage.listQuiz.Count);
        }
    }
}