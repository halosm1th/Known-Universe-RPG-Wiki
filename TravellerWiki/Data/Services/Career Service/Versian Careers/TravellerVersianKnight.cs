using System;
using System.Collections.Generic;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.CreationEvents;
using TravellerWiki.Data.Services.CareerService.PolandskianCareeres;
using TravellerWiki.Data.Services.CareerService.VersianCareeres;
using static TravellerWiki.Data.Charcters.TravellerAttributes;
using static TravellerWiki.Data.Charcters.TravellerSkills;

namespace TravellerWiki.Data.Services.CareerService.NationsCareeres
{
    class TravellerVersianKnight : TravellerVersianCareers
    {
        public static TravellerCareer VersianKnight()
        {
            var career = new TravellerVersianKnight();

            return career.GetVersianKnight();
        }
        Random random = new Random();

        public TravellerCareer GetVersianKnight()
        {
            return new TravellerCareer(
       careerName: "Versian Knight",
       description: "A Versian Knight is the lowest form of proper nobility within the Vers Empire. Being both commander of their Lords Levies, and also keeper of their Knight-World. The role of Versian Knight is a complicated one.",
       nationality: TravellerNationalities.Fifth_Vers_Empire,
       qualifications: new List<TravellerAttributeCheck>
       {
                    new TravellerAttributeCheck(Social,12),
       },
       assignments: new List<TravellerAssignment>
       {
                    new TravellerAssignment(
                        name: "Warrior Knight",
                        description: "A warrior Knight is one who focuses on the battlefield. They may officially have a Knight-World, perhaps even one they earned on the battlefield, but the world only exists to supply Levies for the Knight to command under their lord, and provide a place for the Knight to rest in between wars.",
                        survival: new TravellerAttributeCheck(Strength,6),
                        advancement: new TravellerAttributeCheck(Strength,8),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Diplomat),
                            GetSkillTableEntry(Deception),
                            GetSkillTableEntry(Language),
                            GetSkillTableEntry(Advocate),
                            GetSkillTableEntry(Carouse),
                            GetSkillTableEntry(Persuade),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Page", new TravellerRewardItem(TravellerItemStoreService.GetItemStatic("Void Blade"))),
                            ("Squire", new TravellerRewardSkill(Melee_Void)),
                            ("Knight", new TravellerRewardItem(TravellerItemStoreService.GetItemStatic("Ordinis Armour"))),
                            ("Knight Lieutenant", new TravellerRewardSkill(GunCombat)),
                            ("Master Knight", new TravellerRewardSkill(Tactics)),
                            ("Knight Commander", new TravellerRewardAttribute(Social,2)),
                        }),

                    new TravellerAssignment(
                        name: "Civic Knight",
                        description: "A Civic Knight is focused on the role of statecraft on the Knight World, deeply focused on managing the worlds politics, possibly because the planet is a key part of their lord's Regolia or is for some other reason politically important.",
                        survival: new TravellerAttributeCheck(Intelligence,8),
                        advancement: new TravellerAttributeCheck(Social,6),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Diplomat),
                            GetSkillTableEntry(Deception),
                            GetSkillTableEntry(Language),
                            GetSkillTableEntry(Advocate),
                            GetSkillTableEntry(Carouse),
                            GetSkillTableEntry(Persuade),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Page", new TravellerRewardItem(TravellerItemStoreService.GetItemStatic("Void Blade"))),
                            ("Squire", new TravellerRewardSkill(Language)),
                            ("Knight", new TravellerRewardItem(TravellerItemStoreService.GetItemStatic("Ordinis Armour"))),
                            ("Knight Lieutenant", new TravellerRewardSkill(Deception)),
                            ("Master Knight", new TravellerRewardSkill(Leadership)),
                            ("Knight Commander", new TravellerRewardAttribute(Social,2)),
                        }),

