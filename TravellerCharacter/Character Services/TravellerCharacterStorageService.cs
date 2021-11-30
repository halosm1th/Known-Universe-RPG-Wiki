using System;
using System.Collections.Generic;
using System.Linq;
using TravellerCharacter.CharcterTypes;

namespace TravellerCharacter.Character_Services
{
    public class TravellerCharacterStorageService
    {
        public static Dictionary<string, PlayerTravellerCharacter> CharacterList = new();
        public static Random random = new();

        public Dictionary<string, PlayerTravellerCharacter> GetCharacters => CharacterList;

        public void AddCharacter(string ID, PlayerTravellerCharacter character)
        {
            if (CharacterList.ContainsKey(ID))
            {
                CharacterList.Remove(ID);
                CharacterList.Add(ID, character);
            }
            else
            {
                CharacterList.Add(ID, character);
            }
        }

        public bool ContainsKey(string key)
        {
            return CharacterList.ContainsKey(key);
        }

        public string GenerateKey()
        {
            var r = new Random();
            var key = r.Next().ToString();
            if (ContainsKey(key)) return GenerateKey();

            return key;
        }


        public PlayerTravellerCharacter GetCharacter(string requestedKey)
        {
            foreach (var person in CharacterList)
                if (person.Key == requestedKey)
                    return person.Value;
            return CharacterList.First(x => x.Key == requestedKey).Value;
        }
    }
}