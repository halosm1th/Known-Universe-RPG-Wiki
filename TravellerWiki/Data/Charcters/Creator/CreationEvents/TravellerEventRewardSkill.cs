using System.Collections.Generic;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data.CreationEvents
{
    public class TravellerEventRewardSkill : TravellerEventReward
    {
        public TravellerEventRewardSkill(string text, TravellerSkills reward) : base(text, new List<TravellerCharacterCreationReward>())
        {
            Reward.Add(new TravellerRewardSkill(reward));
        }

        public TravellerEventRewardSkill(string text, List<TravellerSkills> reward) : base(text, new List<TravellerCharacterCreationReward>())
        {

            var rewards = new List<TravellerRewardSkill>();
            foreach (var rwrd in reward)
            {
                rewards.Add(new TravellerRewardSkill(rwrd));
            }

            Reward.AddRange(rewards);
        }

        public TravellerEventRewardSkill(string text, List<TravellerRewardSkill> reward) : base(text, new List<TravellerCharacterCreationReward>())
        {
            Reward.AddRange(reward);
        }
    }
}