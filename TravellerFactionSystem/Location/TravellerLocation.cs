using System.ComponentModel;

namespace TravellerFactionSystem.Location;

public abstract class TravellerLocation
{
        public string LocationName { get; }
        public int LocationID { get; }

        public static int baseLocationID = 1000;
        
        public TravellerLocation()
        {
                LocationID = baseLocationID;
                baseLocationID++;
                
                TravellerLocationService.AddLocation(this);
        }


        public override string ToString()
        {
                return LocationName;
        }
}