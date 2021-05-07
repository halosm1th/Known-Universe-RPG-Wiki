using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellerWiki.Data;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using TravellerWiki.Data.Services.CareerService;

namespace TravellerWiki
{
    public class NationInfoPageModel : PageModel
    {
        private List<TravellerNationsCharacterInfo> characterInfos = new TravellerNationsCharacterInfoService().GetTravellerNationsCharacterInfos();
        [BindProperty(SupportsGet = true)]
        public TravellerNationalities NationName { get; set; }
        [BindProperty(SupportsGet = true)]
        public TravellerNationsCharacterInfo CharacterInfo { get; set; }
        public void OnGet(TravellerNationalities nationName)
        {
            NationName = nationName;
            if (characterInfos.Any(nation => nation.Nationality == NationName))
            {
                CharacterInfo = characterInfos.First(nation => nation.Nationality == NationName);
            }
        }
    }
}