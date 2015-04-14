
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
        //private static Helper<T> _instance = null;
        //public static Helper<T> Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //            _instance = new Helper<T>();
        //        return _instance;
        //    }
        //}
        public static Random Rand = new Random();
        //public Helper() { _instance = this; Debug.WriteLine("OK"); }

        public static event EventHandler<String> DoneRequest;
        public static bool CheckInternet() { return NetworkInterface.GetIsNetworkAvailable(); }
        public static void Request(string url)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(url + "?" + DateTime.Now.ToLongTimeString());
            request.Method = "GET";
            request.BeginGetResponse(new AsyncCallback(ReadWebRequestCallBack), request);
        }
        private static void ReadWebRequestCallBack(IAsyncResult result)
        {
            try
            {
                string content = "";
                HttpWebRequest myRequest = (HttpWebRequest)result.AsyncState;
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.EndGetResponse(result);

                using (StreamReader reader = new StreamReader(myResponse.GetResponseStream()))
                { content = reader.ReadToEnd(); }

                myResponse.Close();

                if (DoneRequest != null)
                    DoneRequest(null, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show("You need connect to the Internet!");
            }
        }
        public static ObservableCollection<Song> PairXML(string content)
        {
            ObservableCollection<Song> l = new ObservableCollection<Song>();
            XDocument xdoc = XDocument.Parse(content);
            System.Xml.Serialization.XmlSerializer se = new System.Xml.Serialization.XmlSerializer(typeof(SongCollection));
            l = ((SongCollection)se.Deserialize(xdoc.CreateReader())).List;
            return l;
        }

        public static ImageBrush GetImage()
        {
            ImageBrush i = new ImageBrush();
            int k = Rand.Next(1, 6);
            BitmapImage bitmap = new BitmapImage(new Uri("/Assets/_" + k + ".jpg", UriKind.Relative));
            i.ImageSource = bitmap;
            return i;
        }

        public static ImageSource GetImageSource(string url, UriKind kind)
        {
            return new BitmapImage(new Uri(url, UriKind.Relative));
        }

        private static GoogleAds.InterstitialAd ads;
        public static Random random = new Random();
        public static void RequestAds()
        {
          
                ads = new GoogleAds.InterstitialAd("ca-app-pub-6921176146936171/2383282248");
                ads.ReceivedAd += ads_ReceivedAd;
                GoogleAds.AdRequest request = new GoogleAds.AdRequest();
                ads.LoadAd(request);
        
        }

        static void ads_FailedToReceiveAd(object sender, GoogleAds.AdErrorEventArgs e)
        {
            throw new NotImplementedException();
        }
   
        public static void LoadVserv(Grid LayoutRoot)
        {
            VservAdControl VMB = VservAdControl.Instance;
            //VMB.VservAdError += VMB_VservAdError;
           // VMB.VservAdNoFill += VMB_VservAdNoFill;
            VMB.DisplayAd("d00efdc8", LayoutRoot);
          
           
        }

        static void VMB_VservAdNoFill(object sender, EventArgs e)
        {
            RequestAds();
        }

        static void VMB_VservAdError(object sender, EventArgs e)
        {
            RequestAds();
        }

        static void ads_ReceivedAd(object sender, GoogleAds.AdEventArgs e)
        {
            ads.ShowAd();
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
