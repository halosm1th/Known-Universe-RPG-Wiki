using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using Antlr4.Runtime.Tree;
using Microsoft.VisualBasic.CompilerServices;

namespace BasicFantasyRPCharacterCreator
{
    public abstract class BasicFantasyClass
    {
        public string Name { get; set; }
        public abstract int XPForNext_Level(int currentLevel);
        public abstract int MaxLevel();
    }

    public class BasicFantasyCharacter
    {
        public string Name { get; set; }
        public int ArmourClass { get; set; }
        public int AttackBonus { get; set; }
        
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        
        public int XP { get; set; }
        public int XPForNext_Level => Class.XPForNext_Level(CurrentLevel);
        
        public int CurrentLevel { get; set; }
        public int MaxLevel => Class.MaxLevel();
        
        public List<BasicFantasyItem> Equipment { get; set; }

        public List<BasicFantasyAttribute> Attributes { get; set; }

        public BasicFantasyAttribute GetAttribute(BasicFantasyAttributes attribute)
        {
            return Attributes.First(x => x.Attribute == attribute);
        }
        
        public BasicFantasySavingThrow DeathSavingThrow { get; set; }
        public BasicFantasySavingThrow WandsSavingThrow { get; set; }
        public BasicFantasySavingThrow SpellsSavingThrow { get; set; }
        public BasicFantasySavingThrow StoneSavingThrow { get; set; }
        public BasicFantasySavingThrow DragonsBreathSavingThrow { get; set; }
        
        
        public BasicFantasyRace Race { get; set; }
        public BasicFantasyClass Class { get; set; }

        

    }
}