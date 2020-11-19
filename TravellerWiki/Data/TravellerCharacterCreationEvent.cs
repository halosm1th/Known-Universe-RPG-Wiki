using System.Collections.Generic;
using System.Text;

namespace TravellerWiki.Data
{

    public class TravellerCharacterCreationEventJSON
    {
        public string EventText { get; set; }
        public TravellerSkillCheck SkillCheck { get; set; }
        public TravellerCharacterCreationRewardJSON OnSuccess { get; set; }
        public TravellerCharacterCreationRewardJSON OnFailure { get; set; }
        public TravellerCharacterCreationRewardJSON Reward { get; set; }
        public TravellerCharacterCreationEventJSON(string eventText)
        {
            EventText = eventText;
        }

        public TravellerCharacterCreationEvent GetEvent()
        {
            TravellerCharacterCreationEvent travellerEvent;

            if (SkillCheck != null)
            {
                travellerEvent = 
                    new TravellerCharacterCreationTextEventWithSkillCheck(
                        EventText,SkillCheck,OnSuccess.GetReward(),OnFailure.GetReward());
            }
            else if (Reward != null)
            {
                travellerEvent =
                    new TravellerCharacterCreationTextEventWithReward(
                        EventText, Reward.GetReward());
            }
            else
            {
                travellerEvent = new TravellerCharacterCreationTextEvent(EventText);
            }

            return travellerEvent;
        }
    }

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
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(EventText);
            sb.Append(". With a skill check: ");
            sb.Append(SkillCheck.ToString());
            if (OnSuccess != null)
            {
                sb.Append("On Success:");
                sb.Append(OnSuccess.ToString());
            }
            if (OnFailure != null)
            {
                sb.Append("On Failure:");
                sb.Append(OnFailure.ToString());
            }
            return sb.ToString();
        }
    }

    public class TravellerCharacterCreationEmptyEvent : TravellerCharacterCreationEvent
    {
        public TravellerCharacterCreationEmptyEvent() : base("Empty Event")
        {
        }
        public override string ToString()
        {
            return $"{EventText}";
        }
    }

    public class TravellerCharacterCreationTextEvent : TravellerCharacterCreationEvent
    {
        public TravellerCharacterCreationTextEvent(string eventText) : base(eventText)
        {
        }
        public override string ToString()
        {
            return $"{EventText}";
        }
    }

    public class TravellerCharacterCreationTextEventWithSkillCheck : TravellerCharaceterCreationEventSkillCheck
    {
        public TravellerCharacterCreationTextEventWithSkillCheck(string eventText, TravellerSkillCheck skillCheck,
            TravellerCharacterCreationReward onSuccess, TravellerCharacterCreationReward onFailure) : base(eventText,
            skillCheck, onSuccess, onFailure)
        {
        }

        public override string ToString()
        {
            return $"{EventText}";
        }
    }

    public class TravellerCharacterCreationTextEventWithReward : TravellerCharacterCreationEvent
    {

        public TravellerCharacterCreationReward Reward { get; }
        public TravellerCharacterCreationTextEventWithReward(string eventText, TravellerCharacterCreationReward reward) : base(eventText)
        {
            Reward = reward;
        }

        public override string ToString()
        {
            return $"{EventText}. You get: {Reward} as a reward";
        }
    }
}