using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using TravellerWiki.Data.Charcters;
using static TravellerWiki.Data.Charcters.TravellerSkill.TravellerSkills;

namespace TravellerWiki.Data
{
    public class TravellerNPCService
    {



        private static readonly TravellerNameService nameService = new TravellerNameService();

        private List<TravellerAttribute> getBackgroundAttributes(int background) =>

            background switch
            { 
                0 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(TravellerAttributes.Strength,-1),
                    new TravellerAttribute(TravellerAttributes.Dexterity,1),
                    new TravellerAttribute(TravellerAttributes.Education,-1),
                },
                1 => new List<TravellerAttribute>
                {
                    new TravellerAttribute(TravellerAttributes.Endurance,1),
                    new TravellerAttribute(TravellerAttributes.Education,-1),
                },
                2 => new List<TravellerAttribute>
                {
                    new TravellerAttribute(TravellerAttributes.Education,1)
                },
                3 => new List<TravellerAttribute>
                {
                    new TravellerAttribute(TravellerAttributes.Education,-2),
                    new TravellerAttribute(TravellerAttributes.Dexterity,+1),
                    new TravellerAttribute(TravellerAttributes.Social,-2),
                },
                4 => new List<TravellerAttribute>
                {
                    new TravellerAttribute(TravellerAttributes.Education,-3),
                    new TravellerAttribute(TravellerAttributes.Endurance,+2),
                },
                5 => new List<TravellerAttribute>
                {
                    new TravellerAttribute(TravellerAttributes.Strength,-1),
                    new TravellerAttribute(TravellerAttributes.Education,+2),
                    new TravellerAttribute(TravellerAttributes.Endurance,+1),
                },
                6 => new List<TravellerAttribute>
                {
                    new TravellerAttribute(TravellerAttributes.Dexterity,+1),
                    new TravellerAttribute(TravellerAttributes.Education,+1),
                    new TravellerAttribute(TravellerAttributes.Endurance,-1),

                },
                7 => new List<TravellerAttribute>
                {
                    new TravellerAttribute(TravellerAttributes.Endurance,1),
                },
                _ => new List<TravellerAttribute>()

            };

