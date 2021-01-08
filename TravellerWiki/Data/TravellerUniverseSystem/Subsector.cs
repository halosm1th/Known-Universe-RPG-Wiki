using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TravellerUniverse
{
    public class Subsector
    {
        [JsonProperty]
        public World[,] Systems;
        public long WorldCount => (long)Systems.Cast<World>().Count(system => system.HasWorld);
        [JsonProperty]
        public string Name;

        public Subsector()
        {
            Name = "";
            Systems = EmptySubsector();
        }

        public Subsector(string name, World[,] systems)
        {
            Systems = systems;
            Name = name;
        }
        public Subsector(string name, List<World> systems)
        {
            Systems = EmptySubsector();
            Name = name;

            foreach (var world in systems)
            {
                Systems[world.Y, world.X] = world;
            }
        }

        private World[,] EmptySubsector()
        {
            var worlds = new World[10, 8];
            for (int y = 0; y < worlds.GetLength(0); y++)
            {
                for (int x = 0; x < worlds.GetLength(1); x++)
                {
                    worlds[y, x] = new World(x, y,false);
                }
            }

            return worlds;
        }

        private string GetPlanets()
        {
            var sb = new StringBuilder();
            foreach (var system in Worlds())
            {
                //sb.Append(system.GetHTML());
            }

            return sb.ToString();
        }


        public List<World> Worlds()
        {
            return SystemsAsList().Where(x => x.HasWorld).ToList();
        }

        public List<World> SystemsAsList()
        {
            var worlds = new List<World>();
            foreach (var system in Systems)
            {
                worlds.Add(system);
            }

            return worlds;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var worlds = SystemsAsList().Where(x => x.HasWorld).ToList();
            sb.Append($"Subsector {Name}\n");
            foreach (var world in worlds)
            {
                sb.Append(world.ToString() + "\n");
            }

            return sb.ToString();
        }

    }
}