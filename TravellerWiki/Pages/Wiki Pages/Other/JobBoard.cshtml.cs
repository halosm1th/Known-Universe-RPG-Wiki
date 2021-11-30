using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TravellerWiki
{
    public class JobBoardModel : PageModel
    {
        private readonly List<string> InvalidTASMembershipIDs = new() { "1999", "2000", "0000", "1234", "0xDEADBEEF" };
        private readonly List<string> ValidTASMembershipIDs = new() { "1701", "123", "0xCAFEBABE", "Anchovies" };

        [BindProperty(SupportsGet = true)] public bool CanViewBoard { get; set; }
        [BindProperty(SupportsGet = true)] public bool InvalidID { get; set; }
        [BindProperty(SupportsGet = true)] public int? JobID { get; set; }

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
        public void OnPost(string TASID)
        {
            CanViewBoard = ValidTASMembershipIDs.Contains(TASID);
            if (!CanViewBoard) InvalidID = InvalidTASMembershipIDs.Contains(TASID);
        }

        public void GetSpecificJob(int JobID)
        {
        }
    }
}