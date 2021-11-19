using TravellerCharacter.CharacterParts;
using TravellerWiki.Data;

namespace TravellerCharacter.CharacterCreator.Careers.SkillEntry
{
    public class TravellerSkillTableEntryAttribute : TravellerSkillTableEntry
    {

        public TravellerAttributes Attribute { get; }

        public TravellerSkillTableEntryAttribute(TravellerAttributes attribute) 
            : base(attribute.ToString())
        {
            Attribute = attribute;
        }

        public override string ToString()
        {
            return $"{Attribute}";
        }
    }
}