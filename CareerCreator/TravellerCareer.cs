using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            List<(string Title, TravellerCharacterCreationReward Perk)> ranksAndBonuses,
            TravellerSkillCheck commmsionCheck)
        {
            HasCommision = hasCommision;
            if (hasCommision)
            {
                CommissionSkillList = commissionSkillList;
                RanksAndBonuses = ranksAndBonuses;
                CommmsionCheck = commmsionCheck;
            }
        }
    }

    public class TravellerCareerJson
    {
        public string CareerName { get; set; }
        public string CareerDescription { get; set; }
        public string Nationality { get; set; }

        public List<TravellerSkillCheck> Qualifications { get; set; }

        public TravellerCommission Commission { get; set; }
        public List<TravellerAssignment> Assignments { get; set; }

        public List<(int Cash, TravellerCharacterCreationReward Benefit)> MusteringOutBenefits { get; set; }

        public List<string> PersonalDevelopmentSkillList { get; set; }
        public List<string> ServiceSkillsList { get; set; }

        public List<string> AdvancedEducationSkillList { get; set; }

        public List<TravellerCharacterCreationEvent> Events { get; set; }
        public List<TravellerCharacterCreationEvent> Mishaps { get; set; }

        private static TravellerNationsCharacterInfoService travellerNationsCharacterInfoService = new TravellerNationsCharacterInfoService();

        private Dictionary<string, TravellerNationsCharacterInfo> nationService = travellerNationsCharacterInfoService.GetTravellerNationsCharacterInfos();

        [JsonConstructor]
        public TravellerCareerJson(string careerName, string description, 
            string nationality, List<TravellerSkillCheck> qualifications,
            TravellerCommission commission, List<TravellerAssignment> assignments,
            List<(int Cash, TravellerCharacterCreationReward Benefit)> musteringOutBenefits, 
            List<string> personalDevelopmentSkillList, List<string> serviceSkillsList, 
            List<string> advancedEducationSkillList,
            List<TravellerCharacterCreationEvent> events,
            List<TravellerCharacterCreationEvent> mishaps)
        {
            CareerName = careerName;
            CareerDescription = description;
            Nationality = nationality;
            Qualifications = qualifications;
            Commission = commission;
            Assignments = assignments;
            MusteringOutBenefits = musteringOutBenefits;
            PersonalDevelopmentSkillList = personalDevelopmentSkillList;
            ServiceSkillsList = serviceSkillsList;
            AdvancedEducationSkillList = advancedEducationSkillList;
            Events = events;
            Mishaps = mishaps;
        }

        public TravellerCareer CreateCareerFromJson()
        {
            return new TravellerCareer(careerName: CareerName,
                CareerDescription,
                nationality: Nationality,
                qualifications: Qualifications, commission: Commission, assignments: Assignments,
                musteringOutBenefits: MusteringOutBenefits,
                personalDevelopmentSkillList: PersonalDevelopmentSkillList,
                serviceSkillsList: ServiceSkillsList,
                advancedEducationSkillList: AdvancedEducationSkillList, events: Events, mishaps: Mishaps);
        }

    }
    public class TravellerCareer
    {
        public string CareerName { get; set; }
        public string CareerDescription { get; set; }
        public TravellerNationsCharacterInfo Nationality { get; set; }
        public List<TravellerSkillCheck> Qualifications { get; set; }

        public TravellerCommission Commission { get; set; }
        public List<TravellerAssignment> Assignments { get; set; }

        public List<(int Cash, TravellerCharacterCreationReward Benefit)> MusteringOutBenefits { get; set; }

        public List<string> PersonalDevelopmentSkillList { get; set; }
        public List<string> ServiceSkillsList { get; set; }

        public List<string> AdvancedEducationSkillList { get; set; }

        public List<TravellerCharacterCreationEvent> Events { get; set; }
        public List<TravellerCharacterCreationEvent> Mishaps { get; set; }

        private static TravellerNationsCharacterInfoService travellerNationsCharacterInfoService = new TravellerNationsCharacterInfoService();

        private Dictionary<string, TravellerNationsCharacterInfo> nationService = travellerNationsCharacterInfoService.GetTravellerNationsCharacterInfos();

        //Everything
        public TravellerCareer(string careerName, string description, string nationality, List<TravellerSkillCheck> qualifications, TravellerCommission commission,
            List<TravellerAssignment> assignments, List<(int Cash, TravellerCharacterCreationReward Benefit)> musteringOutBenefits,
            List<string> personalDevelopmentSkillList, List<string> serviceSkillsList,
            List<string> advancedEducationSkillList, List<TravellerCharacterCreationEvent> events, List<TravellerCharacterCreationEvent> mishaps)
        {
            CareerName = careerName;
            CareerDescription = description;
            Qualifications = qualifications;
            Assignments = assignments;
            MusteringOutBenefits = musteringOutBenefits;
            PersonalDevelopmentSkillList = personalDevelopmentSkillList;
            ServiceSkillsList = serviceSkillsList;
            AdvancedEducationSkillList = advancedEducationSkillList;
            Events = events;
            Mishaps = mishaps;
            Commission = commission;
            Nationality = nationService[nationality];
        }

        //Everything but comission
        public TravellerCareer(string careerName, string description, string nationality, List<TravellerSkillCheck> qualifications, List<TravellerAssignment> assignments,
            List<(int Cash, TravellerCharacterCreationReward Benefit)> musteringOutBenefits, List<string> personalDevelopmentSkillList, List<string> serviceSkillsList,
            List<string> advancedEducationSkillList, List<TravellerCharacterCreationEvent> events, List<TravellerCharacterCreationEvent> mishaps)
        {
            CareerName = careerName;
            CareerDescription = description;
            Qualifications = qualifications;
            Assignments = assignments;
            MusteringOutBenefits = musteringOutBenefits;
            PersonalDevelopmentSkillList = personalDevelopmentSkillList;
            ServiceSkillsList = serviceSkillsList;
            AdvancedEducationSkillList = advancedEducationSkillList;
            Events = events;
            Mishaps = mishaps;
            Nationality = nationService[nationality];
        }

        //Everything but comission and advanced education

        public TravellerCareer(string careerName, string description, string nationality, List<TravellerSkillCheck> qualifications, List<TravellerAssignment> assignments,
            List<(int Cash, TravellerCharacterCreationReward Benefit)> musteringOutBenefits, List<string> personalDevelopmentSkillList,
            List<string> serviceSkillsList, List<TravellerCharacterCreationEvent> events, List<TravellerCharacterCreationEvent> mishaps)
        {
            CareerName = careerName;
            CareerDescription = description;
            Qualifications = qualifications;
            Assignments = assignments;
            MusteringOutBenefits = musteringOutBenefits;
            PersonalDevelopmentSkillList = personalDevelopmentSkillList;
            ServiceSkillsList = serviceSkillsList;
            Events = events;
            Mishaps = mishaps;
            Nationality = nationService[nationality];
        }

        //No advanced education
        public TravellerCareer(string careerName, string description, string nationality, List<TravellerSkillCheck> qualifications,
            List<TravellerAssignment> assignments, List<(int Cash, TravellerCharacterCreationReward Benefit)> musteringOutBenefits,
            List<string> personalDevelopmentSkillList, List<string> serviceSkillsList,
            TravellerCommission commission, List<TravellerCharacterCreationEvent> events, List<TravellerCharacterCreationEvent> mishaps)
        {
            CareerName = careerName;
            CareerDescription = description;
            Qualifications = qualifications;
            Assignments = assignments;
            MusteringOutBenefits = musteringOutBenefits;
            PersonalDevelopmentSkillList = personalDevelopmentSkillList;
            ServiceSkillsList = serviceSkillsList;
            Events = events;
            Mishaps = mishaps;
            Commission = commission;
            Nationality = nationService[nationality];
        }

    }

    public class TravellerAssignment
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TravellerSkillCheck Survival { get; set; }
        public TravellerSkillCheck Advancement { get; set; }

        public List<string> SkillList { get; set; }
        public List<(string title, TravellerCharacterCreationReward TravellerCharacterCreationReward)> RanksAndBonuses { get; set; }

        public TravellerAssignment(string name, string description, TravellerSkillCheck survival, TravellerSkillCheck advancement, List<string> skillList, List<(string title, TravellerCharacterCreationReward perk)> ranksAndBonuses)
        {
            Name = name;
            Description = description;
            Survival = survival;
            Advancement = advancement;
            SkillList = skillList;
            RanksAndBonuses = ranksAndBonuses;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
