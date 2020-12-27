using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TravellerWiki.Data
{

    public class TravellerCharacterCreationSkillReward : TravellerCharacterCreationReward
    {
        public List<string> Skilllist { get; }

        public TravellerCharacterCreationSkillReward(List<string> skilllist)
        {
            Skilllist = skilllist;
        }

        public override string ToString()
        {
            return $"Skills: {Skilllist.Aggregate("",(skills,next) => $"{skills} {next}")}";
        }
    }

    public class TravellerCharacterCreationItemReward : TravellerCharacterCreationReward
    {
        public List<string> Items { get; }

        public TravellerCharacterCreationItemReward(List<string> items)
        {
            Items = items;
        }
        public override string ToString()
        {
            return $"Items: {Items.Aggregate("", (skills, next) => $"{skills} {next}")}";
        }

    }

    public class TravellerCharacterCreationJobChangeReward : TravellerCharacterCreationReward
    {
        public string NewCareerName { get; }

        public TravellerCharacterCreationJobChangeReward(string newCareerName)
        {
            NewCareerName = newCareerName;
        }

        public override string ToString()
        {
            return $"Change Career to: {NewCareerName}";
        }
    }

    public class TravellerCharacterCreationBenefitIncreaseReward : TravellerCharacterCreationReward
    {
        public int BenefitIncreaseAmount { get; }

        public TravellerCharacterCreationBenefitIncreaseReward(int benefitIncreaseAmount)
        {
            BenefitIncreaseAmount = benefitIncreaseAmount;
        }

        public override string ToString()
        {
            return $"Increase to 1 benefit roll by {BenefitIncreaseAmount}";
        }
    }

    public class TravellerCharacterCreationAdvancementReward : TravellerCharacterCreationReward
    {
        public int AdvancementAmount { get; }

        public TravellerCharacterCreationAdvancementReward(int advancementAmount)
        {
            AdvancementAmount = advancementAmount;
        }
        public override string ToString()
        {
            return $"Increase to 1 advance roll by {AdvancementAmount}";
        }
    }

    public class TravellerCharacterCreationCommissionReward : TravellerCharacterCreationReward
    {
        public int CommissionIncreaseChange { get; }

        public TravellerCharacterCreationCommissionReward(int commissionIncreaseChange)
        {
            CommissionIncreaseChange = commissionIncreaseChange;
        }

        public override string ToString()
        {
            return $"Add {CommissionIncreaseChange} to your commission roll if you take one this term";
        }
    }

    public class TravellerLifeEventReward : TravellerCharacterCreationReward
    {
        public override string ToString()
        {
            return "The traveller is to roll on the life events table";
        }
    }


    public class TravellerContactReward : TravellerCharacterCreationReward
    {
        public string ContactCount { get; }
        public string ContactType { get; }

        public TravellerContactReward(string contactCount, string contactType)
        {
            ContactCount = contactCount;
            ContactType = contactType;
        }

        public override string ToString()
        {
            return $"Gain {ContactCount} contacts of {ContactType}";
        }
    }

    public class TravellerOtherReward : TravellerCharacterCreationReward
    {
        public string Rewardtext { get; }

        public TravellerOtherReward(string rewardtext)
        {
            Rewardtext = rewardtext;
        }

        public override string ToString()
        {
            return $"Other Reward: {Rewardtext}";
        }
    }

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

    public abstract class TravellerCharacterCreationReward
    {
    }
}