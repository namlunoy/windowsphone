using FotorEffect;
using FotorEffect.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

public class EditImageCollection
{
    public List<EditImageItem> Items = new List<EditImageItem>();
    public EditImageCollection()
    {
        Items.Add(new EditImageItem() { Filter = new BlurFilterModel(), Text="Blur" });
        Items.Add(new EditImageItem() { Filter = new BrightnessFilterModel(), Text = "Brightness" });
        Items.Add(new EditImageItem() { Filter = new ColorAdjustFilterModel(), Text = "Adjust Color" });
        Items.Add(new EditImageItem() { Filter = new ColorBoostFilterModel(), Text = "Boost Color" });
        Items.Add(new EditImageItem() { Filter = new ContrastFilterModel(), Text = "Contrast" });
        Items.Add(new EditImageItem() { Filter = new ColorizationFilterModel(), Text = "Colorization" });
        Items.Add(new EditImageItem() { Filter = new EmbossFilterModel(), Text = "Emboss" });
        Items.Add(new EditImageItem() { Filter = new ExposureFilterModel(), Text = "Exposure" });
        Items.Add(new EditImageItem() { Filter = new LevelsFilterModel(), Text = "Levels" });
        Items.Add(new EditImageItem() { Filter = new NoiseFilterModel(), Text = "Noise" });
        Items.Add(new EditImageItem() { Filter = new PaintFilterModel(), Text = "Paint" });
        Items.Add(new EditImageItem() { Filter = new PosterizeFilterModel(), Text = "Posterize" });
        Items.Add(new EditImageItem() { Filter = new TemperatureAndTintFilterModel(), Text = "Temperature" });


    }
}

namespace FotorEffect.UserControls
{
    public sealed partial class EditImageItem : UserControl, INotifyPropertyChanged
    {
        public EditImageItem()
        {
            this.InitializeComponent();
            DataContext = this;
            Selected = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private WriteableBitmap _outputBitmap = null;
        public WriteableBitmap OutputBitmap
        {
            get { return _outputBitmap; }
            set { _outputBitmap = value; NotifyPropertyChanged("OutputBitmap"); }
        }

        private ImageSource _imageSource;
        public ImageSource ImageSource
        {
            get { return _imageSource; }
            set { _imageSource = value; NotifyPropertyChanged("ImageSource"); }
        }



        private Visibility _selected;
        public Visibility Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                NotifyPropertyChanged("Selected");
            }

        }



        private String _text = "";
        public String Text
        {
            get { return _text; }
            set { _text = value; NotifyPropertyChanged("Text"); }
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
