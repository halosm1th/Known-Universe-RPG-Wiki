﻿namespace TravellerCharacter.CharacterCreator.CreationEvents
{
    public class TravellerEventInjuryAndMore : TravellerEventInjury
    {
        public TravellerEventInjuryAndMore(string eventText, TravellerEventCharacterCreation followupEvent) :
            base(eventText)
        {
            FollowupEvent = followupEvent;
        }

        public TravellerEventCharacterCreation FollowupEvent { get; }

        public override string ToString()
        {
            return $"{base.ToString()}. [{FollowupEvent}]";
        }
    }
}