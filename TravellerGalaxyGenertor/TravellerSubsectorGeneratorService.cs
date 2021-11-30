using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using TravellerMapSystem;
using TravellerMapSystem.Worlds;

namespace TravellerGalaxyGenertor
{
    public class TravellerSubsectorGeneratorService
    {
        private static Dictionary<string, KnownUniverseSubsector> Subsectors { get; set; }

        public TravellerSubsectorGeneratorService()
        {
            if (Subsectors == null)
            {
                Subsectors = new Dictionary<string, KnownUniverseSubsector>();
                GetGeneratedSubsectors();
            }
            
        }

        public void GetGeneratedSubsectors()
        {
            var loc = Directory.GetCurrentDirectory() + "/Data/SubsectorJson/GeneratedSubsectors";
            var files = Directory.GetFiles(loc, "*.json").ToList();
            foreach (var file in files)
            {
                AddSubsector(File.ReadAllText(file));
            }
        }

        public Image GenerateSubSectorImage(string id)
        {
            return Subsectors[id].GenerateSubSectorImage();
        }

        public string GenerateSubsector(MapNameLists nameLists ,string name, int denisity, int minSize = 1, int maxSize = 6)
        {
            var subsector = new KnownUniverseSubsector(name);
            subsector.GenerateSubsector(nameLists, denisity,minSize,maxSize);

            return AddSubsector(subsector);
        }

        public static KnownUniverseSystem GetSystem(string subsectorID, int x, int y)
        {
            return Subsectors[subsectorID].GetSystem(x, y);
        }

        public KnownUniverseSubsector GetSubsector(string id)
        {
            return Subsectors[id];
        }
        
        public Dictionary<string, KnownUniverseSubsector> AllSubsectors()
        {
            if (Subsectors.Count > 0)
            {
                return Subsectors;
            }

            return new Dictionary<string, KnownUniverseSubsector>();
        }
        public string AddSubsector(KnownUniverseSubsector sub)
        {
            var id = (sub.Name.Aggregate(0, (h, t) => h + t) + (int) sub.WorldCount).ToString();
            Subsectors.Add(id,sub);

            return id;
        }

        public string AddSubsector(string json)
        {
            var sub = JsonConvert.DeserializeObject<KnownUniverseSubsector>(json,
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
            var id = (sub.Name.Aggregate(0, (h, t) => h + t) + (int) sub.WorldCount).ToString();
            
            Subsectors.Add(id,sub);

            return id;
        }
    }
}