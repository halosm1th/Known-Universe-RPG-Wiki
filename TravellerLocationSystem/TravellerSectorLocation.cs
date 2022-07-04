namespace TravellerLocationSystem;

public class TravellerSectorLocation : TravellerSubsectorLocation
{
    public int SectorX { get; set; }
    public int SectorY { get; set; }


    public TravellerSectorLocation(int secx = 1, int secy = 1, int subX = 1, int subY = 1, int sysLoc = 1) : base(subX, subY, sysLoc)
    {
        SectorX = secx;
        SectorY = secy;
    }
}