using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravellerWiki.Data.Services.CareerService
{
    public class TravellerCareerService
    {

        public static List<TravellerCareer> StaticListOfCareers = LoadListOfJobs();
        public List<TravellerCareer> ListOfCareers = LoadListOfJobs();

        private static List<TravellerCareer> _careers = new List<TravellerCareer>();
        public static List<TravellerCareer> LoadListOfJobs()
        {
            Console.WriteLine("Adding Careers");
            if (_careers == null || _careers.Count == 0)
            {
                Console.WriteLine("Load Major Powers");
                var majorPowers = new TravellerMajorPowerCareers();

                Console.WriteLine("Loading Middle Powers");
                var middlePowers = new TravellerMiddlePowerCareers();

                Console.WriteLine("Loading Minor Powers");
                var minorPowers = new TravellerMinorPowerCareers();

                _careers = new List<TravellerCareer>();
                //TODO uncomment these as they are added and won't crash shit!
                majorPowers.AddMajorPowerCareers(_careers);
                //middlePowers.AddMiddlePowerCareers(_careers);
                minorPowers.AddMinorPowers(_careers);

            }

            return _careers;
        }

        public TravellerCareer GetCareer(string careerName)
        {
            return ListOfCareers.First(x => x.CareerName == careerName);
        }

        public List<TravellerCareer> GetCareers(TravellerNationalities nationality)
        {
            return ListOfCareers.Where(x => x.Nationality==nationality).ToList();
        }
        public List<TravellerCareer> GetCareers()
        {
            return ListOfCareers;
        }
    }
}