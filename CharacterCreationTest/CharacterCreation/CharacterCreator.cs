using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using TravellerWiki.Data;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.CreationEvents;
using TravellerWiki.Data.TravellerInjuries;

namespace CharacterCreationTest.CharacterCreation
{
    class CharacterCreator
    {
        #region Public Variables
        public PlayerTravellerCharacter _character; 
        public int NumberOfTravellerBackgroundSKills =>
            3 + _character.AttributeList.First(x => x.AttributeName == TravellerAttributes.Education).AttributeModifier;

        public int TravellersAge => _character.Age;

        #endregion
        #region Checks
        //Checks
        public bool HasCharacter { get; protected set; }

        public bool Advanced { get; protected set; }
        public bool HardAdvanced { get; protected set;  }
        public bool Mishapped { get; protected set; }

        public bool HasBeenDrafted { get; protected set; }
        public bool HasName { get; protected set; }
        public bool HasNationality { get; protected set; }
        public bool HasBackgroundSkills { get; protected set; }
        public bool HasHadJob { get; protected set; }
        public bool HasJob { get; protected set; }
        public bool FirstTermOfJob { get; protected set; }
        public bool FinishedCharacterCreation { get; protected set; }
        public bool BuyEquipment { get; protected set; }
        //34 = 4 terms before aging begins to take effect.
        public bool HasAging => _character.Age > 34;
        
        #endregion
        #region private variables
        private Random dice = new Random();
        private TravellerCareerService careerService = new TravellerCareerService();
        #endregion
        #region Constructor
        public CharacterCreator()
        {
            HasCharacter = false;
            HasName = false;
            HasNationality = false;
            HasBackgroundSkills = false;
            HasHadJob = false;
            FirstTermOfJob = true;
            FinishedCharacterCreation = true;
            BuyEquipment = false;

        }
#endregion
        #region Basic Character Stuff
        /// <summary>
        /// Create a new empty Traveller Character
        /// </summary>
        public void NewCharacter()
        {
            if (!HasCharacter)
            {
                _character = new PlayerTravellerCharacter();
                _character.Age = 18;
                HasCharacter = true;
                
            }
        }

        /// <summary>
        /// Assign the name of the Character
        /// </summary>
        /// <param name="name">The name to give to the character</param>
        public void SetName(string name)
        {
            if (!HasName)
            {
                _character.Name = name;
                HasName = true;
            }
        }
        #endregion
        #region Stats
        /// <summary>
        /// Generate the stats for the traveller character for the decided to allocate as they want
        /// </summary>
        /// <param name="includePsi"> whether to include the psi stat in generation</param>
        /// <returns></returns>
        public Dictionary<int, int> GenerateStats(bool includePsi = false)
        {
            int numberOfStats = 6 + (includePsi ? 1 : 0);
            var result = new Dictionary<int,int>();
            for (int i = 0; i < numberOfStats; i++)
            {
                result[i] = RollDice();
            }

            return result;
        }

        /// <summary>
        /// Assign an attribute its value on the character
        /// </summary>
        /// <param name="attribute">The attribute to assign to the character sheet</param>
        public void AssignStat(TravellerAttribute attribute)
        {
            _character.AttributeList.Add(attribute);
        }
        #endregion
        #region Nationality
        /// <summary>
        /// Check if the nation has entry requirements. Should be called before Can Enter nation and apply nation.
        /// </summary>
        /// <param name="nationality">The nationality to check</param>
        /// <returns></returns>
        public bool NationHasEntryRequirements(TravellerNationsCharacterInfo nationality) =>  nationality.EntryRequirements.Count > 0;

        /// <summary>
        /// Check if a traveller can enter the particular nationality
        /// </summary>
        /// <param name="nationality">The Nationality the traveller wishes to enter</param>
        /// <param name="attribute"></param>
        /// <param name="diceResult"></param>
        /// <returns></returns>
        public bool CanEnterNationality(TravellerNationsCharacterInfo nationality, TravellerAttributeCheck attributeCheck,
            int diceResult)
        {
            return !HasNationality && 
                   attributeCheck.PassedCheck(diceResult + _character.GetRelevantAttributeModifier(attributeCheck.UnderlingAttribute));

        }

