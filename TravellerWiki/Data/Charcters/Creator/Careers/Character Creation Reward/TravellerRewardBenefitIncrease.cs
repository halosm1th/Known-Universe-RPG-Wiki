namespace TravellerWiki.Data
{
    public class TravellerRewardBenefitIncrease : TravellerCharacterCreationReward
    {
        public int BenefitIncreaseAmount { get; }

        public TravellerRewardBenefitIncrease(int benefitIncreaseAmount)
        {
            BenefitIncreaseAmount = benefitIncreaseAmount;
        }

        public override string ToString()
        {
            return $"Increase to 1 benefit roll by {BenefitIncreaseAmount}";
        }
    }
}