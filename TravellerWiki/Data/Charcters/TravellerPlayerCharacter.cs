using System;
using System.Collections.Generic;
using System.Linq;

namespace TravellerWiki.Data.Charcters
{
    public class TravellerPlayerCharacter : TravellerCharacter
    {
        public string PlayerName { get; set; }

        public List<TravellerCareer> PreviousCareers { get; set; }

        public TravellerPlayerCharacter()
        {

        }

        public TravellerPlayerCharacter(string name, int age, int jackOfAllTrades, 
            TravellerNationsCharacterInfo nationality, List<TravellerSkill> skillList, 
            List<TravellerAttribute> attributeList, List<TravellerItem> items, 
            List<TravellerAugments> augments, List<TravellerArmour> armour, 
            List<TravellerWeapon> weapons, List<TravellerFinances> finances, 
            List<TravellerContact> contacts, string playerName, List<TravellerCareer> previousCareers) 
        {
            PlayerName = playerName;
            PreviousCareers = previousCareers;

            Name = name;
            Age = age;
            JackOfAllTrades = jackOfAllTrades;
            Nationality = nationality;
            AttributeList = attributeList;
            SkillList = skillList;
            Items = items;
            Augments = augments;
            Armour = armour;
            Weapons = weapons;
            Finances = finances;
            Contacts = contacts;
        }
    }

    public class TravellerCharacterCreator
    {
        public TravellerCharacter CreatedCharacter { get; set; }

        public TravellerCharacterCreator()
        {
            CreatedCharacter = new TravellerPlayerCharacter();
        }

        public void SetName(string name)
        {
            CreatedCharacter.Name = name;
        }

        public void SetStat(TravellerAttribute attribute)
        {
            CreatedCharacter.AttributeList.Add(attribute);
        }

        public bool TryEnterNation(TravellerNationsCharacterInfo nationality, int roll)
        {

            return nationality.EntryRequirements.Where(entryRequirement =>
            {
                var attribute =
                    CreatedCharacter.AttributeList.First(attr => attr.AttributeName == entryRequirement.AttributeName);
                var result = roll + attribute.AttributeModifier;
                return result >= entryRequirement.AttributableValue;
            }).Any();
        }

        public void SetNationality(TravellerNationsCharacterInfo nationality, int roll)
        {
            if (TryEnterNation(nationality,roll))
            {
                CreatedCharacter.Nationality = nationality;
                nationality.BackgroundSkills.ForEach(skill => CreatedCharacter.SkillList.Add(skill));
                nationality.Perks.ForEach(perk =>CreatedCharacter.AddItem(perk));
                CreatedCharacter.AttributeList.ForEach(attr =>
                    attr.AttributableValue += nationality.StatChanges
                        .First(backgroundAttr => 
                            backgroundAttr.AttributeName == attr.AttributeName)
                        .AttributableValue);
            }

        }
    }
}