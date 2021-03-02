using System.Collections.Generic;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public class TravellerRewardSkillChoice : TravellerCharacterCreationReward
    {
        public List<TravellerSkill> SkillList { get; }
        public int PickCount { get; }

        public TravellerRewardSkillChoice(int pickCount, List<TravellerSkill> skillList)
        {
            SkillList = skillList;
            PickCount = pickCount;
        }
        public TravellerRewardSkillChoice(int pickCount, List<TravellerSkills> skillList)
        {
            var SkillList = new List<TravellerSkill>();
            foreach (var skill in skillList)
            {
                SkillList.Add(new TravellerSkill(skill));
            }
            PickCount = pickCount;
        }
    }
}