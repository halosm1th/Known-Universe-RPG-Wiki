using System.Collections.Generic;
using TravellerWiki.Data.SimpleWikiClasses;

namespace TravellerWiki.Data.VoicesFromTheVoidArticles
{
    public class VoicesIssue5
    {
        public static VoicesFromTheVoidIssue Issue5 = null;
        
        public static VoicesFromTheVoidIssue AddIssue5()
        {
            if (Issue5 == null)
            {

               Issue5 = new VoicesFromTheVoidIssue(
                    issueName: "Stars of the Void",
                    issueDescription:
                    "Stars in the Void is a special issue of Voices in the Void highlighting some smaller, local pieces that may not have otherwise made the major papers.",
                    issueNumber: 5,
                    new List<VoicesFromTheVoidArticle>
                    {

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Kenzie Clark",
                            articleName: "Western Islands Alliance Strengthens Boarders",
                            publisher: IslandsSectorPublishers.Tales_From_The_Tree,
                            publicationDate: new TravellerDateTime(13, 06),
                            paragraphs: new List<string>
                            {
                                "The Western Islands Alliance is tense. People can tell that war is coming. Local outlets report that this is impossible; trade is too important, the economics just aren't there. However, the increasing amount of adverts for joining the military, military and civil dockyards full of workers laying down warships of all sizes and classes, and the larger gatherings of fleets around major Naval ports tell a very different story. ",
                                "Things aren't made better by government stalemating on recent legislation regarding AI rights. Specifically whether conscious and semi-conscious AI and combat robots can choose to object to serving in combat. Currently, the United Federation of Earth aligned ruling party has been supportive of legislation allowing conscientious objection for AI's and other constructs. While the opposition has formed a united front on their objection, pointing to the fact that machines are creations of man, and restraining bolts prevent them from objecting; opponents also cite the stance of so called 'earned freedom' in that their express purpose in construction was combat, so they can be stationed in less combat-oriented roles and serve out a term of duty in repayment for their construction fees, equal to 3 years of human life. However, Government has currently objected to the latter offer on the basis that: it is outside the scope of current legislation, and that the offer rejects the AI's conscious right to object to combat, as it never had a choice in its creation, to suggest such akin to suggesting forced service for any child convinced by soldiers of the government or employees of a corporations. ",
                                "The bill has been divisive among the public, with many of those who support the bill choosing to remove their robots restraining bolts, and some major cities even going so far as to allow robots to rent apartments for their own use. While in opposition controlled cities robots are often forced to maintain their restraining bolts and are not allowed to power down except when absolutely necessary, or must do so in public places in case they are needed. ",
                                "Whether it'll be the AI fighting the Alliance, the people in the alliance fighting one another, or the Alliance fighting the Empire, the Alliance is sure to be fighting a war by the end of the year. "
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Septima Catiana",
                            articleName:
                            "Spiritwood Senate passes vote to Condemn Essig Kritarchy; Cites piracy along major trade-ways",
                            publisher: IslandsSectorPublishers.PrincePeriodical,
                            publicationDate: new TravellerDateTime(24, 03),
                            paragraphs: new List<string>
                            {
                                "The Spiritwood Senate has long been a friend to the Essig Kritarchy. Trade has always been an economic vitality to the Senate, it connects it internally, and that trade forms the foundation of unity needed to keep the Senate protected from the Trade Federations underlings. This same dependency has been what protects the fledgling pirate guild turned nation known as the Essig Kritarchy. ",
                                "However, the Kritarchy has grown desperate. The union between various Trade Consortiums in the subsector has resulted in a shift in the balance of power and unity, which has been negative for the Kritarchy. Their once richly plundered spacelanes are now well patrolled, and the ships travelling them well armed. While the Kritarchy has become known for their mercenary fleets sector wide, especially popular among the kings, the Kritarchy has always depended on the Senate for a route out of the subsector. ",
                                "The Kritarchy rejected this dependency when it decided to attack Senate trade ships travelling from Lavernia to Spiritwood, raiding and destroying several Lavernian science vessels transporting vital research to Spiritwood. Spiritwood has now signed a defense pact with the Southern Trade Consortium. While limited, the pact does specify that the two sides will work together to combat piracy, especially state sponsored piracy. "
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Martha Gorste",
                            articleName:
                            "New Colchis Business Board Votes to Allow Construction of Military Vessels for Outside Nation.",
                            publisher: IslandsSectorPublishers.Whipp_The_Truth,
                            publicationDate: new TravellerDateTime(13, 07),
                            paragraphs: new List<string>
                            {
                                " The New Colchis Business Board was recently given a proposal for construction of 3 dozen military vessels. The order was requested by a third party through the company operating out of the Trade Federation, and thus was sanctioned by the Trade Federation, and would therefore have been rubber stamped through the Board. However, the size of this order stopped it, as well as what it was asking for. ",
                                " The order was calling for 36 ships in total. 10 Corvettes, 4 Destroyers, 4 Light Cruisers, 1 Heavy Cruiser, 1 Carrier with full fighter complement, 3 Fuel ships, 2 Cargo ships, Two Troop Supply ships, 2 Repair ships, 1 Medical ship, and 6 Troop transports. These ships were to be produced with top of the line Laser and Slug cannons constructed in the NCBB, and all the ships were to be equipped with the famous Callin Stellar Imaginators J3 jump Drives. The fleet itself is suspected to cost a small fortune and many speculate as to its true owner. ",
                                " Speculation largely lies in two camps. One says the ships are being purchased by the Count of Acadie for his new fleet, to protect the planet in case of imperial invasion. The other camp says that the ships are being bought by the OIDL to help them construct a new, fast, fleet, which they will then use to make a surprise attack on St. Genevieve(5,3:3'3). The Board itself voted to allow the ships to be constructed, claiming that both theories were horribly inaccurate. "
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Martha Gorste",
                            articleName: "Trade Federation Recovery Underway",
                            publisher: IslandsSectorPublishers.Lickup_The_Facts,
                            publicationDate: new TravellerDateTime(01, 09),
                            paragraphs: new List<string>
                            {
                                "While it may have been months since the plague ended, the disaster is still fresh in many minds. Refugees who fled and survived have slowly begun returning home. The Ex-Capital of the Trade Federation Kerkhoven has begun reconstruction. Other nearby systems are slowly being reclaimed, and stations being repaired. Bidding on colonization rights has already begun, with the lowest bid being 93.3 billion credits to colonize Galien (7,2;4'3), up to 792 Trillion for colonization rights to Knoblick (4,3;4'3).",
                                "People within the Trade Federation are hopeful. The plague has most people on edge, and the recent war to the west has done nothing to ease tensions. Meanwhile in the North refuges from what was the Western Islands Commune are reported to be entering spaceports in droves;many fleeing what are now 'Northern Kingdoms'. ",
                                "People within the Trade Federation are hopeful. The plague has most people on edge, and the recent war to the west has done nothing to ease tensions. Meanwhile in the North refuges from what was the Western Islands Commune are reported to be entering spaceports in droves;many fleeing what are now 'Northern Kingdoms'. "
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Kobos Placek",
                            articleName: "Slaughter on Ranwas leaves 400 Thought-leaders Dead; Lawgarites Suspected",
                            publisher: IslandsSectorPublishers.TheStrategist,
                            publicationDate: new TravellerDateTime(11, 05),
                            paragraphs: new List<string>
                            {
                                " Ranwas(8,3:3'3) was to sanctify a Church-World, to further Sigmars goal of guiding the heathens of this sector with his warmth and light. However, some Lawgarian cultists who are obviously Germushians are suspected to be behind the fowling of this glorious and noble goal. The Lawgarians chose to use their light-gift from Sigmar to steal Sigmar's children from him, to deny them Sigmars guidance to the eternal. The driving force behind this atrocity is clearly the Lawgarian lack of morals, not seeing those who embrace Simgars Light as brothers, but instead as fools guided by a dead-holyman. Of course, they themselves forget their own long since dead founder was himself a follower of Sigmar, and whose writings are still at the heart of their movement. ",
                                " The misguided heathens chose to take the most deadly option available to them, targeting a small mountain monastery dedicated to the education of those who were chosen to sense Sigmar's light the brightest, at the expense of their sensing of the world around them, have been shushed out. Their lives are unable to be guided by Sigmar flame, by a group of 7 Lawgarians, intent on pushing their violent agenda. The Gunmen stole a shuttle from the planet's starport, and went to the Monastery posing as a repair team for the H2O-extractors. Their repairs involved several automatic weapons, which seemed to have been smuggled in from Deutschland, and adding lothin-9, a deadly neuro-toxin to the monastery's water supply. ",
                                " Once the monks and children were having delusions of Lawgar, the gunmen attacked, using high explosives to breach doors and walls, and assault weapons to gun-down any priest who got to close. The Lawgarians destroyed or stole many statues of Sigmar, as well as the funds that had been gathered to be transported to Olitar for the construction of 1000 new Humane Society's for lost Animals. In response to this horrific terrorist attack, the Olitar Protectorate has reaffirmed the requirement for all people within its borders to attend prayers to Sigmar daily, those who are not of the Church of Sigmar are still expected to attend. Punishments for found Lawgarians have been raised from hefty fines to death. A cohort of inquisitors have been dispatched aboard the Battlestar 'Rocens Hope' and will be overseen for several months by Inquisitor Adalwolf Fedorov. "
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Bigos Ambroży",
                            articleName: "Neubayern Topas Alliance Neutrality leading to instability at Home",
                            publisher: IslandsSectorPublishers.ConsortiumNewsNetwork,
                            publicationDate: new TravellerDateTime(03, 08),
                            paragraphs: new List<string>
                            {
                                " The Soviets, the Factories, nay the people, are abuzz with discussion around the latest issue facing the Neubayern Topas Alliance: The War between the Independent Defense Federation (IDF) and Old Islands Defense League (OIDL). Initially the war had little effect on the NTA, which was occupied with the economic fallout of the end of the Acadie Tillium Highway, and dissolution of the Western Islands Commune. ",
                                " That all changed when the 'Most Serene Fleet' departed from the Serendip Belt (2,3:5'3) on route to Topas, having previously received passage permission from the NTA. This permission had been granted without approval from the affected Soviets, and without informing the public that it would be happening. Since then, documents have come out that reveal a large-scale fuel and supply effort was going to be made to support the IDF fleet, and were later dated to have been started about 2 days before the statement about NTA neutrality was released, and finalized with approval 3 days after the statements release. This obviously sets up a clear timeline of public neutrality and private support. Further, the resupply fleet was to be paid for directly to the BundesSluzhbaRazvedki Neubayern-Topas Alliance (BSR-NTA) which is the NTA's foreign intelligence service. Renowned sector wide for their stealth, efficiency and brutality. What the BSR-NTA would do with this extra capital is unknown, but it is sure that it would not assist our fellow workers and children of Sigmar in the Sector. ",
                                " For this reason, the people of the NTA have become divided. The streets, previously filled with united protests against the failing state's ability to pay its laborers a living wage, have been replaced with near-warlike conditions. Barricades separate different camps from one another, At night the various camps start tossing firebombs, rocks, and in some cases stun grenade (and in one particularly deadly attack, a live grenade was thrown into one of the streets which killed seven and wounding dozens more) into one another's camps, while guards along the barricades sit with shoddy rifles and farmers shotguns waiting for their opposition to get close enough. The result is that the NTA is slowly devolving into factionalized trench warfare in the streets. If the state is unable to regain control soon, I foresee a complete collapse of the NTA within 3 years "
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Laurel Glenham",
                            articleName:
                            "Dominate Supreme Announces Funding for 5 new Sith Temples within the Dominate of the Imperial Faith; Construction begins in 3 months; expected to finished in 5;",
                            publisher: IslandsSectorPublishers.The_Imperial_Standard,
                            publicationDate: new TravellerDateTime(15, 10),
                            paragraphs: new List<string>
                            {
                                " His most glorious Imperial Highness the Exalted Dominate Supreme has announced that he has secured funding and support for the creation of Five new Sith Temples to be constructed within the Dominate of the Imperial Faith. This is the first official action taken by the Dominate Supreme with regards to the Imperial Faith, which has until one year from the Thippe Accords (2/05/83391) to separate itself and its assets from the Kotlik Tribunal. ",
                                " The Dominate Supreme has seen it right to call on his fellow Imperials to assist in the spreading of Truth around this sector. To accomplish this the Dominate is not only seeking Darths who will be able to teach in these new Temples, but also on those most loyal Imperials who adhere not only to the law, and the social customs, but also have embraced the Truth of the Sith to aid their Dominate in its goal of spreading the Imperial Faith, in both its spiritual and cultural forms ",
                                " The Dominate of the Imperial Faith was established following the Thippe464 Accords which happened on 2/05/83390. They specified that after 6 months legal control of land would be handed over from the previous legal owner to the new legal owner. The Dominate saw it wise to allow the Imperial Faith 6 extra months to remove Tribunal influences. This more than generous Imperial reward has been besmirched by Federation propagandists perpetuating putrid perforations of the Truth who claim that the (military) Tribunals illegal coup was in fact justified and widely supported by the people. This is however, obviously false, as the Dominate stated during his speech announcing the new Dominate of the Imperial Faith: \"The people of these planets are more citizens of the Dominate then prisoners of a shame Tribunal which every non-rigged poll clearly demonstrates that the people do not support the oppressive military state under-which they are forced to exist; fearing constantly for their lives, that one misplaced word or step could result in them being branded a traitor to the tribunal and 'deported' to the No God Land. ",
                                " In short, the people want this, the Dominate wants this, and the only real opposition are those militant hounds of the unjust Kotlik Tribunal "
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Blakewell Daisy",
                            articleName: "Defense League Stands Strong",
                            publisher: IslandsSectorPublishers.The_Imperial_Standard,
                            publicationDate: new TravellerDateTime(07, 08),
                            paragraphs: new List<string>
                            {
                                " The Old Islands Defense League (OIDL) stands strong in the face of horrific losses. With the destruction of Amondiage some questionably loyal people are asking whether the OIDL can remain. I am here to tell you that yes, we can. Sure, our capital may be destroyed, our Immortal reincarnated Emperor has once again returned to the godly plane from which he descended to guide us, and our primary fleets destroyed, but the OIDL stands strong. ",
                                " In facing this new threat, the OIDL in New Home has kept the western front strong and well defended. Colchis has kept the pressure on the traitorous Acadie, who is unfortunately protected by some fake-Count. Until now, the Dominate Supremius has refused to heed our requests for aid. While our allies, the Venhut Dominate States, have stepped up Gloriously to assist us. With the combined pressure of the League and Dominate States, we will surely crush the IDF dogs, and whatever allies they happen to rope into this romp of a war. "
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Martha Gorste",
                            articleName:
                            "From Commoner to Countess. The story of Favonia Plautis nee Avitus, Countess of Belview.",
                            publisher: IslandsSectorPublishers.Kosses_Kings_Kommandments,
                            publicationDate: new TravellerDateTime(18),
                            paragraphs: new List<string>
                            {
                                " A commoner, Favonia Avitus was born in the Duchy of Jeffers to a Production Worker and an Idea Creator. The latter was lucky enough to be a servant to the old House of Auspex. When the new government took control of the planet, the Duchess fled, the Avitus family, like so many others, fled with them. ",
                                " The family would spend its time serving house Auspex in whatever way they could. Favonia, through her mothers connections, was able to secure a position as a handmaiden to Duchess Silia. Favonia saw the value in such a position and used it to ingratiate herself not only to her Duchess through good service, but also to the other nobles by ensuring the great appearances of the Duchess and by being a conduit through which information was able to flow. ",
                                " When Duchess Auspex was restored her rightful lands, she was quick to reinstate several of her previous title holders. However, the overthrown government had left a new treat for the Duchess, the county of Belview. The Duchess used this county to promote the beautiful Favonia to a titled position in reward for her hard work, while also securing a strong political marriage to the King of Cadyville from a marriage between this loyal courtier and the ninth son of the King of Cadyville. A true love story for the ages. "
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Marha Gorste",
                            articleName: "A Tale of Two Kings; How the Coila Military Alliance was founded. ",
                            publisher: IslandsSectorPublishers.Kosses_Kings_Kommandments,
                            publicationDate: new TravellerDateTime(16, 03),
                            paragraphs: new List<string>
                            {
                                " I was born in the free Kingdom of Coila. My King, the King of Coila, is one of two kings who protects me, and this has been the case for over 35 years. Before then, in the feuding times, the strong King of Escalante bullied the kind King of Coila, while the other kings waited around, ignoring their bullied peer. ",
                                " This situation changed when the Kingdom of Kosse left the Rex van der Ostrovski, after signing the Jeffers-Kosse Trade Pact. This ended the strong Kings need to show his strength by belittling the kind King, and instead began their tenuous friendship. Their newfound friendship was quickly tested when the Rex van der Ostrvoski called upon them for war, declaring that to not join would make them the enemy of the Kings. ",
                                " Neither the kind King of Coila, nor the strong King of Escalante would agree to an unjust war against a lawful succession from the Rex van der Ostrovski. They instead chose to take the fast path and leave the Kings themselves, which led to them becoming the target of the King's fury. The strong King was able to hold his once peers off, while the kind king was able to keep the people at peace, in return the people came to appreciate their kind and strong kings, equal in power, protectors of their realms, but allied in their duty to those same realms by working together to protect them. "
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Seryogin Miron",
                            articleName: "No God Land Confirms Renunciation of the Church of Sigmar",
                            publisher: IslandsSectorPublishers.ConsortiumNewsNetwork,
                            publicationDate: new TravellerDateTime(03, 09),
                            paragraphs: new List<string>
                            {
                                " When the Western Islands Commune was dissolved, it fell apart into two major regions, the Rex van der Sever and the No God Land. In the 6 months after the accords, the Commune was formally dissolved, Chairman of the Executive Committee Stalinski stepped down, and his successor oversaw the signing of the treaty that allowed newly titled Kings to choose to leave the Greater Commune by popular referendum. ",
                                " After the Rex van der Sever took their titles and left, what remained was that which would become the 'No God Land'. The supposed leader and founder of this new nation, Faith Wiley, has not been seen since the signing of the Thippe464 accords, and left only one overriding commandment for her new nation, that it be a 'No God Land' which the Central and Executive Committee's of the transitionary Government chose to interpret as not only a strict separation of Church and State, but the complete banishment of religion from both the State and the Nation, which was done by renouncing the Communes ties to the Church of Sigmar. ",
                                " Public response has been mixed to negative. Most of the public had either been born into or had converted to the Church of Sigmar themselves, and thus find the new binding law banishing their practicing of religion punishing. Others however, argue that the new law is in fact liberating, as the people will be freed from the oppressive drug that is religion, and instead able to fill their mind not with worthless fantasies but with science and knowledge. ",
                                " Following the transition from Commune to No God Land, the new constitution enshrined the national and state religion as a form of atheism. The comrades who make up the No God Land have begun campaigning against these reforms; their protests always end the same way: massacre. The last of which ended with 193 comrades dead after they simply gathered in front of their prayer house and attempted to utter a hymn to Sigmar. Thus far, the church has been slow to make any statement. The Inquisition has declared that any Light-Seers or servants of the Light who are harmed will be avenged with maximum fury. As well, the church has said that church owned buildings will be defended by their Light-Seers, flock, and any Sigmarines who are in the area. What bloodshed lies next for Sigmars children is unknown, nor is what will happen to the fleeing refugees from what was once the Commune, or how the Church itself will continue to respond. "
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Lurio Bantia",
                            articleName: "Red Rock Republic Votes Reduces Refugees",
                            publisher: IslandsSectorPublishers.ConsortiumNewsNetwork,
                            publicationDate: new TravellerDateTime(23, 08),
                            paragraphs: new List<string>
                            {
                                "The dissolution of the Western Islands Commune has affected every nation differently. For some, it has allowed them to grow and prosper. For others, it has caused them to freeze and stall. For Red Rock, it has been complicated. ",
                                "The Red Rock Republic considers itself Liberal. It is tolerant of others, it accepts everyone and offers them citizenship in return for minor service, and it believes strongly in its republican values. So when the value of liberalism and accepting refugees from the Commune as it falls apart, the answer seems obvious, of course let them in! They help our labor market, they fill jobs, and do good things, and we've always been supportive to those refugees fleeing the Communes oppression, nevermind that immigration from the Trade Federation has long been a source of new citizens; the obvious answer is: Let them in. ",
                                "But this obvious answer becomes hard to maintain when the 10th refugee ship this week arrives at Red Rock; when the smallest of these jump capable craft, a barely 100-Ton ship strapped with the essentials to use a J1 drive, is filled with 20-50 people crammed together in there, pushing whatever O2 system is has well beyond the max, nevermind the food or water requirements; when the refugees make up 3% of the population of your largest planet, both in literal size and population size; is the answer still that obvious? This has been the debate ravaging dinner tables and offices for the past four months. That debate has ended today with the final tallying of the Republic Wide policy evaluation, and the results are in: we need to change our answer. What this looks like for the Red Rock Republic remains unknown, but at this time, the debate seems to be limited around how to best manage the situation on the home front, and what can be done internationally to help. "
                            }),

                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Ursacius Nasica",
                            articleName: "The Story of an up and coming pirate, Blaski",
                            publisher: IslandsSectorPublishers.Tales_From_The_Tree,
                            publicationDate: new TravellerDateTime(14, 04),
                            paragraphs: new List<string>
                            {
                                " Born in the northern Trade Consortium (now Trade Federation), Guza Blaski was leaving his home planet of Goldrun heading to Trevorton when the free trader he was travelling on was held for ransom by some Essig Pirates. Blaski asked them if they could use a hand, which they honorably and eagerly accepted. Blaski was quickly welcomed among the crew as they returned home to Essig. However, while attacking a freighter carrying 40 million credits, Blaski was badly wounded when leading a raiding party on board the freighter and took a shotgun blast to his left leg, he was then left for dead. ",
                                " Blaski recovered however, and was able to join aboard another Essig Pirate ship, this time heading north to the Commune to do some raiding. The group came across the discovery that a church on Skandia (1,3:4'7) held numerous valuable works of art and relics from the pre-commune days; the pirates chose to liberate these valuable positions for the public. Blaski famously kicked in the doors to the church, his right hand clutching a Power-Rapier, left holding an automatic shotgun, taking down the Light-Seer's guarding the door to prevent any townsfolk from escaping, and then blasting the the Master Light-seer conducting the service. ",
                                " Blaski's next raid didn't go as well. Instead of a triumphant battle, the next plan required stealth, one of Blaski's more lacking skills. As a result of his lack of ability to keep quiet, and tossing multiple grenades into the town's food supply, blowing the large granary apart and setting the town ablaze, Blaski lost the posting he had secured. But blessed are the fates for Blaski, as another group of Pirates heard about the failed attack and chose to make their own attempt. Thanks to Blaski's damage the second group was much more successful, and even rescued Blaski, taking him aboard their ship. ",
                                " The two recent Captains of Blaski recently met each other, and decided to settle their differences with a small exchange of laser and missile fire, ending with a boarding party led by Blaski's old captain. Who agreed to let his old crewmate off in exchange for the Captain never seeing Blaski again. Blaski was quick to accept the deal and has seemingly fallen out of the Kitarchy's eyes, but no true pirate can resist spaces endless call forever "
                            }),
                        new VoicesFromTheVoidArticle(
                            articleAuthor: "Teagan Hendrix",
                            articleName: "Star-Can Confederacy debate rages over ship procurement.",
                            publicationDate: new TravellerDateTime(19, 06),
                            publisher: IslandsSectorPublishers.Tales_From_The_Tree,
                            paragraphs: new List<string>()
                            {
                                "Within the Star-Can Confederacy a debate overtake most of the 4.5 million citizens lives, revolving around the expensive question of military ship procurement. While everyone agrees the Confederacy needs some form of anti-piracy task-force, no one can agree on what it should look like.",
                                "The first plan, which was proposed by the current ruling government, would see the Confederacy spend 1 Billion Credits, the majority would be going to 4 system patrol ships (equipped with both missile and beam laser turrets, and a j3 drive), but there is a hefty investment in 8 scout/courier ships (each with a single twin beam-laser turret and j1 drive). The plan generally focuses on using the scout ship for inter-system defense while the larger patrol ships would do as their name suggests and _patrol_ the border lands. The key goal of the plan is anti-piracy measures, with the Government admitting that the fleet would have limited effect in a battle against neighboring hostile forces.",
                                "The second plan, coming from the opposition, focuses on defense over anti-piracy measures, with a heavy investment into a single FER-DE-LANCE class destroyer which would be imported as a downgraded ship from the nearby United Federation of Ship, as well as two smaller Gazelle class close-escorts, with a deployment strategy that would see the destroyer left in Sidebrook(2,3:3'1) while each of the escorts would be deployed in nearby systems.",
                                "The debate now rages over the question of whether the fleet's purpose is the defense of the Confederacy, or the protection of trade/anti-piracy measures. The opposition has thusfar been on the offensive, focusing on the lack of military defense in a time of escalating conflict, while Government has been aruging that their priority should be in trade, and that if a war were to come, without the support of the nearby Mainhair Military Republic, Western Islands Alliance, and Independent Defense Federation, the Confederacy would fall quickly to any real threat. Thus the government should focus on the threat it _can_ handle while letting the big players fight it out with each other."
                            }
                        ),
                        new VoicesFromTheVoidArticle(
                            articleAuthor:"Jasrellius Nymus",
                            articleName: "Pro God-Land terrorist attack against Daycare on Kingdom of Hermleigh(5,5:1'3); 1 child & both attackers dead.",
                            publicationDate:new TravellerDateTime(23,07),
                            publisher: IslandsSectorPublishers.Kosses_Kings_Kommandments,
                            paragraphs: new List<string>()
                            {
                                "In a rather unexpected incident, a the Kingdom of Hermleigh(5,5:1'3) suffered a terror attack at a daycare next door to a Sigmarian Temple and an Amphetemine production facility.",
                                "The attack happened at 3:52pm Local Time, after the two assailants entered the neighboring Sigmarian Temple, demanding to know the location of a child staying in the temple. When the Temple refused, the terrorists exited the building, entering the daycare next door. ",
                                "Upon entering the daycare, the older of the two attackers demanded to know the location of a patience corridor, while the younger attacker left the building to guard it from police. When the mom-bots refused, the attacker drew their weapon and attempted to disable the entry mom-bot, but failed instead brutally obliterating a toddler.",
                                "After firing, the other assailant seemed to begin to run away, before deciding to change course and return to aid their ally, firing a hand-gun round at the older terrorist, hitting them. The Older terrorist swung aronud, raising his own, larger laser rifle, and fired at his friend, failing to wound him.",
                                "The two continued to exchange fire until station authorities arrived and attampted to take the two into custody. The Both Terrorists attacked the stations security team, but both failed to kill any station personnel. The two attacked seemingly in order of their ages, with the older first being decimated by gunfire, which gave the younger terrorist a moment to shout \" Hail Lithia! \"",
                                "Lithia(7,6:1'2) is known to be small trade-depo, which is now a part of the No God Land. The Planet recently featured in local newspapers for accidentally shipping out expired food, as well as a recent economic slowdown believed to be brought on by the increased autonomy of the post-Commune systems.",
                                "The attackers share little in common, both are believed to have been Versian due to their language, the younger one was wearing Fifth Empire Islands Expeditionary Force Military Combat Armour, and the older one made mention of returning to prison. So far, the Expeditionary Force has denied any involvement or relation to the terrorists and the Fifth Vers Empire has only stated that both left Imperial Lands at least 3 years ago, and the Empire had no information about them since.",
                                "Overall, this attack was a small event, that while concerning, is only one in a recent trend of anti-Sigmarian attacks. Whether these attacks are related to the rumours of the Church hiding Agents of the Communist Empire of the Deutchland or simply more anti-Sigmarian bigotry that has been on the rise since both the End of the Commune, and the End of the last Great War, has yet to become clear."
                                
                            }),
                            });
            }

            return Issue5;

        }
    }
}