using System.Collections.Generic;
using System.Linq;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public class TravellerCharacterCreationItemReward : TravellerCharacterCreationReward
    {
        public List<TravellerItem> Items { get; }

        public TravellerCharacterCreationItemReward(List<TravellerItem> items)
        {
            Items = items;
        }
        public override string ToString()
        {
            return $"{Items.Aggregate("", (skills, next) => $"{skills} {next}")}";
        }

    }
}