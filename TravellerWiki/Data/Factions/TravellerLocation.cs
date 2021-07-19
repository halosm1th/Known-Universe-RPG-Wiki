namespace TravellerWiki.Data.Factions
{
    public class TravellerLocation
    {
        public int SubSectorX { get; set; }
        public int SubSectorY { get; set; }

        public int ParsecX { get; set; }
        public int ParsecY { get; set; }
        
        public string LocationName { get; set; }

        public TravellerLocation(string locationName = "", int subSectorX = 1, int subSectorY = 1, int parsecX = 1, int parsecY = 1)
        {
            if (SubSectorX <= 0) subSectorX = 1;
            if (SubSectorY <= 0) subSectorY = 1;
            if (parsecX <= 0) parsecX = 1;
            if (parsecY <= 0) parsecY = 1;
            
            if (SubSectorX > 4) subSectorX = 4;
            if (SubSectorY > 4) subSectorY = 4;
            if (parsecX > 8) parsecX = 8;
            if (parsecY > 10) parsecY = 10;
            
            if (string.IsNullOrEmpty(locationName)) locationName = "Deep Space";
            if (locationName.Length > 256) locationName = locationName.Substring(0, 256);
            
            SubSectorX = subSectorX;
            SubSectorY = subSectorY;
            ParsecX = parsecX;
            ParsecY = parsecY;
            LocationName = locationName;
        }

        public override string ToString()
        {
            return $"{LocationName}({ParsecX},{ParsecY}:{SubSectorX}'{SubSectorY})";
        }
    }
}