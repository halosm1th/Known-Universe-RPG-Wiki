using System;
using System.IO;
using System.Threading.Tasks;

namespace TravellerMapSystem
{
    class KnownUniverseMegaSector
    {
        public string Name;
        private KnownUniverseSuperSector[,] supersectors;

        public KnownUniverseMegaSector(string name, int xSize, int ySize)
        {
            supersectors = new KnownUniverseSuperSector[ySize, xSize];
            Name = name;
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    var s = new KnownUniverseSuperSector(KnownUniverseSubsector.GenerateName(),x,y,6,6);
                    supersectors[y, x] = s;
                }
            }
        }

        public void GenerateMegaSector(string path)
        {
            foreach (var supers in supersectors)
            {
                supers.GenerateSuperSector();
            }
        }
    }
}