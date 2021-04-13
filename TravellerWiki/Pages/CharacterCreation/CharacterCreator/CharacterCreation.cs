using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerWiki.Data;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.CreationEvents;
using TravellerWiki.Data.Services.CareerService;

namespace TravellerWiki.Pages.CharacterCreation.CharacterCreator
{
    public partial class CharacterCreation
    {

        private string TravellerName = "";
        int roll = -1;
        #region Events
        public bool DoneGettingEvent = false;
        public TravellerEventCharacterCreation ThisTermsEvent = null;

        public int attributeToCheckNumber = -1;
        public void EventAttributeCheck()
        {
            var evnt = (TravellerEventAttributeCheck)ThisTermsEvent;

            if (attributeToCheckNumber == -1) attributeToCheckNumber = 0;
            roll = CharacterCreationService.RollDice();
            var passedCheck = evnt.AttributeChecks[attributeToCheckNumber].PassedCheck(roll);
            if (passedCheck && evnt.HasYesEvent)
            {
                ThisTermsEvent = evnt.YesEvent;
            }
            else if (!passedCheck && evnt.HasNoEvent)
            {
                ThisTermsEvent = evnt.NoEvent;
            }

            attributeToCheckNumber = -1;
        }

        public void GetEvent()
        {
            if (PassedSurvival)
            {
                var roll = CharacterCreationService.RollDice();
                ThisTermsEvent = CharacterCreationService.GetEvent(roll);
            }
            else
            {
                var roll = CharacterCreationService.RollDice(1);
                ThisTermsEvent = CharacterCreationService.GetMishap(roll);
            }

            if (ThisTermsEvent is TravellerEventLife)
            {
                ThisTermsEvent = CharacterCreationService.GetLifeEvent(CharacterCreationService.RollDice());
            }
        }

        public void DoneEvent()
        {
            DoneGettingEvent = true;
            ThisTermsEvent = null;
            roll = -1;
            CharacterCreationService.GainBenefitForTerm();
        }

        #endregion
        #region Survival

        public bool RolledSurvival = false;
        public bool HasRolled = false;
        public bool PassedSurvival = false;

        public void InitSurvival()
        {
            RolledSurvival = false;
            PassedSurvival = false;
        }

        public void RollSurvival()
        {
            roll = CharacterCreationService.RollDice();
            PassedSurvival = CharacterCreationService.CheckSurvival(roll);
            HasRolled = true;
        }
        #endregion  
        #region PickingSkill
        public bool isSuperSkill = false;
        public bool HasChosenSkillTable = false;
        public int chosenSkillTable = -1;
        public string ChosenSkillTableName = "";

        public void initSkillTable()
        {
            isSuperSkill = false;
            HasChosenSkillTable = false;
            chosenSkillTable = -1;
            roll = -1;
            ChosenSkillTableName = "";
        }

        public void ApplySkill(TravellerSkillTableEntry skill)
        {

            CharacterCreationService.ApplySkillTableResult(skill);
            HasChosenSkillTable = true;
            isSuperSkill = false;
            chosenSkillTable = -1;
            ChosenSkillTableName = "";
        }

        public TravellerSkills ChosenSubSkill;
        public TravellerSkills SuperSkill;
        public void SelectSubSkill()
        {
            ApplySkill(new TravellerSkillTableEntrySkill(ChosenSubSkill));
        }

        public void RollSkill()
        {
            var skillTable = GetChosenSkillTable();

            roll = CharacterCreationService.RollOnSkillTable();
            var skill = skillTable[roll];
            if (CharacterCreationService.IsSkill(skill) && CharacterCreationService.IsSuperSkill(skill))
            {
                isSuperSkill = true;
                SuperSkill = ((TravellerSkillTableEntrySkill)skill).Skill;
            }
            else
            {
                ApplySkill(skill);
            }
        }

        private List<TravellerSkillTableEntry> GetChosenSkillTable()
        {
            return chosenSkillTable switch
            {
                0 => chosenCareer.PersonalDevelopmentSkillList,
                1 => chosenCareer.ServiceSkillsList,
                2 => chosenAssignment.SkillList,
                _ => chosenCareer.PersonalDevelopmentSkillList
            };
        }

        #endregion
        #region Getting a Career

        TravellerCareer chosenCareer = null;
        TravellerAssignment chosenAssignment = null;
        string careerName = "";
        string assignmentName = "";
        int qualificationChoice = -1;
        bool hasAssignment = false;
        bool passedQualification = false;
        bool rolledQualification = false;
        bool hasJob = false;
        public bool HasBasicTrainingSkill = false;
        public string ChosenBasicTrainingSkillName = "";

        public void initCareer()
        {
            chosenCareer = null;
            chosenAssignment = null;
            careerName = "";
            assignmentName = "";
            qualificationChoice = -1;
            hasAssignment = false;
            passedQualification = false;
            rolledQualification = false;
            HasBasicTrainingSkill = false;
            hasJob = false;
            string ChosenBasicTrainingSkillName = "";
        }

