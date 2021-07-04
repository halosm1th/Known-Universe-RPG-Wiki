namespace TravellerWiki.Data
{
    public class TravellerRewardDebt : TravellerCharacterCreationReward
    {
        public int Amount { get; }

        public TravellerRewardDebt(int credits)
        {
            Amount = credits;
        }

        public override string ToString()
        {
            return $"Cr-{Amount}";
        }
    }

    public class TravellerRewardCredits : TravellerCharacterCreationReward
    {
        public int Amount { get; }

        public TravellerRewardCredits(int credits)
        {
            Amount = credits;
        }

        public override string ToString()
        {
            return $"Cr{Amount}";
        }
    }
}