namespace Traveller_Politics_Game;

class PoliticalNations
{
    public static List<PoliticalNation> LoadNations(List<PoliticsGameSystem> worlds)
    {
        return new List<PoliticalNation>()
        {
            new (
                "tester",
                "testland",
                new List<Fleet>()
                {
                    // new Fleet(5,new Location(4,4,7,7))
                },
                GetSystemsByLocation(new List<Location>()
                {
                    new (4,4,6,7),
                    new (4,4,7,8),
                    new (4,4,8,7),
                    new (4,4,3,2),
                    new (4,4,4,1),
                    new (4,4,7,1),
                    new (4,4,3,5),
                    new (4,4,2,5),
                    new (4,4,4,5),
                    new (4,4,3,6),
                    new (4,4,4,6),
                    new (4,4,5,9),
                }, worlds)),
            new PoliticalNation("oTest", "ostest",
                new List<Fleet>(),
                GetSystemsByLocation(new List<Location>()
                {
                    new (4,4,8,2),
                    new (4,4,6,3),
                    new (4,4,8,3),
                    new (4,4,5,4),
                    new (4,4,6,4),
                    new (4,4,7,4),
                    new (4,4,8,4),
                    new (4,4,7,5),
                    new (4,4,6,5)
                }, worlds))
        };
    }
    
    #region helperMethods
    private static List<PoliticsGameSystem> GetSystemsByLocation(List<Location> locations, List<PoliticsGameSystem> worlds)
    {
        var systems = new List<PoliticsGameSystem>();
        foreach (var location in locations)
        {
            systems.Add(GetSystemByLocation(location, worlds));
        }
        return systems;
    }

    private static PoliticsGameSystem GetSystemByLocation(Location location, List<PoliticsGameSystem> worlds)
    {
        return worlds.First(x => x.SystemLocation == location);
    }
    
    #endregion
}