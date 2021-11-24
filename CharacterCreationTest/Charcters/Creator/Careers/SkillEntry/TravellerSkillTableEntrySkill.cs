using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public class TravellerSkillTableEntrySkill : TravellerSkillTableEntry
    {
        public TravellerSkills Skill { get; }

        public TravellerSkillTableEntrySkill(TravellerSkills skill)
        {
            Skill = skill;
            Name = Skill.ToString();
        }

        public override string ToString()
        {
            return $"{Skill}";
        }
    }
}