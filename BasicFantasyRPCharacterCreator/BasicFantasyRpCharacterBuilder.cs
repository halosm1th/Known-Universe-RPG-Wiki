using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Dice;
using Newtonsoft.Json.Bson;
using static BasicFantasyRPCharacterCreator.BasicFantasyAttributes;

namespace BasicFantasyRPCharacterCreator
{
    public class BasicFantasyRpCharacterBuilder
    {
        //There are 6 attributes in dnd.
        private readonly int NUM_OF_ATTRIBUTES = 6;
        private readonly int PRIME_REQISIT_MIN = 9;
        
        private BasicFantasyCharacter Character;
        private Random _random;

        private static List<BasicFantasyRace> RaceList = new List<BasicFantasyRace>()
        {
            
        };

        public BasicFantasyRpCharacterBuilder()
        {
            Character = new BasicFantasyCharacter();
        }

        public int GetRandom(int min, int max)
        {
            return _random.Next(min, max);
            
        }
        
        #region Attributes
        public List<int> GenerateAttributes()
        {
            var attr = new List<int>();
            for (int i = 0; i < NUM_OF_ATTRIBUTES; i++)
            {
                attr.Add((int) Math.Round(Roller.Roll("3D6").Value));
            }

            if (attr.Sum() <= ((PRIME_REQISIT_MIN - 1) * NUM_OF_ATTRIBUTES))
            {
                return GenerateAttributes();
            }

            return attr;
        }

        public void SetStrength(int str)
        {
            Character.Attributes.Add(new BasicFantasyAttribute(Strength,str));
        }
        
        public void SetDex(int dex)
        {
            Character.Attributes.Add(new BasicFantasyAttribute(Dexterity,dex));
        }
        public void SetWis(int wis)
        {
            Character.Attributes.Add(new BasicFantasyAttribute(Wisdom,wis));
        }
        public void SetCon(int con)
        {
            Character.Attributes.Add(new BasicFantasyAttribute(Constitution,con));
        }
        public void SetInt(int intel)
        {
            Character.Attributes.Add(new BasicFantasyAttribute(Intelligence,intel));
        }
        public void SetChar(int cha)
        {
            Character.Attributes.Add(new BasicFantasyAttribute(Charisma,cha));
        }
        #endregion
        #region Race

        public List<BasicFantasyRace> GetRaces()
        {
            var races = new List<BasicFantasyRace>();
            foreach (var race in RaceList)
            {
                if (race.MeetsAttributeRequirements(Character))
                {
                    races.Add(race);
                }
            }

            return races;
        }

        public void SetRace(BasicFantasyRace race)
        {
            Character.Race = race;
        }
        #endregion
        #region Classes

        public List<BasicFantasyClass> GetClasses()
        {
            
        }
        #endregion
    }
}