using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerWiki.Data.Charcters;
using CharacterCreatorService = TravellerWiki.Data.CharacterCreation.CharacterCreatorService;

namespace TravellerWiki.Data.Services
{
    public class TravellerCharacterStorageService
    {
        public static Dictionary<string, PlayerTravellerCharacter> CharacterList = new Dictionary<string, PlayerTravellerCharacter>();
        public static Random random = new Random();

        public void AddCharacter(string ID, PlayerTravellerCharacter character)
        {
            CharacterList.Add(ID, character);
        }

        public bool ContainsKey(string key) => CharacterList.ContainsKey(key);

        public string GenerateKey()
        {
            Random r = new Random();
            var key = r.Next().ToString();
            if (ContainsKey(key))
            {
                return GenerateKey();
            }

            return key;
        }
    

        public PlayerTravellerCharacter GetCharacter(string requestedKey)
        {
            foreach (var person in CharacterList)
            {
                if (person.Key == requestedKey)
                {
                    return person.Value;
                }
            }
            return CharacterList.First(x => x.Key == requestedKey).Value;
        }

        public Dictionary<string, PlayerTravellerCharacter> GetCharacters => CharacterList;
    }
}
