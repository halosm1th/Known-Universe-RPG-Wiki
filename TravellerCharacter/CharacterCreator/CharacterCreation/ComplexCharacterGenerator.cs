using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellerCharacter.Character_Services;
using TravellerCharacter.CharacterCreator.Careers;
using TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward;
using TravellerCharacter.CharacterCreator.Careers.SkillEntry;
using TravellerCharacter.CharacterCreator.CreationEvents;
using TravellerCharacter.CharacterCreator.Items;
using TravellerCharacter.CharacterCreator.TravellerInjuries;
using TravellerCharacter.CharacterParts;
using TravellerCharacter.CharcterTypes;

namespace TravellerCharacter.CharacterCreator.CharacterCreation
{
    internal class ComplexCharacterGenerator
    {
        #region Access The Generated Characters

        public List<ComplexTravellerNPC> GenerateCharacters(int count = 1,
            TravellerNationalities nation = TravellerNationalities.Fifth_Vers_Empire, int age = 18, string name = "",
            bool usePsi = false)
        {
            var characters = new List<ComplexTravellerNPC>();
            for (var i = 0; i < count; i++) characters.Add(GenerateCharacterAndStory(nation, age, name, usePsi));


            return characters;
        }

        public ComplexTravellerNPC GenerateCharacterAndStory()
        {
            return GenerateCharacter();
        }

        public ComplexTravellerNPC GenerateCharacterAndStory(TravellerNationalities nation, int age = 18,
            string name = "", bool usePsi = false)
        {
            return GenerateCharacter(nation, age, name, usePsi);
        }

        #endregion

        #region Generator cores

        private static ComplexTravellerNPC
            GenerateCharacter(TravellerNationalities nation, int age = 18, string name = "", bool usePsi = false)
        {
            var travellerCreator = new CharacterCreatorService();
            var story = new StringBuilder();
            var random = new Random();

            travellerCreator.NewCharacter();
            GenerateCharacterWithPossibleName(nation, name, random, travellerCreator, story);
            GenerateValues(travellerCreator, story, usePsi);

            var nationService = new TravellerNationsCharacterInfoService();
            var nationality = nationService.GetNationsCharacterInfo(nation);
            ApplyNationality(nationality, random, travellerCreator, nationService, story);

            do
            {
                if (!travellerCreator.HasJob)
                {
                    FindCareer(travellerCreator, random, story);
                    story.AppendLine("");
                }

                GenerateSkill(travellerCreator, random, story);
                story.AppendLine("");

                CreationEvent(travellerCreator, random, story);
                story.AppendLine("");

                if (travellerCreator.Mishapped) GetBenefits(travellerCreator, random, story);

                IncreaseAge(travellerCreator, random, story);
                story.AppendLine("");
            }
            //While the traveller has a job and is less then 100, or the traveller gets really unlucky and decides to drop out.
            while (DoAnotherTerm(travellerCreator, age, random));
            //

            GetBenefits(travellerCreator, random, story);

            Console.ForegroundColor = ConsoleColor.Green;
            //story.Insert(0, travellerCreator._character.ToString());
            Console.ForegroundColor = ConsoleColor.DarkGray;

            return new ComplexTravellerNPC(travellerCreator.GetPlayerCharacter(), story.ToString());
        }

        private static void GenerateCharacterWithPossibleName(TravellerNationalities nation, string name, Random random,
            CharacterCreatorService travellerCreator, StringBuilder story)
        {
            if (name == string.Empty || name == "" || name == null)
            {
                var names = new TravellerNameService()
                    .GetNames(1, TravellerNameService.GetNationalitiesNameList(nation));
                name = names[random.Next(names.Count)];

                ApplyName(name, travellerCreator, random, story);
            }
            else
            {
                ApplyName(name, travellerCreator, random, story);
            }
        }

        private static bool DoAnotherTerm(CharacterCreatorService travellerCreator, int CharactersAge, Random random)
        {
            var hardAdvance = travellerCreator.HardAdvanced;
            var travAge = travellerCreator.TravellersAge;
            var tooOld = travAge >= CharactersAge;
            var notToOld = !tooOld;
            var hasJobAndCanKeepWorking = travellerCreator.HasJob && notToOld;
            var shouldContinue = random.Next(0, 2) == 1;

            //If we are too old, do not keep going, unless we have to.
            if (tooOld && !hardAdvance) return false;
            //Otherwise we might advance
            return hardAdvance || hasJobAndCanKeepWorking || shouldContinue;
        }

