using System.Collections.Generic;
using System.Linq;
using TravellerCharacter.Character_Services.Career_Service.Polandskian_Careers;
using TravellerCharacter.Character_Services.Career_Service.Versian_Careers;
using TravellerCharacter.CharacterParts;
using TravellerCharacter.CharcterTypes;

namespace TravellerCharacter.Character_Services
{
    public class TravellerNationsCharacterInfoService
    {
        private static List<TravellerNationsCharacterInfo> travellerNationsInfo = new List<TravellerNationsCharacterInfo>()
        {
            /* {
                 "Universalis Confederation",
                 new TravellerNationsCharacterInfo(
                     "Universalis Confederation",
                     backgroundText: "The Universalis Confederation exists as both a government and a forum for the major nations to conduct peace negotiations and try and prevent war. While 90%+ of the population who legally are with the Universalis Confederation are also Witchers, the remaining people are mostly those who happened to work within the Confederation or their children.",
                     statChanges: new List<(TravellerAttributes Stat, int ChangeBy)>
                     {
                         (Education,2),(Social,1),(Endurance,-2)
                     },
                     perks:new List<TravellerCharacterCreationReward>
                     {
                         new TravellerRewardCharacterCreationItem(new List<TravellerItem>
                         {
                             new TravellerItem("Universalis Confederation Passport",100000,0,20),
                             new TravellerItem("TAS Membership",1000000,0,20)
                         }),
                         new TravellerRewardCharacterCreationSkill(new List<TravellerSkill>
                         {
                             new TravellerSkill(Language_Common, 1),
                             new TravellerSkill(Language, 1),
                             new TravellerSkill(Religion_Witcherism),
                         })
                     },
                     backgroundSkills:new Dictionary<int, TravellerSkill>
                     {
                         {0, new TravellerSkill(Admin)},
                         {1,new TravellerSkill(Animals)},
                         {2,new TravellerSkill(Art)},
                         {3,new TravellerSkill(Athletics)},
                         {4,new TravellerSkill(Carouse)},
                         {5,new TravellerSkill(Drive)},
                         {6,new TravellerSkill(Electronics)},
                         {7,new TravellerSkill(Flyer)},
                         {8,new TravellerSkill(Language)},
                         {9,new TravellerSkill(Mechanic)},
                         {10,new TravellerSkill(Medic)},
                         {11,new TravellerSkill(Profession)},
                         {12,new TravellerSkill(Science)},
                         {13,new TravellerSkill(Seafarer)},
                         {14,new TravellerSkill(Streetwise)},
                         {15,new TravellerSkill(Survival)},
                         {16,new TravellerSkill(VaccSuit)}
                     },
                     drifter:"Witcher Citizen",
                     drafts:new []{"Universalis Defense Army", "Universalis Defense Navy"})
 
             },
             {
                 "Witcher",
                 new TravellerNationsCharacterInfo("Witcher",
                     backgroundText: "The Witchers are a cross between peacekeepers, military leaders, police, and monster hunters. They are recruited from worlds and trained aboard massive Kaer-Stella (Star Keeps) filled with dozens of cities dedicated to that world ship's different schools.",
                     statChanges: new List<(TravellerAttributes Stat, int ChangeBy)>
                     {
                         (Strength,2),(Social,1),(Education,-1)
                     },
                     perks:new List<TravellerCharacterCreationReward>
                     {
                         new TravellerRewardCharacterCreationItem(new List<TravellerItem>
                         {
                             new TravellerWeapon("Void Blade",5000000,1,20,0,"12D12",0,"Void"),
                             new TravellerItem("Witcher",100000000,0,1)
                         }),
                         new TravellerRewardCharacterCreationSkill(new List<TravellerSkill>
                             {
                                 new TravellerSkill(Language_Witcher, 1),
                                 new TravellerSkill(Language, 1),
                                 new TravellerSkill(Religion_Witcherism),
                             })
 
                     },
                     backgroundSkills:new Dictionary<int, TravellerSkill>()
                     {
                         {0, new TravellerSkill(Melee_Void)},
                         {1,new TravellerSkill(Recon)},
                         {2,new TravellerSkill(Art)},
                         {3,new TravellerSkill(Athletics)},
                         {4,new TravellerSkill(Carouse)},
                         {5,new TravellerSkill(Deception)},
                         {6,new TravellerSkill(JackOfAllTrades)},
                         {7,new TravellerSkill(Persuade)},
                         {8,new TravellerSkill(Language)},
                         {9,new TravellerSkill(Mechanic)},
                         {10,new TravellerSkill(Medic)},
                         {11,new TravellerSkill(Profession)},
                         {12,new TravellerSkill(Science)},
                         {13,new TravellerSkill(Stealth)},
                         {14,new TravellerSkill(Streetwise)},
                         {15,new TravellerSkill(Survival)},
                         {16,new TravellerSkill(VaccSuit)},
                     },
                     entryRequirements:new List<TravellerAttributeCheck>
                     {
                         new TravellerAttributeCheck(Psionics, 6), 
                         new TravellerAttributeCheck(Social, 8)
                     }, 
                     drifter:"Witcher Citizen", drafts:new string[]{"Witcher"},
                     parentNation:"Universalis Confederation")
             },
             {
                 "United Federation of Earth and her Colonies Among the Stars",
                 new TravellerNationsCharacterInfo("United Federation of Earth and her Colonies Among the Stars",
                     backgroundText: "The United Federation of Earth is an unequal paradise full of contradictions. While it is a place of equality and justice, there is a house of Lords and all land is owned by a few elite. While you are legally free to do as you like, you must be a part of the state. While there are many perks, the cushy life leads many intellectuals to a premature death.",
                     statChanges: new List<(TravellerAttributes Stat, int ChangeBy)>
                     {
                         (Education,+2),(Intelligence,+2),(Endurance,-2),(Strength,-1)
                     },
                     perks:new List<TravellerCharacterCreationReward>
                     {
                         new TravellerRewardCharacterCreationItem(new List<TravellerItem>
                         {
                             new TravellerAugments("Optional Neural Net", 5000000,1,20,"A tiny but powerful semi-organic micro-computer embded at the base of a persons skull. The computer a 20mm rectangle, and serves as the interface for most augmentations. Once inserted into the skull, its tendrils will slowly spread throughout the users brain until fully integrated and able to intrepret commands without verbal cues.   is able to transmit multiple forms of data, Computer/5. Necessary component for most augmentations","Base of Skull"),
                             new TravellerItem("Federation Citizenship",100,1,10)
                         }),
                         new TravellerRewardCharacterCreationSkill(new List<TravellerSkill>
                             {
                                 new TravellerSkill(Language_FederationCommon, 1),
                                 new TravellerSkill(Religion_Witcherism),
                             })
                     },
                     backgroundSkills:new Dictionary<int, TravellerSkill>()
                     {
                         {0,new TravellerSkill(Admin)},
                         {1,new TravellerSkill(Advocate)},
                         {2,new TravellerSkill(Art)},
                         {3,new TravellerSkill(Astrogation)},
                         {4,new TravellerSkill(Engineer)},
                         {5,new TravellerSkill(Persuade)},
                         {6,new TravellerSkill(Electronics)},
                         {7,new TravellerSkill(Flyer)},
                         {8,new TravellerSkill(Language)},
                         {9,new TravellerSkill(Mechanic)},
                         {10,new TravellerSkill(Medic)},
                         {11,new TravellerSkill(Profession)},
                         {12,new TravellerSkill(Science)},
                         {13,new TravellerSkill(Seafarer)},
                         {14,new TravellerSkill(Streetwise)},
                         {15,new TravellerSkill(Gambler)},
                         {16,new TravellerSkill(VaccSuit)},
                     }, 
                     drifter:"Federation Citizen", drafts:new []
                     {
                         "Federation Army", 
                         "Federation Navy",
                         "Federation Scout",
                         "Lords Military"
                     })},
             {
                 "Luna Knights",
                 new TravellerNationsCharacterInfo("Luna Knights",
                     backgroundText: "The sworn defenders of Earth, protectors of the jewel, the Luna Knights are known throughout the Universe for their strength and their near mythical standards for warriors make being a member of the Luna Knights an honour bestowed only on the chosen few of society.",
                     statChanges: new List<(TravellerAttributes Stat, int ChangeBy)>
                     {
                         (Social,1),(Strength,2),(Dexterity,2),(Intelligence,-2),(Education,-2)
                     },
                     perks:new List<TravellerCharacterCreationReward>
                     {
                         new TravellerRewardCharacterCreationItem(new List<TravellerItem>
                         {
                             new TravellerWeapon("Knights Void Blade",5000000,1,20,0,"12D12",0,"Void"),
                             new TravellerArmour("Knights Armour",5000000,100,18,500,30,"+4 str, +4 dex, 20 slots, Vacc Suit 2"),
                             new TravellerItem("Knights Transport",100000000,1,13)
                         }),
                         new TravellerRewardCharacterCreationSkill(new List<TravellerSkill>
                             {
                                 new TravellerSkill(Language_HighVersian, 1),
                                 new TravellerSkill(Language_FederationCommon, 1),
                                 new TravellerSkill(Religion_Deorism),
                             })
                     },
                     backgroundSkills:new Dictionary<int, TravellerSkill>()
                     {
                         {0, new TravellerSkill(GunCombat)},
                         {1, new TravellerSkill(Melee)},
                         {2, new TravellerSkill(Explosives)},
                         {3, new TravellerSkill(Deception)},
                         {4, new TravellerSkill(Gunner)},
                         {5, new TravellerSkill(HeavyWeapons)},
                         {6, new TravellerSkill(Electronics)},
                         {7, new TravellerSkill(Flyer)},
                         {8, new TravellerSkill(Drive)},
                         {9, new TravellerSkill(Pilot)},
                         {10, new TravellerSkill(Recon)},
                         {11, new TravellerSkill(Stealth)},
                         {12, new TravellerSkill(Tactics)},
                         {13, new TravellerSkill(Seafarer)},
                         {14, new TravellerSkill(Streetwise)},
                         {15, new TravellerSkill(Survival)},
                         {16, new TravellerSkill(VaccSuit)},
                     },
                     entryRequirements:new List<TravellerAttributeCheck>
                     {
                         new TravellerAttributeCheck(Dexterity,8),
                         new TravellerAttributeCheck(Endurance,8),
                         new TravellerAttributeCheck(Psionics,8),
                         new TravellerAttributeCheck(Strength,8)
                     }, drifter:"Luna Knight", drafts:new string[]{"Luna Knight"},
                     parentNation:"United Federation of Earth and her Colonies Among the Stars")},*/
           TravellerVersianCareers.VersianNation,
           TravellerEquitesOrdinisDeorum.EquitesOrdinisDeorumNation,
            /*{
                "United Reverse Lords",
                new TravellerNationsCharacterInfo("United Reverse Lords",
                    backgroundText: "Following the Deutschland defaulting on their war debt, the Vers empire fell into civil war before eventually fracturing into two. The United Reverse Lords seeks to continue the great work done by Emperor Reveres and takes heavy inspiration from the First Vers Republic.",
                    statChanges: new List<(TravellerAttributes Stat, int ChangeBy)>
                    {
                        (Education,2),(Intelligence,2),(Social,-1),
                    },
                    perks:new List<TravellerCharacterCreationReward>
                    {
                        new TravellerRewardCharacterCreationItem(new List<TravellerItem>
                        {
                            new TravellerItem("United Reverse Lords Citizenship",100,1,10),
                            new TravellerAugments("Optional Neural Net", 5000000,1,20,"A tiny but powerful semi-organic micro-computer embded at the base of a persons skull. The computer a 20mm rectangle, and serves as the interface for most augmentations. Once inserted into the skull, its tendrils will slowly spread throughout the users brain until fully integrated and able to intrepret commands without verbal cues.   is able to transmit multiple forms of data, Computer/5. Necessary component for most augmentations","Base of Skull"),

                        }),
                        new TravellerRewardCharacterCreationSkill(new List<TravellerSkill> {
                                new TravellerSkill(Language_HighVersian, 1),
                                new TravellerSkill(Langauge_LowVersian, 1),
                                new TravellerSkill(Religion_Deorism),

                            })
                    },
                    backgroundSkills:new Dictionary<int, TravellerSkill>()
                    {
                        {0, new TravellerSkill(Admin)},
                        {1, new TravellerSkill(Animals)},
                        {2, new TravellerSkill(Art)},
                        {3, new TravellerSkill(Athletics)},
                        {4, new TravellerSkill(Carouse)},
                        {5, new TravellerSkill(Drive)},
                        {6, new TravellerSkill(Electronics)},
                        {7, new TravellerSkill(Flyer)},
                        {8, new TravellerSkill(Language)},
                        {9, new TravellerSkill(Mechanic)},
                        {10, new TravellerSkill(Medic)},
                        {11, new TravellerSkill(Profession)},
                        {12, new TravellerSkill(Science)},
                        {13, new TravellerSkill(Seafarer)},
                        {14, new TravellerSkill(Streetwise)},
                        {15, new TravellerSkill(Survival)},
                        {16, new TravellerSkill(VaccSuit)},
                    },
                    drifter:"Reverse Military Industry", drafts:new string[]
                    {
                        "Reverse Army", 
                        "Reverse Navy", 
                        "Reverse Spy"
                    })},
            {
                "Xiao-Ming Mega Corporation",
                new TravellerNationsCharacterInfo("Xiao-Ming Mega Corporation",
                    backgroundText: "Following a bloody defeat in the great war and the loss of their control over the Axion Alliance, Xiao-Ming Industries has been forced to lay off a large amount of “wasteful expenditures”, otherwise known as employees. While many are still paying off their corporate conception/birth/life/property damage/etc-debts and thus are forced to continue to be impossibly employed.",
                    statChanges: new List<(TravellerAttributes Stat, int ChangeBy)>
                    {
                        (Dexterity,2),(Education,1),(Social,-2),(Intelligence,-1),
                    },
                    perks:new List<TravellerCharacterCreationReward>
                    {
                        new TravellerRewardCharacterCreationItem(new List<TravellerItem>
                        {
                            new TravellerItem("Xiao-Ming Exit Package (pays cost per month)",200,1,9),
                            new TravellerItem("Xiao-Ming Employee Card",100,1,9),
                        }),
                        new TravellerRewardCharacterCreationSkill(new List<TravellerSkill> {
                                new TravellerSkill(Langauge_XiaoMing, 1),
                                new TravellerSkill(Language_AxiosPolitical, 1),
                                new TravellerSkill(Religion_JediIsm),

                            })
                    },
                    backgroundSkills:new Dictionary<int, TravellerSkill>()
                    {
                        {0, new TravellerSkill(Admin)},
                        {1, new TravellerSkill(Advocate)},
                        {2, new TravellerSkill(Broker)},
                        {3, new TravellerSkill(Athletics)},
                        {4, new TravellerSkill(Astrogation)},
                        {5, new TravellerSkill(Drive)},
                        {6, new TravellerSkill(Navigation)},
                        {7, new TravellerSkill(Flyer)},
                        {8, new TravellerSkill(Language)},
                        {9, new TravellerSkill(Mechanic)},
                        {10, new TravellerSkill(Profession)},
                        {11, new TravellerSkill(Profession)},
                        {12, new TravellerSkill(Science)},
                        {13, new TravellerSkill(Seafarer)},
                        {14, new TravellerSkill(Streetwise)},
                        {15, new TravellerSkill(Steward)},
                        {16, new TravellerSkill(VaccSuit)},
                    }, 
                    drifter:"Production", 
                    drafts:new string[]
                    {
                        "Defense Contracting"
                    })},
            {
                "Communist Empire of the Deutschland",
                new TravellerNationsCharacterInfo("Communist Empire of the Deutschland",
                    backgroundText: "Backbreaking work, a constant diet of propaganda, the only relief being the even more propaganda filled church sermons. Life is nasty, brutish, and if you’re lucky, short. Labour camps await anyone caught trying to leave the Utopian communist wonderland, while positions that leave the communal-empire are covenanted to only the chosen few comrades of the empress and her closest admirals, generals, bankers, priests and friends.",
                    statChanges: new List<(TravellerAttributes Stat, int ChangeBy)>
                    {
                        (Education,-2),(Intelligence,-1),(Social,-2),(Strength,+4),(Endurance,+3),(Dexterity,+2),
                    },
                    perks:new List<TravellerCharacterCreationReward>
                    {
                        new TravellerRewardCharacterCreationSkill(new List<TravellerSkill> {
                                new TravellerSkill(Language_germushian, 1),
                                new TravellerSkill(Religion_Sigmarism),

                            })
                    },
                    backgroundSkills:new Dictionary<int, TravellerSkill>()
                    {
                        {0, new TravellerSkill(Deception)},
                        {1, new TravellerSkill(Animals)},
                        {2, new TravellerSkill(Stealth)},
                        {3, new TravellerSkill(Athletics)},
                        {4, new TravellerSkill(Persuade)},
                        {5, new TravellerSkill(Drive)},
                        {6, new TravellerSkill(Electronics)},
                        {7, new TravellerSkill(Flyer)},
                        {8, new TravellerSkill(Language)},
                        {9, new TravellerSkill(Mechanic)},
                        {10, new TravellerSkill(Medic)},
                        {11, new TravellerSkill(Profession)},
                        {12, new TravellerSkill(Science)},
                        {13, new TravellerSkill(Seafarer)},
                        {14, new TravellerSkill(Streetwise)},
                        {15, new TravellerSkill(Survival)},
                        {16, new TravellerSkill(VaccSuit)},
                    }, 
                    drifter:"Deutschland Prisoner", drafts:new string[]
                    {
                        "Deutschland Army", 
                        "Deutschland Navy", 
                        "Deutschland Colonizer",
                        "Deutschland Priest"
                    })},
            {
                "Church of Sigmar",
                new TravellerNationsCharacterInfo("Church of Sigmar",
                    backgroundText: "The holy light, the one true god, the only true god. The powerhouse behind the Deutschland and the creators of the almost demi-god like sigmarines. As well the churches inquisitors act as their magical enforcers and commanders. ",
                    statChanges: new List<(TravellerAttributes Stat, int ChangeBy)>
                    {
                        (Psionics,1), (Social,1), (Strength,1),
                    },
                    perks:new List<TravellerCharacterCreationReward>
                    {
                        new TravellerRewardCharacterCreationItem(new List<TravellerItem>
                        {
                            new TravellerItem("Sexton of Sigmar (Holy Relic)",10000,3,16),
                        }),
                        new TravellerRewardCharacterCreationSkill(new List<TravellerSkill> {
                                new TravellerSkill(Language_germushian, 1),
                                new TravellerSkill(Langauge_Sigmarian, 1),
                                new TravellerSkill(Religion_Sigmarism),

                            })
                    },
                    backgroundSkills:new Dictionary<int, TravellerSkill>()
                    {
                        {0, new TravellerSkill(Advocate)},
                        {1, new TravellerSkill(Language)},
                        {2, new TravellerSkill(Melee)},
                        {3, new TravellerSkill(GunCombat)},
                        {4, new TravellerSkill(Carouse)},
                        {5, new TravellerSkill(Deception)},
                        {6, new TravellerSkill(Persuade)},
                        {7, new TravellerSkill(Science)},
                        {8, new TravellerSkill(Profession)},
                        {9, new TravellerSkill(Medic)},
                        {10, new TravellerSkill(Survival)},
                        {11, new TravellerSkill(VaccSuit)},
                    },
                    entryRequirements:new List<TravellerAttributeCheck>
                    {
                        new TravellerAttributeCheck(Social,10),
                        new TravellerAttributeCheck(Psionics,8)
                    }, 
                    drifter:"Deutschland Priest", drafts:new string[]
                    {
                        "Deutschland Priest", 
                        "Sigmarine", 
                        "Inquisitor of Sigmar"
                    },
                    parentNation:"Communist Empire of the Deutschland")},
            {
                "Germushian Free Republic",
                new TravellerNationsCharacterInfo("Germushian Free Republic",
                    backgroundText: "The best things in life may be free, but money, that's what you want. The Germushian Free Republic says Free Enterprise is the way forward. Government should be as out of the way as those pesky protestors. So long as you got the money that is. Of course, this drives the drug cartels who back the government to make sure that the average citizen actually has an okay life.",
                    statChanges: new List<(TravellerAttributes Stat, int ChangeBy)>
                    {
                        (Education,+2),(Social,+2),(Endurance,-2),(Intelligence,-1),
                    },
                    perks:new List<TravellerCharacterCreationReward>
                    {
                        new TravellerRewardCharacterCreationSkill(new List<TravellerSkill> {
                                new TravellerSkill(Language_germushian, 1),
                                new TravellerSkill(Language_Common, 1),
                                new TravellerSkill(Religion_Lawgarism),

                            })
                    },
                    backgroundSkills:new Dictionary<int, TravellerSkill>()
                    {
                        { 0, new TravellerSkill(Advocate)},
                        { 1, new TravellerSkill(Animals)},
                        { 2, new TravellerSkill(Broker)},
                        { 3, new TravellerSkill(Deception)},
                        { 4, new TravellerSkill(Carouse)},
                        { 5, new TravellerSkill(Drive)},
                        { 6, new TravellerSkill(Gambler)},
                        { 7, new TravellerSkill(Flyer)},
                        { 8, new TravellerSkill(Language)},
                        { 9, new TravellerSkill(JackOfAllTrades)},
                        { 10, new TravellerSkill(Persuade)},
                        { 11, new TravellerSkill(Profession)},
                        { 12, new TravellerSkill(Science)},
                        { 13, new TravellerSkill(Steward)},
                        { 14, new TravellerSkill(Streetwise)},
                        { 15, new TravellerSkill(Stealth)},
                        { 16, new TravellerSkill(VaccSuit)},
                    }, 
                    drifter:"Cartel Worker", 
                    drafts:new string[]
                    {
                        "Government Military",
                        "Cartel Military",
                    })},*/
            TravellerPolandskianCareers.PolandskiaNation,
            /*
            {
                "Trans Galactic Empire",
                new TravellerNationsCharacterInfo("Trans Galactic Empire",
                    backgroundText: "The Empire has only recently been redeclared by the newly crowned Emperor Kylo Ren. Life within the empire is clearly split among the three social classes of Imperial, Citizen, and Resident. Where Imperial is anyone working in service of the empire. Citizens can enjoy a good life while residents can enjoy breathing something related to air.",
                    statChanges: new List<(TravellerAttributes Stat, int ChangeBy)>
                    {
                        (Strength,1),
                        (Education,1),
                        (Dexterity,-1),
                        (Intelligence,-1),
                    },
                    perks:new List<TravellerCharacterCreationReward>
                    {
                        new TravellerRewardCharacterCreationItem(new List<TravellerItem>
                        {
                            new TravellerAugments("Neural Net", 5000000,1,20,"A tiny but powerful semi-organic micro-computer embded at the base of a persons skull. The computer a 20mm rectangle, and serves as the interface for most augmentations. Once inserted into the skull, its tendrils will slowly spread throughout the users brain until fully integrated and able to intrepret commands without verbal cues.   is able to transmit multiple forms of data, Computer/5. Necessary component for most augmentations","Base of Skull"),

                        }),
                        new TravellerRewardCharacterCreationSkill(new List<TravellerSkill> {
                                new TravellerSkill(Langauge_HighImperial, 1),
                                new TravellerSkill(Langauge_LowImperial, 1),
                                new TravellerSkill(Religion_ModernSithism),

                            })
                    },
                    backgroundSkills:new Dictionary<int, TravellerSkill>()
                    {
                        { 0, new TravellerSkill(Admin)},
                        { 1, new TravellerSkill(Advocate)},
                        { 2, new TravellerSkill(Art)},
                        { 3, new TravellerSkill(Athletics)},
                        { 4, new TravellerSkill(Diplomat)},
                        { 5, new TravellerSkill(Drive)},
                        { 6, new TravellerSkill(Melee)},
                        { 7, new TravellerSkill(GunCombat)},
                        { 8, new TravellerSkill(Language)},
                        { 9, new TravellerSkill(Leadership)},
                        { 10, new TravellerSkill(Medic)},
                        { 11, new TravellerSkill(Profession)},
                        { 12, new TravellerSkill(Science)},
                        { 13, new TravellerSkill(Steward)},
                        { 14, new TravellerSkill(Streetwise)},
                        { 15, new TravellerSkill(Tactics)},
                        { 16, new TravellerSkill(VaccSuit)},
                    }, 
                    drifter:"Imperial Mafia", drafts:new string[]
                    {
                        "Imperial Army",
                        "Imperial Navy",
                        "Imperial Storm Troopers"
                    })},
            {
                "Sith",
                new TravellerNationsCharacterInfo("Sith",
                    backgroundText: "The Sith are the Church of the Empire, as declared by the First Emperor Sheeve Palpatine, also known by his Sith title as Darth Sideous. Today with Darth Reserecteous at the head of the church the Sith are back, stronger than ever.",
                    statChanges: new List<(TravellerAttributes Stat, int ChangeBy)>
                    {
                        (Psionics,2),(Strength,1),(Dexterity,1),(Intelligence,1),(Social,1),(Education,1)
                    },
                    perks:new List<TravellerCharacterCreationReward>
                    {
                        new TravellerRewardCharacterCreationItem(new List<TravellerItem>
                        {
                            new TravellerWeapon("Sith Void Blade",5000000,1,20,0,"12D12",0,"Void"),

                        }),
                        new TravellerRewardCharacterCreationSkill(new List<TravellerSkill> {
                                new TravellerSkill(Langauge_HighImperial, 1),
                                new TravellerSkill(Language_Sith, 1),
                                new TravellerSkill(Religion_Sithism),

                            })
                    },
                    backgroundSkills:new Dictionary<int, TravellerSkill>()
                    {
                        { 0, new TravellerSkill(Melee_Void)},
                        { 1, new TravellerSkill(Language)},
                        { 2, new TravellerSkill(VaccSuit)},
                        { 3, new TravellerSkill(Deception)},
                        { 4, new TravellerSkill(FreeForm)},
                        { 5, new TravellerSkill(Streetwise)},
                        { 6, new TravellerSkill(Stealth)},
                        { 7, new TravellerSkill(Recon)},
                    },
                    entryRequirements:new List<TravellerAttributeCheck>
                    {
                        new TravellerAttributeCheck(Psionics,8)
                    }, drifter:"Imperial Mafia", drafts:new string[]
                    {
                        "Sith",
                        "Imperial Army",
                        "Imperial Navy"
                    },
                    parentNation:"Trans Galactic Empire")},
            {
                "First Order",
                new TravellerNationsCharacterInfo("First Order",
                    backgroundText: "The most fanatical of the factions within the Empire, founded for that very purpose by the first emperor himself. Having recently failed to invade the Federation, the First Order returned to prominence upon the return of Britannia, now their looming military awaits another chance at war.",
                    statChanges: new List<(TravellerAttributes Stat, int ChangeBy)>
                    {
                        (Social,1),(Strength,1),(Dexterity,1),(Endurance,-1),(Intelligence,-2),(Education,-1),
                    },
                    perks:new List<TravellerCharacterCreationReward>
                    {
                        new TravellerRewardCharacterCreationItem(new List<TravellerItem>
                        {
                            new TravellerItem("Imperial Status",1000000,1,18),
                            new TravellerAugments("Neural Net", 5000000,1,20,"A tiny but powerful semi-organic micro-computer embded at the base of a persons skull. The computer a 20mm rectangle, and serves as the interface for most augmentations. Once inserted into the skull, its tendrils will slowly spread throughout the users brain until fully integrated and able to intrepret commands without verbal cues.   is able to transmit multiple forms of data, Computer/5. Necessary component for most augmentations","Base of Skull"),

                            new TravellerWeapon("First Order Void Knife",10000000,1,20,
                                0,"6D12",0,"Void"),
                        }),
                        new TravellerRewardCharacterCreationSkill(new List<TravellerSkill> {
                                new TravellerSkill(Langauge_HighImperial, 2),
                                new TravellerSkill(Religion_OrthodoxSithism),

                            })
                    },
                    backgroundSkills:new Dictionary<int, TravellerSkill>()
                    {
                        { 0, new TravellerSkill(Admin)},
                        { 1, new TravellerSkill(Melee)},
                        { 2, new TravellerSkill(GunCombat)},
                        { 3, new TravellerSkill(Athletics)},
                        { 4, new TravellerSkill(HeavyWeapons)},
                        { 5, new TravellerSkill(Drive)},
                        { 6, new TravellerSkill(Electronics)},
                        { 7, new TravellerSkill(Flyer)},
                        { 8, new TravellerSkill(Language)},
                        { 9, new TravellerSkill(Mechanic)},
                        { 10, new TravellerSkill(Medic)},
                        { 11, new TravellerSkill(Gunner)},
                        { 12, new TravellerSkill(Explosives)},
                        { 13, new TravellerSkill(Seafarer)},
                        { 14, new TravellerSkill(Streetwise)},
                        { 15, new TravellerSkill(Survival)},
                        { 16, new TravellerSkill(VaccSuit)},
                    }, 
                    drifter:"Imperial Mafia", drafts:new string[]
                    {
                        "Elite Storm Trooper",
                        "Elite Imperial Navy",
                        "Imperial Army",
                        "Imperial Navy",
                        "Imperial Stormtrooper"
                    },
                    parentNation:"Trans Galactic Empire")},
            {
                "The Kingdom of Britannia",
                new TravellerNationsCharacterInfo("The Kingdom of Britannia",
                    backgroundText: "The Kingdom of Britannia once was the Empire, then it was part of Vers. Now the unique culture that has developed here finally has its own unique name, even if it does reside under the Imperial banner, those within Britannia tend to be closer to classical Vader-Imperials than the modern Neo-Palpatinian-Imperial.",
                    statChanges: new List<(TravellerAttributes Stat, int ChangeBy)>
                    {
                        (Intelligence,1),(Education,1),
                    },
                    perks:new List<TravellerCharacterCreationReward>
                    {
                        new TravellerRewardCharacterCreationSkill(new List<TravellerSkill> {
                                new TravellerSkill(Langauge_LowImperial, 1),
                                new TravellerSkill(Religion_BritannianSithism, 0),
                                new TravellerSkill(Langauge_Britannian,1),

                            })
                    },
                    backgroundSkills:new Dictionary<int, TravellerSkill>()
                    {
                        { 0, new TravellerSkill(Admin)},
                        { 1, new TravellerSkill(Animals)},
                        { 2, new TravellerSkill(Art)},
                        { 3, new TravellerSkill(Athletics)},
                        { 4, new TravellerSkill(Carouse)},
                        { 5, new TravellerSkill(Drive)},
                        { 6, new TravellerSkill(Electronics)},
                        { 7, new TravellerSkill(Flyer)},
                        { 8, new TravellerSkill(Language)},
                        { 9, new TravellerSkill(Mechanic)},
                        { 10, new TravellerSkill(Medic)},
                        { 11, new TravellerSkill(Profession)},
                        { 12, new TravellerSkill(Science)},
                        { 13, new TravellerSkill(Seafarer)},
                        { 14, new TravellerSkill(Streetwise)},
                        { 15, new TravellerSkill(Survival)},
                        { 16, new TravellerSkill(VaccSuit)},
                    },
                    drifter:"Imperial Mafia", drafts:new []
                    {
                        "Britannian Military",
                        "Imperial Army",
                        "Imperial Navy",
                        "Imperial Stormtrooper"
                    },
                    parentNation:"Trans Galactic Empire")},
            {
                "Imperial Versian Federated Territories",
                new TravellerNationsCharacterInfo("Imperial Versian Federated Territories",
                    backgroundText: "After a bloody war for independence with Britannia that only ended when the Emperor officially joined the war on the side of the Territories that Britannia would eventually back off. Now the democratic nation is the puppet of a despotic empire, for now trapped in an abusive relationship, assured protection by their protector, the Emperor.",
                    statChanges: new List<(TravellerAttributes Stat, int ChangeBy)>
                    {
                        (Intelligence,2),(Social,-1),(Strength,-1),(Endurance,1),
                    },
                    perks:new List<TravellerCharacterCreationReward>
                    {
                        new TravellerRewardCharacterCreationItem(new List<TravellerItem>
                        { 
                            new TravellerAugments("Neural Net", 5000000,1,20,"A tiny but powerful semi-organic micro-computer embded at the base of a persons skull. The computer a 20mm rectangle, and serves as the interface for most augmentations. Once inserted into the skull, its tendrils will slowly spread throughout the users brain until fully integrated and able to intrepret commands without verbal cues.   is able to transmit multiple forms of data, Computer/5. Necessary component for most augmentations","Base of Skull"),
                            new TravellerItem("Imperial Citizen Status",10000,1,18),

                        }),
                        new TravellerRewardCharacterCreationSkill(new List<TravellerSkill> {
                                new TravellerSkill(Langauge_LowImperial, 1),
                                new TravellerSkill(Langauge_LowVersian, 1),
                                new TravellerSkill(Religion_Deorism),

                            })
                    },
                    backgroundSkills:new Dictionary<int, TravellerSkill>()
                    {
                        { 0, new TravellerSkill(Melee)},
                        { 1, new TravellerSkill(Animals)},
                        { 2, new TravellerSkill(Art)},
                        { 3, new TravellerSkill(Athletics)},
                        { 4, new TravellerSkill(Carouse)},
                        { 5, new TravellerSkill(Drive)},
                        { 6, new TravellerSkill(Electronics)},
                        { 7, new TravellerSkill(Flyer)},
                        { 8, new TravellerSkill(Language)},
                        { 9, new TravellerSkill(GunCombat)},
                        { 10, new TravellerSkill(Medic)},
                        { 11, new TravellerSkill(Profession)},
                        { 12, new TravellerSkill(Science)},
                        { 13, new TravellerSkill(Seafarer)},
                        { 14, new TravellerSkill(Streetwise)},
                        { 15, new TravellerSkill(Survival)},
                        { 16, new TravellerSkill(VaccSuit)},
                    },
                    drifter:"Imperial Mafia", drafts:new []
                    {
                        "IVFT Military",
                        "Imperial Army",
                        "Imperial Navy",
                        "Imperial Stormtrooper"
                    },
                    parentNation:"Trans Galactic Empire")},
            {
                "Axion Alliance",
                new TravellerNationsCharacterInfo("Axion Alliance",
                    backgroundText: "Founded following the first Sol war, nearly 82,000 years ago, the Axion Alliance has persisted as the longest standing peace agreement in Human history. Today it unites alien nations all around a foriegn galaxy who once were oppressed by Xiao-Ming Industries now are once again given a chance at freedom.",
                    statChanges: new List<(TravellerAttributes Stat, int ChangeBy)>
                    {
                        (Dexterity,1),(Intelligence,1),
                    },
                    perks:new List<TravellerCharacterCreationReward>
                    {
                        new TravellerRewardCharacterCreationItem(new List<TravellerItem>
                        {
                            new TravellerItem("Alliance Status",1000,1,15),
                        }),
                        new TravellerRewardCharacterCreationSkill(new List<TravellerSkill> {
                                new TravellerSkill(Language_AxiosCommon, 1),
                                new TravellerSkill(Language_AxiosPolitical, 1),
                                new TravellerSkill(Religion_JediIsm),

                            })
                    },
                    backgroundSkills:new Dictionary<int, TravellerSkill>()
                    {
                        { 0, new TravellerSkill(Admin)},
                        { 1, new TravellerSkill(Advocate)},
                        { 2, new TravellerSkill(Animals)},
                        { 3, new TravellerSkill(Art)},
                        { 4, new TravellerSkill(Athletics)},
                        { 5, new TravellerSkill(Broker)},
                        { 6, new TravellerSkill(Carouse)},
                        { 7, new TravellerSkill(Drive)},
                        { 8, new TravellerSkill(Electronics)},
                        { 9, new TravellerSkill(Engineer)},
                        { 10, new TravellerSkill(Flyer)},
                        { 11, new TravellerSkill(Language)},
                        { 12, new TravellerSkill(Mechanic)},
                        { 13, new TravellerSkill(Medic)},
                        { 14, new TravellerSkill(Pilot)},
                        { 15, new TravellerSkill(Profession)},
                        { 16, new TravellerSkill(Science)},
                        { 17, new TravellerSkill(Seafarer)},
                        { 18, new TravellerSkill(Streetwise)},
                        { 19, new TravellerSkill(Survival)},
                        { 20, new TravellerSkill(VaccSuit)},
                    }, 
                    drifter:"Ex-Corper", drafts:new []
                    {
                        "Axion Army",
                        "Axion Navy"
                    })

            },
            {
                "Artekkan Guilds",
                new TravellerNationsCharacterInfo("Artekkan Guilds",
                    backgroundText: "Little is known of the secretive Artekkan Guilds. Their massive mining ships rarely dock with anyone, and their automated trade-ships seemingly have no human crews. Their cities are reported to be diamond underground palaces of lush green connected by voidgates, a technology thought impossible at this level by the rest of the universe",
                    statChanges: new List<(TravellerAttributes Stat, int ChangeBy)>
                    {
                        (Dexterity,2),(Endurance,1),(Social,-4),(Education,1),(Intelligence,1),
                    },
                    perks:new List<TravellerCharacterCreationReward>
                    {
                        new TravellerRewardCharacterCreationItem(new List<TravellerItem>
                        {
                            new TravellerItem("Guild Card",1000000,1,25),
                        }),
                        new TravellerRewardCharacterCreationSkill(new List<TravellerSkill> {
                                new TravellerSkill(Language_Tekka, 1),
                                new TravellerSkill(Language_Common, 1),
                                new TravellerSkill(Religion_Gatism),

                            })
                    },
                    backgroundSkills:new Dictionary<int, TravellerSkill>
                    {
                        {0, new TravellerSkill(Admin)},
                        {1, new TravellerSkill(Astrogation)},
                        {2, new TravellerSkill(Broker)},
                        {3, new TravellerSkill(Diplomat)},
                        {4, new TravellerSkill(Carouse)},
                        {5, new TravellerSkill(Pilot)},
                        {6, new TravellerSkill(Electronics)},
                        {7, new TravellerSkill(Flyer)},
                        {8, new TravellerSkill(Language)},
                        {9, new TravellerSkill(Mechanic)},
                        {10, new TravellerSkill(Engineer)},
                        {11, new TravellerSkill(VaccSuit)},
                        {12, new TravellerSkill(Gambler)},
                        {13, new TravellerSkill(Persuade)}
                    },
                    drifter:"Guild Worker", drafts:new string[]
                    {
                        "Guild Defender"
                    },
                    parentNation:"Axion Alliance")},
                    */
        };


        public List<TravellerNationsCharacterInfo> GetNationsList =>
            GetTravellerNationsCharacterInfos().Select(x => x).ToList();
        public List<TravellerNationsCharacterInfo> GetTravellerNationsCharacterInfos() =>
            travellerNationsInfo;
        public TravellerNationsCharacterInfo GetNationsCharacterInfo(TravellerNationalities nationality) => GetNationsList.First(x => x.Nationality == nationality);

    }
}
