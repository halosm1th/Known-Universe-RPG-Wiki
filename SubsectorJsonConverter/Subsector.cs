using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TravellerUniverse
{
    class Subsector
    {

        public World[,] Systems;
        public long WorldCount => (long) Systems.Cast<World>().Count( system => system.HasWorld);

        public string Name;

        public Subsector(string[] WebText, string name)
        {
            Name = name;
            Systems = ParseWorlds(WebText);
        }

        private World[,] ParseWorlds(string[] worldText)
        {
            var systems = new World[8, 10];
            var index = 0;

            var worldName = "";
            var starportQuality = "";

            while (index < worldText.Length)
            {



                index++;
            }

            return systems;
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