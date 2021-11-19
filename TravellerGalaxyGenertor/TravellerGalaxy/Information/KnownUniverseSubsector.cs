using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TravellerMapSystem.Tools;
using TravellerMapSystem.Worlds;

namespace TravellerMapSystem
{
    public class KnownUniverseSubsector
    {
        
        [JsonProperty]
        public KnownUniverseSystem[,] Systems;
        
        [JsonProperty]
        public string Name;
        
        public long WorldCount => Systems.Cast<KnownUniverseSystem>().Aggregate(0,(h,t) => h + t.WorldCount);
        
        [JsonIgnore]
        private static List<string> names = File.ReadAllLines(Directory.GetCurrentDirectory() + "/placeName.txt").ToList();
       // private static List<string> usedNames = new List<string>();

        private static Random random = new Random();

        public KnownUniverseSubsector(int x,int y)
        {
            Name = GenerateName() + $" subsector {x},{y}";
            Systems = new KnownUniverseSystem[10, 8];
        }

        
        public KnownUniverseSubsector()
        {
            Name = "";
            Systems = GenerateEmptySubsector();
        }
        
        public static string GenerateName()
        {
            var name = names[random.Next(0, names.Count)];
            return name;
        }

        private KnownUniverseSystem[,] GenerateEmptySubsector()
        {
            var systems = new KnownUniverseSystem[10, 8];
            for (int y = 0; y < systems.GetLength(0); y++)
            {
                for (int x = 0; x < systems.GetLength(1); x++)
                {
                    systems[y, x] = new KnownUniverseSystem(x,y);
                }
            }

            return systems;
        }
        
        public void GenerateSubsector(int worldOdds = 50)
        {
            for (int y = 0; y < Systems.GetLength(0); y++)
                {
                    for (int x = 0; x < Systems.GetLength(1); x++)
                    {
                        if (random.Next(0, 101) <= worldOdds)
                        {
                            Systems[y, x] = new KnownUniverseSystem(x, y, GenerateName());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(Systems[y, x]);
                        }
                        else
                        {
                            Systems[y, x] = new KnownUniverseSystem(x, y);
                        }
                    }
                }
        }

        public Bitmap GenerateSubSectorImage()
        {
            var drawing = new DrawSubsector(this);
            return drawing.GenerateSubSectorImage();
        }

        public void WriteSubsector(StreamWriter sw)
        {
            foreach (var system in Systems)
            {
                if (system.HasWorld)
                {
                    sw.WriteLine(system);
                    sw.Flush();
                }
            }
        }

        public List<TravellerWorld> Worlds()
        {
            var worlds = new List<TravellerWorld>();
            foreach (var system in Systems)
            {
                worlds.AddRange(system.WorldsInSystem.Select(x => x as TravellerWorld));
            }

            return worlds;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Subsector {Name}\n");
            foreach (var system in Systems)
            {
                sb.Append(system.ToString() + "\n");
            }

            return sb.ToString();
        }

    }
}