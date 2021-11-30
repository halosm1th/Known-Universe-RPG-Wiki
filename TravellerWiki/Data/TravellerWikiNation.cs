using System.Collections.Generic;

namespace TravellerWiki.Data
{
    public class TravellerWikiNation
    {
        public enum Relationship
        {
            Ally,
            Enemy,
            Neutral
        }

        public string Name { get; }


        public Dictionary<(string Name, string URL), Relationship> Relationships { get; set; }

        //World, Text
        public Dictionary<string, string> WorldsControlled { get; set; }
    }
}