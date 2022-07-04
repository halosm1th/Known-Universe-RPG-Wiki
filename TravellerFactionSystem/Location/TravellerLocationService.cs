using System.Collections.Generic;
using System.Linq;

namespace TravellerFactionSystem.Location;

public class TravellerLocationService
{
    public static Dictionary<int, TravellerLocation> Locations { get; set; } = new Dictionary<int, TravellerLocation>();

    public static void AddLocation(TravellerLocation location)
    {
        Locations.Add(location.LocationID,location);
    }

    public static int GetLocationIDFromName(string locationName)
    {
        return Locations.Values.First(x => x.LocationName == locationName)?.LocationID ?? 0;
    }

    public static TravellerLocation GetLocationByName(string name)
    {
        return GetLocation(GetLocationIDFromName(name));
    }

    public static TravellerLocation GetLocation(int id)
    {
        if (id != 0)
        {
            return Locations[id];
        }

        return null;
    } 
}