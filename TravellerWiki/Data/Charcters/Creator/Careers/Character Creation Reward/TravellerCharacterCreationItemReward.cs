using System.Collections.Generic;
using System.Linq;

namespace TravellerWiki.Data
{
    public class TravellerCharacterCreationItemReward : TravellerCharacterCreationReward
    {
        public List<string> Items { get; }

        public TravellerCharacterCreationItemReward(List<string> items)
        {
            Items = items;
        }
        public override string ToString()
        {
            return $"{Items.Aggregate("", (skills, next) => $"{skills} {next}")}";
        }

    }
}