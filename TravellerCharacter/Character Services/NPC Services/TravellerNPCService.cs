using System;
using System.Collections.Generic;
using System.Linq;
using TravellerCharacter.CharacterCreator.Items;
using TravellerCharacter.CharacterParts;
using TravellerCharacter.CharcterTypes;
using static TravellerCharacter.CharacterParts.TravellerSkills;
using static TravellerCharacter.CharacterParts.TravellerAttributes;

namespace TravellerCharacter.Character_Services.NPC_Services
{
    public enum TravellerNPCBackgrounds
    {
        Belter,
        Colonist,
        Developed_World,
        Fringe,
        Low_Tech,
        Metropolis,
        Space_Habitat,
        Water_World,
        Error
    }

    public enum TravellerNPCCareers
    {
        Administrator,
        Agent,
        Barbarian,
        Citizen,
        Corsair,
        Marine,
        Medic,
        Military_Enlisted,
        Military_Officer,
        Noble,
        Performer,
        Rogue,
        Scholar,
        Scout,
        Spacer_Crew,
        Spacer_Command,
        Wanderer,
        Error
    }

    public class TravellerNPCService
    {
        private static readonly TravellerNameService nameService = new();

        private static Random rand = new();

        private readonly List<string> CharacterQuirkList = new()
        {
            "Loyal",
            "Distracted by other worries",
            "Unusually provincial",
            "In debt to criminals",
            "Drunkard or drug addict",
            "Makes very bad jokes", "Government informant", "Will betray characters",
            "Mistakes a Traveller for someone else", "Aggressive",
            "Possesses unusually advanced technology", "Has secret allies",
            "Unusually handsome or beautiful",
            "Secret anagathic user", "Spying on the Travellers", "Looking for something",
            "Possesses TAS membership",
            "Helpful",
            "Is secretly hostile towards the Travellers",
            "Forgetful",
            "Wants to borrow money",
            "Wants to hire the Travellers",
            "Is convinced the Travellers are dangerous",
            "Has useful contacts", "Involved in political intrigue", "Artistic",
            "Has a dangerous secret", "Easily confused",
            "Wants to get off planet as soon as possible", "Unusually ugly",
            "Attracted to a Traveller", "Worried about current situation", "From offworld",
            "Shows pictures of his children",
            "Possesses telepathy or other unusual quality"
        };

        private readonly List<string> PatronTypeList = new()
        {
            "Assassin", "Merchant", "Smuggler", "Free Trader", "Terrorist", "Broker", "Embezzler",
            "Corporate Executive",
            "Thief", "Corporate Agent", "Revolutionary", "Financier", "Clerk", "Belter", "Administrator", "Researcher",
            "Mayor", "Naval Officer", "Minor Versian Noble", "Pilot", "Physician", "Starport Administrator",
            "Tribal Leader",
            "Scout", "Diplomat", "Alien", "Courier", "Playboy", "Spy", "Stowaway", "Ambassador", "Family Relative",
            "Noble",
            "Agent of a Foreign Power", "Police Officer", "Imperial Agent", "Sigmarian Preacher",
            "Minor Federation Noble",
            "Traitor", "Ripperdoc", "Hacker", "Punk", "Magic User", "Spiritual Advisor", "Fixer", "Journalist",
            "Influencer"
        };