        /// <summary>
        /// Apply the nationalities stat changes and perks to the character
        /// </summary>
        /// <param name="nationality">The Chosen nationality</param>
        public void ApplyNationality(TravellerNationsCharacterInfo nationality)
        {
            if (HasNationality) return;

            _character.Nationality = nationality;
            ApplyNationalityStatChange(nationality.StatChanges);
            ApplyNationsPerks(nationality.Perks);
            HasNationality = true;
        }

        /// <summary>
        /// Apply the perks from the nation to the character
        /// </summary>
        /// <param name="nationality">The chosen nationality</param>
        private void ApplyNationsPerks(List<TravellerCharacterCreationReward> perks)
        {
            foreach (var perk in perks)
            {
                if (perk is TravellerRewardCharacterCreationItem itemReward)
                {
                    foreach (var item in itemReward.Items)
                    {
                        _character.AddItem(item);
                    }
                }
                else if (perk is TravellerRewardCharacterCreationSkill skillReward)
                {
                    foreach (var skill in skillReward.Skilllist)
                    {
                        _character.AddSkill(skill);
                    }
                }
            }
        }

        /// <summary>
        /// Apply the nations stat changes to the character
        /// </summary>
        /// <param name="nationality">The chosen nationality to apply the changes from.</param>
        private void ApplyNationalityStatChange(List<(TravellerAttributes Stat, int ChangeBy)> statChanges)
        {
            foreach (var nationalityStatChange in statChanges)
            {
                _character.ChangeAttribute(nationalityStatChange.Stat, nationalityStatChange.ChangeBy);
            }
        }
        #endregion
        #region BackgroundSkills
        public Dictionary<int, TravellerSkill> GetBackgoundSkills(TravellerNationsCharacterInfo nationality)
        {
            return nationality.BackgroundSkills;
        }

        public void ApplyBackgroundSkills(List<TravellerSkill> skills)
        {
            if (HasBackgroundSkills) return;

            foreach (var skill in skills)
            {
                _character.AddSkill(skill);
            }
        }
        #endregion
        #region Enter Career

        public TravellerCareer GetCareer(string careerName) => careerService.GetCareer(careerName);
        public TravellerAssignment GetAssignment(string assignmentName) => GetAssignments(_character.LastCareer).First(x => x.Name==assignmentName);
        public List<TravellerCareer> GetTravellerCareers() => _character.Nationality.NationsCareers;
        public TravellerCareer GetDrifter() => _character.Nationality.DrifterCareer;

        public TravellerCareer GetDrafted(int roll)
        {
            if(roll > _character.Nationality.DraftTable.Length) throw new ArgumentOutOfRangeException("Error, draft roll outside expected range");

            return _character.Nationality.DraftTable[roll];
        }

        public bool CanEnterCareer(TravellerAttributeCheck careerCheck, int diceResult) 
            => 
                careerCheck.PassedCheck(diceResult 
                    + _character.GetRelevantAttributeModifier(careerCheck.UnderlingAttribute));

        public List<TravellerAssignment> GetAssignments(TravellerCareer career)
        {
            return career.Assignments;
        }

        public void JoinCareer(TravellerCareer career, TravellerAssignment assignment)
        {
            _character.PreviousCareers.Push((career,assignment,0));
            FirstTermOfJob = true;
            HasJob = true;
            Mishapped = false;
            Advanced = false;
            HardAdvanced = false;
        }

        public void LeaveCareer()
        {
            HasJob = false;
        }
        #endregion
        #region Career Basic Training
        public bool GetsBasicTraining() => FirstTermOfJob;

        public void ApplyRegularBasicTraining(TravellerSkillTableEntry basicTraining)
        {
            if(!FirstTermOfJob) throw new ArgumentException("Error, not first of career!");
            AddSkillTableEntryToCharacter(basicTraining);
            FirstTermOfJob = false;
        }
        public void ApplyFirstBasicTraining(TravellerCareer career)
        {
            if(!FirstTermOfJob && HasHadJob) throw new ArgumentException("Error, not first career");
            foreach (var skill in career.ServiceSkillsList)
            {
                AddSkillTableEntryToCharacter(skill);
            }

            HasHadJob = true;
            FirstTermOfJob = false;
        }
        #endregion
        #region Career Skills
        /// <summary>
        /// Returns a value in the range for the skill table, will be between 0-5
        /// </summary>
        /// <returns>Returns a value between 0-5</returns>
        public int RollOnSkillTable() => RollDice(1)-1;

