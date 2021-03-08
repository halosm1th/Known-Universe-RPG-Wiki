using System.Collections.Generic;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public class TravellerRewardSkillAny : TravellerRewardSkill
    {
        public TravellerRewardSkillAny() : base(new List<TravellerSkills>())
        {
            AddSkills(new List<TravellerSkills>
            {
                TravellerSkills.Admin,
                TravellerSkills.Advocate,
                TravellerSkills.AetherSwap,
                TravellerSkills.AetherTalk,
                TravellerSkills.AetherWalk,
                TravellerSkills.Animals,
                TravellerSkills.Art,
                TravellerSkills.Astrogation,
                TravellerSkills.Athletics,
                TravellerSkills.Broker,
                TravellerSkills.Carouse,
                TravellerSkills.Circle,
                TravellerSkills.Deception,
                TravellerSkills.Diplomat,
                TravellerSkills.Drive,
                TravellerSkills.Electronics,
                TravellerSkills.Engineer,
                TravellerSkills.Explosives,
                TravellerSkills.Flyer,
                TravellerSkills.FreeForm,
                TravellerSkills.Gambler,
                TravellerSkills.GunCombat,
                TravellerSkills.Gunner,
                TravellerSkills.HeavyWeapons,
                TravellerSkills.Investigate,
                TravellerSkills.Language,
                TravellerSkills.Leadership,
                TravellerSkills.LifeCreate,
                TravellerSkills.LifeDrain,
                TravellerSkills.LifeWalk,
                TravellerSkills.Luck,
                TravellerSkills.Mechanic,
                TravellerSkills.Medic,
                TravellerSkills.Melee,
                TravellerSkills.Navigation,
                TravellerSkills.Persuade,
                TravellerSkills.Pilot,
                TravellerSkills.Profession,
                TravellerSkills.Recon,
                TravellerSkills.Religion,
                TravellerSkills.Science,
                TravellerSkills.Seafarer,
                TravellerSkills.SigmarsAid,
                TravellerSkills.SigmarsAir,
                TravellerSkills.SigmarsFreeze,
                TravellerSkills.SigmarsFlame,
                TravellerSkills.SigmarsGuidance,
                TravellerSkills.SigmarsHand,
                TravellerSkills.SigmarsKnowledge,
                TravellerSkills.SigmarsLight,
                TravellerSkills.SigmarsWater,
                TravellerSkills.SoulSight,
                TravellerSkills.SoulLink,
                TravellerSkills.SoulSwap,
                TravellerSkills.Stealth,
                TravellerSkills.Steward,
                TravellerSkills.Streetwise,
                TravellerSkills.Survival,
                TravellerSkills.Tactics,
                TravellerSkills.VaccSuit
            });
        }
    }
}