using System.Collections.Generic;
using System.Text;
using TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward;

namespace TravellerCharacter.CharacterCreator.CreationEvents
{
    public class TravellerEventReward : TravellerEventCharacterCreation
    {
        public TravellerEventReward(string text, TravellerCharacterCreationReward reward) : base(text)
        {
            Reward = new List<TravellerCharacterCreationReward>();
            Reward.Add(reward);
        }

        public TravellerEventReward(string text, List<TravellerCharacterCreationReward> reward) : base(text)
        {
            Reward = reward;
        }

        public List<TravellerCharacterCreationReward> Reward { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(EventText);
            sb.Append(": ");

            foreach (var reward in Reward)
            {
                sb.Append(reward);
                sb.Append(" ");
            }

            return sb.ToString();
        }
    }
}