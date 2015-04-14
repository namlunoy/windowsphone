
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using System.Xml.Serialization;
using vservWindowsPhone;
using Windows.Storage;

namespace NarutoOST.Models
{
    public class Helper<T>
    {
     
        public static ObservableCollection<Song> PairXML(string content)
        {
            ObservableCollection<Song> l = new ObservableCollection<Song>();
            XDocument xdoc = XDocument.Parse(content);
            System.Xml.Serialization.XmlSerializer se = new System.Xml.Serialization.XmlSerializer(typeof(SongCollection));
            l = ((SongCollection)se.Deserialize(xdoc.CreateReader())).List;
            return l;
        }

    

        public static async Task<ObservableCollection<T>> readXMLAsync(string fileName)
        {
            string content = String.Empty;
            ObservableCollection<T> list = new ObservableCollection<T>();
            var l = await ApplicationData.Current.LocalFolder.GetFilesAsync();
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].Name.Equals(fileName))
                {
                    Debug.WriteLine("Path: " + l[i].Path);
                    var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(fileName);
                    using (StreamReader reader = new StreamReader(myStream))
                    {
                        XmlSerializer se = new XmlSerializer(typeof(ObservableCollection<T>));
                        list = se.Deserialize(reader) as ObservableCollection<T>;
                    }
                    return list;
                }
            }
            return list;
        }

        public static async Task writeXMLAsync(ObservableCollection<T> listPic, string fileName)
        {
            XmlSerializer se = new XmlSerializer(typeof(ObservableCollection<T>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(fileName,
                              CreationCollisionOption.ReplaceExisting))
            {
                se.Serialize(stream, listPic);
            }
        }

    }
}
