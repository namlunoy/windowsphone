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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace MyQuiz
{
    public partial class SettingPage : PhoneApplicationPage
    {
        public SettingPage()
        {
            InitializeComponent();

            Loaded += SettingPage_Loaded;


            if (!NetworkInterface.GetIsNetworkAvailable())
                ads.Visibility = System.Windows.Visibility.Collapsed;
        }
        ObservableCollection<UC_Category> listCate = new ObservableCollection<UC_Category>();
        void SettingPage_Loaded(object sender, RoutedEventArgs e)
        {
            listCate.Clear();
            foreach (var item in Category.ListCategories)
            {
                UC_Category uc = new UC_Category(item);
                uc.eventHanler += TakeAction;
                listCate.Add(uc);
            }
            list.ItemsSource = listCate;
        }

        private void TakeAction(object sender, UC_Args e)
        {
            switch (e.TypeEdit)
            {
                case EditType.Delete:
                    DeleteCategory(e);
                    break;
                case EditType.Edit:
                    EditCategory(e);
                    break;
                default:
                    break;
            }
        }

        private void EditCategory(UC_Args e)
        {
            this.NavigationService.Navigate(new Uri("/EditListPage.xaml?CateName="+e.Name, UriKind.Relative));
        }

        private async void DeleteCategory(UC_Args e)
        {
            var r = MessageBox.Show("delete " + e.Name + "?", "note", MessageBoxButton.OKCancel);
            if (r == MessageBoxResult.OK)
            {
                Category ct = Category.ListCategories.Where(c => c.Name.Equals(e.Name)).First();
                Category.ListCategories.Remove(ct);
                await Category.SaveCategoriesAsync();
                listCate.Remove(listCate.Where(u => u.Cate.Name.Equals(e.Name)).FirstOrDefault());
                list.ItemsSource = listCate;
            }
        }


    }
}