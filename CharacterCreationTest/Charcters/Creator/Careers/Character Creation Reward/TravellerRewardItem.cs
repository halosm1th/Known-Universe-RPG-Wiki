using System.Collections.Generic;
using System.Linq;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public class TravellerRewardItem : TravellerCharacterCreationReward
    {
        public List<TravellerItem> Items { get; }

        public TravellerRewardItem(string name, int cost, int kg, int tl)
        {
            Items = new List<TravellerItem>();
            Items.Add(new TravellerItem(name,cost,kg,tl));
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
            Items  = new List<TravellerItem>();
            foreach (var item in items)
            {
                Items.Add(new TravellerItem(item,0,0,0));
            }
        }
        public override string ToString()
        {
            return $"{Items.Aggregate("", (items, next) => $"{items} | {next}")} ";
        }

    }
}