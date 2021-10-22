using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LunarCrushGet
{
    public class Processor
    {
        public static async Task<Root> LoadInformation()
        {
            string url = "https://api.lunarcrush.com/v2?data=assets&key=c1s8ov65f4hb4mawe9j1tb&symbol=LTC&data_points=1";

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


    }
}
