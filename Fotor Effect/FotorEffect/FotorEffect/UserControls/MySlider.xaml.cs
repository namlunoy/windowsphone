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
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FotorEffect.UserControls
{
    public sealed partial class MySlider : UserControl, INotifyPropertyChanged
    {
        public MySlider(string text, int maxValue)
        {
            this.InitializeComponent();
            xSlider.Maximum = maxValue;
        }
        public MySlider(string text,double min, double maxValue)
        {
            this.InitializeComponent();
            xSlider.Maximum = maxValue;
            xSlider.Minimum = min;
        }


        private int _maxValue;

        public int MaxValue
        {
            get { return _maxValue; }
            set { _maxValue = value; Notify("MaxValue"); }
        }


        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public Slider slider { get { return xSlider; } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
