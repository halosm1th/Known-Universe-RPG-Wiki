using System;
using System.Collections.Generic;
using TravellerCharacter.Character_Services.Career_Service.Polandskian_Careers;
using TravellerCharacter.CharacterCreator.Careers;

namespace TravellerCharacter.Character_Services.Career_Service
{
    internal class TravellerMinorPowerCareers : TravellerCareerServiceCareer
    {
        public void AddMinorPowers(List<TravellerCareer> careers)
        {
            AddArtekkanCareer(careers);
            Console.WriteLine("Add Polandskia");
            TravellerPolandskianCareers.AddPolandskianCareers(careers);
            AddFirstOrderCareer(careers);
            AddBritanniaCareer(careers);
            AddIVFTCareer(careers);
        }

        private static void AddArtekkanCareer(List<TravellerCareer> careers)
        {
        }

        private static void AddFirstOrderCareer(List<TravellerCareer> careers)
        {
        }

        private static void AddBritanniaCareer(List<TravellerCareer> careers)
        {
        }

        private static void AddIVFTCareer(List<TravellerCareer> careers)
        {
        }
    }
}