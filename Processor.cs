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
            string url = "https://api.lunarcrush.com/v2?data=assets&key=usd1pm5mhrtjoqcn6asxa&symbol=LTC&data_points=1";
            Console.WriteLine($"General API connection test: {RemoteFileExists("https://api.sunrise-sunset.org/json?lat=41.494804&lng=-75.536852&date=today")} ");
            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        Root result = await response.Content.ReadAsAsync<Root>();

                        return result;
                    }
                    else
                    {
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

