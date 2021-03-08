using System.Collections.Generic;

namespace TravellerWiki.Data.TravellerInjuries
{
    public class TravellerMultiInjury : TravellerInjury
    {
        public List<TravellerInjury> Injuries { get; }

        public TravellerMultiInjury(string description, List<TravellerInjury> injuries) : base(description,0)
        {
            Injuries = injuries;
        }
    }
}