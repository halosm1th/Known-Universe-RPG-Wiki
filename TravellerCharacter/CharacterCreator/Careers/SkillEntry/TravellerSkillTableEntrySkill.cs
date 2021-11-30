using TravellerCharacter.CharacterParts;

namespace TravellerCharacter.CharacterCreator.Careers.SkillEntry
{
    public class TravellerSkillTableEntrySkill : TravellerSkillTableEntry
    {
        public TravellerSkillTableEntrySkill(TravellerSkills skill) : base(skill.ToString())
        {
            Skill = skill;
        }

        public TravellerSkills Skill { get; }

        public override string ToString()
        {
            return $"{Skill}";
        }
    }
}