namespace Traveller_Politics_Game;

class PoliticsGame
{
    private List<PoliticalNation> Nations;
    private List<PoliticsGameSystem> WorldsInGame;

    int round = 1;
    string command = "";
    
    public PoliticsGame()
    {
        LoadWorlds();
        Nations = LoadNations();
    }

    public List<PoliticsGameSystem> GetSystemsByLocation(List<Location> locations)
    {
        var systems = new List<PoliticsGameSystem>();
        foreach (var location in locations)
        {
            systems.Add(GetSystemByLocation(location));
        }
        return systems;
    }

    public PoliticsGameSystem GetSystemByLocation(Location location)
    {
        return WorldsInGame.First(x => x.SystemLocation == location);
    }
    
    private List<PoliticalNation> LoadNations()
    {
        return PoliticalNations.LoadNations(WorldsInGame);
    }

    private void LoadWorlds()
    {
        WorldsInGame = new List<PoliticsGameSystem>();
        var subsectors = Directory.GetFiles(Directory.GetCurrentDirectory() + 
                                            "/Data/IslandsWorlds", "*.txt");
        foreach (var subsector in subsectors)
        {
            var text = File.ReadAllLines(subsector);
            foreach (var system in text)
            {
                WorldsInGame.Add(new PoliticsGameSystem(system));
            }
        }
    }

    public void PlayGame()
    {
        PrintWorlds();
        do
        {
            PrintRound();

            foreach (var nation in Nations)
            {
                Console.WriteLine(nation.ToString());
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n------------------------------\n");
                Console.ForegroundColor = ConsoleColor.Gray;;
            }
            
            GetCommand();
            InterpretCommand();
        } while (round < 9);
    }

    private void GetCommand()
    {
        Console.Write("Command: ");
        command = Console.ReadLine();
    }

    private void PrintRound()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine($"Round: {round}");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    private void PrintWorlds()
    {
        foreach (var world in WorldsInGame)
        {
            Console.WriteLine(world);
        }
    }

    public void InterpretCommand()
    {
        if (command.ToLower() == "exit game")
        {
            round = 10;
        }else if (command.ToLower() == "next")
        {
            round++;
        }
        
    }
}