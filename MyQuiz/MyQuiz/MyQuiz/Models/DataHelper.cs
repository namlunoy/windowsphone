using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using System.IO;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MyQuiz
{
    public class DataHelper<T>
        where T : new()
    {
        public static Random Rand = new Random();
        public static async Task ResetFiles()
        {
            var l = await ApplicationData.Current.LocalFolder.GetFilesAsync();
            for (int i = 0; i < l.Count; i++)
            {
                await l[i].DeleteAsync();
            }
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
