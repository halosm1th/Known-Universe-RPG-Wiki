using System.Collections.Generic;
using TravellerCharacter.CharacterCreator.CharacterCreation;
using TravellerCharacter.CharcterTypes;

namespace TravellerCharacter.Character_Services.NPC_Services
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
