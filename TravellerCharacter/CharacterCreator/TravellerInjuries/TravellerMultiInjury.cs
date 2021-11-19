using System.Collections.Generic;

namespace TravellerCharacter.CharacterCreator.TravellerInjuries
{
    public class TravellerMultiInjury : TravellerInjury
    {
        public List<TravellerInjury> Injuries { get; }

        public TravellerMultiInjury(string description, List<TravellerInjury> injuries) : base(description,0)
        {
            Injuries = injuries;
        }

        /// <summary>
        /// When you've resolved an injury, remove it from the list
        /// </summary>
        /// <param name="inj">Injury to remove</param>
        public void ResolveInjury(TravellerInjury inj)
        {
            Injuries.Remove(inj);
        }
    }
}