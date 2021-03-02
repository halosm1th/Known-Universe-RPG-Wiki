using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using TravellerWiki.Data;
using TravellerWiki.Data.Charcters;

namespace CharacterCreationTest.CharacterCreation
{
    class CharacterCreator
    {
        #region Public Variables
        public TravellerCharacter _character; 
        public int NumberOfTravellerBackgroundSKills =>
            3 + _character.AttributeList.First(x => x.AttributeName == TravellerAttributes.Education).AttributeModifier;

        #endregion
        #region Checks
        //Checks
        public bool HasCharacter { get; protected set; }

        public bool HasBeenDrafted { get; protected set; }
        public bool HasName { get; protected set; }
        public bool HasNationality { get; protected set; }
        public bool HasBackgroundSkills { get; protected set; }
        public bool HasHadJob { get; protected set; }
        public bool FirstTermOfJob { get; protected set; }
        public bool FinishedCharacterCreation { get; protected set; }
        public bool BuyEquipment { get; protected set; }
        
        #endregion
        #region private variables
        private Random dice = new Random();
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
        public List<TravellerCareer> GetTravellerCareers() => _character.Nationality.NationsCareers;
        public TravellerCareer GetDrifter() => _character.Nationality.DrifterCareer;

        public TravellerCareer GetDrafted(int roll)
        {
            if(roll > _character.Nationality.DraftTable.Length) throw new ArgumentOutOfRangeException("Error, draft roll outside expected range");

            return _character.Nationality.DraftTable[roll];
        }

        public bool CanEnterCareer(TravellerAttributeCheck careerCheck,
            int diceResult)
        {
            return
                careerCheck.PassedCheck(diceResult + _character.GetRelevantAttributeModifier(careerCheck.UnderlingAttribute));

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
        #region Core Career Loop
        public int RollSkillTable() => RollDice(1);

        public void ApplySkillTableResult(TravellerSkillTableEntry entry)
        {
            AddSkillTableEntryToCharacter(entry);
        }

        #endregion
        #region Helper Methods
        private void AddSkillTableEntryToCharacter(TravellerSkillTableEntry skillTableEntry)
        {
            if (skillTableEntry is TravellerSkillTableEntrySkill skill)
            {
                _character.AddSkill(skill.Skill);
            }else if (skillTableEntry is TravellerSkillTableEntryAttribute attribute)
            {
                _character.AddAttribute(attribute.Attribute);
            }
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

            return result;
        }
        #endregion  

    }
}
