namespace TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward
{
    public class TravellerRewardQualification : TravellerCharacterCreationReward
    {
        public TravellerRewardQualification(int amount)
        {
            IncreaseAmount = amount;
        }

        public int IncreaseAmount { get; }

        public override string ToString()
        {
            return $"Increase your next qualification roll by: {IncreaseAmount}";
        }
    }
}