using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using CharacterCreationTest.CharacterCreation;
using TravellerWiki.Data;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.CreationEvents;
using TravellerWiki.Data.TravellerInjuries;

namespace CharacterCreationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Generate how many characters?");
            var input = Console.ReadLine();
            int number = 1;
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine($"Error with input: {input}, going with default of 1");
                number = 1;
            }

            if (!Directory.GetCurrentDirectory().Contains("/Characters"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Characters");
            }

            ComplexCharacterGenerator generator;

            for(int i=0; i < number; i++) { 
                //Console.Clear();
                generator = new ComplexCharacterGenerator();
                var character  = generator.GenerateCharacterAndStory();

                Console.WriteLine(character.creationStory);
                File.WriteAllText(Directory.GetCurrentDirectory() + $"/Characters/{character.character.Name}.char", character.creationStory);
                
                Console.WriteLine($"\n\nPress enter to clear screen and generate the next character [{i}/{number}]");
                //Console.ReadLine();

            }

            Console.WriteLine("Press any key to exit");

            Console.ReadKey();
        }

        #region career

        #endregion
        #region background skills

        #endregion
        #region nationality

        #endregion
        #region basic setup

        #endregion
    }
}
