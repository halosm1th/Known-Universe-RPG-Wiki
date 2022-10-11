using System.Collections.Generic;
using TravellerCharacter.CharacterCreator.Careers;

namespace TravellerCharacter.Character_Services.Career_Service.Basic_Careers
{
    internal class TravellerBasicCareer : TravellerMinorPowerCareers
    {
        public static void AddNationCareers(List<TravellerCareer> careers)
        {
            var career = TravellerNationCareer.NationCareer();

            careers.Add(career);
        }
    }
}