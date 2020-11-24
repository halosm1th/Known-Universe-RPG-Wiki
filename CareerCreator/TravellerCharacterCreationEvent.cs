using System.Collections.Generic;

namespace TravellerWiki.Data
{
    public abstract class TravellerCharacterCreationEvent
    {
        public string EventText { get; protected set; }
        public TravellerCharacterCreationEvent(string eventText)
        {
            EventText = eventText;
        }
    }

    public abstract class TravellerCharaceterCreationEventSkillCheck : TravellerCharacterCreationEvent
    {
        public TravellerSkillCheck SkillCheck { get; }
        public TravellerCharacterCreationReward OnSuccess { get; }
        public TravellerCharacterCreationReward OnFailure { get; }

        public TravellerCharaceterCreationEventSkillCheck(string eventText, TravellerSkillCheck skillCheck, TravellerCharacterCreationReward onSuccess, TravellerCharacterCreationReward onFailure) : base(eventText)
        {
            SkillCheck = skillCheck;
            OnSuccess = onSuccess;
            OnFailure = onFailure;
        }
    }

    public class TravellerCharacterCreationEmptyEvent : TravellerCharacterCreationEvent
    {
        public TravellerCharacterCreationEmptyEvent() : base("Empty Event")
        {
        }
    }

    public class TravellerCharacterCreationTextEvent : TravellerCharacterCreationEvent
    {
        public TravellerCharacterCreationTextEvent(string eventText) : base(eventText)
        {
        }
    }

    public class TravellerCharacterCreationTextEventWithSkillCheck : TravellerCharaceterCreationEventSkillCheck
    {
        public TravellerCharacterCreationTextEventWithSkillCheck(string eventText, TravellerSkillCheck skillCheck, TravellerCharacterCreationReward onSuccess, TravellerCharacterCreationReward onFailure) : base(eventText, skillCheck, onSuccess, onFailure)
        {
        }
    }

    public class TravellerCharacterCreationTextEventWithReward : TravellerCharacterCreationEvent
    {

        public TravellerCharacterCreationReward Reward { get; }
        public TravellerCharacterCreationTextEventWithReward(string eventText, TravellerCharacterCreationReward reward) : base(eventText)
        {
            Reward = reward;
        }
    }
}