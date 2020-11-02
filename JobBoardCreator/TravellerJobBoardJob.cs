using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravellerWiki.Data
{
    public class TravellerJobBoardJob
    {
        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }

        [JsonProperty("jobDescription")]
        public string JobDescription { get; set; }

        [JsonProperty("jobPayment")]
        public int JobPayment { get; set; }

        [JsonProperty("numberOfAccepted")]
        public int NumberOfAccepted { get; set; }

        [JsonProperty("numberOfActive")]
        public int NumberOfActive { get; set; }

        [JsonProperty("numberOfMaxAccepts")]
        public int MaxAccepts { get; set; }

        [JsonProperty("visivle")]
        public bool Visible { get; set; }


        [JsonProperty("senderName")]
        public string SenderName { get; set; }
        [JsonProperty("senderLocation")]
        public string SenderLocation { get; set; }
        [JsonProperty("boardOfferedOn")]
        public string JobBoardOfferedOn { get; set; }
        [JsonProperty("expiryDate")]
        public string ExpiryDate { get; set; }
        [JsonProperty("IssuingDate")]
        public string IssuedOnDate { get; set; }
        
        [JsonProperty("Mission")]
        public string Mission { get; set; }

        [JsonProperty("Patron")]
        public string Patron { get; set; }

        [JsonProperty("Target")]
        public string Target { get; set; }

        [JsonProperty("Opposition")]
        public string Opposition { get; set; }
        
        [JsonProperty("PatronQuirk")]
        public string PatronQuirk { get; set; }

        [JsonProperty("TargetQuirk")]
        public string TargetQuirk { get; set; }

        [JsonProperty("Ally")]
        public string Ally { get; set; }
        [JsonProperty("Enemy")]
        public string Enemy { get; set; }

        public TravellerJobBoardJob(string jobTitle, string jobDescription, int jobPayment, int numberOfAccepted, int numberOfActive, int maxAccepts, bool visible, string senderName, string senderLocation, string jobBoardOfferedOn, string expiryDate, string issuedOnDate, string mission, string patron, string target, string opposition, string patronQuirk, string targetQuirk, string ally, string enemy)
        {
            JobTitle = jobTitle;
            JobDescription = jobDescription;
            JobPayment = jobPayment;
            NumberOfAccepted = numberOfAccepted;
            NumberOfActive = numberOfActive;
            MaxAccepts = maxAccepts;
            Visible = visible;
            SenderName = senderName;
            SenderLocation = senderLocation;
            JobBoardOfferedOn = jobBoardOfferedOn;
            ExpiryDate = expiryDate;
            IssuedOnDate = issuedOnDate;
            Mission = mission;
            Patron = patron;
            Target = target;
            Opposition = opposition;
            PatronQuirk = patronQuirk;
            TargetQuirk = targetQuirk;
            Ally = ally;
            Enemy = enemy;
        }
    }
}
