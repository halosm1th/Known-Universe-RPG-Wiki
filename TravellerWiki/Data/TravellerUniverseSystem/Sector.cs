using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellerUniverse
{
    public class Sector
    {
        public Subsector[,] Subsectors { get; set; }
        public string Name;

        public long WorldCount => Subsectors.Cast<Subsector>().Sum(sub => sub.WorldCount);

        public Sector(string name, Subsector[,] subsectors)
        {
            this.Name = name;
            this.Subsectors = subsectors;
        }

        public List<string> GetSubsectorNames()
        {
            return Subsectors.OfType<Subsector>().Select(subsector => subsector.Name).ToList();
        }

    }
}