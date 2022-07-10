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
                        new TravellerSubsectorLocation(6,0),
                        new TravellerSubsectorLocation(7,0),
                        new TravellerSubsectorLocation(5,1),
                        new TravellerSubsectorLocation(6,3),
                        new TravellerSubsectorLocation(7,4),
                    },
                    new Dictionary<string, IMilitaryAsset>()
                    {
                        
                    },
                    "test","Island Nation"),
                new TravellerNation(new List<TravellerLocation>()
                    {
                        new TravellerSubsectorLocation(4,0),
                        new TravellerSubsectorLocation(1,0),
                        new TravellerSubsectorLocation(3,0),
                        new TravellerSubsectorLocation(4,1),
                        new TravellerSubsectorLocation(1,1),
                        new TravellerSubsectorLocation(2,2),
                        new TravellerSubsectorLocation(1,2),
                        new TravellerSubsectorLocation(2,3),
                        new TravellerSubsectorLocation(1,3),
                        new TravellerSubsectorLocation(0,4),
                        new TravellerSubsectorLocation(0,5),
                        new TravellerSubsectorLocation(1,5),
                    },
                    new Dictionary<string, IMilitaryAsset>()
                    {
                        
                    },
                    "test","Cluster Nation"),
            },
                "Super Nation 1"),
            new TravellerSuperNation(new List<TravellerNation>()
                {
                    new TravellerNation(new List<TravellerLocation>()
                        {
                            new TravellerSubsectorLocation(3,5),
                            new TravellerSubsectorLocation(5,6),
                            new TravellerSubsectorLocation(2,8),
                            new TravellerSubsectorLocation(1,9),
                        },
                        new Dictionary<string, IMilitaryAsset>()
                        {
                        
                        },
                        "test","Evil Island Nation"),
                    new TravellerNation(new List<TravellerLocation>()
                        {
                            new TravellerSubsectorLocation(4,8),
                            new TravellerSubsectorLocation(5,8),
                            new TravellerSubsectorLocation(6,9),
                            new TravellerSubsectorLocation(7,8),
                            new TravellerSubsectorLocation(7,9),
                        },
                        new Dictionary<string, IMilitaryAsset>()
                        {
                        
                        },
                        "test","Evil Core Nation"),
                },
                "Super Nation 2")
        };
    }
}