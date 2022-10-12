using System;

namespace Traveller_Politics_Game
{
    class PoliticsGameConsole
    {
        public static void Main()
        {
            var game = new PoliticsGame();
            
            game.PlayGame();
        }
    }

    record Location(int SubsectorX, int SubsectorY, int ParsecX, int ParsecY)
    {
        public override string ToString()
        {
            return $"{SubsectorX},{SubsectorY}:{ParsecX},{ParsecY}";
        }
    }

    record Capital(int Credits, int Food, int Production, int Population, int Fuel);
}