                    new TravellerAssignment(
                        name: "Economic Knight",
                        description: "These Knights focus on the economy, whether limited to just their Knight-World or perhaps that of their sectors trade or perhaps even trade within the wider Regolia of their and neighboring Lords.",
                        survival: new TravellerAttributeCheck(Education,6),
                        advancement: new TravellerAttributeCheck(Intelligence,8),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Broker),
                            GetSkillTableEntry(Admin),
                            GetSkillTableEntry(Advocate),
                            GetSkillTableEntry(JackLuck),
                            GetSkillTableEntry(Persuade),
                            GetSkillTableEntry(Science),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Page", new TravellerRewardItem(TravellerItemStoreService.GetItemStatic("Void Blade"))),
                            ("Squire", new TravellerRewardSkill(Broker)),
                            ("Knight", new TravellerRewardItem(TravellerItemStoreService.GetItemStatic("Ordinis Armour"))),
                            ("Knight Lieutenant", new TravellerRewardSkill(Steward)),
                            ("Master Knight", new TravellerRewardSkill(Science_Economics)),
                            ("Knight Commander", new TravellerRewardAttribute(Social,2)),
                        }),

       },
       personalDevelopmentSkillList: new List<TravellerSkillTableEntry>
       {
                    GetSkillTableEntry(Leadership),
                    GetSkillTableEntry(Advocate),
                    GetSkillTableEntry(Broker),
                    GetSkillTableEntry(GunCombat),
                    GetSkillTableEntry(Deception),
                    GetSkillTableEntry(Investigate),
       },
       serviceSkillsList: new List<TravellerSkillTableEntry>
       {
                    GetSkillTableEntry(Diplomat),
                    GetSkillTableEntry(Melee),
                    GetSkillTableEntry(Admin),
                    GetSkillTableEntry(Steward),
                    GetSkillTableEntry(Art),
                    GetSkillTableEntry(Carouse),
       }, musteringOutBenefits: new List<(int Cash, TravellerCharacterCreationReward Benefit)>
       {
                    (25000, new TravellerRewardSkill(Language)),
                    (50000, new TravellerRewardItem(
                        TravellerItemStoreService.GetItemStatic("Universalis Confederation Passport"))),
                    (100000, new TravellerRewardSkill(JackLuck)),
                    (250000, new TravellerRewardOther("Landing Fort")),
                    (500000, new TravellerRewardItem(TravellerItemStoreService.GetItemStatic("Knights Revolver"))),
                    (750000, new TravellerRewardOther("You receive a personal vehicle, such as a ground car or air/raft. You can choose exactly what type of vehicle this is but it may not be armed and has a limit of Cr300000 and TL 10. If you roll this benefit again, gain a level of Drive or Flyer")),
                    (1000000, new TravellerRewardContact("Lord Contact",TravellerNPCRelationship.Ally)),
       },
       events: new List<TravellerEventCharacterCreation>
       {
                    new TravellerEventMishap("Disaster! Roll on the mishap table, but you are not ejected from the career"),
                    
                    new TravellerEventSkillCheck("A war breaks out on your knight world",
                        yesEvent:new TravellerEventRewardSkill("You are able to put the rebellion down", Melee_Void ), 
                        noEvent:new TravellerEventReward("The war is a failure and your forced take on debt.",new TravellerRewardCredits(1000000)),
                        skillCheck:new TravellerSkillCheck(Melee_Void,6)),

                    new TravellerEventSkillCheck("There is an economic disaster on your Knight-World.",
                        yesEvent:new TravellerEventRewardSkill("you are able to weather the disaster without too much econmic harm.",
                            Science_Economics),
                        noEvent:new TravellerEventChoice("Your unable to navigate the economic disaster, you need to pick between taking on debt or failing you feudal obligation.",
                            yesText:"Take on Debt",
                            yesEvent:new TravellerEventReward("You take on a fair bit of debt.",
                                new TravellerRewardCredits(random.Next(1,11) * 1000000)),
                            noEvent:new TravellerEventRewardAttribute("Your feudal obligation falters.",
                                new TravellerAttribute(Social,-1)),
                            noText:"Fail your Feudal Obligiton"), 
                        skillCheck:new TravellerSkillCheck(Science_Economics,8)),


                    new TravellerEventAttributeCheck("The political winds shift on your Knight-World.",
                        successEvent:new TravellerEventReward("You are able to expand your own power.",
                            new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                            {
                                {"Vassal 1",TravellerNPCRelationship.Contact },
                                {"Vassal 2",TravellerNPCRelationship.Contact },
                            })),
                        failEvent:new TravellerEventReward("You piss off your vassles.",
                            new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                            {
                                {"Vassal 1",TravellerNPCRelationship.Enemy},
                                {"Vassal 2",TravellerNPCRelationship.Enemy},
                                {"Vassal 3",TravellerNPCRelationship.Enemy},

                            })),
                        attributeCheck:new TravellerAttributeCheck(Social,6)),


                    new TravellerEventSkillCheck("There is a war between your Lord and another of their peers and you are called upon to do your part",
                        yesEvent:new TravellerEventReward("You are invaluable to your lords war effort.", new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardSkill(Melee_Void),
                            new TravellerRewardAdvancement(8)
                        }),
                        noEvent:new TravellerEventReward("The war is a failure, your master blames you for it.",new TravellerRewardAdvancement(-14)),
                        skillCheck:new TravellerSkillCheck(Melee_Void,6)),


                    new TravellerEventLife("You have a life event!"),

                    new TravellerEventAttributeCheck("The political winds shift with your Lord and you see a chance for a promotion.",
                        successEvent:new TravellerEventReward("You are able to navigate the situation and find yourself in your lords favour.",new TravellerRewardAdvancement(8)),
                        failEvent:new TravellerEventReward("You appear overeager and causing your lord to favour someone else.",new TravellerRewardAdvancement(-3)),
                        attributeCheck:new TravellerAttributeCheck(Social,6)),

                    new TravellerEventSkillCheck("The economics of your lord's Regolia has changed, and you are tagged to help",
                        yesEvent:new TravellerEventReward("You are able to gain a better economic position, and even make some profit for yourself",new TravellerRewardCredits(500000)),
                        noEvent:new TravellerEventReward("You  overextend yourself and are punished for it",new TravellerRewardDebt(1000000)),
                        skillCheck:new TravellerSkillCheck(Science_Economics,8)),

                    new TravellerEventSkillCheck("Your knight commander takes a chance to seize power from their rival, and call on you to help in the battle.",
                        yesEvent:new TravellerEventReward("You slay your foes! You thanks to your skills the battle is won/",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                                {
                                    {"Knight 1",TravellerNPCRelationship.Ally },
                                    {"Knight 2",TravellerNPCRelationship.Ally },
                                }),
                                new TravellerRewardSkill(Melee_Void),
                            }),
                        noEvent: new TravellerEventSeverelyInjured("You are wounded in battle"),
                        skillCheck:new TravellerSkillCheck(Melee_Void,8)),

                    new TravellerEventAttributeCheck("There is change in the political order under your Knight Commander and you are poised to take advantage of that change.",
                        successEvent:new TravellerEventReward("You are able to convince the others to follow you, gaining you some powerful allies and increasing your social standing.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                                {
                                    {"Noble 1",TravellerNPCRelationship.Contact },
                                    {"Noble 2",TravellerNPCRelationship.Contact },
                                }),
                                new TravellerRewardAttribute(Social,2),
                            }),
                        failEvent:new TravellerEventReward("You are unable to seize the chance, instead making enemies with those who do take power",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                                {
                                    {"Noble 1",TravellerNPCRelationship.Enemy},
                                    {"Noble 2",TravellerNPCRelationship.Enemy},
                                    {"Noble 3",TravellerNPCRelationship.Enemy},
                                    {"Noble 4",TravellerNPCRelationship.Enemy},
                                    {"Noble 5",TravellerNPCRelationship.Enemy},
                                }),
                                new TravellerRewardAttribute(Social,-2),
                            }),
                        attributeChecks: new List<TravellerAttributeCheck>{
                            new TravellerAttributeCheck(Social,8)
                        }),

                    new TravellerEventChangeCareers("It is discovered that you have the Gift of the Gods.","Equites Ordinius Deorum"),
       },
       mishaps: new List<TravellerEventCharacterCreation>
       {
                    new TravellerEventSeverelyInjured("You are severely injured!"),
                    new TravellerEventText("You disgrace yourself in front of your lord and their peers to such a great degree that you are removed from their service and your title revoked."),
                    new TravellerEventChangeCareers("A peasant uprising overtakes your planet, to appease the leader of the peasants your lord removes you from your position. Making you an aristocrat instead of a warrior.", "Versian Aristocractic"),
                    new TravellerEventText("After a disastrous harvest, you are called to serve your lord but are unable to muster the required levies and thus your contract is unfulfilled, costing you your title."),
                    new TravellerEventReward("You insult your lord greatly, while the offense is not so great that you lose your title or land, you do lose your contract with that lord.",
                    new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                    {
                        {"Enemy Knight 1", TravellerNPCRelationship.Enemy},
                        {"Enemy Knight 2", TravellerNPCRelationship.Enemy},
                        {"Enemy Knight 3", TravellerNPCRelationship.Enemy},
                    })),
                    new TravellerEventInjury("You are injured!"),
       }
   );
        }
    }
}