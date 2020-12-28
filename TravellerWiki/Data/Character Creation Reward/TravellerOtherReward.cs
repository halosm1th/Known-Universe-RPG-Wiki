namespace TravellerWiki.Data
{
    public class TravellerOtherReward : TravellerCharacterCreationReward
    {
        public string Rewardtext { get; }

        public TravellerOtherReward(string rewardtext)
        {
            Rewardtext = rewardtext;
        }

        public override string ToString()
        {
            return $"Other Reward: {Rewardtext}";
        }
    }
}