using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WikiServices.SimpleServiceDriverCode;

namespace WikiServices.DataServices
{
    public enum HighVersianLetters
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Z
    }

    public class HighVersianService
    {
        public List<HighVersianLetters> Letters() {
        var values = Enum.GetValues(typeof(HighVersianLetters));
            var letters = new List<HighVersianLetters>();
            foreach (var val in  values)
            {
                letters.Add((HighVersianLetters) val);
            }

            return letters;
        }
        
        public string GetLetterProunciation(HighVersianLetters letter)
            => letter switch {
            HighVersianLetters.A => "a as in [a]pple",
            HighVersianLetters.B => "B as in [B]eta",
            HighVersianLetters.C => "Ch as in [Ch]ase",
            HighVersianLetters.D => "D as in [D]emand",
            HighVersianLetters.E => "e as in B[e]t",
            HighVersianLetters.F => "F as in [F]it",
            HighVersianLetters.G => "G as in [G]ust",
            HighVersianLetters.H => "H as in [H]ot",
            HighVersianLetters.I => "E  as in [E]at",
            HighVersianLetters.J => "J as in [J]oin",
            HighVersianLetters.K => "K as in [C]a[K]e",
            HighVersianLetters.L => "L as in [L]ibrary",
            HighVersianLetters.M => "M as in [M]an",
            HighVersianLetters.N => "N as in [n]o",
            HighVersianLetters.O => "O as in [O]pen",
            HighVersianLetters.P => "P as in [P]eel",
            HighVersianLetters.Q => "Q as in [Qu]iet",
            HighVersianLetters.R => "R as in [R]ide",
            HighVersianLetters.S => "S as in [S]tand",
            HighVersianLetters.T => "T as in [T]iberius",
            HighVersianLetters.U => "U as in F[U]me",
            HighVersianLetters.V => "V as in [V]ictor",
            HighVersianLetters.W => "W as in [W]hile",
            HighVersianLetters.X => "S as in [S]teal",
            HighVersianLetters.Z => "Z as in [Z]eta",
            _ => $"{letter} is unknown"
        };

        public  List<HighVersianDefinition> Prefixes { get; } = new List<HighVersianDefinition>
        {
            new HighVersianDefinition("Apoc","Absolute, complete, total"),
            new HighVersianDefinition("Ae","Very/Extremely Long"),
            new HighVersianDefinition("Oe","Very/Extremely short"),
            new HighVersianDefinition("Ard","Burning"),
            new HighVersianDefinition("Auct","Authority / Commander / Author"),
            new HighVersianDefinition("Cen","Hundred"),
            new HighVersianDefinition("Ci","Skin, Flesh, Physical"),
            new HighVersianDefinition("Com","Mix, combined, added to (generally an object)"),
            new HighVersianDefinition("Con","With, Together"),
            new HighVersianDefinition("Bon","Good"),
            new HighVersianDefinition("De","God/Heavenly/Godly"),
            new HighVersianDefinition("Dec","Ten"),
            new HighVersianDefinition("Di","Two"),
            new HighVersianDefinition("Dom","Home, hearth, house"),
            new HighVersianDefinition("E","Without, lacking."),
            new HighVersianDefinition("Ex","From (coming from), the place of begining, start; point of origin."),
            new HighVersianDefinition("Em","Combined / Shared (generally a person)"),
            new HighVersianDefinition("Ext","Extinguish, end, finish"),
            new HighVersianDefinition("Fi","Child, offspring"),
            new HighVersianDefinition("For","Very, greatly"),
            new HighVersianDefinition("Ign","Warm/Hot/Warmth"),
            new HighVersianDefinition("Il","False, wrong"),
            new HighVersianDefinition("Im","Large, in great amount"),
            new HighVersianDefinition("In","Small, in little amount; not"),
            new HighVersianDefinition("Mal","Sick, wrong, perverted, badly, poorly"),
            new HighVersianDefinition("Max","Maximum, largest, greatest"),
            new HighVersianDefinition("Med","Mediate, intervene, heal, remedy"),
            new HighVersianDefinition("Mel","Thousand; millenium"),
            new HighVersianDefinition("Mil","Million"),
            new HighVersianDefinition("Min","Smallest, lowest, minimum"),
            new HighVersianDefinition("Mis","A little/small"),
            new HighVersianDefinition("Mol","Craft/Construct/Design/Create"),
            new HighVersianDefinition("Mor","Lots, plentiful"),
            new HighVersianDefinition("Mut","Mutate, change, modify"),
            new HighVersianDefinition("Ni","Nine"),
            new HighVersianDefinition("Okt","Eight"),
            new HighVersianDefinition("Pi","Five"),
            new HighVersianDefinition("Post","After, behind, back"),
            new HighVersianDefinition("Red","Again"),
            new HighVersianDefinition("Sal","Safe, Secury, saved, protected"),
            new HighVersianDefinition("San","Without, lacking, non"),
            new HighVersianDefinition("Se","Six"),
            new HighVersianDefinition("Sep","Seven"),
            new HighVersianDefinition("Ton","Stretching or extending"),
            new HighVersianDefinition("Tri","Three"),
            new HighVersianDefinition("Turb","Disturbance, disruption, trouble, stir"),
            new HighVersianDefinition("Un","One"),
            new HighVersianDefinition("Vesti","Energy/Current/Electricity"),
            new HighVersianDefinition("Vis","Void Power/Energy/Raw potential"),
            new HighVersianDefinition("Vri","Four"),
            new HighVersianDefinition(" ","No prefix"),
            new HighVersianDefinition("Som","Sleep, asleep, sleeping"),
            new HighVersianDefinition("Omn","All"),
            new HighVersianDefinition("Pat","Father"),
            new HighVersianDefinition("Mat","Mother"),
            new HighVersianDefinition("Da","Of/From [ie House OF Allusia]"),
            new HighVersianDefinition("Ne","Not, no"),
            new HighVersianDefinition("Vet","Old, elder"),
            new HighVersianDefinition("Dae","Daemonic, having to with daemons"),
            new HighVersianDefinition("Dem","Demonic, having to do with demons"),
            new HighVersianDefinition("Del","Devil in nature, having to do with devils"),
            new HighVersianDefinition("Ve","To, a function prefix to indicate something which does a thing, is moving towrds a thing, or other uses of the word To."),
            new HighVersianDefinition("Pro","Top, highest, best")
        }.OrderBy(x => x.Letters.First<char>()).ToList();

        public List<HighVersianDefinition> Roots { get; } = new List<HighVersianDefinition>()
        {
            new HighVersianDefinition("Aedific","Build/Craft/Create"),
            new HighVersianDefinition("Ac","Threat, Attack, Action"),
            new HighVersianDefinition("Akw","Water/liquid"),
            new HighVersianDefinition("Amet","Expanding"),
            new HighVersianDefinition("Amic","Familiar, friend (possibly pet)"),
            new HighVersianDefinition("Ant","Smell/oder OR Lingering, waiting, slow, delayed, hindering"),
            new HighVersianDefinition("Alac","Fast/quickly"),
            new HighVersianDefinition("Alypse","destruction, elimination, remove, decimate"),
            new HighVersianDefinition("At","Marked, noted "),
            new HighVersianDefinition("Aur","Around/Air/Gas"),
            new HighVersianDefinition("Beautit","Beautiful, Brilliant, elegant"),
            new HighVersianDefinition("Bul","A place where people or things gather or are stored"),
            new HighVersianDefinition("Cael","Soul / Spirit"),
            new HighVersianDefinition("Cand","Bright, torch or light"),
            new HighVersianDefinition("Catr","Cut, remove, slash"),
            new HighVersianDefinition("Centr","Center, middle, core"),
            new HighVersianDefinition("Creatur","Animals or Creatures with low intelligence,"),
            new HighVersianDefinition("Damn","Hurt/Damage/Pain"),
            new HighVersianDefinition("Daz","A daze, stunned, shocked"),
            new HighVersianDefinition("Disc","Study / Learn / Information"),
            new HighVersianDefinition("Dol","Trick, lie, illusion"),
            new HighVersianDefinition("Edict","Edict, commandment, law, order"),
            new HighVersianDefinition("Element","Element(generally natural, can refer to planes, or periodic elements) "),
            new HighVersianDefinition("Embresc","Darkness, especially nighttime or the darkness of night"),
            new HighVersianDefinition("End","Length, time, distance"),
            new HighVersianDefinition("Eric","Mercy, kindness"),
            new HighVersianDefinition("Et","and"),
            new HighVersianDefinition("Exit","Leave / Destroy"),
            new HighVersianDefinition("Fantas","fake, unreal, an illusion (or image)"),
            new HighVersianDefinition("Flux","Change"),
            new HighVersianDefinition("Fum","decomposing, dead, corpse"),
            new HighVersianDefinition("Fur","Furious, Angry, enraged"),
            new HighVersianDefinition("Gemma","Jewel, Gem"),
            new HighVersianDefinition("Gen","Related, similar, alike"),
            new HighVersianDefinition("Guin","Blood"),
            new HighVersianDefinition("Homin","A person/human or something with high intelligence"),
            new HighVersianDefinition("Integr","integrate, mix, combined"),
            new HighVersianDefinition("Itr","Thunder, straining of rope, breaking of something "),
            new HighVersianDefinition("Lat","Large, wide, big, width"),
            new HighVersianDefinition("Lect","Chosen, selected, picked "),
            new HighVersianDefinition("Liquid","Liquid"),
            new HighVersianDefinition("Lus","Play, Preform, etc"),
            new HighVersianDefinition("Mandat","Law/Command/Order"),
            new HighVersianDefinition("Mens","Brain/mind/thoughts  "),
            new HighVersianDefinition("M","A person, singular"),
            new HighVersianDefinition("Midab","strength of character or muscle. Muscle Mass"),
            new HighVersianDefinition("Mult","Multiply, increase"),
            new HighVersianDefinition("Necess","Need, necessary, require"),
            new HighVersianDefinition("Orit","To say or speak, orate"),
            new HighVersianDefinition("Par","Leader/Master/Head of Unit/Group"),
            new HighVersianDefinition("Plant","Plant/Tree"),
            new HighVersianDefinition("Pert","Part or Piece"),
            new HighVersianDefinition("Posit","An idea or theory, which is assumed to be true; A core element or component"),
            new HighVersianDefinition("Pron","Prone, fallen, down"),
            new HighVersianDefinition("Propr","Proper, the correct way"),
            new HighVersianDefinition("Pur","Pure, clean, safe"),
            new HighVersianDefinition("Putrid","Disgusting, ruined, destroyed"),
            new HighVersianDefinition("Robor","Strengthen or hence, encourage"),
            new HighVersianDefinition("S","Agree, yes, affirmative"),
            new HighVersianDefinition("Sil","Sail, jump, leap, bounce"),
            new HighVersianDefinition("Simil","Similar, A like, likewise"),
            new HighVersianDefinition("Sonit","Song, Sonnet, music, sound, noise"),
            new HighVersianDefinition("Spat","Void, Beyond Stars / Space"),
            new HighVersianDefinition("Spir","Breath, blow, breath, (figurative as well as literal)"),
            new HighVersianDefinition("Stellar","Space / Stars"),
            new HighVersianDefinition("Vers","Home, Planet, Capital, (Like Earth) "),
            new HighVersianDefinition("V","By, (through) [we travelled BY starship; inspired BY hope]"),
            new HighVersianDefinition("Ulent","Full of, abounding in"),
            new HighVersianDefinition("Umbr","Darkness"),
            new HighVersianDefinition("Tu","Body, person (corpse)"),
            new HighVersianDefinition("Ting","Touch"),
            new HighVersianDefinition("Terr","Rock/Earth/Dirt/Metal"),
            new HighVersianDefinition("Tend","Tender, showing care"),
            new HighVersianDefinition("Ten","Tenacious, firm, steadfast, unyielding"),
            new HighVersianDefinition("Tal","Distinguish, excellent"),
            new HighVersianDefinition("Tag","Disease, sickness, plague"),
            new HighVersianDefinition("Lad","Steal, take"),
            new HighVersianDefinition("Sanct","Sacred, Holy, divine, religious"),
            new HighVersianDefinition("Glad","Sword, Blade, etc"),
            new HighVersianDefinition("Siens","Knowing, understanding"),
            new HighVersianDefinition("Armor","Armour, protective clothing"),
            new HighVersianDefinition("Arm","Clothing"),
            new HighVersianDefinition("Thron","Throne, head seat, master-chair"),
            new HighVersianDefinition("En","In/at/from/upon/within/under/while/during"),
            new HighVersianDefinition("Qies","Rest/sleep/ To stop. (pronounced quies)"),
            new HighVersianDefinition("Castell","Castle"),
            new HighVersianDefinition("Libr","Book/text"),
            new HighVersianDefinition("Qod","Which; Because; Until"),
            new HighVersianDefinition("Qom","Whose,"),
            new HighVersianDefinition("Ips","himself/herself/itself/being"),
            new HighVersianDefinition("Bell","War"),
            new HighVersianDefinition("Vid","See/View"),
            new HighVersianDefinition("Quit","Quit, stop, leave"),
            new HighVersianDefinition("Orbit","Orbital, in space, or around an object or planet."),
            new HighVersianDefinition("Mag","Magic."),
            new HighVersianDefinition("tern","Period or Length of time"),
            new HighVersianDefinition("El","Battle, conflict, engagement."),

        }.OrderBy(x => x.Letters.First()).ToList();
        
        public List<HighVersianDefinition> Postfixes { get; } = new List<HighVersianDefinition>()
        {
            new HighVersianDefinition("A","An object or thing"),
            new HighVersianDefinition("e","A group/Plural"),
            new HighVersianDefinition("i","A person, singular, generally the speaker / First Person"),
            new HighVersianDefinition("o","Present tense / at the moment"),
            new HighVersianDefinition("u","For someone else, a person but not the speaker, the person being spoken of/to (can be second person but more often refers to the third person)"),


            new HighVersianDefinition("ia","A person using or experiencing an object"),
            new HighVersianDefinition("ea","A group using or experiencing an object"),
            new HighVersianDefinition("oa","A object currently doing something; an objecting being used by another object"),
            new HighVersianDefinition("ua","Someone else using an object"),


            new HighVersianDefinition("ae","A group of objects"),
            new HighVersianDefinition("ie","A group of people, a group of leaders, the speakers group"),
            new HighVersianDefinition("oe","Happening in the present moment to a group"),
            new HighVersianDefinition("Ue","A group who works for someone else, a group acting for someone else"),


            new HighVersianDefinition("ai","A person using an object"),
            new HighVersianDefinition("ei","The persons group"),
            new HighVersianDefinition("oi","The thing which the person is presently doing"),
            new HighVersianDefinition("ui","The person being spoken to"),


            new HighVersianDefinition("ao","An object presently doing"),
            new HighVersianDefinition("eo","A group presently doing"),
            new HighVersianDefinition("io","I am person who is currently / presently doing"),
            new HighVersianDefinition("uo","You are/someone is currently doing / Second Person"),


            new HighVersianDefinition("Au","An object of the other person or party"),
            new HighVersianDefinition("eu","A group with the other person; the other persons group"),
            new HighVersianDefinition("iu","Me to you, my group to your group. "),
            new HighVersianDefinition("ou","Your current group, your group is actively"),


            new HighVersianDefinition("Al","An object which is"),
            new HighVersianDefinition("El","A group which is"),
            new HighVersianDefinition("Il","A person who is"),
            new HighVersianDefinition("Ol","Which is currently"),
            new HighVersianDefinition("Ul","Another who is"),

            new HighVersianDefinition("Am","An object being used"),
            new HighVersianDefinition("Em","A group being used/multiple things being used"),
            new HighVersianDefinition("Im","A person being used, working"),
            new HighVersianDefinition("Om","Actively in use, being done / current / happening presently"),
            new HighVersianDefinition("Um","Devoted to / In service of / Sent on behalf of; Or the listening being used/being told what to do"),

            new HighVersianDefinition("Iam","My ROOT is in use. I’m in use by my ROOT"),
            new HighVersianDefinition("Iem","I am using my group of ROOT"),
            new HighVersianDefinition("Iom","I am using my ROOT"),
            new HighVersianDefinition("Ium","You are using my ROOT; I am using your ROOT"),

            new HighVersianDefinition("An","The area taken up by an object, the objects ‘space’"),
            new HighVersianDefinition("En","The area taken up by of a group"),
            new HighVersianDefinition("In","The area taken up by a person, a persons ‘place’"),
            new HighVersianDefinition("On","An area in use, the active use of an area"),
            new HighVersianDefinition("Un","The area taken up, used by, or occupied by someone else."),

            new HighVersianDefinition("Ar","The thing which does a job"),
            new HighVersianDefinition("Ir","The person who does a job or role"),
            new HighVersianDefinition("Or","A job or role"),
            new HighVersianDefinition("Er","A group of jobs/roles"),
            new HighVersianDefinition("Ur","The listeners role or job"),

            new HighVersianDefinition("Aor","An object which does/is doing a job or role"),
            new HighVersianDefinition("Eor","A group who does or is doing the root job or role"),
            new HighVersianDefinition("Ior","A person (generally the speaker) who does/is doing the root job"),
            new HighVersianDefinition("Uor","Someone who does or is doing a job or role, generally the listener"),

            new HighVersianDefinition("Are","A group of objects which do a role"),
            new HighVersianDefinition("Ere","A super group, larger category, a group of groups/jobs"),
            new HighVersianDefinition("Ire","A group of core people who do a role, your peers role"),
            new HighVersianDefinition("Ore","Their current purpose; actively doing"),
            new HighVersianDefinition("Ure","The role of the group of listeners"),

            new HighVersianDefinition("As","A group of things/objects"),
            new HighVersianDefinition("Es","A group of, plural"),
            new HighVersianDefinition("Is","An organization/group of people"),
            new HighVersianDefinition("Os","A group presently doing"),
            new HighVersianDefinition("Us","Devote to or in service of a group or organization"),

            new HighVersianDefinition("At","To make an object more ROOT"),
            new HighVersianDefinition("Et","To make a group of / To make a group of somethings ROOT"),
            new HighVersianDefinition("It","To make a person more ROOT"),
            new HighVersianDefinition("Ot","To actively make more ROOT"),
            new HighVersianDefinition("Ut","To make another person ROOT"),

            new HighVersianDefinition("Aos","A group of objects which are doing something"),
            new HighVersianDefinition("Eos","A group of groups which is currently doing something; An organization"),
            new HighVersianDefinition("Ios","A group of people doing something, the active tense of a group of people"),
            new HighVersianDefinition("Ors","A group whose job or role which is ROOT"),
            new HighVersianDefinition("Urs","The listeners job/role or the third persons job or role which is actively doing ROOT (their job, your job)"),


            new HighVersianDefinition("Anda","Enlarge, widen, increase an objects area"),
            new HighVersianDefinition("Ate","Simple past / past Present tense "),
            new HighVersianDefinition("Ens","Present Active Tense/Participate"),
            new HighVersianDefinition("Ili","A person who is dedicated or devoted to (focused, specialized)"),
            new HighVersianDefinition("'","Denotes male/masculine. [quickly stop the last sound]"),
            new HighVersianDefinition(";","Denotes female/feminine. [have the last sound go on for a moment longer]"),
            
            new HighVersianDefinition("Eas","A group using a group of objects."),
            new HighVersianDefinition("Ias","A person using a group of objects."),
            new HighVersianDefinition("Oas","The group of objects which are in use."),
            new HighVersianDefinition("Uas","Someone else using a group of objects."),
            
            new HighVersianDefinition("Ais","A group of people using an object. "),
            new HighVersianDefinition("Eis","The speaker’s group of people using another group."),
            new HighVersianDefinition("Ois","The thing in use by the speakers’ group."),
            new HighVersianDefinition("Uis","The person being spoken to by the speakers’ group."),

        }.OrderBy(x => x.Letters.First()).ToList();


        private static List<HighVersianDefinition> HighVersianWordDefinitions()
        {
            var text = new List<HighVersianDefinition>()
            {
                new HighVersianDefinition("Aedificata","An object or thing which builds. (Factory)"),
                new HighVersianDefinition("Aedificate","Build"),
                new HighVersianDefinition("Aedifici","A person who builds"),
                new HighVersianDefinition("Aedificis","A group of yous' which builds (construction company)"),
                new HighVersianDefinition("Awka","Water"),
                new HighVersianDefinition("Awke","An Ocean"),
                new HighVersianDefinition("Awki","(I am) A person from the sea / ocean / water area."),
                new HighVersianDefinition("Awko","Water flowing/ A stream / River"),
                new HighVersianDefinition("Awku","(someone who is) a person from the sea / ocean / water world."),
                new HighVersianDefinition("Amet","Expanding/Growing"),
                new HighVersianDefinition("Amicus","Pet/Devoted friend/Significant Other"),
                new HighVersianDefinition("Alacer","A group devoted to going quickly"),
                new HighVersianDefinition("Apocalypseia","A person who experiences absolute and total destruction or ruin; an apocalypse."),
                new HighVersianDefinition("Apocproru","(You are/were) Absolute or completely proper. Good."),
                new HighVersianDefinition("Ardens","Burning"),
                new HighVersianDefinition("Auctoritas","A person whose job it is to speak with authority, the commander."),
                new HighVersianDefinition("Aura","Around / Air / Gas"),
                new HighVersianDefinition("Aure"," A group of gasses/A cloud"),
                new HighVersianDefinition("Auri","Drug Addict (Literal: Air Person)"),
                new HighVersianDefinition("Auro","Farting or the act of gas moving"),
                new HighVersianDefinition("Auru","Air Person / Pilot"),

                new HighVersianDefinition("Beautitas","A group of things/objects which are beautiful"),
                new HighVersianDefinition("Caeles","A group of souls."),
                new HighVersianDefinition("Caeli","A spirit / Soul (Ghost)"),
                new HighVersianDefinition("Caelum","In service to the (real of) souls"),
                new HighVersianDefinition("Candor","A candle. Or can be a derogatory term for teacher, thinker, scientist, etc."),
                new HighVersianDefinition("Centrum","in the Center, in the middle, centered on something"),
                new HighVersianDefinition("Cicatris","A group who cuts skin; a group of scars people; a mob"),
                new HighVersianDefinition("Compositae","To combined together two base objects / element / ideas into a new object or idea or element"),
                new HighVersianDefinition("Contagios","A plague, disease, or illness, which is actively being spread. (Literal: A group of people with a disease or plague)"),
                new HighVersianDefinition("Contagiosis","An organization or group of people who are spreading a disease or plague. (Literal: An organization of a group of people with a disease or plague)"),
                new HighVersianDefinition("Contingens","Contingent, waiting for, possible. (Literal, with an active touch, with a push)"),
                new HighVersianDefinition("Creaturae","a group of low intelligence creatures"),
                new HighVersianDefinition("Damno","To damage; To damn someone, to demand someone’s present destruction; "),
                new HighVersianDefinition("Damnum","Devoted to or in service of destruction"),
                new HighVersianDefinition("Daze","A group which is Shocked, stunned, dazed"),
                new HighVersianDefinition("Dazi","A person who is shocked on stunned"),
                new HighVersianDefinition("Deor","God/Godly"),
                new HighVersianDefinition("Dees","The Gods/Gods"),
                new HighVersianDefinition("Deorum","In the service of Gods"),
                new HighVersianDefinition("Dilata","Increase the possible area of an object, double the range"),
                new HighVersianDefinition("Dilatanda","Double the actual area of an object, double its width"),
                new HighVersianDefinition("Disco","(Active) to learn/Study"),
                new HighVersianDefinition("Dolum","A person who plays a trick, a person involved in a joke or prank; trickster"),

                new HighVersianDefinition("Domemparior","Lord (Literal: Commander of the shared house) "),
                new HighVersianDefinition("Demil","The person who is godly; the divine person;"),

                new HighVersianDefinition("Elementum","Working for an element. Serving an element"),

                new HighVersianDefinition("Emparar","The Crown "),
                new HighVersianDefinition("Emparir","A Emperor / The Emperor"),
                new HighVersianDefinition("Emparior","The person who does the job of shared leader; (The) Emperor"),
                new HighVersianDefinition("Emparor","The Role of Emperor"),

                new HighVersianDefinition("Equitar","The armour of a Knight"),
                new HighVersianDefinition("Equitir","A Knight"),
                new HighVersianDefinition("Equites","Knights"),
                new HighVersianDefinition("Equitor","(The) Knight"),

                new HighVersianDefinition("Extendere","Extend, increase the length (generally in time) (Literal: the end length of the group of groups)"),

                new HighVersianDefinition("Exvers","From the Home (cultural/spiritial/social home; not literal)"),

                new HighVersianDefinition("Exit","Left, evacuated, exited"),
                new HighVersianDefinition("Exita","Exit, doorway, (Literal: The object exit) ; Death, died"),
                new HighVersianDefinition("Exite","Exits, multiple exits"),
                new HighVersianDefinition("Exiti","I exit, I leave"),
                new HighVersianDefinition("Exito","To leave, to exit. Active form of exit; Dying (leaving life)"),
                new HighVersianDefinition("Exitu","You exit, you leave, they exit"),
                new HighVersianDefinition("Exitium","A person who is devoted to destruction/The Abyss"),

                new HighVersianDefinition("Extinguere","Extinguish, snuff out light (Literal: End / Extinguish a group of fires for someone else’s)"),

                new HighVersianDefinition("Fantasia","A person experiencing a fake image/illusion or sensation"),
                new HighVersianDefinition("Fluxa","Fleeting (Literal: A changing object, an object in change) "),
                new HighVersianDefinition("Formidabili","Fearsome, Formidable (Literal: A person who is very devoted to their strength)"),
                new HighVersianDefinition("Forsilo","Big Jump; Leap (Literal: Very big sail/jump)"),
                new HighVersianDefinition("Fumo","A crypt or graveyard (Literal: A group of dead or decomposing things)"),
                new HighVersianDefinition("Furens","A person who is presently angry"),

                new HighVersianDefinition("Hominum","In service of or devoted to a person or thing with human-like intelligence."),

                new HighVersianDefinition("Ignis","Fire/Flames. Or to set on fire (properly, in service of heat)"),
                new HighVersianDefinition("Illusio","An illusion (Literal: You are currently doing/watching a bad play / show.) "),
                new HighVersianDefinition("Immensa","Immense, vast, huge. (Literal: An idea of great size)"),
                new HighVersianDefinition("Intendet","Intensify (Literal: To make a group not soft/tender)"),

                new HighVersianDefinition("Liquidum","Bring forth water/to control water"),

                new HighVersianDefinition("Lecta","A chosen object"),
                new HighVersianDefinition("Lecte","A chosen group/people"),
                new HighVersianDefinition("Lecti","A chosen speaker; the chosen one"),
                new HighVersianDefinition("Lecto","The act of choosing"),
                new HighVersianDefinition("Lectu","A chosen person"),

                new HighVersianDefinition("Luso","The act of play. A show/performance."),

                new HighVersianDefinition("Ma","It (generally an object)"),
                new HighVersianDefinition("Maledictum","Curse (Literal: a Someone who is serving a wrong commandment or order)"),
                new HighVersianDefinition("Mandatum","A command / following a command / A command to be followed"),

                new HighVersianDefinition("Mi","Me"),
                new HighVersianDefinition("Mio","We, With me (my group)"),

                new HighVersianDefinition("Minaces","Threaten, threatening (Literal: A group of small violence)"),
                new HighVersianDefinition("Minamichi","My little friend, my pet (general a small animal)"),
                new HighVersianDefinition("Misericors","Merciful (Literal: A group whose job it is to have a little amount of mercy)"),
                new HighVersianDefinition("Molior","A person who builds/crafts/creates (less like construction, more like artist/craftsmen)"),
                new HighVersianDefinition("Mora","Delayed (Literal: Lots of objects or items)"),
                new HighVersianDefinition("Morantes","Lingering, remaining. (Literal: A Large group of smells or orders)"),
                new HighVersianDefinition("Mortuis","The dead. (Literal: A group of large [bloated] bodies)"),

                new HighVersianDefinition("Mu","They"),
                new HighVersianDefinition("Mu’","He"),
                new HighVersianDefinition("Mu;","She"),
                new HighVersianDefinition("Mua","It"),
                new HighVersianDefinition("Mua’","It (Male)"),
                new HighVersianDefinition("Mua;","It (female)"),

                new HighVersianDefinition("Mue","You (plural, group)"),
                new HighVersianDefinition("Mue’","Guys/Men"),
                new HighVersianDefinition("Mue;","Girls/Women"),

                new HighVersianDefinition("Mui","You"),
                new HighVersianDefinition("Mui’","You (Male)"),
                new HighVersianDefinition("Mui;","You (Female)"),
                new HighVersianDefinition("Multa","Multiple, multiply objects"),
                new HighVersianDefinition("Mutare","To change, mutate, or otherwise transform"),

                new HighVersianDefinition("Ordinis","Order of the"),
                new HighVersianDefinition("Orito","(To) speak, speaking"),

                new HighVersianDefinition("Pertinas","Persistent (Literal: Part of a group of things in an area taken up by people)"),
                new HighVersianDefinition("Planta","A plant or tree"),
                new HighVersianDefinition("Pronus","A person who has fallen down (Literal: A person devoted to being prone)"),
                new HighVersianDefinition("Propria","Stylized (Literal: a person who is experiencing the proper way/form)"),
                new HighVersianDefinition("Putridus","Devoted to destruction/ruin"),

                new HighVersianDefinition("Redintegrare","Quicken (Literal: A group of objects which are used to integrate again)"),
                new HighVersianDefinition("Resilio","Bounce (Literal: A person who is currently leaping again)"),
                new HighVersianDefinition("Robora","Encourage (Literal: An object which strengthens)"),

                new HighVersianDefinition("Sanguinem","A loss of blood, bloody (Literal: The loss of a group of blood)"),

                new HighVersianDefinition("Sa","Yes (it agrees/it works/it functions)"),
                new HighVersianDefinition("Se","Yes (we agree or I agree with multiple statements) "),
                new HighVersianDefinition("Si","Yes (I agree)"),
                new HighVersianDefinition("So","Yes, and; Yes, lets"),
                new HighVersianDefinition("Su","Yes (You agree)"),

                new HighVersianDefinition("Saleo","Welcome (to the group / event), hello. (Literal: A group which is currently safe)"),
                new HighVersianDefinition("Salio","Hello, Salutations (Literal: I am a person who is currently safe)"),
                new HighVersianDefinition("Saluo","Are you okay. Hello? (Literal: You are currently safe)"),

                new HighVersianDefinition("Salbol","Safehouse, Bank, church; sacred place / religious place. (Literal: Safe Place, a safe place where people gather or things are stored)"),
                new HighVersianDefinition("Salboli","My house which is safe"),

                new HighVersianDefinition("Sonetus","A sound or noise from someone else"),

                new HighVersianDefinition("Stellar","Stars / space"),
                new HighVersianDefinition("Stellarum","In the service of the stars"),

                new HighVersianDefinition("Talem","Empower, increase power. (Literal: The distinguished group) "),
                new HighVersianDefinition("Tenas","Stubborn (Literal: A group of things which are tenacious)"),
                new HighVersianDefinition("Tenebrescere","Tenebrous, dark, shadowy. (Literal: A super category of unyielding or unending darkness)"),
                new HighVersianDefinition("Terra","A rock, or mineral, or other object that comes from the ground. "),
                new HighVersianDefinition("Tonitrua","Thunder (Literal: the stretching of already stretched rope by someone else; the sound of rope breaking from afar)"),
                new HighVersianDefinition("Turbatur","Tumultuous (Literal: A person whose job or role is marked by disturbances or disruptions)"),
                new HighVersianDefinition("Turbulentos","Disruptive (Literal: A group that is currently full of disturbances)"),

                new HighVersianDefinition("Umbra","Shadow, dark[ness] (Literal: An object which is dark.)"),

                new HighVersianDefinition("Vis","Void energy/power"),

                new HighVersianDefinition("Vers","The planet of Vers OR Homeworld"),
                new HighVersianDefinition("Versius","My Home/Planet devoted to your service; from my home to you. OR My Planet which is devoted to the service of Vers/The Home (Also the capital of the Vers empire)"),
                new HighVersianDefinition("Versariam","The thing which does the job of being my land. The Land of the Vers empire (Versians) (Literal: The area occupied by my home)"),
                new HighVersianDefinition("Versarium","The thing which does the job of being my home being used by you. OR Our shared home; OR The people of Vers, Versians. "),

                new HighVersianDefinition("Verus","Material / Real / Physical"),
                new HighVersianDefinition("Vestibulum","Commanding Energy or electricity. (Formally, either someone who is devoted to collected energy, or that the energy is devoted to someone)"),

                new HighVersianDefinition("Una","One"),
                new HighVersianDefinition("Dia","Two"),
                new HighVersianDefinition("Tria","Three"),
                new HighVersianDefinition("Vria","Four"),
                new HighVersianDefinition("Pia","Five"),
                new HighVersianDefinition("Sea","Six"),
                new HighVersianDefinition("Sepa","Seven"),
                new HighVersianDefinition("Okta","Eight"),
                new HighVersianDefinition("Nia","Nine"),
                new HighVersianDefinition("Deca","Ten"),
                new HighVersianDefinition("Undecuna","Eleven (One ten and one)"),
                new HighVersianDefinition("Undecdia","Tweleve (one ten and two)"),
                new HighVersianDefinition("Undectria","Thirteen (one ten and three)"),
                new HighVersianDefinition("Undecvria","Fourteen"),
                new HighVersianDefinition("Undecpia","Fifteen"),
                new HighVersianDefinition("Undecsea","Sixteen"),
                new HighVersianDefinition("Undecsepa","Seventeen"),
                new HighVersianDefinition("Undecokta","Eighteen"),
                new HighVersianDefinition("Undecnia","Nineteen"),
                new HighVersianDefinition("Dideca","Twenty (two ten)"),
                new HighVersianDefinition("Didecuna","Twenty one (two ten and one)"),
                new HighVersianDefinition("Trideca","Thirty"),
                new HighVersianDefinition("Tridecuna","Thirty one"),
                new HighVersianDefinition("Uncena","One Hundred"),
                new HighVersianDefinition("Unmela","One Thousand"),
                new HighVersianDefinition("Trimelpicena et Sea","Three Thousand Five Hundred and Six"),
                new HighVersianDefinition("Decmela","Ten Thousand"),
                new HighVersianDefinition("Cenmela","One-Hundred Thousand"),
                new HighVersianDefinition("Pisemela","Fifty Six Thousand"),
                new HighVersianDefinition("Dicenmela","Two Hundred Thousand"),
                new HighVersianDefinition("Unmila","One Million"),
                new HighVersianDefinition("Una","One"),
                new HighVersianDefinition("Tridecmila, Picen Et Oktdecmel, Sepcena Et Vridecuna","Thirty Six Million, Five hundred and eighty two thousand, Seven-Hundred and Fourty-One"),

                new HighVersianDefinition("Fimul","(Another) Child (person you're talking to); Non-Literal: Childhood friend; fellow child"),
                new HighVersianDefinition("Fimui","Child (person you're talking to)"),
                new HighVersianDefinition("Fimui'","Child (male) whose the target of your speech"),
                new HighVersianDefinition("Fimui;","Child (female) to whom you're speaking"),

                new HighVersianDefinition("Fimei","The speakers child (the child being spoken to who "),
                new HighVersianDefinition("Fimei'","Son"),
                new HighVersianDefinition("Fimei;","Daughter"),

                new HighVersianDefinition("Ladu","One who steals"),
                new HighVersianDefinition("Ladi","I steal"),
                new HighVersianDefinition("Ladio","I am stealing"),
                new HighVersianDefinition("Ladir","Thief; person who steals"),

                new HighVersianDefinition("Caelereis","Everyones/humanities collective souls. [proper: Cael-ere-ei-is] (Literal: The souls of the larger category of the speakers group/organizatgion)"),

                new HighVersianDefinition("Amicu","A friend, someone who is a friend [second or third person] (literal: familiar/friend being spoken of)"),

                new HighVersianDefinition("Genel","Family, Kin, (Literal: a group which is alike/related)"),

                new HighVersianDefinition("Exspiroa","Inspire; blow [air] (Literal: From the object which is currently breathing)"),

                new HighVersianDefinition("Vam","By/through (an object causing)"),

                new HighVersianDefinition("Somfantasia","The dream which someone is experiencing (literal: sleep illusion someone is experiencing)"),
                new HighVersianDefinition("Somfantasa","Dream as an object, someones dream, or a dream (literal: The object of sleep illusion )"),
                new HighVersianDefinition("Piia","A person who is experiencing five of an object"),
                new HighVersianDefinition("Pura","an object which is clean/pure"),
                new HighVersianDefinition("Puro","Something which is actively being purified/purifying"),
                new HighVersianDefinition("Puri","I am pure"),
                new HighVersianDefinition("Peru","Someone else who is pure/you are pure"),
                new HighVersianDefinition("Inperu","Someone who is not pure"),
                new HighVersianDefinition("Inpereo","A group who is actively impure"),

                new HighVersianDefinition("Damnitio","Damnation (Literal: A person who is actively experiencing a group of damage/pain)"),
                new HighVersianDefinition("Damnituio","Damn you [insult] (Literal: the person being spoken to is actively being caused a group of damage/hurt)"),
                new HighVersianDefinition("necessarius","a person who is devoted to the thing which does something that is necessary"),
                new HighVersianDefinition("Thornar","The throne/their throne"),
                new HighVersianDefinition("Exdom","From home"),
                new HighVersianDefinition("Necessoi","The thing which the person is presently doing which is necessary/needed"),
                new HighVersianDefinition("Sanctaor","An object which is sacred"),
                new HighVersianDefinition("Visgladau","Someone elses void blade; the void blade which belongs to"),
                new HighVersianDefinition("Omnsiensie","The (group of) All-Knowing Leaders"),
                new HighVersianDefinition("Dearmorua","(Someone Elses) Godly/Divine/Spiritual(?) Armour"),
                new HighVersianDefinition("Unpatir'","(Male) One/First person who does the job of being the Father. (Spirirtual: One-Father, the 'father' everyone prays to in a Sigmarian Religion)"),
                new HighVersianDefinition("Qieso","The active form of rest, resting/sleeping (figurative form of resting as well, as in resting on)"),
                new HighVersianDefinition("Imcastellam","(The) Large/Great Castle which is in use (by) "),
                new HighVersianDefinition("Devers","Holy capital/spiritual center. The divine home (planet)."),
                new HighVersianDefinition("Fornecessao","An object which is very/greatly necessary"),
                new HighVersianDefinition("Mallibral","A book which is sick/wrong/heretical"),
                new HighVersianDefinition("Exitiam","In use by the Abyss, someone who is working for the Daemons (Literal: I am in use by destroy)"),
                new HighVersianDefinition("Neu","Not (person, other)"),
                new HighVersianDefinition("Auctumbrie","Dark Lords"),
                new HighVersianDefinition("Fordecaelia","The object of the very/greatly divine spirit"),
                new HighVersianDefinition("Canda","The object of light"),
                new HighVersianDefinition("Vidia","Seer (a person who experiences seeing)"),
                new HighVersianDefinition("Magi","Mage or magic user"),
                new HighVersianDefinition("Daemagi","Daemonic Magic User, evil mage. "),
                new HighVersianDefinition("Daemes","A group of Daemons. "),
                new HighVersianDefinition("Daeme","A Daemon. "),
                new HighVersianDefinition("Aeterna","The object of eternal. (A very long period of time)"),
                new HighVersianDefinition("Proelir","The best people of battle, the best warrriors."),
                new HighVersianDefinition("Proelais","The best warrriors, who are using an object."),
                
                new HighVersianDefinition("Nesomfantasoi","avoiding thinking about, to lack the courage to do, to not want to do  (Literal: The sleep-illusion (dream) the person is presently NOT having.)"),
            };
            if (text.Count > 0) return text.OrderBy(x => x?.Letters.First()).ToList();
            else return text;
        }

        public List<HighVersianDefinition> Words => GenerateWords();

        private static List<HighVersianDefinition> _words = new List<HighVersianDefinition>();


        private static int cacheHits = 0;
        private static int valuesInChache => _words.Count;
        private static int cacheMiss = 0;

        public HighVersianDefinition GetWord(string prefix, string root, string postfix)
        {
            if (_words == null || _words.Count <= 0) GenerateWords();

            var spellingOfWord = $"{prefix}{root}{postfix}".ToUpper();

            var containsWord = _words.Any(x => x.Letters == spellingOfWord);
            

            
            if (containsWord)
            {
                cacheHits++;
            
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine($"Looking for: {spellingOfWord}. Found: {containsWord} [{cacheHits.ToString()}:{cacheMiss.ToString()}/{valuesInChache.ToString()}]");
            
                return Words.First(x => x.Letters == spellingOfWord);
            }
            else
            {
                return new HighVersianDefinition("ERROR", "Not Found -- No word with a more complex meaning then the literal form of its translation.");
                //Bad Code, slows stuff down too much
/*                cacheMiss++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Looking for: {spellingOfWord}. Found: {containsWord} [{cacheHits.ToString()}:{cacheMiss.ToString()}/{valuesInChache.ToString()}]");
            
                var meaning = GetWordMeaning(prefix,root,postfix);
                var word = new HighVersianDefinition(spellingOfWord, meaning);
                AddWord(word);
                return word;*/
            }
        }

        public string GetWordMeaning(string prefix, string root, string postfix)
        {
            var preMeaning = GetPrefixMeaning(prefix);
            var rootMeaning = GetRootMeaning(root);
            var postMeaning =   GetPostfixMeaning(postfix);
            var meaning = $"{preMeaning}. {rootMeaning}. {postMeaning}";

            return meaning;
        }

        private string GetPrefixMeaning(string prefix) 
            => Prefixes.AsParallel().First(x => x.Letters == prefix.ToUpper()).Meaning;

        
        private string GetRootMeaning(string root) 
            => Roots.First(x => x.Letters == root.ToUpper()).Meaning;
        
        private string GetPostfixMeaning(string postfix) 
            => Postfixes.First(x => x.Letters == postfix.ToUpper()).Meaning;
        
        public List<HighVersianDefinition> GenerateWords()
        {
            if (_words != null && _words.Count > 0)
            {
                return _words;
            }

            _words = HighVersianWordDefinitions();

/*            foreach (var root in Roots.OrderBy(x => x.Letters.First()))
            {
                Task.Run(() => GeneratePrefixesForRootAndSave(root));
            }
*/
            return _words;
        }


        public void GeneratePrefixesForRootAndSave(HighVersianDefinition root)
        {
            foreach (var prefix in Prefixes.OrderBy(x => x.Letters.First()))
            {
                Task.Run(() => GeneratePostfixesForRootAndSave(prefix,root));
            }
        }
        
        public  void GeneratePostfixesForRootAndSave(HighVersianDefinition prefix, HighVersianDefinition root)
        {
            foreach (var postfix in Postfixes.OrderBy(x => x.Letters.First()))
            {
                var word = new HighVersianDefinition($"{prefix.Letters}{root.Letters}{postfix.Letters}", $"{prefix.Meaning} {root.Meaning} {postfix.Meaning}");
                AddWord(word);
                
            }
        }

        /// <summary>
        /// Add a word to the list of words
        /// </summary>
        /// <param name="word">The word to add</param>
        /// <returns>Returns false if the word is already defined. True if added successfully</returns>
        public bool AddWord(HighVersianDefinition word)
        {
            if (_words.Any(x => x.Letters.Equals(word.Letters)))
            {
                return false;
            }
            
            _words.Add(word);
            return true;
        }
        
    }
}
