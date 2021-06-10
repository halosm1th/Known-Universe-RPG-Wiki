using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.CreationEvents;
using TravellerWiki.Data.TravellerInjuries;

namespace TravellerWiki.Data.CharacterCreation
{
    public class ComplexCharacterGenerator
    {

        public List<(TravellerCharacter character, string creationStory)> GenerateCharacters(int count=1)
        {
            var characters = new List<(TravellerCharacter character, string creationStory)>();
            for (int i = 0; i < count; i++)
            {
                characters.Add(GenerateCharacterAndStory());
            }


            return characters;
        }

        public (TravellerCharacter character, string creationStory) GenerateCharacterAndStory()
        {
            return GenerateCharacter();
        }

        
        private static (TravellerCharacter character, string creationStory) GenerateCharacter()
        {
            var travellerCreator = new CharacterCreatorService();
            var story = new StringBuilder();
            var random = new Random();
            
            travellerCreator.NewCharacter();
            int CharactersAge = 18 + (4 * random.Next(1,21));

            GenerateName(travellerCreator, random, story);
            GenerateValues(travellerCreator, story);
            GenerateNationality(random, travellerCreator, story);

            do
            {
                if (!travellerCreator.HasJob)
                {
                    FindCareer(travellerCreator, random, story);
                    story.AppendLine("");
                }

                GenerateSkill(travellerCreator,random, story);
                story.AppendLine("");

                CreationEvent(travellerCreator,random, story);
                story.AppendLine("");

                if (travellerCreator.Mishapped)
                {
                    GetBenefits(travellerCreator,random,story);
                }

                IncreaseAge(travellerCreator,random, story);
                story.AppendLine("");

            }
            //While the traveller has a job and is less then 100, or the traveller gets really unlucky and decides to drop out.
            while (travellerCreator.HardAdvanced ||
                   (travellerCreator.HasJob && travellerCreator.TravellersAge < CharactersAge) ||
                   random.Next(0,2)==1);
            //

            GetBenefits(travellerCreator, random,story);

            Console.ForegroundColor = ConsoleColor.Green;
            story.Insert(0, travellerCreator._character.ToString());
            Console.ForegroundColor = ConsoleColor.DarkGray;

            return (travellerCreator.GetPlayerCharacter(),story.ToString());
        }

        private static void GetBenefits(CharacterCreatorService creator, Random random, StringBuilder story)
        {
            var benefits = creator.GetBenefits();
            for (var i = 0; i < creator.NumberOfBenefitRolls; i++)
            {
                var roll = creator.RollDice(1);
                var cash = random.Next(0, 2) == 1;

                if ((roll == 1 || roll == 6) && creator.BenefitRollModifiers.Count > 0)
                {
                    var modifier = GetBenefitModifier(creator, random, roll, story);
                    roll += creator.UseModifier(modifier);
                }
                
                ApplyReward(creator,random,creator.GetBenefit(roll, cash),story);
            }
        }

        private static int GetBenefitModifier(CharacterCreatorService creator, Random random, int roll, StringBuilder story)
        {
            var modifier = random.Next(creator.BenefitRollModifiers.Count);
            if (roll + modifier < 1 || roll+modifier > 7)
            {
                return GetBenefitModifier(creator, random, roll, story);
            }

            return modifier;
        }

