namespace TravellerWiki.Data
{
    public class TravellerRewardAdvancement : TravellerCharacterCreationReward
    {
        public int AdvancementAmount { get; }

        public TravellerRewardAdvancement(int advancementAmount)
        {
            AdvancementAmount = advancementAmount;
        }
        public override string ToString()
        {
            return $"Increase to 1 advance roll by {AdvancementAmount}";
        }
    }
}