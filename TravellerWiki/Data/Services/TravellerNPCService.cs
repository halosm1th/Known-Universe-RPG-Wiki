using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public class TravellerNPCService
    {



        private static readonly TravellerNameService nameService = new TravellerNameService();

        private Dictionary<string, int> GetBackgroundSkillsAsync(int background) =>
            background switch
            { 
                0 => new Dictionary<string,int>()
                {
                    {"Str", -1},
                    {"Dex", +1},
                    {"Edu", -1},
                    {"Profession (belter)", 2},
                    {"Jack-of-All-Trades", 1},
                    {"Vacc Suit",1},
                    {"Astrogation", 0},
                    {"Carouse", 0},
                    {"Electronics", 0},
                    {"Mechanic", 0},
                    {"Medic", 0},
                    {"Recon", 0},
                    {"Science", 0},
                },
                1 => new Dictionary<string, int>()
                {
                    {"End", +1},
                    {"Edu", -1},
                    {"Survival", 2},
                    {"Athletics (strength)", 1},
                    {"Jack-of-All-Trades",1},
                    {"Gun Combat (slug)", 1},
                    {"Drive", 0},
                    {"Navigation", 0},
                    {"Mechanic", 0},
                    {"Medic", 0},
                    {"Recon", 0},
                    {"Profession", 0},
                },
                2 => new Dictionary<string, int>()
                {
                    {"Edu", +1},
                    {"Admin", 1},
                    {$@"Electronics {((background/2==0)? "Comms" : "Computers")}", 1},
                    {"Profession (any)",1},
                    {"Drive (wheel)", 1},
                    {"Science (any)", 1},
                    {"art", 0},
                    {"Advocate", 0},
                    {"Diplomat", 0},
                    {"Flyer", 0},
                    {"Streetwise", 0},
                },
                3 => new Dictionary<string, int>()
                {
                    {"Edu", -2},
                    {"Dex", +1},
                    {"Soc", -2},
                    {"Streetwise", 2},
                    {"Athletics (dexterity)", 1},
                    {"Deception",1},
                    {"Melee (Unarmed)", 1},
                    {"Gambler", 0},
                    {"Gun combat", 0},
                    {"Recon", 0},
                    {"Stealth", 0},
                },
                4 => new Dictionary<string, int>()
                {
                    {"Edu", -3},
                    {"End", +2},
                    {"Language (Local Dialect)", 2},
                    {"Profession (Any suitable)", 2},
                    {"Survival",1},
                    {"Animals (Any)", 1},
                    {"Athletics", 0},
                    {"Gun combat (archaic)", 1},
                    {"Carouse", 0},
                    {"Melee (any)", 1},
                    {"Navigation", 0},
                    {"Recon", 0},
                    {"Steward", 0},
                    {"Streetwise", 0},
                },
                5 => new Dictionary<string, int>()
                {
                    {"Str", -1},
                    {"Edu", +2},
                    {"End", +1},
                    {"Profession (Any)", 2},
                    {"Admin",1},
                    {"Diplomat", 1},
                    {$@"Electronics {((background/2==0)? "Comms" : "Computers")}", 1},
                    {"Streetwise", 1},
                    {"Advocate", 0},
                    {"Broker", 0},
                    {"Carouse", 0},
                    {"Drive", 0},
                },
                6 => new Dictionary<string, int>()
                {
                    {"Dex", +1},
                    {"Edu", +1},
                    {"End", -1},
                    {"Profession (Any)", 1},
                    {"Athletics (Dexterity)",1},
                    {"Engineering (Life Support)", 1},
                    {"Admin", 0},
                    {"Astrogation", 0},
                    {"Mechanic", 0},
                    {"Science", 0},
                    {"Steward", 0},
                    {"Vacc Suit", 0},
                },
                7 => new Dictionary<string, int>()
                {
                    {"End", +1},
                    {"Seafarer  (Any)", 2},
                    {"Navigation",1},
                    {"Profession  (Any)", 1},
                    {"Admin", 0},
                    {"Recon ", 1},
                    {"Athletics ", 0},
                    {"Electronics ", 0},
                    {"Carouse ", 0},
                    {"Survival  Suit", 0},
                },
            };
        private Dictionary<string, int> GetCareerSkillsAsync(int career) =>
            career switch
            {
                0 => new Dictionary<string, int>()
                {
                    {"Edu", +1},
                    {"Soc", +1},
                    {"Admin", 3},
                    {"Advocate", 1},
                    {"Broker",1},
                    {"Carouse", 1},
                    {"Diplomat", 1},
                    {"Electronics (computers)", 1},
                    {"Art", 0},
                    {"Drive", 0},
                    {"Leadership", 0},
                    {"Profession", 0},
                    {"Science", 0},
                },
                1 => new Dictionary<string, int>()
                {
                    {"Int", +1},
                    {"Streetwise", 2},
                    {"Investigate", 2},
                    {"Electronics (comms)", 1},
                    {"Carouse",1},
                    {"Deception", 1},
                    {"Persuade", 0},
                    {"Recon", 0},
                    {"Stealth", 0},
                    {"Advocate", 0},
                    {"Drive", 0},
                    {"Melee", 0},
                    {"Gun Combat", 0},
                },
                2 => new Dictionary<string, int>()
                {
                    {"Str", +1},
                    {"End", +2},
                    {"Melee (Blade)", 2},
                    {"Survival", 2},
                    {"Animals (any)", 1},
                    {"Profession (any suitable)",1},
                    {"Recon", 1},
                    {"Athletics (any)", 0},
                    {"Carouse", 0},
                    {"Navigation", 0},
                    {"Stealth", 0},
                    {"Seafarer", 0},
                },
                3 => new Dictionary<string, int>()
                {
                    {"Edu", +1},
                    {"Electronics (computer)", 1},
                    {"Streetwise", 1},
                    {"Drive (any)", 1},
                    {"Profession (any)",2},
                    {"Flyer (any)", 1},
                    {"Science (any)", 1},
                    {"Advocate", 0},
                    {"Art", 0},
                    {"Carouse", 0},
                    {"Deception", 0},
                    {"Diplomat", 0},
                    {"Mechanic", 0},
                    {"Medic", 0},
                    {"Persuade", 0},
                },
                4 => new Dictionary<string, int>()
                {
                    {"Dex", +1},
                    {"Soc", -2},
                    {"Vacc Suit",2},
                    {"Athletics (dexterity)",1},
                    {"Gun Combat (any)", 1},
                    {"Gunner",1},
                    {"Electronics (any)",1},
                    {"Mechanic",1},
                    {"Melee (any)",1},
                    {"Deception",0},
                    {"Engineer",0},
                    {"Explosives",0},
                    {"Medic",0},
                    {"Recon",0},
                    {"Streetwise",0},
                },
                5 => new Dictionary<string, int>()
                {
                    {"Dex", +1},
                    {"Edu", +1},
                    {"Vacc Suit",2},
                    {"Gun Combat (any)", 2},
                    {"Gunner",1},
                    {"Electronics",0},
                    {"Athletics",0},
                    {"Melee (Blade)",1},
                    {"Heavy Weapons",0},
                    {"Explosives",0},
                    {"Medic",0},
                    {"Recon",0},
                },
                6 => new Dictionary<string, int>()
                {
                    {"Soc", +1},
                    {"Medic",3},
                    {"Admin", 2},
                    {"Electronics (computer)",1},
                    {"Investigate",1},
                    {"Persuade",1},
                    {"Science (Any)",1},
                    {"Heavy Advocate",0},
                    {"Diplomat",0},
                    {"Drive",0},
                    {"Flyer",0},
                },
                7 => new Dictionary<string, int>()
                {
                    {"End", +2},
                    {"Gun Combat (any)", 3},
                    {"Athletics (endurance)",1},
                    {"Explosives",1},
                    {"Recon",1},
                    {"Heavy Weapons",1},
                    {"Mechanic",1},
                    {"Drive",0},
                    {"Electronics",0},
                    {"Medic",0},
                    {"Melee",0},
                    {"Sealth",0},
                },
                8 => new Dictionary<string, int>()
                {
                    {"Edu", +1},
                    {"Leadership", 2},
                    {"Admin",1},
                    {"Diplomat",1},
                    {"Gun Combat (any)",1},
                    {"Tactics (military)",1},
                    {"Athletics (endurance)",1},
                    {"Heavy Weapons",1},
                    {"Recon",1},
                    {"Drive",0},
                    {"Electronics",0},
                    {"Medic",0},
                    {"Stealth",0},
                },
                9 => new Dictionary<string, int>() {
                    {"Edu",1},
                    {"Leadership", 2},
                    {"Diplomat", 2},
                    {"Admin", 1},
                    {"Advocate", 1},
                    {"Carouse", 1},
                    {"Persuade", 1},
                    {"Art", 0},
                    {"Broker", 0}, 
                    {"Deception", 0},
                    {"Gambler", 0}
                },
                10 => new Dictionary<string, int>()
                {
                    {"Int",1},
                    {"Art (any)", 3},
                    {"Carouse", 2},
                    {"Deception", 1},
                    {"Persuade", 1},
                    {"Streetwise", 1},
                    {"Steward", 1},
                    {"Athletics", 0},
                    {"Broker", 0},
                    {"Gambler", 0},
                    {"Profession", 0}
                },
                11 => new Dictionary<string, int>()
                {
                    {"Int",1},
                    {"Soc",-1},
                    {"Stealth", 2},
                    {"Streetwise", 2},
                    { "Deception", 1},
                    {" Gambler", 1},
                    {"Melee (any)", 1},
                    {"Recon", 1},
                    {"Athletics", 0},
                    {"Electronics", 0},
                    { "Gun Combat", 0},
                    {"Persuade", 0}
                },
                12 => new Dictionary<string, int>()
                {
                    {"Int",1},
                    {"Edu",1},
                    {"Science (any)", 3},
                    {"Investigate",2},
                    { "Electronics (computers)", 1},
                    {"Science (any other)", 1},
                    {"Persuade", 1},
                    {"Art", 0},
                    {"Diplomat", 0},
                    {"Drive", 0},
                    {"Medic", 0},
                    {"Navigation", 0},
                    {"Profession", 0}
                },
                13 => new Dictionary<string, int>()
                {
                    {"Int",1},
                    {"Astrogation", 1},
                    { "Pilot (starship)", 1},
                    {"Electronics (computers)", 1},
                    { "Engineer (any)", 1},
                    { "Jack-of-all-Trades", 1},
                    { "Streetwise", 1},
                    { "Vacc Suit", 1},
                    { "Carouse", 0},
                    { "Drive", 0},
                    { "Gun Combat", 0},
                    { "Medic", 0},
                    {"Investigate", 0},
                    { "Recon", 0}
                },
                14 => new Dictionary<string, int>()
                {
                    {"Dex",1},
                    {"Vacc Suit", 3},
                    { "Athletics (any)", 1},
                    { "Electronics (any)", 1},
                    { "Engineer (any)", 1},
                    { "Mechanic", 1},
                    { "Steward", 1},
                    { "Gunner", 0},
                    { "Pilot", 0},
                    { "Medic", 0},
                    { "Persuade", 0}
                },
                15 => new Dictionary<string, int>()
                {
                    {"Int",1},
                    { "Pilot (starship)", 2},
                    { "Admin", 1},
                    { "Astrogation", 1},
                    { "Electronics (sensors)", 1},
                    { "Gunner", 1},
                    { "Vacc Suit", 1},
                    { "Advocate", 0},
                    { "Broker", 0},
                    { "Leadership", 0},
                    { "Persuade", 0},
                    { "Tactics", 0}
                },
                16 => new Dictionary<string, int>()
                {
                    { "Streetwise", 2},
                    { "Melee (unarmed)", 1},
                    { "Recon", 1},
                    { "Stealth", 1},
                    { "Steward", 1},
                    { "Vacc Suit", 1},
                    { "Carouse", 0},
                    { "Deception", 0},
                    { "Drive", 0},
                    { "Gun Combat", 0},
                    { "Mechanic", 0},
                    { "Profession", 0},
                    { "Survival", 0}
                },
            };

        private List<string> PatronTypeList = new List<string>()
        {
            "Assassin","Merchant","Smuggler","Free Trader","Terrorist","Broker","Embezzler","Corporate Executive","Thief",
            "Corporate Agent","Revolutionary","Financier","Clerk","Belter","Administrator","Researcher","Mayor","Naval Officer","Minor Noble","Pilot","Physician","Starport Administrator",
            "Tribal Leader","Scout","Diplomat","Alien","Courier","Playboy","Spy","Stowaway","Ambassador","Family Relative","Noble","Agent of a Foreign Power","Police Officer","Imperial Agent"
        }; 
        
        private List<string> CharacterQuirkList = new List<string>()
        {
            "Loyal",
            "Distracted by other worries",
            "Unusually provincial",
            "In debt to criminals",
            "Drunkard or drug addict",
            "Makes very bad jokes","Government informant","Will betray characters",
            "Mistakes a Traveller for someone else","Aggressive",
            "Possesses unusually advanced technology","Has secret allies",
            "Unusually handsome or beautiful",
            "Secret anagathic user","Spying on the Travellers","Looking for something",
            "Possesses TAS membership",
            "Helpful",
            "Is secretly hostile towards the Travellers",
            "Forgetful",
            "Wants to borrow money",
            "Wants to hire the Travellers",
            "Is convinced the Travellers are dangerous",
            "Has useful contacts","Involved in political intrigue","Artistic",
            "Has a dangerous secret","Easily confused",
            "Wants to get off planet as soon as possible","Unusually ugly",
            "Attracted to a Traveller","Worried about current situation","From offworld","Shows pictures of his children",
            "Possesses telepathy or other unusual quality"
        };

        private async Task<string> GetName(TravellerNameService.NationNameList nationList)
        {
            return nameService.GetNames(1, nationList)[0] ?? "Error";
        }

        private string GetBackgroundName(int background)
            => background switch
            {
                0 => "Belter",
                1 => "Colonist",
                2 => "Developed World",
                3 => "Fringe",
                4 => "Low-Tech",
                5 => "Metropolis",
                6 => "Space Habitat",
                7 => "Water World",
            };

        private string GetCareerName(int career)
            => career switch
            {
                0 => "ADMINISTRATOR",
                1 => "AGENT",
                2 => "BARBARIAN",
                3 => "CITIZEN",
                4 => "CORSAIR",
                5 => "MARINE",
                6 => "MEDIC",
                7 => "MILITARY (ENLISTED)",
                8 => "MILITARY (OFFICER)",
                9 => "NOBLE",
                10 => "PERFORMER",
                11 => "ROGUE",
                12 => "SCHOLAR",
                13 => "SCOUT",
                14 => "SPACER (CREW)",
                15 => "SPACER (COMMAND)",
                16 => "WANDERER",
            };

        private static Random rand = new Random();


        public async Task<List<TravellerNPC>>GetNPCAsync(int npcCount, TravellerNameService.NationNameList nationNameList)
        {
            var npcList = new List<TravellerNPC>();

            try
            {
                for (int i = 0; i < npcCount; i++)
                {
                    var npc = await TravellerNpc(nationNameList);
                    npcList.Add(npc);
                }

            }
            catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            return npcList;
        }

        protected async Task<TravellerNPC> TravellerNpc(TravellerNameService.NationNameList nationNameList)
        {
            var background = rand.Next(0, 8);
            var career = rand.Next(0, 16);

            var skillList = SkillList(background, career, rand);
            var attributeList = AttributeList(skillList,rand);

            var name = await GetName(nationNameList);
            var backgroundName = GetBackgroundName(background);
            var careerName = GetCareerName(career);

            var patron = PatronTypeList[rand.Next(0, PatronTypeList.Count)];
            var quirk = CharacterQuirkList[rand.Next(0, CharacterQuirkList.Count)];

            var npc = new TravellerNPC
            {
                SkillList = skillList,
                AttributeList = attributeList,
                Name = name,
                Background = backgroundName,
                Career = careerName,
                PatronText = patron,
                QuirkText = quirk
            };
            return npc;
        }

        private List<TravellerAttribute> AttributeList(List<TravellerSkill> skills, Random rng)
        {
            var attributes = new List<TravellerAttribute>();

            attributes.Add(GenerateAttributeFromSkills("Str",skills, rng));
            attributes.Add(GenerateAttributeFromSkills("Dex",skills, rng));
            attributes.Add(GenerateAttributeFromSkills("End",skills, rng));
            attributes.Add(GenerateAttributeFromSkills("Int",skills, rng));
            attributes.Add(GenerateAttributeFromSkills("Edu",skills, rng));
            attributes.Add(GenerateAttributeFromSkills("Soc",skills, rng));


            return attributes;
        }

        private TravellerAttribute GenerateAttributeFromSkills(string attributeName, List<TravellerSkill> skills, Random rng)
        {
            int attMod = 0;
            if (skills.Any(skill => skill.SkillName == attributeName))
            {
                attMod = skills.Where(skill => skill.SkillName == attributeName)
                    .Select(skill => skill.SkillValue).Aggregate(0, (h, t) => h + t);
            }

            var attribute = GetAttribute(attributeName);

            return new TravellerAttribute(attribute, rng.Next(2, 13) + attMod);
        }

        private TravellerAttributes GetAttribute(string shortHand)
         {
             switch (shortHand)
             {
                case "Dex":
                    return TravellerAttributes.Dexterity;
                    
                case "End":
                    return TravellerAttributes.Endurance;
                case "Int":
                    return TravellerAttributes.Intelligence;
                case "Edu":
                    return TravellerAttributes.Education;
                case "Soc":
                    return TravellerAttributes.Social;
                case "Psi":
                    return TravellerAttributes.Psionics;
                case "San":
                    return TravellerAttributes.Sanity;
                case "Str":
                default:
                    return TravellerAttributes.Strength;
            }
         }

        private List<TravellerSkill> SkillList(int background, int career, Random rng)
        {
            var backgroundStats = GetBackgroundSkillsAsync(background);
            var careerStats = GetCareerSkillsAsync(career);

            var skillList = new List<TravellerSkill>();

            foreach (var skill in backgroundStats)
            {
                skillList.Add(new TravellerSkill(skill.Key, skill.Value));
            }

            foreach (var skill in careerStats)
            {
                if (skillList.Any(listSkill => listSkill.SkillName == skill.Key))
                {
                    skillList.First(listSkill => listSkill.SkillName == skill.Key).SkillValue += skill.Value == 0 ? 1 : skill.Value;
                }
                else
                {
                    skillList.Add(new TravellerSkill(skill.Key,skill.Value));
                }
            }

            return skillList;
        }
    }
}
