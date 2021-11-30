using System;
using System.IO;

namespace TravellerMapSystem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var path = Directory.GetCurrentDirectory() + "/Malfantasai2/";


            var sec = new KnownUniverseSector();
            sec.GenerateSubsectors();
            sec.WriteSector(path);

            Console.WriteLine(path);
            Console.ReadKey();

            //var galaxy = new Galaxy("test");
        }
    }
}