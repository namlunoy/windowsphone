using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Net.NetworkInformation;

namespace MyQuiz
{
    public partial class PreTestingPage : PhoneApplicationPage
    {
        public static List<Category> selectedCategories = new List<Category>();
        public class MyClass
        {
            public string ID { get; set; }
        }

        public PreTestingPage()
        {
            InitializeComponent();
            list.ItemsSource = Category.ListCategories;

            if (!NetworkInterface.GetIsNetworkAvailable())
                ads.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void clickGo(object sender, RoutedEventArgs e)
        {
            selectedCategories.Clear();
            if (list.SelectedItems != null && list.SelectedItems.Count > 0)
            {
                foreach (var item in list.SelectedItems)
                {
                    Category c = item as Category;
                    if (c != null)
                        selectedCategories.Add(c);
                }
                if (selectedCategories.Count > 0)
                {
                    int COUNT = 0;
                    foreach (var item in selectedCategories)

                        COUNT += item.Quizzes.Count;

                    if (COUNT == 0)
                    {
                        MessageBox.Show("This category doesn't have any question!");
                     //   this.NavigationService.GoBack();
                    }

                    else this.NavigationService.Navigate(new Uri("/TestingPage.xaml", UriKind.Relative));
                }
            }
            else
            {
                MessageBox.Show("select your categories!");
            }
        }
    }
}