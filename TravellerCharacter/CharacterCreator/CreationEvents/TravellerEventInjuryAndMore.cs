namespace TravellerCharacter.CharacterCreator.CreationEvents
{
    public class TravellerEventInjuryAndMore : TravellerEventInjury
    {
        public TravellerEventCharacterCreation FollowupEvent { get; }
        public TravellerEventInjuryAndMore(string eventText, TravellerEventCharacterCreation followupEvent) : base(eventText)
        {
            FollowupEvent = followupEvent;
        }

        public override string ToString()
        {
            return $"{base.ToString()}. [{FollowupEvent}]";
        }
    }
}