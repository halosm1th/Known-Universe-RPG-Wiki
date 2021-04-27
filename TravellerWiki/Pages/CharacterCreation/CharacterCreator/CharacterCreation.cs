using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TravellerWiki.Data;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.CreationEvents;
using TravellerWiki.Data.Services.CareerService;
using TravellerWiki.Data.TravellerInjuries;

namespace TravellerWiki.Pages.CharacterCreation.CharacterCreator
{
    public partial class CharacterCreation
    {
        /*

        int roll = -1;
        #region Reward
        public bool RewardRequiresUserInput = false;
        private bool hasRunRewardInit = false;

        public void InitReward()
        {
            RewardRequiresUserInput = false;
            InitRewardSkill();
            hasRunRewardInit = true;
        }

        public void MishapEventReward()
        {
            roll = CharacterCreationService.RollDice();
            SpecialTermsEvent = CharacterCreationService.GetMishap(roll);
            InitEvent();
        }

        #endregion
        #region Injury
        public bool IsChoiceInjury = false;


        public void InitInjury()
        {
            IsChoiceInjury = false;
            NeedsMedicalAid = false;
            ActualInjury = null;
            InjuryChoice = -1;
            effectedStat = -1;
        }
        
        #endregion

        #region Events

        public bool DoneGettingEvent = false;
        public TravellerInjury Injury = null;
        public TravellerEventCharacterCreation SpecialTermsEvent = null;
        public TravellerEventCharacterCreation ThisTermsEvent = null;

        public void InitEvent()
        {
            DoneGettingEvent = false;
            Injury = null;
            ThisTermsEvent = null;
        }


        #endregion
        #region Survival

        #endregion  
        #region Getting a Career

        TravellerCareer chosenCareer = null;
        bool hasAssignment = false;
        TravellerAssignment chosenAssignment = null;




        #endregion
        #region basicFlags

        public void initBasicFlags()
        {
            DonePickingCareer = false;
            DoneLivingLife = false;
            HasBeenDraftedOnce = false;
            PickingSkills = false;
        }


        bool DonePickingCareer = false;
        public void ChangeDonePickingCareer() => DonePickingCareer = !DonePickingCareer;

        bool DoneLivingLife = false;
        public void ChangeDoneLivingLife() => DoneLivingLife = true;

        bool HasBeenDraftedOnce = false;
        public void ChangeHasBeenDraftedOnce() => HasBeenDraftedOnce = true;

        bool PickingSkills= false;
        public void ChangeDonePickingSkills() => PickingSkills = !PickingSkills;


        #endregion
        #region Setup
        public void ResetCareer()
        {
            InitEvent();
        }

        public void Init()
        {
            CharacterCreationService.ResetChecks();
            initBasicFlags();
            ResetCareer();
        }


        #endregion
        */
    }
}
