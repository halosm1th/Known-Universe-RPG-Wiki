namespace TravellerWiki.Data
{
    public class TravellerContactReward : TravellerCharacterCreationReward
    {
        public string ContactCount { get; }
        public string ContactType { get; }

        public TravellerContactReward(string contactCount, string contactType)
        {
            ContactCount = contactCount;
            ContactType = contactType;
        }

        public override string ToString()
        {
            return $"Gain {ContactCount} contacts of {ContactType}";
        }
    }
}