        public List<(string,List<TravellerSkillTableEntry>)> GetSkillTables()
        {
            var tables = new List<(string, List<TravellerSkillTableEntry>)>();
            tables.Add(("Service Skills",_character.PreviousCareers.Peek().Item1.ServiceSkillsList));
            tables.Add(("Personal Development Skills",_character.PreviousCareers.Peek().Item1.PersonalDevelopmentSkillList));
            tables.Add(($"{_character.PreviousCareers.Peek().Item2.Name} Skills",_character.PreviousCareers.Peek().Item2.SkillList));

            return tables;
        }

        public bool IsSkill(TravellerSkillTableEntry skill) => skill is TravellerSkillTableEntrySkill;

        public bool IsSuperSkill(TravellerSkillTableEntry skill)
            => TravellerSkill.IsSuperSkill(((TravellerSkillTableEntrySkill)skill).Skill);

        public bool IsSuperSkill(TravellerSkills skill) => TravellerSkill.IsSuperSkill(skill);

        public bool ApplySkillTableResult(TravellerSkillTableEntry entry)
        {
            return AddSkillTableEntryToCharacter(entry);
        }

        #endregion
        #region Career Survival
        public bool CheckSurvival(int roll)
        {
            var survival = _character.PreviousCareers.Peek().Item2.Survival;
            var stat = _character.AttributeList.First(x => x.AttributeName == survival.AttributeToCheck);

            var check = survival.PassedCheck(roll + stat.AttributeModifier);

            Mishapped = !check;

            if (Mishapped) HasJob = false;

            return check;
        }
        #endregion
        #region Career Events

        public bool PassSkillCheck(TravellerSkillCheck check, int roll)
        {
            var skill = check.SkillToCheck;
            //Get the skill if we have it, or try jack of all trades
            var skillReal = _character.GetSkill(skill) ?? _character.GetSkill(TravellerSkills.JackOfAllTrades);
            //If we don't have them, -3, other wise use them!
            var DM = skillReal?.SkillValue ?? -3;

            return check.PassedCheck(roll + DM);
        }
        public TravellerEventCharacterCreation GetLifeEvent(int roll) => _character.LastCareer.GetLifeEvent(roll);

        public TravellerEventCharacterCreation GetEvent(int roll)
        {
            if (roll < 2 || roll > 12)
            {
                throw new ArgumentOutOfRangeException("Error die roll was out of range!");
            }

            //The life event table is supposed to be the numbers between 2-12. We must adjust for 
            //Zero based indexing
            return _character.LastCareer.Events[roll - 2];
        }

        //TODO Impliment rewards
        /// <summary>
        /// Apply a reward to the character.
        /// </summary>
        /// <param name="reward">The reward given to the character</param>
        /// <returns>Returns true if the reward requires user input</returns>
        public bool ApplyReward(TravellerCharacterCreationReward reward)
        {
            if (reward is TravellerRewardWeapon)
            {

            }else if (reward is TravellerRewardSkillChoice)
            {
                
            }else if (reward is TravellerRewardQualification)
            {

            }
            else if (reward is TravellerRewardOther)
            {

            }
            else if (reward is TravellerRewardLifeEvent)
            {

            }
            else if (reward is TravellerRewardEmpty)
            {

            }
            else if (reward is TravellerRewardContact)
            {

            }
            else if (reward is TravellerRewardCharacterCreationSkill)
            {

            }
            else if (reward is TravellerRewardCharacterCreationJobChange)
            {

            }
            else if (reward is TravellerRewardCharacterCreationItem)
            {

            }
            else if (reward is TravellerRewardBonusBenefit)
            {

            }
            else if (reward is TravellerRewardCharacterCreationBenefitIncrease)
            {

            }
            else if (reward is TravellerRewardCharacterCreationAdvancement)
            {

            }
            else if (reward is TravellerRewardAttribute)
            {

            }

            return false;
        }

        #endregion
        #region CareerMishaps
        public TravellerEventCharacterCreation GetMishap(int roll)
        {
            if (roll < 1 || roll > 6)
            {
                throw new ArgumentOutOfRangeException("Error die roll was out of range!");
            }

            //The mishap table is supposed to be the numbers between 1 and 6. We must adjust for 
            //Zero based indexing
            return _character.LastCareer.Mishaps[roll - 1];
        }
        #endregion
        #region Advancing

