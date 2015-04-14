using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;

namespace YES_or_NO
{
    public class FileHelper<T>
    {
        public static async Task<List<T>> readXMLAsync(string fileName)
        {
            string content = String.Empty;
            List<T> list = new List<T>();
            var l = await ApplicationData.Current.LocalFolder.GetFilesAsync();
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].Name.Equals(fileName))
                {
                    Debug.WriteLine("Path: " + l[i].Path);
                    var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(fileName);
                    using (StreamReader reader = new StreamReader(myStream))
                    {
                        XmlSerializer se = new XmlSerializer(typeof(List<T>));
                        list = se.Deserialize(reader) as List<T>;
                    }
                    return list;
                }
            }
            return list;
        }

        public static async Task writeXMLAsync(List<T> listPic, string fileName)
        {
            XmlSerializer se = new XmlSerializer(typeof(List<T>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(fileName,
                              CreationCollisionOption.ReplaceExisting))
            {
                se.Serialize(stream, listPic);
            }
        }

    }
}
