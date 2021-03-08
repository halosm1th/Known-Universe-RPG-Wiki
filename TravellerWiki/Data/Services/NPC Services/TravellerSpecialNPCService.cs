using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravellerWiki.Data
{
    public class TravellerSpecialNPCService : TravellerNPCService
    {

        private static Random rand = new Random();

        public List<TravellerSpecialNPC> GetNPC(int npcCount, TravellerNameService.NationNameList nationNameList)
        {
            var npcList = new List<TravellerSpecialNPC>();
            try
            {
                for (int i = 0; i < npcCount; i++)
                {
                    var npc = GenerateTravellerSpecialNpc(nationNameList);
                    npcList.Add(npc);
                }

            }
            catch (Exception e)
            {
                var x = 1 + 2;
                Console.WriteLine(e);
            }
            return npcList;
        }

        private TravellerNPCRelationship GetRelationship(int relationship)
            => relationship switch
            {
                0 => TravellerNPCRelationship.Ally,
                1 => TravellerNPCRelationship.Contact,
                2 => TravellerNPCRelationship.Enemy,
                3 => TravellerNPCRelationship.Rival,
            };

        private int GetAffinity(TravellerNPCRelationship relationship)
            => relationship switch
            {
                TravellerNPCRelationship.Ally => rand.Next(2, 13),
                TravellerNPCRelationship.Contact => rand.Next(1, 7) + 1,
                TravellerNPCRelationship.Rival => rand.Next(1, 7) - 1,
                TravellerNPCRelationship.Enemy => 0,

            };

        private int GetEnmity(TravellerNPCRelationship relationship)
            => relationship switch
            {
                TravellerNPCRelationship.Rival => rand.Next(1, 7) + 1,
                TravellerNPCRelationship.Contact => rand.Next(1, 7) - 1,
                TravellerNPCRelationship.Ally => rand.Next(2, 13),
                TravellerNPCRelationship.Enemy => 0,

            };

        private int GetPower() => rand.Next(2, 13);

        private int GetInfluence() => rand.Next(2, 13);

        public TravellerSpecialNPC GenerateTravellerSpecialNpc(string name, TravellerNPCRelationship relationshipType)
        {
            var baseNPCTask = TravellerNpc(name);
            var baseNPC = baseNPCTask.Result;

            var affinity = TravellerSpecialNPC.AffinityModifier(GetAffinity(relationshipType));
            var enmity = TravellerSpecialNPC.EnmityModifier(GetEnmity(relationshipType));
            var power = TravellerSpecialNPC.PowerInfluenceModifier(GetPower());
            var influence = TravellerSpecialNPC.PowerInfluenceModifier(GetInfluence());

            var npc = new TravellerSpecialNPC()
            {
                SkillList = baseNPC.SkillList,
                AttributeList = baseNPC.AttributeList,
                Name = baseNPC.Name,
                Background = baseNPC.Background,
                Career = baseNPC.Career,
                PatronText = baseNPC.PatronText,
                QuirkText = baseNPC.QuirkText,
                Affinity = affinity,
                Enmity = enmity,
                Power = power,
                Influence = influence
            };
            return npc;
        }

        private TravellerSpecialNPC GenerateTravellerSpecialNpc(TravellerNameService.NationNameList nationNameList)
        {
            var baseNPCTask = TravellerNpc(nationNameList);
            var baseNPC = baseNPCTask.Result;

            var relationship = rand.Next(0, 4);
            var relationshipType = GetRelationship(relationship);

            var affinity = TravellerSpecialNPC.AffinityModifier(GetAffinity(relationshipType));
            var enmity = TravellerSpecialNPC.EnmityModifier(GetEnmity(relationshipType));
            var power = TravellerSpecialNPC.PowerInfluenceModifier(GetPower());
            var influence = TravellerSpecialNPC.PowerInfluenceModifier(GetInfluence());

            var npc = new TravellerSpecialNPC()
            {
                SkillList = baseNPC.SkillList,
                AttributeList = baseNPC.AttributeList,
                Name = baseNPC.Name,
                Background = baseNPC.Background,
                Career = baseNPC.Career,
                PatronText = baseNPC.PatronText,
                QuirkText = baseNPC.QuirkText,
                Affinity = affinity,
                Enmity = enmity,
                Power = power,
                Influence = influence
            };
            return npc;
        }
    }
}
