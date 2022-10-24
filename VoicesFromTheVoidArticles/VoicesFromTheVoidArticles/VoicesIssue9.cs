using System.Collections.Generic;
using System.Threading.Tasks;

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
                            publicationDate: new TravellerDateTime(01,12,83,391),
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
                            publicationDate: new TravellerDateTime(19,02,83,392),
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
                            publicationDate: new TravellerDateTime(03,09,83,393),
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
                            publicationDate: new TravellerDateTime(15,04,83,394),
                            paragraphs: new List<string>
                            {
                                "Red Rock has officially joined the Dominate Alliance, forming the Dominate of Red Rock under Dominatus Electus Logan. It has launched fleets to attack the Trade Federation, kicking the latter out of the Payette Subsector, and even going so far as to capture Ijamsville and neighboring systems giving it a foothold in 4,2. Trevor, always the rebel swore alliegence to Red Rock as soon as offered. ",
                                "The Spiritwood Senate has elected to join the Rex van der Ostovski after being granted expanded lands during the peace of 83391, when the Federation annexed the Southern Islands Trade Consortium. The new lands cost Spiritwood heavily economically; the new promises from their liege indicate that these issues should be lesser, while the autonomy of the Spiritwood holdings maintained within the Rex van der Ostrovski. King Max is thought of quite highly due to his political acumen in making the Kings the largest they've ever been. "
                            }),
                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Faleria Bellator",
                            articleName: "Dutchy no-more - Knight Hubert swears in new: Rex van der Jeffers.",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(27,08,83,395),
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
                            publicationDate: new TravellerDateTime(01,08,83,396),
                            paragraphs: new List<string>
                            {
                                "Tensions are higher then ever before. It seems the whole sector is ready for war, waiting for a trigger. Fleets have grown large; many argue their nations can't continue to support their fleets and feed their people. Some call for peace; most call for war. There can only be one way of life they say. The Union's or the Dominate's. Military strategists say that the winner will likely be whoever hits first, and hardest. Political Commentators have remarked on the vital importance of the Kings Neutrality. If the balance of power leans too far to one side, it will incentivize them to launch an assault, leading to a war from which the sector will never recover. "
                            }),
                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Zigmund Zilka",
                            articleName: "Peace in our Time!",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(21,07,83,396),
                            paragraphs: new List<string>()
                            {
                                "Praise Sigmar! Praise King Erin! Praise the lamp post from which the tyrant Malik hangs from! (Dominatus Supremius Logan of the Grand-Dominate of Venhut has already declared a museum for the Lamp Post, with funding raised from the looting of Former Supremius Malik’s personal pleasure villas.)  The war is over; the era of Pax Erinia has been declared. The reborn Church of Sigmar has begun sponsoring construction of schools, church’s, hospitals, and other charitable goods, effectively usurping the role of Dominate tainted Red Cross. But what caused this transformation, when as soon as two months ago war seemed all but inevitable? Read on.",
                                "Six months ago, the sector was ready for war, the only question was who would fire first. At the same time, Domanitus Supremius Malik assumed the position, taking over from the impeach Logan. Malik’s first move was to pull most of the Dominate from all international treaties, forcing the Red Cross to concede control over their lands in exchanging for the Dominate signing onto the Bank and Red Cross treaty. This negotiation saw the first example of his brinksmanship style of politics, threatening to nuke the whole negotiations by demanding the Red Cross pay the Dominate hundreds of credits. ",
                                "Over the next several months, shifting alliances begin to form. The Union coalesced from three separate nations into a single nation capable of putting up a defense to the threat posed by the Dominate. The Dominate had been working with some kings, other kings worked with the Union, drawing all closer to an inevitable, titan, clash. Guided by Sigmar’s light. A path out was revealed. Brinksmanship politics pushed all the Kings into open negotiations with the Union. A super-union, an oligarchical group of United Kings; the former Supreme Admiral of the Kotlik Junta becoming the new UK’s Military Head, the former Lawgarian of the Trade Federation now made economic minister, and the former prime minister of the Federation of Fosterville the acting Prime Minister of the UK. Meanwhile, the joining Kings would retain their independence. King Erin would be made formal High-King, overseeing a constitutional oligarchical-monarchy; her lands being transferred to the King-In-Name-Only of Jeffers Finn; the newly appeared Aliens being the tools of the High-King. ",
                                "In a too late, last ditch effort to prevent unification, Dominatus Supremius Malik paid the total of Dominate Supreme’s money to destroy the field of the newly formed UK. The ensuing few days saw the new total collapse of the Dominate under Malik. Staring with the desertion the key Economic Minister Owen to the United Kingdoms, taking with him the centrally located Venhut Dominate after being threated by Malik in another failed attempt at brinksmanship, followed shortly after by the desertion of former Dominate Supremius made Admiral Logan to the UK, taking with him the Dominate of Red Rock. Malik, essentially broke and without a military, facing increasing desertion and open rioting in the face of impending collapse agreed to a cease-fire with the United Kingdom, being allowed to retain his holdings in the Kendrick Subsector, and a few fleets, but otherwise lost control of lands. During this time, the two splinter Dominates reformed into the neo-Venhut Dominate, a province of the United Kings, with a similar position as that of one of the Kings, or the Union within the United Kings. ",
                                "Dominatus Malik was when offered another three successive chances to join the United Kings and spare his land, but each time a return of brinksmanship – getting a concession, thinking ‘but is this really the best I can get?’ try and go high, and push war as a way to get his goal – only now he lacked the economic know how, or the military power, to enforce his threats in the long term. As fleets began to desert, the Domanitus Supremius declared martial law, gunning challengers to the regime down in the street. Popular uprisings followed, collapsing what was left of the newly formed ‘Democratic Republic of Malik’ into the neo-Venhut Dominate. ",
                                "Shortly after, the reborn Church of Sigmar was granted full proselytizing and inquisitorial rights throughout the United Kingdom, at a cost of some lands being given to the Union, others to the Dominate, with the rest being left to the Former King now self-declared Sigmarian of the true faith, a splinter sect of the Orthadox Germushian Church.",
                                "As of now, three nations have three oligarchs of the governing council which make up the nine-person oligarchy that now runs the Northwestern Islands Sector. Composed of: The Union, The Neo-Venhut Dominate, and the Rex van der Jeffers, united under the reign of King Erin. How long the tenuous peace lasts, we cannot be sure. But as of now, a peaceful and democratic opening exists. Let there be peace in our time!",
                                
                            }),

                    }
                );
            }

            return issue9;
        }
    }
}