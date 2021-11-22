using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds;
using TravellerGalaxyGenertor.TravellerGalaxy.Interfaces;

namespace TravellerMapSystem.Worlds
{
    public class KnownUniverseSystem
    {
        #region Variables
        public int X { get; }
        public int Y { get; }
        public bool HasWorld = false;
        public string Name { get; }
        public List<IWorld> WorldsInSystem { get; }
        
        public int WorldCount => WorldsInSystem.Count;

        public IWorld PrimaryWorld => WorldsInSystem.First();
        #endregion
        

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
                
                for (int i = 0; i < systemSize; i++)
                {
                    var worldtype = rand.Next(0, 2);
                    if (!hasCoreWorld || worldtype == 0)
                    {
                        WorldsInSystem.Add(new TravellerWorld(name, i + 1));
                        if (!hasCoreWorld) hasCoreWorld = true;

                    }else if (worldtype == 1)
                    {
                        WorldsInSystem.Add(new StarsWithoutNumberWorld(name,i+1));
                    }
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"System {Name}. Locations: {WorldsInSystem}.\n");
            foreach (var world in WorldsInSystem)
            {
                sb.Append($"  {world.ToString()}\n");
            }

            return sb.ToString();
        }
    }
}