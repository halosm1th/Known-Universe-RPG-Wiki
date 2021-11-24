using System;
using TravellerCharacter.CharacterCreator.Careers;
using TravellerWiki.Data.Services.CareerService.NationsCareeres;

namespace TravellerCharacter.Character_Services.Career_Service.Basic_Careers
{
    class TravellerMationCareer : TravellerBasicCareers
    {
        public static TravellerCareer NationCareer()
        {
            var career = new TravellerMationCareer();

            return career.GetNationCareer();
        }
        Random random = new Random();

        public TravellerCareer GetNationCareer()
        {
            return null;
            /*
            return new TravellerCareer(
       careerName: "",
       description: "",
       nationality: TravellerNationalities.,
       qualifications: new List<TravellerAttributeCheck>
       {
                    new TravellerAttributeCheck(),
       },
       assignments: new List<TravellerAssignment>
       {
                    new TravellerAssignment(
                        name: "",
                        description: "",
                        survival: new TravellerAttributeCheck(),
                        advancement: new TravellerAttributeCheck(),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("", new TravellerRewardCharacterCreationSkill()),
                            ("", new TravellerRewardCharacterCreationSkill()),
                            ("", new TravellerRewardCharacterCreationSkill()),
                            ("", new TravellerRewardCharacterCreationSkill()),
                            ("", new TravellerRewardCharacterCreationSkill()),
                            ("", new TravellerRewardCharacterCreationSkill()),
                        }),

                    new TravellerAssignment(
                        name: "",
                        description: "",
                        survival: new TravellerAttributeCheck(),
                        advancement: new TravellerAttributeCheck(),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("", new TravellerRewardCharacterCreationSkill()),
                            ("", new TravellerRewardCharacterCreationSkill()),
                            ("", new TravellerRewardCharacterCreationSkill()),
                            ("", new TravellerRewardCharacterCreationSkill()),
                            ("", new TravellerRewardCharacterCreationSkill()),
                            ("", new TravellerRewardCharacterCreationSkill()),
                        }),

                    new TravellerAssignment(
                        name: "",
                        description: "",
                        survival: new TravellerAttributeCheck(),
                        advancement: new TravellerAttributeCheck(),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("", new TravellerRewardCharacterCreationSkill()),
                            ("", new TravellerRewardCharacterCreationSkill()),
                            ("", new TravellerRewardCharacterCreationSkill()),
                            ("", new TravellerRewardCharacterCreationSkill()),
                            ("", new TravellerRewardCharacterCreationSkill()),
                            ("", new TravellerRewardCharacterCreationSkill()),
                        }),

       },
       personalDevelopmentSkillList: new List<TravellerSkillTableEntry>
       {
                    GetSkillTableEntry(),
                    GetSkillTableEntry(),
                    GetSkillTableEntry(),
                    GetSkillTableEntry(),
                    GetSkillTableEntry(),
                    GetSkillTableEntry(),
       },
       serviceSkillsList: new List<TravellerSkillTableEntry>
       {
                    GetSkillTableEntry(),
                    GetSkillTableEntry(),
                    GetSkillTableEntry(),
                    GetSkillTableEntry(),
                    GetSkillTableEntry(),
                    GetSkillTableEntry(),
       }, musteringOutBenefits: new List<(int Cash, TravellerCharacterCreationReward Benefit)>
       {
                    (, new TravellerCharacterCreationReward()),
                    (, new TravellerCharacterCreationReward()),
                    (, new TravellerCharacterCreationReward()),
                    (, new TravellerCharacterCreationReward()),
                    (, new TravellerCharacterCreationReward()),
                    (, new TravellerCharacterCreationReward()),
                    (, new TravellerCharacterCreationReward()),
       },
       events: new List<TravellerEventCharacterCreation>
       {
                    new TravellerEventMishap("Disaster! Roll on the mishap table, but you are not ejected from the career"),
                    new TravellerEventCharacterCreation(),

                    new TravellerEventCharacterCreation(),

                    new TravellerEventCharacterCreation(),

                    new TravellerEventCharacterCreation(),

                    new TravellerEventLife("You have a life event!"),

                    new TravellerEventCharacterCreation(),

                    new TravellerEventCharacterCreation(),

                    new TravellerEventCharacterCreation(),

                    new TravellerEventCharacterCreation(),

                    new TravellerEventCharacterCreation(),
       },
       mishaps: new List<TravellerEventCharacterCreation>
       {
                    new TravellerEventSeverelyInjured("You are severely injured!"),
                    new TravellerEventCharacterCreation(),
                    new TravellerEventCharacterCreation(),
                    new TravellerEventCharacterCreation(),
                    new TravellerEventCharacterCreation(),
                    new TravellerEventInjury("You are injured!"),
       }
   );*/
        }
    }
}