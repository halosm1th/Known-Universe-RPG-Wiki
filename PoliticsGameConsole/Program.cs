// See https://aka.ms/new-console-template for more information
using TravellerPoliticsGameSystem;

Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine("Starting game system!");
var PoliticsGame = new TravellerPoliticsGameCore();

var input = "";
do
{
    foreach (var nation in PoliticsGame.SuperNations)
    {
        Console.WriteLine(nation.ToString());
    }
    input = GetCommand();
} while (ExecuteCommand(input.ToLower()));
Environment.Exit(0);



static string GetCommand()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Enter Command: ");
    var command = Console.ReadLine();
    Console.ForegroundColor = ConsoleColor.Gray;
    
    return command;
}

bool ExecuteCommand(string command)
{
    if (command == "exit" && command == "quit" && command == "q")
    {
        return false;
    }
    
    if (command == "update")
    {
        Update();
    }

    return true;
}

void Update()
{
    foreach (var super in PoliticsGame.SuperNations)
    {
        super.Update();
    }
}


