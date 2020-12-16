using System;
using System.IO;
using TravellerUniverse;

namespace SubsectorJsonConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the full path to subsector: ");
            var path = Console.ReadLine();
            var text = File.ReadAllLines(path);

            Console.Write("Enter subsector name: ");
            var name = Console.ReadLine();

            var subsector = new Subsector(text,name);
            Console.WriteLine("Hello World!");
        }
    }
}
