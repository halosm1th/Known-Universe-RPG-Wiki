// See https://aka.ms/new-console-template for more information
using TravellerPoliticsGameSystem;

static string GetCommand()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Enter Command: ");
    var command = Console.ReadLine();
    Console.ForegroundColor = ConsoleColor.Gray;
    
    return command;
}

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
    } while (input.ToLower() != "exit" && input.ToLower() != "quit" && input.ToLower() != "q");

    Environment.Exit(0);


