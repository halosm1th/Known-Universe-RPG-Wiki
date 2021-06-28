using System.Collections.Generic;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.CreationEvents;

namespace TravellerWiki.Data.Services.CareerService
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