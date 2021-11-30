using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellerCharacter.Character_Services;
using TravellerCharacter.CharacterParts;
using TravellerCharacter.CharcterTypes;

namespace TravellerWiki
{
    public class NationInfoPageModel : PageModel
    {
        private readonly List<TravellerNationsCharacterInfo> characterInfos =
            new TravellerNationsCharacterInfoService().GetTravellerNationsCharacterInfos();

        [BindProperty(SupportsGet = true)] public TravellerNationalities NationName { get; set; }

        [BindProperty(SupportsGet = true)] public TravellerNationsCharacterInfo CharacterInfo { get; set; }

        public void OnGet(TravellerNationalities nationName)
        {
            NationName = nationName;
            if (characterInfos.Any(nation => nation.Nationality == NationName))
                CharacterInfo = characterInfos.First(nation => nation.Nationality == NationName);
        }
    }
}