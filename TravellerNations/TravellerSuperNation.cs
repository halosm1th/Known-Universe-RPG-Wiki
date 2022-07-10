using TravellerEconomySystem;
using TravellerLocationSystem;
using TravellerMapSystem.Worlds;

namespace TravellerNations;

public class TravellerSuperNation : ITravellerEconomicNation
{
    public List<TravellerNation> MemberNations;
    
    public string Name { get; }

    public TravellerSuperNation(List<TravellerNation> memberNations, string name)
    {
        MemberNations = memberNations;
        Name = name;
    }

    public void Update()
    {
        foreach (var nation in MemberNations)
        {
            nation.Update();
        }
    }

    public override string ToString()
    {
        var memerNames = "";
        foreach (var memb in MemberNations)
        {
            memerNames += memb.ToString() + " ";
        }

        return $"{Name}: {memerNames}";
    }

    public Dictionary<TravellerLocation, KnownUniverseSystem> Systems
    {
        get
        {
            var systems = new Dictionary<TravellerLocation, KnownUniverseSystem>();
            foreach (var nation in MemberNations)
            {
                foreach (var system in nation.Systems)
                {
                    systems.Add(system.Key, system.Value);
                }
            }

            return systems;
        }
    }

    public Dictionary<string, IExpenditure> Expenitures { get; }
}