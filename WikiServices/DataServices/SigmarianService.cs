using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerFactionSystem.Faction_Types;
using WikiServices.SimpleServiceDriverCode;
// ReSharper disable StringLiteralTypo

namespace WikiServices.DataServices
{
    public enum SigmarianLetters
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

    public class SigmarianService
    {
        public List<SigmarianLetters> Letters() {
        var values = Enum.GetValues(typeof(SigmarianLetters));
            var letters = new List<SigmarianLetters>();
            foreach (var val in  values)
            {
                letters.Add((SigmarianLetters) val);
            }

            return letters;
        }
        
        public string GetLetterProunciation(SigmarianLetters letter)
            => letter switch {
            SigmarianLetters.A => "a as in [a]pple",
            SigmarianLetters.B => "B as in [B]eta",
            SigmarianLetters.C => "Ch as in [Ch]ase",
            SigmarianLetters.D => "D as in [D]emand",
            SigmarianLetters.E => "e as in B[e]t",
            SigmarianLetters.F => "F as in [F]it",
            SigmarianLetters.G => "G as in [G]ust",
            SigmarianLetters.H => "H as in [H]ot",
            SigmarianLetters.I => "E  as in [E]at",
            SigmarianLetters.J => "J as in [J]oin",
            SigmarianLetters.K => "K as in [C]a[K]e",
            SigmarianLetters.L => "L as in [L]ibrary",
            SigmarianLetters.M => "M as in [M]an",
            SigmarianLetters.N => "N as in [n]o",
            SigmarianLetters.O => "O as in [O]pen",
            SigmarianLetters.P => "P as in [P]eel",
            SigmarianLetters.Q => "Q as in [Qu]iet",
            SigmarianLetters.R => "R as in [R]ide",
            SigmarianLetters.S => "S as in [S]tand",
            SigmarianLetters.T => "T as in [T]iberius",
            SigmarianLetters.U => "U as in F[U]me",
            SigmarianLetters.V => "V as in [V]ictor",
            SigmarianLetters.W => "W as in [W]hile",
            SigmarianLetters.X => "S as in [S]teal",
            SigmarianLetters.Z => "Z as in [Z]eta",
            _ => $"{letter} is unknown"
        };

        public  List<HighVersianDefinition> MaleNouns { get; } = new List<HighVersianDefinition>
        {
            new HighVersianDefinition("Una","One (of an object)"),
            new HighVersianDefinition("Libra","Book"),
            new HighVersianDefinition("Deas","Gods"),
            new HighVersianDefinition("Mas","We"),
            new HighVersianDefinition("Dea","God"),
            new HighVersianDefinition("Va","(noun) by (noun)"),
            new HighVersianDefinition("Saptiam","The Void (Place)"),
            new HighVersianDefinition("Tas","Them"),
            new HighVersianDefinition("Ta","Him"),
            new HighVersianDefinition("Famparar","Master/head of the family"),
            new HighVersianDefinition("Emparar","Emperor"),
            new HighVersianDefinition("Versariam","The place of vers"),

           
        }.OrderBy(x => x.Letters.First<char>()).ToList();

        
        public  List<HighVersianDefinition> FemaleNouns { get; } = new List<HighVersianDefinition>
        {
            new HighVersianDefinition("Unu","One, number"),
            new HighVersianDefinition("Diu","Two, number"),
            new HighVersianDefinition("Triu","Three, number"),
            new HighVersianDefinition("Vriu","Four, number"),
            new HighVersianDefinition("Piu","Five, number"),
            new HighVersianDefinition("Seu","Six, number"),
            new HighVersianDefinition("Sepu","Seven, number"),
            new HighVersianDefinition("Oktu","Eight, number"),
            new HighVersianDefinition("Vitu","Life"),
           
        }.OrderBy(x => x.Letters.First<char>()).ToList();
        
