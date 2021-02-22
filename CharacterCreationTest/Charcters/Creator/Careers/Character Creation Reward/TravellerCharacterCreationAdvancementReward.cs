namespace TravellerWiki.Data
{
    public class TravellerCharacterCreationAdvancementReward : TravellerCharacterCreationReward
    {
        public int AdvancementAmount { get; }

        public TravellerCharacterCreationAdvancementReward(int advancementAmount)
        {
            AdvancementAmount = advancementAmount;
        }
        public override string ToString()
        {
            return $"Increase to 1 advance roll by {AdvancementAmount}";
        }
    }
}