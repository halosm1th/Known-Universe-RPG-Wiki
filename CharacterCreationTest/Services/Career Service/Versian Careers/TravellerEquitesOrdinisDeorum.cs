﻿using System;
using System.Collections.Generic;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.CreationEvents;
using TravellerWiki.Data.Services.CareerService.PolandskianCareeres;
using TravellerWiki.Data.Services.CareerService.VersianCareeres;
using static TravellerWiki.Data.Charcters.TravellerAttributes;
using static TravellerWiki.Data.Charcters.TravellerSkills;

namespace TravellerWiki.Data.Services.CareerService.VersianCareeres
{
    class TravellerEquitesOrdinisDeorum : TravellerVersianCareers
    {
        public static TravellerNationsCharacterInfo EquitesOrdinisDeorumNation => new TravellerNationsCharacterInfo(
            "Equites Ordinis deorum",
            TravellerNationalities.Equites_Ordinis_deorum,
            backgroundText:
            "The elite Knights of the Gods serve as the Versian response to things like the Luna Knights, or the Witchers. While technically being an Order now under the command of the Empress, the Knights of the Gods truly serve those within the Void, not just their embodiment in this plane of existence.",
            statChanges: new List<(TravellerAttributes Stat, int ChangeBy)>
            {
                (Psionics, 2), (Social, -1)
            },
            perks: new List<TravellerCharacterCreationReward>
            {
                new TravellerRewardItem(new List<TravellerItem>
                {
                    new TravellerItem("Versian Citizenship", 10000, 1, 20),

                    new TravellerWeapon("Ordinis Void Blade", 10000000, 1, 20,
                        0, "12D12", 0, "Void"),

                    new TravellerArmour("Ordinis Armour", 5000000, 100, 18,
                        500, 30, "+2 str, +2 dex, +6 Psi, 20 slots, Vacc Suit 2"),

                }),
                new TravellerRewardSkill(new List<TravellerSkill>
                {
                    new TravellerSkill(Language_HighVersian, 2),
                    new TravellerSkill(Langauge_LowVersian, 1),
                    new TravellerSkill(Religion_Deorism),

                })
            },
            backgroundSkills: new Dictionary<int, TravellerSkill>()
            {
                {0, new TravellerSkill(Admin)},
                {1, new TravellerSkill(Advocate)},
                {2, new TravellerSkill(Art)},
                {3, new TravellerSkill(Melee)},
                {4, new TravellerSkill(FreeForm_Material)},
                {5, new TravellerSkill(FreeForm_Abyss)},
                {6, new TravellerSkill(Electronics)},
                {7, new TravellerSkill(FreeForm_Nether)},
                {8, new TravellerSkill(Language)},
                {9, new TravellerSkill(FreeForm_Void)},
                {10, new TravellerSkill(Medic)},
                {11, new TravellerSkill(GunCombat)},
                {12, new TravellerSkill(Science)},
                {13, new TravellerSkill(FreeForm_Aether)},
                {14, new TravellerSkill(Streetwise)},
                {15, new TravellerSkill(Survival)},
                {16, new TravellerSkill(VaccSuit)},
            },
            entryRequirements: new List<TravellerAttributeCheck>
            {
                new TravellerAttributeCheck(Psionics, 6),
                new TravellerAttributeCheck(Social, 8)
            },
            drifter: "Versian Knight", drafts: new string[] {"Equites Ordinis Deorum"},
            parentNation:TravellerNationalities.Fifth_Vers_Empire);

        public static TravellerCareer EquitesOrdinisDeorum()
        {
            var career = new TravellerEquitesOrdinisDeorum();

            return career.GetEquitesOrdinisDeorum();
        }
        Random random = new Random();

