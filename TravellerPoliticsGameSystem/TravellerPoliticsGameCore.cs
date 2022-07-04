using TravellerLocationSystem;
using TravellerNations;

namespace TravellerPoliticsGameSystem;

public class TravellerPoliticsGameCore
{
    public List<TravellerSuperNation> SuperNations { get; }

    public void NextTurn()
    {
        foreach (var super in SuperNations)
        {
            super.Update();
        }
    }

    public TravellerPoliticsGameCore()
    {
        SuperNations = new List<TravellerSuperNation>()
        {
            new TravellerSuperNation(new List<TravellerNation>()
            {
                new TravellerNation(new List<TravellerLocation>()
                    {
                        
                    },
                    new Dictionary<string, IMilitaryAsset>()
                    {
                        
                    },
                    "test","Test Nation 1"),
            },
                "Test Nation please ignore")
        };
    }
}