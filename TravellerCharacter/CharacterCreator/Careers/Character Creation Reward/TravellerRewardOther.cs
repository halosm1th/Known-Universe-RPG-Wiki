namespace TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward
{
    public class TravellerRewardOther : TravellerCharacterCreationReward
    {
        public TravellerRewardOther(string rewardtext)
        {
            Rewardtext = rewardtext;
        }

        public string Rewardtext { get; }

        public override string ToString()
        {
            return $"Other Reward: {Rewardtext}";
        }
    }
}