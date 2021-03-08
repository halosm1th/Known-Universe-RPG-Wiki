using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data.Services.CareerService
{
    class TravellerCareerServiceCareer
    {
        public TravellerSkillTableEntry GetSkillTableEntry(TravellerSkills skill)
        {
            return new TravellerSkillTableEntrySkill(skill);
        }
        public TravellerSkillTableEntry GetSkillTableEntry(TravellerAttributes attribute)
        {
            return new TravellerSkillTableEntryAttribute(attribute);
        }

        public static TravellerSkillTableEntry GetSkillTableEntryStatic(TravellerSkills skill)
        {
            return new TravellerSkillTableEntrySkill(skill);
        }
        public static TravellerSkillTableEntry GetSkillTableEntryStatic(TravellerAttributes attribute)
        {
            return new TravellerSkillTableEntryAttribute(attribute);
        }
    }
}