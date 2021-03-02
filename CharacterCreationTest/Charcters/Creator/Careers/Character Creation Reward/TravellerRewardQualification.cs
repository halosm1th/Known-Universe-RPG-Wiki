namespace TravellerWiki.Data
{
    public class TravellerRewardQualification : TravellerCharacterCreationReward
    {
        public int IncreaseAmount { get; }

        public TravellerRewardQualification(int amount)
        {
            IncreaseAmount = amount;
        }
    }
}