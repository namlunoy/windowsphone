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

namespace private_notes
{
    public partial class NewNote : PhoneApplicationPage
    {
        int count = 0;
        Note newNote = new Note();

        public NewNote()
        {
            InitializeComponent();
            Loaded += NewNote_Loaded;
        }

        void NewNote_Loaded(object sender, RoutedEventArgs e)
        {
            count = 0;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string id;
            if (this.NavigationContext.QueryString.TryGetValue("id", out id))
            {
                //Nếu có thì hiển thị cái có
                count = 1;
                count1 = 1;
                count2 = 1;
                title.Foreground = new SolidColorBrush(Colors.White);
                content.Foreground = new SolidColorBrush(Colors.White);

                newNote = MainPage.listNote.GetNote(id);

                title.Text = newNote.Title;
                content.Text = newNote.Content;
            }
            else
            {

            }
        }

        int count1 = 0;
        int count2 = 0;
        private void gotFocus(object sender, RoutedEventArgs e)
        {
            if (count1 == 0)
                title.Text = "";

            title.Foreground = new SolidColorBrush(Colors.Black);
            count1++;
        }

        private void lostFocus(object sender, RoutedEventArgs e)
        {
            title.Foreground = new SolidColorBrush(Colors.White);
        }

        private void gotFocus2(object sender, RoutedEventArgs e)
        {
            if (count2 == 0)
                content.Text = "";

            content.Foreground = new SolidColorBrush(Colors.Black);
            count2++;
        }

        private void lostFocus2(object sender, RoutedEventArgs e)
        {
            content.Foreground = new SolidColorBrush(Colors.White);
        }

        private async void clickSave(object sender, EventArgs e)
        {
            if (count == 0)
                newNote.Id = Helper.GenerateId();

            newNote.Time = Helper.GetTime();
            newNote.Title = title.Text;
            newNote.Content = content.Text;

            await MainPage.listNote.AddNote(newNote);
            MessageBox.Show("OK!");
        }
    }
}