        private List<TravellerSkill> GetBackgroundSkillsAsync(int background) =>
            background switch
            { 
                0 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Profession_Belter, 2),
                    new TravellerSkill(JackOfAllTrades, 1),
                    new TravellerSkill(VaccSuit,1),
                    new TravellerSkill(Astrogation),
                    new TravellerSkill(Carouse),
                    new TravellerSkill(Electronics),
                    new TravellerSkill(Mechanic),
                    new TravellerSkill(Medic),
                    new TravellerSkill(Recon),
                    new TravellerSkill(Science),
                },
                1 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Survival,2),
                    new TravellerSkill(Athletics_Strength,1),
                    new TravellerSkill(JackOfAllTrades,1),
                    new TravellerSkill(GunCombat_Slug,1),
                    new TravellerSkill(Drive),
                    new TravellerSkill(Navigation),
                    new TravellerSkill(Mechanic),
                    new TravellerSkill(Medic),
                    new TravellerSkill(Recon),
                    new TravellerSkill(Profession),
                },
                2 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Admin,1),
                    new TravellerSkill(Electronics_Comms,1),
                    new TravellerSkill(Electronics_Computers,1),
                    new TravellerSkill(Profession,1),
                    new TravellerSkill(Drive_Wheel,1),
                    new TravellerSkill(Science,1),
                    new TravellerSkill(Art),
                    new TravellerSkill(Advocate),
                    new TravellerSkill(Diplomat),
                    new TravellerSkill(Flyer),
                    new TravellerSkill(StreetWise),
                },
                3 => new List<TravellerSkill>()
                {
                    new TravellerSkill(StreetWise,2),
                    new TravellerSkill(Athletics_Dexterity,1),
                    new TravellerSkill(Deception,1),
                    new TravellerSkill(Melee_Unarmed,1),
                    new TravellerSkill(Gambler),
                    new TravellerSkill(GunCombat),
                    new TravellerSkill(Recon),
                    new TravellerSkill(Stealth),
                },
                4 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Language,2),
                    new TravellerSkill(Profession,2),
                    new TravellerSkill(Survival,1),
                    new TravellerSkill(Athletics),
                    new TravellerSkill(Animals,1),
                    new TravellerSkill(GunCombat_Archaic,1),
                    new TravellerSkill(Carouse),
                    new TravellerSkill(Melee,1),
                    new TravellerSkill(Navigation),
                    new TravellerSkill(Recon),
                    new TravellerSkill(StreetWise),
                },
                5 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Profession,2),
                    new TravellerSkill(Admin,1),
                    new TravellerSkill(Diplomat,1),
                    new TravellerSkill(Electronics_Comms,1),
                    new TravellerSkill(Electronics_Computers,1),
                    new TravellerSkill(StreetWise,1),
                    new TravellerSkill(Advocate),
                    new TravellerSkill(Broker),
                    new TravellerSkill(Drive),
                    new TravellerSkill(Carouse),
                },
                6 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Profession,1),
                    new TravellerSkill(Athletics_Dexterity,1),
                    new TravellerSkill(Engineer_LifeSupport,1),
                    new TravellerSkill(Admin),
                    new TravellerSkill(Astrogation),
                    new TravellerSkill(Mechanic),
                    new TravellerSkill(Science_Archaeology),
                    new TravellerSkill(VaccSuit),
                    new TravellerSkill(Steward),
                },
                7 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Seafarer,2),
                    new TravellerSkill(Navigation,1),
                    new TravellerSkill(Profession,1),
                    new TravellerSkill(Recon,1),
                    new TravellerSkill(Admin),
                    new TravellerSkill(Athletics),
                    new TravellerSkill(Electronics),
                    new TravellerSkill(Carouse),
                    new TravellerSkill(VaccSuit),
                },
            };

        private List<TravellerAttribute> getCareerAttributes(int career) =>
            career switch
            {

                0 => new List<TravellerAttribute>
                {

                },
                1 => new List<TravellerAttribute>
                {

                },
                2 => new List<TravellerAttribute>
                {

                },
                3 => new List<TravellerAttribute>
                {

                },
                4 => new List<TravellerAttribute>
                {

                },
                5 => new List<TravellerAttribute>
                {

                },
                6 => new List<TravellerAttribute>
                {

                },
                7 => new List<TravellerAttribute>
                {

                },
                8 => new List<TravellerAttribute>
                {

                },
                9 => new List<TravellerAttribute>
                {

                },
                10 => new List<TravellerAttribute>
                {

                },
                11 => new List<TravellerAttribute>
                {

                },
                12 => new List<TravellerAttribute>
                {

                },
                13 => new List<TravellerAttribute>
                {

                },
                14 => new List<TravellerAttribute>
                {

                },
                15 => new List<TravellerAttribute>
                {

                },
                16 => new List<TravellerAttribute>
                {

                },
                _ => new List<TravellerAttribute>()
    };

        private List<TravellerSkill> GetCareerSkillsAsync(int career) =>
            career switch
            {
                0 => new List<TravellerSkill>()
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
                1 => new List<TravellerSkill>()
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
                2 => new List<TravellerSkill>()
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
                3 => new List<TravellerSkill>()
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
                4 => new List<TravellerSkill>()
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
                5 => new List<TravellerSkill>()
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
                6 => new List<TravellerSkill>()
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
                7 => new List<TravellerSkill>()
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
                8 => new List<TravellerSkill>()
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
                9 => new List<TravellerSkill>() {
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
                10 => new List<TravellerSkill>()
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
                11 => new List<TravellerSkill>()
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
                12 => new List<TravellerSkill>()
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
                13 => new List<TravellerSkill>()
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
                14 => new List<TravellerSkill>()
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
                15 => new List<TravellerSkill>()
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
                16 => new List<TravellerSkill>()
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
            var attributeList = AttributeList(background,career,rand);

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

        private int AttributeModifiers(TravellerAttributes attr, int background, int career)
        {
            var backAttr = getBackgroundAttributes(background);
            var carrAttr = getCareerAttributes(career);

            return backAttr.First(x => x.AttributeName == attr).AttributableValue +
                   carrAttr.First(x => x.AttributeName == attr).AttributableValue;
        }

        private List<TravellerAttribute> AttributeList(int background, int career, Random rng)
        {
            var attrList = new List<TravellerAttribute>();

            attrList.Add(new TravellerAttribute(TravellerAttributes.Strength, 
                rng.Next(2, 13) 
                + AttributeModifiers(TravellerAttributes.Strength,background,career)));

            attrList.Add(new TravellerAttribute(TravellerAttributes.Dexterity, 
                rng.Next(2, 13)
                + AttributeModifiers(TravellerAttributes.Dexterity, background, career)));

            attrList.Add(new TravellerAttribute(TravellerAttributes.Endurance, 
                rng.Next(2, 13)
                + AttributeModifiers(TravellerAttributes.Endurance, background, career)));

            attrList.Add(new TravellerAttribute(TravellerAttributes.Intelligence, 
                rng.Next(2, 13)
                + AttributeModifiers(TravellerAttributes.Intelligence, background, career)));

            attrList.Add(new TravellerAttribute(TravellerAttributes.Education, 
                rng.Next(2, 13)
                + AttributeModifiers(TravellerAttributes.Education, background, career)));
            
            attrList.Add(new TravellerAttribute(TravellerAttributes.Social, 
                rng.Next(2, 13)
                + AttributeModifiers(TravellerAttributes.Social, background, career)));

            return attrList;

        }

        private List<TravellerSkill> SkillList(int background, int career, Random rng)
        {
            var backgroundStats = GetBackgroundSkillsAsync(background);
            var careerStats = GetCareerSkillsAsync(career);

            var skillList = new List<TravellerSkill>();

            foreach (var skill in backgroundStats)
            {
                skillList.Add(skill);
            }

            foreach (var skill in careerStats)
            {
                if (skillList.Any(listSkill => listSkill.SkillName == skill.SkillName))
                {
                    skillList.First(listSkill => listSkill.SkillName == skill.SkillName).SkillValue += skill.SkillValue == 0 ? 1 : skill.SkillValue;
                }
                else
                {
                    skillList.Add(skill);
                }
            }

            return skillList;
        }
    }
}
