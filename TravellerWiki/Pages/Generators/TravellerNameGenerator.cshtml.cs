using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellerCharacter.Character_Services;
using TravellerWiki.Data;
using WikiServices.DataServices;

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