        private List<TravellerAttribute> GetBackgroundAttributesAsync(TravellerNPCBackgrounds background)
        {
            return background switch
            {
                TravellerNPCBackgrounds.Belter => new List<TravellerAttribute>
                {
                    new(Strength, -1),
                    new(Dexterity, +1),
                    new(Education, -1)
                },
                TravellerNPCBackgrounds.Colonist => new List<TravellerAttribute>
                {
                    new(Endurance, +1),
                    new(Education, -1)
                },
                TravellerNPCBackgrounds.Developed_World => new List<TravellerAttribute>
                {
                    new(Education, +1)
                },
                TravellerNPCBackgrounds.Fringe => new List<TravellerAttribute>
                {
                    new(Education, -2),
                    new(Dexterity, +1),
                    new(Social, -2)
                },
                TravellerNPCBackgrounds.Low_Tech => new List<TravellerAttribute>
                {
                    new(Education, -3),
                    new(Endurance, +2)
                },
                TravellerNPCBackgrounds.Metropolis => new List<TravellerAttribute>
                {
                    new(Strength, -1),
                    new(Education, +2),
                    new(Endurance, +1)
                },
                TravellerNPCBackgrounds.Space_Habitat => new List<TravellerAttribute>
                {
                    new(Dexterity, +1),
                    new(Education, +1),
                    new(Endurance, -1)
                },
                TravellerNPCBackgrounds.Water_World => new List<TravellerAttribute>
                {
                    new(Endurance, +1)
                },
                _ => new List<TravellerAttribute>()
            };
        }

        private List<TravellerSkill> GetBackgroundSkillsAsync(TravellerNPCBackgrounds background)
        {
            return background switch
            {
                TravellerNPCBackgrounds.Belter => new List<TravellerSkill>
                {
                    new(Profession_Belter, 2),
                    new(JackOfAllTrades, 1),
                    new(VaccSuit, 1),
                    new(Astrogation),
                    new(Carouse),
                    new(Electronics),
                    new(Mechanic),
                    new(Medic),
                    new(Recon),
                    new(Science)
                },
                TravellerNPCBackgrounds.Colonist => new List<TravellerSkill>
                {
                    new(Survival, 2),
                    new(Athletics_Strength, 1),
                    new(JackOfAllTrades, 1),
                    new(GunCombat_Slug, 1),
                    new(Drive),
                    new(Navigation),
                    new(Mechanic),
                    new(Medic),
                    new(Recon),
                    new(Profession)
                },
                TravellerNPCBackgrounds.Developed_World => new List<TravellerSkill>
                {
                    new(Electronics_Comms, 1),
                    new(Profession, 1),
                    new(Drive_Wheel, 1),
                    new(Science, 1),
                    new(Art),
                    new(Advocate),
                    new(Diplomat),
                    new(Flyer),
                    new(Streetwise)
                },
                TravellerNPCBackgrounds.Fringe => new List<TravellerSkill>
                {
                    new(Streetwise, 2),
                    new(Athletics_Dexterity, 1),
                    new(Deception, 1),
                    new(Melee_Unarmed, 1),
                    new(Gambler),
                    new(GunCombat),
                    new(Recon),
                    new(Stealth)
                },
                TravellerNPCBackgrounds.Low_Tech => new List<TravellerSkill>
                {
                    new(Language, 2),
                    new(Profession, 2),
                    new(Survival, 1),
                    new(Animals, 1),
                    new(Athletics),
                    new(GunCombat_Archaic, 1),
                    new(Carouse),
                    new(Melee, 1),
                    new(Navigation),
                    new(Recon),
                    new(Steward),
                    new(Streetwise)
                },
                TravellerNPCBackgrounds.Metropolis => new List<TravellerSkill>
                {
                    new(Profession, 2),
                    new(Admin, 1),
                    new(Diplomat, 1),
                    new(Electronics_Comms),
                    new(Streetwise, 1),
                    new(Advocate),
                    new(Broker),
                    new(Carouse),
                    new(Drive)
                },
                TravellerNPCBackgrounds.Space_Habitat => new List<TravellerSkill>
                {
                    new(Profession, 1),
                    new(Athletics_Dexterity, 1),
                    new(Engineer_LifeSupport, 1),
                    new(Admin),
                    new(Astrogation),
                    new(Mechanic),
                    new(Science),
                    new(Steward),
                    new(VaccSuit)
                },
                TravellerNPCBackgrounds.Water_World => new List<TravellerSkill>
                {
                    new(Seafarer, 2),
                    new(Navigation, 1),
                    new(Profession, 1),
                    new(Admin),
                    new(Recon, 1),
                    new(Athletics),
                    new(Electronics),
                    new(Carouse),
                    new(VaccSuit)
                },
                _ => new List<TravellerSkill>()
            };
        }

