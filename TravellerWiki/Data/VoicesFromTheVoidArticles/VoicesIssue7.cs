using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Hosting.Internal;
using TravellerWiki.Data.Services.DataServices;
using TravellerWiki.Data.SimpleWikiClasses;
using TravellerWiki.Pages.VoicesFromTheVoid;

namespace TravellerWiki.Data.VoicesFromTheVoidArticles
{
    public class VoicesIssue7
    {
        private static VoicesFromTheVoidIssue issue7 = null;
        public static VoicesFromTheVoidIssue AddIssue7()
        {
            if (issue7 == null)
            {
                issue7 = new VoicesFromTheVoidIssue(
                    issueName: "Industry News",
                    issueDescription:
                    "Corps and Industries have been getting hit and fighting each other in the background, here's an issue dedicated to our coverage of said issues.",
                    issueNumber: 7,
                    articles: new List<VoicesFromTheVoidArticle>
                    {
                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Burska Hetman",
                            articleName: "Counts Compromise in Dispute over Shipping Company: Metrolink.",
                            publisher: IslandsSectorPublishers.Lickup_The_Facts,
                            publicationDate: new TravellerDateTime(27, 07),
                            paragraphs: new List<string>
                            {
                                "Formerly Ionia-Waskin Trade Pact company and sector wide shipping giant **MetroLink** has had its fate settled following a major court case.",
                                $"The company was founded within the Trade Pact 34 years ago, and serves as the primary distributor of Xiao-Ming goods within the sector. Following the [Thippe Accords](https://thesteamnetwork.com/VoicesFromTheVoid/Articles/{VoicesIssue2.AddIssue2().Articles.First(x => x.ArticleName.Contains("Breaking news! Commune no More!")).ArticleID}) where the Waskish system was given to the Southern Islands Trade Consortium, the company sued to have its headquarters transfered to the tiny system of WillsVil(7,3:3'4) which is still  owned by a Xiao-Ming friendly government.",
                                "The Courts were initially apprehensive about allowing this desicion, as pretty much all of the companies assests, employees, etc, were not within the tiny system. However, several other companies within the Southern Trade Consortium have compromised, if the company transfers its HQ to WIllsvill, it looses any sway it has in the Consortium, thus far the company has officially refused to comment, but sources on the inside say that the corp is working to find alternative solutions. "
                            }),
                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Abbington Strader",
                            articleName:
                            "Sith Extremists attack Tokeland Imperial Hospital; First Order Storm-Troopers Intervene; 9 dead, 8 wounded.",
                            publisher: IslandsSectorPublishers.The_Imperial_Standard,
                            publicationDate: new TravellerDateTime(13, 03),
                            paragraphs: new List<string>
                            {
                                "A splinter sect of the Sith, who go by the name: _Sigmorian Sith of Henefer_, are a group of Sigmarian-Sith Extremists who get their support from the the Old Islands Defense League. The group attacked the Tokeland Imperial Hospital two days ago. The stated goal of the extremists was to remove the taint of imperial augmentation from Sigmorias creations.",
                                "The group started their attack by taking the emergency room hostage using several illegially smuggled [redara-37 laser carbines]https://vignette.wikia.nocookie.net/starwars/images/2/20/E-11_blaster_rifle_DICE.png/revision/latest?cb=20151106030234). The group proceeded to rampage through the hospital, terrorisizing patients and staff alike while on the hunt for augmentated patients. The Terrorists came across the augment-recovery ward as a crack-squad of First Order Storm-Troopers commanded by the Imperial Special Forces Sargent John-171 entered the hospital. The Terrorists executed 4 patients, including one 7-year old Child who went by the name Lola Cambell who had lost her arm following an accident on a school trip, before the Storm-Troopers arrived. ",
                                "One of the extermists had a strong connection to the force, and drew on it, tugging at the life of the nearby patients, wounding 3 of them. The same extremist also had a micro-explosive in their heart, which detonated following a well timed headshot from Special Forces Solider John-171.",
                                "Overall, the extremist threat to Tokeland hospital was taken care of in just under 17 minutes. Far longer then acceptable for an Imperial institution. In response to this horrific event, the Planetary Governor has agreed to station a squad of First Order Storm-Trooprs on site all day until the extremist cells have been weeded out. To further this end, the Governor has called on the Dominate Supreme to investigate the actions of New Home(3,5:3'3) and Colchis(4,6:3'3) and their terrorist connections."
                            }),
                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Maccalus Lycus",
                            articleName: "Dataheist Postpones Merger In Spiritwood Senate",
                            publisher: IslandsSectorPublishers.PrincePeriodical,
                            publicationDate: new TravellerDateTime(03, 05),
                            paragraphs: new List<string>
                            {
                                "Two major armour manufactures and retailers within the Spiritwood Senate, _Spirit of Defense_ and _Senatatoral Suits_, were set to merge pending Senatorial Approval. However this approval has been postponed following a major dataheist.",
                                "The records of over 1.3 million clients, including both Sector-Wide buyers and individual customers had their data stolen when a group of hackers attacked the companies Headquarters mainframe, killing 13 and wounding 29 others, and causing 2.3 million in property damage. The Group is believed to have ties back to the **Southern Islands Trade Consortium** armour company _Protect Your Selfie_, however these ties have not been confirmed and the company dies any involvement what-so-ever.",
                                "Regardless, their stock price has nearly tripled since the news of the postponement broke, which conveniently prevented their largest competitor _I Own Armour_ from keeping up their hostile takeover. This combined with a suspected piracy campaign has had a crippling effect on _I Own Armour_, who went from being one of the largest armour retail chains in the Sector with 40% market domination, to now controlling less then 8% and whose share price has dropped a near record-breaking 26 points in just under 2 months.",
                                "Speculation on how this will play out is still up in the air, but many fear that more corporate infighting will only continue the unending campaign of death."
                            }),
                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Orlando Kyrie",
                            articleName: "Famed Artist John killed in Dreamport-3 Jump-Drive explosion.",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(29, 06),
                            paragraphs: new List<string>
                            {
                                "The Famous artist Gon is missing presumed dead following a jump-drive rupture aboard a Callin Stellar Imaginator Dreamport-3 being operated by the Esperenza headquartered Trade Company & Transport Agency _Bank Line_.",
                                "The company denies all fault in the rupture, saying that the crew aboard the ship had been properly vetted, passangers checked, and everything done according to plane. The company has not refused to rule out fowl play, and has hired Red Rock(5,3:4'1) based Police and Security firm G4Si to investigate the issue.",
                                "At this time, Jon's family has not yet responded to the tragedy, nor has any of his recent compatriots, but his fans have en mass expressed their sadness at his disappearance, with some even going so far as to say that no one will ever mach his quality or style in their lifetime, with one fan even saying that they had constructed a neural net based on all his performances to recreate the legend.",
                                "Life long friend. mentor, and ally, Menty, has expressed deep sorry at the disappearance of his friend, saying in a statement that 'Gohns true Talent was in the way he burrowed into your heart, and how from within he so magnificently pulled the cords that you can do nothing but weep. He will be greatly missed, but has joined his greatest fan, Ambassador Baldoda.'",
                                "Callin Stellar Imaginators however, has been even more dramatically impacted, as they have had a host of customers asking questions, and sector wide calls for regulation and investigation rage. Thus far the company has issued only a short statement saying that it will take action should the company be found at fault at the end of the investigation being conducted by the currently aggrieved party. Many however find this to have been lackluster, and the companies stock price has dropped to reflect this."
                            }),
                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Silarz Rogozinski",
                            articleName: "Huckling Carl misses Jump-Drive Industry Summit.",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(06, 07),
                            paragraphs: new List<string>
                            {
                                "At the start of this month the Annual **Callin Drive Summit** is held on New Colchis, the industries biggest and growing Jump Drive manufactors, Star ship designers and builders, parts producers, etc gather to discuss industry trends and standards. For the first time in 23 years, industry stable _Huckling Carl_ was absent from the Summit.",
                                "Rumours fly as to why the company no showed, but the biggest suspected reason is that the company objects being absorbed into a Trade Consortium, especially one with a 9% tarrif on Xiao-Ming goods, which the corp relies on to produce a majority of minor parts in their jump drives.",
                                $"Secondary rumours include the company plotting to produce its own, home designed, J3 drive to compete with the one designed by the New Colchis Business Board's Research Institute, or that the company no longer feels _Callin Stellar Imaginators_ have what it takes, especially following their dramatic stock decrees and increasingly bad press, including the renouncement of several Noblemen men from the companies board."
                            }),
                    }
                );
            }

            return issue7;
        }
    }
}