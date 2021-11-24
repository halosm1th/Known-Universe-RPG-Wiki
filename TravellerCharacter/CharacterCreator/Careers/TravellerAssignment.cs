using System.Collections.Generic;
using TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward;
using TravellerCharacter.CharacterCreator.Careers.SkillEntry;
using TravellerWiki.Data;

namespace TravellerCharacter.CharacterCreator.Careers
{
    public class TravellerAssignment
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TravellerAttributeCheck Survival { get; set; }
        public TravellerAttributeCheck Advancement { get; set; }

        public List<TravellerSkillTableEntry> SkillList { get; set; }
        public List<(string title, TravellerCharacterCreationReward TravellerCharacterCreationReward)> RanksAndBonuses { get; set; }

        public TravellerAssignment(string name, string description, TravellerAttributeCheck survival, TravellerAttributeCheck advancement, List<TravellerSkillTableEntry> skillList, List<(string title, TravellerCharacterCreationReward perk)> ranksAndBonuses)
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