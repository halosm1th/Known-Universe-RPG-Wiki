namespace TravellerWiki.Data.Charcters
{
    public class TravellerArmour : TravellerItem
    {
        public int RadiationProtection { get; set; }
        public int Protection { get; set; }

        public TravellerArmour(string name, int cost, int kg, int tl, int radiationProtection, int protection, string descr) :
            base(name, cost, kg, tl,descr, TravellerItemTypes.Armour)
        {
            RadiationProtection = radiationProtection;
            Protection = protection;

        }
        public override string ToString()
        {
            return
                $"[{Name}({TechLevel}), Cr{Cost}, {KG}, {RadiationProtection}, {Protection}+, {Description}]";
        }
    }
}