using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TravellerWiki.Data
{
    public class TravellerCommission
    {
        public bool HasCommision { get; set; }

        public List<string> CommissionSkillList { get; set; }
        public List<(string Title, TravellerCharacterCreationReward Perk)> RanksAndBonuses { get; set; }
        public TravellerSkillCheck CommmsionCheck { get; set; }

        public TravellerCommission(bool hasCommision = false)
        {
            HasCommision = false;
        }

        [JsonConstructor]
        public TravellerCommission(bool hasCommision, 
            List<string> commissionSkillList,
            List<(string Title, TravellerCharacterCreationRewardJSON Perk)> ranksAndBonuses,
            TravellerSkillCheck commmsionCheck)
        {
            HasCommision = hasCommision;
            if (hasCommision)
            {
                CommissionSkillList = commissionSkillList;
                RanksAndBonuses = ranksAndBonuses.Select(rab => (rab.Title, rab.Perk.GetReward())).ToList();
                CommmsionCheck = commmsionCheck;
            }
        }
    }
}