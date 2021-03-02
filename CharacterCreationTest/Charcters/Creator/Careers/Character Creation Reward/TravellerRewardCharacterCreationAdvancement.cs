namespace TravellerWiki.Data
{
    public class TravellerRewardCharacterCreationAdvancement : TravellerCharacterCreationReward
    {
        public int AdvancementAmount { get; }

        public TravellerRewardCharacterCreationAdvancement(int advancementAmount)
        {
            AdvancementAmount = advancementAmount;
        }
        public override string ToString()
        {
            return $"Increase to 1 advance roll by {AdvancementAmount}";
        }
    }
}