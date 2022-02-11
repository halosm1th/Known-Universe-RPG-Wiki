using System;
using System.IO;
using TravellerFactionSystem.Location;

namespace TravellerMapSystem
{
    internal class KnownUniverseSuperSector : TravellerLocation
    {
        public string Name;
        private readonly KnownUniverseSector[,] sectors;

        public KnownUniverseSuperSector(string name, int x, int y, int xSize, int ySize)
        {
            sectors = new KnownUniverseSector[ySize, xSize];
            Name = name + $" {x},{y}";
        }

        public void GenerateSuperSector()
        {
            for (var y = 0; y < sectors.GetLength(0); y++)
            for (var x = 0; x < sectors.GetLength(1); x++)
            {
                var s = new KnownUniverseSector();

                s.GenerateSubsectors(40);
                sectors[y, x] = s;
            }
        }

        public void WriteSuperSector(string path)
        {
            foreach (var sector in sectors)
            {
                var secPath = path + $"\\{sector.Name}_Sector";

                Directory.CreateDirectory(secPath);
                Console.WriteLine($"Writing {sector.Name} To: {secPath}");
                sector.WriteSector(secPath);
            }
        }
    }
}