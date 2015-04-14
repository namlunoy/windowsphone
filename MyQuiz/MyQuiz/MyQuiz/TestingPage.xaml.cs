using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace MyQuiz
{
    public partial class TestingPage : PhoneApplicationPage
    {
        Stopwatch stopwatch = new Stopwatch();
        int questionIndex = -1;
        public static List<Quiz> listQuiz = new List<Quiz>();

        public int COUNT { get { return listQuiz.Count; } }
        public TestingPage()
        {
            InitializeComponent();
            WaitASec.Completed += WaitASec_Completed;

            if (!NetworkInterface.GetIsNetworkAvailable())
                ads.Visibility = System.Windows.Visibility.Collapsed;
            else
            {
              
            }
        }
      

        private void Binding()
        {
            txtA.Text = listQuiz[questionIndex].Answer_A;
            txtB.Text = listQuiz[questionIndex].Answer_B;
            txtC.Text = listQuiz[questionIndex].Answer_C;
            txtD.Text = listQuiz[questionIndex].Answer_D;
            txtQuestion.Text = listQuiz[questionIndex].Question;
        }

        void WaitASec_Completed(object sender, EventArgs e)
        {

            if (questionIndex + 1 < COUNT)
            {
                questionIndex++;
                Binding();
                txtCount.Text = string.Format("{0}/{1}", questionIndex + 1, COUNT);
                ellipse_A.Fill = new SolidColorBrush(Colors.Transparent);
                ellipse_B.Fill = new SolidColorBrush(Colors.Transparent);
                ellipse_C.Fill = new SolidColorBrush(Colors.Transparent);
                ellipse_D.Fill = new SolidColorBrush(Colors.Transparent);
            }
            else
            {
                MessageBox.Show("You have finished your test!");
                this.NavigationService.Navigate(new Uri("/ResultPage.xaml", UriKind.Relative));
            }

        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Nếu là quay lại từ trang kết quả thì quay về
            if (e.NavigationMode == NavigationMode.Back)
            {
                this.NavigationService.GoBack();
            }
            else
            {
                TestingPage_Loaded(this, null);
            }
        }

        Random rand = new Random();

        /// <summary>
        /// Mix list đã được chọn
        /// </summary>
        public void Mix()
        {
            int k;
            if (listQuiz.Count > 2)
            {
                for (int i = 0; i < listQuiz.Count; i++)
                {
                    do
                    {
                        k = rand.Next(0, listQuiz.Count);
                    } while (k == i);
                    Quiz t = listQuiz[k];
                    listQuiz[k] = listQuiz[i];
                    listQuiz[i] = t;
                }
            }
        }


        /// <summary>
        /// Load các câu hỏi từ các categories và mix nó
        /// </summary>
        void TestingPage_Loaded(object sender, RoutedEventArgs e)
        {
            listQuiz.Clear();
            foreach (var item in PreTestingPage.selectedCategories)
                foreach (var q in item.Quizzes)
                    listQuiz.Add(q);
            Mix();


            questionIndex++;
            Binding();
            txtCount.Text = string.Format("{0}/{1}", questionIndex + 1, COUNT);
        }



        private void NextQuestion()
        {
            WaitASec.Begin();
        }

        private void ChonA(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ellipse_A.Fill = new SolidColorBrush(Colors.White);
            Grid g = sender as Grid;
            if (g != null)
            {
                if (g.Name.Equals("GridA"))
                {
                    listQuiz[questionIndex].DapAnDaChon = "A";
                    ellipse_A.Fill = new SolidColorBrush(Colors.White);
                    ellipse_B.Fill = new SolidColorBrush(Colors.Transparent);
                    ellipse_C.Fill = new SolidColorBrush(Colors.Transparent);
                    ellipse_D.Fill = new SolidColorBrush(Colors.Transparent);
                }
                else if (g.Name.Equals("GridB"))
                {
                    listQuiz[questionIndex].DapAnDaChon = "B";
                    ellipse_A.Fill = new SolidColorBrush(Colors.Transparent);
                    ellipse_B.Fill = new SolidColorBrush(Colors.White);
                    ellipse_C.Fill = new SolidColorBrush(Colors.Transparent);
                    ellipse_D.Fill = new SolidColorBrush(Colors.Transparent);
                }
                else if (g.Name.Equals("GridC"))
                {
                    listQuiz[questionIndex].DapAnDaChon = "C";
                    ellipse_A.Fill = new SolidColorBrush(Colors.Transparent);
                    ellipse_B.Fill = new SolidColorBrush(Colors.Transparent);
                    ellipse_C.Fill = new SolidColorBrush(Colors.White);
                    ellipse_D.Fill = new SolidColorBrush(Colors.Transparent);
                }
                else
                {
                    listQuiz[questionIndex].DapAnDaChon = "D";
                    ellipse_A.Fill = new SolidColorBrush(Colors.Transparent);
                    ellipse_B.Fill = new SolidColorBrush(Colors.Transparent);
                    ellipse_C.Fill = new SolidColorBrush(Colors.Transparent);
                    ellipse_D.Fill = new SolidColorBrush(Colors.White);
                }
                NextQuestion();
            }
        }

        private void clickStop(object sender, EventArgs e)
        {
            if (MessageBox.Show("you want to stop?", "note", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                this.NavigationService.Navigate(new Uri("/ResultPage.xaml", UriKind.Relative));
            }
        }




    }
}