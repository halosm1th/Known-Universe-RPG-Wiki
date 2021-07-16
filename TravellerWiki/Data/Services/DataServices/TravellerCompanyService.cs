using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerWiki.Data.Services.CareerService;
using static TravellerWiki.Data.TravellerIslandsNations;
using static TravellerWiki.Data.TravellerIndustries;
using static TravellerWiki.Data.Services.CareerService.TravellerNationalities;
using TravellerWiki.Data.SimpleWikiClasses;
using TravellerWiki.Data.VoicesFromTheVoidArticles;
using TravellerWiki.Pages.Wiki_Pages;

namespace TravellerWiki.Data.Services.DataServices
{
    public class TravellerCompanyService
    {
        public List<TravellerCompany> Companies => _companies;

        private static List<TravellerCompany> _companies = GetCompanies();

        private static List<TravellerCompany> GetCompanies()
        {
            var factions = new TravellerFactionService();
            return factions.Factions.Where(x => x is TravellerCompany).Cast<TravellerCompany>().ToList();
        }
    }
}