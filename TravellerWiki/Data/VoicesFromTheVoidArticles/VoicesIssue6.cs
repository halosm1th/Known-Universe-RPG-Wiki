using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Hosting.Internal;
using TravellerWiki.Data.SimpleWikiClasses;

namespace TravellerWiki.Data.VoicesFromTheVoidArticles
{
    public class VoicesIssue6 
    {
        public static VoicesFromTheVoidIssue AddIssue6()
        {
            return new VoicesFromTheVoidIssue(
                issueName: "Tales from the Islands",
                issueDescription: "These are some of the stories that Voices was lucky enough to publish on our site, but were unable to put into a volume yet, so now they're here.",
                issueNumber: 6,
                articles: new List<VoicesFromTheVoidArticle>
                {
                    new VoicesFromTheVoidArticle(
                        articleAuthor:"Kustov Kesslering",
                        articleName:"A new Torchbearer was born!",
                        publisher: IslandsSectorPublishers.Voices_From_The_Void,
                        publicationDate:new TravellerDateTime(12,09),
                        paragraphs:new List<string>
                        {
                            "Blessed is Sigmar and those who carry his torch! Blessed are those who survived the" +
                            " horror on Fordoche, where a beast holy against the light of Sigmar was birthed " +
                            "forth from a lightless Capitalist Cult (probably with the darkness of the mad-god" +
                            " Lawgar) desperate to destroy the lives of their Comrades in the Commune! It was " +
                            "thanks to the newly lit Torchbearer Beutler Burdukovsky who's brave sacrifice resulted the abyssal beasts death. " +
                            "His status as Torchbearer has been confirmed by High Inquisitor Fedorov and " +
                            "blessed by the Church. Those who basked in the light of this Torchbearer and " +
                            "helped to light his flame include the Strong Krausser Kublanov, the Brave Dyogtina" +
                            " Orya, and the hammer-keeper Kurochkin Klugman, the first returned to his home-Commune to become" +
                            " a member of its Planetary committee, while the other two have chosen to join  the retinue of the newly anointed Inquisitor Nikiforov Blattner"
                        }),

                    new VoicesFromTheVoidArticle(
                        articleAuthor:"Orlando Kyrie",
                        articleName:"The Death of a Noble",
                        publisher: IslandsSectorPublishers.Voices_From_The_Void,
                        publicationDate:new TravellerDateTime(28,05),
                        paragraphs:new List<string>
                        {
                            "A great being had been lost today. Their most esteemed re-lator Tenelthorp Chesterfield was killed during a riot on the Mainhair Military Republic world of Uncode, in the Adhell district of the famous 'Donut Station', where he was working with an Uncode native, Hadeem Japuk, to earn money to send back to Japuk's family on the Military Republics planet below.",
                            "Chesterfield, beloved by many across the Known Universe for his kindness and compassion was the second Grandchild of the Federations first Extra Terrestrial Marriage, between the Human Woman Elizabeth Montgomery and the Falezorp Dominant Tenelthorp Ælfthryth. The marriage occurred early in the 3100s, following thr First Sol War and the Verseraulius Civil War.",
                            "The two met following Montgomery's tradeships Void-Priest mischarted the course, resulting in the first contact scenario on the mostly ocean planet which the ship arrived above, led by Mrs Montgomery. ",
                            "The most honoured Re-lator Chesterfield will surely be missed by all the great houses of the federation, and by all those who had the enviable chance to be in the presence of such nobility."
                        }),

                    new VoicesFromTheVoidArticle(
                        articleName:"Outsider Ambrose Anointed thus Appointed",
                        articleAuthor:"Orlando Kyrie",
                        publisher: IslandsSectorPublishers.Voices_From_The_Void,
                        publicationDate:new TravellerDateTime(10,05),
                        paragraphs:new List<string>
                        {
                            "Following the Trade Federations decision to merge the Trade Consortiums of Intercourse and Citra into one Southern Islands Trade Consortium, a leading conversation is who will be appointed to lead the new Consortium.",
                            "This honour has befallen the Federation Baron and earned the rank of Admiral in his Lord Weibes Navy during the Great War. During the war the Baron became distinguished for his work on the Germushian front and operating in what is now colloquially referred to as the Corridor.",
                            "The Baron, appointed on recommendation of the Western Islands Alliance, has chosen to begin his Tenure as Chairman of the Consortium by touring his new Domain. Beginning in Intercourse, the journey is expected to take the Baron to every world under his purview.",
                            "What the esteemed Federation noble holds for the Islands is unknown, and the Dominate Supremius has already requested Witcher Mediation for Violating the Andorius Accords of 83338 which stipulated that no signatory nation may hold land within the area designated as the Corridor, and if the signatory does hold land, then it falls on the other signers to take action to, legally and if necessary militarily, remove the invading government.",
                            "If the issue is investigated, there is a fear that this could backfire on the Dominate Supremius, who are known to have various close, bordering on illegal, ties with the Trans Galactic Empire which could be cause for war if the Witchers set precedent with this investigation by deeming it illegal.",
                            "What the future holds for Baron Ambrose of Sicily is not yet clear, but Voices will make sure to stay on the story.",
                        }),

                    new VoicesFromTheVoidArticle(
                        articleAuthor:"Faleria Bellator",
                        articleName:"Bumbling Baron raising an army, not just ranks.",
                        publisher: IslandsSectorPublishers.Voices_From_The_Void,
                        publicationDate:new TravellerDateTime(16,05),
                        paragraphs:new List<string>
                        {
                            "His grace the good Knight Huber has chosen Sir Wysoki to lead his most glorious forces in battle to ensure the liberation of the recently ceded kingdoms in the North of the Islands. His reason for doing this is visible to none in his court, nor any of the courts this author has stayed in.",
                            "His highness Wysoki’s appointment is rumoured to come with other bonuses, such as a possible increase in rank and gaining favour with the Knight himself. He is set to command the fleets of several of his supperious in the peerage. This has of course led to much anger, especially due to the Barons young age and ‘playboy’ attitude. Many kings are unsure if he has what it takes to truly lead a fleet in war.",
                            "Rumours circulate the various Kings courts about when the new Armada will depart the RVO, but no date has been set yet, and if there are any fleet maneuver plans, they have not yet been leaked. Though speculation that the Armada would head through the newly minted Trade Federation were quickly squashed when the Federation issued a statement declaring in no uncertain terms that Wysoki could not lead his fleet through their territories.",
                            "While no formal declaration of war has been issued, the Communes continued claim of ownership over the various kingdoms as they dissolve has been rumoured to greatly anger the Kings, who want their near fiefdoms. This is certain to lead towards some kind of bloodshed, but this author only hopes that their fellow Levis can survive the hardships of war under a fair and just liege."
                        }),

                    new VoicesFromTheVoidArticle(
                        articleAuthor:"Wyatt Larson",
                        articleName:"Planet Moff Sky goes off world, while Nappanee destroyed by plague",
                        publisher: IslandsSectorPublishers.Voices_From_The_Void,
                        publicationDate:new TravellerDateTime(17,05),
                        paragraphs:new List<string>
                        {
                            "Recently prompted Imperial Planetary Governess Skye Eden was reported as abandoning her previous posting as Planetary Moff of Nappanee as the planet descended into chaos caused by a rapidly spreading reanimator plague.",
                            "Governess Eden was recently involved in a small scale controversy in the Amondiage Imperial Government, and the greater Old Islands Defense League, after the story broke that she was ultimately responsible for the assassination of the previous Plentary Govenour of her new planet of St. Denis.",
                            "The defense of the Planetary Governess to the latter allegations is that she did as any good imperial would have done and nothing more. To the former assertions that she had left her post, the Governess has revealed to this reporter a series of documents showing that the Governor of Nappanee held a Citizens grudge to his fellow Imperial over their difference in Birth-Nationality.",
                            "The saving grace for the failure of a Governor of Nappanee is that the plague is said to have killed all souls as the imperial outpost on the planet, this has been confirmed by the Old Islands Navy who recently confirmed the loss of the colony, and announced that planning for a new colony is already underway. A full investigation into the virus has also been called by the Low-Emperor on Amondiage, who swore to discover who was behind this heinous failure at public safety."
                        }),

                    new VoicesFromTheVoidArticle(
                        articleAuthor:"Zygmont Zylka",
                        articleName:"Trade Federation declaration of a plague",
                        publisher: IslandsSectorPublishers.Voices_From_The_Void,
                        publicationDate:new TravellerDateTime(15,06),
                        paragraphs:new List<string>
                        {
                            "The Trade Federation finally puts people over profit. Six Standard months late, but better than never. The Federation has still refused to answer as to what caused the virus to appear, or what the virus is, or how the virus can be stopped, but they did declare that there is a plague condition sweeping the Federation, and all ships that are coming from infected systems, or have infected systems within 3 jumps of their current position should immediately be quarantined according to the Federation.",
                            "The Federation also refused to take the blame for refusing to act earlier, or discuss the extent of the damage, but unofficial reports have discussed that the plague has destroyed several high population planets and crippled several military installations, most of which are along major trade routes. This is expected to impact Trade along these routes heavily and food prices are expected to increase to compensate.",
                            "The primary motivation behind revealing the plague condition appears to have less to do with the destruction of the capital as it does the revelation that plague has spread to several planets outside the Trade Federation, including Napannee (1,3:4’3) and Uncode (6,6:3’2) among others.",
                            "What caused the virus, Witchers know but refuse to speak about it. If you have any tips, write them in and we here at Voices of the Void, if we can verify them as true, Voices will pay the writer Cr100,000."
                        }),

                    new VoicesFromTheVoidArticle(
                        articleName: "Report on the destruction of Kerkhoven",
                        articleAuthor: "Zygmont Zylka",
                        publisher:IslandsSectorPublishers.Voices_From_The_Void,
                        publicationDate: new TravellerDateTime(14,06),
                        paragraphs:new List<string>
                        {
                            "Recently, a small scout ship was recovered from the ruins of the Highport over Kerkhoven, within the ship was a small family of three people who were lucky enough to refuel the secondary fuel tank and disconnect the line before an internal rupture ignited the tillum, destroying the station.",
                            "The ‘Mother’ of the family, Linda, spoke about how a Deustchland tillium hauler coming up from Coila brought some kind of plague with it. The plague would lead to many turning insane and wanting to devour those around them, infecting them with the plague.",
                            "Some who tried to escape and fled to the planet seemed to lead to the destruction of most of the 9.3 billion people by taking the infection down with them. Those who survived did so in small holdouts and military bases, heavily fortified and with limited supplies. They were rescued by the Wintershall Tillium Corporation, who generally send a ship with unrefined tillium from Freeborn to Kerkhoven.",
                            "Upon the Corporation ships arrival it picked up a beacon from the tiny Scout Craft, and rescued those aboard. The Trade Federation official government has still yet to comment on this issue, the Witchers are equally silent. Inquisitor Fedorov, operating on behalf of “Sigmar, The Church, and the Government of the Deutschland, in that order” denied any fault of the Deutschland Government, promising that every Tillium Haulers shipboard Chaplins would insure that it could never happen on a Deutschland vessel. Stating that ‘The virus must have appeared elsewhere and somehow snuck aboard the vessel with some passengers they picked up at port who did not bask in the glorious light of Sigmar’"
                        }),

                    new VoicesFromTheVoidArticle(
                        articleName: "[= Kaer-Ship Aventorarial Release =] -=Univeralis Confederation Bulletin=- {North Western Islands Watchers} <Western Islands Commune Information Release> <[Dominate Supremius Dispatch]> [(Western Islands Alliance Announcement)] <<King's Decree>> $(Trade Federation Press Release)$ Etc...",
                        articleAuthor: "Venhut Dominate State Offical Statement",
                        publisher:IslandsSectorPublishers.Univeralis_Confederation_Bulletin,
                        publicationDate: new TravellerDateTime(03,06),
                        paragraphs:new List<string>
                        {
                            "A group of terrorists leading an armed revolt against the legal Government of Uncode recently have been Confirmed to be tied to the plague sweeping across the Trade Federation, and most recently a terrorist attack on the Donut Station of Uncode which resulted in the death of the Master Witcher Swanson Joaquin and the kidnapping and assumed murder of the Apprentice Witcher Alexzander Kenzie.",
                            "The terrorists are known to be harbouring the instigator of the riot [Name:Dani, Home: Coda] In Uncodes Adhell District, as well as the two men[Name: Mikee, Home: Starcan. Name: Barry Budson, Home: Starcan] responsible for causing the riot to turn into a failed revolt. They are also said to have kidnapped the Son of the Verisan Knight Nathaniel Huber, who was kidnapped by the terrorists to fund their operation under the cover of delivering Iron Dust, but actually smuggling illegal combat drugs to help overthrow already unstable governments for their own twisted ideology.",
                            "Currently it is believed that the terrorists are acting alone, but in the name of the now dissolved Western Islands Commune. The reported reason behind the terrorist targeting The Trade Federation and their allies is due to the terrorists desire to install a pro-communist government like that of the Western Islands Commune. A Spokesman from the Central subcommittee on foreign communications said that the commune had no involvement in the actions of these terrorists and denounce their actions.",
                            "This opinion have been echoed by Knight Huber who said that the terrorists kidnapped his son from a party the Knight was hosting on his privately owned planet of Coda. This party is the same one where the Imperial Ambassador Baldoa was brutally murdered. Knight Huber believes that the terrorist knew the Ambassador would be at the party before the attack and that the murder of the Ambassador was a deliberate choice, knowing it would further destabilize the Sector, and that it was only because of the good work of the Rex van der Ostrovski's Baron Alexi Wysoki that the commune was able to reach a place where it could peacefully dissolve, denying the terrorists their goal.",
                            "All nearby systems and government have been alerted as to this issue and a sector wide manhunt is in effect, with a bounty on the heads of the terrorists; 50 million Credits dead, 100 million Credits alive. As well, the witcher Kaer-Ship Aventorarial has been recalled to retrieve the bodies and being justice to this situation."
                        }),
                    new VoicesFromTheVoidArticle(
                    articleAuthor:"Orlando Kyrie",
                        articleName:"Star-Can Abandons military obligations to focus on personal defense.",
                        publisher:IslandsSectorPublishers.Voices_From_The_Void,
                        publicationDate:new TravellerDateTime(13,07),
                        paragraphs:new List<string>()
                        {
                            $"The [debate](https://thesteamnetwork.com/VoicesFromTheVoid/Articles/{@VoicesIssue5.AddIssue5().Articles.First(x => x.ArticleName.Contains("Star-Can Confederacy debate rages over ship procurement.")).ArticleID.ToString()}) in the Star-Can Confederacy has finished. The Government of the Confederacy decided to renounce their obligations made during the Gloire(3,3:2'3) Accords in 83386, which said that all signatories would maintain a fleet capable of defending themselves as well as rendering aid to fellow signatories in a time of escalating violence. ",
                            "When war broke out between the Independent Defense Federation(IDF) and the Old Islands Defense League(OIDL), it was assumed that the IDFs traditional allies would back it in its war, as had been reaffirmed at the affirmation accords. There was a flutter of hope that the IDF may get its aid when the Star-Can Confederacy Government began discussing fleet procurement in serious, hushed, voices. The conclusion reached by the Government was that a proper military fleet was well outside of their budget, and at best they could hope for a fleet capable of dealing with internal piracy issues.",
                            "Opposition to the government pointed out that a fleet for anti-piracy purposes would fall under policing, not military action, and that creating such a fleet for military purposes would cause the Confederation to fail to maintain its promise in the Gloire Accords. ",
                            "Government chose to ignore their allies and obligations, investing in the anti-piracy fleet for a total cost of just under 1 billion Credits. Most of which is being financed by loans offered to the Confederation by the Western Islands Alliance to allow them to meet their Accords obligation. How this insulting use of funds and failure to uphold their promises will play out in the long run is unknown, but what can be said for certain now is that the Government of the Confederacy has failed and let down their allies, and if the IDF fail in their war against the OIDL and allies, that blame rests as much on the Confederacy as it does the IDF."
                        }),
                    new VoicesFromTheVoidArticle(
                        articleAuthor:"Master of Arms Haddock Gibbs ",
                        articleName:"The Death of an Apprentice Sith, Matt Warde.",
                        publisher:IslandsSectorPublishers.The_Imperial_Standard,
                        publicationDate: new TravellerDateTime(28,08),
                        paragraphs: new List<string>
                        {
                            "Mathew Warde wasn't an old man when he died. In Imperial years hes was but a wee lad, just barely younger then the Empire intowhich he was born, and a mere speck of an Atom on the Sith Timeline." +
                            "This fledgling apprentice had an interesting life before he departed from the empire, though his exploits limited and of little note for this publication, as this publication instead wishes to focus its eyes on Apprentice Wardes Actions after he left the Empire and Dominate behind.",
                            "Warde was known to be on world when the Witcher plague broke out on the Old Islands Defense League world of Nappanee(1,3:4'3), dropping off information and research for an imperial ally but a future enemy of Ward, Imperial Planetary Military Commander and future Planet Moff Sky Eden. [All of which occured just before the planet fell to the plague.](https://thesteamnetwork.com/VoicesFromTheVoid/Articles/1069)",
                            "Warde and his troupe then went to [Kerkhoven(4,3:4'3)](https://thesteamnetwork.com/VoicesFromTheVoid/Articles/1071), where Warde was responsible for firing on a small childing, wounding their arm. But beyond this, the brave sith was able to his poweres to hold the plague-beasts on the station at bay, buying time for his allies and himself to escape. Afterwhich they departed to the research medical base on Bellport(3,6:4'3).",
                            "After visiting and rendering aid to the researchers on Bellport, and killing their leader, while one group member was exposed to horrific research experiments. The group then departed, with Warde as their head, towards the recently changed hands planet of Jeffers(2,9:4'3)." +
                            "On Jeffers, Warde was instrumental in installing the Xiao-Ming Born Duke Han Fei to the throne through a [marriage to the title-holder Silia Auspex](https://thesteamnetwork.com/VoicesFromTheVoid/Articles/1044). In an attempt to stop the transfer of power and instead secure the planet for herself, Imperial Planet-Moff Sky Eden arrived aboard her own star destroyer and attacked the planet, attempting to lay siege." +
                            " Moff Eden executed the survivors from Kerkhoven, before being stopped by Warde and his allies. Warde then become a body-guard to and key man for Duke Atreiedes himself. " +
                            "The Duke and his retinue then departed on a mission to view their newest claim, the planet of Acadie (6,5:3'3), along the way, Warde helped the Duke defend his ship from Pirates in the system Means(2,7:4'3), and proceeded to join the Duke on an investigative exploration of the planet Demmitt(2,6:4'3). On this strange world, while defending the researches from a strange, alien entity, ward was attacked by a naked, scared, and confused reseracher with a plasma rifle, whose dead-shot aim oblitered most of Warde. His body was able to offer one last Imperial service, that of cover to protect the Duke and his troupe from the strange alien creature on the world." +
                            " Warde gave his life for an imperial cause, protecting a title holder and spreading the imperial and sithly message. He was as true to the imperial dream and shall go down in the sector as one of its legends."
                        }),
                    new VoicesFromTheVoidArticle(
                        articleAuthor:"Zygmont Zylka",
                        articleName:"Death of Dimmitt",
                        publisher: IslandsSectorPublishers.Voices_From_The_Void,
                        publicationDate:new TravellerDateTime(08,09),
                        paragraphs:new List<string>{
                            "A tragedy is on display for us today with the revelation that the Ciayk Starship Producers research outpost on the planet of Dimmitt(2,6:4'3) has been slaughtered.",
                            "The facilities computer systems have been unrecoverable destroyer, along with a majority of the electronics within the facility. Backups of the research appears to have been stolen, and 8 of the employees have been kidnapped, the rest were all killed.",
                            "The lab appeared to be researching an innovated new Hull Technology allowing for liquid self repairing hulls, as well as seeing how this technology could be adapted for other markets, such as Augmentation.",
                            "For this reason, current evidence suggests it may have been an inquisitor who did this. There are several void blade marks that match with one that an inquisitor would use, as well as a few other possible signs, such as ramblings in a journal regarding the 'Wife of Sigmar' from one of the doctors.",
                            "Hopefully the Witchers are able to investigate this issue and bring justice to the lives lost here."
                            }
                        
                        ),
                }
            );
        }
    }
}