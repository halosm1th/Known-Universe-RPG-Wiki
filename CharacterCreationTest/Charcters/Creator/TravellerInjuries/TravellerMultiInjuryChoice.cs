using System;
using System.Collections.Generic;

namespace TravellerWiki.Data.TravellerInjuries
{
    public class TravellerMultiInjuryChoice : TravellerMultiInjury
    {
        public TravellerMultiInjuryChoice(string description, List<TravellerInjury> injuries) : base(description, injuries)
        {
        }

        public TravellerInjury GetInjury(int roll)
        {
            if (roll >= Injuries.Count) throw new ArgumentOutOfRangeException("Error, roll was outside of injury range");
            return Injuries[roll];
        }
    }
}