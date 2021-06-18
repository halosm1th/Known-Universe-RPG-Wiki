using System.Collections.Generic;
using System.Diagnostics;

namespace TravellerWiki.Data.Charcters
{
    public class TravellerWeapon : TravellerItem
    {
        public int RangeInMeters { get; set; }
        public string Damage { get; set; }
        public int MagazineCapacity { get; set; }
        public int MagazineCost { get; set; }
        public List<TravellerWeaponTrait> WeaponTraits { get; set; }
        public string OtherInformation { get; set; }

        public TravellerWeapon(string name, int cost, int kg, int tl, int rangeInMeters, string damage,
            int magazineCapacity, int magazineCost, List<TravellerWeaponTraits> weaponTraits, string otherInformation) :
            base(name, cost, kg, tl)
        {
            RangeInMeters = rangeInMeters;
            Damage = damage;
            MagazineCapacity = magazineCapacity;
            OtherInformation = otherInformation;
            MagazineCost = magazineCost;
            ItemType = TravellerItemTypes.Weapon;
            WeaponTraits = new List<TravellerWeaponTrait>();
            foreach (var t in weaponTraits)
            {
                WeaponTraits.Add(new TravellerWeaponTrait(t));

            }
        }

        public override string ToString()
        {
            return
                $"[{Name}({TechLevel}), Cr{Cost}, {KG}, {RangeInMeters}M, {Damage}, {MagazineCapacity},{OtherInformation}]";
        }
    }
}