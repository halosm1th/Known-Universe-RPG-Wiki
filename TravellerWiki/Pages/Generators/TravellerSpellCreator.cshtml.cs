using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WikiServices.InformationServices;

namespace TravellerWiki
{
    public class TravellerSpellCreatorModel : PageModel
    {
        [BindProperty]
        public bool HasSpell
        {
            get => _hasSpell;
            set => _hasSpell = value;
        }

        public TravellerSpellCreatorModel()
        {
        }

        private bool _hasSpell = false;
        [BindProperty] public string SpellText { get; set; }

        public void OnGet(int nation, int plane, int action,int target, int modifier, int requestedSpell = 0)
        {
            if (requestedSpell == 1)
            {
                var magicSystem = new TravellerFreeFormMagicSystemsService();

                var Nation = (FreeFormLanguages) nation-1;

                var sb = new StringBuilder();
                sb.Append(magicSystem.GetPlanesWords(Nation).Keys.ToList()[plane-1]);
                sb.Append(" ");

                sb.Append(magicSystem.GetActionWords(Nation).Keys.ToList()[action-1]);
                sb.Append(" ");
                sb.Append(magicSystem.GetTargetWords(Nation).Keys.ToList()[target-1]);

                if (modifier > 0)
                {
                    sb.Append(" ");
                    sb.Append(magicSystem.GetModifiersWords(Nation).Keys.ToList()[modifier-1]);
                }

                SpellText = sb.ToString();
                HasSpell = true;
            }
        }
    }
}