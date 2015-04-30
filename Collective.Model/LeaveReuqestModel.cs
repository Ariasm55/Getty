using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using RestSharp;


namespace Collective.Model
{
   public class LeaveRequestModel
    {
       class Products
       {
           public string Name { get; set; }
           public double Price { get; set; }
           public string Category { get; set; }
       }
       public string Name { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }

       public static void SendRequest()
       {
           var request = WebRequest.Create("https://portal.collectivesolution.net/api/leave_add.aspx");
           request.Method = "POST";
           request.ContentType = "text/json; charset=utf-8";
           using (var writer = new StreamWriter(request.GetRequestStream()))
           {
               var user = "juan.arias";
               writer.Write("getty_username =" + user, "type = 2", "start_date=4/26/2015","count=1","reason= Testing this API in WPF");
               Console.Write("hi im Kirby");
               //writer.Write("type=1");
               //writer.Write("start_date=4/26/2015");
               //writer.Write("count=1");
               //writer.Write("reason=Testing API online using WPF");
           }
           var httpResponse1 = (HttpWebResponse)request.GetResponse();
           using (var streamReader = new StreamReader(httpResponse1.GetResponseStream()))
           {
               var result = streamReader.ReadToEnd();
               MessageBox.Show(result);
           }


           //var httpWebRequest = (HttpWebRequest)WebRequest.Create("path/api");
           //httpWebRequest.ContentType = "text/json";
           //httpWebRequest.Method = "POST";
           //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
           //{
           //    streamWriter.Write(json);
           //    streamWriter.Flush();
           //}
           //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();


           var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://portal.collectivesolution.net/api/leave_add.aspx");
           httpWebRequest.ContentType = "application/json; charset=utf-8";
           httpWebRequest.Method = "POST";
           
          
           using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
           {
               string json = "{\"getty_username\":\"juan.arias\"" +
                             "\"type\":\"2\"" +
                             "\"start_date\":\"4/30/2015\"" +
                             "\"count\":\"1\"" +
                             "\"reason\":\"Like my new Testing Ground\"}";

               streamWriter.Write(json);
               
           }

           var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
           using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
           {
               var result = streamReader.ReadToEnd();
               MessageBox.Show(result);
           }


       }

       public static void Sendme()
       {
           var client = new RestClient("https://portal.collectivesolution.net/api/testpage.aspx");

       }

    }
}
