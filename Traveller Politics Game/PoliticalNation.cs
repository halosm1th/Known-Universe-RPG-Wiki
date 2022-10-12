using System.Runtime.Serialization;
using System.Text;
using TravellerMapSystem.Worlds;

namespace Traveller_Politics_Game;

class PoliticalNation
{

    #region Readonlys
    private readonly int TECH_LEVEL_RESET_VALUE = 3;
    private readonly int LOWEST_TECH_LEVEL = 1;
    

    private readonly int FOOD_GENERATOR_MODIFIER = 3;
    private readonly int PRODUCTION_GENERATOR_MODIFIER = 2;
    private readonly int POPULATION_GENERATOR_MODIFIER = 4;
    private readonly int FUEL_GENERATOR_MODIFIER = 1;
    
    
    private readonly int POOR_VALUE = 10;
    private readonly int PRODUCTION_COST_VALUE = 1;
    private readonly int PROD_TECHLEVEL_MOD = 6;
    private readonly int AGRI_COST_VALUE = 1;
    private readonly int FUEL_COST_VALUE = 1;
    private readonly int POP_COST_VALUE = 1;
    private readonly int POP_TECHLEVEL_MODIFIER = 2;
    #endregion
    
    #region derived values
    public Dictionary<string,Capital> StaticCosts => GetStaticCosts();

    public Capital Resources => GetResources();
    public int TechLevel => GetTechLevel();
    #endregion
    
    #region public Variables
    public string PlayerName { get; }
    public string NationName { get; }
    
    public List<Fleet> NationalFleets { get; }

    public List<PoliticsGameSystem> NationalSystems { get; }
    public Dictionary<string,Capital> DynamicCosts { get; }
    public Dictionary<string,Capital> DynamicIncomes { get; }
    public Capital TotalCosts
    {
        get
        {
            var money = DynamicCosts.Sum(x => x.Value.Credits) + StaticCosts.Sum(x => x.Value.Credits);
            var food = DynamicCosts.Sum(x => x.Value.Food) + StaticCosts.Sum(x => x.Value.Food);
            var prod = DynamicCosts.Sum(x => x.Value.Production) + StaticCosts.Sum(x => x.Value.Production);
            var pop = DynamicCosts.Sum(x => x.Value.Population) + StaticCosts.Sum(x => x.Value.Population);
            var fuel = DynamicCosts.Sum(x => x.Value.Fuel) + StaticCosts.Sum(x => x.Value.Fuel);
            return new Capital(money,food,prod,pop,fuel);
        }
    }
    #endregion

    public PoliticalNation(string playerName = "test player", string nationName = "test nation", List<Fleet> nationalFleets = default, 
        List<PoliticsGameSystem> nationalSystems = default, Dictionary<string, Capital> dynamicCosts = default, Dictionary<string, Capital> dynamicIncomes = default)
    {
        PlayerName = playerName;
        NationName = nationName;

        if (nationalFleets == default) nationalFleets = new List<Fleet>();
        if (nationalSystems == default) nationalSystems = new List<PoliticsGameSystem>();
        if (dynamicCosts == default) dynamicCosts = new Dictionary<string, Capital>();
        if (dynamicIncomes == default) dynamicIncomes = new Dictionary<string, Capital>();
        NationalFleets = nationalFleets;
        NationalSystems = nationalSystems;
        DynamicCosts = dynamicCosts;
        DynamicIncomes = dynamicIncomes;
    }
    
    #region Costs

    private Dictionary<string, Capital> GetStaticCosts()
    {
        var costs = new Dictionary<string, Capital>();

        GetFleetsCost(costs);
        
        GetSystemCosts(costs);

        return costs;
    }

    private void GetFleetsCost(Dictionary<string, Capital> costs)
    {
        foreach (var fleet in NationalFleets)
        {
            costs.Add($"Fl. Tl: {fleet.TechLevel}", fleet.GetUpkeepCost());
        }
    }

    private void GetSystemCosts(Dictionary<string, Capital> costs)
    {
        foreach (var system in NationalSystems)
        {
            var credits = 0;
            var food = 0;
            var prod = 0;
            var pop = 0;
            var fuel = 0;

            if (system.Tags.Contains(TradeCodes.Po))
            {
                credits = POOR_VALUE * TechLevel;
            }

            if (system.Tags.Contains(TradeCodes.Na))
            {
                food = AGRI_COST_VALUE * TechLevel;
            }

            if (system.Tags.Contains(TradeCodes.Ni))
            {
                prod = PRODUCTION_COST_VALUE * (TechLevel/PROD_TECHLEVEL_MOD);
            }

            if (system.Tags.Contains(TradeCodes.Lo))
            {
                pop = POP_COST_VALUE * (TechLevel/POP_TECHLEVEL_MODIFIER);
                fuel = FUEL_COST_VALUE * TechLevel;
            }

            costs.Add(system.LocName, new Capital(credits, food, prod, pop, fuel));
        }
    }

    public void AddDynamicCost(string name, Capital cost)
    {
        DynamicCosts.Add(name,cost);
    }

