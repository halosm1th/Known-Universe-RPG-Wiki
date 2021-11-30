using System;
using System.Collections.Generic;
using TravellerCharacter.Character_Services.NPC_Services;
using TravellerCharacter.CharacterCreator;
using TravellerCharacter.CharacterCreator.Careers;
using TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward;
using TravellerCharacter.CharacterCreator.Careers.SkillEntry;
using TravellerCharacter.CharacterCreator.CreationEvents;
using TravellerCharacter.CharacterParts;
using TravellerCharacter.CharcterTypes;
using static TravellerCharacter.CharacterParts.TravellerSkills;
using static TravellerCharacter.CharacterParts.TravellerAttributes;

namespace TravellerCharacter.Character_Services.Career_Service.Versian_Careers
{
    internal class TravellerVersianIdeaCreator : TravellerVersianCareers
    {
        private Random random = new();

        public static TravellerCareer VersianIdeaCreator()
        {
            var career = new TravellerVersianIdeaCreator();

            return career.GetNationCareer();
        }

        public TravellerCareer GetNationCareer()
        {
            return new TravellerCareer(
                "Versian Idea Creator",
                "he brave thinkers kept in the noble courts of the Versian lords to think up the newest innovations that may tickle the fancy of their Great Noble, or advance their claims upon lesser nobles.",
                TravellerNationalities.Fifth_Vers_Empire,
                new List<TravellerAttributeCheck>
                {
                    new(Education, 6),
                    new(Intelligence, 8),
                    new(Social, 10)
                },
                new List<TravellerAssignment>
                {
                    new(
                        "Physics Thinker",
                        "You are one of the thinkers of physics problems within the Vers Empire. You help to create the newest weapons and ships of the empire.",
                        new TravellerAttributeCheck(Education, 6),
                        new TravellerAttributeCheck(Intelligence, 8),
                        new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Science_Physics),
                            GetSkillTableEntry(Education),
                            GetSkillTableEntry(Science_Cosmology),
                            GetSkillTableEntry(Electronics_Computers),
                            GetSkillTableEntry(Science_Voidology),
                            GetSkillTableEntry(Electronics_RemoteOps)
                        },
                        new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Teaching Assistant", new TravellerRewardSkill(Science)),
                            ("Lecturer", new TravellerRewardAttribute(Education)),
                            ("Teaching Professor", new TravellerRewardSkill(Electronics)),
                            ("Researching Professor", new TravellerRewardSkill(Language)),
                            ("Associate Professor", new TravellerRewardAttribute(Intelligence)),
                            ("Professor", new TravellerRewardSkill(Diplomat))
                        }),

