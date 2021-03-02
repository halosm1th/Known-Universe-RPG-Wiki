﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public class TravellerNationsCharacterInfo
    {
        public string NationName { get; set; }
        public string BackgroundText { get; set; }
        public List<(TravellerAttributes Stat, int ChangeBy)> StatChanges { get; set; }
        public List<TravellerCharacterCreationReward> Perks { get; set; }
        public Dictionary<int,TravellerSkill> BackgroundSkills { get; set; }
        public List<TravellerAttributeCheck> EntryRequirements { get; set; }
        public TravellerCareer DrifterCareer { get; set; }
        public TravellerCareer[] DraftTable { get; set; }
        public string ParentNation { get; set; }
        public List<TravellerCareer> NationsCareers { get; set; }
        
        private readonly List<TravellerCareer> careerList = new TravellerCareerService().GetCareers();
        
        public TravellerNationsCharacterInfo(string name, string backgroundText, 
            List<(TravellerAttributes Stat, int ChangeBy)> statChanges, 
            List<TravellerCharacterCreationReward> perks, 
            Dictionary<int, TravellerSkill> backgroundSkills, 
            string parentNation, string drifter,
            string[] drafts )
        {
            NationName = name;
            BackgroundText = backgroundText;
            StatChanges = statChanges;
            Perks = perks;
            BackgroundSkills = backgroundSkills;
            EntryRequirements = new List<TravellerAttributeCheck>();
            //DrifterCareer =  GetJob(drifter);
            //DraftTable = GetJobs(drafts.ToList()).ToArray();
            ParentNation = parentNation;
            //TODO set the nations careers
            //NationsCareers = careerList.Where(x => x.Nationality.NationName == name).ToList();
        }
        public TravellerNationsCharacterInfo(string name, string backgroundText,
            List<(TravellerAttributes Stat, int ChangeBy)> statChanges,
            List<TravellerCharacterCreationReward> perks,
            Dictionary<int, TravellerSkill> backgroundSkills,
            List<TravellerAttributeCheck> entryRequirements,
            string parentNation, string drifter,
            string[] drafts)
        {
            NationName = name;
            BackgroundText = backgroundText;
            StatChanges = statChanges;
            Perks = perks;
            BackgroundSkills = backgroundSkills;
            EntryRequirements = entryRequirements;
            //DrifterCareer = GetJob(drifter);
            //DraftTable = GetJobs(drafts.ToList()).ToArray();
            ParentNation = parentNation;
            //TODO set the nations careers
            //NationsCareers = careerList.Where(x => x.Nationality.NationName == name).ToList();
        }

        public TravellerNationsCharacterInfo(string name, string backgroundText,
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
            //DrifterCareer = GetJob(drifter);
            //DraftTable = GetJobs(drafts.ToList()).ToArray();
            ParentNation = null;
            //TODO set the nations careers
            //NationsCareers = careerList.Where(x => x.Nationality.NationName == name).ToList();
        }

        public TravellerNationsCharacterInfo(string name, string backgroundText,
            List<(TravellerAttributes Stat, int ChangeBy)> statChanges,
            List<TravellerCharacterCreationReward> perks,
            Dictionary<int, TravellerSkill> backgroundSkills, string drifter,
            string[] drafts)
        {
            NationName = name;
            BackgroundText = backgroundText;
            StatChanges = statChanges;
            Perks = perks;
            BackgroundSkills = backgroundSkills;
            EntryRequirements = new List<TravellerAttributeCheck>();
            //DrifterCareer = GetJob(drifter);
            ///DraftTable = GetJobs(drafts.ToList()).ToArray();
            ParentNation = null;
            //TODO set the nations careers
            NationsCareers = new List<TravellerCareer>();
            foreach (var career in careerList)
            {
                if (career.Nationality == name)
                {
                    NationsCareers.Add(career);
                }
            }
            NationsCareers.AddRange(careerList.Where(x => x.Nationality == name));
        }

        

        public List<TravellerCareer> GetJobs(List<string> jobs)
        {
            var careers = new List<TravellerCareer>();
            foreach (var job in jobs)
            {
                careers.Add(NationsCareers.First(x => x.CareerName == job));
            }

            return careers;
        }

        public TravellerCareer GetJob(string jobName) => 
            NationsCareers.First(x => x.CareerName == jobName);

        public TravellerNationsCharacterInfo()
        {
            NationName = "Error";
            BackgroundText = "Error";
            StatChanges = new List<(TravellerAttributes Stat, int ChangeBy)>( );
            Perks = new List<TravellerCharacterCreationReward>();
            BackgroundSkills = new Dictionary<int, TravellerSkill>();
            EntryRequirements = new List<TravellerAttributeCheck>();
            ParentNation = null;
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