using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TravellerMapSystem.Tools;
using TravellerMapSystem.Worlds;
using Image = SixLabors.ImageSharp.Image;

namespace TravellerMapSystem
{
    public class KnownUniverseSubsector
    {
        #region Variables
        
        [JsonProperty]
        public KnownUniverseSystem[,] Systems;
        
        [JsonProperty]
        public string Name;
        
        public long WorldCount => Systems.Cast<KnownUniverseSystem>().Aggregate(0,(h,t) => h + t.WorldCount);

        public BigInteger TotalPopulation =>
            Worlds().Aggregate(BigInteger.Zero, (h, t) => h + (t == null? 0 : BigInteger.Parse(t.Population )));
        
        [JsonIgnore]
        private static List<string> names = File.ReadAllLines(Directory.GetCurrentDirectory() + "/placeName.txt").ToList();
       // private static List<string> usedNames = new List<string>();

        private static Random random = new Random();
#endregion
        #region Constructor
        public KnownUniverseSubsector(int x,int y)
        {
            Name = GenerateName() + $" subsector {x},{y}";
            Systems = new KnownUniverseSystem[10, 8];
        }
        
        public KnownUniverseSubsector(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = names[random.Next(0, names.Count)];
            }
            
            Name = name;
            Systems = new KnownUniverseSystem[10, 8];
        }

        
        public KnownUniverseSubsector()
        {
            Name = "";
            Systems = GenerateEmptySubsector();
        }
        #endregion
        #region Private Methods
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
        #endregion
        #region Public Methods
        public void GenerateSubsector(int worldOdds = 50, int minSystemSize = 1, int maxSystemSize = 21)
        {
            if (maxSystemSize > 51)
            {
                maxSystemSize = 50;
            }

            if (minSystemSize < 0)
            {
                minSystemSize = 0;
            }
            
            for (int y = 0; y < Systems.GetLength(0); y++)
            {
                for (int x = 0; x < Systems.GetLength(1); x++)
                {
                    if (random.Next(0, 101) <= worldOdds)
                    {
                        Systems[y, x] = new KnownUniverseSystem(x, y, GenerateName(),random.Next(minSystemSize, maxSystemSize));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(Systems[y, x].ToString());
                    }
                    else
                    {
                        Systems[y, x] = new KnownUniverseSystem(x, y);
                    }
                }
            }
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
#endregion
        #region Get Information

        public Image GenerateSubSectorImage()
        {
            var drawing = new DrawSubsector(this);
            return drawing.GenerateSubSectorImage();
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

        public KnownUniverseSystem GetSystem(int x, int y)
        {
            return Systems[y, x];
        }

        public string Json()
        {
            return JsonConvert.SerializeObject(this,
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
        }
        
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Subsector {Name}\n");
            foreach (var system in Systems)
            {
                sb.Append(system.ToString() + "\n");
            }

            return sb.ToString().Replace("\n","");
        }
        #endregion
        #region Static Methods
        public static string GenerateName()
        {
            var name = names[random.Next(0, names.Count)];
            return name;
        }
        #endregion
        
    }
}