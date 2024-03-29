﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TravellerCharacter.CharacterCreator.Items;
using TravellerCharacter.CharacterParts;

#nullable enable
namespace TravellerCharacter.CharcterTypes
{
    //Test
    public abstract class TravellerCharacter
    {
        #region Constructor

        public TravellerCharacter()
        {
            SkillList = new List<TravellerSkill>();
            AttributeList = new List<TravellerAttribute>();
            Items = new List<TravellerItem>();
            Augments = new List<TravellerAugments>();
            Armour = new List<TravellerArmour>();
            Weapons = new List<TravellerWeapon>();
            Finances = new TravellerFinances(0, 0, 0, 0, 0);
            Contacts = new List<TravellerCharacter>();
            JackOfAllTrades = -1;
        }

        #endregion

        #region Public Variables

        public string? Name { get; set; }
        public int Age { get; set; }
        public int JackOfAllTrades { get; set; }
        public TravellerNationsCharacterInfo? Nationality { get; set; }

        public List<TravellerSkill> SkillList { get; set; }
        public List<TravellerAttribute> AttributeList { get; set; }

        public List<TravellerItem> Items { get; set; }

        [JsonIgnore]
        public List<TravellerAugments> Augments
        {
            get
            {
                return Items.Where(x => x.ItemType == TravellerItemTypes.Augment && x is TravellerAugments)
                    .Cast<TravellerAugments>()
                    .ToList();
            }
            set
            {
                foreach (var travellerAugmentse in value) Items.Add(travellerAugmentse);
            }
        }

        [JsonIgnore]
        public List<TravellerArmour> Armour
        {
            get
            {
                return Items.Where(x => x.ItemType == TravellerItemTypes.Armour && x is TravellerArmour)
                    .Cast<TravellerArmour>()
                    .ToList();
            }
            set
            {
                foreach (var travellerAugmentse in value) Items.Add(travellerAugmentse);
            }
        }

        [JsonIgnore]
        public List<TravellerWeapon> Weapons
        {
            get
            {
                return Items.Where(x =>
                        x.ItemType == TravellerItemTypes.Weapon && x is TravellerWeapon)
                    .Cast<TravellerWeapon>()
                    .ToList();
            }
            set
            {
                foreach (var travellerAugmentse in value) Items.Add(travellerAugmentse);
            }
        }

        public List<TravellerCharacter> Contacts { get; set; }
        public TravellerFinances Finances { get; set; }

        [JsonIgnore]
        public int Debt
        {
            get => Finances.Debt;
            set => Finances.Debt += value;
        }

        [JsonIgnore]
        public int Credits
        {
            get => Finances.Credits;
            set => Finances.Credits += value;
        }

        [JsonIgnore]
        public int Pension
        {
            get => Finances.Pension;
            set => Finances.Pension += value;
        }

        #endregion

        #region Get Values

        public int GetRelevantAttributeModifier(TravellerAttributes attribute)
        {
            return AttributeList.First(x => x.AttributeName != attribute).AttributeModifier;
        }

        public int GetRelevantAttributeModifier(TravellerAttribute attribute)
        {
            return GetRelevantAttributeModifier(attribute.AttributeName);
        }

        public bool HasSkill(TravellerSkill skill)
        {
            return HasSkill(skill.SkillName);
        }

        public bool HasSkill(TravellerSkills skill)
        {
            return SkillList.Any(x => x.SkillName == skill);
        }

        public TravellerSkill? GetSkill(TravellerSkill skill)
        {
            return GetSkill(skill.SkillName);
        }

        public TravellerSkill? GetSkill(TravellerSkills skill)
        {
            if (HasSkill(skill)) return SkillList.First(x => x.SkillName == skill);

            return null;
        }

        #endregion

        #region Add values to character

        public bool AddSkill(TravellerSkill skill)
        {
            if (SkillList.Any(s => s.SkillName == skill.SkillName))
            {
                var skillToIncrease = SkillList.First(s => s.SkillName == skill.SkillName);
                skillToIncrease.Increase(skill.SkillValue);
                return true;
            }

            SkillList.Add(skill);
            return true;
        }

