using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannup.Model
{
    public class Category : INotifyPropertyChanged
    {
        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("IsSelected"));
            }
        }



        public String name { get; set; }
        public String Title { get { return name; } }
        public String LinkString { get; set; }
        public Uri Url { get { return new Uri(LinkString); } }
        public int Type { get; set; }

        public Category()
        {
            IsSelected = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
