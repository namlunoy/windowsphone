using Nokia.Graphics.Imaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FotorEffect.UserControls
{
    public sealed partial class EffectedImageItem : UserControl, INotifyPropertyChanged
    {
        public EffectedImageItem()
        {
            this.InitializeComponent();
            DataContext = this;

        }


        private Visibility _visible;
        public Visibility Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;//== Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed; 
                NotifyPropertyChanged("Visible");
            }
        }

        private WriteableBitmap _outputBitmap = null;
        public WriteableBitmap OutputBitmap
        {
            get { return _outputBitmap; }
            set { _outputBitmap = value; NotifyPropertyChanged("OutputBitmap"); }
        }


        private String _text = "";
        public String Text
        {
            get { return _text; }
            set { _text = value; NotifyPropertyChanged("Text"); }
        }

        public void SetBigView(int f)
        {
            f = f % 4;
            Height = 110;
            Width = 100;
            //Name.Visibility = Windows.UI.Xaml.Visibility.Visible;
            Margin = new Thickness(3, 10, 4, 0);
            Frame.Visibility = Windows.UI.Xaml.Visibility.Visible;
          //  image.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //switch (f)
            //{
            //    case 0:
            //        Frame.Source = new BitmapImage(new Uri("ms-appx:///Assets/f1.png"));
            //        break;
            //    case 1:
            //        Frame.Source = new BitmapImage(new Uri("ms-appx:///Assets/f2.png"));
            //        break;
            //    case 2:
            //        Frame.Source = new BitmapImage(new Uri("ms-appx:///Assets/f3.png"));
            //        break;
            //    case 3:
            //        Frame.Source = new BitmapImage(new Uri("ms-appx:///Assets/f4.png"));
            //        break;
            //    default:
            //        break;
            //}
        }

        public void SetSmallView()
        {
            Height = 80;
            Width = 80;
           // Margin = new Thickness(0, 20, 20, 0);
        }

        public FilterModel Filter { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
