namespace TravellerEconomySystem;

public interface IExpenditure
{
    string ExpenditureName { get; }
    TravellerEconomicCore UpkeepCost { get; set; }
}