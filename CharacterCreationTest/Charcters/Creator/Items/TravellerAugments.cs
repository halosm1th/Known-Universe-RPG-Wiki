namespace TravellerWiki.Data.Charcters
{
    public class TravellerAugments : TravellerItem
    {
        public string Improvement { get; set; }
        public string Location { get; set; }

        public TravellerAugments(string name, int cost, int kg, int tl, string improvement, string location) : base(name, cost, kg, tl)
        {
            Improvement = improvement;
            Location = location;
        }
    }
}