        public (string title, TravellerCharacterCreationReward TravellerCharacterCreationReward) GetRank()
        {
            var rankListSize = _character.LastAssignment.RanksAndBonuses.Count;
            return _character.LastAssignment.RanksAndBonuses[
                Math.Min(rankListSize,_character.PreviousCareers.Peek().rank)];
        }

        public bool Advances(int roll)
        {

            var advance = _character.PreviousCareers.Peek().Item2.Advancement;
            var stat = _character.AttributeList.First(x => x.AttributeName == advance.AttributeToCheck);

            var check = advance.PassedCheck(roll + stat.AttributeModifier);

            Advanced = check;
            HardAdvanced = false;

            if (roll + stat.AttributeModifier >= 12)
            {
                HardAdvanced = true;
            }

            if (Advanced)
            {
                var career = _character.PreviousCareers.Pop();
                var newCareer = (career.Career, career.Assignment, career.rank++);
                _character.PreviousCareers.Push(newCareer);
            }

            return check;
        }
        #endregion
        #region Aging

        /// <summary>
        /// Apply aging for the term.
        /// </summary>
        /// <returns>Returns if the character needs to make an aging roll or not.</returns>
        public bool ApplyAging()
        {
            _character.Age += 4;
            return ((_character.Age - 18) / 4) > 4;
        }

        /// <summary>
        /// See if you have to dela with the effects of aging.
        /// </summary>
        /// <param name="roll">The roll for this terms aging, 2d6</param>
        /// <returns>whether or not you have to deal with the effects of an aging roll.</returns>
        public bool HasAgingEffect(int roll) => roll + ((_character.Age - 18) / 4) > 4;

        /// <summary>
        /// The effects of an aging roll
        /// </summary>
        /// <param name="roll">What you rolled on aging.</param>
        /// <returns>The effects of your roll.</returns>
        public TravellerInjury AgingRoll(int roll)
        {
            var aging = roll - ((_character.Age - 18) / 4);
            return aging switch
            { 
                0 => new TravellerInjury("Reduce one physical characteristic by 1",1),
                -1 => new TravellerMultiInjury("Reduce two physical characteristics by 1",
                    new List<TravellerInjury>
                    {
                        new TravellerInjury("First",1),
                        new TravellerInjury("Second",1),
                    }),
                -2 => new TravellerMultiInjury("Reduce three physical characteristics by 1",
                    new List<TravellerInjury>
                    {
                        new TravellerInjury("First",1),
                        new TravellerInjury("Second",1),
                        new TravellerInjury("Third",1),
                    }),
                -3 => new TravellerMultiInjury("Reduce one physical characteristics by 2, two by 1",
                    new List<TravellerInjury>
                    {
                        new TravellerInjury("First",2),
                        new TravellerInjury("Second",1),
                        new TravellerInjury("Third",1),
                    }),
                -4 => new TravellerMultiInjury("Reduce two physical characteristics by 2, one by 1",
                    new List<TravellerInjury>
                    {
                        new TravellerInjury("First",2),
                        new TravellerInjury("Second",2),
                        new TravellerInjury("Third",1),
                    }),
                -5 => new TravellerMultiInjury("Reduce three physical characteristics by 2",
                    new List<TravellerInjury>
                    {
                        new TravellerInjury("First",2),
                        new TravellerInjury("Second",2),
                        new TravellerInjury("Third",2),
                    }),
                _ => new TravellerMultiInjury("Reduce two physical characteristics by 2, and one mental by 1",
                    new List<TravellerInjury>
                    {
                        new TravellerInjury("First",2),
                        new TravellerInjury("Second",2),
                        new TravellerInjuryMental("Third",1),
                    }),

            };
        }
        #endregion
        #region Helper Methods

