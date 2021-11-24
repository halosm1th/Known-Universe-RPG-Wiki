using System.Collections.Generic;
using System.Text;
using TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward;
using TravellerCharacter.CharacterParts;

namespace TravellerCharacter.CharacterCreator.CreationEvents
{
    public class TravellerEventRewardAttribute : TravellerEventReward
    {
        public TravellerEventRewardAttribute(string text, TravellerAttribute reward) : base(text, new List<TravellerCharacterCreationReward>())
        {
            Reward.Add(new TravellerRewardAttribute(reward));
        }

        public TravellerEventRewardAttribute(string text, TravellerAttributes reward, int amount = 1) : base(text, new List<TravellerCharacterCreationReward>())
        {
            Reward.Add(new TravellerRewardAttribute(reward, amount));
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
        
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(EventText);

            foreach (var rwd in Reward)
            {
                sb.Append($" [{rwd}]");
            }

            return sb.ToString();
        }
    }
}