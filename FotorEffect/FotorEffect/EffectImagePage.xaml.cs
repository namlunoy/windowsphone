using FotorEffect.Common;
using FotorEffect.Models;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace FotorEffect
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EffectImagePage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        public FilterCollection filterCollection = new FilterCollection();
        private FilterModel selectedFilter = null;
        public static List<CategoryEffectControl> listCategory = new List<CategoryEffectControl>();
        public EffectImagePage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            Loaded += EffectImagePage_Loaded;
        }

        async void EffectImagePage_Loaded(object sender, RoutedEventArgs e)
        {
            loading.Visibility = Windows.UI.Xaml.Visibility.Visible;
            xImage.Source = App.photo.OriginalBitmap;
            int count = 1;
            listCategory.Clear();
            foreach (var listFilter in filterCollection.FilterList)
            {
                CategoryEffectControl category = new CategoryEffectControl();
                List<EffectedImageItem> listItem = new List<EffectedImageItem>();
                foreach (FilterModel filter in listFilter)
                {
                    EffectedImageItem image = new EffectedImageItem();
                    image.Filter = filter;
                    image.Text = filter.Name;
                    App.photo.AddFilterModel(filter);
                    image.OutputBitmap = await App.photo.LayHinhThuNho(80);
                    App.photo.RemoveLastFilter();
                    image.Height = 80;
                    image.Width = 80;
                    image.Visible = Windows.UI.Xaml.Visibility.Collapsed;
                    listItem.Add(image);
                }
                category.ListEffectedItems = listItem;
                category.Height = 60;
                category.Width = 60;
                category.Text = count.ToString();
                switch (count)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        category.Text = "gray";
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
                count++;
                category.IsSelected = Visibility.Collapsed;
                listCategory.Add(category);
            }
            listSelection.ItemsSource = listCategory;
            listSelection.SelectedIndex = 0;
            loading.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

        }


        public NavigationHelper NavigationHelper
        { get { return this.navigationHelper; } }

        public ObservableDictionary DefaultViewModel
        { get { return this.defaultViewModel; } }

        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        { }


        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        { }


        protected  override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        { }


        private async void clickCheck(object sender, TappedRoutedEventArgs e)
        {
            if (selectedFilter != null)
                await App.photo.ApplyFilterModelAsync(selectedFilter);
          
            this.Frame.GoBack();
        }

        private void selectFilterListChanged(object sender, SelectionChangedEventArgs e)
        {


            if (e != null && e.AddedItems != null && e.AddedItems.Count > 0)
            {
                CategoryEffectControl c = e.AddedItems[0] as CategoryEffectControl;
                if (c != null)
                {
                    c.IsSelected = Visibility.Visible;
                    ListViewEffectItems.ItemsSource = c.ListEffectedItems;
                }
            }

            if (e != null && e.RemovedItems != null && e.RemovedItems.Count > 0)
            {
                CategoryEffectControl c = e.RemovedItems[0] as CategoryEffectControl;
                if (c != null)
                    c.IsSelected = Visibility.Collapsed;
            }
        }

        private async void selectEffect(object sender, SelectionChangedEventArgs e)
        {
            loading.Visibility = Windows.UI.Xaml.Visibility.Visible;

            if (e != null && e.AddedItems != null && e.AddedItems.Count > 0)
            {
                var i = e.AddedItems[e.AddedItems.Count - 1] as EffectedImageItem;
                if (i != null)
                {
                    i.Visible = Windows.UI.Xaml.Visibility.Visible;
                    App.photo.AddFilterModel(i.Filter);
                    WriteableBitmap b = new WriteableBitmap(App.photo.Width, App.photo.Height);
                    await App.photo.RenderBitmapAsync(b);
                    xImage.Source = b;
                    App.photo.RemoveLastFilter();
                    selectedFilter = i.Filter;

                }
            }

            if (e != null && e.RemovedItems != null)
            {
                foreach (var item in e.RemovedItems)
                {
                    EffectedImageItem i = item as EffectedImageItem;
                    if (i != null)
                        i.Visible = Windows.UI.Xaml.Visibility.Collapsed;
                }
            }

            loading.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

        }

        private void clickViewAll(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AllEffectedImagePage));
        }
    }
}