        private List<TravellerAttribute> GetCareerAttributesAsync(TravellerNPCCareers career)
        {
            return career switch
            {
                TravellerNPCCareers.Administrator => new List<TravellerAttribute>
                {
                    new(Education, +1),
                    new(Social, +1)
                },
                TravellerNPCCareers.Agent => new List<TravellerAttribute>
                {
                    new(Intelligence, +1)
                },
                TravellerNPCCareers.Barbarian => new List<TravellerAttribute>
                {
                    new(Strength, +1),
                    new(Endurance, +2)
                },
                TravellerNPCCareers.Citizen => new List<TravellerAttribute>
                {
                    new(Education, +1)
                },
                TravellerNPCCareers.Corsair => new List<TravellerAttribute>
                {
                    new(Dexterity, +1),
                    new(Social, -2)
                },
                TravellerNPCCareers.Marine => new List<TravellerAttribute>
                {
                    new(Dexterity, +1),
                    new(Education, +1)
                },
                TravellerNPCCareers.Medic => new List<TravellerAttribute>
                {
                    new(Social, +1)
                },
                TravellerNPCCareers.Military_Enlisted => new List<TravellerAttribute>
                {
                    new(Endurance, +2)
                },
                TravellerNPCCareers.Military_Officer => new List<TravellerAttribute>
                {
                    new(Education, +1)
                },
                TravellerNPCCareers.Noble => new List<TravellerAttribute>
                {
                    new(Education, 1)
                },
                TravellerNPCCareers.Performer => new List<TravellerAttribute>
                {
                    new(Intelligence, 1)
                },
                TravellerNPCCareers.Rogue => new List<TravellerAttribute>
                {
                    new(Intelligence, 1),
                    new(Social, -1)
                },
                TravellerNPCCareers.Scholar => new List<TravellerAttribute>
                {
                    new(Intelligence, 1),
                    new(Education, 1)
                },
                TravellerNPCCareers.Scout => new List<TravellerAttribute>
                {
                    new(Intelligence, 1)
                },
                TravellerNPCCareers.Spacer_Crew => new List<TravellerAttribute>
                {
                    new(Dexterity, 1)
                },
                TravellerNPCCareers.Spacer_Command => new List<TravellerAttribute>
                {
                    new(Intelligence, 1)
                },
                TravellerNPCCareers.Wanderer => new List<TravellerAttribute>(),
                _ => new List<TravellerAttribute>()
            };
        }

