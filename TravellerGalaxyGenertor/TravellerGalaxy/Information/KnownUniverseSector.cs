using System.Collections.Generic;
using System.IO;
using System.Linq;
using SixLabors.ImageSharp;

namespace TravellerMapSystem
{
    public class KnownUniverseSector
    {
        private readonly MapNameLists _nameList;
        public string Name;
        public KnownUniverseSubsector[,] Subsectors;

        public Dictionary<string, string> SubsectorNames { get; }

        public int WorldCount => Subsectors.Cast<List<KnownUniverseSubsector>>()
            .Aggregate(0, (h, t) => h +
                                    t.Aggregate(0, (h, t) => h + WorldCount));

        public KnownUniverseSector(MapNameLists nameLists = MapNameLists.Generic)
        {
            Subsectors = new KnownUniverseSubsector[4, 4];
            Name = KnownUniverseSubsector.GenerateName(nameLists);
            SubsectorNames = new Dictionary<string, string>();
            _nameList = nameLists;
        }
        
        public KnownUniverseSector(string name, MapNameLists nameLists = MapNameLists.Generic)
        {
            Subsectors = new KnownUniverseSubsector[4, 4];
            Name = name;
            SubsectorNames = new Dictionary<string, string>();
            _nameList = nameLists;
        }

        public void GenerateSubsectors(int worldChance = 50)
        {
            for (var y = 0; y < Subsectors.GetLength(0); y++)
            for (var x = 0; x < Subsectors.GetLength(1); x++)
            {
                Subsectors[y, x] = new KnownUniverseSubsector(x, y);
                Subsectors[y, x].GenerateSubsector(_nameList, worldChance);
            }
        }

        public void WriteSector(string directory)
        {
            Directory.SetCurrentDirectory(directory);
            foreach (var subsector in Subsectors)
            {
                var sub = subsector.GenerateSubSectorImage();
                sub.Save(subsector.Name + ".jpg");
                // Console.ForegroundColor = ConsoleColor.Red;
                // Console.WriteLine($"Writing subsector {subsector.Name}");
                //  Console.ForegroundColor = ConsoleColor.Green;
                File.WriteAllText(directory + $"\\{subsector.Name}.txt", subsector.ToString());
            }
        }
    }
}