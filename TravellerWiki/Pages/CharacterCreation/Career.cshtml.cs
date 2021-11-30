using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellerCharacter.Character_Services.Career_Service;
using TravellerCharacter.CharacterCreator.Careers;

namespace TravellerWiki
{
    public class CareerModel : PageModel
    {
        public TravellerCareer Career;
        private readonly TravellerCareerService careerService = new();

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