namespace TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward
{
    public class TravellerRewardDebt : TravellerCharacterCreationReward
    {
        public TravellerRewardDebt(int credits)
        {
            Amount = credits;
        }

        public int Amount { get; }

        public override string ToString()
        {
            return $"Cr-{Amount}";
        }
    }

    public class TravellerRewardCredits : TravellerCharacterCreationReward
    {
        public TravellerRewardCredits(int credits)
        {
            Amount = credits;
        }

        public int Amount { get; }

        public override string ToString()
        {
            return $"Cr{Amount}";
        }
    }
}