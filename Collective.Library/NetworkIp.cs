using System.Net;
using System.Net.Sockets;

namespace Collective.Library
{
   public class NetworkIp
    {
       public static string LocalIPAddress()
       {
           IPHostEntry host;
           string localIp = "";
           host = Dns.GetHostEntry(Dns.GetHostName());
           foreach (IPAddress ip in host.AddressList)
           {
               if (ip.AddressFamily == AddressFamily.InterNetwork)
               {
                   localIp = ip.ToString();
                   break;
               }
           }
           return localIp;
       }
    }
}
