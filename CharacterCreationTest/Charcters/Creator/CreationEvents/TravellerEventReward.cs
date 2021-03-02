using System.Collections.Generic;

namespace TravellerWiki.Data.CreationEvents
{
    public class TravellerEventReward : TravellerEventCharacterCreation
    {
        public List<TravellerCharacterCreationReward> Reward { get; }

        public TravellerEventReward(string text, List<TravellerCharacterCreationReward> reward) : base(text)
        {
            Reward = reward;
        }

    }
}