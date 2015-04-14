using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FotorEffect.UserControls
{
    public sealed partial class CategoryEffectControl : UserControl, INotifyPropertyChanged
    {
        public CategoryEffectControl()
        {
            this.InitializeComponent();
         
       
        }




        private Brush _color;
        public Brush Color
        {
            get { return this.Background; }
        }


        private String _text;
        public String Text
        {
            get { return _text; }
            set
            {
                _text = value;
                Notify("IsSelected");
            }
        }

        public List<EffectedImageItem> ListEffectedItems { get; set; }

        private Visibility _isSelected;
        public Visibility IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;// == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
                Notify("IsSelected");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
