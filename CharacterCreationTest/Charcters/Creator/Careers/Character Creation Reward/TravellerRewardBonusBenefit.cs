namespace TravellerWiki.Data
{
    public class TravellerRewardBonusBenefit : TravellerCharacterCreationReward
    {
        public TravellerRewardBonusBenefit(int numberOfExtraRolls)
        {
            NumberOfExtraRolls = numberOfExtraRolls;
        }

        public int NumberOfExtraRolls { get; }
    }
}