    public void RemoveDynamicCost(string name)
    {
        DynamicCosts.Remove(name);
    }
    #endregion
    #region Gaining Capital
public Capital GetResources()
{
    var credits = GetGeneratedCredits();
    var food = GetGeneratedFood();
    var prod = GetGeneratedProduction();
    var pop = GetGeneratedPopulation();
    var fuel = GetGeneratedFuel();

    credits += GetDynamicCredits();
    food += GetDynamicFood();
    prod += GetDynamicProd();
    pop += GetDynamicPop();
    fuel += GetDynamicFuel();
    
    return new Capital(credits, food, prod, pop, fuel);
}

private int GetDynamicPop()
{    int population = 0;

    foreach (var dync in DynamicIncomes)
    {
        population += dync.Value.Population;
    }
    
    return population;
}

private int GetDynamicProd()
{    int production = 0;

    foreach (var dync in DynamicIncomes)
    {
        production += dync.Value.Production;
    }
    
    return production;
}

private int GetDynamicFood()
{    int food = 0;

    foreach (var dync in DynamicIncomes)
    {
        food += dync.Value.Food;
    }
    
    return food;
}

private int GetDynamicFuel()
{    int fuel = 0;

    foreach (var dync in DynamicIncomes)
    {
        fuel += dync.Value.Fuel;
    }
    
    return fuel;
}

private int GetDynamicCredits()
{
    int credits = 0;

    foreach (var dync in DynamicIncomes)
    {
        credits += dync.Value.Credits;
    }
    
    return credits;
}

private int GetGeneratedFuel()
{
    return NationalSystems.Where(x => x.FuelWorld)
        .Aggregate(0,(h,t) => h+((1 * FUEL_GENERATOR_MODIFIER) * TechLevel));
}

private int GetGeneratedPopulation()
{
    return NationalSystems.Where(x => x.Tags.Contains(TradeCodes.Po))
        .Aggregate(0,(h,t) => h+(1 * POPULATION_GENERATOR_MODIFIER) * TechLevel);
}

private int GetGeneratedProduction()
{
    return NationalSystems.Where(x => x.Tags.Contains(TradeCodes.In))
        .Aggregate(0,(h,t) => h+(1 * PRODUCTION_GENERATOR_MODIFIER) * TechLevel);
}

private int GetGeneratedFood()
{
    return NationalSystems.Where(x => x.Tags.Contains(TradeCodes.Ag))
        .Aggregate(0,(h,t) => h+(1 * FOOD_GENERATOR_MODIFIER) * TechLevel);
}

private int GetGeneratedCredits()
{
    //Basically every world except poor worlds produce something of value relative to the current tech level. 
    return NationalSystems.Where(x => !x.Tags.Contains(TradeCodes.Po))
        .Aggregate(0, (h, t) => h + (1 * TechLevel));
}
#endregion
#region Managing Nation  
public bool MoveFleet(Location src, Location dest)
{
    if (!HasFleet(src)) return false;

    NationalFleets.First(x => x.Location == src).MoveFleet(dest);
    return true;
}


public bool ModifyFleet(Location src, Location dest, int amount)
{
    if (!HasFleet(src)) return false;
    
    var fleet =  NationalFleets.First(x => x.Location == src);
    fleet.MoveFleet(dest);
    fleet.ModifyFleet(amount);
    return true;
}

public int GetTechLevel()
    {

        var techLevel = LOWEST_TECH_LEVEL;
        var lowTechCounter = 0;
        
        foreach (var system in NationalSystems)
        {
            
            if (system.Tags.Any(x => x == TradeCodes.Ht))
            {
                techLevel++;
            }
            else if (system.Tags.Any(x => x == TradeCodes.Lt))
            {
                lowTechCounter++;
            }

            if (lowTechCounter >= TECH_LEVEL_RESET_VALUE)
            {
                lowTechCounter = 0;
                techLevel--;
            }
        }

        techLevel = Math.Max(LOWEST_TECH_LEVEL, techLevel);

        return techLevel;
    }


private bool HasFleet(Location src)
{
    if (NationalFleets.All(x => x.Location != src))
    {
        return false;
    }

    return true;
}
#endregion

public override string ToString()
{
    return $"{NationName} ({PlayerName}):" +
           $"\n\tTech Level: {TechLevel}" +
           $"\n\tIncome: {GetResources().ToString().Replace("Capital","")}" +
           $"\n\tCosts: {TotalCosts.ToString().Replace("Capital","")}" +
           $"\n\tFleets:" +
           $"{GetFleetText()}" +
           $"\n\tSystems:" +
           $"{GetSystemsText()}";
}

private string GetFleetText()
{    
    var text = new StringBuilder();
     var iter = 1;
    foreach (var fleet in NationalFleets)
    {
        text.Append("\n\t\t");
        text.Append($"| Fl. #{iter} " +
                    $"| TL: {fleet.TechLevel} " +
                    $"| Loc: {fleet.Location} " +
                    $"| {fleet.GetUpkeepCost().ToString().Replace("Capital","Upkeep:")}");
        iter++;
    }
    
    return text.ToString();
}

private string GetSystemsText()
{
    var text = new StringBuilder();

    foreach (var system in NationalSystems)
    {
        text.Append("\n\t\t");
        text.Append(system);
    }
    
    return text.ToString();
}
}