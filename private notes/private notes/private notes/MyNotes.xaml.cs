using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;

namespace private_notes
{
    public partial class MyNotes : PhoneApplicationPage
    {
        public MyNotes()
        {
            InitializeComponent();
            Loaded += MyNotes_Loaded;
        }

        void MyNotes_Loaded(object sender, RoutedEventArgs e)
        {
            list.ItemsSource = MainPage.listNote.Notes;
        }

        private void selectNote(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private async void click_Delete(object sender, RoutedEventArgs e)
        {
            if (list.ItemContainerGenerator == null) return;
            var selectedListBoxItem = list.ItemContainerGenerator.ContainerFromItem(((MenuItem)sender).DataContext) as ListBoxItem;
            if (selectedListBoxItem == null) return;
            var selectedIndex = list.ItemContainerGenerator.IndexFromContainer(selectedListBoxItem);
            MainPage.listNote.Notes.Remove((list.Items[selectedIndex] as Note));
            await MainPage.listNote.Save();
        }

      
    }
}