        private List<TravellerSkill> GetCareerSkillsAsync(TravellerNPCCareers career)
        {
            return career switch
            {
                TravellerNPCCareers.Administrator => new List<TravellerSkill>
                {
                    new(Admin, 3),
                    new(Advocate, 1),
                    new(Broker, 1),
                    new(Carouse, 1),
                    new(Diplomat, 1),
                    new(Electronics_Computers, 1),
                    new(Art),
                    new(Drive),
                    new(Leadership),
                    new(Profession),
                    new(Science)
                },
                TravellerNPCCareers.Agent => new List<TravellerSkill>
                {
                    new(Streetwise, 2),
                    new(Investigate, 2),
                    new(Electronics_Comms, 1),
                    new(Carouse, 1),
                    new(Deception, 1),
                    new(Persuade),
                    new(Recon),
                    new(Stealth),
                    new(Advocate),
                    new(Drive),
                    new(Melee),
                    new(GunCombat)
                },
                TravellerNPCCareers.Barbarian => new List<TravellerSkill>
                {
                    new(Melee_Blade, 2),
                    new(Survival, 2),
                    new(Animals, 1),
                    new(Profession, 1),
                    new(Recon, 1),
                    new(Athletics),
                    new(Carouse),
                    new(Navigation),
                    new(Stealth),
                    new(Seafarer)
                },
                TravellerNPCCareers.Citizen => new List<TravellerSkill>
                {
                    new(Electronics_Computers, 1),
                    new(Streetwise, 1),
                    new(Drive, 1),
                    new(Profession, 2),
                    new(Flyer, 1),
                    new(Science, 1),
                    new(Advocate),
                    new(Art),
                    new(Carouse),
                    new(Deception),
                    new(Diplomat),
                    new(Mechanic),
                    new(Medic),
                    new(Persuade)
                },
                TravellerNPCCareers.Corsair => new List<TravellerSkill>
                {
                    new(VaccSuit, 2),
                    new(Athletics_Dexterity, 1),
                    new(GunCombat, 1),
                    new(Gunner, 1),
                    new(Electronics, 1),
                    new(Mechanic, 1),
                    new(Melee, 1),
                    new(Deception),
                    new(Engineer),
                    new(Explosives),
                    new(Medic),
                    new(Recon),
                    new(Streetwise)
                },
                TravellerNPCCareers.Marine => new List<TravellerSkill>
                {
                    new(VaccSuit, 2),
                    new(GunCombat, 2),
                    new(Gunner, 1),
                    new(Electronics),
                    new(Athletics),
                    new(Melee_Blade, 1),
                    new(HeavyWeapons),
                    new(Explosives),
                    new(Medic),
                    new(Recon)
                },
                TravellerNPCCareers.Medic => new List<TravellerSkill>
                {
                    new(Admin, 2),
                    new(Electronics_Computers, 1),
                    new(Investigate, 1),
                    new(Persuade, 1),
                    new(Science, 1),
                    new(Advocate),
                    new(Diplomat),
                    new(Drive),
                    new(Flyer)
                },
                TravellerNPCCareers.Military_Enlisted => new List<TravellerSkill>
                {
                    new(GunCombat, 3),
                    new(Athletics_Endurance, 1),
                    new(Explosives, 1),
                    new(Recon, 1),
                    new(HeavyWeapons, 1),
                    new(Mechanic, 1),
                    new(Drive),
                    new(Electronics),
                    new(Medic),
                    new(Melee),
                    new(Stealth)
                },
                TravellerNPCCareers.Military_Officer => new List<TravellerSkill>
                {
                    new(Leadership, 2),
                    new(Admin, 1),
                    new(Diplomat, 1),
                    new(GunCombat, 1),
                    new(Tactics_Military, 1),
                    new(Athletics_Endurance, 1),
                    new(HeavyWeapons, 1),
                    new(Recon, 1),
                    new(Drive),
                    new(Electronics),
                    new(Medic),
                    new(Stealth)
                },
                TravellerNPCCareers.Noble => new List<TravellerSkill>
                {
                    new(Leadership, 2),
                    new(Diplomat, 2),
                    new(Admin, 1),
                    new(Advocate, 1),
                    new(Carouse, 1),
                    new(Persuade, 1),
                    new(Art),
                    new(Broker),
                    new(Deception),
                    new(Gambler)
                },
                TravellerNPCCareers.Performer => new List<TravellerSkill>
                {
                    new(Art, 3),
                    new(Carouse, 2),
                    new(Deception, 1),
                    new(Persuade, 1),
                    new(Streetwise, 1),
                    new(Steward, 1),
                    new(Athletics),
                    new(Broker),
                    new(Gambler),
                    new(Profession)
                },
                TravellerNPCCareers.Rogue => new List<TravellerSkill>
                {
                    new(Stealth, 2),
                    new(Streetwise, 2),
                    new(Deception, 1),
                    new(Gambler, 1),
                    new(Melee, 1),
                    new(Recon, 1),
                    new(Athletics),
                    new(Electronics),
                    new(GunCombat),
                    new(Persuade)
                },
                TravellerNPCCareers.Scholar => new List<TravellerSkill>
                {
                    new(Science, 3),
                    new(Investigate, 2),
                    new(Electronics_Computers, 1),
                    new(Science, 1),
                    new(Persuade, 1),
                    new(Art),
                    new(Diplomat),
                    new(Drive),
                    new(Medic),
                    new(Navigation),
                    new(Profession)
                },
                TravellerNPCCareers.Scout => new List<TravellerSkill>
                {
                    new(Astrogation, 1),
                    new(Pilot_Spacecraft, 1),
                    new(Electronics_Computers, 1),
                    new(Engineer, 1),
                    new(JackOfAllTrades, 1),
                    new(Streetwise, 1),
                    new(VaccSuit, 1),
                    new(Carouse),
                    new(Drive),
                    new(GunCombat),
                    new(Medic),
                    new(Investigate),
                    new(Recon)
                },
                TravellerNPCCareers.Spacer_Crew => new List<TravellerSkill>
                {
                    new(VaccSuit, 3),
                    new(Athletics, 1),
                    new(Electronics, 1),
                    new(Engineer, 1),
                    new(Mechanic, 1),
                    new(Steward, 1),
                    new(Gunner),
                    new(Pilot),
                    new(Medic),
                    new(Persuade)
                },
                TravellerNPCCareers.Spacer_Command => new List<TravellerSkill>
                {
                    new(Pilot_Spacecraft, 2),
                    new(Admin, 1),
                    new(Astrogation, 1),
                    new(Electronics_Sensors, 1),
                    new(Gunner, 1),
                    new(VaccSuit, 1),
                    new(Advocate),
                    new(Broker),
                    new(Leadership),
                    new(Persuade),
                    new(Tactics)
                },
                TravellerNPCCareers.Wanderer => new List<TravellerSkill>
                {
                    new(Streetwise, 2),
                    new(Melee_Unarmed, 1),
                    new(Recon, 1),
                    new(Stealth, 1),
                    new(Steward, 1),
                    new(VaccSuit, 1),
                    new(Carouse),
                    new(Deception),
                    new(Drive),
                    new(GunCombat),
                    new(Mechanic),
                    new(Profession),
                    new(Survival)
                },
                _ => new List<TravellerSkill>()
            };
        }

