using System.Text;

namespace TravellerCharacter.CharcterTypes
{


    public class TravellerSpecialNPC : TravellerNPC
    {
        public int Affinity { get; set; }
        public int Enmity { get; set; }
        public int Influence { get; set; }
        public int Power { get; set; }

        public static int PowerInfluenceModifier(int value) 
            => value switch {
                5=> 0,
                6 =>1,
                7 => 1,
                8 =>2,
                9 =>3,
                10 =>4,
                11 =>5,
                12=> 6,
                _ => 0

         };

        public static string PowerText(int affinityModifier)
            => affinityModifier switch
            {
                0 => "The individual has virtually no resources they can bring to bear other than their own personal possessions.",
                1 => "Has a few friends or contacts who might be willing to help; the equivalent of a typical band of Travellers.",
                2 => "Has a significant asset such as a small starship and crew, or a small force of skilled mercenaries, high-end lawyers, or the like.",
                3 => "Has access to very significant assets such as a mercenary unit or a modest sized business entity.",
                4 => "Has powerful assets, equivalent to a small merchant shipping line or major business group.",
                5 => "Has enormous power, such as someone in the top echelons of a planetary government or the CEO of a large shipping line.",
                6 => "Is a factor in interstellar politics, such as a navy admiral or an official in an interstellar government.",
                _ => "Error",
            };

        public static string InfluenceText(int affinityModifier)
            => affinityModifier switch
            {
                0 => "Has virtually no influence over anyone.",
                1 => "Owed a couple of favours by minor officials and local notables such as the leader of a street gang or a port authority official.",
                2 => "Has one or more minor local notables ‘in their pocket’ and can get them to act illegally or dangerously on the odd occasion.",
                3 => "Has some influence over powerful people such as mid-level planetary government officials or rich portside merchant factors.",
                4 => "Has some influence at the interplanetary level, with government or underworld figures that owe him a favour or two.",
                5 => "Has very significant influence at the interstellar level, and can lean on lawmakers or officials in interstellar government.",
                6 => "Has the ear of extremely powerful people, such as the ruling noble of the local subsector.",
                _ => "Error",
            };

        public static string InfluenceDegree(int affinityModifier)
            => affinityModifier switch
            {
                0 => "No Influence",
                1 => "Little Influence",
                2 => "Some Influence",
                3 => "Influential",
                4 => "Highly Influential",
                5 => "Extremely Influential",
                6 => "Kingmaker",
                _ => "Error",
            };

        public static string PowerDegree(int affinityModifier)
            => affinityModifier switch
            {
                0 => "Powerless",
                1 => "Weak",
                2 => "Useful",
                3 => "Moderately Powerful",
                4 => "Powerful",
                5 => "Very Powerful",
                6 => "Major Player",
                _ => "Error",
            };


        public static int EnmityModifier(int value) => 0 - AffinityModifier(value);
        
        public static int AffinityModifier(int value)
            => value switch {
            2 => 0,
            3 => 1,
            4=> 1,
            5 => 2,
            6 =>2 ,
            7 => 3,
            8 =>3,
            9 =>4,
            10 =>4,
            11 =>5,
            12=> 6,
            _ => 6};

        public static string EnmityText(int affinityModifier)
            => affinityModifier switch
            {
                0 => "No Enmity towards the Traveller. This may be because they do not know who the Traveller is, or because the Traveller has done nothing to offend them.",
                -1 => "Vaguely ill-disposed towards the Traveller (or perhaps everyone in general) but will not go out of their way to impede them. Someone with an Enmity value of -1 is unlikely to take an action that will have serious consequences for the Traveller unless there is some great benefit.",
                -2 => "May engage in acts of petty spite for no gain, just to annoy and upset the Traveller. Someone with an Enmity value of -2 will probably stop short of actions that would seriously harm or kill the Traveller.",
                -3 => "Will go to some trouble to impede the Traveller, just out of spite. Does not care much what happens to the Traveller and will more than likely feel they deserve anything they get.",
                -4 => "Will do almost anything to get one over on the Traveller. Might actively plot against the Traveller for the sake of revenge or causing further harm even if there is little or no gain involved.",
                -5 => "Will actively plot or take serious risks to cause the Traveller harm at any opportunity.",
                -6 => "May engage in self-destructive actions in order to harm the Traveller, or put innocents at risk.",
                _ => "Error",
            };

        public static string EnmityDegree(int affinityModifier)
            => affinityModifier switch
            {
                0 => "None",
                -1 => "Mistrustful",
                -2 => "Negatively inclined",
                -3 => "Very negatively inclined",
                -4 => "Hatred",
                -5 => "Bitter hatred",
                -6 => "Blinded by hate",
                _ => "Error",
            };

        public static string AffinityText(int affinityModifier)
            => affinityModifier switch
            {
                0 => "No Affinity towards the Traveller. This may be an enemy or just someone who does not care at all what happens to the Traveller, depending on Enmity",
                1 => "About as well inclined towards the Traveller as any random stranger with a social conscience is likely to be. They will take minor actions to help, largely out of common courtesy, but not go to much trouble on the Traveller’s behalf unless there are benefits to the action.",
                2 => "Will probably help in a safe and easy manner if asked, even without reward, but will not take much risk.",
                3 => "Will take modest risks on the Traveller’s behalf or offer help without being asked, if they realise their friend could benefit.",
                4 => "Will do almost anything to help the Traveller, but may have higher loyalties to their own family, cause or service, or to other close friends.",
                5 => "Will probably put the Traveller’s interests before their own or that of others.",
                6 => "Will do whatever the Traveller asks of them (or what they think the Traveller would want), no matter what risks are involved. May also expect others to do the same.",
                _ => "Error",
            };

        public static string AffinityDegree(int affinityModifier)
            => affinityModifier switch
            {
                0 => "None",
                1 => "Vaguely well inclined",
                2 => "Positively inclined",
                3 => "Very positively inclined",
                4 => "Loyal friend",
                5 => "Love",
                6 => "Fanatical",
                _ => "Error",
            };

        private string SpecialNPCAffinityAndEnimity()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(AffinityDegree(Affinity));
            sb.Append(", ");
            sb.Append(EnmityDegree(Enmity));

            return sb.ToString();
        }

        private string SpecialNPCInfluenceAndPower()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(InfluenceDegree(Influence));
            sb.Append(", ");
            sb.Append(PowerDegree(Power));

            return sb.ToString();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append(" - ");

            sb.Append(SpecialNPCAffinityAndEnimity());
            sb.Append(" - ");

            sb.Append(SpecialNPCInfluenceAndPower());

            return sb.ToString();
        }
    }
}
