namespace TravellerWiki.Data
{
    public class TravellerRewardOther : TravellerCharacterCreationReward
    {
        public string Rewardtext { get; }

        public TravellerRewardOther(string rewardtext)
        {
            Rewardtext = rewardtext;
        }

        public override string ToString()
        {
            return $"Other Reward: {Rewardtext}";
        }
    }
}