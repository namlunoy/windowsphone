using Microsoft.Phone.BackgroundAudio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NarutoOST.Models
{

    public class Song : IComparable<Song>,IEquatable<Song>
    {
        [XmlElement("i")]
        public int Index;

        [XmlIgnore]
        public int STT { get; set; }

        [XmlElement("time")]
        public string Time { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("link")]
        public string LinkSring;

        [XmlElement("type")]
        public int Loai = 3;

        public Uri LinkUri { get { return new Uri(LinkSring, UriKind.Absolute); } }
        public AudioTrack GetAudiTrack { get { return new AudioTrack(LinkUri, Name, Author, "", null, "", EnabledPlayerControls.All); } }
        public int CompareTo(Song other) { return this.Name.CompareTo(other.Name); }

        [XmlIgnore]
        public bool IsInFavorite = false;

        public Song CloneFavorite()
        {

            Song clone = new Song();
            this.IsInFavorite = true;
            clone.IsInFavorite = true;
            clone.Author = this.Author;
            clone.Index = this.Index;
            clone.LinkSring = this.LinkSring;
            clone.Loai = 3;
            clone.Name = this.Name;
            clone.Time = this.Time;
            return clone;
        }

        public bool Equals(Song other)
        {
            return this.Name.Equals(other.Name);
        }
    }

    [XmlRoot("root")]
    public class SongCollection
    {
        [XmlArray("ListSong")]
        [XmlArrayItem("Song")]
        public ObservableCollection<Song> List = new ObservableCollection<Song>();

    }
}
