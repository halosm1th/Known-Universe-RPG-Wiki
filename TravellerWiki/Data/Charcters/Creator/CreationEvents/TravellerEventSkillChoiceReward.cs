using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data.CreationEvents
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