using System.Collections.Generic;

namespace TravellerWiki.Data.Charcters
{
    public class TravellerSpecialAmmo : TravellerItem
    {
        public int AmmoMultiplierCost { get; set; }
        public string Range { get; set; }
        public List<TravellerWeaponTraits> AmmoTraits { get; set; }
        public bool AppliesToPistol { get; set; }
        public bool AppliesToRifle { get; set; }
        public bool AppliesToShotgun { get; set; }
        public bool AppliesToHeavy{ get; set; }
        public TravellerSpecialAmmo(string name, int AmmoMulCost, int tl, List<TravellerWeaponTraits> ammoTraits, 
            bool pistol, bool rifle, bool shotgun, bool heavy, string description = "") 
            : base(name, -1, 0, tl, description, TravellerItemTypes.Weapon_Modification)
        {
            AmmoMultiplierCost = AmmoMulCost;
            AppliesToPistol = pistol;
            AppliesToRifle = rifle;
            AppliesToHeavy = heavy;
            AppliesToShotgun = shotgun;
            AmmoTraits = ammoTraits;
        }
    }
}