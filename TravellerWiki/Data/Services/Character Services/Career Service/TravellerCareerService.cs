using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravellerWiki.Data.Services.CareerService
{
    public enum TravellerNationalities
    {
        Universalis_Confederation,
        Wicher, 
        United_Federation_of_Earth_and_her_Colonies_Among_the_Stars,
        Luna_Knights,
        Fifth_Vers_Empire,
        Equites_Ordinis_deorum,
        United_Reverse_Lords,
        Xiao_Ming_Mega_Corporation,
        Communist_Empire_of_the_Deutschland,
        Church_of_Sigmar,
        Germushian_Free_Republic,
        Polandskia_Peoples_Union,
        Trans_Galactic_Empire,
        Sith,
        First_Order,
        The_Kingdom_of_Britannia,
        Imperial_Versian_Federated_Territories,
        Axion_Alliance,
        Artekkan_Guilds
    }

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