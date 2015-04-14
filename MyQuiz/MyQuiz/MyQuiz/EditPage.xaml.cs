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
    public partial class EditPage : PhoneApplicationPage
    {
        public Quiz selectedQuiz;
        public EditPage()
        {
            InitializeComponent();
            listbox.ItemsSource = Category.ListCategories;

            if (!NetworkInterface.GetIsNetworkAvailable())
                ads.Visibility = System.Windows.Visibility.Collapsed;
        }

        void Bingding()
        {
            LayoutRoot.DataContext = selectedQuiz;
            int k = 0;
            for (int i = 0; i < listbox.Items.Count; i++)
            {
                if ((listbox.Items[i] as Category).Name.Equals(selectedQuiz.CategoryName))
                {
                    listbox.SelectedIndex = i;
                    break;
                }
            }

            if (selectedQuiz.DapAnDung.Equals("A"))
                r_A.IsChecked = true;
            else if (selectedQuiz.DapAnDung.Equals("B"))
                r_B.IsChecked = true;
            else if (selectedQuiz.DapAnDung.Equals("C"))
                r_C.IsChecked = true;
            else
                r_D.IsChecked = true;
         
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (this.NavigationContext.QueryString.ContainsKey("ID"))
            {
                string id = "";
                if (this.NavigationContext.QueryString.TryGetValue("ID", out id))
                {
                    foreach (var cate in Category.ListCategories)
                    {
                        foreach (var q in cate.Quizzes)
                        {
                            if (q.ID.Equals(id))
                            {
                                selectedQuiz = q;
                                Bingding();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Can't find the question!");
                    this.NavigationService.GoBack();
                }
            }
            else
            {
                MessageBox.Show("Can't find the question!");
                this.NavigationService.GoBack();
            }
            //base.OnNavigatedTo(e);
        }
    

        private async void clickSave(object sender, EventArgs e)
        {

            if (selectedQuiz.CategoryName.Equals((listbox.SelectedItem as Category).Name))
            {

            }
            else
            {
                Category oldCate = Category.GetCategoryByName(selectedQuiz.CategoryName);
                Category newCate = Category.GetCategoryByName((listbox.SelectedItem as Category).Name);
                oldCate.Quizzes.Remove(selectedQuiz);
                selectedQuiz.CategoryName = newCate.Name;
                newCate.Quizzes.Add(selectedQuiz);
            }

            selectedQuiz.Answer_A = txtA.Text;
            selectedQuiz.Answer_B = txtB.Text;
            selectedQuiz.Answer_C = txtC.Text;
            selectedQuiz.Answer_D = txtD.Text;
            selectedQuiz.Question = txtQuestion.Text;

            if ((bool)r_A.IsChecked)
                selectedQuiz.DapAnDung = "A";
            if ((bool)r_B.IsChecked)
                selectedQuiz.DapAnDung = "B";
            if ((bool)r_C.IsChecked)
                selectedQuiz.DapAnDung = "C";
            if ((bool)r_D.IsChecked)
                selectedQuiz.DapAnDung = "D";


            await Category.SaveCategoriesAsync();
            MessageBox.Show("Updated!");
            this.NavigationService.GoBack();
        }

      
    }
}