namespace TravellerWiki.Data.Charcters
{
    public class TravellerWeapon : TravellerItem
    {
        public int RangeInMeters { get; set; }
        public string Damage { get; set; }
        public int MagazineCapacity { get; set; }
        public string OtherInformation { get; set; }

        public TravellerWeapon(string name, int cost, int kg, int tl, int rangeInMeters, string damage, int magazineCapacity, string otherInformation) : base(name, cost, kg, tl)
        {
            RangeInMeters = rangeInMeters;
            Damage = damage;
            MagazineCapacity = magazineCapacity;
            OtherInformation = otherInformation;
        }

        public override string ToString()
        {
            return
                $"[{Name}({TechLevel}), Cr{Cost}, {KG}, {RangeInMeters}M, {Damage}, {MagazineCapacity},{OtherInformation}]";
        }
    }
}