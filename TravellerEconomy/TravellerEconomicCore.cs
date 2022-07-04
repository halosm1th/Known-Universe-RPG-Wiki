using TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds;

namespace TravellerEconomySystem;

public class TravellerEconomicCore
{
    public int Money { get; internal set; }
    public int Resources { get; internal set; }
    public int Food { get; internal set; }
    public int Workers { get; internal set; }
    public int TechLevel { get; internal set; }

    public TravellerEconomicCore(int money=0, int resources=0, int food=0, int workers=0, int techLevel =0)
    {
        Money = money;
        Resources = resources;
        Food = food;
        Workers = workers;
        TechLevel = techLevel;
    }
    
    public TravellerEconomicCore(TravellerEconomicCore old)
    {
        Money = old.Money;
        Resources = old.Resources;
        Food = old.Food;
        Workers = old.Workers;
        TechLevel = old.TechLevel;
    }


    public void Add(TravellerEconomicCore other)
    {
        Money -= other.Money;
        Resources -= other.Resources;
        Food -= other.Food;
        Workers -= other.Workers;
        TechLevel -= other.TechLevel;
    }
    
    public void MultiplyTechToIncome()
    {
        var multiplyLevel = TechLevel;
        if (multiplyLevel == 0)
            multiplyLevel = 1;
        
        Food *= multiplyLevel;
        Resources *= multiplyLevel;
        Money *= multiplyLevel;
        Workers *= multiplyLevel;
    }

    public void ProcessTradeCodesExpenses(List<TradeCodes> tradeCodes)
    {
        
        foreach (var tradecode in tradeCodes)
        {
            if (tradecode == TradeCodes.Non_Agricultural)
            {
                Food--;
            }else if (tradecode == TradeCodes.Low_Population)
            {
                TechLevel--;
            }else if (tradecode == TradeCodes.Low_Tech)
            {
                Workers--;
            }else if (tradecode == TradeCodes.Non_Industrial)
            {
                Resources--;
            }else if (tradecode == TradeCodes.Poor)
            {
                Money--;
            }
        }
    }
    
    public void ProcessTradeCodesIncome(List<TradeCodes> tradeCodes)
    {
        foreach (var tradecode in tradeCodes)
        {
            if (tradecode == TradeCodes.Agriculture)
            {
                Food++;
            }else if (tradecode == TradeCodes.High_Tech)
            {
                TechLevel++;
            }else if (tradecode == TradeCodes.High_Populatin)
            {
                Workers++;
            }else if (tradecode == TradeCodes.Industrial)
            {
                Resources++;
            }else if (tradecode == TradeCodes.Rich)
            {
                Money++;
            }
        }
    }

}