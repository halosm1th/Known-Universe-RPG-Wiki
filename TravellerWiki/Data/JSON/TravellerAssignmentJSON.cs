using System.Collections.Generic;
using System.Linq;

namespace TravellerWiki.Data
{
    public class TravellerAssignmentJSON
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TravellerSkillCheck Survival { get; set; }
        public TravellerSkillCheck Advancement { get; set; }

        public List<string> SkillList { get; set; }
        public List<(string title, TravellerCharacterCreationRewardJSON TravellerCharacterCreationReward)> RanksAndBonuses { get; set; }

        public TravellerAssignmentJSON(string name, string description, TravellerSkillCheck survival, TravellerSkillCheck advancement, List<string> skillList, List<(string title, TravellerCharacterCreationRewardJSON perk)> ranksAndBonuses)
        {
            Name = name;
            Description = description;
            Survival = survival;
            Advancement = advancement;
            SkillList = skillList;
            RanksAndBonuses = ranksAndBonuses;
        }

        public TravellerAssignment ConvertToAssignment()
        {
            var name = Name;
            var desc = Description;
            var sur = Survival;
            var adv = Advancement;
            var skl = SkillList;
            var rab = RanksAndBonuses.Select(x => (x.title ?? "", x.TravellerCharacterCreationReward.GetReward())).ToList();
            return new TravellerAssignment(name,desc,sur,adv,skl,rab);
        }
    }
}