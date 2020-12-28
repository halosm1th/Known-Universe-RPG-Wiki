using System.Collections.Generic;

namespace TravellerWiki.Data
{
    public class TravellerCharacterCreationEventJSON
    {
        public string EventText { get; set; }

        public List<TravellerCharacterCreationEventSkillChoice> EventSkillChoices { get; set; }

        public TravellerCharacterCreationRewardJSON Reward { get; set; }

        public TravellerCharacterCreationEvent GetEvent()
        {
            if (EventSkillChoices != null)
            {
                return new TravellerCharacterCreationEvent(EventText,EventSkillChoices,Reward.GetReward());
            }

            return new TravellerCharacterCreationEvent(EventText);
            
        }
    }
}