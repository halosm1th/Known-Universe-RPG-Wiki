using System.Collections.Generic;

namespace VoicesFromTheVoidArticles.VoicesFromTheVoidArticles
{
    public class VoicesIssue9
    {
        private static VoicesFromTheVoidIssue issue9 = null;
        public static VoicesFromTheVoidIssue AddIssue9()
        {
            if (issue9 == null)
            {
                issue9 = new VoicesFromTheVoidIssue(
                    issueName: "The Post-War Years",
                    issueDescription:
                    "This is a collection of the top stories that Voices in the Void has published in the last Five Years, offering a glimpse into what's happened and changed over that time.",
                    issueNumber: 9,
                    articles: new List<VoicesFromTheVoidArticle>
                    {
                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Zygmont Zylka",
                            articleName: "The War is Over!",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(01,12,83391),
                            paragraphs: new List<string>
                            {
                                "It is over! A bloody long year of war led by the Dominate and their allies. Amodiage may have been destroyed; but Acadie has been reconquered! A resulting peace treaty united Venhut with what remained of Amondiage, while also taking control of the former Red Rock Republic, Neubayern-Topas alliance, and other nearby nations. In exchange, the Western Islands Alliance, reformed into the Federation of Fosterville, was granted permission to annex what had been the Southern-Islands Trade Consortium and the Sansterre Belt. Shortly after, what had once been Gunripped and its surrounding regions in Oren Wastes 2 (2,2) were divided up among the new Imperial powers.",
                                "During later negotiations with the Western Islands Trade Federation, the Dominate of the Imperial Faith was brought back under Kotlik Control in exchange for several systems in the Kendrick Subsector (1,1). ",
                                "Finally the nations of Sar-tan and Star-can came together in agreement to house the International Red Cross. The Bank of Esperenza was returned its traditional lands, and the new Zulflucht Federation houses the new International Political Food Bank, an entity whose claimed purpose is to \"Give the rich and powerful the dinners they need.\"",
                                "With the end of the war, the now heavily militarized governments have been forced to focus on regaining control within their own boarders and dealing with economic issues. Many say that the peace deals, which critics call the execution of an imperialists vision of the Thippe464 Accords of 83390, will not last the decade."
                            }),
                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Faleria Bellator",
                            articleName: "A Kingdom Reborn!",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(19,02,83392),
                            paragraphs: new List<string>
                            {
                                "The No God Land and Rex van der Sever have just ended their 'civil war' as the revisionists are already terming it. What had once been a strong, and proud, duality of nations divided peacefully in the Thippe Accords now revert, like so many things, to their pre-thippe ways, with a new coat of paint. The Rex van der Sever have won out, and with them those Godly Communist Duetchlanders have been expelled from the Islands. ",
                                "Olitar, lacking a protector, has been taken by the Western Islands Trade Federation, now reborn as just _The_ Trade Federation. With this, the old Commune holdings in the Oren Wastes were snatched by the Trade Federation. Kotlik executed a well planned invasion, capturing several systems in Wynona (2,1). The Trade Federation also took the opportunity to absorb their former puppet: The New Colchis Business Board. These moves created what some in the Trade Federation have taken to calling 'their colonies.' In trade for these lands, the Rex van der Sever secured a few holdings in the Nothern part of Payette (4,1)",
                                "During this time the Rex van der Ostrovski laid claim to the nation founded following the Tilova Pact, as well as Thippe itself, all in Oren Wastes 2 (2,2). Knight Hubert also granted Coda as a fief to Duke of Jeffers as thank you for his and his compatriots help in regaining control in the North. "
                            }),
                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Orlando Kyrie",
                            articleName: "Formation of a Union.",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(03,09,83393),
                            paragraphs: new List<string>
                            {
                                "With the dissolution of most of the smaller powers in the Sector, the Germushian aligned Trade Federation, and United Federation of Earth aligned Federation of Fosterville have chosen to sign an 'Act of Union,' between themselves and the Kotlik Republican-esc Military Junta. The goal of this Union is a shared military integration under the command of a state-elected President, as well as favourable economic unity and foreign policy objectives.",
                                "Political analysts believe this military formation is created out of fear of the Dominates growing power, especially in the Galactic Center. Rumours talk of tension within the Rex van der Ostrovski. The Eastern faction favouring the Dominate and the Western favouring the Trade Federation. But it is believe to have little truth. ",
                                "The Union Claims their formation is purely for defensive purposes, citing escalating tensions sector wide."
                            }),
                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Zygmont Zylka",
                            articleName: "Red Rock Goes Evil; Spiritwood submits to Liege.",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(15,04,83394),
                            paragraphs: new List<string>
                            {
                                "Red Rock has officially joined the Dominate Alliance, forming the Dominate of Red Rock under Dominatus Electus Logan. It has launched fleets to attack the Trade Federation, kicking the latter out of the Payette Subsector, and even going so far as to capture Ijamsville and neighboring systems giving it a foothold in 4,2. Trevor, always the rebel swore alliegence to Red Rock as soon as offered. ",
                                "The Spiritwood Senate has elected to join the Rex van der Ostovski after being granted expanded lands during the peace of 83391, when the Federation annexed the Southern Islands Trade Consortium. The new lands cost Spiritwood heavily economically; the new promises from their liege indicate that these issues should be lesser, while the autonomy of the Spiritwood holdings maintained within the Rex van der Ostrovski. King Max is thought of quite highly due to his political acumen in making the Kings the largest they've ever been. "
                            }),
                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Faleria Bellator",
                            articleName: "Dutchy no-more - Knight Hubert swears in new: Rex van der Jeffers.",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(27,08,83395),
                            paragraphs: new List<string>
                            {
                                "For their long standing good service, and growing issues between themselves and the Rex Max, Knight Hubert has granted the former Dutchy now Rex of Jeffers the title of King, and giving it all the former lands of the Rex van der Ostrovski in the 4,3, and 4,4 subsectors, as well as a few lands in 3,4. The Knight also granted the new King the former Rex van der Ostrovki's colonial holdings.",
                                "The RO is nominally the superior power of the two, but the RJ seems to have gained great sway with the Knight is recent years. However, he is reported to be leaving the sector for personal business for the next few years, how this will impact the Kings is unknown. ",
                                "At present the greatest point of departure between the two southern Kingdoms is who they wish to support: the Western Rex van der Ostrovski seek a Pro-Dominate alliance, while the Eastern Rex van der Jeffers seeks closer ties with the Trade Federation. The Rex van der Sever is what keeps them from acting on these desires. It is believed by all three parties that should Sever split again, the galaxy would be enveloped in economic crisis and war."
                            }),
                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Orlando Kyrie",
                            articleName: "Scared, scared, sector silently screams: \"STOP WAR!\"",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(01,08,83396),
                            paragraphs: new List<string>
                            {
                                "Tensions are higher then ever before. It seems the whole sector is ready for war, waiting for a trigger. Fleets have grown large; many argue their nations can't continue to support their fleets and feed their people. Some call for peace; most call for war. There can only be one way of life they say. The Union's or the Dominate's. Military strategists say that the winner will likely be whoever hits first, and hardest. Political Commentators have remarked on the vital importance of the Kings Neutrality. If the balance of power leans too far to one side, it will incentivize them to launch an assault, leading to a war from which the sector will never recover. "
                            }),

                    }
                );
            }

            return issue9;
        }
    }
}