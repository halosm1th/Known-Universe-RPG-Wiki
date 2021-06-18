namespace TravellerWiki.Data.Charcters
{
    public class TravellerAugments : TravellerItem
    {
        public string Improvement { get; set; }
        public string Location { get; set; }

        public TravellerAugments(string name, int cost, int kg, int tl, string improvement, string location, string description = "") : 
            base(name, cost, kg, tl,description, TravellerItemTypes.Augment)
        {
            Improvement = improvement;
            Location = location;
        }
        public override string ToString()
        {
            return
                $"[{Name}({TechLevel}), Cr{Cost}, {KG}, {Improvement}, {Location}]";
        }
    }
}