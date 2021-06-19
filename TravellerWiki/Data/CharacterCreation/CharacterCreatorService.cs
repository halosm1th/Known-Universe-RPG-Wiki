using System;
using System.Collections.Generic;
using System.Linq;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.CreationEvents;
using TravellerWiki.Data.Services.CareerService;
using TravellerWiki.Data.TravellerInjuries;
using ArgumentNullException = System.ArgumentNullException;

namespace TravellerWiki.Data.CharacterCreation
{
    public class CharacterCreatorService
    {
        #region Public Variables
        public PlayerTravellerCharacter _character;
        public TravellerNationsCharacterInfo Nationality => _character.Nationality;
        public string Name => _character.Name;
        public readonly int AgingCrisisCost = 10000;
        public TravellerCareer LastCareer => _character.LastCareer ?? null;
        public Stack<(TravellerCareer Career, TravellerAssignment Assignment, int rank)> PreviousCareers => _character.PreviousCareers ?? null;
        public TravellerAssignment LastAssignment => _character.LastAssignment ?? null;
        public string LastRank => _character.LastRank ?? "None";
        public int LastRankNumber => _character.PreviousCareers.Peek().rank;
        public int NumberOfTravellerBackgroundSKills =>
            3 + _character.AttributeList.First(x => x.AttributeName == TravellerAttributes.Education).AttributeModifier;

        public int TravellersAge => _character.Age;

        public int QualificationModifier { get; protected set; }
        public int AdvancementModifier { get; protected set; }
        public int NumberOfBenefitRolls { get; protected set; }
        public List<int> BenefitRollModifiers { get; protected set; }

        public List<TravellerAttribute> GetAttributes => _character.AttributeList;
        public TravellerAttribute GetTravellerAttribute(TravellerAttributes attribute) => GetAttributes.First(x => x.AttributeName == attribute) ?? new TravellerAttribute(attribute, -1);

        public List<TravellerAttribute> GetPhysicalAttributes => GetAttributes.Where(x => x.IsPhysical()).ToList();
        public List<TravellerAttribute> GetMentalAttributes => GetAttributes.Where(x => x.IsMental()).ToList();

        public Stack<TravellerEventCharacterCreation> CurrentTermsEvents = new Stack<TravellerEventCharacterCreation>();
        public TravellerEventCharacterCreation LastEvent => CurrentTermsEvents.Count > 0 ? CurrentTermsEvents.Peek() : new TravellerEventText("Error");
        public List<TravellerCharacterCreationReward> ChosenBenefits = new List<TravellerCharacterCreationReward>();

        #endregion
        #region Checks
        //Checks

        public void ResetChecks()
        {
            HasCharacter = false;
            Dead = false;
            Advanced = false;
            HardAdvanced = false;
            Mishapped = false;
            HasBeenDrafted = false;

            HasName = false;
            HasStats = false;
            HasNationality = false;
            HasBackgroundSkills = false;
            HasHadJob = false;
            HasJob = false;
            FirstTermOfJob = false;
            FinishedCharacterCreation = false;
            BuyEquipment = false;
        }
        public bool HasCharacter { get; protected set; }
        public bool Dead { get; protected set; }
        public bool Advanced { get; protected set; }
        public bool HardAdvanced { get; protected set; }
        public bool Mishapped { get; protected set; }

        public bool HasBeenDrafted { get; set; }
        public bool HasName { get; protected set; }
        public bool HasStats { get; set; }
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
        private TravellerSpecialNPCService npcService = new TravellerSpecialNPCService();
        #endregion
        #region Constructor
        public CharacterCreatorService()
        {
            HasCharacter = false;
            HasName = false;
            HasNationality = false;
            HasBackgroundSkills = false;
            HasHadJob = false;
            FirstTermOfJob = true;
            FinishedCharacterCreation = true;
            BuyEquipment = false;
            BenefitRollModifiers = new List<int>();

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
        public List<int> GenerateStats(bool includePsi = false)
        {
            int numberOfStats = 6 + (includePsi ? 1 : 0);
            var result = new List<int>();
            for (int i = 0; i < numberOfStats; i++)
            {
                result.Add(RollDice());
            }

            return result;
        }

        /// <summary>
        /// Assign an attribute its value on the character, if one with that name exists, remove it and add the new one.
        /// </summary>
        /// <param name="attribute">The attribute to assign to the character sheet</param>
        public void AssignStat(TravellerAttribute attribute)
        {
            if (_character.AttributeList.Any(a => a.AttributeName == attribute.AttributeName))
            {
                _character.AttributeList.RemoveAll(a => a.AttributeName == attribute.AttributeName);
            }


            _character.AttributeList.Add(attribute);
        }
        #endregion
        #region Nationality
        /// <summary>
        /// Check if the nation has entry requirements. Should be called before Can Enter nation and apply nation.
        /// </summary>
        /// <param name="nationality">The nationality to check</param>
        /// <returns></returns>
        public bool NationHasEntryRequirements(TravellerNationsCharacterInfo nationality) => nationality.EntryRequirements.Count > 0;

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
                if (perk is TravellerRewardItem itemReward)
                {
                    foreach (var item in itemReward.Items)
                    {
                        _character.AddItem(item);
                    }
                }
                else if (perk is TravellerRewardSkill skillReward)
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

            HasBackgroundSkills = true;
        }
        #endregion
        #region Enter Career