        private static void ApplyReward(CharacterCreatorService creator,Random random,TravellerCharacterCreationReward reward, StringBuilder story)
        {
            story.AppendLine($"Apply reward: {reward}");
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

                    ApplyReward(creator,random,new TravellerRewardSkill(skill), story);

                    if (choice.PickCount > 1)
                    {
                        ApplyReward(creator,random,new TravellerRewardSkillChoice(choice.PickCount-1,choice.SkillList), story);
                    }
                }else if (reward is TravellerRewardOther other)
                {

                }
                else if (reward is TravellerRewardLifeEvent lifeEvent)
                {
                    ApplyEvent(creator,random,creator.GetLifeEvent(creator.RollDice()), story);
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

                        ApplyReward(creator,random,new TravellerRewardSkill(newSkills), story);
                    }
                }
                else if (reward is TravellerRewardJobChange jobChange)
                {
                    var career = creator.GetCareer(jobChange.NewCareerName);
                    GetAssignmentAndJoinCareer(creator, random, career, story);
                }
            }
        }

        private static void CreationEvent(CharacterCreatorService travellerCreator, Random random, StringBuilder story)
        {
            TravellerEventCharacterCreation creationEvent;
            if (travellerCreator.CheckSurvival(travellerCreator.RollDice()))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                story.AppendLine("You survive");
                Console.ForegroundColor = ConsoleColor.Gray;
                creationEvent = GetEvent(travellerCreator);
                //Some events may impact advancement, better to use it twice in this case.
                ApplyEvent(travellerCreator,random,creationEvent, story);
                travellerCreator.GainBenefitForTerm();
                Advance(travellerCreator,random, story);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                story.AppendLine("You mishap!");
                Console.ForegroundColor = ConsoleColor.Gray;

                story.AppendLine();
                creationEvent = GetMishap(travellerCreator);
                ApplyEvent(travellerCreator,random,creationEvent, story);
            }
        }

        private static void FindCareer(CharacterCreatorService travellerCreator, Random random, StringBuilder story)
        {
            var career = GetCareer(travellerCreator, random, story);
            GetAssignmentAndJoinCareer(travellerCreator, random, career, story);
        }

        private static void GetAssignmentAndJoinCareer(CharacterCreatorService travellerCreator, Random random, TravellerCareer career, StringBuilder story)
        {
            var assignment = GetAssignment(travellerCreator, career, random, story);
            JoinCareerAndBasicTraining(travellerCreator, random, career, assignment, story);
        }

        private static void JoinCareerAndBasicTraining(CharacterCreatorService travellerCreator, Random random, TravellerCareer career,
            TravellerAssignment assignment, StringBuilder story)
        {
            travellerCreator.JoinCareer(career, assignment);
            BasicTraining(travellerCreator, career, random, story);
        }

        private static void GenerateNationality(Random random, CharacterCreatorService travellerCreator, StringBuilder story)
        {
            var nation = ApplyNationality(random, travellerCreator, story);
            GetBackgroundSkills(travellerCreator, nation, random);
        }

        public static void Advance(CharacterCreatorService creator, Random random, StringBuilder story)
        {
            if (creator.Advances(creator.RollDice()))
            {
                var rank = creator.GetRank();
                Console.ForegroundColor = ConsoleColor.Green;
                story.AppendLine("Advanced!");
                story.AppendLine($"{rank.title}: {rank.TravellerCharacterCreationReward}");
                Console.ForegroundColor = ConsoleColor.Gray;
                //Generate the bonus skill for advancing
                GenerateSkill(creator,random, story);
            }
        }

        private static void IncreaseAge(CharacterCreatorService creator, Random random, StringBuilder story)
        {
            story.AppendLine("Applying aging");
            if (creator.ApplyAging())
            {
                var roll = creator.RollDice();
                if (creator.HasAgingEffect(roll))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    story.AppendLine("Aging has an effect!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    var injury = creator.AgingRoll(roll);
                    ApplyInjury(creator,random, injury, story);
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            story.AppendLine($"The traveller is now {creator.TravellersAge} years old");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void ApplyInjuries(CharacterCreatorService creator, Random random, TravellerInjury injury, StringBuilder story)
        {
            if (injury is TravellerMultiInjury multi)
            {
                foreach (var singleInjury in multi.Injuries)
                {
                    ApplyInjury(creator,random, singleInjury, story);
                }
            }
        }

        private static void ApplyInjury(CharacterCreatorService creator, Random random, TravellerInjury injury, StringBuilder story)
        {
            if (injury is TravellerMultiInjuryChoice choice)
            {
                ApplyInjury(creator,random,choice.GetInjury(random.Next(choice.InjuryCount)), story);
                return;
            }
            
            if (injury is TravellerMultiInjury)
            {
                ApplyInjuries(creator,random,injury, story);
                return;
            }

            var statsEffected = creator.GetEffectedAttributes(injury);
            var stat = statsEffected[random.Next(statsEffected.Count)];

            Console.ForegroundColor = ConsoleColor.Red;
            story.AppendLine("There has been an injury!");
            Console.ForegroundColor = ConsoleColor.Gray;
            story.AppendLine($"{injury.InjuryDescription}: {stat.AttributeName}({stat.AttributableValue}) will be reduced by {injury.InjuryDamage}");
            if (!creator.ApplyTravellerInjury(injury, stat))
            {
                int amountToRepair = random.Next(1, 5);
                int repairCost = creator.RollDice(1);
                Console.ForegroundColor = ConsoleColor.Red;
                story.AppendLine($"The Traveller has died!\nWill be repaired for: {amountToRepair} costing: {(repairCost * creator.AgingCrisisCost) * amountToRepair}");
                Console.ForegroundColor = ConsoleColor.Gray;
                creator.RepairAttribute(amountToRepair, repairCost,stat);
            }
            else
            {
                story.AppendLine("It was not fatal... yet.");
            }
        }

        private static void ApplyEvent(CharacterCreatorService creator,Random random,
            TravellerEventCharacterCreation creationEvent, StringBuilder story)
        {
            story.AppendLine($"{creationEvent.EventText}");
            if (creationEvent is TravellerEventAttributeCheck attribute)
            {
                AttributeEvent(creator,random, attribute, story);
            }
            else if (creationEvent is TravellerEventChangeCareerWithAssignment changeWithAssignment)
            {
                var career = creator.GetCareer(changeWithAssignment.NewCareerName);
                var assignment = creator.GetAssignment(career,changeWithAssignment.Assignment);
                JoinCareerAndBasicTraining(creator,random,career,assignment, story);
            }
            else if (creationEvent is TravellerEventChangeCareers changeCareer)
            {
                var career = creator.GetCareer(changeCareer.NewCareerName);
                GetAssignmentAndJoinCareer(creator, random, career, story);
            }
            else if (creationEvent is TravellerEventSkillCheck skillCheck)
            {
                PreformASkillCheck(creator, random, skillCheck, story);
            }
            else if (creationEvent is TravellerEventChoice choice)
            {
                ChoiceEvent(creator, random, choice, story);
            }
            else if (creationEvent is TravellerEventSeverelyInjured injured)
            {
                ApplyInjury(creator,random, injured.GetSevereInjury(creator.RollDice(1),creator.RollDice(1)), story);
            }
            else if (creationEvent is TravellerEventInjury injury)
            {
                ApplyInjury(creator, random, injury.GetInjury(creator.RollDice(1)), story);
            }
            else if (creationEvent is TravellerEventLife life)
            {
                ApplyEvent(creator,random,creator.GetLifeEvent(creator.RollDice()), story);
            }
            else if (creationEvent is TravellerEventMishap mishap)
            {
                ApplyEvent(creator,random,creator.GetMishap(creator.RollDice(1)), story);
            }
            else if (creationEvent is TravellerEventMultiChoice multi)
            {
                ApplyEvent(creator,random,multi.GetEvent(random.Next(0,multi.Events.Count)), story);
            }
            else if (creationEvent is TravellerEventReward rewards)
            {
                foreach (var reward in rewards.Reward)
                {
                    story.AppendLine(reward.ToString());
                    ApplyReward(creator,random,reward, story);
                }
            }
            else if (creationEvent is TravellerEventText eventText)
            {
            }
        }

        private static void PreformASkillCheck(CharacterCreatorService creator, Random random,
            TravellerEventSkillCheck skillCheck, StringBuilder story)
        {
            var check = skillCheck.SkillChecks[random.Next(skillCheck.SkillChecks.Count)];
            if (creator.PassSkillCheck(check, creator.RollDice()))
            {
                story.Append(skillCheck.YesText);
                story.AppendLine(" <<You succeed>>");
                if (skillCheck.HasYesEvent)
                {
                    ApplyEvent(creator, random, skillCheck.YesEvent, story);
                }
            }
            else
            {
                story.AppendLine(skillCheck.NoText);
                story.AppendLine(" <<You fail>>");
                if (skillCheck.HasNoEvent)
                {
                    ApplyEvent(creator, random, skillCheck.NoEvent, story);
                }
            }
        }

        private static void ChoiceEvent(CharacterCreatorService creator, Random random, 
            TravellerEventChoice choice, StringBuilder story)
        {
            if (random.Next(0, 2) != 1)
            {
                story.AppendLine($"{choice.YesText}");
                if (choice.HasYesEvent)
                {
                    ApplyEvent(creator, random, choice.YesEvent, story);
                }
            }
            else
            {
                story.AppendLine($"{choice.NoText}");
                if (choice.HasNoEvent)
                {
                    ApplyEvent(creator, random, choice.NoEvent, story);
                }
            }
        }

        private static void AttributeEvent(CharacterCreatorService creator,Random random ,
            TravellerEventAttributeCheck attribute, StringBuilder story)
        {
            if (attribute.AttributeChecks[0].PassedCheck(creator.RollDice()))
            {
                story.AppendLine($"{attribute.YesText}");
                if (attribute.HasYesEvent)
                {
                    ApplyEvent(creator,random,attribute.YesEvent, story);
                }
            }
            else
            {
                story.AppendLine($"{attribute.NoText}");
                if (attribute.HasNoEvent)
                {
                    ApplyEvent(creator,random,attribute.NoEvent,story);
                }
            }
        }

        private static TravellerEventCharacterCreation GetEvent(CharacterCreatorService creator)
        {
            return creator.GetEvent(creator.RollDice());
        }

        private static TravellerEventCharacterCreation GetMishap(CharacterCreatorService creator)
        {
            return creator.GetMishap(creator.RollDice(1));
        }

        private static TravellerCareer GetCareer(CharacterCreatorService travellerCreator, Random random, StringBuilder story)
        {
            story.AppendLine("Getting career.");

            var careers = travellerCreator.GetTravellerCareers();
            var careerNumber = random.Next(0, careers.Count);
            var career = careers[careerNumber];

            story.AppendLine($"Chosen Career: {career.CareerName} - {career.CareerDescription}");

            if (!travellerCreator.CanEnterCareer(career.Qualifications[0], travellerCreator.RollDice()))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                story.AppendLine("Failed to enter career!");
                Console.ForegroundColor = ConsoleColor.Gray;
                if (!travellerCreator.HasBeenDrafted)
                {
                    story.AppendLine("Was drafted");
                    career = travellerCreator.GetDrafted(random.Next(0,
                        travellerCreator._character.Nationality.DraftTable.Length));
                }
                else
                {
                    story.AppendLine("Took drifter");
                    career = travellerCreator.GetDrifter();
                }
            }

            story.AppendLine($"Spending term in: {career.CareerName}");
            
            return career;
        }

        public static TravellerAssignment GetAssignment(CharacterCreatorService creator, TravellerCareer career,Random random, StringBuilder story)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            story.AppendLine("Generating assignment");
            var assignments = creator.GetAssignments(career);

            var assignment = assignments[random.Next(0, assignments.Count)];

            Console.ForegroundColor = ConsoleColor.Blue ;
            story.AppendLine($"Chosen Assignment: {assignment.Name} ");

            return assignment;
        }

        private static List<TravellerSkillTableEntry> GetSkillTable(CharacterCreatorService creator, Random random, StringBuilder story)
        {
            var skillTables = creator.GetSkillTables();
            var table = skillTables.ElementAt(random.Next(0, skillTables.Count));
            Console.ForegroundColor = ConsoleColor.Yellow;
            story.AppendLine($"Chosen the: {table.Item1}");
            Console.ForegroundColor = ConsoleColor.Gray;

            return table.Item2;
        }

        private static void GenerateSkill(CharacterCreatorService creator, Random random, StringBuilder story)
        {
            var table = GetSkillTable(creator, random,story);
            var skill = table[creator.RollOnSkillTable()];

            skill = GetSubSkill(creator, random, skill);

            Console.ForegroundColor = ConsoleColor.Green;
            story.AppendLine($"Gained the: {skill} Skill");
            Console.ForegroundColor = ConsoleColor.Gray;
            creator.ApplySkillTableResult(skill);
        }

        private static TravellerSkillTableEntry GetSubSkill(CharacterCreatorService creator, Random random,
            TravellerSkillTableEntry skill)
        {
            if (creator.IsSkill(skill) && creator.IsSuperSkill(skill))
            {
                var subSkills = creator.GetSubSkills(((TravellerSkillTableEntrySkill) skill).Skill);
                skill = new TravellerSkillTableEntrySkill(subSkills[random.Next(0, subSkills.Count)]);
            }

            return skill;
        }

        private static TravellerSkills GetSubSkill(CharacterCreatorService creator, Random random,
            TravellerSkills skill)
        {
            if (creator.IsSuperSkill(skill))
            {
                var subSkills = creator.GetSubSkills(skill);
                skill = subSkills[random.Next(0, subSkills.Count)];
            }

            return skill;
        }

        private static void BasicTraining(CharacterCreatorService travellerCreator, 
            TravellerCareer career, Random random, StringBuilder story)
        {
            if (travellerCreator.GetsBasicTraining())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                story.AppendLine("Gets basic training");
                if (!travellerCreator.HasHadJob)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    story.AppendLine("First basic training");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    travellerCreator.ApplyFirstBasicTraining(career);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    story.AppendLine("Normal basic training");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    travellerCreator.ApplyRegularBasicTraining(
                        career.ServiceSkillsList[random.Next(0, career.ServiceSkillsList.Count)]);
                }
            }
        }

        private static void GetBackgroundSkills(CharacterCreatorService travellerCreator, 
            TravellerNationsCharacterInfo nation,
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

        private static TravellerNationsCharacterInfo ApplyNationality(Random random, 
            CharacterCreatorService travellerCreator, StringBuilder story)
        {
            var nationService = new TravellerNationsCharacterInfoService();
            var nations = nationService.GetNationsList;
            var nation = nations.ElementAt(random.Next(0, nations.Count));
            

            story.AppendLine($"Chosen nation: {nation}");

            if (travellerCreator.NationHasEntryRequirements(nation))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                story.AppendLine("Trying to enter nation.");
                if (!travellerCreator.CanEnterNationality(nation, nation.EntryRequirements[0], travellerCreator.RollDice()))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    story.AppendLine("Failed to enter Nation");
                    nation = nationService.GetTravellerNationsCharacterInfos().First(x => x.Nationality == nation.ParentNation);
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            story.AppendLine($"Applying Nation: {nation}");
            Console.ForegroundColor = ConsoleColor.Gray;
            travellerCreator.ApplyNationality(nation);

            return nation;
        }

        private static void GenerateName(CharacterCreatorService travellerCreator, Random random
            , StringBuilder story)
        {
            story.Append("Travellers Name: ");
            var names = new TravellerNameService()
                .GetNames(1, TravellerNameService.NationNameList.Any);
            var name = names[random.Next(names.Count)];
            
            story.Append($"{name}\n");

            travellerCreator.SetName(name);
        }

        private static void GenerateValues(CharacterCreatorService travellerCreator, StringBuilder story)
        {
            var stats = travellerCreator.GenerateStats(true);

            var attributes = Enum.GetValues(typeof(TravellerAttributes));

            for (int i = 0; i < stats.Count; i++)
            {
                travellerCreator.AssignStat(new TravellerAttribute((TravellerAttributes) attributes.GetValue(i), stats[i]));
            }

            foreach (var stat in travellerCreator._character.AttributeList)
            {
                story.AppendLine(stat.ToString());
            }
        }
    }
}