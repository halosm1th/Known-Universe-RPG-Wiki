using System.Collections.Generic;
using System.Linq;

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


    public abstract class TravellerCharacterCreationReward
    {
    }
}