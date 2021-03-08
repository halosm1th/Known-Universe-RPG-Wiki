using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data.TravellerInjuries
{
    public class TravellerInjurySpecific : TravellerInjury
    {
        public TravellerAttribute Damage { get; }

        public TravellerInjurySpecific(string description,TravellerAttributes attribute , int damage) : base(description, damage)
        {
            Damage = new TravellerAttribute(attribute,damage);
        }
    }
}