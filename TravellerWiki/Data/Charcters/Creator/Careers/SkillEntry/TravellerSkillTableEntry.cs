using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public abstract class TravellerSkillTableEntry
    {
        public string Name { get; set; }

        public TravellerSkillTableEntry(string name)
        {
            Name = name;
        }
    }
}