using System.Collections.Generic;

namespace TravellerWiki.Data
{
    public class TravellerAssignment
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TravellerSkillCheck Survival { get; set; }
        public TravellerSkillCheck Advancement { get; set; }

        public List<string> SkillList { get; set; }
        public List<(string title, TravellerCharacterCreationReward TravellerCharacterCreationReward)> RanksAndBonuses { get; set; }

        public TravellerAssignment(string name, string description, TravellerSkillCheck survival, TravellerSkillCheck advancement, List<string> skillList, List<(string title, TravellerCharacterCreationReward perk)> ranksAndBonuses)
        {
            Name = name;
            Description = description;
            Survival = survival;
            Advancement = advancement;
            SkillList = skillList;
            RanksAndBonuses = ranksAndBonuses;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}