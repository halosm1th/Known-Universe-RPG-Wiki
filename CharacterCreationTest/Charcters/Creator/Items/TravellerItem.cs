namespace TravellerWiki.Data.Charcters
{
    public class TravellerItem
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int KG { get; set; }
        public int TechLevel { get; set; }

        public override string ToString()
        {
            return $"{Name}({TechLevel}): Cr{Cost}, {KG}";
        }

        public TravellerItem(string name, int cost, int kg, int tl)
        {
            Name = name;
            Cost = cost;
            KG = kg;
            TechLevel = tl;
        }

        public bool CanBuyItem(TravellerFinances travellersFinances) => travellersFinances.HasEnoughCredits(Cost);

        public void BuyItem(TravellerCharacter character)
        {
            if (character.Items != null)
            {
                character.Items.Add(this);
            }
        }
    }
}