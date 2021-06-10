using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharacterCreationTest.CharacterCreation;
using CharacterCreatorService = TravellerWiki.Data.CharacterCreation.CharacterCreatorService;

namespace TravellerWiki.Data.Services
{
    public class MultiPageCharacterCreationService
    {
        public static Dictionary<string, CharacterCreatorService> CharacterCreationServices = new Dictionary<string, CharacterCreatorService>();
        public static Random random = new Random();
        public CharacterCreatorService GetCharacterCreatorService(string characterID) => CharacterCreationServices[characterID];

        public string CreateNewCreator()
        {
            var key = random.Next().ToString();
            if (CharacterCreationServices.ContainsKey(key)) return CreateNewCreator();

            CharacterCreationServices[key] = new CharacterCreatorService();
            return key;
        }

    }
}
