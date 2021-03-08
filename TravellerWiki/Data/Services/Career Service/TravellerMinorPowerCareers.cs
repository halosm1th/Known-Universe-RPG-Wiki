using System.Collections.Generic;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.CreationEvents;
using TravellerWiki.Data.Services.CareerService.PolandskianCareeres;

namespace TravellerWiki.Data.Services.CareerService
{
    class TravellerMinorPowerCareers : TravellerCareerServiceCareer
    {
        public void AddMinorPowers(List<TravellerCareer> careers)
        {
            AddArtekkanCareer(careers);
            TravellerPolandskianCareers.AddPolandskianCareers(careers);
            AddFirstOrderCareer(careers);
            AddBritanniaCareer(careers);
            AddIVFTCareer(careers);
        }

        private static void AddArtekkanCareer(List<TravellerCareer> careers)
        {
        }
        private static void AddFirstOrderCareer(List<TravellerCareer> careers)
        {
        }
        private static void AddBritanniaCareer(List<TravellerCareer> careers)
        {
        }
        private static void AddIVFTCareer(List<TravellerCareer> careers)
        {
        }

    }
}