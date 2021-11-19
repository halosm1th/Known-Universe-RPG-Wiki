using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

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
            Y = x;
            WorldsInSystem = new List<IWorld>();
            Name = name;

            if (systemSize > 0)
            {
                HasWorld = true;
                
                for (int i = 0; i < systemSize; i++)
                {
                    WorldsInSystem.Add(new TravellerWorld(name,i+1));
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