﻿using Newtonsoft.Json;
using TravellerCharacter.CharacterParts;

namespace TravellerCharacter.CharacterCreator.Items
{
    public class TravellerItemJson
    {
        public TravellerItemJson(int id, TravellerItem item)
        {
            ID = id;
            Item = item;
        }

        public int ID { get; set; }
        public TravellerItem Item { get; set; }

        public static string ToJsonStringWithID(int id, TravellerItem item)
        {
            return JsonConvert.SerializeObject(new TravellerItemJson(id, item));
        }
    }


    public abstract class TravellerItem
    {
        public TravellerItem(string name, int cost, int kg, int tl, string description = "",
            TravellerItemTypes itemType = TravellerItemTypes.ItemGeneric)
        {
            Name = name;
            Cost = cost;
            KG = kg;
            TechLevel = tl;
            ItemType = itemType;
            Description = description;
        }

        public string Name { get; set; }
        public int Cost { get; set; }
        public int KG { get; set; }
        public int TechLevel { get; set; }
        public string Description { get; set; }

        public TravellerItemTypes ItemType { get; protected set; }

        public override string ToString()
        {
            return $"{Name}({TechLevel}): Cr{Cost}, {KG}";
        }

        public bool CanBuyItem(TravellerFinances travellersFinances)
        {
            return travellersFinances.HasEnoughCredits(Cost);
        }

        public void BuyItem(CharcterTypes.TravellerCharacter character)
        {
            if (character.Items != null) character.Items.Add(this);
        }
    }
}