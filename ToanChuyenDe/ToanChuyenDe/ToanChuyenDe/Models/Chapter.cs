using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ToanChuyenDe.Models
{
    public class Chapter
    {
        [XmlElement("Title")]
        public String Title { get; set; }

        [XmlArray("Lessons")]
        [XmlArrayItem("Lesson")]
        public List<Lesson> Lessons { get; set; }
    }

    [XmlRoot("root")]
    public class ChapterCollection
    {
        [XmlArray("Chapters")]
        [XmlArrayItem("Chapter")]
        public ObservableCollection<Chapter> Chapters = new ObservableCollection<Chapter>();
    }
}
