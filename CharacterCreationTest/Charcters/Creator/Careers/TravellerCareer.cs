﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.CreationEvents;
using TravellerWiki.Data.Services.CareerService;

namespace TravellerWiki.Data
{
    public class TravellerCareer
    {
        #region Public Variables
        public string CareerName { get; set; }
        public string CareerDescription { get; set; }
        public TravellerNationalities Nationality { get; set; }
        public List<TravellerAttributeCheck> Qualifications { get; set; }

        public List<TravellerAssignment> Assignments { get; set; }

        public List<(int Cash, TravellerCharacterCreationReward Benefit)> MusteringOutBenefits { get; set; }

        public List<TravellerSkillTableEntry> PersonalDevelopmentSkillList { get; set; }
        public List<TravellerSkillTableEntry> ServiceSkillsList { get; set; }

        public List<TravellerEventCharacterCreation> Events { get; set; }
        public List<TravellerEventCharacterCreation> Mishaps { get; set; }

        #endregion
        #region Private variables
        private static TravellerNationsCharacterInfoService travellerNationsCharacterInfoService = new TravellerNationsCharacterInfoService();

        private Random random = new Random();
        #endregion
        #region Constructors
        //Everything but comission and advanced education

        public TravellerCareer(string careerName, string description, TravellerNationalities nationality, List<TravellerAttributeCheck> qualifications, List<TravellerAssignment> assignments,
            List<(int Cash, TravellerCharacterCreationReward Benefit)> musteringOutBenefits, List<TravellerSkillTableEntry> personalDevelopmentSkillList,
            List<TravellerSkillTableEntry> serviceSkillsList, List<TravellerEventCharacterCreation> events, List<TravellerEventCharacterCreation> mishaps)
        {
            CareerName = careerName;
            CareerDescription = description;
            Qualifications = qualifications;
            Assignments = assignments;
            MusteringOutBenefits = musteringOutBenefits;
            PersonalDevelopmentSkillList = personalDevelopmentSkillList;
            ServiceSkillsList = serviceSkillsList;
            Events = events;
            Mishaps = mishaps;
            Nationality = nationality;
        }

        #endregion
        #region Life Events

        public TravellerEventCharacterCreation GetLifeEvent(int roll)
            => roll switch
            {
                2 => new TravellerEventInjury("Sickness or Injury:"),
                3 => new TravellerEventText("Birth or Death: Someone close to you is born or dies, like a friend or family member and you are involved in some way."),
                4 => new TravellerEventReward("A relationship ends badly, resulting in a new enemy.", new List<TravellerCharacterCreationReward>
                {
                    new TravellerRewardContact("Ex-Significant Other",TravellerNPCRelationship.Enemy)
                }),
                5 => new TravellerEventReward("Improve a relationship, possibly leading to marriage or some other emotional commitment.", new List<TravellerCharacterCreationReward>
                {
                    new TravellerRewardContact("Significant Person",TravellerNPCRelationship.Ally)
                }),
                6=> new TravellerEventReward("New relationship, you become involved in a new romantic relationship.", new List<TravellerCharacterCreationReward>
                {
                    new TravellerRewardContact("Romantic Partner",TravellerNPCRelationship.Ally)
                }),
                7 => new TravellerEventReward("New Contact.", new List<TravellerCharacterCreationReward>
                {
                    new TravellerRewardContact("Contact",TravellerNPCRelationship.Contact)
                }),
                8 => new TravellerEventReward("You are betrayed in some fashion by a friend.", new List<TravellerCharacterCreationReward>
                {
                    new TravellerRewardContact("Traior",TravellerNPCRelationship.Rival)
                }),
                9 => new TravellerEventReward("You move to a new world, gaining +2 to your next qualification roll.", new List<TravellerCharacterCreationReward>
                {
                    new TravellerRewardQualification(2)
                }),
                10 => new TravellerEventReward("You stumble into good fortunes, finding money or having a lifelong dream come true.", new List<TravellerCharacterCreationReward>
                {
                    new TravellerRewardBenefitIncrease(2)
                }),
                11 => new TravellerEventChoice("You commit or are the victim (or accused) of a crime.",
                    yesText:"Lose one Benefit roll",
                    yesEvent: new TravellerEventReward("You lose one benefit roll",
                        new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardBonusBenefit(-1)
                        }),
                    noText: "Go To Jail or nations equivalent.",
                    noEvent: new TravellerEventReward("You go to jail or nations drifter.",
                        new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardJobChange(new TravellerNationsCharacterInfoService().GetNationsList.First(x => x.Nationality == Nationality).DrifterCareer.CareerName)
                        })),
                12 => new TravellerEventMultiChoice("An unusual event occurs",
                    new List<TravellerEventCharacterCreation>
                    {
                        new TravellerEventReward("You discover you have Psionic powers", new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardAttribute(new TravellerAttribute(TravellerAttributes.Psionics,random.Next(2,13)))
                        }),

                        new TravellerEventReward("You come into contact with a previously unknown alien species.", new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardSkill(new List<TravellerSkill>{ new TravellerSkill(TravellerSkills.Science,1)}),
                            new TravellerRewardContact("Alien",TravellerNPCRelationship.Contact)
                        }),

                        new TravellerEventText("You stumble across an alien artifact not otherwise known to your nation."),

                        new TravellerEventText("You have amnesia, something happened to you, but you can't recall what."),
                        new TravellerEventReward("You come into contact with someone in the upper echelons of your nations government, perhaps even its leader.",
                            new List<TravellerCharacterCreationReward>{new TravellerRewardContact("High ranking Government Worker",TravellerNPCRelationship.Contact)}),
                        new TravellerEventText("You come across some technology older than your nation, possible older than humanity.")
                    }),
                _ => (TravellerEventCharacterCreation) new TravellerEventText("Error")
            };

        public TravellerEventCharacterCreation GenerateLifeEvent()
        {
            var numb = random.Next(2, 13);
            return GetLifeEvent(numb);
        }
#endregion

    }
}
