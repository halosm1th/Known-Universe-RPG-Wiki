using System;
using System.Collections.Generic;

namespace TravellerWiki.Data.TravellerInjuries
{
    public class TravellerMultiInjuryChoice : TravellerMultiInjury
    {
        public int InjuryCount => Injuries.Count;

        public TravellerMultiInjuryChoice(string description, List<TravellerInjury> injuries) : base(description, injuries)
        {
        }

        public TravellerInjury GetInjury(int choice)
        {
            if (choice >= Injuries.Count) throw new ArgumentOutOfRangeException("Error, roll was outside of injury range");
            return Injuries[choice];
        }
    }
}