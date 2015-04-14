using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ToanChuyenDe.Models
{
    public class Node
    {
        public int STT { get; set; }

        [XmlElement("Content")]
        public String Content { get; set; }

        [XmlElement("ImageURL")]
        public String ImageURL { get; set; }
    }
}
