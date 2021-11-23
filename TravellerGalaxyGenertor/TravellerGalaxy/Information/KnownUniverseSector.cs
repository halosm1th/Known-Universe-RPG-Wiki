using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;

namespace TravellerMapSystem
{
    public class KnownUniverseSector
    {
        public KnownUniverseSubsector[,] Subsectors;
        public string Name;

        public KnownUniverseSector()
        {
            Subsectors = new KnownUniverseSubsector[4,4];
            Name = KnownUniverseSubsector.GenerateName();
        }

        public void GenerateSubsectors(int worldChance = 50)
        {
            for (int y = 0; y < Subsectors.GetLength(0); y++)
            {
                for (int x = 0; x < Subsectors.GetLength(1); x++)
                {
                    Subsectors[y,x] = new KnownUniverseSubsector(x,y);
                    Subsectors[y,x].GenerateSubsector(worldChance);
                }
            }
        }

        public void WriteSector(string directory)
        {
            Directory.SetCurrentDirectory(directory);
            foreach (var subsector in Subsectors)
            {
                var sub= subsector.GenerateSubSectorImage();
                sub.Save(subsector.Name + ".jpg");
               // Console.ForegroundColor = ConsoleColor.Red;
               // Console.WriteLine($"Writing subsector {subsector.Name}");
              //  Console.ForegroundColor = ConsoleColor.Green;
                File.WriteAllText(directory + $"\\{subsector.Name}.txt",subsector.ToString());
            }
        }

    }
}