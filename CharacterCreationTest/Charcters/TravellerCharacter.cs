using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellerWiki.Data.Charcters
{
    public class PlayerTravellerCharacter : TravellerCharacter
    {
    }

    public abstract class TravellerCharacter
    {
        #region Public Variables
        public string Name { get; set; }
        public int Age { get; set; }
        public int JackOfAllTrades { get; set; } 
        public TravellerNationsCharacterInfo Nationality { get; set; }

        public List<TravellerSkill> SkillList { get; set; }
        public List<TravellerAttribute> AttributeList{ get; set; }

        public List<TravellerItem> Items { get; set; }
        public List<TravellerAugments> Augments { get; set; }
        public List<TravellerArmour> Armour { get; set; }
        public List<TravellerWeapon> Weapons { get; set; }
        public List<TravellerFinances> Finances { get; set; }
        public List<TravellerCharacter> Contacts { get; set; }
        #endregion
        #region Constructor
        public TravellerCharacter()
        {
            SkillList = new List<TravellerSkill>();
            AttributeList = new List<TravellerAttribute>();
            Items = new List<TravellerItem>();
            Augments = new List<TravellerAugments>();
            Armour = new List<TravellerArmour>();
            Weapons = new List<TravellerWeapon>();
            Finances = new List<TravellerFinances>();
            Contacts = new List<TravellerCharacter>();
            JackOfAllTrades = -1;
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
        #endregion  
        #region Add values to character
        public bool AddSkill(TravellerSkill skill)
        {
            if (SkillList.Any(s => s.SkillName == skill.SkillName))
            {
                SkillList.Where(s => s.SkillName == skill.SkillName).Select(x => x.SkillValue += skill.SkillValue);
                return true;
            }
            else
            {
                SkillList.Add(skill);
                return true;
            }

            return false;
        }

        public bool AddSkill(TravellerSkills skill)
        {
            if (SkillList.Any(s => s.SkillName == skill))
            {
                SkillList.Where(s => s.SkillName == skill).Select(x => x.SkillValue += 1);
                return true;
            }
            else
            {
                SkillList.Add(new TravellerSkill(skill));
                return true;
            }

            return false;
        }

        public bool AddAttribute(TravellerAttributes attribute)
        {
            if (AttributeList.Any(s => s.AttributeName == attribute))
            {
                AttributeList.Where(s => s.AttributeName == attribute).Select(x => x.AttributableValue += 1);
                return true;
            }
            else
            {
                AttributeList.Add(new TravellerAttribute(attribute,1));
                return true;
            }

            return false;
        }

        /// <summary>
        /// Add an item to the traveller
        /// </summary>
        /// <param name="item">The item to add</param>
        /// <returns>If the item was return successfully or not.</returns>
        public bool AddItem(TravellerItem item)
        {
            if (item is TravellerAugments augments)
            {
                Augments.Add(augments);
                return true;
            }else if (item is TravellerWeapon weapon)
            {
                Weapons.Add(weapon);
                return true;
            }
            else if (item is TravellerArmour armour)
            {
                Armour.Add(armour);
                return true;
            }
            else
            {
                Items.Add(item);
                return true;
            }

            return false;
        }
#endregion
        #region Change Attribute
        /// <summary>
        /// Modify a traveller Attribute on the character
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
        #endregion
        #region overrides
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Name);
            sb.Append(" ");
            sb.Append(Nationality);
            sb.Append(" ");

            sb.Append("\n\n");

            foreach (var travellerAttribute in AttributeList)
            {
                sb.Append(travellerAttribute);
                sb.Append(" ");
            }

            sb.Append("\n\n");

            foreach (var travellerAttribute in SkillList)
            {
                sb.Append(travellerAttribute);
                sb.Append(" ");
            }

            sb.Append("\n\n");

            foreach (var travellerAttribute in Items)
            {
                sb.Append(travellerAttribute);
                sb.Append(" ");
            }

            sb.Append("\n");


            return sb.ToString();
        }
        #endregion
    }
}
