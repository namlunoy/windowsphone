using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyQuiz
{
    public class Quiz
    {
        public string ID { get; set; }
        public string Question { get; set; }
        public string Answer_A { get; set; }
        public string Answer_B { get; set; }
        public string Answer_C { get; set; }
        public string Answer_D { get; set; }
        public string DapAnDung { get; set; }

        [XmlIgnore]
        public string DapAnDaChon { set; get; }
        public bool KetQua { get { return DapAnDung.Equals(DapAnDaChon); } }
        public string CategoryName { get; set; }
        public Quiz()
        {
            DapAnDaChon = "";
            DapAnDung = "";
        }
    }
}
