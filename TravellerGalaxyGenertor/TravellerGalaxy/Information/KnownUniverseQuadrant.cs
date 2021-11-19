using System.IO;
using TravellerMapSystem;

namespace TravellerMapSystem
{
    class KnownUniverseQuadrant
    {
        private KnownUniverseMegaSector[,] megaSectors;
        private readonly int MEGA_X_SIZE = 8;
        private readonly int MEGA_Y_SIZE = 8;


        public string Name;
        public KnownUniverseQuadrant(string name, int xSize, int ySize)
        {
            Name = name;
            megaSectors = new KnownUniverseMegaSector[ySize,xSize];
        }

        public void GenerateQuadrants(string path)
        {
            for (int y = 0; y < megaSectors.GetLength(0); y++)
            {
                for (int x = 0; x < megaSectors.GetLength(1); x++)
                {
                    var mega = new KnownUniverseMegaSector(KnownUniverseSubsector.GenerateName(), MEGA_X_SIZE, MEGA_Y_SIZE);
                    megaSectors[y, x] = mega;
                    mega.GenerateMegaSector(path);

                }
            }
        }
    }
}