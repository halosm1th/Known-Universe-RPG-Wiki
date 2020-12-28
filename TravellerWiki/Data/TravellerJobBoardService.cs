using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBoardCreator;
using Newtonsoft.Json;
using TravellerWiki.Pages.Generators;

namespace TravellerWiki.Data
{
    public class TravellerJobBoardService
    {
        public static int Updates = 0;
        public static readonly int MAX_UPDATES_BEFORE_SAVE = 5;
        public static List<TravellerJobBoardJob> ListOfJobs = LoadListOfJobs();
        public static List<TravellerJobBoardJob> ListOfNonTASJobs = GenerateNonTASJobs();


        private static bool _loadedFile = false;
        private static List<TravellerJobBoardJob> _jobs;
        private static List<TravellerJobBoardJob> _NonTASJobs;
        public static List<TravellerJobBoardJob> LoadListOfJobs()
        {
            if (!_loadedFile)
            {

                var file = File.ReadAllText(Directory.GetCurrentDirectory() + "/JobOffers.json");
                var convertedFile = JsonConvert.DeserializeObject<List<TravellerJobBoardJob>>(file);
                _loadedFile = true;
                _jobs = convertedFile;
            }

            return _jobs;
        }

        public static List<TravellerJobBoardJob> GenerateNonTASJobs()
        {
            if (_NonTASJobs == null || _NonTASJobs.Count <= 0)
            {
                var missionGenerator = new TravellerMissionGeneratorService();
                var rand = new System.Random();
                var sb = new StringBuilder();

                _NonTASJobs = new List<TravellerJobBoardJob>();
                for (int i = 0; i < 100; i++)
                {
                    var mission = missionGenerator.GenerateTravellerMission();
                    sb.Append(rand.Next(1, 9));
                    sb.Append(",");
                    sb.Append(rand.Next(1, 11));
                    sb.Append(":");
                    sb.Append(rand.Next(1, 5));
                    sb.Append("'");
                    sb.Append(rand.Next(1, 5));
                    var senderLoc = sb.ToString();
                    sb.Clear();

                    sb.Append("A Job - ");
                    sb.Append(mission.Mission);
                    var title = sb.ToString();
                    sb.Clear();

                    _NonTASJobs.Add(new TravellerJobBoardJob()
                    {
                        Ally = mission.Ally,
                        Enemy = mission.Enemy,
                        ExpiryDate = GetDate(35,rand),
                        IssuedOnDate = GetDate(5,rand),
                        JobBoardOfferedOn = "Word of Mouth",
                        JobDescription = rand.Next(1000,9999).ToString(),
                        JobPayment = rand.Next(2000, 250001),
                        JobTitle = title,
                        MaxAccepts = rand.Next(10, 1001),
                        NumberOfAccepted = rand.Next(1, 11),
                        NumberOfActive = rand.Next(0, 6),
                        Mission = mission.Mission,
                        Target = mission.Target,
                        TargetQuirk = mission.TargetQuirk,
                        Patron = mission.Patron,
                        PatronQuirk = mission.PatronQuirk,
                        Opposition = mission.Opposition,
                        
                        SenderLocation = senderLoc,
                        SenderName = "Mr. Who",
                        Visible = true,

                    });
                }
            }

            return _NonTASJobs;
        }

        private static string GetDate(int yearMod, Random rand)
        {
            var day = rand.Next(1, 32);
            var month = rand.Next(1, 13);
            var year = 83385+ rand.Next(0, yearMod);
            var sb = new StringBuilder();

            sb.Append(day);
            sb.Append("/");
            sb.Append(month);
            sb.Append("/");
            sb.Append(year);
            return sb.ToString();
        }

        public List<TravellerJobBoardJob> GetNonTASJobs(int count)
        {
            if (count == -1)
            {
                return ListOfNonTASJobs;
            }
            else
            {
                var retJobs = new List<TravellerJobBoardJob>();
                var random = new Random();
                for (int i = 0; i < count; i++)
                {
                    var job = ListOfNonTASJobs.ElementAt(random.Next(0, ListOfNonTASJobs.Count));
                    retJobs.Add(job);
                }

                return retJobs;
            }
        }

        public List<TravellerJobBoardJob> GetJobBoardJobs => ListOfJobs;
    }
}