        private static ComplexTravellerNPC GenerateCharacter()
        {
            var travellerCreator = new CharacterCreatorService();
            var story = new StringBuilder();
            var random = new Random();

            travellerCreator.NewCharacter();
            var CharactersAge = 18 + 4 * random.Next(1, 21);

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

                GenerateSkill(travellerCreator, random, story);
                story.AppendLine("");

                CreationEvent(travellerCreator, random, story);
                story.AppendLine("");

                if (travellerCreator.Mishapped) GetBenefits(travellerCreator, random, story);

                IncreaseAge(travellerCreator, random, story);
                story.AppendLine("");
            }
            //While the traveller has a job and is less then 100, or the traveller gets really unlucky and decides to drop out.
            while (travellerCreator.HardAdvanced ||
                   travellerCreator.HasJob && travellerCreator.TravellersAge < CharactersAge ||
                   random.Next(0, 2) == 1);
            //

            GetBenefits(travellerCreator, random, story);

            Console.ForegroundColor = ConsoleColor.Green;
            story.Insert(0, travellerCreator._character.ToString());
            Console.ForegroundColor = ConsoleColor.DarkGray;

            return new ComplexTravellerNPC(travellerCreator.GetPlayerCharacter(), story.ToString());
        }

        #endregion

        #region Benefits

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

