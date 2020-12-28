using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobBoardCreator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TravellerWiki
{
    public class JobBoardModel : PageModel
    {
        private List<string> ValidTASMembershipIDs = new List<string>{ "1701","123",  "0xCAFEBABE"};
        private List<string> InvalidTASMembershipIDs = new List<string>{ "1999","2000","0000","1234", "0xDEADBEEF"};

        [BindProperty(SupportsGet = true)] public bool CanViewBoard { get; set; }
        [BindProperty(SupportsGet = true)] public bool InvalidID { get; set; }
        public void OnGet()
        {
        }

        /*
         *        
           public async Task<IActionResult> OnGetAsync(string nationName)
           {
           NationName = nationName.Replace('_',' ');
           CharacterInfo = characterInfos[NationName];
           return Page();
           }
         *
         */
        [HttpGet("{TASID}")]
        public void OnPost(string TASID)
        {
            CanViewBoard = ValidTASMembershipIDs.Contains(TASID);
            if (!CanViewBoard)
            {
                InvalidID = InvalidTASMembershipIDs.Contains(TASID);
            }
        }
    }
}