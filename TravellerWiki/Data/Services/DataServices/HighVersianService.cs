using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting.Internal;

namespace TravellerWiki.Data.Services.DataServices
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
            HighVersianLetters.Q => "Q as in [Q]uiet",
            HighVersianLetters.R => "R as in [R]ide",
            HighVersianLetters.S => "S as in [S]tand",
            HighVersianLetters.T => "T as in [T]iberius",
            HighVersianLetters.U => "U as in F[U]me",
            HighVersianLetters.V => "V as in [V]ictor",
            HighVersianLetters.W => "W as in [W]hile",
            HighVersianLetters.X => "S as in [S]teal",
            HighVersianLetters.Z => "Z as in [Z]eta",
        };

        public List<HighVersianDefinition> Prefixes = new List<HighVersianDefinition>()
        {
            new HighVersianDefinition("Apoc","Absolute, complete, total"),
            new HighVersianDefinition("Ard","Burning"),
            new HighVersianDefinition("Auct","Authority / Commander / Author"),
            new HighVersianDefinition("Ci","Skin, Flesh, Physical"),
            new HighVersianDefinition("Com","Mix, combined, added to (generally an object)"),
            new HighVersianDefinition("Con","With, Together"),
            new HighVersianDefinition("De","God/Heavenly/Godly"),
            new HighVersianDefinition("Di","Two"),
            new HighVersianDefinition("Dom","Home, hearth, house"),
            new HighVersianDefinition("Em","Combined / Shared (generally a person)"),
            new HighVersianDefinition("Ext","Extinguish, end, finish"),
            new HighVersianDefinition("For","Very, greatly"),
            new HighVersianDefinition("Ign","Warm/Hot/Warmth"),
            new HighVersianDefinition("Il","False, wrong"),
            new HighVersianDefinition("Im","Large, in great amount"),
            new HighVersianDefinition("In","Small, in little amount; not"),
            new HighVersianDefinition("Mal","Sick, wrong, perverted, badly, poorly"),
            new HighVersianDefinition("Max","Maximum, largest, greatest"),
            new HighVersianDefinition("Med","Mediate, intervene, heal, remedy"),
            new HighVersianDefinition("Min","Smallest, lowest, minimum"),
            new HighVersianDefinition("Mis","A little/small"),
            new HighVersianDefinition("Mol","Craft/Construct/Design/Create"),
            new HighVersianDefinition("Mor","Lots, plentiful"),
            new HighVersianDefinition("Mut","Mutate, change, modify"),
            new HighVersianDefinition("Red","Again"),
            new HighVersianDefinition("Sal","Safe, Secury, saved, protected"),
            new HighVersianDefinition("San","Without, lacking, non"),
            new HighVersianDefinition("Ton","Stretching or extending"),
            new HighVersianDefinition("Turb","Disturbance, disruption, trouble, stir"),
            new HighVersianDefinition("Vesti","Energy/Current/Electricity"),
            new HighVersianDefinition("Vis","Void Power/Energy/Raw potential"),
            new HighVersianDefinition("​","No prefix"),

        };

        public List<HighVersianDefinition> Roots = new List<HighVersianDefinition>()
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
            new HighVersianDefinition("Orit","To say or speak, orate"),
            new HighVersianDefinition("Par","Leader/Master/Head of Unit/Group"),
            new HighVersianDefinition("Plant","Plant/Tree"),
            new HighVersianDefinition("Pert","Part or Piece"),
            new HighVersianDefinition("Posit","An idea or theory, which is assumed to be true; A core element or component"),
            new HighVersianDefinition("Pron","Prone, fallen, down"),
            new HighVersianDefinition("Propr","Proper, the correct way"),
            new HighVersianDefinition("Putrid","Disgusting, ruined, destroyed"),
            new HighVersianDefinition("Robor","Strengthen or hence, encourage"),
            new HighVersianDefinition("S","Agree, yes, affirmative"),
            new HighVersianDefinition("Sil","Sail, jump, leap, bounce"),
            new HighVersianDefinition("Sonit","Song, Sonnet, music, sound, noise"),
            new HighVersianDefinition("Spat","Void, Beyond Stars / Space"),
            new HighVersianDefinition("Stellar","Space / Stars"),
            new HighVersianDefinition("Vers","Home, Planet, Capital, (Like Earth) "),
            new HighVersianDefinition("Ulent","Full of, abounding in"),
            new HighVersianDefinition("Umbr","Darkness"),
            new HighVersianDefinition("Tu","Body, person (corpse)"),
            new HighVersianDefinition("Ting","Touch"),
            new HighVersianDefinition("Terr","Rock/Earth/Dirt/Metal"),
            new HighVersianDefinition("Tend","Tender, showing care"),
            new HighVersianDefinition("Ten","Tenacious, firm, steadfast, unyielding"),
            new HighVersianDefinition("Tal","Distinguish, excellent"),
            new HighVersianDefinition("Tag","Disease, sickness, plague"),

        };

        public List<HighVersianDefinition> Postfixes = new List<HighVersianDefinition>()
        {
            new HighVersianDefinition("A","An object or thing"),
            new HighVersianDefinition("e","A group/Plural"),
            new HighVersianDefinition("i","A person, singular, generally the speaker / First Person"),
            new HighVersianDefinition("o","A person, singular, generally the speaker / First Person"),
            new HighVersianDefinition("u","For someone else, a person but not the speaker, the person being spoken of/to (can be second person but more often refers to the third person)"),


            new HighVersianDefinition("ae","A group of objects"),
            new HighVersianDefinition("ie","A group of people, a group of leaders, the speakers group"),
            new HighVersianDefinition("oe","Happening in the present moment to a group"),
            new HighVersianDefinition("Ue","A group who works for someone else, a group acting for someone else"),


            new HighVersianDefinition("ia","A person using or experiencing an object"),
            new HighVersianDefinition("ea","A group using or experiencing an object"),
            new HighVersianDefinition("oa","A object currently doing something; an objecting being used by another object"),
            new HighVersianDefinition("ua","Someone else using an object"),


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

        };

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
            
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Looking for: {spellingOfWord}. Found: {containsWord} [{cacheHits.ToString()}:{cacheMiss.ToString()}/{valuesInChache.ToString()}]");
            
                return Words.First(x => x.Letters == spellingOfWord);
            }
            else
            {
                cacheMiss++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Looking for: {spellingOfWord}. Found: {containsWord} [{cacheHits.ToString()}:{cacheMiss.ToString()}/{valuesInChache.ToString()}]");
            
                var meaning = GetWordMeaning(prefix,root,postfix);
                var word = new HighVersianDefinition(spellingOfWord, meaning);
                AddWord(word);
                return word;
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
        
        private static List<HighVersianDefinition> HighVersianWordDefinitions()
        {
            return new List<HighVersianDefinition>()
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
                new HighVersianDefinition("Apocalypsia","A person who experiences absolute and total destruction or ruin; an apocalypse."),
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
                /*
                new HighVersianDefinition("",""),
                new HighVersianDefinition("",""),
                new HighVersianDefinition("",""),
                new HighVersianDefinition("",""),
                new HighVersianDefinition("",""),
                */
            };
        }
    }
}
