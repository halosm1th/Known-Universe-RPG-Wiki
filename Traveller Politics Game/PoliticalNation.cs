using System.Data;
using System.Runtime.Serialization;
using System.Text;
using TravellerMapSystem.Worlds;

namespace Traveller_Politics_Game;

class PoliticalNation
{

    #region Readonlys
    private readonly int TECH_LEVEL_RESET_VALUE = 3;
    private readonly int LOWEST_TECH_LEVEL = 1;
    
    private readonly int POOR_VALUE = 16;
    private readonly int RICH_VALUE = 50;

    private readonly int FUEL_TECHLEVEL_MOD = 3;
    private readonly int FUEL_GENERATOR_MODIFIER = 3;
    private readonly int FUEL_COST_VALUE = 1;

    private readonly int AGRI_TECHLEVEL_MOD = 1;
    private readonly int FOOD_GENERATOR_MODIFIER = 6;
    private readonly int AGRI_COST_VALUE = 2;
    
    private readonly int PROD_TECHLEVEL_MOD = 6;
    private readonly int PRODUCTION_GENERATOR_MODIFIER = 3;
    private readonly int PRODUCTION_COST_VALUE = 1;
    
    private readonly int POP_TECHLEVEL_MODIFIER = 2;
    private readonly int POPULATION_GENERATOR_MODIFIER = 2;
    private readonly int POP_COST_VALUE = 2;
    #endregion
    
    #region derived values
    public Dictionary<string,Capital> StaticCosts => GetStaticCosts();

    public Capital Resources => GetResources();
    public int TechLevel => GetTechLevel();
    #endregion
    
    #region public Variables
    public string PlayerName { get; }
    public int NationID { get; }
    public string NationName { get; }
    
    public List<Fleet> NationalFleets { get; }

    public List<PoliticsGameSystem> NationalSystems { get; }
    public Dictionary<string,Capital> DynamicCosts { get; }
    public Dictionary<string,Capital> DynamicIncomes { get; }
    public Capital TotalNonFleetCosts
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
    public Capital TotalCosts
    {
        get
        {
            var money = DynamicCosts.Sum(x => x.Value.Credits) + GetStaticCostsIncludingFleet().Sum(x => x.Value.Credits);
            var food = DynamicCosts.Sum(x => x.Value.Food) + GetStaticCostsIncludingFleet().Sum(x => x.Value.Food);
            var prod = DynamicCosts.Sum(x => x.Value.Production) + GetStaticCostsIncludingFleet().Sum(x => x.Value.Production);
            var pop = DynamicCosts.Sum(x => x.Value.Population) + GetStaticCostsIncludingFleet().Sum(x => x.Value.Population);
            var fuel = DynamicCosts.Sum(x => x.Value.Fuel) + GetStaticCostsIncludingFleet().Sum(x => x.Value.Fuel);
            return new Capital(money,food,prod,pop,fuel);
        }
    }
    
    #endregion

    public PoliticalNation(int nationID, string playerName = "test player", string nationName = "test nation", List<Fleet> nationalFleets = default, 
        List<PoliticsGameSystem> nationalSystems = default, Dictionary<string, Capital> dynamicCosts = default, Dictionary<string, Capital> dynamicIncomes = default)
    {
        PlayerName = playerName;
        NationName = nationName;
        NationID = nationID;

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
    
    private Dictionary<string, Capital> GetStaticCostsIncludingFleet()
    {
        var costs = new Dictionary<string, Capital>();

        AddFleetsCost(costs);
        
        GetSystemCosts(costs);

        return costs;
    }

    private Dictionary<string, Capital> GetStaticCosts()
    {
        var costs = new Dictionary<string, Capital>();

        //GetFleetsCost(costs);
        
        GetSystemCosts(costs);

        return costs;
    }

    private Capital GetFleetCosts()
    {
        var numb = 0;
        var cost = new Capital(0,0,0,0);
        foreach (var fleet in NationalFleets)
        {
            numb++;
            cost += fleet?.GetUpkeepCost() ?? new Capital();
        }

        return cost;
    }

    private void AddFleetsCost(Dictionary<string, Capital> costs)
    {
        var numb = 0;
        foreach (var fleet in NationalFleets)
        {
            numb++;
            costs.Add($"Fl. #{numb} Tl: {fleet.TechLevel} Loc: {fleet.Location}", fleet.GetUpkeepCost());
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
                food = AGRI_COST_VALUE * TechLevel/AGRI_TECHLEVEL_MOD;
            }

            if (system.Tags.Contains(TradeCodes.Ni))
            {
                prod = PRODUCTION_COST_VALUE * (TechLevel/PROD_TECHLEVEL_MOD);
                credits = POOR_VALUE * (TechLevel / PROD_TECHLEVEL_MOD);
            }

            if (system.Tags.Contains(TradeCodes.Lo))
            {
                pop = POP_COST_VALUE * (TechLevel/POP_TECHLEVEL_MODIFIER);
                fuel = (FUEL_COST_VALUE) * (TechLevel/FUEL_TECHLEVEL_MOD);
                food = AGRI_COST_VALUE * (TechLevel / POP_TECHLEVEL_MODIFIER);
            }

            costs.Add(system.LocName, new Capital(credits, food, prod, pop, fuel));
        }
    }