        public TravellerCareer GetCareer(string careerName) => careerService.GetCareer(careerName);
        public TravellerAssignment GetAssignment(TravellerCareer career, string assignmentName) => GetAssignments(career).First(x => x.Name == assignmentName);
        public List<TravellerCareer> GetTravellerCareers() => _character.Nationality.NationsCareers;
        public TravellerCareer GetDrifter() => _character.Nationality.DrifterCareer;

        public TravellerCareer GetDrafted(int roll)
        {
            if (roll > _character.Nationality.DraftTable.Length) throw new ArgumentOutOfRangeException("Error, draft roll outside expected range");

            return _character.Nationality.DraftTable[roll];
        }

        public bool CanEnterCareer(TravellerAttributeCheck careerCheck, int diceResult)
            =>
                careerCheck.PassedCheck(diceResult
                    + _character.GetRelevantAttributeModifier(careerCheck.UnderlingAttribute) + QualificationModifier);

        public List<TravellerAssignment> GetAssignments(TravellerCareer career)
        {
            return career.Assignments;
        }

        public void JoinCareer(TravellerCareer career, TravellerAssignment assignment)
        {
            _character.PreviousCareers.Push((career, assignment, 0));
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
            if (!FirstTermOfJob) throw new ArgumentException("Error, not first of career!");
            AddSkillTableEntryToCharacter(basicTraining);
            FirstTermOfJob = false;
        }
        public void ApplyFirstBasicTraining(TravellerCareer career)
        {
            if (!FirstTermOfJob && HasHadJob) throw new ArgumentException("Error, not first career");
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
        public int RollOnSkillTable() => RollDice(1) - 1;

        public List<(string, List<TravellerSkillTableEntry>)> GetSkillTables()
        {
            var tables = new List<(string, List<TravellerSkillTableEntry>)>();
            tables.Add(("Service Skills", _character.PreviousCareers.Peek().Item1.ServiceSkillsList));
            tables.Add(("Personal Development Skills", _character.PreviousCareers.Peek().Item1.PersonalDevelopmentSkillList));
            tables.Add(($"{_character.PreviousCareers.Peek().Item2.Name} Skills", _character.PreviousCareers.Peek().Item2.SkillList));

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
            var check = false;
            try
            {
                var stat = _character.AttributeList.First(x => x.AttributeName == survival.AttributeToCheck);


                check = survival.PassedCheck(roll + stat.AttributeModifier);

                Mishapped = !check;

                if (Mishapped) HasJob = false;

            }
            catch (InvalidOperationException)
            {
                _character.AddAttribute(survival.AttributeToCheck);
                check = CheckSurvival(roll);
            }
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
            var evnt = _character.LastCareer.Events[roll - 2];
            AddEvent(evnt);
            return evnt;
        }

        public void AddEvent(TravellerEventCharacterCreation evnt)
        {
            CurrentTermsEvents.Push(evnt);
        }

        public void DoneEvent()
        {
            var temp = new Queue<TravellerEventCharacterCreation>();
            foreach (var evnt in CurrentTermsEvents)
            {
                temp.Enqueue(evnt);
            }

            foreach (var evnt in temp)
            {
                _character.CharactersEvents.Push(evnt);
            }
            CurrentTermsEvents = new Stack<TravellerEventCharacterCreation>();
        }

        /// <summary>
        /// Apply a reward to the character.
        /// </summary>
        /// <param name="reward">The reward given to the character</param>
        /// <returns>Returns true if the reward requires user input</returns>
        public bool ApplyReward(TravellerCharacterCreationReward reward)
        {
            if (reward is TravellerRewardCredits credits)
            {
                _character.AddCredits(credits.Amount);
                return false;
            }

            if (reward is TravellerRewardDebt debt)
            {
                _character.AddDebt(debt.Amount);
                return false;
            }

            if (reward is TravellerRewardWeapon)
            {
                //The traveller Must Pick out their weapon. 
                return true;
            }

            if (reward is TravellerRewardSkillChoice)
            {
                //The traveller must pick which skill to choose.
                return true;
            }

            if (reward is TravellerRewardQualification qualification)
            {
                QualificationModifier += qualification.IncreaseAmount;
                return false;
            }

            if (reward is TravellerRewardOther)
            {
                //Other rewards are not for the system!
                return true;
            }

            if (reward is TravellerRewardLifeEvent)
            {
                //Life events require a roll on a table!
                return true;
            }

            if (reward is TravellerRewardEmpty)
            {
                //If its an empty reward, nothing to do with it.
                return false;
            }

            if (reward is TravellerRewardContact contacts)
            {
                foreach (var contact in contacts.Contacts)
                {
                    var npc = npcService.GenerateTravellerSpecialNpc(contact.Key, contact.Value);
                    _character.Contacts.Add(npc);
                }

                return false;
            }

            if (reward is TravellerRewardSkill skills)
            {
                //If its a super skill
                if (skills.Skilllist.Any(x => x.IsSuperSkill())) return true;

                //if that somehow still snuck through!
                foreach (var skill in skills.Skilllist)
                {
                    if (!_character.AddSkill(skill)) return true;
                }

                return false;
            }

            if (reward is TravellerRewardJobChange)
            {
                return true;
            }

            if (reward is TravellerRewardItem items)
            {
                foreach (var item in items.Items)
                {
                    if (!_character.AddItem(item)) return true;
                }

                return false;
            }

            if (reward is TravellerRewardBonusBenefit benefit)
            {
                NumberOfBenefitRolls += benefit.NumberOfExtraRolls;
                return false;
            }

            if (reward is TravellerRewardBenefitIncrease benefitIncrease)
            {
                BenefitRollModifiers.Add(benefitIncrease.BenefitIncreaseAmount);
                return false;
            }

            if (reward is TravellerRewardAdvancement advance)
            {
                AdvancementModifier += advance.AdvancementAmount;
                return false;
            }

            if (reward is TravellerRewardAttribute attribute)
            {
                _character.ChangeAttribute(attribute.AttributeChange);
                return false;
            }

            if (reward is TravellerRewardCombatImplant combatImplant)
            {
                return true;
                _character.AddItem(new TravellerAugments("Combat Implant", 50000, 0, 12, "Gain any augmentations (see page 99) with a limit of Cr50000 and TL 12. If you roll this benefit again, then you may either take a different Augmentation or increase the one you already possess by one level (this may take it above the credit and TL limit)" ));
                return false;
            }

            if (reward is TravellerRewardArmour armour)
            {
                return true;
                _character.AddItem(new TravellerArmour("Armour", 10000, 0, 12, 0, 0,
                    "Select any type of armour with a limit of Cr10000 and TL 12. If you roll this benefit again, then you can either select another type of armour with the same limits or trade your original in for armour with a limit of Cr 25000."));
                return false;
            }

            if (reward is TravellerRewardBlade blade)
            {
                return true;
                _character.AddItem(new TravellerWeapon("Blade", 2000, 0, 12, 0, "0D6",
                    0, 0, new List<TravellerWeaponTraits> { }, "Select any blade weapon with a limit of Cr1000 and TL 12. If you roll this benefit again, you may take another blade or one level in the Melee (blades) skill."));
                return false;
            }

            if (reward is TravellerRewardGun gun)
            {
                return true; 
                _character.AddItem(new TravellerWeapon("Gun", 2000, 0, 12, 0, "0D6",
                    0, 0, new List<TravellerWeaponTraits> { }, "Select any common or military ranged weapon with a limit of Cr1000 and TL 12. If you roll this benefit again, you may take another weapon or one level in the appropriate Gun Combat skill for a weapon already received as a benefit"));
                return false;
            }

            if (reward is TravellerRewardAugment augment)
            {
                return true;
                _character.AddItem(
                    new TravellerAugments("Augment", 25000, 0, 12, "Gain any augmentations (see page 99) with a limit of Cr50000 and TL 12. If you roll this benefit again, then you may either take a different Augmentation or increase the one you already possess by one level (this may take it above the credit and TL limit)"));
                return false;
            }

            if (reward is TravellerRewardVehicle vehicle)
            {
                _character.AddItem(new TravellerGenericItem(@vehicle.RewardText, 100000000, 0, 15));
                return false;
            }

            if (reward is TravellerRewardShip ship)
            {
                _character.AddItem(new TravellerGenericItem(@ship.RewardText, 100000000, 0, 15));
                return false;
            }

            throw new ArgumentException("Error, this type fo reward isn't handled!");

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
            var evnt = _character.LastCareer.Mishaps[roll - 1];
            AddEvent(evnt);
            return evnt;
        }
        #endregion
        #region Advancing

        public (string title, TravellerCharacterCreationReward TravellerCharacterCreationReward) GetRank()
        {
            var rankListSize = _character.LastAssignment.RanksAndBonuses.Count;

            return _character.LastAssignment.RanksAndBonuses[
                Math.Min(rankListSize - 1, _character.PreviousCareers.Peek().rank)];
        }

        public bool Advances(int roll)
        {

            var advance = _character.PreviousCareers.Peek().Item2.Advancement;
            var stat = _character.AttributeList.First(x => x.AttributeName == advance.AttributeToCheck);

            var check = advance.PassedCheck(roll + stat.AttributeModifier + AdvancementModifier);

            Advanced = check;
            HardAdvanced = false;

            if (roll + stat.AttributeModifier >= 12)
            {
                HardAdvanced = true;
            }

            if (Advanced)
            {
                var career = _character.PreviousCareers.Pop();
                var rank = career.rank + 1;
                var newCareer = (career.Career, career.Assignment, rank);
                _character.PreviousCareers.Push(newCareer);
            }

            return check;
        }
        #endregion
        #region Benefits
        /// <summary>
        /// Gain ytour benefit for the term and finish the event.
        /// </summary>
        public void GainBenefitForTerm()
        {
            DoneEvent();
            NumberOfBenefitRolls++;
        }

        public List<(int cash, TravellerCharacterCreationReward benefits)> GetBenefits()
        {
            if (FirstTermOfJob)
            {
                var Currentcareer = PreviousCareers.Pop();
                var retCar = PreviousCareers.Peek().Career;
                PreviousCareers.Push(Currentcareer);
                return retCar.MusteringOutBenefits;
            }
            else
            {
                return LastCareer.MusteringOutBenefits;
            }
        }

        public int UseModifier(int usedBenefitModifier)
        {
            if (usedBenefitModifier < 0 || usedBenefitModifier > BenefitRollModifiers.Count) throw new ArgumentOutOfRangeException($"Error argument was outside of range for benefit rolls. Got {usedBenefitModifier} but range is 0-{BenefitRollModifiers.Count}");

            var benefit = BenefitRollModifiers[usedBenefitModifier];
            BenefitRollModifiers.RemoveAt(usedBenefitModifier);

            return benefit;
        }

        public TravellerCharacterCreationReward GetBenefit(int benefitNumber, bool cash = false)
        {
            if (benefitNumber >= GetBenefits().Count) benefitNumber = GetBenefits().Count - 1;
            if (benefitNumber < 0) benefitNumber = 0;

            NumberOfBenefitRolls--;
            if (cash)
            {
                return new TravellerRewardCredits(GetBenefits()[benefitNumber].cash);
            }

            return GetBenefits()[benefitNumber].benefits;

        }

        public void SelectBenefit(int benefitNumber, bool cash = false)
        {
            ChosenBenefits.Add(GetBenefit(benefitNumber, cash));
        }

        /// <summary>
        /// Generate the benefit rolls, and reset the chosen benefits list.
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, int> GenerateBenefits()
        {
            var rand = new Random();
            ChosenBenefits = new List<TravellerCharacterCreationReward>();

            var rolls = new Dictionary<int, int>();

            for (int i = 0; i < NumberOfBenefitRolls; i++)
            {
                rolls.Add(i, rand.Next(0, 6));
            }

            return rolls;
        }
        #endregion
        #region Injuries

        /// <summary>
        /// Apply damage to the character
        /// </summary>
        /// <param name="injury">The injury to apply</param>
        /// <param name="attributeEffected">The attribute to apply to the injury</param>
        /// <returns>Returns if the traveller is still alive after their injury or not. (True is alive, false is dead)</returns>
        public bool ApplyTravellerInjury(TravellerInjury injury, TravellerAttribute attributeEffected)
        {
            attributeEffected.ModifyStat(0 - injury.InjuryDamage);
            var result = attributeEffected.AttributableValue > 0;
            Dead = !result;
            return result;
        }

        public void RepairAttribute(int amountToRepair, int costRoll, TravellerAttribute attributeToRepair)
        {
            _character.AddDebt((costRoll * AgingCrisisCost) * amountToRepair);
            _character.ChangeAttribute(attributeToRepair.AttributeName, amountToRepair);
        }

        public List<TravellerAttribute> GetEffectedAttributes(TravellerInjury injury)
        {
            if (injury is TravellerInjurySpecific specific)
            {
                return GetPhysicalAttributes.Where(x => x.AttributeName == specific.Damage.AttributeName).ToList();
            }

            if (injury is TravellerInjuryMental)
            {
                return GetMentalAttributes;
            }

            return GetPhysicalAttributes;
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
                0 => new TravellerInjury("Reduce one physical characteristic by 1", 1),
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
                result += dice.Next(1, sidesPerDie + 1);
            }

            //The lowest you can have is the number of dice, but the highest value of those dice
            var min = Math.Min(numberOfDice * sidesPerDie, result);
            var max = Math.Max(min, numberOfDice);
            return max;
        }

        public PlayerTravellerCharacter GetPlayerCharacter() => _character;

        #endregion

    }
}