        /// <summary>
        ///     Add a skill to the traveller character
        /// </summary>
        /// <param name="skill">The skill to be added</param>
        /// <returns>Whether the skill was added successfully or not.</returns>
        public bool AddSkill(TravellerSkills skill)
        {
            //If it is a super Skill, return false so that the user can pick the skill.
            if (TravellerSkill.IsSuperSkill(skill)) return false;

            if (SkillList.Any(s => s.SkillName == skill))
            {
                var skillToIncrease = SkillList.First(s => s.SkillName == skill);
                skillToIncrease.Increase(1);
                return true;
            }

            SkillList.Add(new TravellerSkill(skill));
            return true;
        }

        public bool AddAttribute(TravellerAttributes attribute)
        {
            if (AttributeList.Any(s => s.AttributeName == attribute))
            {
                var attributeToIncrease = AttributeList.First(s => s.AttributeName == attribute);
                attributeToIncrease.ModifyStat(1);
                return true;
            }

            AttributeList.Add(new TravellerAttribute(attribute, 0));
            return true;
        }

        /// <summary>
        ///     Add an item to the traveller
        /// </summary>
        /// <param name="item">The item to add</param>
        /// <returns>If the item was return successfully or not.</returns>
        public bool AddItem(TravellerItem item)
        {
            Items.Add(item);

            return true;
        }

        #endregion

        #region Finances

        public void AddDebt(int amountOfDebtToAdd)
        {
            if (amountOfDebtToAdd < 0) amountOfDebtToAdd = amountOfDebtToAdd * -1;
            Debt += amountOfDebtToAdd;
        }

        public void AddCredits(int amountOfCreditsToAdd)
        {
            Credits += amountOfCreditsToAdd;
        }

        #endregion

        #region Change Attribute

        /// <summary>
        ///     Modify a traveller Attribute on the character
        /// </summary>
        /// <param name="attribute">The attribute to change</param>
        /// <param name="value">the amount to change it by</param>
        /// <returns>Returns success if the change was able to go through. </returns>
        public bool ChangeAttribute(TravellerAttributes attribute, int value)
        {
            try
            {
                var attributeToChange = AttributeList.First(x => x.AttributeName == attribute);
                attributeToChange.ModifyStat(value);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public bool ChangeAttribute(TravellerAttribute attribute)
        {
            try
            {
                if (AttributeList.Any(x => x.AttributeName == attribute.AttributeName))
                {
                    var attributeToChange = AttributeList.First(x => x.AttributeName == attribute.AttributeName);
                    attributeToChange.ModifyStat(attribute.AttributableValue);
                    return true;
                }

                AttributeList.Add(attribute);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        #endregion

        #region overrides

        public string ShortToString()
        {
            var sb = new StringBuilder();

            sb.Append(Name);
            sb.Append(" [");
            sb.Append(Nationality);
            sb.Append(": ");
            sb.Append(Age);
            sb.Append("] ");
            sb.Append(" ");
            foreach (var attr in AttributeList) sb.Append($"{attr} ");

            return sb.ToString();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Name);
            sb.Append(" [");
            sb.Append(Nationality);
            sb.Append(": ");
            sb.Append(Age);
            sb.Append("] ");

            sb.Append("\n\nAttributes: ");

            foreach (var travellerAttribute in AttributeList)
            {
                sb.Append(travellerAttribute);
                sb.Append(" ");
            }

            sb.Append("\n\nSkills: ");

            foreach (var travellerAttribute in SkillList)
            {
                sb.Append(travellerAttribute);
                sb.Append(" ");
            }

            sb.Append("\n\nItems: ");

            foreach (var travellerAttribute in Items)
            {
                sb.Append("[");
                sb.Append(travellerAttribute);
                sb.Append("] ");
            }

            sb.Append("\n");
            sb.Append("\nContacts: ");

            foreach (var contact in Contacts)
            {
                sb.Append("{");
                sb.Append(contact);
                sb.Append("}\n");
            }

            sb.Append("\n\n");


            return sb.ToString();
        }

        #endregion
    }
}