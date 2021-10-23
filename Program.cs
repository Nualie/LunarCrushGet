using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Data;
using System.Threading.Tasks;
using System.Net;

namespace LunarCrushGet
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://api.lunarcrush.com/v2?data=assets&key=usd1pm5mhrtjoqcn6asxa&symbol=LTC";
            try
            {
                Root test = new Root();
                Root.print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            /*
            if (RemoteFileExists(url))
            {
               
            }
            else
            {
                Console.WriteLine("URL irresponsive");
            }*/
            

        }

        public static bool RemoteFileExists(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }


    }

}