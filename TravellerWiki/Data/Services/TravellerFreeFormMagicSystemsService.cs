using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TravellerWiki.Data
{
    public enum FreeFormLanguages
    {
        HighVersian,
        Jedi,
        Sith,
        FederationCommon,
    }
    public enum FreeFormPlanes
    {
        Void, Aether, Material, Nether, Abyss
    }

    public enum FreeFormActions
    {
        Build, Learn, Change, Ruin, Command
    }

    public enum FreeFormTargets
    {
        Animals, Water, Air, Creature, Plant, Fire, Image, Mind, Earth, Constructed, Electricity, Void
    }

    public class TravellerFreeFormMagicSystemsService
    {
        

        private static string GetPlaneDescription(FreeFormPlanes plane) =>
            plane switch
            {
                FreeFormPlanes.Void => "Void (Energy, Raw Matter, Creation)",
                FreeFormPlanes.Aether => "Aether (Souls, Life, Healing)",
                FreeFormPlanes.Material => "Material (The Physical world)",
                FreeFormPlanes.Nether => "Nether (Death, Disease, Sin)",
                FreeFormPlanes.Abyss => "Abyss (Destruction, Entropy, The Absence of sanity)",
            };

        private Dictionary<string, string> GetFederationPlanes()
        {
            return new Dictionary<string, string>()
            {
                { "Immortal",GetPlaneDescription(FreeFormPlanes.Void)},
                { "Spiritual",GetPlaneDescription(FreeFormPlanes.Aether)},
                { "Temporal",GetPlaneDescription(FreeFormPlanes.Material)},
                { "Resurrection",GetPlaneDescription(FreeFormPlanes.Nether)},
                { "Eternal",GetPlaneDescription(FreeFormPlanes.Abyss)},
            };
        }

        private Dictionary<string, string> GetVersianPlanes()
        {
            return new Dictionary<string, string>()
            {
                { "Spatium",GetPlaneDescription(FreeFormPlanes.Void)},
                { "Caelum",GetPlaneDescription(FreeFormPlanes.Aether)},
                { "Verus",GetPlaneDescription(FreeFormPlanes.Material)},
                { "Exanimum",GetPlaneDescription(FreeFormPlanes.Nether)},
                { "Exitium",GetPlaneDescription(FreeFormPlanes.Abyss)},
            };
        }

        private Dictionary<string, string> GetJediPlanes()
        {
            return new Dictionary<string, string>()
            {
                { "Altissima",GetPlaneDescription(FreeFormPlanes.Void)},
                { "Ceu",GetPlaneDescription(FreeFormPlanes.Aether)},
                { "Terra",GetPlaneDescription(FreeFormPlanes.Material)},
                { "Morte",GetPlaneDescription(FreeFormPlanes.Nether)},
                { "Destino",GetPlaneDescription(FreeFormPlanes.Abyss)},
            };
        }

        private Dictionary<string, string> GetSithPlanes()
        {
            return new Dictionary<string, string>()
            {
                { "Vacio",GetPlaneDescription(FreeFormPlanes.Void)},
                { "Celestial",GetPlaneDescription(FreeFormPlanes.Aether)},
                { "Terrenal",GetPlaneDescription(FreeFormPlanes.Material)},
                { "Infierno",GetPlaneDescription(FreeFormPlanes.Nether)},
                { "Abismo",GetPlaneDescription(FreeFormPlanes.Abyss)},
            };
        }



        private static string GetActionDescription(FreeFormActions action) =>
            action switch
            {
                FreeFormActions.Build => "Build, create something. This can be used to create new cells to heal wounds, create food and water, create items",
                FreeFormActions.Learn => "Learn, gather information, understand",
                FreeFormActions.Change => "Change, transform, mutate, intead of creating something new, modifying something currently existing.",
                FreeFormActions.Ruin => "Ruin, destroy, make worse, remove, degrade",
                FreeFormActions.Command => "Command, control, order, tell what to do, manipulate. (You could command an innaimate object to move for example)",
            };

        private Dictionary<string, string> GetFederationAction()
        {
            return new Dictionary<string, string>()
            {
                { "Forge",GetActionDescription(FreeFormActions.Build)},
                { "Study",GetActionDescription(FreeFormActions.Learn)},
                { "Alter",GetActionDescription(FreeFormActions.Change)},
                { "Decay",GetActionDescription(FreeFormActions.Ruin)},
                { "Order",GetActionDescription(FreeFormActions.Command)},
            };
        }

        private Dictionary<string, string> GetVersianAction()
        {
            return new Dictionary<string, string>()
            {
                { "Aedificate",GetActionDescription(FreeFormActions.Build)},
                { "Disco",GetActionDescription(FreeFormActions.Learn)},
                { "Mutare",GetActionDescription(FreeFormActions.Change)},
                { "Putridus",GetActionDescription(FreeFormActions.Ruin)},
                { "Mandatum",GetActionDescription(FreeFormActions.Command)},
            };
        }

        private Dictionary<string, string> GetJediAction()
        {
            return new Dictionary<string, string>()
            {
                { "Crio",GetActionDescription(FreeFormActions.Build)},
                { "Descobrir",GetActionDescription(FreeFormActions.Learn)},
                { "Modificar",GetActionDescription(FreeFormActions.Change)},
                { "Ruina",GetActionDescription(FreeFormActions.Ruin)},
                { "Ordem",GetActionDescription(FreeFormActions.Command)},
            };
        }

        private Dictionary<string, string> GetSithAction()
        {
            return new Dictionary<string, string>()
            {
                { "Construir",GetActionDescription(FreeFormActions.Build)},
                { "Comprender",GetActionDescription(FreeFormActions.Learn)},
                { "Cambio",GetActionDescription(FreeFormActions.Change)},
                { "Corrupto",GetActionDescription(FreeFormActions.Ruin)},
                { "Comando",GetActionDescription(FreeFormActions.Command)},
            };
        }


        private static string GetTargetDescriptions(FreeFormTargets target)
            => target switch
            { 
                FreeFormTargets.Air => "Air/Gas",
                FreeFormTargets.Animals => "Animals, things with an intelligence lower then 6.",
                FreeFormTargets.Constructed => "Constructed, things that are built",
                FreeFormTargets.Creature => "Humanoid Bodies/Creatures (intelligence of 6 or more)",
                FreeFormTargets.Earth => "Earth, Solid stuff, rock, stone, metal",
                FreeFormTargets.Electricity => "Electricty, Energy",
                FreeFormTargets.Fire => "Fire, Heat, Light",
                FreeFormTargets.Image => "Image, Illusions, sensory effects, the nevous system",
                FreeFormTargets.Mind => "Mind, thoughts, brain",
                FreeFormTargets.Plant => "Plant/Trees",
                FreeFormTargets.Void => "Power, void power, Raw elements from the planes.",
                FreeFormTargets.Water => "Water/Liquid",
            };

        private Dictionary<string, string> GetFederationTargets()
        {
            return new Dictionary<string, string>()
            {
                { "Gaseous",GetTargetDescriptions(FreeFormTargets.Air)},
                { "Thoughtless",GetTargetDescriptions(FreeFormTargets.Animals)},
                { "Engineer",GetTargetDescriptions(FreeFormTargets.Constructed)},
                { "Thoughtful",GetTargetDescriptions(FreeFormTargets.Creature)},
                { "Terran",GetTargetDescriptions(FreeFormTargets.Earth)},
                { "Energy",GetTargetDescriptions(FreeFormTargets.Electricity)},
                { "Flames",GetTargetDescriptions(FreeFormTargets.Fire)},
                { "Fiction",GetTargetDescriptions(FreeFormTargets.Image)},
                { "Conscious",GetTargetDescriptions(FreeFormTargets.Mind)},
                { "Living",GetTargetDescriptions(FreeFormTargets.Plant)},
                { "Magic",GetTargetDescriptions(FreeFormTargets.Void)},
                { "Liquid",GetTargetDescriptions(FreeFormTargets.Water)},
            };
        }

        private Dictionary<string, string> GetVersianTargets()
        {
            return new Dictionary<string, string>()
            {
                { "Aura",GetTargetDescriptions(FreeFormTargets.Air)},
                { "Creaturae",GetTargetDescriptions(FreeFormTargets.Animals)},
                { "Molior",GetTargetDescriptions(FreeFormTargets.Constructed)},
                { "Hominum",GetTargetDescriptions(FreeFormTargets.Creature)},
                { "Terra",GetTargetDescriptions(FreeFormTargets.Earth)},
                { "Vestibulum",GetTargetDescriptions(FreeFormTargets.Electricity)},
                { "Ignis",GetTargetDescriptions(FreeFormTargets.Fire)},
                { "Fantasia",GetTargetDescriptions(FreeFormTargets.Image)},
                { "Mens",GetTargetDescriptions(FreeFormTargets.Mind)},
                { "Planta",GetTargetDescriptions(FreeFormTargets.Plant)},
                { "Vis",GetTargetDescriptions(FreeFormTargets.Void)},
                { "Liquidum",GetTargetDescriptions(FreeFormTargets.Water)},
            };
        }

        private Dictionary<string, string> GetJediTargets()
        {
            return new Dictionary<string, string>()
            {
                { "Ar",GetTargetDescriptions(FreeFormTargets.Air)},
                { "Animal",GetTargetDescriptions(FreeFormTargets.Animals)},
                { "Criada",GetTargetDescriptions(FreeFormTargets.Constructed)},
                { "Criatura",GetTargetDescriptions(FreeFormTargets.Creature)},
                { "Terra",GetTargetDescriptions(FreeFormTargets.Earth)},
                { "Eletricidade",GetTargetDescriptions(FreeFormTargets.Electricity)},
                { "Incendio",GetTargetDescriptions(FreeFormTargets.Fire)},
                { "Cenario",GetTargetDescriptions(FreeFormTargets.Image)},
                { "Pensamento",GetTargetDescriptions(FreeFormTargets.Mind)},
                { "Plantar",GetTargetDescriptions(FreeFormTargets.Plant)},
                { "Igreja",GetTargetDescriptions(FreeFormTargets.Void)},
                { "Fluido",GetTargetDescriptions(FreeFormTargets.Water)},
            };
        }

        private Dictionary<string, string> GetSithTargets()
        {
            return new Dictionary<string, string>()
            {
                { "Cielo",GetTargetDescriptions(FreeFormTargets.Air)},
                { "Bestia",GetTargetDescriptions(FreeFormTargets.Animals)},
                { "Construdio",GetTargetDescriptions(FreeFormTargets.Constructed)},
                { "Inteligente",GetTargetDescriptions(FreeFormTargets.Creature)},
                { "Montana",GetTargetDescriptions(FreeFormTargets.Earth)},
                { "Energia",GetTargetDescriptions(FreeFormTargets.Electricity)},
                { "Fuego",GetTargetDescriptions(FreeFormTargets.Fire)},
                { "Foto",GetTargetDescriptions(FreeFormTargets.Image)},
                { "Cerebro",GetTargetDescriptions(FreeFormTargets.Mind)},
                { "Arbol",GetTargetDescriptions(FreeFormTargets.Plant)},
                { "Teologico",GetTargetDescriptions(FreeFormTargets.Void)},
                { "Liquido",GetTargetDescriptions(FreeFormTargets.Water)},
            };
        }

        private static string GetModifierDescriptions(int modifierNumber)
            => modifierNumber switch
            {
                0 => "Apocalyptic, you can alter the area a spell effects so that the area affected become ruined and devastated in appearance. All surfaces in the area become difficult terrain and remains so for 1D Months.",
                1 => "Aquaify, your spell can be cast and functions underwater with no immediate pennalties",
                2 => "Authoritative, if the spell lands on a creature, you may pick one of the follow actions to prohibit the creatue from taking: Move Closer to Someone of your choice, Move Away from Someone of your choice, Make an Attack, Cast a Spell",
                3 => "Damage Change, change the type of damage from a spell to one of the following: Acid, Cold, Electric, Fire, Magic, Water",
                4 => "Blissfull, the target becomes happy/blissful, on an ally this can empower them to fight harder, on an ememy it can cause them to drop their guard for a turn",
                5 => "Bouncing, if the spell fails, you can try again against a different target",
                6 => "Brisk, grant an alterantive movement type or increase movement speed by 1.5 meters",
                7 => "Burning, the spell does 1D Acid or Fire damage, lasts for 1D rounds unless extinguished with a End 8+ check",
                8 => "Center, you center the spell on yourself, causing it form around you protecting you from the effects of the spell.",
                9 => "Expanding Damage, you may cause an additional 2 points of damage in a characteristic of your choice.",
                
                10 => "Curse, curse the target with the effects of the spell for 1D Years, can be upgraded to 1D Decade",
                11 => "Combined, combined two separate spells together.",
                12 => "Contagious, the effects of the spell spread to anyone who touches the target for 1D seconds on a failed END 8+ check.",
                13 => "Contingent, Allows you to set a spell up as a reserve. Essentially set asside the magic now for later.",
                14 => "Crypt, if a creature dies to your spell, it returns to life at half its health points in 1D hours.",
                15 => "Dead, the decided",
                16 => "Daze, your spell puts the target into a daze.",
                17 => "Delayed, set your spell to be delayed until a specific trigger",
                18 => "Disruptive, your magic power is so strong that you overwhelm the ability for other mages to cast spells in an area of 2D6 meters around you.",
                19 => "Echoing, cast a spell a second time",
                
                20 => "Ectoplasmic, Your spell can bridge the gap between the Material and another Plane",
                21 => "Elemental, you can change the elemental nature of your spell",
                22 => "Empower, double the effects of the spell",
                23 => "Encourage, those affected by the spell gain a moral boost",
                24 => "Enlarge, Double the range of the spell",
                25 => "Extend, Double how long the spell lasts",
                26 => "Familiar, transfer a known spell to a friend/familier of yours",
                27 => "Fearsome, the target is shaken and terrifed because of the spell",
                28 => "Flare, Fire, Light, and Electrical spells cause those who see it to take an Int 6+ check or be dazzled and distracted by the effects for 3D6 seconds",
                29 => "Fleeting, the spell is easier to dismiss",
                
                30 => "Focused, if the spell targets multiple people, one of them is the main taget and has a harder time resisting the effects",
                31 => "Furious, the target of spell becomes enraged",
                32 => "Intensify, multiply the damage by 5",
                33 => "Lingering, remains in the area for 1D minutes",
                34 => "Merciful, the spell deals non-leathal damage",
                35 => "Multiply, add number of Psi points equal to the number of people you'd like to target with the spell",
                36 => "Persistent, if the target saves, the taget must save again",
                37 => "Quicken, cast the spell for 1 action point instead of 2",
                38 => "Scarring, the spell leaves the target fearful of the caster or someone of the casters choice.",
                39 => "Selective, allows the caster to ignore some targets of the spell, 1 psi point per target",
                
                40 => "Shadow, the spells area is engulfed in a shadow",
                41 => "Snuffing, if a creature takes damage from the spell, any light source they have must be restarted",
                42 => "Stylized, the spell is harder to identify",
                43 => "Tenacious, the spell is difficult to dispel",
                44 => "Tenebrous, the spell reduces the light in the affected area",
                45 => "Threatening Illusion, the target believes you illusion is a threat",
                46 => "Thundering, deafen a creature with your spell",
                47 => "Toppling, the spell knocks the target prone",
                48 => "Trick, the target makes an Int/Edu 8+ check, on failture they don't know the spell has been cast",
                49 => "Tumultuous, The target must make an Str/Dex 8+ check or be pushed 2D6 meters away in a random direction.",
                
                50 => "Vast, the spell can be maintained across multiple targest across a vast area (1D12 * 100 meters per psi point)",
                51 => "Widen, double the spells area",
                _ => "Error, outside range.",
            };

        private Dictionary<string, string> GetFederationModifiers()
        {
            return new Dictionary<string, string>()
            {
                { "Apocalyptic",GetModifierDescriptions(0)},
                { "Aquaify",GetModifierDescriptions(1)},
                { "Authoritative",GetModifierDescriptions(2)},
                { "Environment Change",GetModifierDescriptions(3)},
                { "Bliss",GetModifierDescriptions(4)},
                { "Bounce",GetModifierDescriptions(5)},
                { "Quicken",GetModifierDescriptions(6)},
                { "Burn",GetModifierDescriptions(7)},
                { "Selfish",GetModifierDescriptions(8)},
                { "Targeted Pain",GetModifierDescriptions(9)},

                { "Curse",GetModifierDescriptions(10)},
                { "Merge",GetModifierDescriptions(11)},
                { "Infectious",GetModifierDescriptions(12)},
                { "Hinge",GetModifierDescriptions(13)},
                { "Revive",GetModifierDescriptions(14)},
                { "Corpse",GetModifierDescriptions(15)},
                { "Daze",GetModifierDescriptions(16)},
                { "Wait",GetModifierDescriptions(17)},
                { "Overwhelming",GetModifierDescriptions(18)},
                { "Once Again",GetModifierDescriptions(19)},

                { "Duct Tape",GetModifierDescriptions(20)},
                { "Elemental",GetModifierDescriptions(21)},
                { "Double",GetModifierDescriptions(22)},
                { "Inspire",GetModifierDescriptions(23)},
                { "Lengthen",GetModifierDescriptions(24)},
                { "Extend",GetModifierDescriptions(25)},
                { "Indue",GetModifierDescriptions(26)},
                { "Horrifying",GetModifierDescriptions(27)}, // Fearsome
                { "Fabulous",GetModifierDescriptions(28)},
                { "Simple",GetModifierDescriptions(29)},

                { "Focused",GetModifierDescriptions(30)},
                { "Enraging",GetModifierDescriptions(31)},
                { "Dab",GetModifierDescriptions(32)},
                { "Lingering",GetModifierDescriptions(33)},
                { "Stunning",GetModifierDescriptions(34)},
                { "Multiply",GetModifierDescriptions(35)},
                { "Double-tap",GetModifierDescriptions(36)},
                { "Fast Cast",GetModifierDescriptions(37)},
                { "Terrify",GetModifierDescriptions(38)},
                { "Picky",GetModifierDescriptions(39)},

                { "Shadow",GetModifierDescriptions(40)},
                { "Snuff",GetModifierDescriptions(41)},
                { "Signature",GetModifierDescriptions(42)},
                { "Stuck",GetModifierDescriptions(43)},
                { "Darken",GetModifierDescriptions(44)},
                { "Alive Nightmare",GetModifierDescriptions(45)},
                { "Deafen",GetModifierDescriptions(46)},
                { "Knockdown",GetModifierDescriptions(47)},
                { "Amnesia",GetModifierDescriptions(48)},
                { "Throw",GetModifierDescriptions(49)},

                { "Vast",GetModifierDescriptions(50)},
                { "Widen",GetModifierDescriptions(51)},
            };
        }

        private Dictionary<string, string> GetVersianModifiers()
        {
            return new Dictionary<string, string>()
            {
                { "Apocalypsia",GetModifierDescriptions(0)},
                { "Aqua",GetModifierDescriptions(1)},
                { "Auctoritas",GetModifierDescriptions(2)},
                { "Mutare Damno",GetModifierDescriptions(3)},
                { "Beatitas",GetModifierDescriptions(4)},
                { "Resilio",GetModifierDescriptions(5)},
                { "Alacer",GetModifierDescriptions(6)},
                { "Ardens",GetModifierDescriptions(7)},
                { "Centrum",GetModifierDescriptions(8)},
                { "Amet Damnum",GetModifierDescriptions(9)},
                { "Maledictum",GetModifierDescriptions(10)},
                { "Compositae",GetModifierDescriptions(11)},
                { "Contagiosis",GetModifierDescriptions(12)},
                { "Contingens",GetModifierDescriptions(13)},
                { "Fumo",GetModifierDescriptions(14)},
                { "Mortuis",GetModifierDescriptions(15)},
                { "Daze",GetModifierDescriptions(16)},
                { "Mora",GetModifierDescriptions(17)},
                { "Turbulentos",GetModifierDescriptions(18)},
                { "Et Sonitus",GetModifierDescriptions(19)},
                { "Deorum Sanguinem",GetModifierDescriptions(20)},
                { "Elementum",GetModifierDescriptions(21)},
                { "Talem",GetModifierDescriptions(22)},
                { "Robora",GetModifierDescriptions(23)},
                { "Dilata",GetModifierDescriptions(24)},
                { "Extendere",GetModifierDescriptions(25)},
                { "Amicus",GetModifierDescriptions(26)},
                { "Formidabili",GetModifierDescriptions(27)},
                { "Candor",GetModifierDescriptions(28)},
                { "Fluxa",GetModifierDescriptions(29)},
                { "Conuenerunt",GetModifierDescriptions(30)},
                { "Furens",GetModifierDescriptions(31)},
                { "Intendet",GetModifierDescriptions(32)},
                { "Morantem",GetModifierDescriptions(33)},
                { "Misericors",GetModifierDescriptions(34)},
                { "Multa",GetModifierDescriptions(35)},
                { "Pertinax",GetModifierDescriptions(36)},
                { "Redintegrare",GetModifierDescriptions(37)},
                { "Cicatrix",GetModifierDescriptions(38)},
                { "Lecta",GetModifierDescriptions(39)},
                { "Umbra",GetModifierDescriptions(40)},
                { "Extinguere",GetModifierDescriptions(41)},
                { "Propria",GetModifierDescriptions(42)},
                { "Tenax",GetModifierDescriptions(43)},
                { "Tenebrescere",GetModifierDescriptions(44)},
                { "Minaces Illusio",GetModifierDescriptions(45)},
                { "Tonitrua",GetModifierDescriptions(46)},
                { "Pronus",GetModifierDescriptions(47)},
                { "Dolum",GetModifierDescriptions(48)},
                { "Turbatur",GetModifierDescriptions(49)},
                { "Immensa",GetModifierDescriptions(50)},
                { "Dilatanda",GetModifierDescriptions(51)},
            };
        }

        private Dictionary<string, string> GetSithModifiers()
        {
            return new Dictionary<string, string>()
            {
                { "Apocaliptica",GetModifierDescriptions(0)},
                { "Licuar",GetModifierDescriptions(1)},
                { "Autoridad",GetModifierDescriptions(2)},
                { "Cambiar Dano",GetModifierDescriptions(3)},
                { "Feliz",GetModifierDescriptions(4)},
                { "Rebotar",GetModifierDescriptions(5)},
                { "Activo",GetModifierDescriptions(6)},
                { "Ardiente",GetModifierDescriptions(7)},
                { "Centrar",GetModifierDescriptions(8)},
                { "Dolor Dirigido",GetModifierDescriptions(9)},

                { "Maldicion",GetModifierDescriptions(10)},
                { "Unir",GetModifierDescriptions(11)},
                { "Transmisible",GetModifierDescriptions(12)},
                { "Contigente",GetModifierDescriptions(13)},
                { "Cripta",GetModifierDescriptions(14)},
                { "Muerto",GetModifierDescriptions(15)},
                { "Aturdimiento",GetModifierDescriptions(16)},
                { "Retrasar",GetModifierDescriptions(17)},
                { "Disruptivo",GetModifierDescriptions(18)},
                { "Eco",GetModifierDescriptions(19)},

                { "Puente",GetModifierDescriptions(20)},
                { "Cambiar Elemental",GetModifierDescriptions(21)},
                { "Autorizar",GetModifierDescriptions(22)},
                { "Alentar",GetModifierDescriptions(23)},
                { "Agrandar",GetModifierDescriptions(24)},
                { "Ampliar",GetModifierDescriptions(25)},
                { "Obligado",GetModifierDescriptions(26)},
                { "Temible",GetModifierDescriptions(27)},
                { "Deslumbrar",GetModifierDescriptions(28)},
                { "Fugaz",GetModifierDescriptions(29)},

                { "Enfocada",GetModifierDescriptions(30)},
                { "Furiosa",GetModifierDescriptions(31)},
                { "Intensificar",GetModifierDescriptions(32)},
                { "Constante",GetModifierDescriptions(33)},
                { "Misericodioso",GetModifierDescriptions(34)},
                { "Multiplicar",GetModifierDescriptions(35)},
                { "Persistente",GetModifierDescriptions(36)},
                { "Acelerar",GetModifierDescriptions(37)},
                { "Cicatrices",GetModifierDescriptions(38)},
                { "Selectiva",GetModifierDescriptions(39)},

                { "Sombra",GetModifierDescriptions(40)},
                { "Inhalar",GetModifierDescriptions(41)},
                { "Estilizado",GetModifierDescriptions(42)},
                { "Tenaz",GetModifierDescriptions(43)},
                { "Tenebroso",GetModifierDescriptions(44)},
                { "Illusion Amenazante",GetModifierDescriptions(45)},
                { "Tremendo",GetModifierDescriptions(46)},
                { "Derrocar",GetModifierDescriptions(47)},
                { "Enganar",GetModifierDescriptions(48)},
                { "Tumultuoso",GetModifierDescriptions(49)},

                { "Vasto",GetModifierDescriptions(50)},
                { "Ensanchar",GetModifierDescriptions(51)},
            };
        }

        private Dictionary<string, string> GetJediModifiers()
        {
            return new Dictionary<string, string>()
            {
                { "Apocaliptico",GetModifierDescriptions(0)},
                { "Liquefazar",GetModifierDescriptions(1)},
                { "Autoridade",GetModifierDescriptions(2)},
                { "Mudar Dano",GetModifierDescriptions(3)},
                { "Alegre",GetModifierDescriptions(4)},
                { "Pulo",GetModifierDescriptions(5)},
                { "Ativo",GetModifierDescriptions(6)},
                { "Queimando",GetModifierDescriptions(7)},
                { "Centro",GetModifierDescriptions(8)},
                { "Dor Dirigida",GetModifierDescriptions(9)},

                { "Droga",GetModifierDescriptions(10)},
                { "ligacao",GetModifierDescriptions(11)},
                { "Transmissivel",GetModifierDescriptions(12)},
                { "Contingencia",GetModifierDescriptions(13)},
                { "Tumulo",GetModifierDescriptions(14)},
                { "Morto",GetModifierDescriptions(15)},
                { "Daze",GetModifierDescriptions(16)},
                { "Atrasar",GetModifierDescriptions(17)},
                { "Perturbador",GetModifierDescriptions(18)},
                { "Repetir",GetModifierDescriptions(19)},

                { "Ponte",GetModifierDescriptions(20)},
                { "Mudanca Elemental",GetModifierDescriptions(21)},
                { "Ordem",GetModifierDescriptions(22)},
                { "Incentive",GetModifierDescriptions(23)},
                { "Alongar",GetModifierDescriptions(24)},
                { "Prolongar",GetModifierDescriptions(25)},
                { "Obrigado",GetModifierDescriptions(26)},
                { "Temivel",GetModifierDescriptions(27)},
                { "chama",GetModifierDescriptions(28)},
                { "Breve",GetModifierDescriptions(29)},

                { "Determinado",GetModifierDescriptions(30)},
                { "Enfurecido",GetModifierDescriptions(31)},
                { "Piorar",GetModifierDescriptions(32)},
                { "Interminavel",GetModifierDescriptions(33)},
                { "Perdoando",GetModifierDescriptions(34)},
                { "Produtos",GetModifierDescriptions(35)},
                { "Duradouro",GetModifierDescriptions(36)},
                { "Acelere",GetModifierDescriptions(37)},
                { "Cicatrizes",GetModifierDescriptions(38)},
                { "Seletivo",GetModifierDescriptions(39)},

                { "Sombra",GetModifierDescriptions(40)},
                { "Inalar",GetModifierDescriptions(41)},
                { "Personalizada",GetModifierDescriptions(42)},
                { "Persistente",GetModifierDescriptions(43)},
                { "Escurecer",GetModifierDescriptions(44)},
                { "Ilusao Ameacadora",GetModifierDescriptions(45)},
                { "Trovejante",GetModifierDescriptions(46)},
                { "Tombar",GetModifierDescriptions(47)},
                { "Engancao",GetModifierDescriptions(48)},
                { "Tumultuado",GetModifierDescriptions(49)},

                { "Grande",GetModifierDescriptions(50)},
                { "Ampliar",GetModifierDescriptions(51)},
            };
        }

        //Name, Spell Description
        public Dictionary<string, string> GetPlanesWords(FreeFormLanguages language) =>
            language switch
            {
                FreeFormLanguages.FederationCommon => GetFederationPlanes(),
                FreeFormLanguages.HighVersian => GetVersianPlanes(),
                FreeFormLanguages.Sith => GetSithPlanes(),
                FreeFormLanguages.Jedi => GetJediPlanes(),
                _ => new Dictionary<string, string>()
            };

        public Dictionary<string, string> GetActionWords(FreeFormLanguages language)
            => language switch
            {
                FreeFormLanguages.FederationCommon => GetFederationAction(),
                FreeFormLanguages.HighVersian => GetVersianAction(),
                FreeFormLanguages.Sith => GetSithAction(),
                FreeFormLanguages.Jedi => GetJediAction(),
                _ => new Dictionary<string, string>()
            };

        public Dictionary<string, string> GetTargetWords(FreeFormLanguages language)
            => language switch
            {
                FreeFormLanguages.FederationCommon => GetFederationTargets(),
                FreeFormLanguages.HighVersian => GetVersianTargets(),
                FreeFormLanguages.Sith => GetSithTargets(),
                FreeFormLanguages.Jedi => GetJediTargets(),
                _ => new Dictionary<string, string>()
            };

        public Dictionary<string, string> GetModifiersWords(FreeFormLanguages language)
            => language switch
            {
                FreeFormLanguages.FederationCommon => GetFederationModifiers(),
                FreeFormLanguages.HighVersian => GetVersianModifiers(),
                FreeFormLanguages.Sith => GetSithModifiers(),
                FreeFormLanguages.Jedi => GetJediModifiers(),
                _ => new Dictionary<string, string>()
            };
    }
}
