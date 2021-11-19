namespace TravellerCharacter.CharacterCreator.TravellerInjuries
{
    public class TravellerInjury
    {
        public string InjuryDescription { get; }
        public int InjuryDamage { get; }

        public TravellerInjury(string description, int damage)
        {
            InjuryDamage = damage;
            InjuryDescription = description;
        }
    }
}