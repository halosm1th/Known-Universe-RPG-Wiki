using System.Collections.Generic;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data.CreationEvents
{
    public class TravellerEventRewardAttribute : TravellerEventReward
    {
        public TravellerEventRewardAttribute(string text, TravellerAttribute reward) : base(text, new List<TravellerCharacterCreationReward>())
        {
            Reward.Add(new TravellerRewardAttribute(reward));
        }

        public TravellerEventRewardAttribute(string text, TravellerAttributes reward) : base(text, new List<TravellerCharacterCreationReward>())
        {
            Reward.Add(new TravellerRewardAttribute(reward));
        }

        public TravellerEventRewardAttribute(string text, List<TravellerAttributes> reward) : base(text, new List<TravellerCharacterCreationReward>())
        {

            var rewards = new List<TravellerRewardAttribute>();
            foreach (var rwrd in reward)
            {
                rewards.Add(new TravellerRewardAttribute(rwrd));
            }

            Reward.AddRange(rewards);
        }

        public TravellerEventRewardAttribute(string text, List<TravellerRewardAttribute> reward) : base(text, new List<TravellerCharacterCreationReward>())
        {
            Reward.AddRange(reward);
        }
    }
}