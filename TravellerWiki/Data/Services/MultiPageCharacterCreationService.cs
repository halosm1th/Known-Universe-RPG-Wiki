using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var storage = new TravellerCharacterStorageService();
            var key = storage.GenerateKey();

            CharacterCreationServices[key] = new CharacterCreatorService();
            return key;
        }

    }
}
