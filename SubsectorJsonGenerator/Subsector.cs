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
        private static List<string> names = File.ReadAllLines(Directory.GetCurrentDirectory() + "/placeName.txt").ToList();
       // private static List<string> usedNames = new List<string>();

        private static Random random = new Random();
        
        public static string GenerateName()
        {

            var name = names[random.Next(0, names.Count)];

            //names.Remove(name);
            //usedNames.Add(name);
            return name;
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