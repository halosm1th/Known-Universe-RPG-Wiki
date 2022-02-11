using TravellerFactionSystem.Location;

namespace TravellerMapSystem
{
    internal class KnownUniverseMegaSector : TravellerLocation
    {
        public string Name;
        private readonly KnownUniverseSuperSector[,] supersectors;

        public KnownUniverseMegaSector(string name, int xSize, int ySize)
        {
            supersectors = new KnownUniverseSuperSector[ySize, xSize];
            Name = name;
            for (var y = 0; y < ySize; y++)
            for (var x = 0; x < xSize; x++)
            {
                var s = new KnownUniverseSuperSector(KnownUniverseSubsector.GenerateName(MapNameLists.Generic), x, y, 6,
                    6);
                supersectors[y, x] = s;
            }
        }

        public void GenerateMegaSector(string path)
        {
            foreach (var supers in supersectors) supers.GenerateSuperSector();
        }
    }
}