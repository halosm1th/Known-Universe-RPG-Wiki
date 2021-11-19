using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerCharacter.CharacterParts;

namespace TravellerWiki.Data
{
    public class TravellerWikiNation
    {
        public enum Relationship
        {
            Ally, Enemy, Neutral
        }

        public string Name { get; }
        

        public Dictionary<(string Name, string URL), Relationship> Relationships { get; set; }
        
        //World, Text
        public Dictionary<string,string> WorldsControlled { get; set; }
        
    }
}
