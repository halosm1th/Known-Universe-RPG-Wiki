using System;
using System.Linq;
using CharacterCreationTest.CharacterCreation;

namespace CharacterCreationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var travellerCreator = new CharacterCreator();
            Console.WriteLine("Enter Traveller Name:");
            var name = Console.ReadLine();
            Console.Write("Do you want to include psi? (y/n): ");
            var result = Console.ReadKey().KeyChar;
            var usePsi = (result == 'y' || result == 'Y');
            var stats = travellerCreator.GenerateStats(usePsi);

            Console.WriteLine($"Your stats are: {stats.ToArray().ToString()}");
            Console.WriteLine("Strength: ");
            Console.ReadLine();
        }
    }
}
