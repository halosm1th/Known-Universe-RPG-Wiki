using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellerUniverse
{
    class Sector
    {
        private Subsector[,] subsectors;
        public string Name;

        public long WorldCount => subsectors.Cast<Subsector>().Sum(sub => sub.WorldCount);

        public Sector()
        {
            subsectors = new Subsector[4,4];
            Name = Subsector.GenerateName();
        }

        public Sector(string name, List<string>[,] subsectorCodes)
        {
            subsectors = new Subsector[4,4];
            Name = name;
            for (int y = 0; y < 4; y++)
            {
                for(int x =0; x < 4; x++)
                {
                    subsectors[x,y] = new Subsector(subsectorCodes[x,y],this);
                }
            }
        }


        public Sector(string[] text,string name)
        {
            subsectors = new Subsector[4,4];
            Name = name;
            var subsectorsData = new List<string>();
            var x = 0;
            var y = 0;
            var subsectorName = "";
            foreach (var line in text)
            {
                if (line == "")
                {
                    subsectors[y, x] = new Subsector(subsectorsData, subsectorName,this);
                    x++;
                    if (x >= 4)
                    {
                        x = 0;
                        y++;
                    }

                    subsectorsData = new List<string>();
                }else if (line.Contains("Subsector"))
                {
                    subsectorName = line.Remove(0, "Subsector ".Length);
                }
                else
                {
                    subsectorsData.Add(line);
                }
            }

            subsectors[y,x] = new Subsector(subsectorsData,subsectorName,this);
        }

        public void GenerateSubsectors(int worldChance = 50)
        {
            for (int y = 0; y < subsectors.GetLength(0); y++)
            {
                for (int x = 0; x < subsectors.GetLength(1); x++)
                {
                    subsectors[y,x] = new Subsector(x,y,this);
                    subsectors[y,x].GenerateSubsector(worldChance);

                }
            }
        }

    }
}