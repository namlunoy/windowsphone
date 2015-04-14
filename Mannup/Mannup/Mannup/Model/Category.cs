using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannup.Model
{
    public class Category
    {
        public String name { get; set; }
        public String Title { get { return name.ToUpper(); } }
        public String LinkString { get; set; }
        public Uri Url { get { return new Uri(LinkString); } }
    }
}
