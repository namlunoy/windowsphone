using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.ComponentModel;

namespace MyQuiz.Usercontrols
{
    public enum EditType
    {
        Delete, Edit
    }
   public class UC_Args : EventArgs
   {
       public string Name { get; set; }
       public EditType TypeEdit { get; set; }
   }

    public partial class UC_Category : UserControl,INotifyPropertyChanged
    {
        private Category _Cate;
        public EventHandler<UC_Args> eventHanler;
        public Category Cate
        {
            get { return _Cate; }
            set { _Cate = value; Notify("Cate"); }
        }

        public UC_Category(Category c)
        {
            InitializeComponent();
            Cate = c;
            this.DataContext = this;
        }

        private void clickEditCategory(object sender, RoutedEventArgs e)
        {
            if (eventHanler != null)
            {
                UC_Args a = new UC_Args();
                a.Name = Cate.Name;
                a.TypeEdit = EditType.Edit;
                eventHanler(this, a);
            }
        }

        private void clickDeleteCategory(object sender, RoutedEventArgs e)
        {
            if (eventHanler != null)
            {
                UC_Args a = new UC_Args();
                a.Name = Cate.Name;
                a.TypeEdit = EditType.Delete;
                eventHanler(this, a);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private void clickEditCategory2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (eventHanler != null)
            {
                UC_Args a = new UC_Args();
                a.Name = Cate.Name;
                a.TypeEdit = EditType.Edit;
                eventHanler(this, a);
            }
        }
    }
}
