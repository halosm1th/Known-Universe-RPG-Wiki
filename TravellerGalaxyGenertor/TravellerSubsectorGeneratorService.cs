using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TravellerMapSystem;
using TravellerMapSystem.Worlds;

namespace TravellerGalaxyGenertor
{
    public class TravellerSubsectorGeneratorService
    {
        private static Dictionary<string, KnownUniverseSubsector> Subsectors { get; set; }

        public TravellerSubsectorGeneratorService()
        {
            if(Subsectors == null) Subsectors = new Dictionary<string, KnownUniverseSubsector>();
        }

        public Bitmap GenerateSubSectorImage(string id)
        {
            return Subsectors[id].GenerateSubSectorImage();
        }

        public string GenerateSubsector(string name, int denisity, int minSize = 1, int maxSize = 6)
        {
            var subsector = new KnownUniverseSubsector(name);
            subsector.GenerateSubsector(denisity,minSize,maxSize);

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

        public string AddSubsector(KnownUniverseSubsector sub)
        {
            var id = (sub.Name.Aggregate(0, (h, t) => h + t) + (int) sub.WorldCount).ToString();
            Subsectors.Add(id,sub);

            return id;
        }
    }
}