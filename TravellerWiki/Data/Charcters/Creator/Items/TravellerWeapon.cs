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
        public List<TravellerWeaponTraits> WeaponTraits { get; set; }

        public TravellerWeapon(string name, int cost, int kg, int tl, int rangeInMeters, string damage,
                int magazineCapacity, int magazineCost, List<TravellerWeaponTraits> weaponTraits, string description) :
            base(name, cost, kg, tl, description, TravellerItemTypes.Weapon)
        {
            RangeInMeters = rangeInMeters;
            Damage = damage;
            MagazineCapacity = magazineCapacity;
            MagazineCost = magazineCost;
            WeaponTraits = weaponTraits;
        }

        public override string ToString()
        {
            return
                $"[{Name}({TechLevel}), Cr{Cost}, {KG}, {RangeInMeters}M, {Damage}, {MagazineCapacity},{Description}]";
        }
    }
}