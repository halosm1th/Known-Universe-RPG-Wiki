using System.Collections.Generic;
using TravellerCharacter.Character_Services.Career_Service;
using TravellerCharacter.Character_Services.Career_Service.Basic_Careers;
using TravellerCharacter.CharacterCreator.Careers;
using TravellerWiki.Data.Services.CareerService.NationsCareeres;

namespace TravellerWiki.Data.Services.CareerService.NationsCareeres
{
    class TravellerBasicCareers : TravellerMinorPowerCareers
    {

        public static void AddNationCareers(List<TravellerCareer> careers)
        {

            var career = TravellerMationCareer.NationCareer();

            careers.Add(career);
        }
    }
}