using System;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace BasicFantasyRPCharacterCreator
{
    public class BasicFantasyCharacterCreator
    {
        private BasicFantasyRpCharacterBuilder _builder;

        public void CreateCharacter()
        {
            _builder = new BasicFantasyRpCharacterBuilder();
            Console.WriteLine("Setting Attributes");
            SetAttributes();
            Console.WriteLine("Setting Race");
            SetRace();
            Console.WriteLine("Setting class");
            SetClass();
        }

        private void SetRace()
        {
            var races = _builder.GetRaces();
            var race = races[_builder.GetRandom(0, races.Count)];
            _builder.SetRace(race);
        }

        private void SetClass()
        {
            var classes = _builder.GetClasses();
        }
        
        private void SetAttributes()
        {
            var attributes = _builder.GenerateAttributes();
            _builder.SetStrength(attributes[0]);
            _builder.SetDex(attributes[0]);
            _builder.SetCon(attributes[0]);
            _builder.SetWis(attributes[0]);
            _builder.SetInt(attributes[0]);
            _builder.SetChar(attributes[0]);
        }

    }
}