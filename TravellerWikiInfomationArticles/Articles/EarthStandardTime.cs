using System.Collections.Generic;

namespace TravellerWikiInfomationArticles.Articles
{
    class EarthStandardTime
    {
        public static InformationArticle GetArticle() =>
            new InformationArticle(
                "Earth Standard Time",
                $"Earth Standard Time is the Universal Standard Time as declared by the [Universalis Confederation]({WikiInformationArticles.GetArticleLinkIDByName("Univeraslis Confederation")}) though it had been the defacto standard for starships and computers since as early as the second millennium. Earth Standard time is based out of Winnipeg, Canada. UTC-05:00.",
                new List<InformationSection>()
                {
                    new InformationSection("History", new List<string>()
                    {
                        "Earth Standard time was officially declared the new UTC when the United Federation of Earth declared the Standardizations Act law. In order to keep compatibility with old hardware, as well as with Federation technology, the other nations often ran their computers on the Earth 24 hour clock. This made the standard military clock for most nations to be based on the 24 hour clock as opposed to the national clock. When the Universalis Confederation was formed, it was decided that due to its near ubiquity, Earth Standard Time would be the standard."
                    }),
                    new InformationSection("Location format", new List<string>()
                    {
                        "In order to make the Universe easier to map, a standard was also formed to denote location within Galaxies. Due ot time differentials between locations, it has become customary to append the location to a datetime in most locations."
                    }),
                    new InformationSection("Time Format", new List<string>()
                    {
                        "The time format is broken down as so: Millennium-Century:Month-Day:Hour:Min-Second:Milisecond. expressed in the format of either: 083390-04-24T15:29-06:13 or in the short form of: DD/MM/YYYYY"
                    }),
                    new InformationSection("Location Format", new List<string>()
                    {
                        "A galaxy is composed of 4 quadrants, each quadrants has around 3 by 3 mega sectors. Each mega sector is 8 by 8 super Sectors. Each super sector is 6 by 6 sectors, where each sector is 4 by 4 subsectors, and each subsector is 8 by 10 parsecs large.",
                        "Location is as follows: SYSTEM_X,SYSTEM_Y:SUBSECTOR_X'SUBSECTOR_Y;SECTOR_X,_SECTOR_Y:SUPERSECTOR_X'SUPERSECTOR_Y|MEGASECTOR_X,MEGASECTOR_Y:QUADRANT_X,QUADRANT_Y.GALAXY",
                        "By convention, the last value of the location is the proper name of the location. For example a single system would be: .Fosterville. With a period denoting that it is the highest level of discussion. But if we wanted to identify it within its super sector we would write: 1,7:3'1.Western_Islands"
                        ,"The full form would be: 1,7:3'1;1,1:5,4|4,3:1,2.Berlinnic"
                    }),
                    new InformationSection("Full Format", new List<string>()
                    {
                        "The full format is as such: 083390-04-24T15:29-06:13^1,7:3'1;1,1:5,4|4,3:1,2.Berlinnic to denote the date of April 24th, 83390 at just shy of 3:30pm, in the Fosterville System of the Doland Subsector within the North Western Islands Sector of the Ishtar Coriptium Super Sector, inside the Mundel Megasector in the third Quadrant of the Berlinnic Galaxy."
                    }),
                    new InformationSection("", new List<string>()
                        {}),
                    new InformationSection("", new List<string>()
                        {}),
                });
    }
}