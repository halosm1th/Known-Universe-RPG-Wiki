using System.Collections.Generic;
using TravellerCharacter.CharacterCreator.Careers;

namespace TravellerCharacter.Character_Services.Career_Service
{
    class TravellerMiddlePowerCareers : TravellerCareerServiceCareer
    {
        public void AddMiddlePowerCareers(List<TravellerCareer> careers)
        {
            AddAxionAllianceCareers(careers);
            AddGermushianCareers(careers);
            AddUniversalisConfederationCareers(careers);
            AddReverseCareer(careers);
        }

        private static void AddAxionAllianceCareers(List<TravellerCareer> careers)
        {
        }
        private static void AddGermushianCareers(List<TravellerCareer> careers)
        {
        }
        private static void AddUniversalisConfederationCareers(List<TravellerCareer> careers)
        {
        }
        private static void AddReverseCareer(List<TravellerCareer> careers)
        {
        }
    }
}