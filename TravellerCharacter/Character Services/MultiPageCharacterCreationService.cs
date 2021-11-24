using System;
using System.Collections.Generic;
using CharacterCreatorService = TravellerCharacter.CharacterCreator.CharacterCreation.CharacterCreatorService;

namespace TravellerCharacter.Character_Services
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
