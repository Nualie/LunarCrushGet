using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarCrushGet
{
    public class Root
    {
        public Config config { get; set; }
        public Usage usage { get; set; }
        public List<Datum> data { get; set; }


        public static async void print()
        {
            var info = await Processor.LoadInformation();
            Console.WriteLine("Info:\n");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(info))
            {
                try
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(info);
                    Console.WriteLine("{0}={1}", name, value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }

}
