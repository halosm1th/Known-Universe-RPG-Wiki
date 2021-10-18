using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Hosting.Internal;
using TravellerWiki.Data.Services.DataServices;
using TravellerWiki.Data.SimpleWikiClasses;
using TravellerWiki.Pages.VoicesFromTheVoid;

namespace TravellerWiki.Data.VoicesFromTheVoidArticles
{
    public class VoicesIssue8
    {
        private static VoicesFromTheVoidIssue issue8 = null;
        public static VoicesFromTheVoidIssue AddIssue8()
        {
            if (issue8 == null)
            {
                issue8 = new VoicesFromTheVoidIssue(
                    issueName: "Another year of war",
                    issueDescription:
                    "Violence has rocked the Islands as war becomes widespread with teh dawn of the new year",
                    issueNumber: 7,
                    articles: new List<VoicesFromTheVoidArticle>
                    {
                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Zygmont Zylka",
                            articleName: "War is here.",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(27, 07, cen:391),
                            paragraphs: new List<string>
                            {
                                "The last year here in the Islands has not been pretty. Bloody war dominated the closing months 83390; 10/390 saw the Venhut Dominate States losing their Dominate backed fleet after a failed invasion of St. Geneieve due to the interception of Essia Pirates; meanwhile the Dominate launched a successful invasion of Quasqueton (8,9;1’2), meanwhile trade feels further linked the various economies within the sector.",
                                "By 11/390 the war further expanded as the north saw large amounts of funds begin to flow into it from all sides as both the No God Land and Rex van der Sever battled for control of what used to be their shared commune, with the No God Land holding onto its lands; meanwhile other nations began mass militarization movements; and the Dominate continued their campaign with an invasion of the Tech World Agucaitov (6,3;2’2). Meanwhile, an alliance between the Trade Federation and WIA and their puppets led to the invasion of Venhut (5,10;3’2), and Dovers (6,9;3’2), who had recently signed a cease fire with the IDF and their allies. ",
                                "By year end, the Trade Federation was working hard to create some form of semi-formal peace in an attempt to hold off the bloodshed; just at the end of the month the “The end of the Great War” was signed into effect, ensuring non-agression between all nations in the sector except the Rex van der Ostrovski, and a full retreat of all fleets, as well as requiring a concession that the Dominate Supreme who had been instigating various attacks around the sector stand down, handing over control of the Sector to the Red Rock Republic. At the same point, having bought the vast debt of the No God Land, the NGL was forced to bend the knee to their new monarchs. ",
                                "During the month of RRR control of the Dominate, a Rex van der Sever backed terrorist attack rocked the old Dominate; Southern Islands Trade Consortium terrorists attacked the Rex van der Ostrovski, while RVO nobles in the RVS were assassinated, with all links seeming to point back to the Rex van der Sever; Similar terrorist attacks rocked the WIA, whose ties seemed to go back to the Islands Defense Federations internal terrorist issues. With the large disruption to the world through these widespread attacks, the Red Rock Republic launched a war against the Rex van der Ostrovski, retaking the planet of Acadie for the Imperial Tillium Company. In response the Versian Knight Nathanial Huber declared publicly that he would support any imperial officers who wished to turn on their leader; in response all but one fleet turned away from the RRR, swearing fealty to the Venhut Dominate States, transferring control of the empire to what used to be its puppet. By the second month of 83391 the Renewed Venhut launched an invasion into the WIA and IDF, taking the systems of Delray (3,2;1’3), Sansteere (7,2;3’3), and St Geneviev (5,3;3’3).  This left the IDF with their new holdings from the cease fire: New Home (3,5;3’3) and Colchis (4,6;3’3), and their old planets of Serendip Belt (5,3;2’3) and Gloire (3,3;2’3). ",
                                "The galaxy now lies divided at the start of the third month of 83391, bloody war has ravaged the sector. Peace that was to last 50 years lasted mere months as Venhut ships campaign through a previously allied lands, the Trade Federation has backed off the Sector Stage, starting instead an international sector-wide aid group, welcoming war refugees into their mega corps and depleted lands, and their puppets seem to be following suit, with the Mainhair Military Republics glorious new fleet being sworn for the sole purpose of defense. The Red Rock Republic has launched several small invasions in the Rex van der Sever; with no intervention or support seeming to be on the table from the No God Land, while the Rex van der Ostrovski seem to be supporting Venhut. Meanwhile the IDF and WIA have become more focused on their own internal terrorist issues, though how that will now deal with the invasion is not clear, but an early victory over Esperanaza (1,6;2’3) shows good promise for those living under imperial terror now. How the Sector will deal with these changes over the coming months is not clear, but it will be impactful. "
                            }),
                            
                    }
                );
            }

            return issue8;
        }
    }
}