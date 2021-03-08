namespace TravellerWiki.Data
{
    public class TravellerRewardBonusBenefit : TravellerCharacterCreationReward
    {
        public TravellerRewardBonusBenefit(int numberOfExtraRolls=1)
        {
            NumberOfExtraRolls = numberOfExtraRolls;
        }

        public int NumberOfExtraRolls { get; }
        public override string ToString()
        {
            return $"Get an extra {NumberOfExtraRolls} Benefit rolls";
        }
    }
}