        public List<TravellerSkills> GetSubSkills(TravellerSkills skill)
            => skill switch
            {
                TravellerSkills.Animals => new List<TravellerSkills>
                {
                    TravellerSkills.Animals_Handling,
                    TravellerSkills.Animals_Training,
                    TravellerSkills.Animals_Veterinary
                },
                TravellerSkills.Art => new List<TravellerSkills>
                {
                    TravellerSkills.Art_Holography,
                    TravellerSkills.Art_Instrument,
                    TravellerSkills.Art_Preformer,
                    TravellerSkills.Art_VisualMedia,
                    TravellerSkills.Art_Write,
                },
                TravellerSkills.Athletics => new List<TravellerSkills>
                {
                    TravellerSkills.Athletics_Dexterity,
                    TravellerSkills.Athletics_Endurance,
                    TravellerSkills.Athletics_Strength,
                },
                TravellerSkills.Circle => new List<TravellerSkills>
                {
                    TravellerSkills.Circle_Abyss,
                    TravellerSkills.Circle_Aether,
                    TravellerSkills.Circle_Material,
                    TravellerSkills.Circle_Nether,
                    TravellerSkills.Circle_Void,
                },
                TravellerSkills.Drive => new List<TravellerSkills>
                {
                    TravellerSkills.Drive_HoverCraft,
                    TravellerSkills.Drive_Mole,
                    TravellerSkills.Drive_Track,
                    TravellerSkills.Drive_Walker,
                    TravellerSkills.Drive_Wheel,
                },
                TravellerSkills.Electronics => new List<TravellerSkills>
                {
                    TravellerSkills.Electronics_Comms,
                    TravellerSkills.Electronics_Computers,
                    TravellerSkills.Electronics_RemoteOps,
                    TravellerSkills.Electronics_Sensors,
                },
                TravellerSkills.Engineer => new List<TravellerSkills>
                {
                    TravellerSkills.Engineer_JDrive,
                    TravellerSkills.Engineer_LifeSupport,
                    TravellerSkills.Engineer_MDrive,
                    TravellerSkills.Engineer_Power,
                },
                TravellerSkills.Flyer => new List<TravellerSkills>
                {
                    TravellerSkills.Flyer_Airship,
                    TravellerSkills.Flyer_Grav,
                    TravellerSkills.Flyer_Ornithopter,
                    TravellerSkills.Flyer_Roter,
                    TravellerSkills.Flyer_Wing,
                },
                TravellerSkills.FreeForm => new List<TravellerSkills>
                {
                    TravellerSkills.FreeForm_Abyss,
                    TravellerSkills.FreeForm_Aether,
                    TravellerSkills.FreeForm_Material,
                    TravellerSkills.FreeForm_Nether,
                    TravellerSkills.FreeForm_Void,
                },
                TravellerSkills.GunCombat => new List<TravellerSkills>
                {

                    TravellerSkills.GunCombat_Archaic,
                    TravellerSkills.GunCombat_Energy,
                    TravellerSkills.GunCombat_Slug,
                },
                TravellerSkills.Gunner => new List<TravellerSkills>
                {
                    TravellerSkills.Gunner_Capital,
                    TravellerSkills.Gunner_Ortillery,
                    TravellerSkills.Gunner_Screen,
                    TravellerSkills.Gunner_Turret,
                },
                TravellerSkills.HeavyWeapons => new List<TravellerSkills>
                {
                    TravellerSkills.HeavyWeapons_Artillery,
                    TravellerSkills.HeavyWeapons_ManPortable,
                    TravellerSkills.HeavyWeapons_Vehicle,
                },
                TravellerSkills.JackLuck => new List<TravellerSkills>
                {
                    TravellerSkills.JackOfAllTrades,
                    TravellerSkills.Luck
                },
                TravellerSkills.Language => new List<TravellerSkills>
                {
                    TravellerSkills.Language_AxiosCommon,
                    TravellerSkills.Language_AxiosPolitical,
                    TravellerSkills.Langauge_Britannian,
                    TravellerSkills.Language_Common,
                    TravellerSkills.Langauge_ElderTongue,
                    TravellerSkills.Language_FederationCommon,
                    TravellerSkills.Language_germushian,
                    TravellerSkills.Langauge_HighImperial,
                    TravellerSkills.Language_HighVersian,
                    TravellerSkills.Langauge_Jedi,
                    TravellerSkills.Langauge_LowImperial,
                    TravellerSkills.Langauge_LowVersian,
                    TravellerSkills.Langauge_Sigmarian,
                    TravellerSkills.Language_Tekka,
                    TravellerSkills.Language_TradersCant,
                    TravellerSkills.Langauge_Utopian,
                    TravellerSkills.Language_Witcher,
                    TravellerSkills.Langauge_XiaoMing,
                    TravellerSkills.Language_Sith,
                },
                TravellerSkills.Melee => new List<TravellerSkills>
                {
                    TravellerSkills.Melee_Unarmed,
                    TravellerSkills.Melee_Blade,
                    TravellerSkills.Melee_Bludgeon,
                    TravellerSkills.Melee_Natural,
                    TravellerSkills.Melee_Void,
                },
                TravellerSkills.Pilot => new List<TravellerSkills>
                {
                    TravellerSkills.Pilot_CapitalShips,
                    TravellerSkills.Pilot_SmallCraft,
                    TravellerSkills.Pilot_Spacecraft,
                },
                TravellerSkills.Profession => new List<TravellerSkills>
                {
                    TravellerSkills.Profession_Belter,
                    TravellerSkills.Profession_Biologicals,
                    TravellerSkills.Profession_CivilEngineering,
                    TravellerSkills.Profession_Construction,
                    TravellerSkills.Profession_Hydroponics,
                    TravellerSkills.Profession_Polymers,
                },
                TravellerSkills.Religion => new List<TravellerSkills>
                {
                    TravellerSkills.Religion_BritannianSithism,
                    TravellerSkills.Religion_ModernSithism,
                    TravellerSkills.Religion_Deorism,
                    TravellerSkills.Religion_Gatism,
                    TravellerSkills.Religion_Imperialism,
                    TravellerSkills.Religion_JediIsm,
                    TravellerSkills.Religion_Lawgarism,
                    TravellerSkills.Religion_Sigmarism,
                    TravellerSkills.Religion_Sithism,
                    TravellerSkills.Religion_OrthodoxSithism,
                    TravellerSkills.Religion_Witcherism,
                },
                TravellerSkills.Science => new List<TravellerSkills>
                {
                    TravellerSkills.Science_Archaeology,
                    TravellerSkills.Science_Astronomy,
                    TravellerSkills.Science_Biology,
                    TravellerSkills.Science_Chemistry,
                    TravellerSkills.Science_Cosmology,
                    TravellerSkills.Science_Cybernetics,
                    TravellerSkills.Science_Economics,
                    TravellerSkills.Science_Genetics,
                    TravellerSkills.Science_History,
                    TravellerSkills.Science_Linguistics,
                    TravellerSkills.Science_Philosophy,
                    TravellerSkills.Science_Physics,
                    TravellerSkills.Science_Planetology,
                    TravellerSkills.Science_Psychology,
                    TravellerSkills.Science_Robotics,
                    TravellerSkills.Science_Sophontology,
                    TravellerSkills.Science_Voidology,
                    TravellerSkills.Science_Xenology,
                },
                TravellerSkills.Seafarer => new List<TravellerSkills>
                {
                    TravellerSkills.Seafarer_OceanShips,
                    TravellerSkills.Seafarer_Personal,
                    TravellerSkills.Seafarer_Sail,
                    TravellerSkills.Seafarer_Submarine,
                },
                TravellerSkills.Tactics => new List<TravellerSkills>
                {
                    TravellerSkills.Tactics_Military,
                    TravellerSkills.Tactics_Naval,
                },
                _ => new List<TravellerSkills>()
            };

        public bool AddSkillToCharacter(TravellerSkills skill)
        {
            return _character.AddSkill(skill);
        }

        private bool AddSkillTableEntryToCharacter(TravellerSkillTableEntry skillTableEntry)
        {
            if (skillTableEntry is TravellerSkillTableEntrySkill skill)
            {
                return _character.AddSkill(skill.Skill);
            }
            
            if (skillTableEntry is TravellerSkillTableEntryAttribute attribute)
            {
                _character.AddAttribute(attribute.Attribute);
                return true;
            }

            return true;
        }

        /// <summary>
        /// Roll a number of dice. Generate a random number for character creation.
        /// </summary>
        /// <param name="numberOfDice">The number of Dice to roll.</param>
        /// <param name="sides">The (inclusive) number of sides on the dice.</param>
        /// <returns></returns>
        public int RollDice(int numberOfDice = 2, int sidesPerDie = 6)
        {
            var result = 0;
            for (int i = 0; i < numberOfDice; i++)
            {
                result += dice.Next(1, sidesPerDie+1);
            }

            //The lowest you can have is the number of dice, but the highest value of those dice
            return Math.Max(Math.Min(numberOfDice*sidesPerDie,result),numberOfDice);
        }
        #endregion  

    }
}
