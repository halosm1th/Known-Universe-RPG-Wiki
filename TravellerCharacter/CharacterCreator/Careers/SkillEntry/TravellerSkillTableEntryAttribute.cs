using TravellerCharacter.CharacterParts;

namespace TravellerCharacter.CharacterCreator.Careers.SkillEntry
{
    public class TravellerSkillTableEntryAttribute : TravellerSkillTableEntry
    {
        public TravellerSkillTableEntryAttribute(TravellerAttributes attribute)
            : base(attribute.ToString())
        {
            Attribute = attribute;
        }

        public TravellerAttributes Attribute { get; }

        public override string ToString()
        {
            return $"{Attribute}";
        }
    }
}