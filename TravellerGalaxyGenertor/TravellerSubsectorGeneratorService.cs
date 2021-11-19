using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TravellerMapSystem;

namespace TravellerGalaxyGenertor
{
    public class TravellerSubsectorGeneratorService
    {
        private static Dictionary<int, KnownUniverseSubsector> Subsectors { get; set; }

        public TravellerSubsectorGeneratorService()
        {
            if(Subsectors == null) Subsectors = new Dictionary<int, KnownUniverseSubsector>();
        }

        public Bitmap GenerateSubSectorImage(int id)
        {
            return Subsectors[id].GenerateSubSectorImage();
        }

        public int GenerateSubsector(string name, int denisity)
        {
            var subsector = new KnownUniverseSubsector(name);
            subsector.GenerateSubsector(denisity);

            return AddSubsector(subsector);
        }

        public KnownUniverseSubsector GetSubsector(int id)
        {
            return Subsectors[id];
        }

        public int AddSubsector(KnownUniverseSubsector sub)
        {
            var id = sub.Name.Aggregate(0, (h, t) => h + t) + (int) sub.WorldCount;
            Subsectors.Add(id,sub);

            return id;
        }
    }
}