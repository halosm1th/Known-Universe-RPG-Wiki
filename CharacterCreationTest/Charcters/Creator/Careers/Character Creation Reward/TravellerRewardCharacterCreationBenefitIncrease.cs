namespace TravellerWiki.Data
{
    public class TravellerRewardCharacterCreationBenefitIncrease : TravellerCharacterCreationReward
    {
        public int BenefitIncreaseAmount { get; }

        public TravellerRewardCharacterCreationBenefitIncrease(int benefitIncreaseAmount)
        {
            BenefitIncreaseAmount = benefitIncreaseAmount;
        }

        public override string ToString()
        {
            return $"Increase to 1 benefit roll by {BenefitIncreaseAmount}";
        }
    }
}