        private string GetName(TravellerNameService.NationNameList nationList)
        {
            return nameService.GetNames(1, nationList)[0] ?? "Error";
        }


        public string GetBackgroundName(TravellerNPCBackgrounds background)
        {
            return background switch
            {
                TravellerNPCBackgrounds.Belter => "Belter",
                TravellerNPCBackgrounds.Colonist => "Colonist",
                TravellerNPCBackgrounds.Developed_World => "Developed World",
                TravellerNPCBackgrounds.Fringe => "Fringe",
                TravellerNPCBackgrounds.Low_Tech => "Low-Tech",
                TravellerNPCBackgrounds.Metropolis => "Metropolis",
                TravellerNPCBackgrounds.Space_Habitat => "Space Habitat",
                TravellerNPCBackgrounds.Water_World => "Water World",
                _ => "Error"
            };
        }


        public string GetCareerName(TravellerNPCCareers career)
        {
            return career switch
            {
                TravellerNPCCareers.Administrator => "ADMINISTRATOR",
                TravellerNPCCareers.Agent => "AGENT",
                TravellerNPCCareers.Barbarian => "BARBARIAN",
                TravellerNPCCareers.Citizen => "CITIZEN",
                TravellerNPCCareers.Corsair => "CORSAIR",
                TravellerNPCCareers.Marine => "MARINE",
                TravellerNPCCareers.Medic => "MEDIC",
                TravellerNPCCareers.Military_Enlisted => "MILITARY (ENLISTED)",
                TravellerNPCCareers.Military_Officer => "MILITARY (OFFICER)",
                TravellerNPCCareers.Noble => "NOBLE",
                TravellerNPCCareers.Performer => "PERFORMER",
                TravellerNPCCareers.Rogue => "ROGUE",
                TravellerNPCCareers.Scholar => "SCHOLAR",
                TravellerNPCCareers.Scout => "SCOUT",
                TravellerNPCCareers.Spacer_Crew => "SPACER (CREW)",
                TravellerNPCCareers.Spacer_Command => "SPACER (COMMAND)",
                TravellerNPCCareers.Wanderer => "WANDERER",
                _ => "Error"
            };
        }


