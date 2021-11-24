﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using VoicesFromTheVoidArticles;

namespace VoicesFromTheVoidArticles.VoicesFromTheVoidArticles
{
    public class VoicesIssue2
    {
        
        public static VoicesFromTheVoidIssue Issue2 = null;
        public static VoicesFromTheVoidIssue AddIssue2()
        {
            if (Issue2 == null)
            {
                Issue2 = new VoicesFromTheVoidIssue(

                    issueName: "The Vampyr Chronicles",
                    issueDescription:
                    "Following the Plague Outbreak that occured in 83390 within the Western Islands Trade Federation",
                    issueNumber: 2,
                    articles: new List<VoicesFromTheVoidArticle>
                    {
                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Zygmont Zylka",
                            articleName: "What Really Ravaged Raiford?",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(28, 12, 83, 389),
                            paragraphs: new List<string>
                            {
                                "Raiford (7,5:4'3.North Western Islands) has recently lost contact with " +
                                "other nations within the ~~Western Islands Trade Consortium~~ Western Islands " +
                                "Trade Federation. The planet of over 6 million people was recently updated on " +
                                "the Universalis Confederation trade network to reflect its new population of 0. " +
                                "The Trade Federation has been tight lipped so far as to what happened on this " +
                                "planet. Sources aboard the WITC Blissfield , the ship sent to investigate the" +
                                " new population report, say that the scout and recon teams deployed to the planet" +
                                " did not make contact with the Blissfield. Furthermore, according to the source, " +
                                "footage capture from a drone send with the recon party showed the largest city in " +
                                "ruins, looking as though a pack of rabid dogs tore through the citizens.",

                                "What is the Trade Federation hiding? Sources within the newly minted Trade Federation report the already strange power dynamic, where one Baron seems to control all external interactions and one of the leaders of trade consortium handles internal disputes. This has lead to circumstances where the right brain isn't taking to the left brain. Which side knows what happened on Raiford and why they've been working to cover it up, and prevent the other side from knowing currently remains a mystery.",
                                "A mystery that we here at Voices will continue to get to the bottom of, even if it costs us all our credits and lives."

                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Callin Stellar Imaginators",
                            articleName: "-=ADVERT=- The Dreamport-3 -=ADVERT=-",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(),
                            paragraphs: new List<string>
                            {
                                " New from Callin Stellar Imaginators, the Dreamport-3. New in the dreamport line and boasting an impressive jump 3 engine with the ability to two consecutive jumps, the Dreamport-3 is a deserving successor to the bestselling Dreamport-2. Request a consultation to see if a Dreamport is right for you at the nearest Class-A through C shipyard! Brought to you by the Callin Stellar Imaginators: Imagining the next way to get you into the stars! "
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Zygmont Zylka",
                            articleName: "Brandamore No more",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(15),
                            paragraphs: new List<string>
                            {
                                "The nearly half a million people on the Trade Consortium planet of Brandamore (7,3:4'3.North Western Islands) have been failed. While the official tally has not yet been updated by the Confederation, sources on a recent Consortium traskforce sent to investigate why the class-A Trade Ports' Control Board had failed to supply a status update for nearly a month.",
                                "The result was the same, according to my source, as what was found on Rainford (7,3:4'3.North Western Islands) was found here. The planet had been ravaged by war, corpses strew around the streets. Clear damage of military engagement from military base on the planet and whatever besieged them.",
                                "Leaked footage from the investigation of the military base revealed the facility had been decimated. Corpses of soliders remain cast around the facility with claw marks covering their bodies and distinct bite marks on them as well. Seemingly drained of blood.",
                                "At this time, the Trade Consortium still refuses to answer questions as to what happened on Rainford or Brandamore. Instead choosing to reassure everyone that things are under control and that Rainsfords population was move willingly to a new planet. While also claiming that nothing has happened to Brandamore.",
                                "Regardless of what message the Consortium may wish to send, leaked internal trade documents declare Rainford and Brandamore as Red Coded. When the announcement will be passed along to the TAS and the Confederation is currently unknown."
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Zygmont Zylka",
                            articleName: "Crisis on Coolin ",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(15, 02),
                            paragraphs: new List<string>
                            {
                                " The latest Trade Consortium planet to fall silent, the tiny planet of Coolin has reduced its official population from 1 to 0. The staff of the routine starport on the planet are also reportedly deceased. Though current sources from the official Scout teams have been unable to get Voices a copy of the official report yet. We eager await it to review what it contains. Hopefully even some answers, as the still unresponsive Trade Consortium has refused to give any answers."
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Zygmont Zylka",
                            articleName: "Fishy frieght from Fishertown. ",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(29, 02),
                            paragraphs: new List<string>
                            {
                                "Fishertown has lost its people. Once again the trade consortium says nothing but inviting an expert witcher panel in. When questioned, the panel refused to say what was causing the population on these worlds to disappear. Though they did confirm that they have an idea of what is causing the issue, and will investigate further if possible.",
                                "At this time, my sources from with the Trade Consortium confirm that there was a large trade contact taken by a ship that recently bought imperial tillium.",
                                "While this normally wouldn't raise many alarms, the fact that this ship appears in logs of several other infected ships and planets raises several eye brows.",
                                "My sources have been unable to tell me the name of this ship, they have assured me that they have issued a warrant and are investigating."
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Zygmont Zylka",
                            articleName: " Violence on Vacherie",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(18, 03),
                            paragraphs: new List<string>
                            {
                                " While the Witchers promise us information and facts, they deliver none. Where the Trade Consortium should take aciton, the desire for profit leads instead. ",
                                " Vacherie has no people on it. The same ship as on Fishertown and the other attacks appeared here again. But the Trade Consortium instead chooses profits over people by bringing in the military to Vacherie to clear out the station, and have begun scrounging up people to work the highport. Expect the job boards to soon have various contracts about transporting people and goods these depopualted planets after the old cities are walled off and burned. We shall see. I shall not let the Trade Consortium gone unpunished. "
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Zygmont Zylka",
                            articleName: "Hurting Hume",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(05, 04),
                            paragraphs: new List<string>
                            {
                                "Hume, once a major star port for trade and may be the reason for a war in the future if Trevor gets their way, now lies dormant. Once again our esteemed starship was here again. Once again it dropped off the plague again ruining the planet. ",
                                "A fleeing ship was able to record and send to us here at the Voices that confirmed that the plague ship is a Dreamport-3. The company has at this time refused to comment on weather the plague could be related to the ship in any way. ",
                                "The Trade Consortium refuses to give an answer as to what is causing the plague, though the witchers have confirmed with this latest sacrifice they know what the cause is. They still refuse to tell us though. "
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Zygmont Zylka",
                            articleName: "Triumph on Trevor ",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(22, 04),
                            paragraphs: new List<string>
                            {
                                "Much to everyones surprise, Trevor was able to prevent the spread of this disease on their planet. The cause has been discovered! The government in their press release says that a Daemon tears into peoples flesh, devouring them and turning their souls into it slaves and sending them to scoure the planet for the worthy and slaughter all the unworthy. ",
                                "The ship itself escaped but Trevor was able to escape the destruction the faced so many other planets. The ship has escaped but it shall be found, hopefully with this article the witchers will be shamed into finding it. ",
                                "The latest Theory from my sources say that its either heading to Coda or Olitar. My Money is on Olitar. Make a break to the commune and seek immunity. "
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Vox Populus",
                            articleName: "Breaking news! Commune no More!",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(2, 05, 83390),
                            paragraphs: new List<string>
                            {
                                "Breaking news! As of today, 2/05/83390, the Western Islands Commune is no more. As per the newly announced Thippe464 Accords, the commune has been ceeded to two factions. The Rex van der Sever, or kings of the north are being given 23 planets, while a newly created faction, the No God Land, has been founded in the north, perhaps a rebellion to the Deutschland's forcing of the Church of Sigmar on the Commune? It will be given a grand total of 27 planets, 2 of which currently belong to the Kotlik tribunal and are assued to the new faction by the Dominate Surpemius. This is an almost bold declaration of war within a peace treaty.",
                                " Oh, and that isn' the only shocking result from these accords. The United Baronies are united no more. Though they are now part of a trade federation with what was once known as the Western Islands Trade Consortium. How this will play with the guys up stairs no ones really sure. ",
                                " Of course, it wouldn't be the Baronies if some people didn't disagree. Thankfully Tonganoxie immediately declared their independence and exercised section 9. of the Uniting Treaties allow them to leave the baronies of their own free will, and has reformed with many other leaving baronies into the Independent Baronies, totaling 20 planets for themselves. ",
                                " The real winner though, was the Rex van Der Ostrovski, taking massive claims in the Wallwern subsector as well as annihilating two of the three trade pacts, they have become a dominate player in the southern area of the sector and are starting to give the Trade Federation a run for their money. ",
                                " Escalating threats of war will continue to follow, and the Voices of the Void will keep repeating to you why they're wrong "
                            }),


                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Travellers Aid Society",
                            articleName: "Travellers Aid Society Bulletin -=Univeralis Confederation Bulletin=-",
                            publisher: IslandsSectorPublishers.Travellers_Aid_Society,
                            publicationDate: new TravellerDateTime(07, 05),
                            paragraphs: new List<string>
                            {
                                "3390-05-07^07,07:2'2.North Western Islands has been declared a Red Zone with a travel advisory warning. Pirates are known to operate out of this system, and a series of vessels that departed for this system on salvage operations have been reportedly destroyed. These ships launched from ports including: Coda, Agucaitov, Drillion8JA, Moncut, Struggling, Bodeywak, and Mainhair. Effects on trade routes are understood, and an intern-national committee is being assembled to investigate and resolve the issue. (As of: 07/05/83390)"
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Karl Rostova",
                            articleName:
                            "Following the money, how the Western Islands Alliance unintentionally contributed to the Red-Zone in the Oren Wastes 2 Subsector.",
                            publisher: IslandsSectorPublishers.Voices_From_The_Void,
                            publicationDate: new TravellerDateTime(11, 05),
                            paragraphs: new List<string>
                            {
                                " Only days ago the Travellers Aid Society and Universalis Confederation declared a vital parsec of space for trade a Red Zone, making travel there no long viable, and any ship with travel to a Red Zone in their jump logs is automatically quarantined and searched upon arrival to any new nations star port until the message of their clearance is disseminated throughout the sector. This frankly irresponsible action came in response to poor decisions made by the Western Islands Alliance in support of the newly founded Trade Federation over the planet Coda. ",
                                " Coda used to be controlled by the United Baronies, specifically managed by a local feudal technocracy. This legitimate government was overthrown by Alliance backed rebels, with weapons that were supplied by the very pirates operating out of the Red Zoned parsec, who only became an issue because of the money earned from the sale of these weapons. The money itself was notably supplied by the newly founded Trade Federation, in an attempt to install a government that would support the recently announced reforms. ",
                                " The pro-democracy terrorists were confirmed to be supported by the local Travellers Aid Society base, which was previously reported by local press to actually be a front for the United Federation of Earth's scout services, their foreign intelligence agency. This support included establishing and acting as the middle man for the sale of weapons that would later be used to attack a military base, as well as supplying not only the ship, but a crew able to operate the starship to enter the systems gas giant and retrieve a damaged Alliance destroyer. ",
                                " This alliance destroyer would be combined with a fleet including a known pirate in the system with a bounty of over 3.4 million credits. This terrorists starfleet would attack the defensive fleet of the legitimate government, preventing ruling officials from having the chance to flee. It was noted that one shuttle believed to be of Versian design was detected leaving the planet for the moon, but that is currently unconfirmed. ",
                                " On the ground, using the weapons purchased with Trade Federation funds through the Western Islands Alliance backed Scout Services outpost, the terrorists attacked a major military base, devastating it when a rogue rocket hit a pack of plasma energy packs, destroying a large chunk of the facility and surrounding area. ",
                                " The resulting riots from attack has led to a fall in the previous Coda government, being replaced by the terrorist movement. With the legitimate government being executed on a live streamed video, with the new President-Dictatorial declaring: \"The Previous system was corrupt, for that reason we can not use the previous system to try this man.There is no system in the Universe just enough to try a tyrant such as this.So instead I leave the trial up to his soul with the gods, and I shall act as the driver to deliver him unto their judgement.\" Followed by the president plunging a void-blade into the previous leaders temple. ",
                                " This government overthrow is directly the result of the Alliance and the Federation interference. But that isn't the end of their crimes. The Travellers Aid Society also worked with the aforementioned pirate groups to solicit unsuspecting crews into 'salvage operations' wherein the crews would head to the now Red Zoned parsec under the guise of an ancient Deutschlander worldship being there, and instead be ambushed by pirates. ",
                                " The direct actions of the selfish Trade Federation and the meddling of the Western Islands Alliance in response to the freedom of the baronies, as well as the biggies once again assert their *illegal* control over our systems has once again led only to us suffering. ",
                                " Maybe at some point in the future, the great nations can set aside their petty differences and let us peons who must live in their shadows actually have a chance to take a breath of free air instead of the stifling toxicity of their hatred. "
                            }),
                    }
                );
            }

            return Issue2;
        }
    }
}