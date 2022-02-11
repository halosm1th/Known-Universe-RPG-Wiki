using System.Collections.Generic;

namespace TravellerFactionSystem.Location;

public class TravellerLocationService
{
    public static Dictionary<int, TravellerLocation> Locations { get; set; } = new Dictionary<int, TravellerLocation>();

    public static void AddLocation(TravellerLocation location)
    {
        Locations.Add(location.LocationID,location);
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