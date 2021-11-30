namespace TravellerCharacter.CharacterCreator.Items
{
    public enum TravellerAugmentLocations
    {
        Head,
        Limb,
        Body,
        Any
    }

    public class TravellerAugments : TravellerItem
    {
        public TravellerAugments(string name, int cost, int kg, int tl, string improvement,
            TravellerAugmentLocations location = TravellerAugmentLocations.Any, string description = "") :
            base(name, cost, kg, tl, description, TravellerItemTypes.Augment)
        {
            Improvement = improvement;
            Location = location;
        }

        public string Improvement { get; set; }
        public TravellerAugmentLocations Location { get; set; }

        public override string ToString()
        {
            return
                $"[{Name}({TechLevel}), Cr{Cost}, {KG}, {Improvement}, {Location}]";
        }
    }
}