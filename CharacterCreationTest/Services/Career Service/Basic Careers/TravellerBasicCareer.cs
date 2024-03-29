﻿using System.Collections.Generic;
using TravellerWiki.Data.Charcters;
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