﻿namespace TravellerCharacter.CharacterCreator.Items
{
    public class TravellerArmour : TravellerItem
    {
        public TravellerArmour(string name, int cost, int kg, int tl, int radiationProtection, int protection,
            string descr) :
            base(name, cost, kg, tl, descr, TravellerItemTypes.Armour)
        {
            RadiationProtection = radiationProtection;
            Protection = protection;
        }

        public int RadiationProtection { get; set; }
        public int Protection { get; set; }

        public override string ToString()
        {
            return
                $"[{Name}({TechLevel}), Cr{Cost}, {KG}, {RadiationProtection}, {Protection}+, {Description}]";
        }
    }
}