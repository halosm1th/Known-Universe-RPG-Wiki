using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds;
using TravellerMapSystem.Worlds;

namespace TravellerEconomySystem;

public class TravellerEconomy
{

    public TravellerEconomicCore EconomicCore;
    private TravellerEconomicCore _income;
    private TravellerEconomicCore _expenditure;
    
    public bool FoodCrisis { get; private set; }
    public bool PopCrisis { get; private set;}
    public bool ResourceCrisis { get; private set;}
    public bool TechCrisis { get; private set;}
    public bool MoneyCrisis { get;private set; }

    public ITravellerEconomicNation EconomyOf { get; }

    public TravellerEconomy(ITravellerEconomicNation holdingNation)
    {
        EconomyOf = holdingNation;
    }
    
    public void UpdateEconomicStatus()
    {
        UpdateIncome();
        UpdateExpenses(EconomyOf.Expenitures.Select(x => x.Value).ToList());
        UpdateEconomicCore();
        EconomicCrisisCheck();
    }

    private void EconomicCrisisCheck()
    {
        if (EconomicCore.Food < 0) FoodCrisis = true;
        if (EconomicCore.Workers < 0) PopCrisis = true;
        if (EconomicCore.Resources < 0) ResourceCrisis = true;
        if (EconomicCore.TechLevel < 0) TechCrisis = true;
        if (EconomicCore.Money < 0) MoneyCrisis = true;
    }

    private void UpdateEconomicCore()
    {
        var currentMoney = _income.Money - _expenditure.Money;
        var currnetFood = _income.Food - _expenditure.Food;
        var currentResources = _income.Resources - _expenditure.Resources;
        var currentWorkers = _income.Workers - _expenditure.Workers;

        EconomicCore = new TravellerEconomicCore(currentMoney, currentResources, currnetFood, currentWorkers);
    }

    public TravellerEconomicCore calcExpenatures(List<IExpenditure> expenditures)
    {
        var expenses = new TravellerEconomicCore();
        foreach (var expesne in expenditures)
        {
            expenses.Add(expenses);
        }

        return expenses;
    }
    
    private void UpdateExpenses(List<IExpenditure> expenditures)
    {
        var expenses = new TravellerEconomicCore(calcExpenatures(expenditures));
        CalculateSystemExpenses(expenses);
        expenses.MultiplyTechToIncome();
    }

    private void CalculateSystemExpenses(TravellerEconomicCore expenses)
    {
        foreach (var system in EconomyOf.Systems.Select(x => x.Value))
        {
            if (SystemIsBadSpecial(system))
            {
                GetSystemExepenses(system, expenses);
            }
            else
            {
                expenses.Food--;
            }
        }
    }

    private void GetSystemExepenses(KnownUniverseSystem system, TravellerEconomicCore exepensese)
    {
        var tradeCodes = SystemSpecialType(system);
        exepensese.ProcessTradeCodesExpenses(tradeCodes);
    }
    
    private void UpdateIncome()
    {
        var income = new TravellerEconomicCore(_income.Money, _income.Resources, _income.Food, _income.Workers);
        CalculateSystemIncome(income);
        income.MultiplyTechToIncome();
    }

    private void CalculateSystemIncome(TravellerEconomicCore income)
    {
        foreach (var system in EconomyOf.Systems.Select(x => x.Value))
        {
            if (SystemIsGoodSpecial(system))
            {
                GetSystemIncome(system, income);
            }
            else
            {
                //If the planet just exists, it gives one credit.
                income.Money += 1;
            }
        }
    }

    private List<TradeCodes> WorldSpecialType(TravellerWorld world)
    {
        return world.GetTradeCodes();
    }



    private void GetSystemIncome(KnownUniverseSystem system, TravellerEconomicCore income)
    {
        var tradeCodes = SystemSpecialType(system);
        income.ProcessTradeCodesIncome(tradeCodes);
    }

    private List<TradeCodes> SystemSpecialType(KnownUniverseSystem system)
    {
        var tradeCodes = new List<TradeCodes>();
        foreach (var world in system.WorldsInSystem)
        {
            if (world is TravellerWorld travellerWorld)
            {
                tradeCodes.AddRange(WorldSpecialType(travellerWorld));
            }
        }

        return tradeCodes;
    }
    
    
    private bool SystemIsBadSpecial(KnownUniverseSystem system)
    {
        var tradeCodes = SystemSpecialType(system);

        foreach (var tradecode in tradeCodes)
        {
            if (tradecode == TradeCodes.Non_Agricultural)
            {
                return true;
            }

            if (tradecode == TradeCodes.Low_Tech)
            {
                return true;
            }

            if (tradecode == TradeCodes.Low_Population)
            {
                return true;
            }

            if (tradecode == TradeCodes.Non_Industrial)
            {
                return true;
            }

            if (tradecode == TradeCodes.Poor)
            {
                return true;
            }
        }

        return false;
    }
    
    private bool SystemIsGoodSpecial(KnownUniverseSystem system)
    {
        var tradeCodes = SystemSpecialType(system);

        foreach (var tradecode in tradeCodes)
        {
            if (tradecode == TradeCodes.Agriculture)
            {
                return true;
            }

            if (tradecode == TradeCodes.High_Tech)
            {
                return true;
            }

            if (tradecode == TradeCodes.High_Populatin)
            {
                return true;
            }

            if (tradecode == TradeCodes.Industrial)
            {
                return true;
            }

            if (tradecode == TradeCodes.Rich)
            {
                return true;
            }
        }

        return false;
    }

    public override string ToString()
    {
        return $"Money: ${EconomicCore.Money}. Workers: {EconomicCore.Workers}, " +
               $"Industry: {EconomicCore.Resources}, Food: {EconomicCore.Food}, Tech Level: {EconomicCore.TechLevel})";
    }
}