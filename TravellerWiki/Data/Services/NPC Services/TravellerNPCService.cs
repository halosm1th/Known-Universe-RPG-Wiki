using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TravellerWiki.Data.Charcters;
using static TravellerWiki.Data.Charcters.TravellerSkills;
using static TravellerWiki.Data.Charcters.TravellerAttributes;

namespace TravellerWiki.Data
{
    public class TravellerNPCService
    {



        private static readonly TravellerNameService nameService = new TravellerNameService();

        private List<TravellerAttribute> GetBackgroundAttributesAsync(int background) =>
             background switch
             {
                 0 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Strength, -1),
                    new TravellerAttribute(Dexterity, +1),
                    new TravellerAttribute(Education, -1),
                },
                 1 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Endurance, +1),
                    new TravellerAttribute(Education, -1),
                },
                 2 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Education, +1),
                },
                 3 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Education, -2),
                    new TravellerAttribute(Dexterity, +1),
                    new TravellerAttribute(Social, -2),
                },
                 4 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Education, -3),
                    new TravellerAttribute(Endurance, +2),
                },
                 5 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Strength, -1),
                    new TravellerAttribute(Education, +2),
                    new TravellerAttribute(Endurance, +1),
                },
                 6 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Dexterity, +1),
                    new TravellerAttribute(Education, +1),
                    new TravellerAttribute(Endurance, -1),
                },
                 7 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Endurance, +1),
                },
                 _ => new List<TravellerAttribute>(),
             };

        private List<TravellerSkill> GetBackgroundSkillsAsync(int background) =>
            background switch
            {
                0 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Profession_Belter, 2),
                    new TravellerSkill(JackOfAllTrades, 1),
                    new TravellerSkill(VaccSuit,1),
                    new TravellerSkill(Astrogation, 0),
                    new TravellerSkill(Carouse, 0),
                    new TravellerSkill(Electronics, 0),
                    new TravellerSkill(Mechanic, 0),
                    new TravellerSkill(Medic, 0),
                    new TravellerSkill(Recon, 0),
                    new TravellerSkill(Science, 0)
                },
                1 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Survival, 2),
                    new TravellerSkill(Athletics_Strength, 1),
                    new TravellerSkill(JackOfAllTrades,1),
                    new TravellerSkill(GunCombat_Slug, 1),
                    new TravellerSkill(Drive, 0),
                    new TravellerSkill(Navigation, 0),
                    new TravellerSkill(Mechanic, 0),
                    new TravellerSkill(Medic, 0),
                    new TravellerSkill(Recon, 0),
                    new TravellerSkill(Profession, 0),
                },
                2 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Electronics_Comms, 1),
                    new TravellerSkill(Profession,1),
                    new TravellerSkill(Drive_Wheel, 1),
                    new TravellerSkill(Science, 1),
                    new TravellerSkill(Art, 0),
                    new TravellerSkill(Advocate, 0),
                    new TravellerSkill(Diplomat, 0),
                    new TravellerSkill(Flyer, 0),
                    new TravellerSkill(Streetwise, 0),
                },
                3 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Streetwise, 2),
                    new TravellerSkill(Athletics_Dexterity, 1),
                    new TravellerSkill(Deception,1),
                    new TravellerSkill(Melee_Unarmed, 1),
                    new TravellerSkill(Gambler, 0),
                    new TravellerSkill(GunCombat, 0),
                    new TravellerSkill(Recon, 0),
                    new TravellerSkill(Stealth, 0),
                },
                4 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Language, 2),
                    new TravellerSkill(Profession, 2),
                    new TravellerSkill(Survival,1),
                    new TravellerSkill(Animals, 1),
                    new TravellerSkill(Athletics, 0),
                    new TravellerSkill(GunCombat_Archaic, 1),
                    new TravellerSkill(Carouse, 0),
                    new TravellerSkill(Melee, 1),
                    new TravellerSkill(Navigation, 0),
                    new TravellerSkill(Recon, 0),
                    new TravellerSkill(Steward, 0),
                    new TravellerSkill(Streetwise, 0)
                },
                5 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Profession, 2),
                    new TravellerSkill(Admin,1),
                    new TravellerSkill(Diplomat, 1),
                    new TravellerSkill(Electronics_Comms),
                    new TravellerSkill(Streetwise, 1),
                    new TravellerSkill(Advocate, 0),
                    new TravellerSkill(Broker, 0),
                    new TravellerSkill(Carouse, 0),
                    new TravellerSkill(Drive, 0),
                },
                6 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Profession, 1),
                    new TravellerSkill(Athletics_Dexterity,1),
                    new TravellerSkill(Engineer_LifeSupport, 1),
                    new TravellerSkill(Admin, 0),
                    new TravellerSkill(Astrogation, 0),
                    new TravellerSkill(Mechanic, 0),
                    new TravellerSkill(Science, 0),
                    new TravellerSkill(Steward, 0),
                    new TravellerSkill(VaccSuit, 0)
                },
                7 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Seafarer, 2),
                    new TravellerSkill(Navigation,1),
                    new TravellerSkill(Profession, 1),
                    new TravellerSkill(Admin, 0),
                    new TravellerSkill(Recon , 1),
                    new TravellerSkill(Athletics , 0),
                    new TravellerSkill(Electronics , 0),
                    new TravellerSkill(Carouse , 0),
                    new TravellerSkill(VaccSuit, 0)
                },
                _ => new List<TravellerSkill>(),
            };

        private List<TravellerAttribute> GetCareerAttributesAsync(int career) =>
            career switch
            {
                0 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Education, +1),
                    new TravellerAttribute(Social, +1),
                },
                1 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Intelligence, +1),
                },
                2 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Strength, +1),
                    new TravellerAttribute(Endurance, +2),
                },
                3 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Education, +1),
                },
                4 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Dexterity, +1),
                    new TravellerAttribute(Social, -2),
                },
                5 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Dexterity, +1),
                    new TravellerAttribute(Education, +1),
                },
                6 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Social, +1),
                },
                7 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Endurance, +2),
                },
                8 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Education, +1),
                },
                9 => new List<TravellerAttribute>() {
                    new TravellerAttribute (Education,1),
                },
                10 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Intelligence,1),
                },
                11 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Intelligence,1),
                    new TravellerAttribute(Social,-1),
                },
                12 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Intelligence,1),
                    new TravellerAttribute(Education,1),
                },
                13 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Intelligence,1),
                },
                14 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Dexterity,1),
                },
                15 => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Intelligence,1),
                },
                16 => new List<TravellerAttribute>()
                {
                },
                _ => new List<TravellerAttribute>(),
            };
        private List<TravellerSkill> GetCareerSkillsAsync(int career) =>
            career switch
            {
                0 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Admin, 3),
                    new TravellerSkill(Advocate, 1),
                    new TravellerSkill(Broker,1),
                    new TravellerSkill(Carouse, 1),
                    new TravellerSkill(Diplomat, 1),
                    new TravellerSkill(Electronics_Computers, 1),
                    new TravellerSkill(Art, 0),
                    new TravellerSkill(Drive, 0),
                    new TravellerSkill(Leadership, 0),
                    new TravellerSkill(Profession, 0),
                    new TravellerSkill(Science, 0),
                },
                1 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Streetwise, 2),
                    new TravellerSkill(Investigate, 2),
                    new TravellerSkill(Electronics_Comms, 1),
                    new TravellerSkill(Carouse,1),
                    new TravellerSkill(Deception, 1),
                    new TravellerSkill(Persuade, 0),
                    new TravellerSkill(Recon, 0),
                    new TravellerSkill(Stealth, 0),
                    new TravellerSkill(Advocate, 0),
                    new TravellerSkill(Drive, 0),
                    new TravellerSkill(Melee, 0),
                    new TravellerSkill(GunCombat, 0),
                },
                2 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Melee_Blade, 2),
                    new TravellerSkill(Survival, 2),
                    new TravellerSkill(Animals, 1),
                    new TravellerSkill(Profession,1),
                    new TravellerSkill(Recon, 1),
                    new TravellerSkill(Athletics, 0),
                    new TravellerSkill(Carouse, 0),
                    new TravellerSkill(Navigation, 0),
                    new TravellerSkill(Stealth, 0),
                    new TravellerSkill(Seafarer, 0),
                },
                3 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Electronics_Computers, 1),
                    new TravellerSkill(Streetwise, 1),
                    new TravellerSkill(Drive, 1),
                    new TravellerSkill(Profession,2),
                    new TravellerSkill(Flyer, 1),
                    new TravellerSkill(Science, 1),
                    new TravellerSkill(Advocate, 0),
                    new TravellerSkill(Art, 0),
                    new TravellerSkill(Carouse, 0),
                    new TravellerSkill(Deception, 0),
                    new TravellerSkill(Diplomat, 0),
                    new TravellerSkill(Mechanic, 0),
                    new TravellerSkill(Medic, 0),
                    new TravellerSkill(Persuade, 0),
                },
                4 => new List<TravellerSkill>()
                {
                    new TravellerSkill(VaccSuit,2),
                    new TravellerSkill(Athletics_Dexterity,1),
                    new TravellerSkill(GunCombat, 1),
                    new TravellerSkill(Gunner,1),
                    new TravellerSkill(Electronics,1),
                    new TravellerSkill(Mechanic,1),
                    new TravellerSkill(Melee,1),
                    new TravellerSkill(Deception,0),
                    new TravellerSkill(Engineer,0),
                    new TravellerSkill(Explosives,0),
                    new TravellerSkill(Medic,0),
                    new TravellerSkill(Recon,0),
                    new TravellerSkill(Streetwise,0),
                },
                5 => new List<TravellerSkill>()
                {
                    new TravellerSkill(VaccSuit,2),
                    new TravellerSkill(GunCombat, 2),
                    new TravellerSkill(Gunner,1),
                    new TravellerSkill(Electronics,0),
                    new TravellerSkill(Athletics,0),
                    new TravellerSkill(Melee_Blade,1),
                    new TravellerSkill(HeavyWeapons,0),
                    new TravellerSkill(Explosives,0),
                    new TravellerSkill(Medic,0),
                    new TravellerSkill(Recon,0),
                },
                6 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Admin, 2),
                    new TravellerSkill(Electronics_Computers,1),
                    new TravellerSkill(Investigate,1),
                    new TravellerSkill(Persuade,1),
                    new TravellerSkill(Science,1),
                    new TravellerSkill(Advocate,0),
                    new TravellerSkill(Diplomat,0),
                    new TravellerSkill(Drive,0),
                    new TravellerSkill(Flyer,0),
                },
                7 => new List<TravellerSkill>()
                {
                    new TravellerSkill(GunCombat, 3),
                    new TravellerSkill(Athletics_Endurance,1),
                    new TravellerSkill(Explosives,1),
                    new TravellerSkill(Recon,1),
                    new TravellerSkill(HeavyWeapons,1),
                    new TravellerSkill(Mechanic,1),
                    new TravellerSkill(Drive,0),
                    new TravellerSkill(Electronics,0),
                    new TravellerSkill(Medic,0),
                    new TravellerSkill(Melee,0),
                    new TravellerSkill(Stealth,0),
                },
                8 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Leadership, 2),
                    new TravellerSkill(Admin,1),
                    new TravellerSkill(Diplomat,1),
                    new TravellerSkill(GunCombat,1),
                    new TravellerSkill(Tactics_Military,1),
                    new TravellerSkill(Athletics_Endurance,1),
                    new TravellerSkill(HeavyWeapons,1),
                    new TravellerSkill(Recon,1),
                    new TravellerSkill(Drive,0),
                    new TravellerSkill(Electronics,0),
                    new TravellerSkill(Medic,0),
                    new TravellerSkill(Stealth,0),
                },
                9 => new List<TravellerSkill>() {
                    new TravellerSkill(Leadership, 2),
                    new TravellerSkill(Diplomat, 2),
                    new TravellerSkill(Admin, 1),
                    new TravellerSkill(Advocate, 1),
                    new TravellerSkill(Carouse, 1),
                    new TravellerSkill(Persuade, 1),
                    new TravellerSkill(Art, 0),
                    new TravellerSkill(Broker, 0),
                    new TravellerSkill(Deception, 0),
                    new TravellerSkill(Gambler, 0)
                },
                10 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Art, 3),
                    new TravellerSkill(Carouse, 2),
                    new TravellerSkill(Deception, 1),
                    new TravellerSkill(Persuade, 1),
                    new TravellerSkill(Streetwise, 1),
                    new TravellerSkill(Steward, 1),
                    new TravellerSkill(Athletics, 0),
                    new TravellerSkill(Broker, 0),
                    new TravellerSkill(Gambler, 0),
                    new TravellerSkill(Profession, 0)
                },
                11 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Stealth, 2),
                    new TravellerSkill(Streetwise, 2),
                    new TravellerSkill(Deception, 1),
                    new TravellerSkill(Gambler, 1),
                    new TravellerSkill(Melee, 1),
                    new TravellerSkill(Recon, 1),
                    new TravellerSkill(Athletics, 0),
                    new TravellerSkill(Electronics, 0),
                    new TravellerSkill(GunCombat, 0),
                    new TravellerSkill(Persuade, 0)

                },
                12 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Science, 3),
                    new TravellerSkill(Investigate,2),
                    new TravellerSkill(Electronics_Computers, 1),
                    new TravellerSkill(Science, 1),
                    new TravellerSkill(Persuade, 1),
                    new TravellerSkill(Art, 0),
                    new TravellerSkill(Diplomat, 0),
                    new TravellerSkill(Drive, 0),
                    new TravellerSkill(Medic, 0),
                    new TravellerSkill(Navigation, 0),
                    new TravellerSkill(Profession, 0)
                },
                13 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Astrogation, 1),
                    new TravellerSkill( Pilot_Spacecraft, 1),
                    new TravellerSkill(Electronics_Computers, 1),
                    new TravellerSkill( Engineer, 1),
                    new TravellerSkill( JackOfAllTrades, 1),
                    new TravellerSkill( Streetwise, 1),
                    new TravellerSkill( VaccSuit, 1),
                    new TravellerSkill( Carouse, 0),
                    new TravellerSkill( Drive, 0),
                    new TravellerSkill( GunCombat, 0),
                    new TravellerSkill( Medic, 0),
                    new TravellerSkill(Investigate, 0),
                    new TravellerSkill( Recon, 0)
                },
                14 => new List<TravellerSkill>()
                {
                    new TravellerSkill(VaccSuit, 3),
                    new TravellerSkill(Athletics, 1),
                    new TravellerSkill(Electronics, 1),
                    new TravellerSkill(Engineer, 1),
                    new TravellerSkill(Mechanic, 1),
                    new TravellerSkill(Steward, 1),
                    new TravellerSkill(Gunner, 0),
                    new TravellerSkill(Pilot, 0),
                    new TravellerSkill(Medic, 0),
                    new TravellerSkill(Persuade, 0)
                },
                15 => new List<TravellerSkill>()
                {
                    new TravellerSkill(Pilot_Spacecraft, 2),
                    new TravellerSkill(Admin, 1),
                    new TravellerSkill(Astrogation, 1),
                    new TravellerSkill(Electronics_Sensors, 1),
                    new TravellerSkill(Gunner, 1),
                    new TravellerSkill(VaccSuit, 1),
                    new TravellerSkill(Advocate, 0),
                    new TravellerSkill(Broker, 0),
                    new TravellerSkill(Leadership, 0),
                    new TravellerSkill(Persuade, 0),
                    new TravellerSkill(Tactics, 0)
                },
                16 => new List<TravellerSkill>()
                {
                   new TravellerSkill(Streetwise, 2),
                   new TravellerSkill(Melee_Unarmed, 1),
                   new TravellerSkill(Recon, 1),
                   new TravellerSkill(Stealth, 1),
                   new TravellerSkill(Steward, 1),
                   new TravellerSkill(VaccSuit, 1),
                   new TravellerSkill(Carouse, 0),
                   new TravellerSkill(Deception, 0),
                   new TravellerSkill(Drive, 0),
                   new TravellerSkill(GunCombat, 0),
                   new TravellerSkill(Mechanic, 0),
                   new TravellerSkill(Profession, 0),
                   new TravellerSkill(Survival, 0)
                },
                _ =>new List<TravellerSkill>(),
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

        private string GetName(TravellerNameService.NationNameList nationList)
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
                _ => "Error",
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
                _ => "Error",
            };

        private static Random rand = new Random();


        public List<TravellerNPC> GetNPCAsync(int npcCount, TravellerNameService.NationNameList nationNameList)
        {
            var npcList = new List<TravellerNPC>();

            try
            {
                for (int i = 0; i < npcCount; i++)
                {
                    var npc = TravellerNpc(nationNameList);
                    npcList.Add(npc);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return npcList;
        }

        protected async Task<TravellerNPC> TravellerNpcAsync(string name)
        {
            var background = rand.Next(0, 8);
            var career = rand.Next(0, 16);

            var skillList = await Task.Run(() => SkillList(background, career, rand));
            var attributeList = await Task.Run(() => GetAttributeValues(AttributeList(background, career, rand), rand));

            var backgroundName = await Task.Run(() => GetBackgroundName(background));
            var careerName = await Task.Run(() => GetCareerName(career));

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

        protected TravellerNPC TravellerNpc(string name)
        {
            var background = rand.Next(0, 8);
            var career = rand.Next(0, 16);

            var skillList = SkillList(background, career, rand);
            var attributeList = GetAttributeValues(AttributeList(background, career, rand), rand);

            var backgroundName =GetBackgroundName(background);
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

        protected TravellerNPC TravellerNpc(TravellerNameService.NationNameList nationNameList)
        {
            var background = rand.Next(0, 8);
            var career = rand.Next(0, 16);

            var skillList = SkillList(background, career, rand);
            var attributeList = GetAttributeValues(AttributeList(background, career, rand), rand);

            var name = GetName(nationNameList);
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

        private List<TravellerAttribute> GetAttributeValues(List<TravellerAttribute> skills, Random rng)
        {
            var attributes = new List<TravellerAttribute>();

            attributes.Add(GenerateAttributeFromSkills(Strength, skills, rng));
            attributes.Add(GenerateAttributeFromSkills(Dexterity, skills, rng));
            attributes.Add(GenerateAttributeFromSkills(Endurance, skills, rng));
            attributes.Add(GenerateAttributeFromSkills(Intelligence, skills, rng));
            attributes.Add(GenerateAttributeFromSkills(Education, skills, rng));
            attributes.Add(GenerateAttributeFromSkills(Social, skills, rng));


            return attributes;
        }

        private List<TravellerAttribute> AttributeList(int background, int career, Random rng)
        {
            var backgroundStats = GetBackgroundAttributesAsync(background);
            var careerStats = GetCareerAttributesAsync(career);

            var attributeList = new List<TravellerAttribute>();

            foreach (var attr in backgroundStats)
            {
                attributeList.Add(attr);
            }

            foreach (var attr in careerStats)
            {
                if (attributeList.Any(attrList => attrList.AttributeName == attr.AttributeName))
                {
                    attributeList.First(attrList => attrList.AttributeName == attr.AttributeName).AttributableValue
                        += attr.AttributableValue == 0 ? 1 : attr.AttributableValue;
                }
                else
                {
                    attributeList.Add(attr);
                }
            }

            return attributeList;
        }

        private TravellerAttribute GenerateAttributeFromSkills(TravellerAttributes attributeName, List<TravellerAttribute> attributes, Random rng)
        {
            int attMod = 0;
            if (attributes.Any(attr => attr.AttributeName == attributeName))
            {
                attMod = attributes.Where(attr => attr.AttributeName == attributeName)
                    .Select(attr => attr.AttributableValue).Aggregate(0, (h, t) => h + t);
            }

            return new TravellerAttribute(attributeName, rng.Next(2, 13) + attMod);
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
