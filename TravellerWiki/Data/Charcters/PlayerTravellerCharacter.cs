using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using TravellerWiki.Data.CreationEvents;
using TravellerWiki.Data.Services;

namespace TravellerWiki.Data.Charcters
{
#nullable enable
    public class ComplexTravellerNPC : PlayerTravellerCharacter
    {
        public string Story { get; set; }
        public string CharacterID { get; }

        public ComplexTravellerNPC(PlayerTravellerCharacter character, string story) : base(character.PreviousCareers)
        {
            var StorageService = new TravellerCharacterStorageService();
            Story = story;
            CharacterID = StorageService.GenerateKey();
            

            Name = character.Name;
            Nationality = character.Nationality;
            Age = character.Age;
            JackOfAllTrades = character.JackOfAllTrades;
            SkillList = character.SkillList;
            AttributeList = character.AttributeList;
            Items = character.Items;
            Augments = character.Augments;
            Armour = character.Armour;
            Weapons = character.Weapons;
            Contacts = character.Contacts;
            Finances = character.Finances;
        }
    }

    public class PlayerTravellerCharacter : TravellerCharacter
    {
        public Stack<(TravellerCareer Career,TravellerAssignment Assignment, int rank)> PreviousCareers { get; }
        public TravellerCareer? LastCareer => PreviousCareers.Count > 0? PreviousCareers.Peek().Item1 : null;
        public Stack<TravellerEventCharacterCreation> CharactersEvents = new Stack<TravellerEventCharacterCreation>();
        public TravellerAssignment? LastAssignment => PreviousCareers.Count > 0 ? PreviousCareers.Peek().Item2 : null;

        public string LastRank
        {
            get
            {
                if (PreviousCareers.Count > 0)
                {
                    var rank = Math.Min(Math.Max(0, PreviousCareers.Peek().rank),PreviousCareers.Peek().Assignment.RanksAndBonuses.Count-1);
                    var title = PreviousCareers.Peek().Item2.RanksAndBonuses[rank].title;
                    return title;
                }
                else
                {
                    return "None";
                }
            }
        }

        public PlayerTravellerCharacter()
        {
            PreviousCareers = new Stack<(TravellerCareer, TravellerAssignment, int)>();
        }

        public PlayerTravellerCharacter(Stack<(TravellerCareer, TravellerAssignment, int)> previousCareers) : base()
        {
            PreviousCareers = previousCareers;
            
        }

    }
}