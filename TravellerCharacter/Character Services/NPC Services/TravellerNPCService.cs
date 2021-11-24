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

        private static readonly TravellerNameService nameService = new TravellerNameService();

        private List<TravellerAttribute> GetBackgroundAttributesAsync(TravellerNPCBackgrounds background) =>
             background switch
             {
                 TravellerNPCBackgrounds.Belter => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Strength, -1),
                    new TravellerAttribute(Dexterity, +1),
                    new TravellerAttribute(Education, -1),
                },
                 TravellerNPCBackgrounds.Colonist => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Endurance, +1),
                    new TravellerAttribute(Education, -1),
                },
                 TravellerNPCBackgrounds.Developed_World => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Education, +1),
                },
                 TravellerNPCBackgrounds.Fringe => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Education, -2),
                    new TravellerAttribute(Dexterity, +1),
                    new TravellerAttribute(Social, -2),
                },
                 TravellerNPCBackgrounds.Low_Tech => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Education, -3),
                    new TravellerAttribute(Endurance, +2),
                },
                 TravellerNPCBackgrounds.Metropolis => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Strength, -1),
                    new TravellerAttribute(Education, +2),
                    new TravellerAttribute(Endurance, +1),
                },
                 TravellerNPCBackgrounds.Space_Habitat => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Dexterity, +1),
                    new TravellerAttribute(Education, +1),
                    new TravellerAttribute(Endurance, -1),
                },
                 TravellerNPCBackgrounds.Water_World => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Endurance, +1),
                },
                 _ => new List<TravellerAttribute>(),
             };

        private List<TravellerSkill> GetBackgroundSkillsAsync(TravellerNPCBackgrounds background) =>
            background switch
            {
                TravellerNPCBackgrounds.Belter => new List<TravellerSkill>()
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
                TravellerNPCBackgrounds.Colonist => new List<TravellerSkill>()
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
                TravellerNPCBackgrounds.Developed_World => new List<TravellerSkill>()
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
                TravellerNPCBackgrounds.Fringe => new List<TravellerSkill>()
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
                TravellerNPCBackgrounds.Low_Tech => new List<TravellerSkill>()
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
                TravellerNPCBackgrounds.Metropolis => new List<TravellerSkill>()
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
                TravellerNPCBackgrounds.Space_Habitat => new List<TravellerSkill>()
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
                TravellerNPCBackgrounds.Water_World => new List<TravellerSkill>()
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

        private List<TravellerAttribute> GetCareerAttributesAsync(TravellerNPCCareers career) =>
            career switch
            {
                TravellerNPCCareers.Administrator => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Education, +1),
                    new TravellerAttribute(Social, +1),
                },
                TravellerNPCCareers.Agent => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Intelligence, +1),
                },
                TravellerNPCCareers.Barbarian => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Strength, +1),
                    new TravellerAttribute(Endurance, +2),
                },
                TravellerNPCCareers.Citizen => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Education, +1),
                },
                TravellerNPCCareers.Corsair => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Dexterity, +1),
                    new TravellerAttribute(Social, -2),
                },
                TravellerNPCCareers.Marine => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Dexterity, +1),
                    new TravellerAttribute(Education, +1),
                },
                TravellerNPCCareers.Medic => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Social, +1),
                },
                TravellerNPCCareers.Military_Enlisted => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Endurance, +2),
                },
                TravellerNPCCareers.Military_Officer => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Education, +1),
                },
                TravellerNPCCareers.Noble => new List<TravellerAttribute>() {
                    new TravellerAttribute (Education,1),
                },
                TravellerNPCCareers.Performer => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Intelligence,1),
                },
                TravellerNPCCareers.Rogue => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Intelligence,1),
                    new TravellerAttribute(Social,-1),
                },
                TravellerNPCCareers.Scholar => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Intelligence,1),
                    new TravellerAttribute(Education,1),
                },
                TravellerNPCCareers.Scout => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Intelligence,1),
                },
                TravellerNPCCareers.Spacer_Crew => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Dexterity,1),
                },
                TravellerNPCCareers.Spacer_Command => new List<TravellerAttribute>()
                {
                    new TravellerAttribute(Intelligence,1),
                },
                TravellerNPCCareers.Wanderer => new List<TravellerAttribute>()
                {
                },
                _ => new List<TravellerAttribute>(),
            };
        private List<TravellerSkill> GetCareerSkillsAsync(TravellerNPCCareers career) =>
            career switch
            {
                TravellerNPCCareers.Administrator => new List<TravellerSkill>()
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
                TravellerNPCCareers.Agent => new List<TravellerSkill>()
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
                TravellerNPCCareers.Barbarian => new List<TravellerSkill>()
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
                TravellerNPCCareers.Citizen => new List<TravellerSkill>()
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
                TravellerNPCCareers.Corsair => new List<TravellerSkill>()
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
                TravellerNPCCareers.Marine => new List<TravellerSkill>()
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
                TravellerNPCCareers.Medic => new List<TravellerSkill>()
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
                TravellerNPCCareers.Military_Enlisted => new List<TravellerSkill>()
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
                TravellerNPCCareers.Military_Officer => new List<TravellerSkill>()
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
                TravellerNPCCareers.Noble => new List<TravellerSkill>() {
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
                TravellerNPCCareers.Performer => new List<TravellerSkill>()
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
                TravellerNPCCareers.Rogue => new List<TravellerSkill>()
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
                TravellerNPCCareers.Scholar => new List<TravellerSkill>()
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
                TravellerNPCCareers.Scout => new List<TravellerSkill>()
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
                TravellerNPCCareers.Spacer_Crew => new List<TravellerSkill>()
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
                TravellerNPCCareers.Spacer_Command => new List<TravellerSkill>()
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
                TravellerNPCCareers.Wanderer => new List<TravellerSkill>()
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
            "Assassin","Merchant","Smuggler","Free Trader","Terrorist","Broker","Embezzler","Corporate Executive",
            "Thief", "Corporate Agent","Revolutionary","Financier","Clerk","Belter","Administrator","Researcher",
            "Mayor","Naval Officer","Minor Versian Noble","Pilot","Physician","Starport Administrator", "Tribal Leader",
            "Scout","Diplomat","Alien","Courier","Playboy","Spy","Stowaway","Ambassador","Family Relative","Noble",
            "Agent of a Foreign Power","Police Officer","Imperial Agent", "Sigmarian Preacher", "Minor Federation Noble",
            "Traitor","Ripperdoc","Hacker","Punk","Magic User","Spiritual Advisor","Fixer", "Journalist","Influencer"
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


        public string GetBackgroundName(TravellerNPCBackgrounds background)
            => background switch
            {
                TravellerNPCBackgrounds.Belter => "Belter",
                TravellerNPCBackgrounds.Colonist => "Colonist",
                TravellerNPCBackgrounds.Developed_World => "Developed World",
                TravellerNPCBackgrounds.Fringe => "Fringe",
                TravellerNPCBackgrounds.Low_Tech => "Low-Tech",
                TravellerNPCBackgrounds.Metropolis => "Metropolis",
                TravellerNPCBackgrounds.Space_Habitat => "Space Habitat",
                TravellerNPCBackgrounds.Water_World => "Water World",
                _ => "Error",
            };

       

        public string GetCareerName(TravellerNPCCareers career)
            => career switch
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

        public TravellerNPC GenerateNPC(string name, int seed = default)
        {
            if (seed == default)
            {
                seed = rand.Next();
            }

            rand = new Random(seed);
            var background = (TravellerNPCBackgrounds) rand.Next(0, 8);
            var career = (TravellerNPCCareers) rand.Next(0, 16);
            var npc = GenerateNPC(name, background, career,null);
            return npc;
        }
        
        public TravellerNPC GenerateNPC(int seed = default)
        {
            if (seed == default)
            {
                seed = rand.Next();
            }

            rand = new Random(seed);
            var background = (TravellerNPCBackgrounds) rand.Next(0, 8);
            var career = (TravellerNPCCareers) rand.Next(0, 16);
            var nameList = (TravellerNameService.NationNameList) rand.Next(0, Enum.GetValues(typeof(TravellerNameService.NationNameList)).Length);
            var name = GetName(nameList);
            var npc = GenerateNPC(name, background, career,null);
            return npc;
        }

        public TravellerNPC GenerateNPC(TravellerNameService.NationNameList nationNameList, TravellerNPCBackgrounds background, 
            TravellerNPCCareers career, List<TravellerItem> items)
        {

            var name = GetName(nationNameList);
            var npc = GenerateNPC(name,background,career,items);
            return npc;
        }

        public TravellerNPC GenerateNPC(string name, TravellerNPCBackgrounds background, TravellerNPCCareers career, List<TravellerItem> items)
        {
            if (items == null)
            {
                items = new List<TravellerItem>();
            }

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

        private List<TravellerAttribute> AttributeList(TravellerNPCBackgrounds background, TravellerNPCCareers career, Random rng)
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

        private List<TravellerSkill> SkillList(TravellerNPCBackgrounds background, TravellerNPCCareers career, Random rng)
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
