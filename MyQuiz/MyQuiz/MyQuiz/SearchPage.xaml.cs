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
    public partial class SearchPage : PhoneApplicationPage
    {
       GoogleAds.InterstitialAd ad;

       public SearchPage()
        {
            InitializeComponent();

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

        public void Load(List<Quiz> listQuiz)
        {
            int stt = 1;
            int dung = 0;
            stack.Children.Clear();
            foreach (var q in listQuiz)
            {
                Question Q = new Question(q);
                Q.STT = stt.ToString();
                stt++;
                Q.eventHanler += TakeAction;
                if (q.KetQua) dung++;
                stack.Children.Add(Q);
            }
        }

        private void clickSearch(object sender, RoutedEventArgs e)
        {
            List<Quiz> l = new List<Quiz>();
            foreach (var cate in Category.ListCategories)
            {
                foreach (var q in cate.Quizzes)
                {
                    if (q.Question.ToLower().Contains(txt.Text.ToLower()))
                    {
                        l.Add(q);
                    }
                }
            }
            Load(l);
        }

        private async void TakeAction(object sender, UC_Args e)
        {
            switch (e.TypeEdit)
            {
                case EditType.Delete:

                    var r = MessageBox.Show("are you really want to delete this question?", "note", MessageBoxButton.OKCancel);
                    if (r == MessageBoxResult.OK)
                    {
                        bool ok = false;
                        foreach (var item in Category.ListCategories)
                        {
                            foreach (var q in item.Quizzes)
                            {
                                if(q.ID.Equals(e.Name))
                                {
                                    item.Quizzes.Remove(q);
                                    ok = true;
                                    break;
                                }
                            }
                            if (ok)
                                break;
                        }
                        await Category.SaveCategoriesAsync();
                      
                        foreach (var item in stack.Children)
                        {
                            Question q = item as Question;
                            if (q.xQuiz.ID.Equals(e.Name))
                            {
                                stack.Children.Remove(q);
                                break;
                            }
                        }

                    }

                    break;
                case EditType.Edit:

                    foreach (var item in stack.Children)
                    {
                        Question q = item as Question;
                        if (q.xQuiz.ID.Equals(e.Name))
                        {
                            this.NavigationService.Navigate(new Uri("/EditPage.xaml?ID=" + e.Name, UriKind.Relative));
                            break;
                        }
                    }

                    break;
                default:
                    break;
            }
        }
    }
}