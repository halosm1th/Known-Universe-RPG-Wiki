using System.Collections.Generic;
using System.Linq;

namespace TravellerWiki.Data
{

    public class TravellerCharacterCreationRewardJSON
    {
        public List<string> Skilllist { get; set; }
        public List<string> Items { get; set; }
        public string NewCareerName { get; set; }
        public int BenefitIncreaseAmount { get; set; }
        public int AdvancementAmount { get; set; }
        public int CommissionIncreaseChange { get; set; }

        public TravellerCharacterCreationRewardJSON(List<string> skilllist, List<string> items, string newCareerName, int benefitIncreaseAmount, int advancementAmount, int commissionIncreaseChange)
        {
            Skilllist = skilllist;
            Items = items;
            NewCareerName = newCareerName;
            BenefitIncreaseAmount = benefitIncreaseAmount;
            AdvancementAmount = advancementAmount;
            CommissionIncreaseChange = commissionIncreaseChange;
        }

        public TravellerCharacterCreationReward GetReward()
        {
            if (Skilllist != null)
            {
                return new TravellerCharacterCreationSkillReward(Skilllist);
            }
            if (Items != null)
            {
                return new TravellerCharacterCreationItemReward(Items);
            }

            if (NewCareerName != null)
            {
                return new TravellerCharacterCreationJobChangeReward(NewCareerName);
            }

            if (BenefitIncreaseAmount != 0)
            {
                return new TravellerCharacterCreationBenefitIncreaseReward(BenefitIncreaseAmount);
            }
            if (AdvancementAmount != 0)
            {
                return new TravellerCharacterCreationAdvancementReward(AdvancementAmount);
            }
            if (CommissionIncreaseChange != 0)
            {
                return new TravellerCharacterCreationCommissionReward(CommissionIncreaseChange);
            }
            else
            {
                return null;
            }
        }
    }
    public class TravellerCharacterCreationSkillReward : TravellerCharacterCreationReward
    {
        public List<string> Skilllist { get; }

        public TravellerCharacterCreationSkillReward(List<string> skilllist)
        {
            Skilllist = skilllist;
        }

        public override string ToString()
        {
            return $"Skills: {Skilllist.Aggregate("", (skills, next) => $"{skills} {next}")}";
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

    public abstract class TravellerCharacterCreationReward
    {
    }
}