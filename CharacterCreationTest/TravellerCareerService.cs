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

        public List<TravellerCareer> ListOfCareers = LoadListOfJobs();

        private static List<TravellerCareer> _careers;
        public static List<TravellerCareer> LoadListOfJobs()
        {
            var majorPowers = new TravellerMajorPowerCareers();
            var middlePowers = new TravellerMiddlePowerCareers();
            var minorPowers = new TravellerMinorPowerCareers();

            _careers = new List<TravellerCareer>();
            //TODO uncomment these as they are added and won't crash shit!
            majorPowers.AddMajorPowerCareers(_careers);
            //middlePowers.AddMiddlePowerCareers(_careers);
            //minorPowers.AddMinorPowers(_careers);


            return _careers;
        }

        public TravellerCareer GetCareer(string careerName)
        {
            return ListOfCareers.First(x => x.CareerName == careerName);
        }

        public List<TravellerCareer> GetCareers()
        {
            return ListOfCareers;
        }
    }
}
