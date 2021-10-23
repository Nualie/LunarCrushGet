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

            try
            {
                Root test = new Root();
                Root.print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            

        }




    }

}