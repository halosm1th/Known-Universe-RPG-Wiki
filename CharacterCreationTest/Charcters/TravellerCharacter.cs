using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellerWiki.Data.Charcters
{
    public abstract class TravellerCharacter
    {
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
    }
}
