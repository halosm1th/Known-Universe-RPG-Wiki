using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TravellerWiki
{
    public class SearchModel : PageModel
    {
        private static readonly Dictionary<string, string> PageCrosses = GetPageCrosses();

        //Name,Data
        public Dictionary<string, string> SearchResults { get; set; }

        [BindProperty] public string SearchString { get; set; }

        public void OnGet()
        {
        }


        public IActionResult DisplayResults()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (SearchString != null)
                foreach (var page in PageCrosses)
                    if (page.Value.Contains(SearchString))
                    {
                        if (SearchResults == null)
                        {
                            SearchResults = new Dictionary<string, string>();
                            SearchResults[page.Key] = page.Value;
                        }
                        else
                        {
                            SearchResults[page.Key] = page.Value;
                        }
                    }

            return Page();
        }

        private static Dictionary<string, string> GetPageCrosses()
        {
            List<string> _PageNames =
                Directory.GetFiles(Directory.GetCurrentDirectory() + "/Pages/").ToList();
            _PageNames = _PageNames.Where(page => page.Contains(".razor")).ToList();

            List<string> _PageValues =
                _PageNames.Where(page => page.EndsWith(".razor")).Select(System.IO.File.ReadAllText).ToList();

            _PageNames = _PageNames.Select(name
                    => name.Remove(0,
                        name.IndexOf("/Pages/") + "/Pages/".Length))
                .Select(name => name.Replace(".razor", ""))
                .ToList();
            var pageCrosses = new Dictionary<string, string>();

            for (var i = 0; i < _PageNames.Count; i++) pageCrosses[_PageNames[i]] = _PageValues[i];

            return pageCrosses;
        }
    }
}