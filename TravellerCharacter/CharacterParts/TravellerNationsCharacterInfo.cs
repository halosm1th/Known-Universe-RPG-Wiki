﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellerCharacter.Character_Services.Career_Service;
using TravellerCharacter.CharacterCreator;
using TravellerCharacter.CharacterCreator.Careers;
using TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward;
using TravellerCharacter.CharcterTypes;

namespace TravellerCharacter.CharacterParts
{
    public class TravellerNationsCharacterInfo
    {
        private readonly List<TravellerCareer> careerList = new TravellerCareerService().GetCareers();

        public TravellerNationsCharacterInfo(string name, TravellerNationalities nationality, string backgroundText,
            List<(TravellerAttributes Stat, int ChangeBy)> statChanges,
            List<TravellerCharacterCreationReward> perks,
            Dictionary<int, TravellerSkill> backgroundSkills,
            TravellerNationalities parentNation, string drifter,
            string[] drafts)
        {
            NationName = name;
            BackgroundText = backgroundText;
            StatChanges = statChanges;
            Perks = perks;
            BackgroundSkills = backgroundSkills;
            EntryRequirements = new List<TravellerAttributeCheck>();
            _draftText = drafts;
            _drifterText = drifter;
            ParentNation = parentNation;
            NationsCareers = new List<TravellerCareer>();
            NationsCareers.AddRange(careerList.Where(x => x.Nationality == ParentNation));
            //TODO set the nations careers
            NationsCareers.AddRange(careerList.Where(x => x.Nationality == nationality).ToList());
            Nationality = nationality;
        }

        public TravellerNationsCharacterInfo(string name, TravellerNationalities nationality, string backgroundText,
            List<(TravellerAttributes Stat, int ChangeBy)> statChanges,
            List<TravellerCharacterCreationReward> perks,
            Dictionary<int, TravellerSkill> backgroundSkills,
            List<TravellerAttributeCheck> entryRequirements,
            TravellerNationalities parentNation, string drifter,
            string[] drafts)
        {
            NationName = name;
            BackgroundText = backgroundText;
            StatChanges = statChanges;
            Perks = perks;
            BackgroundSkills = backgroundSkills;
            EntryRequirements = entryRequirements;
            _draftText = drafts;
            _drifterText = drifter;
            ParentNation = parentNation;
            NationsCareers = new List<TravellerCareer>();
            //TODO set the nations careers
            NationsCareers.AddRange(careerList.Where(x => x.Nationality == nationality).ToList());
            NationsCareers.AddRange(careerList.Where(x => x.Nationality == ParentNation));
            Nationality = nationality;
        }

        public TravellerNationsCharacterInfo(string name, TravellerNationalities nationality, string backgroundText,
            List<(TravellerAttributes Stat, int ChangeBy)> statChanges,
            List<TravellerCharacterCreationReward> perks,
            Dictionary<int, TravellerSkill> backgroundSkills,
            List<TravellerAttributeCheck> entryRequirements, string drifter,
            string[] drafts)
        {
            NationName = name;
            BackgroundText = backgroundText;
            StatChanges = statChanges;
            Perks = perks;
            BackgroundSkills = backgroundSkills;
            EntryRequirements = entryRequirements;
            _draftText = drafts;
            _drifterText = drifter;
            ParentNation = nationality;
            NationsCareers = new List<TravellerCareer>();
            //TODO set the nations careers
            NationsCareers.AddRange(careerList.Where(x => x.Nationality == nationality).ToList());
            Nationality = nationality;
        }

        public TravellerNationsCharacterInfo(string name, TravellerNationalities nationality, string backgroundText,
            List<(TravellerAttributes Stat, int ChangeBy)> statChanges,
            List<TravellerCharacterCreationReward> perks,
            Dictionary<int, TravellerSkill> backgroundSkills, string drifter,
            string[] drafts)
        {
            NationName = name;
            ParentNation = nationality;
            BackgroundText = backgroundText;
            StatChanges = statChanges;
            Perks = perks;
            BackgroundSkills = backgroundSkills;
            EntryRequirements = new List<TravellerAttributeCheck>();
            NationsCareers = new List<TravellerCareer>();
            NationsCareers.AddRange(careerList.Where(x => x.Nationality == nationality));
            _draftText = drafts;
            _drifterText = drifter;
            Nationality = nationality;

            //TODO set the nations careers
        }

        public TravellerNationsCharacterInfo()
        {
            NationName = "Error";
            BackgroundText = "Error";
            StatChanges = new List<(TravellerAttributes Stat, int ChangeBy)>();
            Perks = new List<TravellerCharacterCreationReward>();
            BackgroundSkills = new Dictionary<int, TravellerSkill>();
            EntryRequirements = new List<TravellerAttributeCheck>();
            ParentNation = Nationality;
        }

        public string NationName { get; set; }
        public TravellerNationalities Nationality { get; }
        public string HTMLName => NationName.Replace(" ", "_");
        public string BackgroundText { get; set; }
        public List<(TravellerAttributes Stat, int ChangeBy)> StatChanges { get; set; }
        public List<TravellerCharacterCreationReward> Perks { get; set; }
        public Dictionary<int, TravellerSkill> BackgroundSkills { get; set; }
        public List<TravellerAttributeCheck> EntryRequirements { get; set; }
        public bool NationHasEntryRequirements => EntryRequirements.Count > 0;
        public TravellerCareer DrifterCareer => GetJob(_drifterText);
        private string _drifterText { get; }
        public TravellerCareer[] DraftTable => _draftText == null ? null : GetJobs(_draftText.ToList()).ToArray();
        private string[] _draftText { get; }

        public TravellerNationalities ParentNation { get; set; }
        public List<TravellerCareer> NationsCareers { get; set; }


        public List<TravellerCareer> GetJobs(List<string> jobs)
        {
            var careers = new List<TravellerCareer>();
            foreach (var job in jobs)
                if (NationsCareers.Any(x => x.CareerName == job))
                    careers.Add(NationsCareers.First(x => x.CareerName == job));

            return careers;
        }

        public TravellerCareer GetJob(string jobName = "")
        {
            return NationsCareers != null ? NationsCareers.First(x => x.CareerName.Equals(jobName)) : null;
        }

        public string GetStatChanges()
        {
            var sb = new StringBuilder();
            foreach (var change in StatChanges)
            {
                sb.Append(change.Stat);
                sb.Append(":");
                sb.Append(change.ChangeBy);

                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }

        public override string ToString()
        {
            return NationName;
        }
    }
}