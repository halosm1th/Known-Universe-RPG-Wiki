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
        public List<TravellerContact> Contacts { get; set; }

        public bool AttributeCheck(TravellerAttribute attribute, int roll)
        {
            return AttributeList.First(atr => atr.AttributeName == attribute.AttributeName).AttributeModifier + roll > attribute.AttributableValue;
        }

        public bool SkillCheck(TravellerSkill skill, int roll)
        {
            return SkillList.First(skl => skl.SkillName == skill.SkillName).SkillValue + roll > skill.SkillValue;
        }

        public void AddItem(TravellerItem item)
        {
            if (item is TravellerWeapon)
            {
                Weapons.Add((TravellerWeapon) item);
            }
            else if (item is TravellerArmour)
            {
                Armour.Add((TravellerArmour) item);
            }
            else if (item is TravellerAugments)
            {
                Augments.Add((TravellerAugments) item);
            }
            else
            {
                Items.Add(item);
            }
        }
    }
}
