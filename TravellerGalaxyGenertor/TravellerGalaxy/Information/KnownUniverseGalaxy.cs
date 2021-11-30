namespace TravellerMapSystem
{
    internal class KnownUniverseGalaxy
    {
        public readonly int QUADRANT_SIZE = 3;
        public string Name;
        private readonly KnownUniverseQuadrant[,] quadrants;

        public KnownUniverseGalaxy(string name)
        {
            Name = name;
            quadrants = new KnownUniverseQuadrant[2, 2];
        }

        private string QuadrantName(int x, int y)
        {
            if (y == 1)
            {
                if (x == 0)
                    return "Alpha Quadrant";
                return "Beta Quadrant";
            }

            if (x == 0)
                return "Gamma Quadrant";

            return "Delta Quadrant";
        }

        public void GenerateGalaxy(string path)
        {
            for (var y = 0; y < quadrants.GetLength(0); y++)
            for (var x = 0; x < quadrants.GetLength(1); x++)
            {
                var qua = new KnownUniverseQuadrant(QuadrantName(x, y), QUADRANT_SIZE, QUADRANT_SIZE);
                quadrants[y, x] = qua;
                qua.GenerateQuadrants(path);
            }
        }
    }
}