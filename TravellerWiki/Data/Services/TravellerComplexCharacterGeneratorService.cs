﻿using System.Collections.Generic;
using TravellerWiki.Data.CharacterCreation;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data.Services
{
    public class TravellerComplexCharacterGeneratorService
    {
        private ComplexCharacterGenerator _generator = new ComplexCharacterGenerator();

        public (PlayerTravellerCharacter character, string creationStory) GetCharacter()
        {
            return _generator.GenerateCharacterAndStory();
        }

        public Dictionary<PlayerTravellerCharacter, string> GetCharacters(int count)
        {
            var dict = new Dictionary<PlayerTravellerCharacter, string>();
            var characters = _generator.GenerateCharacters(count);
            foreach (var gen in characters)
            {
                dict.Add(gen.character, gen.creationStory);
            }

            return dict;
        }
    }
}