using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using Newtonsoft.Json;
using TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds;
using TravellerGalaxyGenertor.TravellerGalaxy.Interfaces;

namespace TravellerMapSystem.Worlds
{
    public class KnownUniverseSystem
    {
        public KnownUniverseSystem(int x, int y, string name = "", int systemSize = 0)
        {
            X = x;
            Y = y;
            WorldsInSystem = new List<IWorld>();
            Name = name;
            var rand = new Random(name.Aggregate(0, (h, t) => h + t));
            var hasCoreWorld = false;

            if (systemSize > 0)
            {
                HasWorld = true;

                for (var i = 0; i < systemSize; i++)
                {
                    var worldtype = rand.Next(1, 101);
                    if (!hasCoreWorld || worldtype >= 1 && worldtype <= 25)
                    {
                        WorldsInSystem.Add(new TravellerWorld(name, i + 1));
                        if (!hasCoreWorld) hasCoreWorld = true;
                    }
                    else if (worldtype >= 25 && worldtype <= 60)
                    {
                        WorldsInSystem.Add(new StarsWithoutNumberWorld(name, i + 1));
                    }
                    else if (worldtype >= 60 && worldtype <= 101)
                    {
                        WorldsInSystem.Add(new StarsWithoutNumberPointOfInterest(name, i + 1));
                    }
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"System {Name}. Locations: {WorldsInSystem}.\n");
            foreach (var world in WorldsInSystem) sb.Append($"  {world.ToString()}\n");

            return sb.ToString();
        }

        #region Variables

        [JsonProperty] public int X { get; set; }

        [JsonProperty] public int Y { get; set; }

        [JsonProperty] public bool HasWorld { get; set; }

        [JsonProperty] public string Name { get; set; }

        [JsonProperty] public List<IWorld> WorldsInSystem { get; set; }


        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int WorldCount => WorldsInSystem.Count;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int AverageTechLevel => WorldsInSystem.Aggregate(0, (h, t) => h + t.TechLevel) /
                                       (WorldsInSystem.Count > 0 ? WorldsInSystem.Count : 1);

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public BigInteger TotalPopulation =>
            WorldsInSystem.Aggregate(BigInteger.Zero, (h, t) => h + BigInteger.Parse(t.Population));

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IWorld PrimaryWorld => WorldCount > 0 ? WorldsInSystem.First() : null;

        #endregion
    }
}