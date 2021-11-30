using System.Collections.Generic;
using System.Linq;
using TravellerCharacter.CharacterCreator.Items;

namespace TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward
{
    public class TravellerRewardItem : TravellerCharacterCreationReward
    {
        public TravellerRewardItem(string name, int cost, int kg, int tl,
            string description = "", TravellerGenericItemTypes subtype = TravellerGenericItemTypes.Other)
        {
            Items = new List<TravellerItem>();
            Items.Add(new TravellerGenericItem(name, cost, kg, tl, description, subtype));
        }

        public TravellerRewardItem(TravellerItem item)
        {
            Items = new List<TravellerItem>();
            Items.Add(item);
        }

        public TravellerRewardItem(List<TravellerItem> items)
        {
            Items = items;
        }

        public TravellerRewardItem(List<string> items)
        {
            Items = new List<TravellerItem>();
            foreach (var item in items) Items.Add(new TravellerGenericItem(item, 0, 0, 0));
        }

        public List<TravellerItem> Items { get; }

        public override string ToString()
        {
            return $"{Items.Aggregate("", (items, next) => $"{items} | {next}")} ";
        }
    }
}