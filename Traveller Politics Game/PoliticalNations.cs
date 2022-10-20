using Newtonsoft.Json.Serialization;

namespace Traveller_Politics_Game;

class PoliticalNations
{
    public static List<PoliticalNation> LoadNations(List<PoliticsGameSystem> worlds)
    {
        return new List<PoliticalNation>()
        {
            new PoliticalNation(0,"Thomas and Barbara", "Bank of Esperenza",
                new List<Fleet>()
                {
                    new (15, new (2,3,1,5))
                },
                GetSystemsByLocation(new List<Location>()
                {
                    new (1,3,8,5),
                    new (2,3,1,5),
                    new (2,3,1,6),
                }, worlds)),
            new (1, "Ninno", "Political Food Bank",
                new List<Fleet>(),
                GetSystemsByLocation(new List<Location>()
                {
                    new (1,2,8,9),
                    new (2,3,1,1),
                    new (1,2,8,10),
                }, worlds)),
            new (2, "Thomas", "Essig Mercenary Company",
                new List<Fleet>(),
                    GetSystemsByLocation(new List<Location>()
                    {
                        new (1,4,4,5),
                        new (1,4, 2,2),
                        new (1,4,1,3),
                        new (1,4,2,4),
                        new (1,4,4,7),
                        
                        new (1,4,2,8),
                        new (1,4,2,9),
                        new (1,4,1,10),
                        new (1,4,2,10),
                    }, worlds)),
            new (3, "Thomas", "The Red Cross",
                new List<Fleet>(),
                GetSystemsByLocation(
                new List<Location>()
                {
                    new (3,2,2,1),
                    new (3,2,1,2),
                    new (3,2,5,2),
                    new (3,2,5,3),
                    new (3,2,2,3),
                    new (3,2,3,4),
                    new (3,2,5,4),
                    new (3,2,3,5),
                    new (3,2,6,4),
                    new (3,2,7,5),
                }, worlds)),
            
            
            new (4,"Maya", "Kotlik Republican-esc Military Junta",
                new List<Fleet>()
                {
                    new (4, new (1,1,5,3)),
                    new (4, new (1,1,5,6)),
                    new (2, new (1,2,6,1)),
                    new (1, new (1,2,4,3)),
                    new (1, new (1,2,2,5)),
                },
                GetSystemsByLocation(new List<Location>()
                {
                    new (2,1,1,1),
                    new (2,1,1,2),
                    new (2,1,6,1),
                    new (2,1,4,3),
                    new (2,1,3,5),
                    new (2,1,2,5),
                    new (2,1,2,7),
                    new (1,1,6,1),
                    new (1,1,7,2),
                    new (1,1,8,1),
                    new (1,1,5,2),
                    new (1,1,5,3),
                    new (1,1,5,4),
                    new (1,1,6,3),
                    new (1,1,7,4),
                    new (1,1,8,3),
                    new (1,1,7,5),
                    new (1,1,5,6),
                    new (1,1,6,5),
                    new (1,1,8,5),
                    new (1,1,8,6),
                },worlds)),
            new (5,"Grayson", "Federation of Fosterville",
                new List<Fleet>()
                {
                    new (3  , new (1,3,3,4)),
                    new (3, new (1,3,6,6)),
                    new (3, new (1,3,8,10)),
                    new (10, new (1,3,5,8)),
                    new (5, new (1,3,3,2)),
                    
                    new (5, new (2,3,3,3)),
                    new (7, new (2,3,5,3)),
                    
                    new (1, new (2,4,2,1)),
                    new (5, new (2,4,7,1)),
                    new (1, new (2,4,5,3)),
                    new (1, new (2,4,3,4)),
                    new (1, new (2,4,4,5)),
                    new (3, new (2,4,7,6)),

                },
                GetSystemsByLocation(new List<Location>()
                {
                    new (2,4,2,1),
                    new (2,4,4,1),
                    new (2,4,6,1),
                    new (2,4,7,1),
                    new (2,4,3,2),
                    new (2,4,4,2),
                    new (2,4,6,2),
                    new (2,4,3,3),
                    new (2,4,5,3),
                    new (2,4,3,4),
                    new (2,4,4,4),
                    new (2,4,7,4),
                    new (2,4,4,5),
                    new (2,4,5,5),
                    new (2,4,6,5),
                    new (2,4,7,6),
                    
                    new (1,3,3,2),
                    new (1,3,3,3),
                    new (1,3,3,4),
                    new (1,3,2,4),
                    new (1,3,2,5),
                    new (1,3,1,7),
                    new (1,3,2,7),
                    new (1,3,3,7),
                    new (1,3,5,7),
                    new (1,3,6,6),
                    new (1,3,3,8),
                    new (1,3,5,8),
                    new (1,3,8,7),
                    new (1,3,3,9),
                    new (1,3,2,9),
                    new (1,3,4,9),
                    new (1,3,6,9),
                    new (1,3,8,8),
                    new (1,3,4,10),
                    new (1,3,6,10),
                    new (1,3,8,10),
                    new (2,3,3,3),
                    new (2,3,5,3),
                    new (2,3,1,10),
                    new (2,3,2,10),
                },worlds)),
            new (6, "Rajah", "Trade Federation",
                new List<Fleet>()
                {
                    new (5, new (2,2,4,2)),
                    new (5,new (3,2,7,3)),
                    new (5,new (2,3,5,7)),
                    
                    new (3, new(4,2,7,2)),
                    new (3, new(4,2,5,4)),

                    new (5, new(4,3,2,1)),
                    new (3, new(4,3,3,6)),

                }, 
                GetSystemsByLocation(new List<Location>()
                {
                    new (2,3,7,5),
                    new (2,3,7,6),
                    new (2,3,6,6),
                    new (2,3,5,7),
                    
                    new (2,2,3,2),
                    new (2,2,4,2),
                    new (2,2,2,3),
                    new (2,2,4,3),
                    new (2,2,5,3),
                    
                    new (3,2,8,2),
                    new (3,2,7,3),
                    new (3,2,8,3),
                    
                    new (4,2,7,2),
                    new (4,2,6,3),
                    new (4,2,5,4),
                    new (4,2,4,5),
                    new (4,2,7,7),
                    new (4,2,6,7),
                    new (4,2,4,9),
                    new (4,2,5,9),
                    new (4,2,6,9),
                    new (4,2,7,9),
                    new (4,2,7,10),
                    new (4,2,8,10),
                    
                    new (4,3,2,1),
                    new (4,3,5,1),
                    new (4,3,7,2),
                    new (4,3,3,3),
                    new (4,3,4,3),
                    new (4,3,3,4),
                    new (4,3,7,3),
                    new (4,3,6,3),
                    new (4,3,7,4),
                    new (4,3,5,5),
                    new (4,3,7,5),
                    new (4,3,2,6),
                    new (4,3,3,6),
                    new (4,3,2,7),
                    new (4,3,3,7),
                },worlds)),
            new (7, "Erin", "Rex van der Ostrovski",
                new List<Fleet>()
                {
                    new (8, new (2,3,8,8)),
                    
                    new (6, new (3,4,1,1)),
                    new (4, new (3,4,3,6)),
                    new (4, new (3,4,4,8)),
                    
                    new (4, new (2,4,1,7)),
                    new (4, new (2,4,1,10)),

                    new (4, new (1,4,7,6)),
                },
                GetSystemsByLocation(
                    new List<Location>()
                    {
                        new (3,4,1,4),
                        new (3,4,1,5),
                        
                        new (2,4,5,8),
                        new (2,4,4,9),
                        
                        new (1,4,8,3),
                        new (1,4,7,6),
                        new (1,4,8,6),
                        new (1,4,7,7),
                        new (1,4,7,8),
                        new (1,4,7,9),
                        new (1,4,6,10),
                        new (1,4,8,10),
                        new (2,4,1,5),
                        new (2,4,1,7),
                        new (2,4,1,10),
                        
                        new (3,3,1,9),
                        new (2,3,8,8),
                        new (2,3,6,9),
                        new (3,4,1,1),
                        new (3,4,2,1),
                        new (3,4,3,4),
                        new (3,4,3,5),
                        new (3,4,3,6),
                        new (3,4,2,6),
                        new (3,4,3,7),
                        new (3,4,5,7),
                        new (3,4,4,8),
                        new (3,4,6,8),
                        new (3,4,7,8),
                        new (3,4,2,9),
                        new (3,4,3,9),
                        new (3,4,4,9),
                        new (3,4,4,10),
                        new (3,4,5,10),
                    },worlds)),
            new (8, "Jabez", "Rex van der Sever",
                new List<Fleet>()
                {
                    new (2, new(2,1,8,2)),
                    new (2, new(2,1,4,8)),
                    new (2, new(2,1,6,10)),
                    new (2, new(2,1,7,10)),
                    
                    new (4, new(3,1,5,3)),
                    new (2, new(3,1,8,2)),
                    new (2, new(3,1,8,5)),
                    new (4, new(3,1,4,6)),
                    new (2, new(3,1,3,10)),

                    new (4, new(4,1,3,4)),
                    new (2, new(4,1,3,4)),
                    new (2, new(4,1,2,5)),
                },
            GetSystemsByLocation(new List<Location>()
                {
                    
                    new (3,1,6,1),
                    new (3,1,7,2),
                    new (3,1,8,2),
                    new (3,1,4,3),
                    new (3,1,5,3),
                    new (3,1,6,3),
                    new (3,1,8,3),
                    new (3,1,6,4),
                    new (3,1,2,5),
                    new (3,1,5,5),
                    new (3,1,6,5),
                    new (3,1,8,5),
                    new (3,1,2,6),
                    new (3,1,4,6),
                    new (3,1,3,7),
                    new (3,1,4,7),
                    new (3,1,7,7),
                    new (3,1,4,8),
                    new (3,1,7,8),
                    new (3,1,7,9),
                    new (3,1,7,10),
                    new (4,1,5,1),
                    new (4,1,6,1),
                    new (4,1,6,2),
                    new (4,1,2,3),
                    new (4,1,3,4),
                    new (4,1,6,4),
                    new (4,1,1,5),
                    new (4,1,2,5),
                    new (3,2,7,1),
                    
                    new (3,1,3,10),
                    
                    new (2,1,8,1),
                    new (2,1,8,2),
                    new (2,1,7,4),
                    new (2,1,6,4),
                    new (2,1,7,6),
                    new (2,1,5,7),
                    new (2,1,8,7),
                    new (2,1,4,8),
                    new (2,1,6,8),
                    new (2,1,8,8),
                    new (2,1,4,9),
                    new (2,1,1,10),
                    new (2,1,3,10),
                    new (2,1,6,10),
                    new (2,1,7,10),
                    new (3,1,1,1),
                    new (3,1,2,1),
                    new (3,1,1,2),
                    new (3,1,1,3),
                    new (3,1,2,3),
                } ,worlds)),
            new (9, "Finn", "Rex van der Jeffers",
                new List<Fleet>()
                {
                    new (1, new(2,2,4,9)),
                    new (9, new(2,2,7,9)),
                    
                    new (1, new(3,2,7,8)),
                    
                    new (4, new(3,4,5,3)),
                    
                    new (4, new(4,3,1,9)),
                    new (4, new(4,3,6,10)),
                    new (1, new(4,3,8,9)),
                    
                    new (1, new(4,4,4,1)),
                    new (7, new(4,4,2,5)),
                    new (4, new(4,4,6,7)),
                }, 
                GetSystemsByLocation(new List<Location>()
                {
                    new (3,2,7,8),
                    
                    new (3,4,6,1),
                    new (3,4,4,2),
                    new (3,4,5,3),
                    new (3,4,6,3),
                    new (3,4,7,3),
                    new (3,4,8,6),
                    
                    new (2,2,4,8),
                    new (2,2,4,9),
                    new (2,2,5,10),
                    new (2,2,7,9),
                    
                    new (4,3,1,9),
                    new (4,3,2,9),
                    new (4,3,2,10),
                    new (4,3,4,9),
                    new (4,3,6,10),
                    new (4,3,8,7),
                    new (4,3,7,8),
                    new (4,3,6,8),
                    new (4,3,8,8),
                    new (4,3,8,9),
                    new (4,4,4,1),
                    new (4,4,7,1),
                    new (4,4,3,2),
                    new (4,4,8,2),
                    new (4,4,6,3),
                    new (4,4,8,3),
                    new (4,4,5,4),
                    new (4,4,7,4),
                    new (4,4,6,4),
                    new (4,4,8,4),
                    new (4,4,3,5),
                    new (4,4,6,5),
                    new (4,4,7,5),
                    new (4,4,2,5),
                    new (4,4,3,6),
                    new (4,4,4,6),
                    new (4,4,6,7),
                    new (4,4,7,8),
                    new (4,4,8,7),
                    new (4,4,5,9),
                },worlds)),
            new (10, "Malik", "Dominate Supreme",
                new List<Fleet>()
                {
                    new (12, new (2,2,7,5)),
                    
                    new (9, new (1,1,6,10)),
                    new (2, new (1,1,2,3)),
                    new (2, new (1,1,3,8)),
                    new (2, new (1,1,7,10)),
                    
                    new (8, new (1,3,5,1)),
                    new (8, new (1,3,7,3)),
                    
                    new (7, new (1,2,8,7)),
                    new (1, new (1,2,6,3)),
                    new (1, new (1,2,6,5)),
                    new (1, new (1,2,6,10)),
                    new (1, new (1,2,1,7)),
                    new (1, new (1,2,2,7)),
                    new (1, new (1,2,2,8)),
                },
                GetSystemsByLocation(new List<Location>()
                {
                    new (2,2,4,6),
                    new (2,2,7,5),
                    new (1,1,1,1),                    
                    new (1,1,2,3),
                    new (1,1,3,5),
                    new (1,1,1,6),
                    new (1,1,4,7),
                    new (1,1,6,7),
                    new (1,1,2,8),
                    new (1,1,3,8),
                    new (1,1,4,8),
                    new (1,1,1,9),
                    new (1,1,2,9),
                    new (1,1,4,9),
                    new (1,1,6,9),
                    new (1,1,2,10),
                    new (1,1,6,10),
                    new (1,1,7,10),

                    new (1,2,1,2),
                    new (1,2,2,1),
                    new (1,2,4,1),
                    new (1,2,3,2),
                    new (1,2,5,2),
                    new (1,2,7,2),
                    new (1,2,8,2),
                    new (1,2,1,3),
                    new (1,2,5,3),
                    new (1,2,7,3),
                    new (1,2,8,3),
                    new (1,2,6,3),
                    new (1,2,4,3),
                    new (1,2,1,4),
                    new (1,2,2,4),
                    new (1,2,3,4),
                    new (1,2,4,4),
                    new (1,2,6,4),
                    new (1,2,8,4),
                    new (1,2,4,5),
                    new (1,2,5,5),
                    new (1,2,6,5),
                    new (1,2,8,5),
                    new (1,2,4,6),
                    new (1,2,7,6),
                    new (1,2,1,7),
                    new (1,2,2,7),
                    new (1,2,1,8),
                    new (1,2,2,8),
                    new (1,2,4,7),
                    new (1,2,7,7),
                    new (1,2,8,7),
                    new (1,2,5,8),
                    new (1,2,7,8),
                    new (1,2,6,8),
                    new (1,2,6,9),
                    new (1,2,5,10),
                    new (1,2,6,10),

                    new (1,3,5,1),
                    new (1,3,6,1),
                    new (1,3,5,2),
                    new (1,3,7,2),
                    new (1,3,5,3),
                    new (1,3,7,3),
                    new (1,3,5,4),
                    new (1,3,6,4),
                },worlds)),
            new (11, "Owen", "Venhut Avenging Dominate for Amondiage",
                new List<Fleet>()
                {
                    new (5,new (2,2,8,3)),
                    new (2,new (3,2,6,6)),
                    new (10,new (3,2,5,10)),
                    new (5,new (2,3,7,2)),
                    
                    new (2,new (3,3,1,4)),
                    new (2,new (3,3,7,6)),
                    new (2,new (3,3,7,2)),
                    new (5,new (4,3,1,2)),
                },
                GetSystemsByLocation(new List<Location>()
                {
                    
                    new (3,2,1,6),
                    new (3,2,1,7),
                    new (3,2,1,8),
                    new (3,2,1,9),
                    
                    new (2,2,8,3),
                    new (3,2,6,6),
                    new (3,2,5,7),
                    new (3,2,3,8),
                    new (3,2,4,7),
                    new (3,2,5,8),
                    new (3,2,4,9),
                    new (3,2,5,10),
                    new (3,2,6,9),
                    new (3,2,6,10),
                    new (2,3,8,1),
                    new (2,3,7,2),
                    new (3,3,2,2),
                    new (3,3,7,2),
                    new (3,3,3,3),
                    new (3,3,5,3),
                    new (3,3,1,4),
                    new (3,3,7,4),
                    new (3,3,8,3),
                    new (3,3,3,5),
                    new (3,3,7,5),
                    new (3,3,6,5),
                    new (3,3,4,6),
                    new (4,3,1,3),
                },worlds)),
            new (12, "Logan", "Dominate of Red Rock",
            new List<Fleet>()
            {
                new (1, new Location(1,4,2,9)),
                new (1,new (1,4,8,10)),
                new (2,new (1,4,6,10)),
                new (2,new (1,4,3,7)),
                new (5,new (1,4,7,6))
            },
            GetSystemsByLocation(new List<Location>()
            {
                new (4,2,1,6),
                new (4,2,3,1),
                new (4,2,2,1),
                new (4,2,3,2),
                    
                new (2,2,6,5),
                    
                new (4,1,5,6),
                new (4,1,7,6),
                new (4,1,3,7),
                new (4,1,8,6),
                new (4,1,6,7),
                new (4,1,8,7),
                new (4,1,5,8),
                new (4,1,4,8),
                new (4,1,2,9),
                new (4,1,3,9),
                new (4,1,4,9),
                new (4,1,6,10),
                new (4,1,8,10),
                new (4,1,8,9),
            },worlds)),
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