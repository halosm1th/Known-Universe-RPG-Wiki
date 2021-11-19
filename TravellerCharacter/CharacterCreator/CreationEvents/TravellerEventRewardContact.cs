using System.Collections.Generic;
using System.Text;
using TravellerCharacter.Character_Services.NPC_Services;
using TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward;
using TravellerWiki.Data;

namespace TravellerCharacter.CharacterCreator.CreationEvents
{
    public class TravellerEventRewardContact : TravellerEventReward
    {
        public TravellerEventRewardContact(string text, TravellerRewardContact contact) : base(text,new List<TravellerCharacterCreationReward>())
        {
            Reward.Add(contact);
        }

        public TravellerEventRewardContact(string text, List<TravellerRewardContact> contacts) : base(text, new List<TravellerCharacterCreationReward>())
        {
            Reward.AddRange(contacts);
        }

        public TravellerEventRewardContact(string text, string contactName, TravellerNPCRelationship relationship) : base(text, new List<TravellerCharacterCreationReward>())
        {
            Reward.Add(new TravellerRewardContact(contactName,relationship));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(EventText);
            foreach (var contact in Reward)
            {
                sb.Append($" [{contact}], ");
            }
            return sb.ToString();
        }
    }
}