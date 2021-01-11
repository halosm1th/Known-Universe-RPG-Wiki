using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravellerWiki.Data
{
    public class TravellerCareerService
    {

        public static int Updates = 0;
        public static readonly int MAX_UPDATES_BEFORE_SAVE = 5;
        public static List<TravellerCareer> ListOfCareers = LoadListOfJobs();


        private static bool _loadedFile = false;
        private static List<TravellerCareer> _careers;
        public static List<TravellerCareer> LoadListOfJobs()
        {
            if (!_loadedFile)
            {

                var file = File.ReadAllText(Directory.GetCurrentDirectory() + "/Careers.json");
                var convertedFile = JsonConvert.DeserializeObject<List<TravellerCareerJson>>(file);

                _loadedFile = true;
                _careers = convertedFile.Select(career => career.CreateCareerFromJson()).ToList();
            }

            return _careers;
        }

        public List<TravellerCareer> GetCareers => ListOfCareers;
    }
}
