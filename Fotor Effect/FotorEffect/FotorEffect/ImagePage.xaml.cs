using FotorEffect.Common;
using FotorEffect.Models;
using FotorEffect.UserControls;
using Nokia.Graphics.Imaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI;
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
    public sealed partial class ImagePage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        IRandomAccessStream _stream = null;
        string linkFile = "";
        public static StorageFile savedFile = null;

        public int xHeight
        {
            get { return App.photo.OriginalBitmap.PixelHeight; }
        }

        public int xWidth
        {
            get { return App.photo.OriginalBitmap.PixelWidth; }
        }
        public ImagePage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            btUndo.IsEnabled = false;
            StatusBar.GetForCurrentView().HideAsync();

        }

        #region NavigationHelper registration
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }


        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }


        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }


        #endregion

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataTransferManager.GetForCurrentView().DataRequested += OnShareDataRequested;

            btAdd.Visibility = App.photo != null ? Visibility.Collapsed : Visibility.Visible;
            if (App.photo != null)
            {
                xImage.Source = App.photo.OriginalBitmap;
                btUndo.IsEnabled = App.photo.CanUndo;
                btShare.IsEnabled = true;
                btShare.Label = "share your photo";
                btShare.Label = App.photo.IsSaved ? "share photo" : "save and share";
            }
            else
            {
                btEdit.IsEnabled = false;
                btEffect.IsEnabled = false;
                btSave.IsEnabled = false;
            }


        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            DataTransferManager.GetForCurrentView().DataRequested -= OnShareDataRequested;
        }





        private void clickEffect(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EffectImagePage));
        }

        private void clickEditImage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EditImagePage));
        }


        #region Open and Save File

        private void clickOpenImage(object sender, RoutedEventArgs e)
        {
            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.FileTypeFilter.Add(".jpg");
            filePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            filePicker.ViewMode = PickerViewMode.Thumbnail;
            App.ContinuationEventHandler += ContinueActivation;
            filePicker.PickSingleFileAndContinue();
        }

        private void clickSaveImage(object sender, RoutedEventArgs e)
        {
            FileSavePicker picker = new FileSavePicker();
            picker.FileTypeChoices.Add("JPG File", new List<string> { ".jpg" });
            picker.SuggestedFileName = string.Format("WP_{0}", DateTime.Now.ToString("yyyyMMddHHmmss"));
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            App.ContinuationEventHandler += ContinueActivation;
            picker.PickSaveFileAndContinue();

        }

        private async void ContinueActivation(object sender, IContinuationActivatedEventArgs e)
        {
            App.ContinuationEventHandler -= ContinueActivation;
            var argOpenFile = e as IFileOpenPickerContinuationEventArgs;
            var argSaveFile = e as IFileSavePickerContinuationEventArgs;

            //Chọn được ảnh
            if (argOpenFile != null && argOpenFile.Files != null && argOpenFile.Files.Count > 0)
            {
                if (_stream != null) _stream.Dispose();
                _stream = await argOpenFile.Files[0].OpenAsync(FileAccessMode.Read);
                WriteableBitmap bitmap = new WriteableBitmap(100, 100);
                bitmap.SetSource(_stream);
                _stream.Seek(0);
                //xImage.Source = bitmap;

                btAdd.Visibility = Visibility.Collapsed;

                App.photo = new PhotoModel();
                App.photo.ImageSource = new RandomAccessStreamImageSource(_stream);
                App.photo.OriginalBitmap = bitmap;
                xImage.Source = App.photo.OriginalBitmap;

                btEdit.IsEnabled = true;
                btEffect.IsEnabled = true;
                btSave.IsEnabled = true;
                savedFile = argOpenFile.Files[0];
                btShare.IsEnabled = true;
                btShare.Label = "share your photo";
                App.photo.IsSaved = true;
            }
            else
            {
                if (argSaveFile != null && argSaveFile.File != null)
                {
                    using (FilterEffect effect = App.photo.GetEffect())
                    using (var jpegRenderer = new JpegRenderer(effect))
                    using (var stream = await argSaveFile.File.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        // Jpeg renderer gives the raw buffer containing the filtered image.
                        IBuffer jpegBuffer = await jpegRenderer.RenderAsync();
                        await stream.WriteAsync(jpegBuffer);
                        await stream.FlushAsync();
                        linkFile = argSaveFile.File.Path;
                        savedFile = argSaveFile.File;
                        btShare.IsEnabled = true;
                        btShare.Label = "share photo";
                        App.photo.IsSaved = true;

                        if (dangShare)
                            DataTransferManager.ShowShareUI();
                    }
                }
            }



            if (App.photo != null)
                btAdd.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            else
                btAdd.Visibility = Windows.UI.Xaml.Visibility.Visible;

        }


        bool dangShare = false;
        #endregion

        private async void clickShare(object sender, RoutedEventArgs e)
        {
            dangShare = true;
            if (!App.photo.IsSaved)
            {
                clickSaveImage(this, null);

            }
            else
            {
                DataTransferManager.ShowShareUI();
            }

        }

        public async Task SaveFile()
        {
            try
            {
                savedFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("tempImage.jpg", CreationCollisionOption.ReplaceExisting);

                using (FilterEffect effect = App.photo.GetEffect())
                using (var jpegRenderer = new JpegRenderer(effect))
                using (var stream = await savedFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    IBuffer jpegBuffer = await jpegRenderer.RenderAsync();
                    await stream.WriteAsync(jpegBuffer);
                    await stream.FlushAsync();
                }
            }
            catch (Exception ex)
            {
                MessageDialog mess = new MessageDialog(ex.Message);
                mess.ShowAsync();
            }
        }






        // Handle DataRequested event and provide DataPackage
        void OnShareDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            try
            {
                dangShare = false;
                var dp = args.Request.Data;
               // var deferral = args.Request.GetDeferral();

                dp.Properties.Title = "new photo";
                // dp.SetText("123");
                //dp.Properties.Description = "The Space Needle in Seattle, WA";
                dp.SetStorageItems(new List<StorageFile> { savedFile });
                //deferral.Complete();

            }
            catch (Exception ex)
            {
                MessageDialog mess = new MessageDialog(ex.Message);
                mess.ShowAsync();
            }
        }

        private async void clickUndo(object sender, RoutedEventArgs e)
        {

            if (App.photo.CanUndo)
            {
                await App.photo.Undo();
                xImage.Source = App.photo.OriginalBitmap;
            }
            btUndo.IsEnabled = App.photo.CanUndo;
            App.photo.IsSaved = false;
            btShare.Label = "save and share";
        }

        private void clickExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void clickAbout(object sender, RoutedEventArgs e)
        {

        }

    }
}
