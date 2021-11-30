using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellerCharacter.Character_Services;

namespace TravellerWiki
{
    public class TravellerNameGeneratorModel : PageModel
    {
        public List<string> ListOfNames { get; set; }
        [BindProperty] public int NumberOfNames { get; set; }

        [BindProperty] public TravellerNameService.NationNameList NameList { get; set; }


        public IActionResult OnPostAsync()
        {
            var temp = new TravellerNameService();
            ListOfNames = temp.GetNames(NumberOfNames, NameList);
            return Page();
        }
    }
}