namespace TravellerFactionSystem
{
    public class TravellerFactionAssetValue
    {
        public TravellerFactionAssetValue(int upkeepCost, int incomeProduced)
        {
            UpkeepCost = upkeepCost;
            IncomeProduced = incomeProduced;
        }

        public int UpkeepCost { get; set; }
        public int IncomeProduced { get; set; }

        public override string ToString()
        {
            return $"Upkeep {UpkeepCost}, Gained {IncomeProduced}.";
        }
    }
}