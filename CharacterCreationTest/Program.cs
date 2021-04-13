using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using CharacterCreationTest.CharacterCreation;
using TravellerWiki.Data;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.CreationEvents;
using TravellerWiki.Data.TravellerInjuries;

namespace CharacterCreationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Generate how many characters?");
            var input = Console.ReadLine();
            int number = 1;
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine($"Error with input: {input}, going with default of 1");
                number = 1;
            }

            for(int i=0; i < number; i++) { 
                Console.Clear();
                GenerateCharacter();
                Console.WriteLine($"\n\nPress enter to clear screen and generate the next character [{i}/{number}]");
                Console.ReadLine();

            }

            Console.WriteLine("Press any key to exit");

            Console.ReadKey();
        }

        private static TravellerCharacter GenerateCharacter()
        {
            var travellerCreator = new CharacterCreator();
            travellerCreator.NewCharacter();

            var random = new Random();
            int CharactersAge = 18 + (4 * random.Next(1,21));

            GenerateName(travellerCreator, random);
            GenerateValues(travellerCreator);
            GenerateNationality(random, travellerCreator);

            do
            {
                if (!travellerCreator.HasJob)
                {
                    FindCareer(travellerCreator, random);
                    Console.WriteLine("");
                }

                GenerateSkill(travellerCreator,random);
                Console.WriteLine("");

                CreationEvent(travellerCreator,random);
                Console.WriteLine("");

                if (travellerCreator.Mishapped)
                {
                    GetBenefits(travellerCreator,random);
                }

                IncreaseAge(travellerCreator,random);
                Console.WriteLine("");

            }
            //While the traveller has a job and is less then 100, or the traveller gets really unlucky and decides to drop out.
            while (travellerCreator.HardAdvanced ||
                   (travellerCreator.HasJob && travellerCreator.TravellersAge < CharactersAge) ||
                   random.Next(0,2)==1);
            //

            GetBenefits(travellerCreator, random);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(travellerCreator._character.ToString());
            Console.ForegroundColor = ConsoleColor.DarkGray;

            return travellerCreator.GetPlayerCharacter();
        }

        private static void GetBenefits(CharacterCreator creator, Random random)
        {
            var benefits = creator.GetBenefits();
            for (var i = 0; i < creator.NumberOfBenefitRolls; i++)
            {
                var roll = creator.RollDice(1);
                var cash = random.Next(0, 2) == 1;

                if ((roll == 1 || roll == 6) && creator.BenefitRollModifiers.Count > 0)
                {
                    var modifier = GetBenefitModifier(creator, random, roll);
                    roll += creator.UseModifier(modifier);
                }
                
                ApplyReward(creator,random,creator.GetBenefit(roll, cash));
            }
        }

        private static int GetBenefitModifier(CharacterCreator creator, Random random, int roll)
        {
            var modifier = random.Next(creator.BenefitRollModifiers.Count);
            if (roll + modifier < 1 || roll+modifier > 7)
            {
                return GetBenefitModifier(creator, random, roll);
            }

            return modifier;
        }

        private static void ApplyReward(CharacterCreator creator,Random random,TravellerCharacterCreationReward reward)
        {
            Console.WriteLine($"Apply reward: {reward}");
            if (creator.ApplyReward(reward))
            {
                if (reward is TravellerRewardWeapon weapon)
                {
                    creator.ApplyReward(new TravellerRewardItem(new List<TravellerItem>
                    {
                        new TravellerWeapon("Weapon", 2000, 0, 12, 0, "0D6", 0, weapon.RewardText)
                    }));

                }else if (reward is TravellerRewardSkillChoice choice)
                {
                    var skill = choice.SkillList[random.Next(choice.SkillList.Count)];

                    ApplyReward(creator,random,new TravellerRewardSkill(skill));

                    if (choice.PickCount > 1)
                    {
                        ApplyReward(creator,random,new TravellerRewardSkillChoice(choice.PickCount-1,choice.SkillList));
                    }
                }else if (reward is TravellerRewardOther other)
                {

                }
                else if (reward is TravellerRewardLifeEvent lifeEvent)
                {
                    ApplyEvent(creator,random,creator.GetLifeEvent(creator.RollDice()));
                }
                else if (reward is TravellerRewardSkill skills)
                {
                    var newSkills = new List<TravellerSkill>();
                    foreach (var skill in skills.Skilllist)
                    {
                        if (skill.IsSuperSkill())
                        {
                            newSkills.Add(new TravellerSkill(GetSubSkill(creator,random,skill.SkillName) ,skill.SkillValue));
                        }
                        else
                        {
                            newSkills.Add(skill);
                        }

                        ApplyReward(creator,random,new TravellerRewardSkill(newSkills));
                    }
                }
                else if (reward is TravellerRewardJobChange jobChange)
                {
                    var career = creator.GetCareer(jobChange.NewCareerName);
                    GetAssignmentAndJoinCareer(creator, random, career);
                }
            }
        }

        private static void CreationEvent(CharacterCreator travellerCreator, Random random)
        {
            TravellerEventCharacterCreation creationEvent;
            if (travellerCreator.CheckSurvival(travellerCreator.RollDice()))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("You survive");
                Console.ForegroundColor = ConsoleColor.Gray;
                creationEvent = GetEvent(travellerCreator);
                //Some events may impact advancement, better to use it twice in this case.
                ApplyEvent(travellerCreator,random,creationEvent);
                travellerCreator.GainBenefitForTerm();
                Advance(travellerCreator,random);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You mishap!");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine();
                creationEvent = GetMishap(travellerCreator);
                ApplyEvent(travellerCreator,random,creationEvent);
            }
        }

        private static void FindCareer(CharacterCreator travellerCreator, Random random)
        {
            var career = GetCareer(travellerCreator, random);
            GetAssignmentAndJoinCareer(travellerCreator, random, career);
        }

        private static void GetAssignmentAndJoinCareer(CharacterCreator travellerCreator, Random random, TravellerCareer career)
        {
            var assignment = GetAssignment(travellerCreator, career, random);
            JoinCareerAndBasicTraining(travellerCreator, random, career, assignment);
        }

        private static void JoinCareerAndBasicTraining(CharacterCreator travellerCreator, Random random, TravellerCareer career,
            TravellerAssignment assignment)
        {
            travellerCreator.JoinCareer(career, assignment);
            BasicTraining(travellerCreator, career, random);
        }

        private static void GenerateNationality(Random random, CharacterCreator travellerCreator)
        {
            var nation = ApplyNationality(random, travellerCreator);
            GetBackgroundSkills(travellerCreator, nation, random);
        }

        #region career

        public static void Advance(CharacterCreator creator, Random random)
        {
            if (creator.Advances(creator.RollDice()))
            {
                var rank = creator.GetRank();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Advanced!");
                Console.WriteLine($"{rank.title}: {rank.TravellerCharacterCreationReward}");
                Console.ForegroundColor = ConsoleColor.Gray;
                //Generate the bonus skill for advancing
                GenerateSkill(creator,random);
            }
        }

        private static void IncreaseAge(CharacterCreator creator, Random random)
        {
            Console.WriteLine("Applying aging");
            if (creator.ApplyAging())
            {
                var roll = creator.RollDice();
                if (creator.HasAgingEffect(roll))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Aging has an effect!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    var injury = creator.AgingRoll(roll);
                    ApplyInjury(creator,random, injury);
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"The traveller is now {creator.TravellersAge} years old");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void ApplyInjuries(CharacterCreator creator, Random random, TravellerInjury injury)
        {
            if (injury is TravellerMultiInjury multi)
            {
                foreach (var singleInjury in multi.Injuries)
                {
                    ApplyInjury(creator,random, singleInjury);
                }
            }
        }

        private static void ApplyInjury(CharacterCreator creator, Random random, TravellerInjury injury)
        {
            if (injury is TravellerMultiInjuryChoice choice)
            {
                ApplyInjury(creator,random,choice.GetInjury(random.Next(choice.InjuryCount)));
                return;
            }
            
            if (injury is TravellerMultiInjury)
            {
                ApplyInjuries(creator,random,injury);
                return;
            }

            var statsEffected = creator.GetEffectedAttributes(injury);
            var stat = statsEffected[random.Next(statsEffected.Count)];

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There has been an injury!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"{injury.InjuryDescription}: {stat.AttributeName}({stat.AttributableValue}) will be reduced by {injury.InjuryDamage}");
            if (!creator.ApplyTravellerInjury(injury, stat))
            {
                int amountToRepair = random.Next(1, 5);
                int repairCost = creator.RollDice(1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The Traveller has died!\nWill be repaired for: {amountToRepair} costing: {(repairCost * creator.AgingCrisisCost) * amountToRepair}");
                Console.ForegroundColor = ConsoleColor.Gray;
                creator.RepairAttribute(amountToRepair, repairCost,stat);
            }
            else
            {
                Console.WriteLine("It was not fatal... yet.");
            }
        }

        private static void ApplyEvent(CharacterCreator creator,Random random,TravellerEventCharacterCreation creationEvent)
        {
            Console.WriteLine($"{creationEvent.EventText}");
            if (creationEvent is TravellerEventAttributeCheck attribute)
            {
                AttributeEvent(creator,random, attribute);
            }
            else if (creationEvent is TravellerEventChangeCareerWithAssignment changeWithAssignment)
            {
                var career = creator.GetCareer(changeWithAssignment.NewCareerName);
                var assignment = creator.GetAssignment(career,changeWithAssignment.Assignment);
                JoinCareerAndBasicTraining(creator,random,career,assignment);
            }
            else if (creationEvent is TravellerEventChangeCareers changeCareer)
            {
                var career = creator.GetCareer(changeCareer.NewCareerName);
                GetAssignmentAndJoinCareer(creator, random, career);
            }
            else if (creationEvent is TravellerEventSkillCheck skillCheck)
            {
                PreformASkillCheck(creator, random, skillCheck);
            }
            else if (creationEvent is TravellerEventChoice choice)
            {
                ChoiceEvent(creator, random, choice);
            }
            else if (creationEvent is TravellerEventSeverelyInjured injured)
            {
                ApplyInjury(creator,random, injured.GetSevereInjury(creator.RollDice(1),creator.RollDice(1)));
            }
            else if (creationEvent is TravellerEventInjury injury)
            {
                ApplyInjury(creator, random, injury.GetInjury(creator.RollDice(1)));
            }
            else if (creationEvent is TravellerEventLife life)
            {
                ApplyEvent(creator,random,creator.GetLifeEvent(creator.RollDice()));
            }
            else if (creationEvent is TravellerEventMishap mishap)
            {
                ApplyEvent(creator,random,creator.GetMishap(creator.RollDice(1)));
            }
            else if (creationEvent is TravellerEventMultiChoice multi)
            {
                ApplyEvent(creator,random,multi.GetEvent(random.Next(0,multi.Events.Count)));
            }
            else if (creationEvent is TravellerEventReward rewards)
            {
                foreach (var reward in rewards.Reward)
                {
                    Console.WriteLine(reward);
                    ApplyReward(creator,random,reward);
                }
            }
            else if (creationEvent is TravellerEventText eventText)
            {
            }
        }

        private static void PreformASkillCheck(CharacterCreator creator, Random random, TravellerEventSkillCheck skillCheck)
        {
            var check = skillCheck.SkillChecks[random.Next(skillCheck.SkillChecks.Count)];
            if (creator.PassSkillCheck(check, creator.RollDice()))
            {
                Console.Write(skillCheck.YesText);
                Console.WriteLine(" <<You succeed>>");
                if (skillCheck.HasYesEvent)
                {
                    ApplyEvent(creator, random, skillCheck.YesEvent);
                }
            }
            else
            {
                Console.WriteLine(skillCheck.NoText);
                Console.WriteLine(" <<You fail>>");
                if (skillCheck.HasNoEvent)
                {
                    ApplyEvent(creator, random, skillCheck.NoEvent);
                }
            }
        }

        private static void ChoiceEvent(CharacterCreator creator, Random random, TravellerEventChoice choice)
        {
            if (random.Next(0, 2) != 1)
            {
                Console.WriteLine($"{choice.YesText}");
                if (choice.HasYesEvent)
                {
                    ApplyEvent(creator, random, choice.YesEvent);
                }
            }
            else
            {
                Console.WriteLine($"{choice.NoText}");
                if (choice.HasNoEvent)
                {
                    ApplyEvent(creator, random, choice.NoEvent);
                }
            }
        }

        private static void AttributeEvent(CharacterCreator creator,Random random ,TravellerEventAttributeCheck attribute)
        {
            if (attribute.AttributeChecks[0].PassedCheck(creator.RollDice()))
            {
                Console.WriteLine($"{attribute.YesText}");
                if (attribute.HasYesEvent)
                {
                    ApplyEvent(creator,random,attribute.YesEvent);
                }
            }
            else
            {
                Console.WriteLine($"{attribute.NoText}");
                if (attribute.HasNoEvent)
                {
                    ApplyEvent(creator,random,attribute.NoEvent);
                }
            }
        }

        private static TravellerEventCharacterCreation GetEvent(CharacterCreator creator)
        {
            return creator.GetEvent(creator.RollDice());
        }

        private static TravellerEventCharacterCreation GetMishap(CharacterCreator creator)
        {
            return creator.GetMishap(creator.RollDice(1));
        }

        private static TravellerCareer GetCareer(CharacterCreator travellerCreator, Random random)
        {
            Console.WriteLine("Getting career.");

            var careers = travellerCreator.GetTravellerCareers();
            var careerNumber = random.Next(0, careers.Count);
            var career = careers[careerNumber];

            Console.WriteLine($"Chosen Career: {career.CareerName} - {career.CareerDescription}");

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

        public static TravellerAssignment GetAssignment(CharacterCreator creator, TravellerCareer career,Random random)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Generating assignment");
            var assignments = creator.GetAssignments(career);

            var assignment = assignments[random.Next(0, assignments.Count)];

            Console.ForegroundColor = ConsoleColor.Blue ;
            Console.WriteLine($"Chosen Assignment: {assignment.Name} ");

            return assignment;
        }

        private static List<TravellerSkillTableEntry> GetSkillTable(CharacterCreator creator, Random random)
        {
            var skillTables = creator.GetSkillTables();
            var table = skillTables.ElementAt(random.Next(0, skillTables.Count));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Chosen the: {table.Item1}");
            Console.ForegroundColor = ConsoleColor.Gray;

            return table.Item2;
        }

        private static void GenerateSkill(CharacterCreator creator, Random random)
        {
            var table = GetSkillTable(creator, random);
            var skill = table[creator.RollOnSkillTable()];

            skill = GetSubSkill(creator, random, skill);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Gained the: {skill} Skill");
            Console.ForegroundColor = ConsoleColor.Gray;
            creator.ApplySkillTableResult(skill);
        }

        private static TravellerSkillTableEntry GetSubSkill(CharacterCreator creator, Random random,
            TravellerSkillTableEntry skill)
        {
            if (creator.IsSkill(skill) && creator.IsSuperSkill(skill))
            {
                var subSkills = creator.GetSubSkills(((TravellerSkillTableEntrySkill) skill).Skill);
                skill = new TravellerSkillTableEntrySkill(subSkills[random.Next(0, subSkills.Count)]);
            }

            return skill;
        }

        private static TravellerSkills GetSubSkill(CharacterCreator creator, Random random,
            TravellerSkills skill)
        {
            if (creator.IsSuperSkill(skill))
            {
                var subSkills = creator.GetSubSkills(skill);
                skill = subSkills[random.Next(0, subSkills.Count)];
            }

            return skill;
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
            

            Console.WriteLine($"Chosen nation: {nation}");

            if (travellerCreator.NationHasEntryRequirements(nation))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Trying to enter nation.");
                if (!travellerCreator.CanEnterNationality(nation, nation.EntryRequirements[0], travellerCreator.RollDice()))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed to enter Nation");
                    nation = nationService.GetTravellerNationsCharacterInfos().First(x => x.Nationality == nation.ParentNation);
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
