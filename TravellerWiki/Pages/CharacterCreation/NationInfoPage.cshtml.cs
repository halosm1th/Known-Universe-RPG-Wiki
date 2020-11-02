using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellerWiki.Data;
using Microsoft.AspNetCore.Mvc.TagHelpers;
namespace TravellerWiki
{
    public class NationInfoPageModel : PageModel
    {
        private Dictionary<string, TravellerNationsCharacterInfo> characterInfos = new TravellerNationsCharacterInfoService().GetTravellerNationsCharacterInfos();
        [BindProperty(SupportsGet = true)]
        public string NationName { get; set; }
        [BindProperty(SupportsGet = true)]
        public TravellerNationsCharacterInfo CharacterInfo { get; set; }
        [HttpGet("{nationName}")]
        public async Task<IActionResult> OnGetAsync(string nationName)
        {
            NationName = nationName.Replace('_',' ');
            CharacterInfo = characterInfos[NationName];
            return Page();
        }
    }
}