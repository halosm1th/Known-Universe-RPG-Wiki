using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellerWiki.Data
{
    public class TravellerNationsCharacterInfoService
    {
        private Dictionary<string, TravellerNationsCharacterInfo> travellerNationsInfo = new Dictionary<string, TravellerNationsCharacterInfo>()
        {
            {
                "Universalis Confederation",
                new TravellerNationsCharacterInfo("Universalis Confederation",
                    backgroundText: "The Universalis Confederation exists as both a government and a forum for the major nations to conduct peace negotiations and try and prevent war. While 90%+ of the population who legally are with the Universalis Confederation are also Witchers, the remaining people are mostly those who happened to work within the Confederation or their children.",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("Edu",2),("Soc",1),("End",-2)
                    },
                    perks:new List<string>
                    {
                        "UC Passport",
                        "TAS Membership",
                        "Language (Common) 1",
                        "Language (Any) 1",
                        "(Religous? Witcherism)"
                    },
                    backgroundSkills:new List<string>
                    {
                        "Admin",
                        "Animals",
                        "Art",
                        "Athletics",
                        "Carouse",
                        "Drive",
                        "Electronics",
                        "Flyer",
                        "language",
                        "Mechanic",
                        "Medic",
                        "Profession",
                        "Science",
                        "Seafarer",
                        "Streetwise",
                        "Survival",
                        "VaccSuit"
                    })},
            {
                "Witcher",
                new TravellerNationsCharacterInfo("Witcher",
                    backgroundText: "The Witchers are a cross between peacekeepers, military leaders, police, and monster hunters. They are recruited from worlds and trained aboard massive Kaer-Stella (Star Keeps) filled with dozens of cities dedicated to that world ship's different schools.",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("Str",2),("Soc",1),("Edu",-1)
                    },
                    perks:new List<string>
                    {
                        "VoidBlade",
                        "WitcherStatus",
                        "Language (Witcher) 1",
                        "Language (Any) 1",
                        "(Religous? Witcherism)"

                    },
                    backgroundSkills:new List<string>
                    {
                        "Melee(void)",
                        "Recon",
                        "Art",
                        "Athletics",
                        "Carouse",
                        "Deception",
                        "Jack-of-all-Trades",
                        "persuade",
                        "language",
                        "Mechanic",
                        "Medic",
                        "Profession",
                        "Science",
                        "stealth",
                        "Streetwise",
                        "Survival",
                        "VaccSuit",
                    },
                    entryRequirements:new List<string>{"Psi 6+","Soc 8+"})},
            {
                "United Federation of Earth and her Colonies Among the Stars",
                new TravellerNationsCharacterInfo("United Federation of Earth and her Colonies Among the Stars",
                    backgroundText: "The United Federation of Earth is an unequal paradise full of contradictions. While it is a place of equality and justice, there is a house of Lords and all land is owned by a few elite. While you are legally free to do as you like, you must be a part of the state. While there are many perks, the cushy life leads many intellectuals to a premature death.",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("Edu",+2),("Int",+2),("End",-2),("Dex | Str",-1)
                    },
                    perks:new List<string>
                    {
                        "OptionalNeuralNet",
                        "FederationCitizenship",
                        "Language (Federation Common) 1",
                        "(Religous? Witcherism)"
                    },
                    backgroundSkills:new List<string>
                    {
                        "Admin",
                        "Advocate",
                        "Art",
                        "Astrogation",
                        "Engineer",
                        "Persuade",
                        "Electronics",
                        "Flyer",
                        "language",
                        "Mechanic",
                        "Medic",
                        "Profession",
                        "Science",
                        "Seafarer",
                        "Streetwise",
                        "Gambler",
                        "VaccSuit",
                    })},
            {
                "Luna Knights",
                new TravellerNationsCharacterInfo("Luna Knights",
                    backgroundText: "The sworn defenders of Earth, protectors of the jewel, the Luna Knights are known throughout the Universe for their strength and their near mythical standards for warriors make being a member of the Luna Knights an honour bestowed only on the chosen few of society.",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("Soc",1),("Str",2),("Dex",2),("Int",-2),("Edu",-2)
                    },
                    perks:new List<string>
                    {
                        "KnightArmour",
                        "KnightWeapons",
                        "Knightstransport",
                        "Language (High Versian) 1",
                        "Language (Federation Common) 1",
                        "(Religous? Deorism)"
                    },
                    backgroundSkills:new List<string>
                    {"Gun",
                        "Melee",
                        "Explosives",
                        "Deception",
                        "Gunner",
                        "HeavyWeapons",
                        "Electronics",
                        "Flyer",
                        "Drive",
                        "Pilot",
                        "Recon",
                        "Stealth",
                        "Tactics",
                        "Seafarer",
                        "Streetwise",
                        "Survival",
                        "VaccSuit",
                    },
                    entryRequirements:new List<string>{"Str | Dex | End | Psi 8+"})},
            {
                "Fifth Vers Empire",
                new TravellerNationsCharacterInfo("Fifth Vers Empire",
                    backgroundText: "A regal empire reformed but ashamed, beaten and lost, dejected and defeated but boldly looking to the future for growth. Those from the Vers Empire that are travelling tend to be low members of the Aristocractic class or rich members of the Civis class.",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("Soc",1),("Edu",+1),("Str",+1),("Dex | Int | Edu",-2)
                    },
                    perks:new List<string>
                    {
                        "Vers Citizenship",
                        "(soc10+ voidKnife)",
                        "Language (Low Versian) 1",
                        "Language (High Versian) 1",
                        "(Religous? Sithism)"
                    },
                    backgroundSkills:new List<string>
                    {
                        "Admin",
                        "Animals",
                        "Art",
                        "Advocate",
                        "Carouse",
                        "Diplomat",
                        "Deception",
                        "Gambler",
                        "language",
                        "Investigate",
                        "Persuade",
                        "Profession",
                        "Science",
                        "Steward",
                        "Streetwise",
                        "Melee",
                        "VaccSuit",
                    })},
            {
                "Equites Ordinis deorum",
                new TravellerNationsCharacterInfo("Equites Ordinis deorum",
                    backgroundText: "The elite Knights of the Gods serve as the Versian response to things like the Luna Knights, or the Witchers. While technically being an Order now under the command of the Empress, the Knights of the Gods truly serve those within the Void, not just their embodiment in this plane of existence.",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("Psi",2),("Soc",-1)
                    },
                    perks:new List<string>
                    {"VoidBlade",
                        "EquitesOrdinisArmour",
                        "Language (High Versian) 2",
                        "Language (Low Versian) 1",
                        "(Religous? Deorism)"
                    },
                    backgroundSkills:new List<string>
                    {
                        "Admin",
                        "Advocate",
                        "Art",
                        "Melee",
                        "Telepathy",
                        "Clairvoyance",
                        "Electronics",
                        "Telekinesis",
                        "Language",
                        "Awareness",
                        "Medic",
                        "GunCombat",
                        "Science",
                        "Teleportation",
                        "Streetwise",
                        "Survival",
                        "VaccSuit",
                    },
                    entryRequirements:new List<string>{"Psi 6+","Soc 8+"})},
            {
                "United Reverse Lords",
                new TravellerNationsCharacterInfo("United Reverse Lords",
                    backgroundText: "Following the Deutschland defaulting on their war debt, the Vers empire fell into civil war before eventually fracturing into two. The United Reverse Lords seeks to continue the great work done by Emperor Reveres and takes heavy inspiration from the First Vers Republic.",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("Edu",2),("Int",2),("Soc",-1),
                    },
                    perks:new List<string>
                    {
                        "UnitedReverseLordsCitizenship",
                        "OptionalNeuralNet",
                        "Language (High Versian) 1",
                        "Language (Low Versian) 1",
                        "(Religous? Deorism)"
                    },
                    backgroundSkills:new List<string>
                    {
                        "Admin",
                        "Animals",
                        "Art",
                        "Athletics",
                        "Carouse",
                        "Drive",
                        "Electronics",
                        "Flyer",
                        "language",
                        "Mechanic",
                        "Medic",
                        "Profession",
                        "Science",
                        "Seafarer",
                        "Streetwise",
                        "Survival",
                        "VaccSuit",
                    })},
            {
                "Xiao-Ming Mega Corporation",
                new TravellerNationsCharacterInfo("Xiao-Ming Mega Corporation",
                    backgroundText: "Following a bloody defeat in the great war and the loss of their control over the Axion Alliance, Xiao-Ming Industries has been forced to lay off a large amount of “wasteful expenditures”, otherwise known as employees. While many are still paying off their corporate conception/birth/life/property damage/etc-debts and thus are forced to continue to be impossibly employed.",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("Str | Dex",2),("Edu",1),("Soc",-2),("Int",-1),
                    },
                    perks:new List<string>
                    {"Xiao-MingEmployeecard",
                        "exitpackage(200Cr/Month)",
                        "Language (Xiao-Ming) 1",
                        "Language (Axios Political) 1",
                        "(Religous? Jed-Iism)"
                    },
                    backgroundSkills:new List<string>
                    {
                        "Admin",
                        "Advocate",
                        "Broker",
                        "Athletics",
                        "Astrogation",
                        "Drive",
                        "Navigation",
                        "Flyer",
                        "language",
                        "Mechanic",
                        "Profession",
                        "Profession",
                        "Science",
                        "Seafarer",
                        "Streetwise",
                        "Steward",
                        "VaccSuit"
                    })},
            {
                "Communist Empire of the Deutschland",
                new TravellerNationsCharacterInfo("Communist Empire of the Deutschland",
                    backgroundText: "Backbreaking work, a constant diet of propaganda, the only relief being the even more propaganda filled church sermons. Life is nasty, brutish, and if you’re lucky, short. Labour camps await anyone caught trying to leave the Utopian communist wonderland, while positions that leave the communal-empire are covenanted to only the chosen few comrades of the empress and her closest admirals, generals, bankers, priests and friends.",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("Edu",-2),("Int",-1),("Soc",-2),("Str",+4),("End",+3),("Dex",+2),
                    },
                    perks:new List<string>
                    {
                        "Language (Germushian) 1",
                        "(Religous? Sigmarism)"
                    },
                    backgroundSkills:new List<string>
                    {
                        "Deception",
                        "Animals",
                        "Stealth",
                        "Athletics",
                        "Persuade",
                        "Drive",
                        "Electronics",
                        "Flyer",
                        "language",
                        "Mechanic",
                        "Medic",
                        "Profession",
                        "Science",
                        "Seafarer",
                        "Streetwise",
                        "Survival",
                        "VaccSuit"
                    })},
            {
                "Church of Sigmar",
                new TravellerNationsCharacterInfo("Church of Sigmar",
                    backgroundText: "The holy light, the one true god, the only true god. The powerhouse behind the Deutschland and the creators of the almost demi-god like sigmarines. As well the churches inquisitors act as their magical enforcers and commanders. ",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("Psi",1), ("Soc",1), ("Str",1),
                    },
                    perks:new List<string>
                    {"(Inquisitor? VoidBlade)",
                        "Sexton of Sigmar (Holy Relic)",
                        "Language (Germushian) 1",
                        "Language (Sigmarian) 1",
                        "(Religous? Sigmarism)"
                    },
                    backgroundSkills:new List<string>
                    {
                        "Advocate",
                        "Language",
                        "Melee",
                        "GunCombat",
                        "Carouse",
                        "Deception",
                        "Persuade",
                        "Science",
                        "Profession",
                        "Medic",
                        "Survival",
                        "VaccSuit",
                    },
                    entryRequirements:new List<string>{"Soc 10+ | Psi 8+"})},
            {
                "Germushian Free Republic",
                new TravellerNationsCharacterInfo("Germushian Free Republic",
                    backgroundText: "The best things in life may be free, but money, that's what you want. The Germushian Free Republic says Free Enterprise is the way forward. Government should be as out of the way as those pesky protestors. So long as you got the money that is. Of course, this drives the drug cartels who back the government to make sure that the average citizen actually has an okay life.",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("Edu",+2),("Soc",+2),("End",-2),("Int",-1),
                    },
                    perks:new List<string>
                    {
                        "Language (Germushian) 1",
                        "Language (Any Common) 1",
                        "(Religous? Lawgarism)"
                    },
                    backgroundSkills:new List<string>
                    {
                        "Advocate",
                        "Animals",
                        "Broker",
                        "Deception",
                        "Carouse",
                        "Drive",
                        "Gambler",
                        "Flyer",
                        "language",
                        "JackOfAllTrades",
                        "Persuade",
                        "Profession",
                        "Science",
                        "Steward",
                        "Streetwise",
                        "Stealth",
                        "VaccSuit",
                    })},
            {
                "Polandskia Peoples Union",
                new TravellerNationsCharacterInfo( "Polandskia Peoples Union",
                    backgroundText: "What happens to a place when the government is told they have to leave, and the replacement government is told they aren’t allowed to do anything too similar to their closest neighbor who they now depend on. Piracy has begun to run rampant, as has terrorism and various warlords declaring their own nations within Polandskia, described once as \\“A nation of nations, one which can handle nations within nations. Even if we don’t always agree as nations.\\”",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("(Str | Dex)",+2),("Int ",1),("(Edu, End ",-1),("| Soc )",-2)
                    },
                    perks:new List<string>
                    {
                        "Weapon",
                        "Language (Germushian) 1",
                        "Language (Sigmarian) 1",
                        "(Religous? Sigmarism)"
                    },
                    backgroundSkills:new List<string>
                    {
                        "GunCombat",
                        "Animals",
                        "Melee",
                        "Athletics",
                        "Carouse",
                        "Drive",
                        "Electronics",
                        "Flyer",
                        "language",
                        "Mechanic",
                        "Medic",
                        "Explosives",
                        "HeavyWeapons",
                        "Seafarer",
                        "Streetwise",
                        "Survival",
                        "VaccSuit",
                    })},
            {
                "Trans Galactic Empire",
                new TravellerNationsCharacterInfo("Trans Galactic Empire",
                    backgroundText: "",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("(Str, Edu",1),("Dex, Int",-1),("| Str, Edu",-1),("Dex, Int)", +1)
                    },
                    perks:new List<string>
                    {
                        "Neural Net",
                        "(Imperial? Imperial Status)",
                        "Language (High Imperial) 1",
                        "Language (Low Imperial) 1",
                        "(Religous? Modern Sithism)"
                    },
                    backgroundSkills:new List<string>
                    {
                        "Admin",
                        "Advocate",
                        "Art",
                        "Athletics",
                        "Diplomat",
                        "Drive",
                        "Melee",
                        "GunCombat",
                        "language",
                        "Leadership",
                        "Medic",
                        "Profession",
                        "Science",
                        "Steward",
                        "Streetwise",
                        "Tactics",
                        "VaccSuit",
                    })},
            {
                "Sith",
                new TravellerNationsCharacterInfo("Sith",
                    backgroundText: "The Sith are the Church of the Empire, as declared by the First Emperor Sheeve Palpatine, also known by his Sith title as Darth Sideous. Today with Darth Reserecteous at the head of the church the Sith are back, stronger than ever.",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("Psi",2),("Str",1),("Dex",1),("Int",1),("Soc",1),("Edu",1)
                    },
                    perks:new List<string>
                    {
                        "Void Blade",
                        "Language (High Imperial) 1",
                        "Language (Sith) 1",
                        "(Religous? Sithism)"
                    },
                    backgroundSkills:new List<string>
                    {
                        "Melee(Void)",
                        "Language",
                        "VaccSuit",
                        "Deception",
                        "Psi-Talent",
                        "Streetwise",
                        "Stealth",
                        "Recon"
                    },
                    entryRequirements:new List<string>{"Psi 8+"})},
            {
                "First Order",
                new TravellerNationsCharacterInfo("First Order",
                    backgroundText: "The most fanatical of the factions within the Empire, founded for that very purpose by the first emperor himself. Having recently failed to invade the Federation, the First Order returned to prominence upon the return of Britannia, now their looming military awaits another chance at war.",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("Soc",1),("Str",1),("Dex",1),("End",-1),("Int",-2),("Edu",-1),
                    },
                    perks:new List<string>
                    {
                        "Neural Net",
                        "Imperial Status",
                        "Void Knife",
                        "Language (High Imperial) 2",
                        "(Religous? Orthodox Sithism)"
                    },
                    backgroundSkills:new List<string>
                    {
                        "Admin",
                        "Melee",
                        "GunCombat",
                        "Athletics",
                        "HeavyWeapons",
                        "Drive",
                        "Electronics",
                        "Flyer",
                        "language",
                        "Mechanic",
                        "Medic",
                        "Gunner",
                        "Explosive",
                        "Seafarer",
                        "Streetwise",
                        "Survival",
                        "VaccSuit"
                    })},
            {
                "The Kingdom of Britannia",
                new TravellerNationsCharacterInfo("The Kingdom of Britannia",
                    backgroundText: "The Kingdom of Britannia once was the Empire, then it was part of Vers. Now the unique culture that has developed here finally has its own unique name, even if it does reside under the Imperial banner, those within Britannia tend to be closer to classical Vader-Imperials than the modern Neo-Palpatinian-Imperial.",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("Int",1),("Edu",1),
                    },
                    perks:new List<string>
                    {
                        "Language (Low Imperial) 1",
                        "Language (Britannian) 1",
                        "(Religous? Britannian Sithism)"
                    },
                    backgroundSkills:new List<string>
                    {"Admin",
                        "Animals",
                        "Art",
                        "Athletics",
                        "Carouse",
                        "Drive",
                        "Electronics",
                        "Flyer",
                        "language",
                        "Mechanic",
                        "Medic",
                        "Profession",
                        "Science",
                        "Seafarer",
                        "Streetwise",
                        "Survival",
                        "VaccSuit"
                    })},
            {
                "Imperial Versian Federated Territories",
                new TravellerNationsCharacterInfo("Imperial Versian Federated Territories",
                    backgroundText: "After a bloody war for independence with Britannia that only ended when the Emperor officially joined the war on the side of the Territories that Britannia would eventually back off. Now the democratic nation is the puppet of a despotic empire, for now trapped in an abusive relationship, assured protection by their protector, the Emperor.",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("Int",2),("Soc",-1),("Str",-1),("End",1),
                    },
                    perks:new List<string>
                    {"Neural Net",
                        "Imperial Citizen Status",
                        "Language (Low Imperial) 1",
                        "Language (Low Versian) 1",
                        "(Religous? Deorism)"
                    },
                    backgroundSkills:new List<string>
                    {"Melee",
                        "Animals",
                        "Art",
                        "Athletics",
                        "Carouse",
                        "Drive",
                        "Electronics",
                        "Flyer",
                        "language",
                        "GunCombat",
                        "Medic",
                        "Profession",
                        "Science",
                        "Seafarer",
                        "Streetwise",
                        "Survival",
                        "VaccSuit",
                    })},
            {
                "Axion Alliance",
                new TravellerNationsCharacterInfo("Axion Alliance",
                    backgroundText: "Founded following the first Sol war, nearly 82,000 years ago, the Axion Alliance has persisted as the longest standing peace agreement in Human history. Today it unites alien nations all around a foriegn galaxy who once were oppressed by Xiao-Ming Industries now are once again given a chance at freedom.",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("(str | dex | end)",1),("(int | edu | soc)",1),
                    },
                    perks:new List<string>
                    {"Alliance Status",
                        "Language (Axios Common) 1",
                        "Language (Axios Political) 1",
                        "(Religous? Jed-Iism)"
                    },
                    backgroundSkills:new List<string>
                    {"Admin",
                        "Advocate",
                        "Animals",
                        "Art",
                        "Athletics",
                        "BrokerCarouse",
                        "Drive",
                        "Electronics",
                        "Engineer",
                        "Flyer",
                        "language",
                        "Mechanic",
                        "Medic",
                        "Pilot",
                        "Profession",
                        "Science",
                        "Seafarer",
                        "Streetwise",
                        "Survival",
                        "VaccSuit"
                    })},
            {
                "Artekkan Guilds",
                new TravellerNationsCharacterInfo("Artekkan Guilds",
                    backgroundText: "Little is known of the secretive Artekkan Guilds. Their massive mining ships rarely dock with anyone, and their automated trade-ships seemingly have no human crews. Their cities are reported to be diamond underground palaces of lush green connected by voidgates, a technology thought impossible at this level by the rest of the universe",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                        ("(Str | Dex)",2),("End",1),("Soc",-4),("Edu",1),("Int",1),
                    },
                    perks:new List<string>
                    {"Guild Card",
                        "Language (Tekka) 1",
                        "Language (Any Common) 1",
                        "(Religous? Gatism)"
                    },
                    backgroundSkills:new List<string>
                    {
                        "Admin",
                        "Astrogation",
                        "Broker",
                        "Diplomat",
                        "Carouse",
                        "Pilot",
                        "Electronics",
                        "Flyer",
                        "language",
                        "Mechanic",
                        "Engineer",
                        "VaccSuit",
                        "Gambler",
                        "Persuade"
                    })},
            {
                "Default",
                new TravellerNationsCharacterInfo("Default",
                    backgroundText: "This is the default human from the base traveller game. I recommend against it.",
                    statChanges: new List<(string Stat, int ChangeBy)>
                    {
                    },
                    perks:new List<string>
                    {
                    },
                    backgroundSkills:new List<string>
                    {"Admin",
                        "Animals",
                        "Art",
                        "Athletics",
                        "Carouse",
                        "Drive",
                        "Electronics",
                        "Flyer",
                        "Language",
                        "Mechanic",
                        "Medic",
                        "Profession",
                        "Science",
                        "Seafarer",
                        "Streetwise",
                        "Survival","VaccSuit"
                    })},
        };

        public Dictionary<string, TravellerNationsCharacterInfo> GetTravellerNationsCharacterInfos() =>
            travellerNationsInfo;
    }
}
