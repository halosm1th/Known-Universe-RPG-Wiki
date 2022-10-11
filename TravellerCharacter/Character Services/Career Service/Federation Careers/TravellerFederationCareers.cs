using System.Collections.Generic;
using TravellerCharacter.CharacterCreator.Careers;

namespace TravellerCharacter.Character_Services.Career_Service.Federation_Careers
{
    internal class TravellerFederationCareers : TravellerMajorPowerCareers
    {
        public static void AddNationCareers(List<TravellerCareer> careers)
        {
            var Navy = TravellerFederationNavy.NationCareer();
            careers.Add(Navy);
                        
            var Knight = TravellerLunaKnights.LunaKnight();
            careers.Add(Knight);
            
            var Citizen = TravellerFederationCitizen.NationCareer();
            careers.Add(Navy);
            
            var Scholar = TravellerFederationScholar.NationCareer();
            careers.Add(Navy);
            
            var Government = TravellerFederationGovernment.NationCareer();
            careers.Add(Navy);
            
            var Nobility = TravellerFederationNobility.NationCareer();
            careers.Add(Navy);
            
            var Scout = TravellerFederationScout.NationCareer();
            careers.Add(Navy);
            
            var Army = TravellerFederationArmy.NationCareer();
            careers.Add(Navy);
            
            var LordsMilitary = TravellerFederationLordsMilitary.NationCareer();
            careers.Add(Navy);
            
            var Prisoner = TravellerFederationPrisoner.NationCareer();
            careers.Add(Navy);
        }
    }
}