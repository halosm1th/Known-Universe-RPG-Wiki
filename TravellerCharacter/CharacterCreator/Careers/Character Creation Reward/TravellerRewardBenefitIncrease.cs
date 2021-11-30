namespace TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward
{
    public class TravellerRewardBenefitIncrease : TravellerCharacterCreationReward
    {
        public TravellerRewardBenefitIncrease(int benefitIncreaseAmount)
        {
            BenefitIncreaseAmount = benefitIncreaseAmount;
        }

        public int BenefitIncreaseAmount { get; }

        public override string ToString()
        {
            return $"Increase to 1 benefit roll by {BenefitIncreaseAmount}";
        }
    }
}