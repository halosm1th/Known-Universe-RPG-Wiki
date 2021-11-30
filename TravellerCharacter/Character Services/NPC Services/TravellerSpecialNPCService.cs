using System;
using System.Collections.Generic;
using TravellerCharacter.CharcterTypes;

namespace TravellerCharacter.Character_Services.NPC_Services
{
    public class TravellerSpecialNPCService : TravellerNPCService
    {
        private static readonly Random rand = new();

        public List<TravellerSpecialNPC> GetNPC(int npcCount, TravellerNameService.NationNameList nationNameList)
        {
            var npcList = new List<TravellerSpecialNPC>();
            try
            {
                for (var i = 0; i < npcCount; i++)
                {
                    var npc = GenerateTravellerSpecialNpc(nationNameList);
                    npcList.Add(npc);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return npcList;
        }

        private TravellerNPCRelationship GetRelationship(int relationship)
        {
            return relationship switch
            {
                0 => TravellerNPCRelationship.Ally,
                1 => TravellerNPCRelationship.Contact,
                2 => TravellerNPCRelationship.Enemy,
                3 => TravellerNPCRelationship.Rival,
                _ => TravellerNPCRelationship.Contact
            };
        }

        private int GetAffinity(TravellerNPCRelationship relationship)
        {
            return relationship switch
            {
                TravellerNPCRelationship.Ally => rand.Next(2, 13),
                TravellerNPCRelationship.Contact => rand.Next(1, 7) + 1,
                TravellerNPCRelationship.Rival => rand.Next(1, 7) - 1,
                TravellerNPCRelationship.Enemy => 0,
                _ => 0
            };
        }

        private int GetEnmity(TravellerNPCRelationship relationship)
        {
            return relationship switch
            {
                TravellerNPCRelationship.Rival => rand.Next(1, 7) + 1,
                TravellerNPCRelationship.Contact => rand.Next(1, 7) - 1,
                TravellerNPCRelationship.Ally => rand.Next(2, 13),
                TravellerNPCRelationship.Enemy => 0,
                _ => 0
            };
        }

        private int GetPower()
        {
            return rand.Next(2, 13);
        }

        private int GetInfluence()
        {
            return rand.Next(2, 13);
        }

        public TravellerSpecialNPC GenerateTravellerSpecialNpc(string name, TravellerNPCRelationship relationshipType)
        {
            var baseNPC = TravellerNpc(name);

            var affinity = TravellerSpecialNPC.AffinityModifier(GetAffinity(relationshipType));
            var enmity = TravellerSpecialNPC.EnmityModifier(GetEnmity(relationshipType));
            var power = TravellerSpecialNPC.PowerInfluenceModifier(GetPower());
            var influence = TravellerSpecialNPC.PowerInfluenceModifier(GetInfluence());

            var npc = new TravellerSpecialNPC
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
            var baseNPC = TravellerNpc(nationNameList);

            var relationship = rand.Next(0, 4);
            var relationshipType = GetRelationship(relationship);

            var affinity = TravellerSpecialNPC.AffinityModifier(GetAffinity(relationshipType));
            var enmity = TravellerSpecialNPC.EnmityModifier(GetEnmity(relationshipType));
            var power = TravellerSpecialNPC.PowerInfluenceModifier(GetPower());
            var influence = TravellerSpecialNPC.PowerInfluenceModifier(GetInfluence());

            var npc = new TravellerSpecialNPC
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