using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TravellerWiki.Data
{
    public class TravellerCareerJson
    {
        public string CareerName { get; set; }
        public string CareerDescription { get; set; }
        public string Nationality { get; set; }

        public List<TravellerSkillCheck> Qualifications { get; set; }

        public TravellerCommission Commission { get; set; }
        public List<TravellerAssignmentJSON> Assignments { get; set; }

        public List<(int Cash, TravellerCharacterCreationRewardJSON Benefit)> MusteringOutBenefits { get; set; }

        public List<string> PersonalDevelopmentSkillList { get; set; }
        public List<string> ServiceSkillsList { get; set; }

        public List<string> AdvancedEducationSkillList { get; set; }

        public List<TravellerCharacterCreationEventJSON> Events { get; set; }
        public List<TravellerCharacterCreationEventJSON> Mishaps { get; set; }

        private static TravellerNationsCharacterInfoService travellerNationsCharacterInfoService = new TravellerNationsCharacterInfoService();

        private Dictionary<string, TravellerNationsCharacterInfo> nationService = travellerNationsCharacterInfoService.GetTravellerNationsCharacterInfos();

        [JsonConstructor]
        public TravellerCareerJson(string careerName, string description, 
            string nationality, List<TravellerSkillCheck> qualifications,
            TravellerCommission commission, List<TravellerAssignmentJSON> assignments,
            List<(int Cash, TravellerCharacterCreationRewardJSON Benefit)> musteringOutBenefits, 
            List<string> personalDevelopmentSkillList, List<string> serviceSkillsList, 
            List<string> advancedEducationSkillList,
            List<TravellerCharacterCreationEventJSON> events,
            List<TravellerCharacterCreationEventJSON> mishaps)
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
                qualifications: Qualifications, commission: Commission, assignments: Assignments.Select(x => x.ConvertToAssignment()).ToList(),
                musteringOutBenefits: MusteringOutBenefits.Select(benefit => (benefit.Cash, benefit.Benefit.GetReward())).ToList(),
                personalDevelopmentSkillList: PersonalDevelopmentSkillList,
                serviceSkillsList: ServiceSkillsList,
                advancedEducationSkillList: AdvancedEducationSkillList, 
                events: Events.Select(ev => ev.GetEvent()).ToList(), 
                mishaps: Mishaps.Select(ms => ms.GetEvent()).ToList());
        }

    }
}