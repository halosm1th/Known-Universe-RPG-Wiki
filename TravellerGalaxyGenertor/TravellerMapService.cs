using System.IO;
using Newtonsoft.Json;
using TravellerMapSystem;

namespace TravellerGalaxyGenertor
{
    public class TravellerMapService
    {
        public KnownUniverseSector Islands_Sector { get; set; }

        public TravellerMapService()
        {
            //Islands_Sector = new KnownUniverseSector("North Western Islands", LoadIslandsSubsectors());
          }

        private KnownUniverseSubsector[,] LoadIslandsSubsectors()
        {
            var subsectors = new KnownUniverseSubsector[4,4];
            //subsectors[0, 0] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/SubsectorJson/Kendrick.json"));
            //subsectors[0, 1] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/SubsectorJson/Wynona.json"));
            //subsectors[0, 2] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/SubsectorJson/Olivehurst.json"));
            //subsectors[0, 3] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/SubsectorJson/Payette.json"));

            //subsectors[1, 0] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/SubsectorJson/OrenWastes1.json"));
            //subsectors[1, 1] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/SubsectorJson/OrenWastes2.json"));
            subsectors[1, 2] = JsonConvert.DeserializeObject<KnownUniverseSubsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/SubsectorJson/OrenWastes3.json"));
            //subsectors[1, 3] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/SubsectorJson/OrenWastes4.json"));

            //subsectors[2, 0] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/SubsectorJson/Doland.json"));
            subsectors[2, 1] = JsonConvert.DeserializeObject<KnownUniverseSubsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/SubsectorJson/NewIslands.json"));
            subsectors[2, 2] = JsonConvert.DeserializeObject<KnownUniverseSubsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/SubsectorJson/OldIslands.json"));
            //subsectors[2, 3] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/SubsectorJson/Stacyville.json"));

            //subsectors[3, 0] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/SubsectorJson/Intercourse.json"));
            //subsectors[3, 1] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/SubsectorJson/Citra.json"));
            //subsectors[3, 2] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/SubsectorJson/Wallwern.json"));
            //subsectors[3, 3] = JsonConvert.DeserializeObject<Subsector>(File.ReadAllText(Directory.GetCurrentDirectory() + "/SubsectorJson/Zaleski.json"));


            return subsectors;
        }

        public KnownUniverseSubsector GetSubsector(int x, int y)
        {
            var subsector = Islands_Sector.Subsectors[x, y];
            return subsector;
        }
    }
}
