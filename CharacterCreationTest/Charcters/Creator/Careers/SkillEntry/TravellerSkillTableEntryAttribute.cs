using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public class TravellerSkillTableEntryAttribute : TravellerSkillTableEntry
    {

        public TravellerAttributes Attribute { get; }

        public TravellerSkillTableEntryAttribute(TravellerAttributes attribute)
        {
            Attribute = attribute;
        }
    }
}