        public TravellerCareer GetEquitesOrdinisDeorum()
        {
            return new TravellerCareer(
       careerName: "Equites Ordinis Deorum",
       description: "The Equites Ordinis Deorum are those blessed within the Vers empire to not only have been granted the honour of bearing the title of knight, but also having been born with a gift from the gods, the ability to bring from the realm above to the realm material the desires of the knight.",
       nationality: TravellerNationalities.Equites_Ordinis_deorum,
       qualifications: new List<TravellerAttributeCheck>
       {
                    new TravellerAttributeCheck(Psionics,10),
       },
       assignments: new List<TravellerAssignment>
       {
                    new TravellerAssignment(
                        name: "Order of Offense",
                        description: "You are the defenders of the faith, you use the powers of the planes to keep the Empire safe and your lord in power.",
                        survival: new TravellerAttributeCheck(Psionics,8),
                        advancement: new TravellerAttributeCheck(Strength,8),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Melee_Void),
                            GetSkillTableEntry(FreeForm),
                            GetSkillTableEntry(Tactics_Military),
                            GetSkillTableEntry(FreeForm),
                            GetSkillTableEntry(Strength),
                            GetSkillTableEntry(GunCombat),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Knight", new TravellerRewardMulti(new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardSkill(FreeForm,1),
                                new TravellerRewardItem(new List<TravellerItem>
                                {
                                    new TravellerWeapon("Equites Void Blade",12000000,1,25,15,"8D20",1,"Can Shoot a single overchaged shot that does 4D20 Damage with a ranged Gun Combat (Void) attack.")
                                })
                            })),
                            ("Brother Knight", new TravellerRewardSkill(FreeForm)),
                            ("Sergeant Knight", new TravellerRewardSkill(FreeForm)),
                            ("Lieutenant Knight", new TravellerRewardSkill(FreeForm)),
                            ("Knight Captain", new TravellerRewardSkill(FreeForm)),
                            ("Knight Commander", new TravellerRewardSkill(FreeForm)),
                        }),

                    new TravellerAssignment(
                        name: "Order of Defense",
                        description: "You are the defenders of your Brothers. You use powers from beyond the material, as well as a deeper understanding of science and medicine to help keep those in the order alive and well defended.",
                        survival: new TravellerAttributeCheck(Psionics,8),
                        advancement: new TravellerAttributeCheck(Endurance,6),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(FreeForm),
                            GetSkillTableEntry(Science),
                            GetSkillTableEntry(Medic),
                            GetSkillTableEntry(Stealth),
                            GetSkillTableEntry(FreeForm),
                            GetSkillTableEntry(Melee_Void),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Knight", new TravellerRewardMulti(new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardSkill(FreeForm,1),
                                new TravellerRewardItem(new List<TravellerItem>
                                {
                                    new TravellerWeapon("Equites Void Blade",12000000,1,25,15,"8D20",1,"Can Shoot a single overchaged shot that does 4D20 Damage with a ranged Gun Combat (Void) attack.")
                                })
                            })),
                            ("Brother Knight", new TravellerRewardSkill(FreeForm)),
                            ("Sergeant Knight", new TravellerRewardSkill(FreeForm)),
                            ("Lieutenant Knight", new TravellerRewardSkill(FreeForm)),
                            ("Knight Captain", new TravellerRewardSkill(FreeForm)),
                            ("Knight Commander", new TravellerRewardSkill(FreeForm)),
                        }),

                    new TravellerAssignment(
                        name: "Order of Utility",
                        description: "The order of utility, the largest of the orders, if you join the Order of Utility you develop the support position for your fellow knights. While Defense and Offense may be leading the charge on the battlefield, Utility is decoding the enemies battle plans while simultaneously other operatives schmooze the opposing leaders.",
                        survival: new TravellerAttributeCheck(Psionics,8),
                        advancement: new TravellerAttributeCheck(Education,8),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Electronics),
                            GetSkillTableEntry(Language),
                            GetSkillTableEntry(Diplomat),
                            GetSkillTableEntry(Recon),
                            GetSkillTableEntry(Survival),
                            GetSkillTableEntry(Streetwise),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Knight", new TravellerRewardMulti(new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardSkill(FreeForm,1),
                                new TravellerRewardItem(new List<TravellerItem>
                                {
                                    new TravellerWeapon("Equites Void Blade",12000000,1,25,15,"8D20",1,"Can Shoot a single overchaged shot that does 4D20 Damage with a ranged Gun Combat (Void) attack.")
                                })
                            })),
                            ("Brother Knight", new TravellerRewardSkill(FreeForm)),
                            ("Sergeant Knight", new TravellerRewardSkill(FreeForm)),
                            ("Lieutenant Knight", new TravellerRewardSkill(FreeForm)),
                            ("Knight Captain", new TravellerRewardSkill(FreeForm)),
                            ("Knight Commander", new TravellerRewardSkill(FreeForm)),
                        }),

       },
       personalDevelopmentSkillList: new List<TravellerSkillTableEntry>
       {
                    GetSkillTableEntry(Psionics),
                    GetSkillTableEntry(Strength),
                    GetSkillTableEntry(Endurance),
                    GetSkillTableEntry(Intelligence),
                    GetSkillTableEntry(Education),
                    GetSkillTableEntry(Social),
       },
       serviceSkillsList: new List<TravellerSkillTableEntry>
       {
                    GetSkillTableEntry(FreeForm_Void),
                    GetSkillTableEntry(FreeForm_Aether),
                    GetSkillTableEntry(FreeForm_Material),
                    GetSkillTableEntry(Psionics),
                    GetSkillTableEntry(FreeForm_Abyss),
                    GetSkillTableEntry(FreeForm_Nether),
       }, musteringOutBenefits: new List<(int Cash, TravellerCharacterCreationReward Benefit)>
       {
                    (100000, new TravellerRewardItem(new List<TravellerItem>
                        {
                            new TravellerWeapon("Equites Void Blade",12000000,1,25,15,"8D20",1,"Can Shoot a single overchaged shot that does 4D20 Damage with a ranged Gun Combat (Void) attack.")
                        })),
                    (250000, new TravellerRewardOther("You gain the a landing fort in the style of the Equites Ordinis Deorum")),
                    (500000, new TravellerRewardOther("You gain a knight-world as a fief")),
                    (750000, new TravellerRewardItem(new List<TravellerItem>
                    {
                        new TravellerItem("Universalis Confederation Passport",100000,0,20),
                    })),
                    (1000000,new TravellerRewardItem(new List<TravellerItem>
                    {
                        new TravellerArmour("Equites Armour",20000000,50,25,
                            800,45,"+4 str, +4 dex, +8 Psi, 25 Slots, Vacc Suit 3, Psi 6"),
                    })),
                    (1250000, new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                        {
                            {"Noble 1",TravellerNPCRelationship.Contact},
                            {"Noble 2",TravellerNPCRelationship.Contact},
                            {"Noble 3",TravellerNPCRelationship.Contact},
                            {"Noble 4",TravellerNPCRelationship.Contact},
                            {"Noble 5",TravellerNPCRelationship.Contact},
                            {"Noble 6",TravellerNPCRelationship.Contact},
                        })),
                    (1500000, new TravellerRewardAugment()),
       },
       events: new List<TravellerEventCharacterCreation>
       {
                    new TravellerEventMishap("Disaster! Roll on the mishap table, but you are not ejected from the career"),
                    
                    new TravellerEventSkillCheck("You are called forth by your lord as a key member of a military engagement to use your powers to turn the battle.",
                        yesEvent:new TravellerEventReward("Your powers flow forth and win the battle for your master", 
                            new TravellerRewardAdvancement(3)),
                        noEvent:new TravellerEventRewardAttribute("You fail to turn the battle and as a result are cast out by your Master and riddiculed by your fellow Knights", 
                            new TravellerAttribute(Social,2)), 
                        skillCheck:new TravellerSkillCheck(FreeForm,8)),

                    new TravellerEventReward("You spend the term training with your fellow Order members, refining your skills."
                        ,new TravellerRewardSkillAny()),

                    new TravellerEventChoice("You are invited to a secret meeting by a Hellsbeckian, asking if they can count on your support if anything were to happen.",
                        yesText:"Of course, I stand behind the True Emperor!",
                        yesEvent:new TravellerEventReward("The group takes you into their folds, murmurs of it spread around the Temple.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardAttribute(Social,-1),
                                new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                                {
                                    {"Hellsbeckian loyalist 1", TravellerNPCRelationship.Ally },
                                    {"Hellsbeckian loyalist 2", TravellerNPCRelationship.Ally },
                                })
                            }),
                        noText:"I would never betray the Rightful Empress!",
                        noEvent:new TravellerEventReward("The group denounces you and swear to destroy you.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardAttribute(Social,1),
                                new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                                {
                                    {"Hellsbeckian loyalist 1", TravellerNPCRelationship.Enemy },
                                    {"Hellsbeckian loyalist 2", TravellerNPCRelationship.Enemy },
                                })
                            })),

                    new TravellerEventAttributeCheck("You spend the term studying with your fellow knights in the libraries of your Monastery giving you a chance to increase your Education.",
                        successEvent:new TravellerEventRewardAttribute("You spend the term studying hard in the library, learning many new things",Education), 
                        failEvent:new TravellerEventText("You spend more of it goofing off then actually studying."), 
                        attributeChecks:new List<TravellerAttributeCheck>{new TravellerAttributeCheck(Education,6)}),

                    new TravellerEventLife("You have a life event!"),

                    new TravellerEventSkillCheck("You spend the term in a siege for your liege, and as a result have many days filled with bloody battles.",
                        yesEvent:new TravellerEventRewardSkill("You conquor the lands with ease.",
                            new List<TravellerSkills>{Melee_Void,GunCombat}),
                        noEvent:new TravellerEventInjury("You are wounded in the siege!"), 
                        skillChecks:new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(Melee_Void,6),
                            new TravellerSkillCheck(GunCombat_Slug,6),
                        }),

                    new TravellerEventSkillCheck("You spend the term on the training field with your fellow Knights.",
                        yesEvent:new TravellerEventRewardSkill("You push yourself harder then you expected, growing stronger thanks to the practice.",
                            Athletics),
                        noEvent:new TravellerEventText("You practice and train as you usually would"),
                        skillCheck:new TravellerSkillCheck(Athletics,6)),

                    new TravellerEventChoice("Some of your fellow Order members invite you to an after hours ritual deep in the catacombs of the Temple you are in.",
                        yesText:"I join them at this meeting.",
                        yesEvent: new TravellerEventChoice("You join a dark ceremony honouring one of the Abyssal beings, when your turn comes to take the pledge of allegiance to the otherworldly being",
                            yesText:"You agree to take the pledge",
                            yesEvent:new TravellerEventReward("You agree to join the cult, and you to take their pledge.",
                                new List<TravellerCharacterCreationReward>
                                {
                                    new TravellerRewardAttribute(Psionics,3),
                                    new TravellerRewardSkill(FreeForm_Abyss),
                                    new TravellerRewardSkill(Deception),
                                    new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                                    {
                                        {"Cultist 1",TravellerNPCRelationship.Contact},
                                        {"Cultist 2",TravellerNPCRelationship.Contact},
                                        {"Human Secretion of the abyssal being brought forth on that fateful night.",TravellerNPCRelationship.Contact},
                                    })
                                }),
                            noText:"You try to lie your way through the pledge",
                            noEvent:new TravellerEventSkillCheck("You try to lie your way through the pledge to the otherworldly being",
                                yesEvent:new TravellerEventReward("You lie your way through the ceremony. Feeling as though you've come to gain a deeper understanding of the fabric of the Unvierse.", 
                                    new List<TravellerCharacterCreationReward>
                                {
                                        new TravellerRewardAttribute(Psionics,1),
                                        new TravellerRewardSkill(FreeForm_Abyss),
                                        new TravellerRewardSkill(Deception)
                                }), 
                                noEvent:new TravellerEventReward("You are unable to resist the cult, and they force you to take their pledge.",
                                    new List<TravellerCharacterCreationReward>
                                    {
                                        new TravellerRewardAttribute(Psionics,3),
                                        new TravellerRewardSkill(FreeForm_Abyss),
                                        new TravellerRewardSkill(Deception),
                                        new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                                        {
                                            {"Cultist 1",TravellerNPCRelationship.Contact},
                                            {"Cultist 2",TravellerNPCRelationship.Contact},
                                            {"Human Secretion of the abyssal being brought forth on that fateful night.",TravellerNPCRelationship.Contact},
                                        })
                                    }),
                                skillCheck:new TravellerSkillCheck(Deception,8) 
                                )), 
                        noText:"I have other concerns to attend to.",
                        noEvent:new TravellerEventText("You deal with your other issues. Though you do hear rumours and stories about a strange otherworldy meeting happening somewhere in the Temple.")),

                    new TravellerEventSkillCheck("Your Knight-World is suffering from a famine and in desperation you decided to use some magic to solve the issue.",
                        yesEvent:new TravellerEventRewardAttribute("You are able to create food for your knight world, and are hailed as a hero on your world",new TravellerAttribute(Social,1)),
                        noEvent:new TravellerEventRewardAttribute("You are vilanized in the media as a result of your peril",new TravellerAttribute(Social,-1)),
                        skillCheck:new TravellerSkillCheck(FreeForm,8)),

                    new TravellerEventText("You spend the term tending to minor issues on your Knight-World."),
       },
       mishaps: new List<TravellerEventCharacterCreation>
       {
                    new TravellerEventSeverelyInjured("You are severely injured!"),
                    new TravellerEventChangeCareers("Whether your fault or not, blame is placed on you for a mishap resulting in death during an extra-planar event, you are kicked out of the order but allowed to keep your title and armour.","Versian Knight"),
                    new TravellerEventChangeCareers("The specific reasons for your banishment are removed from the Orders books, so as to preserve the names of those involved, as a result you are allowed to keep your armour and blade, but you may no longer consider yourself a member of the Equites Ordinis Deorum.","Versian Knight"),
                    new TravellerEventChangeCareers("You fail to cast a spell, and the peril causes a Daemon to appear, ruining the temple you’re training in, you are banished from the Order.","Versian Knight"),
                    new TravellerEventChangeCareers("You fail to uphold your Feudal duties and as a result lose your Knightly title, and thus your position in the Equites Ordinis Deroum","Versian Knight"),
                    new TravellerEventInjury("You are injured!"),
       }
   );
        }
    }
}