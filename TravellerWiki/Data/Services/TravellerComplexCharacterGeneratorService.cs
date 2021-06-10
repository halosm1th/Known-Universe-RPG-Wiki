using System.Collections.Generic;
using TravellerWiki.Data.CharacterCreation;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data.Services
{
    public class TravellerComplexCharacterGeneratorService
    {
        private ComplexCharacterGenerator _generator = new ComplexCharacterGenerator();

        public (TravellerCharacter character, string creationStory) GetCharacter()
        {
            return _generator.GenerateCharacterAndStory();
        }

        public Dictionary<TravellerCharacter, string> GetCharacters(int count)
        {
            var dict = new Dictionary<TravellerCharacter,string>();
            var characters = _generator.GenerateCharacters(count);
            foreach (var gen in characters)
            {
                dict.Add(gen.character, gen.creationStory);
            }

            return dict;
        }
    }
}
