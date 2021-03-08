using System.Collections.Generic;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data.Services.CareerService.PolandskianCareeres
{
    class TravellerPolandskianCareers : TravellerMinorPowerCareers
    {
        public static void AddPolandskianCareers(List<TravellerCareer> careers)
        {

            var pirate = TravellerPolandskiaPirate.PolandskiaPirate();

            careers.Add(pirate);

        }
    }
}