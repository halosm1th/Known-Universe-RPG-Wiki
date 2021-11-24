using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TravellerWiki.Data.Services.CareerService.VersianCareeres;

namespace TravellerWiki.Data.Services.CareerService
{
    class TravellerMajorPowerCareers : TravellerCareerServiceCareer
    {
        public void AddMajorPowerCareers(List<TravellerCareer> careers)
        {
            //TODO uncomment these as they are added and won't crash shit!
            TravellerVersianCareers.AddVersianCareers(careers);
            //AddFederationCareers(careers);
            //AddDeutschlandCareers(careers);
            //AddTransGalaticEmpireCareers(careers);
            //AddXiaoMingCareers(careers);
        }

        /*
              *The reference career!
      public static TravellerCareer Career()
             {
                 return new TravellerCareer(
                     careerName: "",
                     description: "",
                     nationality: "",
                     qualifications: new List<TravellerAttributeCheck>
                     {
                         new TravellerAttributeCheck()
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
                                 ("", new TravellerCharacterCreationReward()),
                                 ("", new TravellerCharacterCreationReward()),
                                 ("", new TravellerCharacterCreationReward()),
                                 ("", new TravellerCharacterCreationReward()),
                                 ("", new TravellerCharacterCreationReward()),
                                 ("", new TravellerCharacterCreationReward()),
                             }),new TravellerAssignment(
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
                                 ("", new TravellerCharacterCreationReward()),
                                 ("", new TravellerCharacterCreationReward()),
                                 ("", new TravellerCharacterCreationReward()),
                                 ("", new TravellerCharacterCreationReward()),
                                 ("", new TravellerCharacterCreationReward()),
                                 ("", new TravellerCharacterCreationReward()),
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
                                 ("", new TravellerCharacterCreationReward()),
                                 ("", new TravellerCharacterCreationReward()),
                                 ("", new TravellerCharacterCreationReward()),
                                 ("", new TravellerCharacterCreationReward()),
                                 ("", new TravellerCharacterCreationReward()),
                                 ("", new TravellerCharacterCreationReward()),
                             }),

                     },
                     musteringOutBenefits: new List<(int Cash, TravellerCharacterCreationReward Benefit)>
                     {
                         (, new TravellerCharacterCreationReward()),
                         (, new TravellerCharacterCreationReward()),
                         (, new TravellerCharacterCreationReward()),
                         (, new TravellerCharacterCreationReward()),
                         (, new TravellerCharacterCreationReward()),
                         (, new TravellerCharacterCreationReward()),
                         (, new TravellerCharacterCreationReward()),
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
                 );
             }
              *
              */

        private static void AddFederationCareers(List<TravellerCareer> careers)
        {
        }

        private static void AddDeutschlandCareers(List<TravellerCareer> careers)
        {
        }

        private static void AddTransGalaticEmpireCareers(List<TravellerCareer> careers)
        {
        }

        private static void AddXiaoMingCareers(List<TravellerCareer> careers)
        {
        }

    }
}