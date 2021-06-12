using System.Collections.Generic;
using TravellerWiki.Data.CharacterCreation;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.Services.CareerService;

namespace TravellerWiki.Data.Services
{
    public class TravellerComplexCharacterGeneratorService
    {
        private ComplexCharacterGenerator _generator = new ComplexCharacterGenerator();

        public ComplexTravellerNPC GetCharacter()
        {
            return _generator.GenerateCharacterAndStory();
        }

        public List<ComplexTravellerNPC> GetCharacters(int count, TravellerNationalities nation, string name, int age, bool usePsi)
        {
            return  _generator.GenerateCharacters(count,nation,age, name, usePsi);
            
        }
    }
}
