namespace TravellerWiki.Data.Charcters
{
    public class TravellerArmour : TravellerItem
    {
        public int RadiationProtection { get; set; }
        public int Protection { get; set; }
        public string Other { get; set; }

        public TravellerArmour(string name, int cost, int kg, int tl, int radiationProtection, int protection, string other) : base(name, cost, kg, tl)
        {
            RadiationProtection = radiationProtection;
            Protection = protection;
            Other = other;
        }
    }
}