        public void ChooseBasicTrainingSkill()
        {
            var skill = chosenCareer.ServiceSkillsList.First(x => x.Name == ChosenBasicTrainingSkillName);
            CharacterCreationService.ApplyRegularBasicTraining(skill);
            HasBasicTrainingSkill = true;
        }

        public void selectCareer()
        {
            var careers = CharacterCreationService.Nationality.NationsCareers;
            if (careerName == "")
            {
                chosenCareer = careers.First();
            }
            else
            {
                chosenCareer = careers.First(x => x.CareerName == careerName);
            }
        }

        public void selectAssignment()
        {
            var assignments = chosenCareer.Assignments;
            if (assignmentName == "")
            {
                chosenAssignment = assignments.First();
            }
            else
            {
                chosenAssignment = assignments.First(x => x.Name == assignmentName);
            }

            hasAssignment = true;
            CharacterCreationService.JoinCareer(chosenCareer, chosenAssignment);
        }

        public void selectQualification()
        {
            if (qualificationChoice == -1) qualificationChoice = 0;
            if (qualificationChoice > chosenCareer.Qualifications.Count) qualificationChoice = 0;
            var qualification = chosenCareer.Qualifications[qualificationChoice];
            roll = CharacterCreationService.RollDice();
            passedQualification = CharacterCreationService.CanEnterCareer(qualification, roll);
            rolledQualification = true;

            if (passedQualification)
            {
                hasJob = true;
            }

        }

        public void takeDrifter()
        {
            var drifter = CharacterCreationService.Nationality.DrifterCareer;
            chosenCareer = drifter;
            hasJob = true;
        }

        public void takeDraft()
        {
            var r = new Random();
            var draftTable = CharacterCreationService.Nationality.DraftTable;
            chosenCareer = draftTable[r.Next(0, draftTable.Length)];
            hasJob = true;
        }

        #endregion
        #region basicFlags

        public void initBasicFlags()
        {
            DoneStats = false;
            FailedNationEntry = false;
            DoneFailedNationEntry = false;
            DonePickingCareer = false;
            DoneLivingLife = false;
            HasBeenDraftedOnce = false;
            DoneBasicTraining = false;
            DonePickingSkills = false;
        }

        bool DoneStats = false;
        public void ChangeDoneStats() => DoneStats = true;

        bool FailedNationEntry = false;

        bool DoneFailedNationEntry = false;
        public void ChangeDoneFailedNationEntry() => DoneFailedNationEntry = true;

        bool DonePickingCareer = false;
        public void ChangeDonePickingCareer() => DonePickingCareer = !DonePickingCareer;

        bool DoneLivingLife = false;
        public void ChangeDoneLivingLife() => DoneLivingLife = true;

        bool HasBeenDraftedOnce = false;
        public void ChangeHasBeenDraftedOnce() => HasBeenDraftedOnce = true;

        bool DoneBasicTraining = false;
        public void ChangeDoneBasicTraining() => DoneBasicTraining = !DoneBasicTraining;

        bool DonePickingSkills = false;
        public void ChangeDonePickingSkills() => DonePickingSkills = !DonePickingSkills;

        #endregion
        #region Stats

        public void InitStats()
        {
            IncludePsi = false;
            StrKey = -1;
            setStr = false;
            setDex = false;
            DexKey = -1;
            setEnd = false;
            EndKey = -1;
            setInt = false;
            IntKey = -1;
            setEdu = false;
            EduKey = -1;
            setSoc = false;
            SocKey = -1;
            setPsi = false;
            PsiKey = -1;
            GeneratedStats = null;
        }

        public Dictionary<int, int> GeneratedStats;
        private bool IncludePsi { get; set; }

        int StrKey = -1;
        bool setStr = false;

        bool setDex = false;
        int DexKey = -1;

        bool setEnd = false;
        int EndKey = -1;

        bool setInt = false;
        int IntKey = -1;

        bool setEdu = false;
        int EduKey = -1;

        bool setSoc = false;
        int SocKey = -1;

        bool setPsi = false;
        int PsiKey = -1;

        #endregion
        #region Setup
        public void ResetCareer()
        {

            initCareer();
            initSkillTable();
            InitSurvival();
        }

        public void Init()
        {
            TravellerName = "";
            CharacterCreationService.ResetChecks();
            InitStats();
            initNationality();
            initBasicFlags();
            ResetCareer();
        }

        public void SetName()
        {
            CharacterCreationService.NewCharacter();
            CharacterCreationService.SetName(TravellerName);
        }

        #endregion
        #region Stats Code

        public bool HasNumberBeenUsed(int number)
        {
            return (setStr && number == StrKey) || (setDex && number == DexKey) || (setEnd && number == EndKey) ||
                   (setInt && number == IntKey) || (setEdu && number == EduKey) || (setSoc && number == SocKey) ||
                   (setPsi && number == PsiKey);
        }

