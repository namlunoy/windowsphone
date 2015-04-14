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
using System.Windows.Media.Imaging;
using Microsoft.Phone.Tasks;
using System.Net.NetworkInformation;

namespace MyQuiz
{
    public partial class EditListPage : PhoneApplicationPage
    {
        public EditListPage()
        {
            InitializeComponent();

            if (!NetworkInterface.GetIsNetworkAvailable())
                ads.Visibility = System.Windows.Visibility.Collapsed;
        }


        public Category selectedCategory;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string name;
            if (this.NavigationContext.QueryString.TryGetValue("CateName", out name))
            {
                selectedCategory = Category.GetCategoryByName(name);
                txtNameCate.Text = selectedCategory.Name;
                image.Source = new BitmapImage(selectedCategory.ImageUri);
                if (selectedCategory != null)
                {
                    int stt = 1;
                    int dung = 0;
                    list.Children.Clear();
                    foreach (var q in selectedCategory.Quizzes)
                    {
                        Question Q = new Question(q);
                        Q.eventHanler += TakeAction;
                        Q.STT = stt.ToString();
                        stt++;
                        if (q.KetQua) dung++;
                        list.Children.Add(Q);
                    }
                }
            }
        }

        private async void TakeAction(object sender, UC_Args e)
        {
            switch (e.TypeEdit)
            {
                case EditType.Delete:

                    var r = MessageBox.Show("are you really want to delete this question?", "note", MessageBoxButton.OKCancel);
                    if (r == MessageBoxResult.OK)
                    {
                        foreach (var item in selectedCategory.Quizzes)
                        {
                            if (item.ID.Equals(e.Name))
                            {
                                selectedCategory.Quizzes.Remove(item);
                                await Category.SaveCategoriesAsync();
                                break;
                            }
                        }
                        foreach (var item in list.Children)
                        {
                            Question q = item as Question;
                            if (q.xQuiz.ID.Equals(e.Name))
                            {
                                list.Children.Remove(q);
                                break;
                            }
                        }

                    }

                    break;
                case EditType.Edit:

                    foreach (var item in list.Children)
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

        private async void clickSave(object sender, EventArgs e)
        {
            foreach (var item in selectedCategory.Quizzes)
                item.CategoryName = txtNameCate.Text;
            selectedCategory.Name = txtNameCate.Text;
            await Category.SaveCategoriesAsync();
            MessageBox.Show("saved!");
            this.NavigationService.GoBack();
        }

        private void clickChangeImage(object sender, RoutedEventArgs e)
        {
            PhotoChooserTask chooser = new PhotoChooserTask();
            chooser.Completed += chooser_Completed;
            chooser.Show();
        }

        void chooser_Completed(object sender, PhotoResult e)
        {
            if (e != null && e.ChosenPhoto != null)
            {
                selectedCategory.ImageUriString = e.OriginalFileName;
                image.Source = new BitmapImage(selectedCategory.ImageUri);
            }
        }
    }
}