                ApplyReward(creator, random, creator.GetBenefit(roll, cash), story);
            }
        }

        private static int GetBenefitModifier(CharacterCreatorService creator, Random random, int roll,
            StringBuilder story)
        {
            var modifier = random.Next(creator.BenefitRollModifiers.Count);
            if (roll + modifier < 1 || roll + modifier > 7) return GetBenefitModifier(creator, random, roll, story);

            return modifier;
        }

        private static void ApplyReward(CharacterCreatorService creator, Random random,
            TravellerCharacterCreationReward reward, StringBuilder story)
        {
            var itemStore = new TravellerItemStoreService();
            story.Append($"\n{creator.Name} gets the following reward: ");
            if (creator.ApplyReward(reward))
            {
                if (reward is TravellerRewardWeapon weapon)
                {
                    var weaponItem =
                        itemStore.WeaponStore.Select(x => x.Value).ToList()[
                            random.Next(0, itemStore.WeaponStore.Count)];
                    creator.ApplyReward(new TravellerRewardItem(new List<TravellerItem>
                    {
                        weaponItem
                    }));
                    story.Append($" new weapon! ({weaponItem.Name}) ");
                }
                else if (reward is TravellerRewardGun gun)
                {
                    var guns = itemStore.WeaponStore.Select(x => x.Value).Where(x => x.MagazineCapacity > 0).ToList();
                    var weaponItem =
                        guns[random.Next(0, guns.Count)];
                    creator.ApplyReward(new TravellerRewardItem(new List<TravellerItem>
                    {
                        weaponItem
                    }));
                    story.Append($" new gun! ({weaponItem.Name}) ");
                }
                else if (reward is TravellerRewardBlade blade)
                {
                    var blades = itemStore.WeaponStore.Select(x => x.Value).Where(x => x.MagazineCapacity == 0)
                        .ToList();
                    var weaponItem =
                        blades[random.Next(0, blades.Count)];
                    creator.ApplyReward(new TravellerRewardItem(new List<TravellerItem>
                    {
                        weaponItem
                    }));
                    story.Append($" new blade! ({weaponItem.Name}) ");
                }
                else if (reward is TravellerRewardArmour armour)
                {
                    var armourItem =
                        itemStore.ArmourStore.Select(x => x.Value).ToList()[
                            random.Next(0, itemStore.ArmourStore.Count)];
                    creator.ApplyReward(new TravellerRewardItem(new List<TravellerItem>
                    {
                        armourItem
                    }));
                    story.Append($" new armour! ({armourItem.Name}) ");
                }
                else if (reward is TravellerRewardAugment augment)
                {
                    var augmentItem =
                        itemStore.AugmentsStore.Select(x => x.Value).ToList()[
                            random.Next(0, itemStore.AugmentsStore.Count)];
                    creator.ApplyReward(new TravellerRewardItem(new List<TravellerItem>
                    {
                        augmentItem
                    }));
                    story.Append($" new augment! ({augmentItem.Name}) ");
                }
                else if (reward is TravellerRewardCombatImplant)
                {
                    var augmentItem =
                        itemStore.AugmentsStore.Select(x => x.Value).ToList()[
                            random.Next(0, itemStore.AugmentsStore.Count)];
                    creator.ApplyReward(new TravellerRewardItem(new List<TravellerItem>
                    {
                        augmentItem
                    }));
                    story.Append($" new combat implant! ({augmentItem.Name}) ");
                }
                else if (reward is TravellerRewardSkillChoice choice)
                {
                    var skill = choice.SkillList[random.Next(choice.SkillList.Count)];
                    story.Append($" the skill: {skill}");

                    ApplyReward(creator, random, new TravellerRewardSkill(skill), story);

                    if (choice.PickCount > 1)
                        ApplyReward(creator, random,
                            new TravellerRewardSkillChoice(choice.PickCount - 1, choice.SkillList), story);
                }
                else if (reward is TravellerRewardOther other)
                {
                    story.Append($"something else entirely: \"{other.Rewardtext}\"");
                }
                else if (reward is TravellerRewardLifeEvent lifeEvent)
                {
                    ApplyEvent(creator, random, creator.GetLifeEvent(creator.RollDice()), story);
                }
                else if (reward is TravellerRewardSkill skills)
                {
                    var newSkills = new List<TravellerSkill>();
                    foreach (var skill in skills.Skilllist)
                    {
                        if (skill.IsSuperSkill())
                        {
                            var sub = GetSubSkill(creator, random, skill.SkillName);
                            story.Append($" the skill: {sub}");
                            newSkills.Add(new TravellerSkill(sub, skill.SkillValue));
                        }
                        else
                        {
                            story.Append($" the skill: {skill.SkillName}");
                            newSkills.Add(skill);
                        }

                        ApplyReward(creator, random, new TravellerRewardSkill(newSkills), story);
                    }
                }
                else if (reward is TravellerRewardJobChange jobChange)
                {
                    var career = creator.GetCareer(jobChange.NewCareerName);
                    story.Append($" joining the {career.CareerName}, ");
                    GetAssignmentAndJoinCareer(creator, random, career, story);
                }
            }
            else
            {
                story.Append($" {reward}");
            }
        }

        #endregion

        #region Events

        private static void CreationEvent(CharacterCreatorService travellerCreator, Random random, StringBuilder story)
        {
            TravellerEventCharacterCreation creationEvent;
            if (travellerCreator.CheckSurvival(travellerCreator.RollDice()))
            {
                story.AppendLine($"{travellerCreator.Name} survives in their career.\n");
                creationEvent = GetEvent(travellerCreator);
                //Some events may impact advancement, better to use it twice in this case.
                ApplyEvent(travellerCreator, random, creationEvent, story);
                travellerCreator.GainBenefitForTerm();
                Advance(travellerCreator, random, story);
            }
            else
            {
                story.AppendLine($"{travellerCreator.Name} mishaps out of their career!\n");
                story.AppendLine();
                creationEvent = GetMishap(travellerCreator);
                ApplyEvent(travellerCreator, random, creationEvent, story);
            }
        }

        private static void ApplyEvent(CharacterCreatorService creator, Random random,
            TravellerEventCharacterCreation creationEvent, StringBuilder story)
        {
            story.Append($"{creationEvent.EventText.Replace("you", "they").Replace("You", "they")}. ");
            if (creationEvent is TravellerEventAttributeCheck attribute)
            {
                AttributeEvent(creator, random, attribute, story);
            }
            else if (creationEvent is TravellerEventChangeCareerWithAssignment changeWithAssignment)
            {
                var career = creator.GetCareer(changeWithAssignment.NewCareerName);
                var assignment = creator.GetAssignment(career, changeWithAssignment.Assignment);
                JoinCareerAndBasicTraining(creator, random, career, assignment, story);
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
                ApplyInjury(creator, random, injured.GetSevereInjury(creator.RollDice(1), creator.RollDice(1)), story);
            }
            else if (creationEvent is TravellerEventInjury injury)
            {
                ApplyInjury(creator, random, injury.GetInjury(creator.RollDice(1)), story);
            }
            else if (creationEvent is TravellerEventLife life)
            {
                ApplyEvent(creator, random, creator.GetLifeEvent(creator.RollDice()), story);
            }
            else if (creationEvent is TravellerEventMishap mishap)
            {
                ApplyEvent(creator, random, creator.GetMishap(creator.RollDice(1)), story);
            }
            else if (creationEvent is TravellerEventMultiChoice multi)
            {
                ApplyEvent(creator, random, multi.GetEvent(random.Next(0, multi.Events.Count)), story);
            }
            else if (creationEvent is TravellerEventReward rewards)
            {
                foreach (var reward in rewards.Reward) ApplyReward(creator, random, reward, story);
            }
            else if (creationEvent is TravellerEventText eventText)
            {
            }
        }

        private static void PreformASkillCheck(CharacterCreatorService creator, Random random,
            TravellerEventSkillCheck skillCheck, StringBuilder story)
        {
            var check = skillCheck.SkillChecks[random.Next(skillCheck.SkillChecks.Count)];
            story.Append(
                $" {creator.Name} chooses to approach the challenge with their {check.SkillToCheck.SkillName},");

            if (creator.PassSkillCheck(check, creator.RollDice()))
            {
                story.AppendLine(" and they are successful. ");
                if (skillCheck.HasYesEvent) ApplyEvent(creator, random, skillCheck.YesEvent, story);
            }
            else
            {
                story.AppendLine(" and they fail. ");
                if (skillCheck.HasNoEvent) ApplyEvent(creator, random, skillCheck.NoEvent, story);
            }
        }

        private static void ChoiceEvent(CharacterCreatorService creator, Random random,
            TravellerEventChoice choice, StringBuilder story)
        {
            if (random.Next(0, 2) != 1)
            {
                story.AppendLine($"{creator.Name} chooses {choice.YesText}. ");
                if (choice.HasYesEvent) ApplyEvent(creator, random, choice.YesEvent, story);
            }
            else
            {
                story.AppendLine($"{creator.Name} chooses {choice.NoText}.");
                if (choice.HasNoEvent) ApplyEvent(creator, random, choice.NoEvent, story);
            }
        }

        private static void AttributeEvent(CharacterCreatorService creator, Random random,
            TravellerEventAttributeCheck attribute, StringBuilder story)
        {
            if (attribute.AttributeChecks[0].PassedCheck(creator.RollDice()))
            {
                story.AppendLine($"{attribute.YesText}");
                if (attribute.HasYesEvent) ApplyEvent(creator, random, attribute.YesEvent, story);
            }
            else
            {
                story.AppendLine($"{attribute.NoText}");
                if (attribute.HasNoEvent) ApplyEvent(creator, random, attribute.NoEvent, story);
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

        #endregion

        #region Careers

        private static void FindCareer(CharacterCreatorService travellerCreator, Random random, StringBuilder story)
        {
            var career = GetCareer(travellerCreator, random, story);
            GetAssignmentAndJoinCareer(travellerCreator, random, career, story);
        }

        private static void GetAssignmentAndJoinCareer(CharacterCreatorService travellerCreator, Random random,
            TravellerCareer career, StringBuilder story)
        {
            var assignment = GetAssignment(travellerCreator, career, random, story);
            JoinCareerAndBasicTraining(travellerCreator, random, career, assignment, story);
        }

        private static void JoinCareerAndBasicTraining(CharacterCreatorService travellerCreator, Random random,
            TravellerCareer career,
            TravellerAssignment assignment, StringBuilder story)
        {
            story.Append($" {travellerCreator.Name} then joins the {career.CareerName} as a(n) {assignment.Name}.\n");
            travellerCreator.JoinCareer(career, assignment);
            BasicTraining(travellerCreator, career, random, story);
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
                GenerateSkill(creator, random, story);
            }
        }


        private static TravellerCareer GetCareer(CharacterCreatorService travellerCreator, Random random,
            StringBuilder story)
        {
            var careers = travellerCreator.GetTravellerCareers();
            var careerNumber = random.Next(0, careers.Count);
            var career = careers[careerNumber];

            story.AppendLine(
                $"{travellerCreator.Name} tries to join the {career.CareerName}, who describe themselves as: \"{career.CareerDescription}\"\n");

            if (!travellerCreator.CanEnterCareer(career.Qualifications[0], travellerCreator.RollDice()))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                story.Append("However, they were unable to!");
                Console.ForegroundColor = ConsoleColor.Gray;
                if (!travellerCreator.HasBeenDrafted)
                {
                    career = travellerCreator.GetDrafted(random.Next(0,
                        travellerCreator._character.Nationality.DraftTable.Length));
                    story.Append($" Then they were drafted into the {career.CareerName}\n");
                }
                else
                {
                    career = travellerCreator.GetDrifter();
                    story.Append(
                        $" They instead chose to become a drifter, and thus fell into a life of {career.CareerName}\n");
                }
            }

            return career;
        }

        public static TravellerAssignment GetAssignment(CharacterCreatorService creator, TravellerCareer career,
            Random random, StringBuilder story)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            var assignments = creator.GetAssignments(career);

            var assignment = assignments[random.Next(0, assignments.Count)];

            Console.ForegroundColor = ConsoleColor.Blue;
            story.AppendLine($"Within their career, {creator.Name} chooses to become a {assignment.Name}.");

            return assignment;
        }

        #endregion

        #region nationality

        private static void GenerateNationality(Random random, CharacterCreatorService travellerCreator,
            StringBuilder story)
        {
            var nationService = new TravellerNationsCharacterInfoService();
            var nations = nationService.GetNationsList;
            var nationality = nations.ElementAt(random.Next(0, nations.Count));

            var nation = ApplyNationality(nationality, random, travellerCreator, nationService, story);
        }

        private static TravellerNationsCharacterInfo ApplyNationality(TravellerNationsCharacterInfo nationality,
            Random random,
            CharacterCreatorService travellerCreator, TravellerNationsCharacterInfoService nationService,
            StringBuilder story)
        {
            story.AppendLine($"{nationality}. ");

            if (travellerCreator.NationHasEntryRequirements(nationality))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                story.Append("They tried to stay in, ");
                if (!travellerCreator.CanEnterNationality(nationality, nationality.EntryRequirements[0],
                    travellerCreator.RollDice()))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    story.Append("but they failed to do so.\n");
                    nationality = nationService.GetTravellerNationsCharacterInfos()
                        .First(x => x.Nationality == nationality.ParentNation);
                }
                else
                {
                    story.Append("and they were successful in it.\n");
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Gray;
            travellerCreator.ApplyNationality(nationality);

            GetBackgroundSkills(travellerCreator, nationality, random, story);

            return nationality;
        }

        #endregion

        #region Aging

        private static void IncreaseAge(CharacterCreatorService creator, Random random, StringBuilder story)
        {
            if (creator.ApplyAging())
            {
                var roll = creator.RollDice();
                if (creator.HasAgingEffect(roll))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    story.Append("\nAs they grow older, aging has an effect! ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    var injury = creator.AgingRoll(roll);
                    ApplyInjury(creator, random, injury, story);
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            story.Append($"\n{creator.Name} is now {creator.TravellersAge} years old.\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void ApplyInjuries(CharacterCreatorService creator, Random random, TravellerInjury injury,
            StringBuilder story)
        {
            if (injury is TravellerMultiInjury multi)
                foreach (var singleInjury in multi.Injuries)
                    ApplyInjury(creator, random, singleInjury, story);
        }

        private static void ApplyInjury(CharacterCreatorService creator, Random random, TravellerInjury injury,
            StringBuilder story)
        {
            if (injury is TravellerMultiInjuryChoice choice)
            {
                ApplyInjury(creator, random, choice.GetInjury(random.Next(choice.InjuryCount)), story);
                return;
            }

            if (injury is TravellerMultiInjury)
            {
                ApplyInjuries(creator, random, injury, story);
                return;
            }

            var statsEffected = creator.GetEffectedAttributes(injury);
            var stat = statsEffected[random.Next(statsEffected.Count)];

            Console.ForegroundColor = ConsoleColor.Red;
            story.Append($"{creator.Name} has been injured! ");
            Console.ForegroundColor = ConsoleColor.Gray;
            story.Append($"They suffer {injury.InjuryDescription}.\n");
            if (!creator.ApplyTravellerInjury(injury, stat))
            {
                var amountToRepair = random.Next(1, 5);
                var repairCost = creator.RollDice(1);
                Console.ForegroundColor = ConsoleColor.Red;
                story.Append(
                    $"{creator.Name} nearly died!\nTheir damage was repaired costing: {repairCost * creator.AgingCrisisCost * amountToRepair}\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                creator.RepairAttribute(amountToRepair, repairCost, stat);
            }
            else
            {
                story.Append("Thankfully, it was not fatal... yet.\n");
            }
        }

        #endregion

        #region Skill Tables

        private static List<TravellerSkillTableEntry> GetSkillTable(CharacterCreatorService creator, Random random,
            StringBuilder story)
        {
            var skillTables = creator.GetSkillTables();
            var table = skillTables.ElementAt(random.Next(0, skillTables.Count));
            Console.ForegroundColor = ConsoleColor.Yellow;
            story.Append($"{creator.Name} spent the term practicing their {table.Item1}");
            Console.ForegroundColor = ConsoleColor.Gray;

            return table.Item2;
        }

        private static void GenerateSkill(CharacterCreatorService creator, Random random, StringBuilder story)
        {
            var table = GetSkillTable(creator, random, story);
            var skill = table[creator.RollOnSkillTable()];

            skill = GetSubSkill(creator, random, skill);

            Console.ForegroundColor = ConsoleColor.Green;
            story.Append($" during which they gained particular experience in the: {skill} skill.\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            creator.ApplySkillTableResult(skill);
        }

        private static TravellerSkillTableEntry GetSubSkill(CharacterCreatorService creator, Random random,
            TravellerSkillTableEntry skill)
        {
            if (creator.IsSkill(skill) && creator.IsSuperSkill(skill))
            {
                var subSkills = creator.GetSubSkills(((TravellerSkillTableEntrySkill)skill).Skill);
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
                story.Append("In their career, they get basic training, ");
                if (!travellerCreator.HasHadJob)
                {
                    story.Append("and it is their first basic training!\nIn this time they learn: ");
                    for (var i = 0; i < career.ServiceSkillsList.Count; i++)
                    {
                        var skill = career.ServiceSkillsList[i];
                        if (i == career.ServiceSkillsList.Count - 1)
                            story.Append($"and {skill}.\n");

                        else
                            story.Append($"{skill}, ");
                    }

                    travellerCreator.ApplyFirstBasicTraining(career);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    var skill = career.ServiceSkillsList[random.Next(0, career.ServiceSkillsList.Count)];
                    travellerCreator.ApplyRegularBasicTraining(skill);

                    story.Append($"its a normal basic training, they learn {skill.Name}\n");
                }
            }
        }

        private static void GetBackgroundSkills(CharacterCreatorService travellerCreator,
            TravellerNationsCharacterInfo nation,
            Random random, StringBuilder story)
        {
            var backgroundSkillList = travellerCreator.GetBackgoundSkills(nation);
            var backgroundSkills = new List<TravellerSkill>();

            story.Append($"While growing up, {travellerCreator.Name} learned: ");

            for (var i = 0; i < travellerCreator.NumberOfTravellerBackgroundSKills; i++)
            {
                var skill = backgroundSkillList[random.Next(0, backgroundSkillList.Count)];
                backgroundSkills.Add(skill);
                if (i == travellerCreator.NumberOfTravellerBackgroundSKills - 1)
                    story.Append($"and {skill}.\n\n");
                else
                    story.Append($"{skill}, ");
            }

            travellerCreator.ApplyBackgroundSkills(backgroundSkills);
        }

        #endregion

        #region Generate basic values

        private static void GenerateName(CharacterCreatorService travellerCreator, Random random
            , StringBuilder story)
        {
            var names = new TravellerNameService()
                .GetNames(1, TravellerNameService.NationNameList.Any);
            var name = names[random.Next(names.Count)];

            ApplyName(name, travellerCreator, random, story);
        }

        private static void ApplyName(string name, CharacterCreatorService travellerCreator,
            Random random, StringBuilder story)
        {
            story.Append($"By the time {name} turned 18, ");

            travellerCreator.SetName(name);
        }

        private static void GenerateValues(CharacterCreatorService travellerCreator, StringBuilder story,
            bool usePsi = false)
        {
            var stats = travellerCreator.GenerateStats(usePsi);

            var attributes = Enum.GetValues(typeof(TravellerAttributes));

            for (var i = 0; i < stats.Count; i++)
                travellerCreator.AssignStat(new TravellerAttribute((TravellerAttributes)attributes.GetValue(i),
                    stats[i]));

            for (var i = 0; i < travellerCreator._character.AttributeList.Count; i++)
            {
                var stat = travellerCreator._character.AttributeList[i];
                //If its the last one do something special
                if (i == travellerCreator._character.AttributeList.Count - 1)
                    story.Append($"and their {stat.AttributeName} was {stat.ToNicelyPutAttribute()}. ");
                else
                    story.Append($"their {stat.AttributeName} was {stat.ToNicelyPutAttribute()}, ");
            }

            story.Append($"\n\n {travellerCreator.Name} was born into the ");
        }

        #endregion
    }
}