                    new(
                        "Social Thinker",
                        "You are one of the social thinkers within the Vers Empire. Your job is to help your Lord craft social policy to prevent revolution.",
                        new TravellerAttributeCheck(Education, 6),
                        new TravellerAttributeCheck(Social, 8),
                        new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Science_History),
                            GetSkillTableEntry(Persuade),
                            GetSkillTableEntry(Science_Linguistics),
                            GetSkillTableEntry(Deception),
                            GetSkillTableEntry(Science_Philosophy),
                            GetSkillTableEntry(Language)
                        },
                        new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Teaching Assistant", new TravellerRewardSkill(Science)),
                            ("Lecturer", new TravellerRewardAttribute(Education)),
                            ("Teaching Professor", new TravellerRewardSkill(Electronics)),
                            ("Researching Professor", new TravellerRewardSkill(Language)),
                            ("Associate Professor", new TravellerRewardAttribute(Intelligence)),
                            ("Professor", new TravellerRewardSkill(Diplomat))
                        }),

                    new(
                        "Engineer Thinker",
                        "You are a Versian Engineer Thinker, your job is to come up with new ways to engineer and create machines for your Lord.",
                        new TravellerAttributeCheck(Intelligence, 6),
                        new TravellerAttributeCheck(Education, 8),
                        new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Science_Robotics),
                            GetSkillTableEntry(Engineer_MDrive),
                            GetSkillTableEntry(Science_Cybernetics),
                            GetSkillTableEntry(Engineer_Power),
                            GetSkillTableEntry(Mechanic),
                            GetSkillTableEntry(Engineer_LifeSupport)
                        },
                        new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Teaching Assistant", new TravellerRewardSkill(Science)),
                            ("Lecturer", new TravellerRewardAttribute(Education)),
                            ("Teaching Professor", new TravellerRewardSkill(Electronics)),
                            ("Researching Professor", new TravellerRewardSkill(Language)),
                            ("Associate Professor", new TravellerRewardAttribute(Intelligence)),
                            ("Professor", new TravellerRewardSkill(Diplomat))
                        })
                },
                personalDevelopmentSkillList: new List<TravellerSkillTableEntry>
                {
                    GetSkillTableEntry(Education),
                    GetSkillTableEntry(Social),
                    GetSkillTableEntry(Intelligence),
                    GetSkillTableEntry(JackLuck),
                    GetSkillTableEntry(Science),
                    GetSkillTableEntry(Education)
                },
                serviceSkillsList: new List<TravellerSkillTableEntry>
                {
                    GetSkillTableEntry(Science),
                    GetSkillTableEntry(Language),
                    GetSkillTableEntry(Science),
                    GetSkillTableEntry(Electronics),
                    GetSkillTableEntry(Science),
                    GetSkillTableEntry(Diplomat)
                }, musteringOutBenefits: new List<(int Cash, TravellerCharacterCreationReward Benefit)>
                {
                    (350,
                        new TravellerRewardOther(
                            "You receive a lab ship with 25% of the mortgage paid off on it. This lab ship is identical to the one on page 170 but you must roll 1D times on the Old Ships Table on page 165. If you roll this benefit again, an additional 25% of the mortgage has been paid off – if you roll this benefit four times, the lab ship will have no mortgage and it will be all yours!")),
                    (700, new TravellerRewardAttribute(Education)),
                    (1400,
                        new TravellerRewardOther(
                            "A research pet, either of your own creation as a favor to someone else.")),
                    (2800, new TravellerRewardAttribute(Social)),
                    (5600, new TravellerRewardOther("A special experimental augmentation")),
                    (11200, new TravellerRewardOther("A special experimental weapon")),
                    (22400, new TravellerRewardOther("You Gain 2 ship shares"))
                },
                mishaps: new List<TravellerEventCharacterCreation>
                {
                    new TravellerEventSeverelyInjured("You are severely injured!"),

                    new TravellerEventRewardAttribute(
                        "Your latest idea goes against the current orthodoxy, and as a result you are ostracized for it and kicked out from your post.",
                        Social, -2),

                    new TravellerEventChoice(
                        "You go ahead with an unapproved experiment, and during the experiment someone is killed and the blood is on your hands. Do you wish to try and flee?",
                        new TravellerEventSkillCheck("You attempt to flee, make a stealth check.",
                            new TravellerEventRewardSkill("You are barely able to get away, increase your stealth by 1",
                                Stealth),
                            new TravellerEventChangeCareers("You fail to flee and are sent to prison",
                                "Versian Prisoner"),
                            (Stealth, 8)),
                        new TravellerEventChangeCareers("You fail to flee and are sent to prison", "Versian Prisoner")),

                    new TravellerEventChoice(
                        "You are accused of having an inappropriate relationship with one of your students. Do you wish to try and deny the alligations?",
                        new TravellerEventSkillCheck("You try and argue your way out of the alligations",
                            new TravellerEventReward(
                                "You are able to fight the alligations, but are still transfered to a new school",
                                new List<TravellerCharacterCreationReward>
                                {
                                    new TravellerRewardAttribute(Social, -1),
                                    new TravellerRewardJobChange("Versian Idea Creator")
                                }),
                            new TravellerEventReward("You are discredited and publically shamed.",
                                new TravellerRewardAttribute(Social, -3)),
                            (Advocate, 8)),
                        new TravellerEventText(
                            "You slink away into the shadows as the news cycle eventually shifts to a different topic.")),

                    new TravellerEventText(
                        "Your ideas personally offend the Noble who’s court you’re in, and as a result you are removed from that court, and you are temporarily blacklisted in the sciences."),

                    new TravellerEventInjury("You are injured!")
                },
                events: new List<TravellerEventCharacterCreation>
                {
                    new TravellerEventMishap(
                        "Disaster! Roll on the mishap table, but you are not ejected from the career"),

                    new TravellerEventAttributeCheck(
                        "One of your fellow Idea Creators has come to you with a brilliant scheme to get higher in the pecking order and has asked for your help.",
                        new TravellerEventReward(
                            "You succeed! their plan works, you are able to impress your noble and fellow scientists greatly!",
                            new TravellerRewardAdvancement(2)),
                        new TravellerEventReward(
                            "It fails and you are exposed as a fraud, slightly discredited in your nobles eyes and the greater scientific community.",
                            new TravellerRewardAdvancement(-1)),
                        (Intelligence, 6)),

                    new TravellerEventRewardAttribute(
                        "You present a new idea that challenges the norm, taking your world and possibly the subsector by storm. You become famous as you spend the term visiting various planets and systems presenting your idea.",
                        Social, 2),

                    new TravellerEventChoice("During the term, a particularly annoying student continuously bugs you.",
                        yesText: "You give them some time.",
                        yesEvent: new TravellerEventRewardContact(
                            "You make friends with the student, eventually realizing that they were actually rather clever.",
                            new TravellerRewardContact("Student", TravellerNPCRelationship.Ally)),
                        noText: "Forget about the ignorant spoiled child, I have work to do!",
                        noEvent: new TravellerEventRewardContact(
                            "Turns out that student was rather clever and has now become one of your fellow peers teaching at this academy, and now works to undermine you.",
                            new TravellerRewardContact("Rival-Professor", TravellerNPCRelationship.Rival))),

                    new TravellerEventReward("You spend the term in your lab conducting research.",
                        new TravellerRewardSkillAny()),

                    new TravellerEventLife("You have a life event!"),

                    new TravellerEventSkillChoiceReward("You spend the term lecturing your students.",
                        new List<TravellerSkills>
                        {
                            Science,
                            Language,
                            Science,
                            Electronics,
                            Science,
                            Diplomat
                        }),

                    new TravellerEventReward(
                        "Your latest idea is a massive success on the market, and as a result you are rewarded handsomely",
                        new TravellerRewardBenefitIncrease(1)),

                    new TravellerEventSkillCheck(
                        " You give some of your best lectures, your students are engaged and attentive. They even ask you some rather inspring questions",
                        new TravellerEventRewardAttribute(
                            "During the course of your lecturing you stumble across a great discovery in the back and forth of discussion",
                            Intelligence),
                        new TravellerEventRewardContact(
                            "While you don't make any great breakthroughs, its clear you have an impact on some students, and they come to see you as a trusted contact.",
                            new List<TravellerRewardContact>
                            {
                                new("Student 1", TravellerNPCRelationship.Contact),
                                new("Student 2", TravellerNPCRelationship.Contact),
                                new("Student 3", TravellerNPCRelationship.Contact)
                            }),
                        (Science, 8)),

                    new TravellerEventAttributeCheck(
                        "Your rival in the court makes a foolish and obvious mistake in their research. You decided to try and point it out",
                        new TravellerEventRewardAttribute("You embarrass your rival, and show off your brilliance.",
                            Intelligence),
                        new TravellerEventReward(
                            "You fail to showcase your intellect, instead being made the fool yourself. Your lord decides not to pay you for this term",
                            new TravellerRewardBonusBenefit(-1)),
                        (Intelligence, 6)),

                    new TravellerEventChoice(
                        "You catch one of your students cheating on an exam. Do you wish to punish them?",
                        yesText: "Sure I'll give them a lecture and punishment.",
                        yesEvent: new TravellerEventAttributeCheck(
                            "You give them a strong lecture, and through sheer force of will, or carefully placed words, you try to convince them of the error in their ways",
                            new TravellerEventRewardContact(
                                "You show the student the error of their ways, and they come to be one of your best pupils.",
                                "Cheating student", TravellerNPCRelationship.Ally),
                            new TravellerEventRewardContact(
                                "The student grows to hate you, blames you for their failing out of school. Pretty soon you begin to receive strange letters in the mail, and hear odd shouts of your name on campus",
                                "Cheating student", TravellerNPCRelationship.Enemy),
                            (Social, 6)),
                        noText:
                        "Ehe, some kids just aren't up to the bar, I'll mark their exam extra hard for failing to even cheat well.",
                        noEvent: new TravellerEventText(
                            "The student is expelled for their actions, both because they cheated in other classes, and because your grade took them below the required average."))
                }
            );
        }
    }
}