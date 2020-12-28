using System;
using System.Collections.Generic;

namespace TravellerWiki.Data
{
    public class TravellerCharacterCreationRewardJSON
    {
        public List<string> Skilllist { get; set; }
        public string? Rewardtext { get; set; }
        public string? ContactCount { get; set; }
        public string? ContactType { get; set; }
        public int? CommissionIncreaseChange { get; set; }
        public int? AdvancementAmount { get; set; }
        public int? BenefitIncreaseAmount { get; set; }
        public string? NewCareerName { get; set; }
        public List<string> Items { get; set; }

        public TravellerCharacterCreationReward GetReward()
        {
            if (Items != null)
            {
                return new TravellerCharacterCreationItemReward(Items);
            }
            
            if (NewCareerName != null || NewCareerName != String.Empty)
            {
                return new TravellerCharacterCreationJobChangeReward(NewCareerName);
            }

            if (BenefitIncreaseAmount != null)
            {
                return new TravellerCharacterCreationBenefitIncreaseReward(BenefitIncreaseAmount ?? 0);
            }

            if (AdvancementAmount != null)
            {
                return new TravellerCharacterCreationAdvancementReward(AdvancementAmount ?? 0);
            }
            
            if (CommissionIncreaseChange != null)
            {
                return new TravellerCharacterCreationCommissionReward(CommissionIncreaseChange ?? 0);
            }

            if (ContactType != null && ContactCount != null)
            {
                return new TravellerContactReward(ContactCount,ContactType);
            }

            if (Skilllist != null)
            {
                return new TravellerCharacterCreationSkillReward(Skilllist);
            }

            if (Rewardtext != null)
            {
                return new TravellerOtherReward(Rewardtext);
            }

            return new TravellerOtherReward("No Entry");
        }

    }
}