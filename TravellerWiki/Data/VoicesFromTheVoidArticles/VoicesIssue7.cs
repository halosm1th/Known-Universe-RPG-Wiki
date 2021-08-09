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
                        new VoicesFromTheVoidArticle(
                            articleAuthor:"Faleria Bellator",
                            articleName:"RVO Aristocratics Praises Corporate Agent [Hunnelwell Hunters]",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(28,07),
                            paragraphs: new List<string>
                            {
                                "A number of high ranking Aristocratics within the Rev van der Ostrovski recently released an open letter praising Ali Ewan; an employee of Hunnelwell Hunters, who are themselves a small privateering firm operating on Hunnelwell(1,9,1,1).",
                                "The Aristocratics are rumoured to have hired the Hunters on several occasions, most recently the Hunters are believed to have been hired to help overthrow the previously Commune aligned Count of Wellston(6,4:2'1), and instead installing a new ruler closer in line with the RVO ideals.",
                                "However, the letter spends more of its time praising the training, quality, independence, and trustworthiness of the Hunters. Critics are vocal about their issues with a group of high ranking Astricocratics supporting not only murderers who are reported to have committed several warcrimes; but also soldiers from outside the RVO.",
                                "Currently, the letter has caused a temporary bump in The Hunnelwell Hunters Stock Price  on the Imperial Exchange, however recent concerns about Imperial Investment Scams praying on RVO minor Nobility have caused the bump to be much smaller then initially expected. Analysts expect the price to keep rising for the rest of the week, before returning to pre-endorsement levels. "
                            }),
                        new VoicesFromTheVoidArticle(
                            articleAuthor:"Caesar Aetius",
                            articleName:"Senecio Cunobarrus head of Artistic Collective Announces Nuken Home",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate:new TravellerDateTime(3,02),
                            paragraphs: new List<string>()
                            {
                                "The Tilovian Pacts Artistic Collective have announced a new partnership with the Old Islands Defense League Privateer Group Nuken Home which will escort artists from around the Central Islands to Tilova(5,10:2'2) so long as they are dues paying Members of the Collective.",
                                "Known Playboy and spokesperson of the Privateer group Danvers Vanessa said about the partnership: \"We here at New Home deeply believe in Artistic Expression, and so we are excited to announce this partnership with the Aritstic Collective. We Hope that this can be the start of a deeper relationship between the people of New Home and Tilova\"",
                                "Meanwhile the Corporate Executive behind the Artistic Collective, Cunobarrus Tyrana, said that he is excited to see how this will allow the collective to explore new forms of artistic expression, and artistic ideas from around the sector, and all these ideas to spread across the sector."
                            }),
                        new VoicesFromTheVoidArticle(
                            articleAuthor:"Wyatt Larson",
                            articleName:"Don Korleonius head of Imperial Mafia Reveals Bill",
                            publisher:IslandsSectorPublishers.The_Imperial_Standard,
                            publicationDate:new TravellerDateTime(28,08),
                            paragraphs: new List<string>()
                            {
                                "The (rumoured) head of the Five Families Imperial Mafia in the Old Islands Sector the don, Korleonius, has revealed a new piece of Legislation today.",
                                "The Bill is set to introduce to the Dominate Supremius a new classification of license allowing research into general purpose AI. This is a bold step not only for the Dominate Supremius, but also for the [Imperial Tillium Company](https://thesteamnetwork.com/Factions/IslandsFaction/10164), who is believed to be behind the drafting of this Legislation. This is because the Bill allows any Dominate Aligned company to apply for a retroactive license, which could interfere in the ongoing investigation into the company for its actions on Acadie(6,5:3'3) regarding the use of [Zalyn units](https://thesteamnetwork.com/VoicesFromTheVoid/Articles/1049)",
                                "In support of the Bill is also the No God Land social group know as the [Free Robotiks Movement](https://www.thesteamnetwork.com/Factions/IslandsFaction/10169), who advocate for the islands to pursue the development of General Purpose AI to give the lands a competitive advantage against the larger nation states."
                            }),
                        
                        new VoicesFromTheVoidArticle(
                            articleAuthor:"Zygmont Zylka",
                            articleName:"Johnson Chins-Ranton head of Free Robotiks Movement Reveals Agreement",
                            publisher:IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate:new TravellerDateTime(30,08),
                            paragraphs: new List<string>()
                            {
                                "John Chins-Ranton, the Head of the Free Robotiks Movement revelead an agreement between the group of several robotics groups within the Dominate Supremius, and the Imperial Tillium Company, to pursue the creation and development of Tillium Mining and Mining ship Defense Robots, to be developed with recent innovations in the field of Artificial Intelligence.",
                                "The group has however announced that the agreement rests on the passage of the recently reveleaved Bill to allow the research and development of General Purpose AI. This controversial bill is rumoured to have ties back to the Imperial Mafia. However, if the bill passes it would open the door for other islands governments to pass similar AI legislation, possibly leading to an increased ferocity in the already harsh war. and possibly bloodier conflicts in the future.",
                                "However, as these conflicts grow in size, the number of robots needed to fight in them will increase, which means that this could be the right time to invest in various robot production companies, as if you're going to risk spending the next few decades in constant war, may as well bet on who the winners will be with your life savings!"
                            }),
                            
                    }
                );
            }

            return issue7;
        }
    }
}