    private int _dynamicCostCounter = 0;
    
    public void AddDynamicCost(string name, Capital cost)
    {
        name = $"#{_dynamicCostCounter} {name}";
        DynamicCosts.Add(name,cost);
        _dynamicCostCounter++;
    }

    
    public void AddDynamicIncome(string name, Capital cost)
    {
        DynamicIncomes.Add(name,cost);
    }

    public void RemoveDynamicCost(string id)
    {
        var name = DynamicCosts.First(x => x.Key.StartsWith(id));
        DynamicCosts.Remove(name.Key);
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
    return NationalSystems.Where(x => x.Tags.Contains(TradeCodes.Hi))
        .Aggregate(0,(h,t) => h+(1 * POPULATION_GENERATOR_MODIFIER) * (TechLevel));
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
    return NationalSystems
               .Where(x => !x.Tags.Contains(TradeCodes.Po) && !x.Tags.Contains(TradeCodes.Ri))
        .Aggregate(0, (h, t) => h + (1 * TechLevel))
           + NationalSystems.Where(x => x.Tags.Contains(TradeCodes.Ri))
               .Aggregate(0,(h,t) => h + (RICH_VALUE * TechLevel));
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

public bool RemoveSystem(Location system)
{
    if (NationalSystems.Any(x => x.SystemLocation == system))
    {
        NationalSystems.Remove(NationalSystems.First(x => x.SystemLocation == system));
        return true;
    }

    return false;
}

public bool RemoveSystems(List<Location> systems)
{
    foreach (var system in systems)
    {
        if (!RemoveSystem(system)) return false;
    }

    return true;
}


public bool AddSystems(List<PoliticsGameSystem> systems)
{
    foreach (var system in systems)
    {
        if (!AddSystem(system)) return false;
    }

    return true;
}

public bool AddSystem(PoliticsGameSystem system)
{
    if (NationalSystems.Any(x => x.SystemLocation == system.SystemLocation))
    {
        return false;
    }
    
    NationalSystems.Add(system);

    return true;
}

public Fleet? GetFleetAt(Location location)
{
    if (HasFleet(location))
    {
        return NationalFleets.First(x => x.Location == location);
    }

    return null;
}

public Fleet? GetFleet(Location loc, int techLevel)
{
    return NationalFleets.First(x => x.Location == loc && x.TechLevel == techLevel);
}

public bool RemoveFleet(Fleet fleet)
{
    NationalFleets.Remove(fleet);
    return false;
}

public bool AddFleet(Fleet fleetToAdd)
{
    NationalFleets.Add(fleetToAdd);
    return true;
}

public bool InRecession = false;
private readonly int RECESSION_MODIFIER = 2;

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

        if (InRecession)
        {
            techLevel /= RECESSION_MODIFIER;
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
    var inc = GetResources();
    var costs = TotalNonFleetCosts;
    var profit = inc - costs;
    var fleetProfit = inc - TotalCosts;
    return $"{NationName} ({PlayerName}):" +
           $"\n\tTech Level: {TechLevel}" +
           $"\n\tIncome: {GetResources().ToString().Replace("Capital","")}" +
           //$"\n\tCosts (Without fleet): {TotalNonFleetCosts.ToString().Replace("Capital","")}" +
           //$"\n\tProfit (before fleet costs): {profit.ToString().Replace("Capital","")}" +
           $"\n\tCosts (With Fleet): {TotalCosts.ToString().Replace("Capital","")}" +
           $"\n\tProfit (with Fleets){fleetProfit.ToString().Replace("Capital","")}" +
           $"\n---" +
           $"\n\tFleets:" +
           $"\n\tFleet Costs: {GetFleetCosts().ToString().Replace("Capital","")}" +
           $"{GetFleetText()}" +
           $"\n\t# of Systems Controlled:" +
           $"{NationalSystems.Count}";
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