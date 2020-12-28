namespace TravellerWiki.Data
{
    public class TravellerCharacterCreationCommissionReward : TravellerCharacterCreationReward
    {
        public int CommissionIncreaseChange { get; }

        public TravellerCharacterCreationCommissionReward(int commissionIncreaseChange)
        {
            CommissionIncreaseChange = commissionIncreaseChange;
        }

        public override string ToString()
        {
            return $"Add {CommissionIncreaseChange} to your commission roll if you take one this term";
        }
    }
}