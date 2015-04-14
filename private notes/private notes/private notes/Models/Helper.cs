using Microsoft.Phone.Net.NetworkInformation;
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

namespace private_notes
{
    public class Helper
    {
        public static string GenerateId()
        {
            return String.Format("{0}{1}{2}{3}", DateTime.Now.DayOfYear, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }
        public static string GetTime()
        {
            return String.Format("{0} - {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
        }

        public static async Task WriteToFile(String text, string fileName)
        {
            // Get the text data from the textbox. 
            byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes(text.ToCharArray());

            // Get the local folder.
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;


            // Create a new file named DataFile.txt.
            var file = await local.CreateFileAsync(fileName,
            CreationCollisionOption.ReplaceExisting);

            // Write the data from the textbox.
            using (var s = await file.OpenStreamForWriteAsync())
            {
                s.Write(fileBytes, 0, fileBytes.Length);
            }
        }


        public static async Task<string> ReadFile(string fileName)
        {
            // Get the local folder.
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            var listFile = await local.GetFilesAsync();
            foreach (var item in listFile)
            {
                if(item.Name.Equals(fileName))
                {
                    string text;
                    var file = await local.OpenStreamForReadAsync(fileName);
                    using (StreamReader streamReader = new StreamReader(file))
                        text = streamReader.ReadToEnd();
                    return text;
                }
            
            }
            return "";
        }


        public static async Task<ObservableCollection<Note>> readXMLAsync(string fileName)
        {
            string content = String.Empty;
            ObservableCollection<Note> list = new ObservableCollection<Note>();
            var l = await ApplicationData.Current.LocalFolder.GetFilesAsync();
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].Name.Equals(fileName))
                {
                    Debug.WriteLine("Path: " + l[i].Path);
                    var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(fileName);
                    using (StreamReader reader = new StreamReader(myStream))
                    {
                        XmlSerializer se = new XmlSerializer(typeof(ObservableCollection<Note>));
                        list = se.Deserialize(reader) as ObservableCollection<Note>;
                    }
                    return list;
                }
            }
            return list;
        }

        public static async Task writeXMLAsync(ObservableCollection<Note> listPic, string fileName)
        {
            XmlSerializer se = new XmlSerializer(typeof(ObservableCollection<Note>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(fileName,
                              CreationCollisionOption.ReplaceExisting))
            {
                se.Serialize(stream, listPic);
            }
        }

    }
}
