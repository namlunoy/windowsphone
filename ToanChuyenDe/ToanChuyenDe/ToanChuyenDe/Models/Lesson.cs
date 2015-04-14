using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ToanChuyenDe.Models
{
    public class Lesson
    {
        public int STT { get; set; }

        [XmlElement("Title")]
        public String Title { get; set; }

        [XmlArray("Nodes")]
        [XmlArrayItem("Node")]
        public List<Node> Nodes { get; set; }
    }
}
