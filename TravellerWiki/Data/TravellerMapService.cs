using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TravellerUniverse;

namespace TravellerWiki.Data
{
    public class TravellerMapService
    {
        public Sector Islands_Sector { get; set; }

        public TravellerMapService()
        {
            Islands_Sector = new Sector("North Western Islands", LoadIslandsSubsectors());
        }

        private Subsector[,] LoadIslandsSubsectors()
        {
            var subsectors = new Subsector[2,2];
            subsectors[0, 0] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/Kendrick.json"));
            subsectors[0, 1] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/Wynona.json"));
            subsectors[0, 2] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/Olivehurst.json"));
            subsectors[0, 3] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/Payette.json"));

            subsectors[1, 0] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/OrenWastes1.json"));
            subsectors[1, 1] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/OrenWastes2.json"));
            subsectors[1, 2] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/OrenWastes3.json"));
            subsectors[1, 3] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/OrenWastes4.json"));

            subsectors[2, 0] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/Doland.json"));
            subsectors[2, 1] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/NewIslands.json"));
            subsectors[2, 2] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/OldIslands.json"));
            subsectors[2, 3] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/Stacyville.json"));

            subsectors[3, 0] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/Intercourse.json"));
            subsectors[3, 1] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/Citra.json"));
            subsectors[3, 2] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/Wallwern.json"));
            subsectors[3, 3] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/Zaleski.json"));


            return subsectors;
        }

        public Subsector GetSubsector(int x, int y)
        {
            return Islands_Sector.Subsectors[x, y];
        }
    }
}
