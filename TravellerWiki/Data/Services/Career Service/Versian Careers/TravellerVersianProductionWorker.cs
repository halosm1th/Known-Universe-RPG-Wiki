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
    class TravellerVersianProductionWorker : TravellerVersianCareers
    {
        public static TravellerCareer VersianProductionWorker()
        {
            var career = new TravellerVersianProductionWorker();

            return career.GetNationCareer();
        }

        Random random = new Random();

        public TravellerCareer GetNationCareer()
        {
            return new TravellerCareer(
                careerName: "Versian Production Worker",
                description:
                "You are a worker of the Versian Empire. You produce goods that keep the heart and soul of the empire strong and expanding. You’re the essential underpinning of Versian Society, even if no one knows it.",
                nationality: TravellerNationalities.Fifth_Vers_Empire,
                qualifications: new List<TravellerAttributeCheck>
                {
                    new TravellerAttributeCheck(Strength, 4),
                    new TravellerAttributeCheck(Dexterity, 4),
                    new TravellerAttributeCheck(Endurance, 4),
                },
                assignments: new List<TravellerAssignment>
                {
                    new TravellerAssignment(
                        name: "Factory Worker",
                        description:
                        "You are a worker in the factories that produce the goods that keep your fellow subjects of the Empire and your Lord happy.",
                        survival: new TravellerAttributeCheck(Dexterity, 5),
                        advancement: new TravellerAttributeCheck(Education, 6),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Profession_Construction),
                            GetSkillTableEntry(Athletics_Dexterity),
                            GetSkillTableEntry(Electronics_RemoteOps),
                            GetSkillTableEntry(Profession_Polymers),
                            GetSkillTableEntry(Drive_Walker),
                            GetSkillTableEntry(Mechanic),
                        },
                        ranksAndBonuses: new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Worker", new TravellerRewardSkill(Profession)),
                            ("Master Worker", new TravellerRewardSkill(Mechanic)),
                            ("Line Master", new TravellerRewardSkill(Engineer)),
                            ("Room Master", new TravellerRewardSkill(Electronics_RemoteOps)),
                            ("Floor Master", new TravellerRewardSkill(Electronics)),
                            ("Factory Master", new TravellerRewardAttribute(Social, 1)),
                        }),

                    new TravellerAssignment(
                        name: "Field Worker",
                        description:
                        "You work the fields that produce the food for the Empire! You feed the people and the war machine. Without you the people would surely riot while starving.",
                        survival: new TravellerAttributeCheck(Endurance, 5),
                        advancement: new TravellerAttributeCheck(Social, 6),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Profession_Biologicals),
                            GetSkillTableEntry(Animals),
                            GetSkillTableEntry(Flyer),
                            GetSkillTableEntry(Endurance),
                            GetSkillTableEntry(Drive_Track),
                            GetSkillTableEntry(Profession_Hydroponics),
                        },
                        ranksAndBonuses: new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Farm Hand", new TravellerRewardSkill(Animals)),
                            ("Field Worker", new TravellerRewardSkill(Profession_Hydroponics)),
                            ("Master Field Worker", new TravellerRewardSkill(Mechanic)),
                            ("Line Master", new TravellerRewardSkill(Profession_Biologicals)),
                            ("Field Master", new TravellerRewardSkill(Drive)),
                            ("Farm Master", new TravellerRewardAttribute(Social, 1)),
                        }),

                    new TravellerAssignment(
                        name: "Dock Worker",
                        description:
                        "You manage the docks of the empire. Both liquid and star. You make sure the goods get on the ships that take them where they need to go.",
                        survival: new TravellerAttributeCheck(Strength, 5),
                        advancement: new TravellerAttributeCheck(Intelligence, 6),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Profession_Belter),
                            GetSkillTableEntry(Athletics_Strength),
                            GetSkillTableEntry(Endurance),
                            GetSkillTableEntry(Seafarer_Personal),
                            GetSkillTableEntry(Drive_HoverCraft),
                            GetSkillTableEntry(Medic),
                        },
                        ranksAndBonuses: new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Fetcher", new TravellerRewardSkill(Drive_HoverCraft)),
                            ("Hauler", new TravellerRewardSkill(Seafarer)),
                            ("Ship Master", new TravellerRewardSkill(Leadership)),
                            ("Warehouse Master", new TravellerRewardSkill(Admin)),
                            ("Dock Master", new TravellerRewardSkill(Advocate)),
                            ("Yard Master", new TravellerRewardAttribute(Social, 1)),
                        }),

                },
                personalDevelopmentSkillList: new List<TravellerSkillTableEntry>
                {
                    GetSkillTableEntry(Drive),
                    GetSkillTableEntry(Mechanic),
                    GetSkillTableEntry(Gambler),
                    GetSkillTableEntry(Athletics),
                    GetSkillTableEntry(Streetwise),
                    GetSkillTableEntry(Profession),
                },
                serviceSkillsList: new List<TravellerSkillTableEntry>
                {
                    GetSkillTableEntry(VaccSuit),
                    GetSkillTableEntry(Profession),
                    GetSkillTableEntry(Pilot_SmallCraft),
                    GetSkillTableEntry(Athletics),
                    GetSkillTableEntry(Engineer_Power),
                    GetSkillTableEntry(Electronics_Computers),
                }, musteringOutBenefits: new List<(int Cash, TravellerCharacterCreationReward Benefit)>
                {
                    (5000, new TravellerRewardItem("One Ship Share", 10000, 1, 15)),
                    (7500, new TravellerRewardContact("Contact from Work", TravellerNPCRelationship.Contact)),
                    (10000, new TravellerRewardAttribute(Strength, 1)),
                    (12500, new TravellerRewardVehicle()),
                    (15000, new TravellerRewardContact("Ally from Work", TravellerNPCRelationship.Ally)),
                    (20000, new TravellerRewardItem("Two Ship Shares", 20000, 1, 15)),
                    (50000, new TravellerRewardOther("Personal Shuttle")),
                },
                mishaps: new List<TravellerEventCharacterCreation>
                {
                    new TravellerEventSeverelyInjured("You are severely injured!"),
                    
                    new TravellerEventRewardContact("Get caught fraternizing with the bosses favorite child.",
                        new List<TravellerRewardContact>
                        {
                            new TravellerRewardContact("Boss's Child",TravellerNPCRelationship.Contact),
                            new TravellerRewardContact("Ex-Boss", TravellerNPCRelationship.Enemy)
                        }),
                    
                    new TravellerEventSkillCheck("Having spent the better part of your career quietly skimming off the top, you finally got caught. Try and get away with some of the money though",
                        yesEvent:new TravellerEventReward("You were able to stash some money", new System.Collections.Generic.List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardBonusBenefit(2),
                            new TravellerRewardBenefitIncrease(1),
                        }), 
                        noEvent:new TravellerEventReward("", new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardBenefitIncrease(1),
                            new TravellerRewardJobChange("Versian Prisoner")
                        }),
                        skillCheck:(Deception,8)),
                    
                    new TravellerEventText("Thinking that you and your fellow workers deserve better pay, you begin to investigate collective bargaining. At the first whiff of this, the owner decides to lay off all the staff."),
                    
                    new TravellerEventText("You’re caught slacking off after a recent fall in output, your boss decides to make an example and lets you go."),
                    
                    new TravellerEventInjury("You are injured!"),
                },
                events: new List<TravellerEventCharacterCreation>
                {
                    new TravellerEventMishap(
                        "Disaster! Roll on the mishap table, but you are not ejected from the career"),
                    new TravellerEventChoice("Your knight is called into war and must raise an army. You are called to serve, do you do so?",
                        yesEvent:new TravellerEventChangeCareers("You join your knights army to do your part","Versian Army"), 
                        noEvent:new TravellerEventAttributeCheck("Your forced to defend your draft dodging.",
                            successEvent:new TravellerEventReward("You are able to stay out of the military, but it effects your chances at a promotion", new TravellerRewardAdvancement(-2)), 
                            failEvent: new TravellerEventChangeCareerWithAssignment("You are drafted into your lords army", "Versian Army","Footman"), 
                            attributeCheck:(Social,6))),

                    new TravellerEventAttributeCheck("There was a murder at your work, and everyone is being interrogated about it.",
                        successEvent: new TravellerEventReward("You are able to pass the interrogation, even though it is long and grueling.",new TravellerRewardAttribute(Social,2)), 
                        failEvent: new TravellerEventChangeCareers("You are found guilty of the murder, regardless of the truth of that statement, and are sent to prison for it.", "Versian Prisoner"), 
                        attributeCheck:(Social,6)),

                    new TravellerEventReward("You come up with a good idea on how to improve productivity", new TravellerRewardAdvancement(1)),

                    new TravellerEventAttributeCheck("Some workers formed a union together and were then let go. You avoided joining for whatever reason. You try to suck up the factory owner.",
                        successEvent: new TravellerEventReward("You are promoted for your sucking up skills", new TravellerRewardAdvancement(10)), 
                        failEvent:new TravellerEventReward("The owner doesn't take kindly to your ass kissing.", new TravellerRewardAdvancement(-2)), 
                        attributeCheck:(Social,6)),

                    new TravellerEventLife("You have a life event!"),

                    new TravellerEventSkillChoiceReward("You spend much of your term learning to drive one of the vehicles at your work.", new List<TravellerSkills>
                    {
                       Drive_HoverCraft,
                       Drive_Mole,
                       Drive_Track,
                       Drive_Walker,
                       Drive_Wheel
                    }),

                    new TravellerEventChoice("You find out one of your coworkers it stealing, do your report them?",
                        yesEvent: new TravellerEventReward("You hand them in, your boss seems to keep an eye on you, and promises it reflects well come review time", new TravellerRewardAdvancement(2)), 
                        noEvent:new TravellerEventRewardContact("You gain a new contact because of this", "Stealing coworker",TravellerNPCRelationship.Contact)),

                    new TravellerEventAttributeCheck("The Economy tanks this term, prove your worth", 
                        successEvent: new TravellerEventReward("You work hard, and your bosses take note.",new TravellerRewardAdvancement(2)), 
                        failEvent:new TravellerEventReward("It hurts, and the company is forced to make some cuts, but you stay employed.",new TravellerRewardBonusBenefit(-1)),
                        attributeChecks:new List<TravellerAttributeCheck>
                        {
                            new TravellerAttributeCheck(Social,6),
                            new TravellerAttributeCheck(Strength,9),
                            new TravellerAttributeCheck(Dexterity,9),
                            new TravellerAttributeCheck(Endurance,9),

                        }),

                    new TravellerEventReward("The economy boomed this term, and you're rewarded handsomely for it.", new TravellerRewardBonusBenefit(2)),

                    new TravellerEventChoice("Some members have been talking about forming a union. Do you want to join?",
                        yesEvent: new TravellerEventSkillCheck("To get it started, you need ot keep it a secrete.",
                            yesEvent: new TravellerEventReward("You are able to negotiate a higher salary for everyone!", new TravellerRewardBenefitIncrease(2)), 
                            noEvent: new TravellerEventChangeCareers("You are kicked out of your job and back to being a citizen","Versian Civis"), 
                            skillCheck:(Stealth,6)), 
                        noEvent: new TravellerEventText("You choose not to join, you spend the term hearing about others you work with forming a small union but it falling apart due to lack of members.")),
                }
            );
        }
    }
}