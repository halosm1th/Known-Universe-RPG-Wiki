namespace TravellerCharacter.CharacterCreator.TravellerInjuries
{
    public class TravellerInjury
    {
        public TravellerInjury(string description, int damage)
        {
            InjuryDamage = damage;
            InjuryDescription = description;
        }

        public string InjuryDescription { get; }
        public int InjuryDamage { get; }
    }
}