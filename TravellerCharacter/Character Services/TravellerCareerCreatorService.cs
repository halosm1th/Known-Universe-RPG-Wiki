using System.Collections.Generic;
using TravellerCharacter.CharacterCreator;
using TravellerCharacter.CharacterCreator.Careers;
using TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward;
using TravellerCharacter.CharacterCreator.Careers.SkillEntry;
using TravellerCharacter.CharcterTypes;

namespace TravellerCharacter.Character_Services
{
    public class TravellerCareerCreatorService
    {
        public List<(string title, TravellerCharacterCreationReward perk)> AssignmentRanks = new();

        public List<TravellerSkillTableEntry> AssignmentSkillTable = new();
        public bool HasAttribute = false;

        public TravellerAttributeCheck Qualification = null;

        public List<TravellerAttributeCheck> QualificationChecks { get; set; }
        public TravellerAttributeCheck AttributeToCheck { get; set; }

        public string AssignmentName { get; set; }
        public string AssignmentDescription { get; set; }

        public List<TravellerAttributeCheck> AssignmentSurvival { get; set; } = new();
        public List<TravellerAttributeCheck> AssignmentAdvancement { get; set; } = new();
        public List<TravellerAssignment> Assignments { get; set; }

        public string CareerName { get; set; }
        public string CareerDescription { get; set; }
        public TravellerNationalities Nationality { get; set; }
    }
}