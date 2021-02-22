namespace TravellerWiki.Data
{
    public class TravellerCharacterCreationBenefitIncreaseReward : TravellerCharacterCreationReward
    {
        public int BenefitIncreaseAmount { get; }

        public TravellerCharacterCreationBenefitIncreaseReward(int benefitIncreaseAmount)
        {
            BenefitIncreaseAmount = benefitIncreaseAmount;
        }

        public override string ToString()
        {
            return $"Increase to 1 benefit roll by {BenefitIncreaseAmount}";
        }
    }
}