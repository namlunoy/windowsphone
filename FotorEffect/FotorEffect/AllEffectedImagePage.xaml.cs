using FotorEffect.Common;
using FotorEffect.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace FotorEffect
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AllEffectedImagePage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        public AllEffectedImagePage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            for (int i = 0; i < EffectImagePage.listCategory.Count; i++)
            {
                PivotItem item = new PivotItem();

                item.Header = EffectImagePage.listCategory[i].Text;
                GridView grid = new GridView();
                foreach (var it in EffectImagePage.listCategory[i].ListEffectedItems)
                    it.SetBigView(i);

                grid.ItemsSource = EffectImagePage.listCategory[i].ListEffectedItems;
                grid.SelectionChanged += grid_SelectionChanged;
                item.Content = grid;

                flipView.Items.Add(item);
            }
        }

        async void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e != null && e.AddedItems != null && e.AddedItems.Count > 0)
            {
                var item = e.AddedItems[0] as EffectedImageItem;
                if (item != null)
                {
                    await App.photo.ApplyFilterModelAsync(item.Filter);
                    this.Frame.GoBack();
                    App.photo.IsSaved = false;
                }
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //foreach (var item in ImagePage.ListEffectedImageItem)
            //{
            //    item.Height = 80;
            //    item.Width = 80;
            //}
        }



        #region NavigationHelper registration
        public NavigationHelper NavigationHelper
        { get { return this.navigationHelper; } }

        public ObservableDictionary DefaultViewModel
        { get { return this.defaultViewModel; } }


        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        { }

        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        { }

        #endregion

        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //foreach (var item in ImagePage.ListEffectedImageItem)
            //    item.Visible = Windows.UI.Xaml.Visibility.Collapsed;

            //if (e != null && e.AddedItems != null && e.AddedItems.Count>0)
            //{
            //    EffectedImageItem i = e.AddedItems[0] as EffectedImageItem;
            //    i.Visible = Windows.UI.Xaml.Visibility.Visible;
            //    ImagePage.selectedItem = i;
            //    this.Frame.GoBack();
            //}
        }


    }
}
