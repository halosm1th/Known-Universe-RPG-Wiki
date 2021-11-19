using System;
using TravellerCharacter.CharacterCreator.TravellerInjuries;

namespace TravellerCharacter.CharacterCreator.CreationEvents
{
    public class TravellerEventSeverelyInjured : TravellerEventInjury
    {
        public TravellerEventSeverelyInjured(string eventText) : base(eventText)
        {
        }

        public TravellerInjury GetSevereInjury(int roll1, int roll2) => GetInjury(Math.Min(roll1, roll2));

        public override string ToString()
        {
            return $"Severly Injured: {EventText}";
        }
    }
}