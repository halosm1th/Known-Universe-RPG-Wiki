using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TravellerWiki.Data
{
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
}
