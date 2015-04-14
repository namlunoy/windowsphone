using Microsoft.Phone.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannup.Model
{
    public class Helper
    {
        public static string bannerID = "ca-app-pub-6921176146936171/9175163444";
        public static string BillboardId = "ca-app-pub-6921176146936171/6221697045";

        public static bool CheckNetwork()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }
       
    }
}
