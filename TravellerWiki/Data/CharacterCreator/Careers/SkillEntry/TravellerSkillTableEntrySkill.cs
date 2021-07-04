using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public class TravellerSkillTableEntrySkill : TravellerSkillTableEntry
    {
        public TravellerSkills Skill { get; }

        public TravellerSkillTableEntrySkill(TravellerSkills skill) : base(skill.ToString())
        {
            Skill = skill;
        }

        public override string ToString()
        {
            return $"{Skill}";
        }
    }
}