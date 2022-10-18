using System.Diagnostics.SymbolStore;
using System.Security.AccessControl;
using Newtonsoft.Json.Serialization;
using TravellerCharacter.Character_Services;
using TravellerMapSystem.Worlds;

namespace Traveller_Politics_Game;

class PoliticsGame
{
    private List<PoliticalNation> Nations;
    private List<PoliticsGameSystem> WorldsInGame;

    int round = 1;
    string command = "";
    private bool newRound = true;
    
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
        PrintWorlds(WorldsInGame);
        do
        {
            if (newRound)
            {
                PrintRound();
                PrintAllNations();
                newRound = false;
            }

            GetCommand();
            InterpretCommand();
        } while (round < 9);
    }

    private void PrintAllNations()
    {
        foreach (var nation in Nations)
        {
            Console.WriteLine(nation.ToString());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n------------------------------\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            ;
        }
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

    private void PrintWorlds(List<PoliticsGameSystem> worldsToPrint)
    {
        foreach (var world in WorldsInGame)
        {
            Console.WriteLine(world);
        }
    }

    private void PrintSubsector((int subx, int suby) subsectorToPrint)
    {
        var worlds = WorldsInGame.Where(x =>
            x.SystemLocation.SubsectorX == subsectorToPrint.subx &&
            x.SystemLocation.SubsectorY == subsectorToPrint.suby);
        Console.WriteLine("Printing worlds.");
        foreach (var world in worlds)
        {
            Console.WriteLine(world);
        }

        Console.WriteLine("");
    }

    public void InterpretCommand()
    {
        var commandParts = command.Split(" ");
        var commandName = commandParts[0].ToLower();
        if (commandName == "exitgame" || commandName == "eg")
        {
            round = 10;
        }else if (commandName == "next")
        {
            NextRound();
        }else if (commandName == "displaysubsector" || commandName == "ds")
        {
            // ds SubX:SubY
            DisplaySubsectorCommand();
        }else if (commandName == "transfersystem" || commandName == "ts")
        {
            TransferSystem(commandParts);
        }else if (commandName == "listnationid" || commandName == "lsid")
        {
            ListNations();
        }else if (commandName == "listnation" || commandName == "ln")
        {
            var nationID = 0;
            if (Int32.TryParse(commandParts[1], out nationID))
            {
                var nation = Nations.First(x => x.NationID == nationID);
                Console.WriteLine(nation);
            }
            else
            {
                Console.WriteLine("Error no nation with that ID");
            }
        }else if (commandName == "movefleet" || commandName == "mf")
        {
            MoveFleet(commandParts);
        }else if (commandName == "addpayment" || commandName == "ap")
        {
            AddPayment(commandParts);
        } else if (commandName == "lde" || commandName == "listexpenses")
        {
            var nation = GetNation(commandParts);
            if (nation == null)
            {
                return;
            }

            foreach (var cost in nation.DynamicCosts)
            {
                Console.WriteLine($"{cost.Key}: {cost.Value}");
            }
        }else if (commandName == "ldi" || commandName == "listincomes")
        {
            ListDynamicIncomes(commandParts);
        }else if (commandName == "listsystems" ||commandName == "ls")
        {
            var nation = GetNation(commandParts);

            if (nation == null)
            {
                return;
            }

            Console.WriteLine("Systems:");
            foreach (var system in nation.NationalSystems)
            {
                Console.WriteLine($"{system}");
            }
        }
        else if (commandName == "adc" || commandName == "adddynamiccost")
        {
            AddDynamicCost(commandParts);
        }else if (commandName == "removecost" || commandName == "rde")
        {
            RemoveDynamicCost(commandParts);
        }
        else if (commandName == "clear" || commandName == "cls")
        {
            Console.Clear();
        }else if (commandName == "buildfleet" || commandName == "bf")
        {
            buildFleet(commandParts);
        }else if (commandName == "removefleet" || commandName == "rf")
        {
            RemoveFleet(commandParts);
        }else if (commandName == "transferfleet" || commandName == "tf")
        {
            TransferFleet(commandParts);
        }
        else if (commandName == "help" || commandName == "?")
        {
            Console.WriteLine("Commands:");
            Console.WriteLine("buildfleet (bf) NATIONID FleetTechLevel Subx,Suby:parX,parY -- build a fleet at the given fleet");
            Console.WriteLine("removefleet (rf) NATIONID subx,suby:parx,pary -- remove a fleet at the given location");
            Console.WriteLine("transferfleet (tf) srcNation:destNation subx,suby:parx,pary techLevel -- transfer THE FIRST FLEET OWNED BY SRC NATION AT SYSTEM TO DEST NATIONS CONTROL.");
            Console.WriteLine("listnation (ln) NATIONID -- lists information about the nation with a given ID");
            Console.WriteLine("listnationid (lnid) -- lists all nations and their ID's");
            Console.WriteLine("help (?) -- display this menu");
            Console.WriteLine("exitgame (eg) -- exit the game");
            Console.WriteLine("next -- move the game to the next round");
            Console.WriteLine("transfersystem (ts) SrcNationID:DestNationId sysSubX,sysSubY:sysParX,sysParY -- transfer the given system from the target nation to the destination nation");
            Console.WriteLine("displaysubsector (ds) subX,subY -- display the subector at the x and y coordinates");
            Console.WriteLine("movefleet (mf) nationID fleetSRC fleetDSt -- checks if nation has a fleet at src, and if so moves it to dest. ");
            Console.WriteLine("addpayment (ap) srcNation:destNation #credits #food #prod #population #fuel");
            Console.WriteLine("listincome (ldi) nationID -- list the chosen nations dynamic incomes");
            Console.WriteLine("listexpenses (lde) nationID -- list the chosen nations dynamic costs");
            Console.WriteLine("adddynamiccost (adc) nationsID #credits #food #prod #pop #fuel -- add a new dynamic cost");
            Console.WriteLine("clear (cls) -- clear the screen");
            Console.WriteLine("listsystems (ls) nationID -- list the systems controlled by the supplied nation id");
        }
        else
        {
            Console.WriteLine($"Error command: {commandName} is not a valid command.\nTry help to list commands.");
        }
        
    }

    private void TransferFleet(string[] commandParts)
    {
        var nations = commandParts[1].Split(":");
        var techLevelText = commandParts[3];
        var srcNationId = 0;
        var destNationID = 0;
        var techLevel = 0;

        var location = PoliticsGameSystem.DecodeLocation(commandParts[2]);

        if (!Int32.TryParse(nations[0], out srcNationId) && Nations.All(x => x.NationID != srcNationId))
        {
            Console.WriteLine("error with src nation id");
            return;
        }

        var src = Nations.First(x => x.NationID == srcNationId);

        if (!Int32.TryParse(nations[1], out destNationID) && Nations.All(x => x.NationID != destNationID))
        {
            Console.WriteLine("error with dest nation id");
            return;
        }

        var dest = Nations.First(x => x.NationID == destNationID);

        if (!Int32.TryParse(techLevelText, out techLevel) && techLevel is > 0 and < 16)
        {
            Console.WriteLine("error invalid tech level");
            return;
        }

        var fleet = src.GetFleet(location, techLevel);
        if (fleet == null)
        {
            Console.WriteLine("Error no fleet found at the given location  with the given tech level");

            return;
        }

        dest.AddFleet(fleet);
        src.RemoveFleet(fleet);
    }

    private void RemoveFleet(string[] commandParts)
    {
        var nation = GetNation(commandParts);
        if (nation == null) return;

        var location = PoliticsGameSystem.DecodeLocation(commandParts[2]);
        var fleet = nation.GetFleetAt(location);
        if (fleet == null)
        {
            Console.WriteLine("There was no fleet at the given location owned by the given nation.");
            return;
        }

        nation.RemoveFleet(fleet);
    }

    private void buildFleet(string[] commandParts)
    {
        var nation = GetNation(commandParts);

        if (nation == null) return;

        var techLevelText = commandParts[2];
        var techLevel = 0;
        var locationText = commandParts[3];

        if (!Int32.TryParse(techLevelText, out techLevel) && !(techLevel >= 1 && techLevel <= 15))
        {
            Console.WriteLine("error techlevel is invalid number or outside valid range (1-15)");
        }

        var location = GetSystemByLocation(PoliticsGameSystem.DecodeLocation(locationText));
        if (location.World.MilitaryBase &&
            location.World.StarportQuality == StarportQuality.A ||
            location.World.StarportQuality == StarportQuality.B &&
            location.World.OtherBase)
        {
            var fleet = new Fleet(techLevel, location.SystemLocation);
            nation.AddFleet(fleet);
        }
        else
        {
            Console.WriteLine("Error location given is not able to create a fleet.");
        }
    }

    private void ListDynamicIncomes(string[] commandParts)
    {
        var nation = GetNation(commandParts);
        if (nation == null)
        {
            return;
        }

        foreach (var income in nation.DynamicIncomes)
        {
            Console.WriteLine($"{income.Key}: {income.Value}");
        }
    }

    private void RemoveDynamicCost(string[] commandParts)
    {
        var nation = GetNation(commandParts);

        if (nation == null)
        {
            return;
        }

        foreach (var expense in nation.DynamicCosts)
        {
            Console.WriteLine($"{expense.Key}: {expense.Value}");
        }

        Console.Write("Enter # to remove: #");
        var numb = "#" + Console.ReadLine();
        nation.RemoveDynamicCost(numb);
    }

    private void AddDynamicCost(string[] commandParts)
    {
        var nation = GetNation(commandParts);

        if (nation == null)
        {
            return;
        }

        var creditsText = commandParts[2];
        var foodText = commandParts[3];
        var prodText = commandParts[4];
        var popText = commandParts[5];
        var fuelText = commandParts[6];
        var credits = 0;
        var food = 0;
        var prod = 0;
        var pop = 0;
        var fuel = 0;

        if (!Int32.TryParse(creditsText, out credits))
        {
            Console.WriteLine("Error with credit amount");
            return;
        }


        if (!Int32.TryParse(foodText, out food))
        {
            Console.WriteLine("Error with food amount");
            return;
        }


        if (!Int32.TryParse(prodText, out prod))
        {
            Console.WriteLine("Error with production amount");
            return;
        }


        if (!Int32.TryParse(popText, out pop))
        {
            Console.WriteLine("Error with pop amount");
            return;
        }


        if (!Int32.TryParse(fuelText, out fuel))
        {
            Console.WriteLine("Error with fuel amount");
            return;
        }

        Console.Write("Enter the name of the cost: ");
        var costName = Console.ReadLine();
        var resources = new Capital(credits, food, prod, pop, fuel);


        nation.AddDynamicCost(costName ?? "Unknown cost", resources);
    }

    private PoliticalNation GetNation(string[] commandParts)
    {
        try
        {
            if (commandParts.Length < 2)
            {
                Console.WriteLine("error no id given");
                return null;
            }
        
            var nationText = commandParts[1];
            var nationID = 0;

            if (!Int32.TryParse(nationText, out nationID) && Nations.Any(x => x.NationID == nationID))
            {
                Console.WriteLine($"Error converting {nationText} to int. Might be invalid ID.");
                return null;
            }

            return Nations.First(x => x.NationID == nationID);
        }
        catch (Exception e)
        {
            Console.WriteLine("There was an error");
            return null;
        }
    }

    private void AddPayment(string[] commandParts)
    {
        var nationsText = commandParts[1].Split(":");
        var creditsText = commandParts[2];
        var foodText = commandParts[3];
        var prodText = commandParts[4];
        var popText = commandParts[5];
        var fuelText = commandParts[6];

        var srcNationId = 0;
        var destNationID = 0;
        var credits = 0;
        var food = 0;
        var prod = 0;
        var pop = 0;
        var fuel = 0;

        if (!Int32.TryParse(nationsText[0], out srcNationId) && Nations.Any(x => x.NationID == srcNationId))
        {
            Console.WriteLine("Error with src nation id");
            return;
        }

        if (!Int32.TryParse(nationsText[1], out destNationID) && Nations.Any(x => x.NationID == destNationID))
        {
            Console.WriteLine("Error with dest nation id");
            return;
        }

        if (!Int32.TryParse(creditsText, out credits))
        {
            Console.WriteLine("Error with credit amount");
            return;
        }


        if (!Int32.TryParse(foodText, out food))
        {
            Console.WriteLine("Error with food amount");
            return;
        }


        if (!int.TryParse(prodText, out prod))
        {
            Console.WriteLine("Error with production amount");
            return;
        }


        if (!int.TryParse(popText, out pop))
        {
            Console.WriteLine("Error with pop amount");
            return;
        }


        if (!int.TryParse(fuelText, out fuel))
        {
            Console.WriteLine("Error with fuel amount");
            return;
        }

        var srcNation = Nations.First(x => x.NationID == srcNationId);
        var destNation = Nations.First(x => x.NationID == destNationID);
        var resources = new Capital(credits, food, prod, pop, fuel);

        destNation.AddDynamicIncome($"Roundly payment from {srcNation.NationName}", resources);
        srcNation.AddDynamicCost($"Roundly payment to {destNation.NationName}", resources);
    }

    private void MoveFleet(string[] commandParts)
    {
        var nationNumb = 0;
        if (ValidateNation(commandParts, out nationNumb)) return;

        try
        {
            var nation = Nations.First(x => x.NationID == nationNumb);

            var srcLoc = PoliticsGameSystem.DecodeLocation(commandParts[2]);
            var destLoc = PoliticsGameSystem.DecodeLocation(commandParts[3]);

            if (!nation.MoveFleet(srcLoc, destLoc))
            {
                Console.WriteLine("There was an error moving the fleet.");
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine("There was an error processing your request. The error was");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{e.ToString()}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    private static bool ValidateNation(string[] commandParts, out int nationNumb)
    {
        if (!Int32.TryParse(commandParts[1], out nationNumb))
        {
            Console.WriteLine("Error the nation number was invalid");
            return true;
        }

        return false;
    }

    private void ListNations()
    {
        Console.WriteLine("ID#): NATION_NAME (PLAYER_NAME)");
        foreach (var nation in Nations)
        {
            Console.WriteLine($"#{nation.NationID}): {nation.NationName} ({nation.PlayerName})");
        }
    }

    private void TransferSystem(string[] commandParts)
    {
        //ts srcNumb:destNumb sysSubX,sysSubY:sysParX,sysParY
        var location = PoliticsGameSystem.DecodeLocation(commandParts[2]);
        var nations = commandParts[1].Split(":");
        var srcNationTxt = nations[0];
        var destNationTxt = nations[1];

        if (!int.TryParse(srcNationTxt, out var srcNationNumb))
        {
            Console.WriteLine("Error invalid source nation ID");
            return;
        }

        if (!int.TryParse(destNationTxt, out var destNationNumb))
        {
            Console.WriteLine("Error invalid destination ID");
            return;
        }

        var srcNation = Nations.First(x => x.NationID == srcNationNumb);
        var destNation = Nations.First(x => x.NationID == destNationNumb);


        if (!srcNation.RemoveSystem(location))
        {
            Console.WriteLine("Error removing system to source nation");
            return;
        }

        if (destNation.AddSystem(WorldsInGame.First(x => x.SystemLocation == location))) return;
        Console.WriteLine("Error adding system to destination nation");
    }

    private void NextRound()
    {
        round++;
        newRound = true;
    }

    private void DisplaySubsectorCommand()
    {
        try
        {
            var locationText = command.Split(" ")[1];
            var subsctor = PoliticsGameSystem.DecodeSubsector(locationText.Split(":"));
            PrintSubsector(subsctor);
        }
        catch (Exception)
        {
            Console.WriteLine("There was an error processing the command");
        }
    }
}