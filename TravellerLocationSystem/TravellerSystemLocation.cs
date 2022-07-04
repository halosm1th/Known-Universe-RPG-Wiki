namespace TravellerLocationSystem;

public class TravellerSystemLocation : TravellerLocation
{
    public int WorldNumber { get; set; }

    public TravellerSystemLocation(int worldNumber = 1)
    {
        WorldNumber = worldNumber;
    }
}