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
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Net.NetworkInformation;

namespace MyQuiz
{
    public partial class AddingPage : PhoneApplicationPage
    {
        Category newCategory;
        string imageUriString = "";
        string dapan = "A";
        public AddingPage()
        {
            InitializeComponent();
            listbox.ItemsSource = Category.ListCategories;

            if (!NetworkInterface.GetIsNetworkAvailable())
                ads.Visibility = System.Windows.Visibility.Collapsed;
        }

        private async void clickAdd(object sender, RoutedEventArgs e)
        {
            if (txtQuestion.Text.Length > 1 && listbox.Items.Count > 0)
            {
                Quiz q = new Quiz();
                DateTime d = DateTime.Now;
                q.ID = string.Format("{0}{1}{2}{3}", d.DayOfYear, d.Hour, d.Minute, d.Second);
                q.Question = txtQuestion.Text;
                q.Answer_A = txtA.Text;
                q.Answer_B = txtB.Text;
                q.Answer_C = txtC.Text;
                q.CategoryName = listbox.SelectedItem.ToString();
                q.Answer_D = txtD.Text;
                q.DapAnDung = dapan;


                if (listbox != null && listbox.SelectedItem != null)
                {
                    Category cate = listbox.SelectedItem as Category;
                    if (cate != null)
                    {
                        txtQuestion.Text = "";
                        txtA.Text = "";
                        txtB.Text = "";
                        txtC.Text = "";
                        txtD.Text = "";
                        cate.Quizzes.Add(q);
                        await Category.SaveCategoriesAsync();
                        MessageBox.Show("Added!");
                    }
                }
                else
                {
                    MessageBox.Show("Choose a category!");
                }
            }
            else
            {
                MessageBox.Show("you must add the question and select one category!");
            }
        }



        private void clickNewCategory(object sender, RoutedEventArgs e)
        {
            popupNewCategory.IsOpen = true;
            txtNewCategoryName.Text = "";
            imageUriString = "/Assets/logo.png";
            quizImage.Source = new BitmapImage(new Uri(imageUriString, UriKind.Relative));

        }

        private void clickChooseImage(object sender, RoutedEventArgs e)
        {
            PhotoChooserTask chooser = new PhotoChooserTask();
            chooser.Completed += chooser_Completed;
            chooser.Show();
        }

        void chooser_Completed(object sender, PhotoResult e)
        {
            if (e != null && e.ChosenPhoto != null)
            {
                Debug.WriteLine(e.OriginalFileName);
                imageUriString = e.OriginalFileName;
                quizImage.Source = new BitmapImage(new Uri(e.OriginalFileName));
            }
        }

        private async void clickAddNEwCate(object sender, RoutedEventArgs e)
        {

            newCategory = new Category();
            if (imageUriString.Length > 4)
                newCategory.ImageUriString = imageUriString;
            newCategory.Name = txtNewCategoryName.Text;
            Category.ListCategories.Add(newCategory);
            await Category.SaveCategoriesAsync();
            popupNewCategory.IsOpen = false;
            MessageBox.Show("Added!");
        }



        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ChonA(object sender, RoutedEventArgs e)
        { dapan = "A"; }
        private void ChonB(object sender, RoutedEventArgs e)
        { dapan = "B"; }
        private void ChonC(object sender, RoutedEventArgs e)
        { dapan = "C"; }
        private void ChonD(object sender, RoutedEventArgs e)
        { dapan = "D"; }

        private void clickAddRandom(object sender, RoutedEventArgs e)
        {
            //Check xem những ô chưa ấn
            List<string> ans = GetRandomAnswer();
            if (ans.Count > 0)
            {
                if (rdioA.IsChecked!=null && rdioA.IsChecked == false)
                    txtA.Text = ans[0];
                if (rdioB.IsChecked != null && rdioB.IsChecked == false)
                    txtB.Text = ans[1];
                if (rdioC.IsChecked != null && rdioC.IsChecked == false)
                    txtC.Text = ans[2];
                if (rdioD.IsChecked != null && rdioD.IsChecked == false)
                    txtD.Text = ans[3];
            }
            //Tìm những đáp án cùng loại

        }

        List<string> GetRandomAnswer()
        {
            List<String> list = new List<string>();
            Category cate = listbox.SelectedItem as Category;
            if (cate != null && cate.Quizzes.Count > 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    int k = DataHelper<int>.Rand.Next(0, cate.Quizzes.Count);
                    int c = DataHelper<int>.Rand.Next(1,5);
                    switch (c)
	                    {
                        case 1:
                            list.Add(cate.Quizzes[k].Answer_A);
                            break;
                              case 2:
                            list.Add(cate.Quizzes[k].Answer_B);
                            break;
                              case 3:
                            list.Add(cate.Quizzes[k].Answer_C);
                            break;
                              case 4:
                            list.Add(cate.Quizzes[k].Answer_D);
                            break;
		               default:
                            break;
	                    }
                    if (list[i].Length < 1)
                        list[i] = "somethings else";
                }
            }
            return list;
        }
    }
}