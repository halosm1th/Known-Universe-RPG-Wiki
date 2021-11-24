using System.Collections.Generic;
using System.Text;
using TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward;
using TravellerCharacter.CharacterParts;
using TravellerWiki.Data;

namespace TravellerCharacter.CharacterCreator.CreationEvents
{
    public class TravellerEventSkillChoiceReward : TravellerEventReward
    {
        public TravellerEventSkillChoiceReward(string text, List<TravellerSkills> skills) : base(text, new List<TravellerCharacterCreationReward>())
        {
            Reward.Add(new TravellerRewardSkillChoice(1,skills));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(EventText);
            sb.Append(" ");

            foreach (var skill in Reward)
            {
                sb.Append(skill.ToString());
                sb.Append(" ");
            }

            return sb.ToString();
        }
    }
}