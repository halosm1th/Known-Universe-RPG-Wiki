using System;
using System.Collections.Generic;
using TravellerCharacter.CharacterCreator.TravellerInjuries;
using TravellerCharacter.CharacterParts;

namespace TravellerCharacter.CharacterCreator.CreationEvents
{
    public class TravellerEventInjury : TravellerEventCharacterCreation
    {
        public static Random random = new();

        public TravellerEventInjury(string eventText) : base(eventText)
        {
        }

        public TravellerInjury GetInjury(int roll)
        {
            return roll switch
            {
                1 => new TravellerMultiInjury("Nearly killed", new List<TravellerInjury>
                {
                    new("Major damage.", random.Next(1, 7)),
                    new("minor damage.", 1),
                    new("minor damage.", 1)
                }),
                2 => new TravellerInjury("Severely injured.", random.Next(0, 6)),
                3 => new TravellerMultiInjuryChoice("Missing eye or limb", new List<TravellerInjury>
                {
                    new TravellerInjurySpecific("Missing Eye", TravellerAttributes.Dexterity, 2),
                    new TravellerInjurySpecific("Missing Limb", TravellerAttributes.Strength, 2)
                }),
                4 => new TravellerInjury("Scarred", 2),
                5 => new TravellerInjury("Injured", 1),
                6 => new TravellerInjury("Lightly damaged, no permenant effect.", 0),
                _ => throw new ArgumentOutOfRangeException($"Error injury roll was outside allowed range (1-6):{roll}")
            };
        }

        public override string ToString()
        {
            return $"{base.ToString()}. You are Injured.";
        }
    }
}