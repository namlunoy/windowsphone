using FotorEffect.Common;
using FotorEffect.UserControls;
using Nokia.Graphics.Imaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Popups;
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
    public sealed partial class EditImagePage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        EditImageCollection collection = new EditImageCollection();
        private double h = 0;
        private double w = 0;
        public EditImagePage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            HieuUngXoay90.Completed += HieuUngXoay90_Completed;
            xImage.Source = App.photo.OriginalBitmap;

            Loaded += EditImagePage_Loaded;
        }

        async void EditImagePage_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadEffectItem();
        }

        public async Task LoadEffectItem()
        {
            foreach (var item in collection.Items)
            {
                App.photo.AddFilterModel(item.Filter);
                item.OutputBitmap = await App.photo.LayHinhThuNho(80);
                App.photo.RemoveLastFilter();
                item.Height = 80;
                item.Width = 80;
                foreach (var s in item.Filter.Sliders)
                {
                    s.slider.ValueChanged += slider_ValueChanged;
                }
            }
            listSelection.ItemsSource = collection.Items;
        }

        bool isBusy = false;
        async void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            try
            {
                if (isBusy == false)
                {
                    isBusy = true;
                    //--------------------------------
                    //Nếu là loại đơn
                    if (listSelection != null && listSelection.SelectedItem != null)
                    {
                        EditImageItem ed = listSelection.SelectedItem as EditImageItem;
                        if (ed != null)
                        {
                            //Nếu là loại đơn
                            if (ed.Filter.Sliders.Count == 1)
                            {
                                if (e.NewValue == 0)
                                {
                                    WriteableBitmap b1 = new WriteableBitmap(App.photo.Width, App.photo.Height);
                                    await App.photo.RenderBitmapAsync(b1);
                                    xImage.Source = b1;
                                    return;
                                }
                            }
                            //Nếu là loại đa
                            switch (ed.Filter.Sliders.Count)
                            {
                                case 1:
                                    ed.Filter.Value = Convert.ToInt32(e.NewValue);
                                    break;
                                case 2:
                                    ed.Filter.A = ed.Filter.Sliders[0].slider.Value;
                                    ed.Filter.Value = ed.Filter.Sliders[1].slider.Value;
                                    break;
                                case 3:
                                    ed.Filter.R = ed.Filter.Sliders[0].slider.Value;
                                    ed.Filter.G = ed.Filter.Sliders[1].slider.Value;
                                    ed.Filter.B = ed.Filter.Sliders[2].slider.Value;
                                    break;
                                case 4:
                                    ed.Filter.R = ed.Filter.Sliders[0].slider.Value;
                                    ed.Filter.G = ed.Filter.Sliders[1].slider.Value;
                                    ed.Filter.B = ed.Filter.Sliders[2].slider.Value;
                                    ed.Filter.A = ed.Filter.Sliders[3].slider.Value;
                                    break;
                                default:
                                    break;
                            }




                            App.photo.AddFilterModel(ed.Filter);
                            WriteableBitmap b = new WriteableBitmap(App.photo.Width, App.photo.Height);
                            await App.photo.RenderBitmapAsync(b);
                            xImage.Source = b;
                            App.photo.RemoveLastFilter();
                        }
                    }
                    //-----------------------------
                    isBusy = false;
                }
                 
            }
            catch (Exception ex)
            {
                isBusy = false;
                MessageDialog m = new MessageDialog(ex.Message);
                m.ShowAsync();
            }
        }

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }


        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        { }

        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        { }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            h = xImage.ActualHeight;
            w = xImage.ActualWidth;

            Debug.WriteLine("xh = " + h + "\nxw = " + w);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        { }


        private void clickRotateImage(object sender, RoutedEventArgs e)
        {
            // btRotateImage.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            //// btCropImage.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            // btAcceptRotate.Visibility = Windows.UI.Xaml.Visibility.Visible;
            // btRotate.Visibility = Windows.UI.Xaml.Visibility.Visible;
            // btCancel.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void clickRotate(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Trước:\nh = " + xImage.ActualHeight + "\nw = " + xImage.ActualWidth);

            HieuUngXoay90.Begin();

        }
        private void clickCancelRotate(object sender, RoutedEventArgs e)
        {
            // btRotateImage.Visibility = Visibility.Visible;
            //// btCropImage.Visibility = Visibility.Visible;

            // btAcceptRotate.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            // btRotate.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            // btCancel.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            begin.Value = 0;
            end.Value = 0;
            HieuUngXoay90.Begin();
        }

        private async void clickAcceptRotateImage(object sender, RoutedEventArgs e)
        {
            //  btRotateImage.Visibility = Visibility.Visible;
            ////  btCropImage.Visibility = Visibility.Visible;

            //  btAcceptRotate.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            //  btRotate.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            //  btCancel.Visibility = Windows.UI.Xaml.Visibility.Collapsed;


            await App.photo.ApplyRotationFilterAsync(-begin.Value);
            Debug.WriteLine("Thưc hiện quay: " + (-begin.Value));
            App.photo.IsSaved = false;
            begin.Value = 0;
            end.Value = 0;
            xImage.Source = App.photo.OriginalBitmap;

            HieuUngXoay90.Begin();
        }



        void HieuUngXoay90_Completed(object sender, object e)
        {
            //xImage.Source = App.photo.OriginalBitmap;

            begin.Value = end.Value;
            end.Value = end.Value - 90;
            Debug.WriteLine("begin = " + begin.Value + " - end = " + end.Value);
        }

        private void CanLaiAnh()
        {
            Debug.WriteLine("Sau:\nh = " + xImage.ActualHeight + "\nw = " + xImage.ActualWidth);

            //xImage.Height = xImage.ActualWidth;
            //xImage.Width = xImage.ActualHeight;
        }



        private void selectFilterListChanged(object sender, SelectionChangedEventArgs e)
        {

            if (e != null && e.AddedItems != null && e.AddedItems.Count > 0)
            {
                EditImageItem c = e.AddedItems[0] as EditImageItem;
                if (c != null)
                {
                    editPanel.Visibility = Windows.UI.Xaml.Visibility.Visible;

                    c.Selected = Visibility.Visible;
                    stack.Children.Clear();
                    foreach (var item in c.Filter.Sliders)
                        stack.Children.Add(item);

                }
            }

            if (e != null && e.RemovedItems != null && e.RemovedItems.Count > 0)
            {
                EditImageItem c = e.RemovedItems[0] as EditImageItem;
                if (c != null)
                    c.Selected = Visibility.Collapsed;
            }
        }

        private async void clickCheck(object sender, TappedRoutedEventArgs e)
        {
            loading.Visibility = Windows.UI.Xaml.Visibility.Visible;
            if (listSelection != null && listSelection.SelectedItem != null)
            {
                EditImageItem ed = listSelection.SelectedItem as EditImageItem;
                if (ed != null)
                {
                    await App.photo.ApplyFilterModelAsync(ed.Filter);
                    await LoadEffectItem();
                }
            }
            loading.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            editPanel.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            listSelection.SelectedItem = null;
        }

        private void clickCancel(object sender, TappedRoutedEventArgs e)
        {

        }









    }
}
