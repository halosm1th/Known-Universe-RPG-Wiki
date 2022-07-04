namespace TravellerLocationSystem;

public class TravellerSubsectorLocation : TravellerSystemLocation
{
    public int SubsectorX { get; set; }
    public int SubsectorY{ get; set; }
    
    public TravellerSubsectorLocation(int subX = 1, int subY = 1, int sysLoc = 1) : base(sysLoc)
    {
        SubsectorX = subX;
        SubsectorY = subY;
    }
}