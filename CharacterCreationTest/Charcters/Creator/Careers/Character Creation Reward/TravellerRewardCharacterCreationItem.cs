using System.Collections.Generic;
using System.Linq;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public class TravellerRewardCharacterCreationItem : TravellerCharacterCreationReward
    {
        public List<TravellerItem> Items { get; }

        public TravellerRewardCharacterCreationItem(List<string> items)
        {
            Items  = new List<TravellerItem>();
            foreach (var item in items)
            {
                Items.Add(new TravellerItem(item,0,0,0));
            }
        }

        public TravellerRewardCharacterCreationItem(List<TravellerItem> items)
        {
            Items = items;
        }
        public override string ToString()
        {
            return $"{Items.Aggregate("", (items, next) => $"{items} {next}")} | ";
        }

    }
}