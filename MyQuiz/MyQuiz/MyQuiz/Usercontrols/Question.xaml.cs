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
using System.Windows.Media;
using System.Diagnostics;
using Microsoft.Phone.Tasks;

namespace MyQuiz.Usercontrols
{
    public partial class Question : UserControl,INotifyPropertyChanged
    {
        private Quiz _quiz;
        public EventHandler<UC_Args> eventHanler;
        public Quiz xQuiz
        {
            get { return _quiz; }
            set { _quiz = value; Notify("xQuiz"); }
        }


        private string _stt;

        public string STT
        {
            get { return _stt; }
            set { _stt = value; Notify("STT"); }
        }
        public Question()
        {
            Debug.WriteLine("Chạy hàm tạo mặc định!");
        }
        public Question(Quiz q)
        {
            InitializeComponent();
            xQuiz = q;

            rect.Fill = q.KetQua ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);

            switch (xQuiz.DapAnDung)
            {
                case "A":
                    eliipse_A.Fill = new SolidColorBrush(Colors.Blue);
                    break;
                case "B":
                    eliipse_B.Fill = new SolidColorBrush(Colors.Blue);
                    break;
                case "C":
                    eliipse_C.Fill = new SolidColorBrush(Colors.Blue);
                    break;
                case "D":
                    eliipse_D.Fill = new SolidColorBrush(Colors.Blue);
                    break;
                default:
                    break;
            }


            if (!xQuiz.KetQua)
            {
                switch (xQuiz.DapAnDaChon)
                {
                    case "A":
                        eliipse_A.Fill = new SolidColorBrush(Colors.Red);
                        break;
                    case "B":
                        eliipse_B.Fill = new SolidColorBrush(Colors.Red);
                        break;
                    case "C":
                        eliipse_C.Fill = new SolidColorBrush(Colors.Red);
                        break;
                    case "D":
                        eliipse_D.Fill = new SolidColorBrush(Colors.Red);
                        break;
                    default:
                        break;
                }
            }
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        bool _isClop = true;
        bool _hidePanel = false;
        public void Expend()
        {
            editPanel.Visibility = System.Windows.Visibility.Visible;
            DapAn.Visibility = System.Windows.Visibility.Visible;
            _isClop = false;
        }

        public void HideEditPanel()
        {
            editPanel.Visibility = System.Windows.Visibility.Collapsed;
            _hidePanel = true;
        }

        private void clickTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (_isClop)
            {
              if(_hidePanel == false)  editPanel.Visibility = System.Windows.Visibility.Visible;
               DapAn.Visibility = System.Windows.Visibility.Visible;
                _isClop = false;
            }
            else
            {
                DapAn.Visibility = System.Windows.Visibility.Collapsed;
                editPanel.Visibility = System.Windows.Visibility.Collapsed;
                _isClop = true;
            }
        }

        private void clickEditCategory(object sender, RoutedEventArgs e)
        {
            if (eventHanler != null)
                eventHanler(this, new UC_Args() { Name = xQuiz.ID, TypeEdit = EditType.Edit });
        }

        private void clickDeleteCategory(object sender, RoutedEventArgs e)
        {
            if (eventHanler != null)
                eventHanler(this, new UC_Args() { Name = xQuiz.ID, TypeEdit = EditType.Delete });
        }

        private void clickShare(object sender, RoutedEventArgs e)
        {
            ShareStatusTask shareStatusTask = new ShareStatusTask();

            shareStatusTask.Status = string.Format("Can you try this one!\nQuestion: {0}\nA: {1}\nB: {2}\nC: {3}\nD: {4}\n<from my quizzes on Windows Phone>",xQuiz.Question,xQuiz.Answer_A,
                xQuiz.Answer_B,xQuiz.Answer_C,xQuiz.Answer_D);

            shareStatusTask.Show();
        }
    }
}
