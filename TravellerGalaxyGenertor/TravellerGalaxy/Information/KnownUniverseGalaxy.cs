using System;
using System.IO;

namespace TravellerMapSystem
{
    class KnownUniverseGalaxy
    {
        private KnownUniverseQuadrant[,] quadrants;
        public string Name;
        public readonly int QUADRANT_SIZE = 3;

        public KnownUniverseGalaxy(string name)
        {
            Name = name;
            quadrants = new KnownUniverseQuadrant[2,2];
        }

        private string QuadrantName(int x, int y)
        {
            if (y == 1)
            {
                if (x == 0)
                {
                    return "Alpha Quadrant";
                }
                else
                {
                    return "Beta Quadrant";
                }
            }
            else
            {
                if (x == 0)
                {
                    return "Gamma Quadrant";
                }

                else
                {
                    return "Delta Quadrant";
                }
            }
        }

        public void GenerateGalaxy(string path)
        {
            for (int y = 0; y < quadrants.GetLength(0); y++)
            {
                for (int x = 0; x < quadrants.GetLength(1); x++)
                {
                    var qua = new KnownUniverseQuadrant(QuadrantName(x, y), QUADRANT_SIZE, QUADRANT_SIZE);
                    quadrants[y, x] = qua;
                    qua.GenerateQuadrants(path);
                }
            }
        }
    }
}