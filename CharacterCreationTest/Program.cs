using System;
using System.Collections.Generic;
using System.Linq;
using CharacterCreationTest.CharacterCreation;
using TravellerWiki.Data;
using TravellerWiki.Data.Charcters;

namespace CharacterCreationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i=0; i < 1; i++) { 
                GenerateCharacter();
            }

            Console.WriteLine("Press any key to exit");

            Console.ReadKey();
        }

        private static void GenerateCharacter()
        {
            var travellerCreator = new CharacterCreator();
            travellerCreator.NewCharacter();

            var random = new Random();

            GenerateName(travellerCreator, random);
            GenerateValues(travellerCreator);

            var nation = ApplyNationality(random, travellerCreator);
            GetBackgroundSkills(travellerCreator, nation, random);

            var career = GetCareer(travellerCreator, random);
            BasicTraining(travellerCreator, career, random);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(travellerCreator._character.ToString());
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        #region career
        private static TravellerCareer GetCareer(CharacterCreator travellerCreator, Random random)
        {
            Console.WriteLine("Getting career.");

            var careers = travellerCreator.GetTravellerCareers();
            var careerNumber = random.Next(0, careers.Count);
            var career = careers[careerNumber];

            Console.WriteLine($"Chosen Career: {career.CareerName}");

            if (!travellerCreator.CanEnterCareer(career.Qualifications[0], travellerCreator.RollDice()))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to enter career!");
                Console.ForegroundColor = ConsoleColor.Gray;
                if (!travellerCreator.HasBeenDrafted)
                {
                    Console.WriteLine("Was drafted");
                    career = travellerCreator.GetDrafted(random.Next(0,
                        travellerCreator._character.Nationality.DraftTable.Length));
                }
                else
                {
                    Console.WriteLine("Took drifter");
                    career = travellerCreator.GetDrifter();
                }
            }

            Console.WriteLine($"Spending term in: {career.CareerName}");
            
            return career;
        }

        private static void BasicTraining(CharacterCreator travellerCreator, TravellerCareer career, Random random)
        {
            if (travellerCreator.GetsBasicTraining())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Gets basic training");
                if (!travellerCreator.HasHadJob)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("First basic training");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    travellerCreator.ApplyFirstBasicTraining(career);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Normal basic training");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    travellerCreator.ApplyRegularBasicTraining(
                        career.ServiceSkillsList[random.Next(0, career.ServiceSkillsList.Count)]);
                }
            }
        }
        #endregion
        #region background skills
        private static void GetBackgroundSkills(CharacterCreator travellerCreator, TravellerNationsCharacterInfo nation,
            Random random)
        {
            var backgroundSkillList = travellerCreator.GetBackgoundSkills(nation);
            var backgroundSkills = new List<TravellerSkill>();

            for (int i = 0; i < travellerCreator.NumberOfTravellerBackgroundSKills; i++)
            {
                backgroundSkills.Add(backgroundSkillList[random.Next(0, backgroundSkillList.Count)]);
            }

            travellerCreator.ApplyBackgroundSkills(backgroundSkills);
        }
        #endregion
        #region nationality
        private static TravellerNationsCharacterInfo ApplyNationality(Random random, CharacterCreator travellerCreator)
        {
            var nationService = new TravellerNationsCharacterInfoService();
            var nations = nationService.GetNationsList;
            var nation = nations.ElementAt(random.Next(0, nations.Count));
            //TODO remove shitty code
            nation = nations.First(n => n.NationName == "Fifth Vers Empire");
            

            Console.WriteLine($"Chosen nation: {nation}");

            if (travellerCreator.NationHasEntryRequirements(nation))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Trying to enter nation.");
                if (!travellerCreator.CanEnterNationality(nation, nation.EntryRequirements[0], travellerCreator.RollDice()))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed to enter Nation");
                    nation = nationService.GetTravellerNationsCharacterInfos()[nation.ParentNation];
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Applying Nation: {nation}");
            Console.ForegroundColor = ConsoleColor.Gray;
            travellerCreator.ApplyNationality(nation);

            return nation;
        }
        #endregion
        #region basic setup

        private static void GenerateName(CharacterCreator travellerCreator, Random random)
        {
            Console.Write("Travellers Name: ");
            var names = new TravellerNameService()
                .GetNames(1, TravellerNameService.NationNameList.Any);
            var name = names[random.Next(names.Count)];
            
            Console.Write($"{name}\n");

            travellerCreator.SetName(name);
        }

        private static void GenerateValues(CharacterCreator travellerCreator)
        {
            var stats = travellerCreator.GenerateStats(true);

            var attributes = Enum.GetValues(typeof(TravellerAttributes));

            for (int i = 0; i < stats.Count; i++)
            {
                travellerCreator.AssignStat(new TravellerAttribute((TravellerAttributes) attributes.GetValue(i), stats[i]));
            }

            foreach (var stat in travellerCreator._character.AttributeList)
            {
                Console.WriteLine(stat);
            }
        }
#endregion
    }
}
