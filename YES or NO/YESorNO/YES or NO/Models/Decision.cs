using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YES_or_NO
{
   public  class Decision : IComparable<Decision>
    {
        public string Content { get; set; }
        public string YourChoice { get; set; }
        public DateTime Time { get; set; }
        public string Result { get; set; }

       public Decision()
        {
            Result = "";
        }
        public int CompareTo(Decision other)
        {
            return -this.Time.CompareTo(other.Time);
        }
    }


    public static class Choices
    {
        public const string YES = "YES";
        public const string NO = "NO";
        public const string THINKING = "thinking...";
    }
}
