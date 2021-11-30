using System;
using System.Collections.Generic;
using System.Linq;
using TravellerCharacter.CharacterCreator.Careers;
using TravellerCharacter.CharcterTypes;

namespace TravellerCharacter.Character_Services.Career_Service
{
    public class TravellerCareerService
    {
        public static List<TravellerCareer> StaticListOfCareers = LoadListOfJobs();

        private static List<TravellerCareer> _careers = new();
        public List<TravellerCareer> ListOfCareers = LoadListOfJobs();

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
            return ListOfCareers.Where(x => x.Nationality == nationality).ToList();
        }

        public List<TravellerCareer> GetCareers()
        {
            return ListOfCareers;
        }
    }
}