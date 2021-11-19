namespace TravellerFactionSystem
{
    public class TravellerFactionAssetValue
    {
        public int UpkeepCost { get; set; }
        public int IncomeProduced { get; set; }

        public TravellerFactionAssetValue(int upkeepCost, int incomeProduced)
        {
            UpkeepCost = upkeepCost;
            IncomeProduced = incomeProduced;
        }

        public override string ToString()
        {
            return $"Upkeep {UpkeepCost}, Gained {IncomeProduced}.";
        }
    }
}