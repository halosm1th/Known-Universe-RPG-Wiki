using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellerWiki.Data;
using TravellerWiki.Data.Charcters;

namespace CharacterCreationTest.CharacterCreation
{
    class CharacterCreator
    {

        private TravellerCharacter _character;

        private Random dice = new Random();
        /// <summary>
        /// Roll a number of dice. Generate a random number for character creation.
        /// </summary>
        /// <param name="numberOfDice">The number of Dice to roll.</param>
        /// <param name="sides">The (inclusive) number of sides on the dice.</param>
        /// <returns></returns>
        public int RollDice(int numberOfDice=2, int sidesPerDie=6)
        {
            var result = 0;
            for (int i = 0; i < numberOfDice; i++)
            {
                result += dice.Next(1, sidesPerDie + 1);
            }

            return result;
        }

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

        /// <summary>
        /// Check if the nation has entry requirements. Should be called before Can Enter nation and apply nation.
        /// </summary>
        /// <param name="nationality">The nationality to check</param>
        /// <returns></returns>
        public bool NationHasEntryRequirements(TravellerNationsCharacterInfo nationality) => nationality.EntryRequirements != null;

        /// <summary>
        /// Check if a traveller can enter the particular nationality
        /// </summary>
        /// <param name="nationality">The Nationality the traveller wishes to enter</param>
        /// <param name="attribute"></param>
        /// <param name="diceResult"></param>
        /// <returns></returns>
        public bool CanEnterNationality(TravellerNationsCharacterInfo nationality, TravellerAttribute attribute,
            int diceResult) =>
            nationality.EntryRequirements.Any(x =>
                x.AttributeName == attribute.AttributeName &&
                x.AttributableValue <= diceResult + attribute.AttributeModifier);

        /// <summary>
        /// Apply the nationalities stat changes and perks to the character
        /// </summary>
        /// <param name="nationality">The Chosen nationality</param>
        public void ApplyNationality(TravellerNationsCharacterInfo nationality)
        {
            _character.Nationality = nationality;
            ApplyNationalityStatChange(nationality.StatChanges);
            ApplyNationsPerks(nationality.Perks);
        }

        /// <summary>
        /// Apply the perks from the nation to the character
        /// </summary>
        /// <param name="nationality">The chosen nationality</param>
        private void ApplyNationsPerks(List<TravellerCharacterCreationReward> perks)
        {
            foreach (var perk in perks)
            {
                if (perk is TravellerCharacterCreationItemReward itemReward)
                {
                    foreach (var item in itemReward.Items)
                    {
                        _character.AddItem(item);
                    }
                }
                else if (perk is TravellerCharacterCreationSkillReward skillReward)
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

        public int NumberOfTravellerBackgroundSKills => 
            _character.AttributeList.First(x => x.AttributeName == TravellerAttributes.Education).AttributeModifier;

        public Dictionary<int, TravellerSkill> GetBackgoundSkills(TravellerNationsCharacterInfo nationality)
        {
            return nationality.BackgroundSkills;
        }

        public void ApplyBackgroundSkills(List<TravellerSkill> skills)
        {
            foreach (var skill in skills)
            {
                _character.AddSkill(skill);
            }
        }
    }
}
