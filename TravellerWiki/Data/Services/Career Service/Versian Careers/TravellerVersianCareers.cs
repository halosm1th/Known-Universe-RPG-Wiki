using System.Collections.Generic;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data.Services.CareerService.VersianCareeres
{
    class TravellerVersianCareers : TravellerMajorPowerCareers
    {

        public static void AddVersianCareers(List<TravellerCareer> careers)
        {

            var prisoner = TravellerVersianPrisoner.VersianPrisoner();
            var army = TravellerVersianArmy.VersianArmy();

            careers.Add(prisoner);
            careers.Add(army);

        }
    }
}