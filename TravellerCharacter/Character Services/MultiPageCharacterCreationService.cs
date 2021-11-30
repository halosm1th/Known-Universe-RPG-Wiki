using System;
using System.Collections.Generic;
using TravellerCharacter.CharacterCreator.CharacterCreation;

namespace TravellerCharacter.Character_Services
{
    public class MultiPageCharacterCreationService
    {
        public static Dictionary<string, CharacterCreatorService> CharacterCreationServices = new();
        public static Random random = new();

        public CharacterCreatorService GetCharacterCreatorService(string characterID)
        {
            return CharacterCreationServices[characterID];
        }

        public string CreateNewCreator()
        {
            var storage = new TravellerCharacterStorageService();
            var key = storage.GenerateKey();

            CharacterCreationServices[key] = new CharacterCreatorService();
            return key;
        }
    }
}