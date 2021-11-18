using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LunarCrushGet
{
    public class Processor
    {
        public static async Task<Root> LoadInformation()
        {
            string key = "zfywgqd3a09ut8v0jd2d9c";
            string url = $"https://api.lunarcrush.com/v2?data=assets&key="+key+"&symbol=LTC&data_points=1";

            Console.WriteLine("Trying to access:\n"+url);

            //https://api.lunarcrush.com/v2?data=assets&key=zfywgqd3a09ut8v0jd2d9c&symbol=LTC&data_points=1
            //link leads to a JSON and not error 403 so it exists
            Console.WriteLine($"General API connection test: {RemoteFileExists("https://api.sunrise-sunset.org/json?lat=41.494804&lng=-75.536852&date=today")} ");
            //check connection to detect a website that's known to be up and running
            Console.WriteLine($"Lunarcrush Website API connection test: {RemoteFileExists("https://legacy.lunarcrush.com/developers/docs")} ");
            //check connection to lunarcrush in general
            Console.WriteLine($"Specific API connection test:");
            while (!RemoteFileExists(url))
            {

            }
            //Console.WriteLine($"Specific API connection test: {RemoteFileExists(url)} ");
            //check connection to the url we actually want

            //code has failed over and over because of what seems to be an auth problem although it works on browser fine
            try
            {
                ApiHelper help = new ApiHelper();
                using (HttpResponseMessage response = await help.ApiClient.GetAsync(url))
                {

                    Console.WriteLine("Status code: " + response.StatusCode);
                    if (response.IsSuccessStatusCode)
                    {
                        Root result = await response.Content.ReadAsAsync<Root>();

                        return result;
                    }
                    else
                    {
                        Console.WriteLine("Status code: " + response.StatusCode);
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("API failed to connect");
                return null;
            }


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
                Console.WriteLine("Status code: "+response.StatusCode);
                //Returns TRUE if the Status code == 200
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch(Exception e)
            {
                //Any exception will returns false.
                Console.WriteLine(e);
                return false;
            }

        }
    } 
}

