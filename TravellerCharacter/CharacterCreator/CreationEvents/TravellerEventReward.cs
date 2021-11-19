using System.Collections.Generic;
using System.Text;
using TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward;
using TravellerWiki.Data;

namespace TravellerCharacter.CharacterCreator.CreationEvents
{
    public class TravellerEventReward : TravellerEventCharacterCreation
    {
        public List<TravellerCharacterCreationReward> Reward { get; }

        public TravellerEventReward(string text, TravellerCharacterCreationReward reward) : base(text)
        {
            Reward = new List<TravellerCharacterCreationReward>();
            Reward.Add(reward);
        }

        public TravellerEventReward(string text, List<TravellerCharacterCreationReward> reward) : base(text)
        {
            Reward = reward;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(EventText);
            sb.Append(": ");

            foreach (var reward in Reward)
            {
                sb.Append(reward.ToString());
                sb.Append(" ");
            }

            return sb.ToString();
        }

    }
}