        public List<TravellerNPC> GetNPCAsync(int npcCount, TravellerNameService.NationNameList nationNameList)
        {
            var npcList = new List<TravellerNPC>();

            try
            {
                for (var i = 0; i < npcCount; i++)
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

        public TravellerNPC GenerateNPC(string name, int seed = default)
        {
            if (seed == default) seed = rand.Next();

            rand = new Random(seed);
            var background = (TravellerNPCBackgrounds)rand.Next(0, 8);
            var career = (TravellerNPCCareers)rand.Next(0, 16);
            var npc = GenerateNPC(name, background, career, null);
            return npc;
        }

        public TravellerNPC GenerateNPC(int seed = default)
        {
            if (seed == default) seed = rand.Next();

            rand = new Random(seed);
            var background = (TravellerNPCBackgrounds)rand.Next(0, 8);
            var career = (TravellerNPCCareers)rand.Next(0, 16);
            var nameList = (TravellerNameService.NationNameList)rand.Next(0,
                Enum.GetValues(typeof(TravellerNameService.NationNameList)).Length);
            var name = GetName(nameList);
            var npc = GenerateNPC(name, background, career, null);
            return npc;
        }

        public TravellerNPC GenerateNPC(TravellerNameService.NationNameList nationNameList,
            TravellerNPCBackgrounds background,
            TravellerNPCCareers career, List<TravellerItem> items)
        {
            var name = GetName(nationNameList);
            var npc = GenerateNPC(name, background, career, items);
            return npc;
        }

        public TravellerNPC GenerateNPC(string name, TravellerNPCBackgrounds background, TravellerNPCCareers career,
            List<TravellerItem> items)
        {
            if (items == null) items = new List<TravellerItem>();

            var skillList = SkillList(background, career, rand);
            var attributeList = GetAttributeValues(AttributeList(background, career, rand), rand);

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
                QuirkText = quirk,
                Items = items
            };
            return npc;
        }

        protected TravellerNPC TravellerNpc(string name)
        {
            var npc = GenerateNPC(name);
            return npc;
        }

        protected TravellerNPC TravellerNpc(TravellerNameService.NationNameList nationNameList)
        {
            var name = GetName(nationNameList);
            var npc = GenerateNPC(name);
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

        private List<TravellerAttribute> AttributeList(TravellerNPCBackgrounds background, TravellerNPCCareers career,
            Random rng)
        {
            var backgroundStats = GetBackgroundAttributesAsync(background);
            var careerStats = GetCareerAttributesAsync(career);

            var attributeList = new List<TravellerAttribute>();

            foreach (var attr in backgroundStats) attributeList.Add(attr);

            foreach (var attr in careerStats)
                if (attributeList.Any(attrList => attrList.AttributeName == attr.AttributeName))
                    attributeList.First(attrList => attrList.AttributeName == attr.AttributeName).AttributableValue
                        += attr.AttributableValue == 0 ? 1 : attr.AttributableValue;
                else
                    attributeList.Add(attr);

            return attributeList;
        }

        private TravellerAttribute GenerateAttributeFromSkills(TravellerAttributes attributeName,
            List<TravellerAttribute> attributes, Random rng)
        {
            var attMod = 0;
            if (attributes.Any(attr => attr.AttributeName == attributeName))
                attMod = attributes.Where(attr => attr.AttributeName == attributeName)
                    .Select(attr => attr.AttributableValue).Aggregate(0, (h, t) => h + t);

            return new TravellerAttribute(attributeName, rng.Next(2, 13) + attMod);
        }

        private List<TravellerSkill> SkillList(TravellerNPCBackgrounds background, TravellerNPCCareers career,
            Random rng)
        {
            var backgroundStats = GetBackgroundSkillsAsync(background);
            var careerStats = GetCareerSkillsAsync(career);

            var skillList = new List<TravellerSkill>();

            foreach (var skill in backgroundStats) skillList.Add(skill);

            foreach (var skill in careerStats)
                if (skillList.Any(listSkill => listSkill.SkillName == skill.SkillName))
                    skillList.First(listSkill => listSkill.SkillName == skill.SkillName).SkillValue +=
                        skill.SkillValue == 0 ? 1 : skill.SkillValue;
                else
                    skillList.Add(skill);

            return skillList;
        }
    }
}