        public bool SkillsSet() => !(setStr & setDex & setEnd & setInt & setEdu & setSoc & IncludePsi) || setPsi;


        public int GetFirstUnusedKey()
        {
            foreach (var key in GeneratedStats)
            {
                if (!HasNumberBeenUsed(key.Key))
                {
                    return key.Key;
                }
            }

            return -1;
        }

        public void GenerateStats()
        {
            GeneratedStats = CharacterCreationService.GenerateStats(IncludePsi);

        }

        public void SetStat(TravellerAttributes attribute)
        {
            int StatValue = -1;
            switch (attribute)
            {
                case TravellerAttributes.Strength:
                    if (StrKey == -1)
                    {
                        StrKey = GetFirstUnusedKey();
                    }
                    StatValue = GeneratedStats[StrKey];
                    setStr = true;


                    break;
                case TravellerAttributes.Dexterity:
                    if (DexKey == -1)
                    {
                        DexKey = GetFirstUnusedKey();
                    }

                    StatValue = GeneratedStats[DexKey];
                    setDex = true;

                    break;
                case TravellerAttributes.Endurance:
                    if (EndKey == -1)
                    {
                        EndKey = GetFirstUnusedKey();
                    }
                    StatValue = GeneratedStats[EndKey];
                    setEnd = true;

                    break;
                case TravellerAttributes.Intelligence:
                    if (IntKey == -1)
                    {
                        IntKey = GetFirstUnusedKey();
                    }
                    StatValue = GeneratedStats[IntKey];
                    setInt = true;

                    break;
                case TravellerAttributes.Education:
                    if (EduKey == -1)
                    {
                        EduKey = GetFirstUnusedKey();
                    }
                    StatValue = GeneratedStats[EduKey];
                    setEdu = true;

                    break;
                case TravellerAttributes.Social:
                    if (SocKey == -1)
                    {
                        SocKey = GetFirstUnusedKey();
                    }
                    StatValue = GeneratedStats[SocKey];
                    setSoc = true;

                    break;
                case TravellerAttributes.Psionics:
                    if (PsiKey == -1)
                    {
                        PsiKey = GetFirstUnusedKey();
                    }
                    StatValue = GeneratedStats[PsiKey];
                    setPsi = true;

                    break;
                default:
                    break;
            }

            CharacterCreationService.AssignStat(new TravellerAttribute(attribute, StatValue));

        }

        #endregion
        #region nationality

        private TravellerNationalities ChosenNationality;
        private int EntryRequirementChoice = 0;
        List<TravellerSkill> backgroundSkills = new List<TravellerSkill>();
        int chosenBackgroundSkill = -1;

        public void initNationality()
        {
            EntryRequirementChoice = 0;
            backgroundSkills = new List<TravellerSkill>();
            chosenBackgroundSkill = -1;
        }

        public void ApplyNationality()
        {
            var nationality = nationsService.GetNationsList.First(x => x.Nationality == ChosenNationality);
            ApplyNationality(nationality);
        }

        public void ApplyNationality(TravellerNationsCharacterInfo nationality)
        {
            CharacterCreationService.ApplyNationality(nationality);
        }

        public void TryEnterNationality()
        {
            var nationality = nationsService.GetNationsList.First(x => x.Nationality == ChosenNationality);
            var entryRequirement = nationality.EntryRequirements[EntryRequirementChoice];
            var roll = CharacterCreationService.RollDice();

            bool canEnter = !CharacterCreationService.CanEnterNationality(nationality, entryRequirement, roll);

            if (!canEnter)
            {
                nationality = nationsService.GetTravellerNationsCharacterInfos().First(x => x.Nationality == nationality.ParentNation);
                FailedNationEntry = true;
            }

            ApplyNationality(nationality);
        }

        private int GetFirstUnusedBackgroundSkill()
        {
            var skillList = CharacterCreationService.GetBackgoundSkills(CharacterCreationService.Nationality);
            foreach (var skill in skillList)
            {
                if (!backgroundSkills.Any(x => x.SkillName == skill.Value.SkillName))
                {
                    return skill.Key;
                }
            }

            return -1;
        }

        public void AddBackgroundSkill()
        {
            var skillList = CharacterCreationService.GetBackgoundSkills(CharacterCreationService.Nationality);
            if (chosenBackgroundSkill == -1 || backgroundSkills.Any(x => x.SkillName == skillList[chosenBackgroundSkill].SkillName))
            {
                chosenBackgroundSkill = GetFirstUnusedBackgroundSkill();
            }


            backgroundSkills.Add(new TravellerSkill(skillList[chosenBackgroundSkill].SkillName, 0));
        }

        public void SaveSkills()
        {
            CharacterCreationService.ApplyBackgroundSkills(backgroundSkills);
        }

        public void ClearSkills()
        {
            backgroundSkills = new List<TravellerSkill>();
        }
        #endregion
    }
}
