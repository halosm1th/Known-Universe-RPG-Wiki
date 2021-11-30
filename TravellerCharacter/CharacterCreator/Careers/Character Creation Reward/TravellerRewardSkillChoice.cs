using System.Collections.Generic;
using System.Linq;
using TravellerCharacter.CharacterParts;

namespace TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward
{
    public class TravellerRewardSkillChoice : TravellerCharacterCreationReward
    {
        public TravellerRewardSkillChoice(int pickCount, List<TravellerSkills> skillList)
        {
            SkillList = new List<TravellerSkill>();
            foreach (var skill in skillList) SkillList.Add(new TravellerSkill(skill));
            PickCount = pickCount;
        }

        public TravellerRewardSkillChoice(int pickCount, List<TravellerSkill> skillList)
        {
            SkillList = skillList;
            PickCount = pickCount;
        }

        public List<TravellerSkill> SkillList { get; }
        public int PickCount { get; set; }

        public void ChoseOne()
        {
            PickCount--;
        }

        protected void AddSkills(List<TravellerSkills> skilllist)
        {
            foreach (var skill in skilllist) SkillList.Add(new TravellerSkill(skill));
        }

        public override string ToString()
        {
            return $"Pick {PickCount} from: [{SkillList.Aggregate("", (next, s) => next + s + ",")}]";
        }
    }
}