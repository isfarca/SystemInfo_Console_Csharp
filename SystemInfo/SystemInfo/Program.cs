using System;
using System.Reflection;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var gpuInfo = new SystemInfo.GraphicsAdapterInfo();
            var cpuInfo = new SystemInfo.ProcessorInfo();

            Console.WriteLine("------------------------");
            Console.WriteLine(" Graphics Adapter Info");
            Console.WriteLine("------------------------");

            foreach(PropertyInfo prop in gpuInfo.GetType().GetProperties())
            {
                Console.WriteLine(String.Format("{0}: {1}", prop.Name, prop.GetValue(gpuInfo, null)));
            }

            Console.WriteLine("");
            Console.WriteLine("");


            Console.WriteLine("------------------------");
            Console.WriteLine("    Processor Info");
            Console.WriteLine("------------------------");

            foreach (PropertyInfo prop in cpuInfo.GetType().GetProperties())
            {
                Console.WriteLine(String.Format("{0}: {1}", prop.Name, prop.GetValue(cpuInfo, null)));
            }

            Console.ReadKey();
        }
    }
}
