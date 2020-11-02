using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravellerWiki.Data
{
    public class TravellerJobBoardService
    {
        public static int Updates = 0;
        public static readonly int MAX_UPDATES_BEFORE_SAVE = 5;
        public static List<TravellerJobBoardJob> ListOfJobs = LoadListOfJobs();


        private static bool _loadedFile = false;
        private static List<TravellerJobBoardJob> _jobs;
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

        public List<TravellerJobBoardJob> GetJobBoardJobs => ListOfJobs;
    }
}
