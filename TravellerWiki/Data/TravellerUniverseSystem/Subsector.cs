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
        private Sector _sector;
        public Subsector(int x,int y, Sector sector)
        {
            Name = GenerateName() + $" subsector {x},{y}";
            Systems = new World[10, 8];
            _sector = sector;
        }

        public Subsector(List<string> worlds,string name, Sector sector)
        {
            Name = name;
            _sector = sector;
                Systems = new World[10,8];

            foreach (var worldText in worlds)
            {

                var world = new World(worldText);
                Systems[world.Y-1,world.X-1] = world;
            }

            for (int y = 0; y < Systems.GetLength(0); y++)
            {
                for (int x = 0; x < Systems.GetLength(1); x++)
                {
                    if (Systems[y, x] == null)
                    {
                        Systems[y, x] = new World(x, y,this);
                    }
                }
            }
        }

        public Subsector(List<string> worlds, Sector sector)
        {
            //Get the name
            Name = worlds[0];
            worlds.RemoveAt(0);
            //Remove the na,

            _sector = sector;
            Systems = new World[10, 8];

            foreach (var worldText in worlds)
            {

                var world = new World(worldText);
                Systems[world.Y - 1, world.X - 1] = world;
            }

            for (int y = 0; y < Systems.GetLength(0); y++)
            {
                for (int x = 0; x < Systems.GetLength(1); x++)
                {
                    if (Systems[y, x] == null)
                    {
                        Systems[y, x] = new World(x, y, this);
                    }
                }
            }
        }
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
                sb.Append(system.GetHTML());
            }

            return sb.ToString();
        }

        public void GenerateSubsector(int worldOdds = 50)
        {
            
                for (int y = 0; y < Systems.GetLength(0); y++)
                {
                    for (int x = 0; x < Systems.GetLength(1); x++)
                    {
                        if (random.Next(0, 101) <= worldOdds)
                        {
                            Systems[y, x] = new World(x, y, GenerateName(),this);
                        }
                        else
                        {
                            Systems[y, x] = new World(x, y,this);
                        }
                    }
                }
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