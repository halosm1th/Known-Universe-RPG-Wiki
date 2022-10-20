using TravellerMapSystem.Worlds;

namespace Traveller_Politics_Game;

class PoliticsGameSystem
{
    public string LocName => $"{Name} " +
                             $"{SystemLocation.SubsectorX},{SystemLocation.SubsectorY}:" +
                             $"{SystemLocation.ParsecX},{SystemLocation.ParsecY}";
    
    public Location SystemLocation;
    public TravellerWorld World;
    public string Name => World.Name;
    public bool FuelWorld = false;
    public List<TradeCodes> Tags => World.WorldTradeCodes;

    public override string ToString()
    {
        return $"| {SystemLocation} | {Name} | {World.UWP} | " +
               $"Mil: {World.MilitaryBase}, Depo: {World.GasGiant}, Othr: {World.OtherBase}  | " +
               $"Is Fuel World: {FuelWorld} | " +
               $"{Tags.Aggregate("",(h,t)=> h + t.ToString() + " ")}";
    }

    public PoliticsGameSystem(string UWP)
    {
        //Example: Sx,Sy:Px,Py NAME WORLD-CODE MFO G
        var codeParts = UWP.Split(' ');
        SystemLocation = DecodeLocation(codeParts[0]);
        var name = codeParts[1];
        var uwp = codeParts[2];
        var stations = DecodeStations(codeParts[3]);
        FuelWorld = codeParts[4].ToLower() == "y";

        World = new TravellerWorld(name, uwp, stations.military, stations.fuelDepo, stations.other);
    }

    public static (bool military, bool fuelDepo, bool other) DecodeStations(string stations)
    {
        bool hasMilitary = false, hasFuelDepo = false, hasOther = false;
        stations = stations.ToLower();
            
        //Check for Military
        if (stations[0] == 'y')
        {
            hasMilitary = true;
        }
            
        //Check for Fuel
        if (stations[1] == 'y')
        {
            hasFuelDepo = true;
        }

        //Check for other
        if (stations[2] == 'y')
        {
            hasOther = true;
        }

        return (hasMilitary, hasFuelDepo, hasOther);
    }

    public static Location DecodeLocation(string location)
    {
        var parts = location.Split(':');
        var subsector = parts[0].Split(',');
        var parsec = parts[1].Split(',');
        
        var (sx,sy) = DecodeSubsector(subsector);
        var (px,py) = DecodeParsec(parsec);

        return new Location(sx,sy,px,py);
    }

    public static (int px, int py) DecodeParsec(string[] parsec)
        => (Convert.ToInt32(parsec[0]), Convert.ToInt32(parsec[1]));

    public static (int sx, int sy) DecodeSubsector(string[] subsector) 
        => (Convert.ToInt32(subsector[0]), Convert.ToInt32(subsector[1]));
}