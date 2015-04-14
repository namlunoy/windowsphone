using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.UI.Xaml;

namespace ToanChuyenDe.Models
{
    public class Helper<T> 
        where T : class , new ()
    {
        public static async Task<T> readXMLAsync(string fileName)
        {
            string content = String.Empty;
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///data.xml"));
           T list = new T();
           var myStream = await file.OpenStreamForReadAsync();
           using (StreamReader reader = new StreamReader(myStream))
           {
               
               XmlSerializer se = new XmlSerializer(typeof(T));
               list = se.Deserialize(reader) as T;
           }
           return list;
           
        }
    }
}
