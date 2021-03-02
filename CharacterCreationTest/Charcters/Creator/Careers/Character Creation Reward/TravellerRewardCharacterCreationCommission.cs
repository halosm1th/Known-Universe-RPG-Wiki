namespace TravellerWiki.Data
{
    public class TravellerRewardCharacterCreationCommission : TravellerCharacterCreationReward
    {
        public int CommissionIncreaseChange { get; }

        public TravellerRewardCharacterCreationCommission(int commissionIncreaseChange)
        {
            CommissionIncreaseChange = commissionIncreaseChange;
        }

        public override string ToString()
        {
            return $"Add {CommissionIncreaseChange} to your commission roll if you take one this term";
        }
    }
}