        public List<HighVersianDefinition> Verbs { get; } = new List<HighVersianDefinition>()
        {
            new HighVersianDefinition("Sao","There are"),
            new HighVersianDefinition("Loqo",""),
            new HighVersianDefinition("Disco","Learn/Understand"),
            new HighVersianDefinition("Cono","With"),
            new HighVersianDefinition("Exo","From"),
            new HighVersianDefinition("Veo","To (give)"),
            new HighVersianDefinition("Dano","(give)"),
            new HighVersianDefinition("Natot","Birthed"),
            new HighVersianDefinition("Aedificot","Constructed"),
            
        }.OrderBy(x => x.Letters.First()).ToList();
        
        public List<HighVersianDefinition> Adjectives { get; } = new List<HighVersianDefinition>()
        {
            new HighVersianDefinition("Eni","On/About"),
            new HighVersianDefinition("Exi","In/Begining/Start/From"),
            new HighVersianDefinition("Uni",""),
            new HighVersianDefinition("Okti","Eight/Eigth"),
            new HighVersianDefinition("Nomit","Name"),
            new HighVersianDefinition("Di","Of"),
            
        }.OrderBy(x => x.Letters.First()).ToList();
        
        
        public List<HighVersianDefinition> Adverbs { get; } = new List<HighVersianDefinition>()
        {
            new HighVersianDefinition("Ere","Will"),
            new HighVersianDefinition("Que","Each"),
            new HighVersianDefinition("Pre","First/Start"),
            new HighVersianDefinition("Mole","Crafted"),
            
        }.OrderBy(x => x.Letters.First()).ToList();
        
        public List<HighVersianDefinition> Postfixes { get; } = new List<HighVersianDefinition>()
        {
            new HighVersianDefinition("A","Male Noun"),
            new HighVersianDefinition("U","Female Noun"),
            new HighVersianDefinition("O","Verb"),
            new HighVersianDefinition("I","Descriptor"),
            new HighVersianDefinition("E","Adverb"),
            new HighVersianDefinition("*S","Plural"),
            new HighVersianDefinition("*M","Place/Location"),
            new HighVersianDefinition("*R","Job/Role"),
            new HighVersianDefinition("*T","Past tense"),

        }.OrderBy(x => x.Letters.First()).ToList();

        private static List<HighVersianDefinition> HighVersianWordDefinitions()
        {
            var text = new List<HighVersianDefinition>()
            {
                new HighVersianDefinition("Et","And"),
            };
            if (text.Count > 0) return text.OrderBy(x => x?.Letters.First()).ToList();
            else return text;
        }

        public List<HighVersianDefinition> Words => GenerateWords();

        private static List<HighVersianDefinition> _words = new List<HighVersianDefinition>();

        public Dictionary<HighVersianDefinition, string> GetAllTerms()
        {
            var dict = new Dictionary<HighVersianDefinition, string>();

            foreach (var pre in FemaleNouns)
            {
                dict.Add(pre, "Female Noun/Object");
            }

            foreach (var pre in MaleNouns)
            {
                dict.Add(pre, "Male Noun/Object");
            }
            
            foreach (var pre in Verbs)
            {
                dict.Add(pre, "Verb/Action");
            }
            
            foreach (var pre in Adjectives)
            {
                dict.Add(pre, "Adjective/Descriptor");
            }
            
            foreach (var root in Adverbs)
            {
                dict.Add(root, "Adverb");
            }
            
            
            foreach (var post in Postfixes)
            {
                dict.Add(post, "Ending");
            }
            
            
            foreach (var word in Words)
            {
                dict.Add(word, "Word");
            }
            
            return dict;
        }
        
        
        public HighVersianDefinition GetWord(string prefix, string root, string postfix)
        {
            if (_words == null || _words.Count <= 0) GenerateWords();

            var spellingOfWord = $"{prefix}{root}{postfix}".ToUpper();

            var containsWord = _words.Any(x => x.Letters == spellingOfWord);
            

            
            if (containsWord)
            {
             
                return Words.First(x => x.Letters == spellingOfWord);
            }
            else
            {
                return new HighVersianDefinition("ERROR", "Not Found -- No word with a more complex meaning then the literal form of its translation.");
                
            }
        }

        public List<HighVersianDefinition> GenerateWords()
        {
            if (_words != null && _words.Count > 0)
            {
                return _words;
            }

            _words = HighVersianWordDefinitions();

            return _words;
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
