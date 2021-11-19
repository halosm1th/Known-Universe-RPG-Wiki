﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TravellerMapSystem
{
    class KnownUniverseSector
    {
        private KnownUniverseSubsector[,] subsectors;
        public string Name;

        public KnownUniverseSector()
        {
            subsectors = new KnownUniverseSubsector[4,4];
            Name = KnownUniverseSubsector.GenerateName();
        }

        public void GenerateSubsectors(int worldChance = 50)
        {
            for (int y = 0; y < subsectors.GetLength(0); y++)
            {
                for (int x = 0; x < subsectors.GetLength(1); x++)
                {
                    subsectors[y,x] = new KnownUniverseSubsector(x,y);
                    subsectors[y,x].GenerateSubsector(worldChance);
                }
            }
        }

        public void WriteSector(string directory)
        {
            Directory.SetCurrentDirectory(directory);
            foreach (var subsector in subsectors)
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