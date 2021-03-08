using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellerWiki.Data;
using TravellerWiki.Data.Services.CareerService;

namespace TravellerWiki
{
    public class CareerModel : PageModel
    {
        public TravellerCareer Career;
        private TravellerCareerService careerService = new TravellerCareerService();
        
        [HttpGet("{career}")]
        public void OnGet(string career)
        {
            if (!string.IsNullOrEmpty(career))
            {
                var careers = careerService.GetCareers();
                Career = careers.First(x => x.CareerName == career);
            }
        }
    }
}