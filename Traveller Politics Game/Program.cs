using System;

namespace Traveller_Politics_Game
{
    class PoliticsGameConsole
    {
        public static void Main()
        {
            Console.WriteLine("Press any button to start the game");
            Console.ReadKey();
            
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

    record Capital(int Credits = 0, int Food = 0, int Production = 0, int Population = 0, int Fuel = 0)
    {
        public Capital(string[] items) : this()
        {
            var credText = items[0];
            var foodText = items[1];
            var prodText = items[2];
            var popText = items[3];
            var fuelText = items[4];

            if (!int.TryParse(credText, out var credits))
            {
                throw new ArgumentException("Error invalid number for credits");
            }

            if (!int.TryParse(foodText, out var food))
            {
                throw new ArgumentException("Error invalid number for credits");
            }

            if (!int.TryParse(prodText, out var prod))
            {
                throw new ArgumentException("Error invalid number for credits");
            }
            
            if (!int.TryParse(popText, out var pop))
            {
                throw new ArgumentException("Error invalid number for credits");
            }

            if (!int.TryParse(fuelText, out var fuel))
            {
                throw new ArgumentException("Error invalid number for credits");
            }
            
            Credits = credits;
            Food = food;
            Production = prod;
            Population = pop;
            Fuel = fuel;

        }
        
        public static Capital operator +(Capital a) => a;
        public static Capital operator -(Capital a) => new (
            -a.Credits, 
            -a.Food,
            -a.Production,
            -a.Population,
            -a.Fuel);

        public static Capital operator +(Capital a, Capital b)
            => new (a.Credits + b.Credits, 
                a.Food + b.Food,
                a.Production + b.Production,
                a.Population + b.Population,
                a.Fuel + b.Fuel);

        public static Capital operator -(Capital a, Capital b)
            => a + (-b);

        public static Capital operator *(Capital a, Capital b)
            => new (a.Credits * b.Credits,
                a.Food * b.Food,
                a.Production * b.Production,
                a.Population * b.Population,
                a.Fuel * b.Fuel);

        public static Capital operator /(Capital a, Capital b)
        {
            if (b.Credits == 0 || b.Food == 0 || b.Fuel == 0 || b.Population == 0 || b.Production == 0)
            {
                throw new DivideByZeroException();
            }
            return new (a.Credits / b.Credits, a.Food / b.Food,
                a.Production / b.Production,a.Population / b.Population,a.Fuel / b.Fuel);
        }
    }
}