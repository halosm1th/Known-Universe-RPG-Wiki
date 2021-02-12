using System.Collections.Generic;

namespace TravellerWiki.Data
{

    public class TravellerCharacterCreationEvent
    {
        public string EventText { get; set; }

        public List<TravellerCharacterCreationEventSkillChoice> EventSkillChoices { get; set; }

        public TravellerCharacterCreationReward Reward { get; set; }

        public TravellerCharacterCreationEvent()
        {
            EventText = "";
            EventSkillChoices = null;
            Reward = null;

        }

        public TravellerCharacterCreationEvent(string eventText)
        {
            EventText = eventText;
            EventSkillChoices = null;
            Reward = null;
        }

        public TravellerCharacterCreationEvent(string eventText, List<TravellerCharacterCreationEventSkillChoice> eventSkillChoices, TravellerCharacterCreationReward reward)
        {
            EventText = eventText;
            EventSkillChoices = eventSkillChoices;
            Reward = reward;
        }
    }

    public class TravellerCharacterCreationEventSkillChoice
    {
        public TravellerSkillCheck SkillCheck { get; }
        public string SkillCheckText { get; set; }
        public TravellerCharacterCreationReward OnSuccess { get; set; }
        public string OnSuccessText { get; set; }
        public TravellerCharacterCreationReward OnFailure { get; set; }
        public string OnFailureText { get; set; }

        public TravellerCharacterCreationEventSkillChoice(TravellerSkillCheck skillCheck, string skillCheckText, TravellerCharacterCreationReward onSuccess, string onSuccessText, TravellerCharacterCreationReward onFailure, string onFailureText)
        {
            SkillCheck = skillCheck;
            SkillCheckText = skillCheckText;
            OnSuccess = onSuccess;
            OnSuccessText = onSuccessText;
            OnFailure = onFailure;
            OnFailureText = onFailureText;
        }
    }
}