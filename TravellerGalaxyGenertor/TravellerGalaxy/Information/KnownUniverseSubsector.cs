using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using TravellerMapSystem.Tools;
using TravellerMapSystem.Worlds;
using WikiServices.DataServices;

namespace TravellerMapSystem
{
    public enum MapNameLists
    {
        Generic,
        Versian
    }

    public class KnownUniverseSubsector
    {
        #region Private Methods

        private KnownUniverseSystem[,] GenerateEmptySubsector()
        {
            var systems = new KnownUniverseSystem[10, 8];
            for (var y = 0; y < systems.GetLength(0); y++)
            for (var x = 0; x < systems.GetLength(1); x++)
                systems[y, x] = new KnownUniverseSystem(x, y);

            return systems;
        }

        #endregion

        #region Static Methods

        public static string GenerateName(MapNameLists nameLists)
        {
            string name = "";
            if (nameLists == MapNameLists.Versian)
                name = versianNames[random.Next(0, versianNames.Count)];
            else name = genericNames[random.Next(0, genericNames.Count)];

            return name;
        }

        #endregion

        #region Variables

        [JsonProperty] public KnownUniverseSystem[,] Systems;

        [JsonProperty] public string Name;

        [JsonProperty] public int SubsectorX;
        [JsonProperty] public int SubsectorY;
        public long WorldCount => Systems.Cast<KnownUniverseSystem>().Aggregate(0, (h, t) => h + t.WorldCount);

        public BigInteger TotalPopulation =>
            Worlds().Aggregate(BigInteger.Zero, (h, t) => h + (t == null ? 0 : BigInteger.Parse(t.Population)));

        [JsonIgnore] private static readonly List<string> genericNames =
            File.ReadAllLines(Directory.GetCurrentDirectory() + "/placeName.txt").ToList();

        private static readonly List<string> versianNames =
            new HighVersianService().Words.Select(x => x.Letters)
                .ToList();
        // private static List<string> usedNames = new List<string>();

        private static readonly Random random = new();

        #endregion

        #region Constructor

        public KnownUniverseSubsector(string name, List<(string,string)> SystemInfo,  int otherWorldsInSystem = 1)
        {
            Name = name;
            Systems = GenerateEmptySubsector();

            foreach (var system in GetSystemInfoAsPieces(SystemInfo))
            {
                Systems[system.y, system.x] = new KnownUniverseSystem(system.name,  system.x, system.y, system.uwp,
                    system.army,system.fuel,system.other, system.faction, otherWorldsInSystem);
            }
        }
        
        public KnownUniverseSubsector(int x, int y, MapNameLists nameLists = MapNameLists.Generic)
        {
            Name = GenerateName(nameLists) + $" subsector {x},{y}";
            Systems = new KnownUniverseSystem[10, 8];
        }

        public KnownUniverseSubsector(string name)
        {
            if (string.IsNullOrEmpty(name)) name = genericNames[random.Next(0, genericNames.Count)];

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

        public List<(string name, int x, int y, string uwp,string faction, bool army, bool fuel, bool other)> 
            GetSystemInfoAsPieces(List<(string, string)> systemInfo) => systemInfo.Select(x => GetSystemInfoPiece(x)).ToList();

        public (string name, int x, int y, string uwp, string faction, bool army, bool fuel, bool other) GetSystemInfoPiece((string, string) systemInfoFull)
        {
            var systemInfo = systemInfoFull.Item1;
            var faction = systemInfoFull.Item2;
            var parts = systemInfo.Split(' ');
            if (parts.Length != 4) 
                throw new InvalidEnumArgumentException($"Error! Was expecting the format: NAME X:Y UWP BASES\n" +
                                                       $"But got: {systemInfo}");

            var name = parts[0];
            var loc = parts[1];
            var uwp = parts[2];
            var bools = parts[3];

            var x = Convert.ToInt32(loc.Split(':')[0]) -1;
            var y = Convert.ToInt32(loc.Split(':')[1]) -1;

            (bool army, bool fuel, bool other) = SplitSystemInfoBools(bools);

            return (name, x, y, uwp, faction,army, fuel, other);
        }

        public (bool army, bool fuel, bool other) SplitSystemInfoBools(string systemBools)
        {
            systemBools = systemBools.ToLower();
            var army = systemBools[0] == 'y';
            var fuel = systemBools[1] == 'y';
            var other = systemBools[2] == 'y';

            return (army, fuel, other);
        }
        #endregion

        #region Public Methods

        public void GenerateSubsector(MapNameLists nameList, int worldOdds = 50, int minSystemSize = 1,
            int maxSystemSize = 21)
        {
            if (maxSystemSize > 51) maxSystemSize = 50;

            if (minSystemSize < 0) minSystemSize = 0;

            for (var y = 0; y < Systems.GetLength(0); y++)
            for (var x = 0; x < Systems.GetLength(1); x++)
                if (random.Next(0, 101) <= worldOdds)
                {
                    Systems[y, x] = new KnownUniverseSystem(x, y, GenerateName(nameList),
                        random.Next(minSystemSize, maxSystemSize));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Systems[y, x].ToString());
                }
                else
                {
                    Systems[y, x] = new KnownUniverseSystem(x, y);
                }
        }

        public void WriteSubsector(StreamWriter sw)
        {
            foreach (var system in Systems)
                if (system.HasWorld)
                {
                    sw.WriteLine(system);
                    sw.Flush();
                }
        }

        #endregion

        #region Get Information

        /// <summary>
        /// Check if the subsector has a world which matches the name
        /// </summary>
        /// <param name="worldName">Example: Test(2,3:4'4)</param>
        /// <returns></returns>
        public bool HasWorld(string worldName)
        {
            bool hasWorld = false;

            for (int y = 0; y < Systems.GetLength(0); y++)
            {
                for (int x = 0; x < Systems.GetLength(1); x++)
                {
                    if ($"{Systems[y, x].Name}({x},{y}:{SubsectorX}'{SubsectorY}" == worldName)
                        return true;
                }
            }
            
            return hasWorld;
        }

        public KnownUniverseSystem GetWorld(string worldName)
        {
                for (int y = 0; y < Systems.GetLength(0); y++)
                {
                    for (int x = 0; x < Systems.GetLength(1); x++)
                    {
                        if ($"{Systems[y, x].Name}({x},{y}:{SubsectorX}'{SubsectorY}" == worldName)
                            return Systems[y,x];
                    }
                }

                return null;
        }

        public Image GenerateSubSectorImage()
        {
            var drawing = new DrawSubsector(this);
            return drawing.GenerateSubSectorImage();
        }

        public List<TravellerWorld> Worlds()
        {
            var worlds = new List<TravellerWorld>();
            foreach (var system in Systems) worlds.AddRange(system.WorldsInSystem.Select(x => x as TravellerWorld));

            return worlds;
        }

        public KnownUniverseSystem GetSystem(int x, int y)
        {
            return Systems[y, x];
        }

        public string Json()
        {
            return JsonConvert.SerializeObject(this,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Subsector {Name}\n");
            foreach (var system in Systems) sb.Append(system + "\n");

            return sb.ToString().Replace("\n", "");
        }

        #endregion
    }
}