namespace TravellerCharacter.CharacterCreator.Items
{
    public class TravellerWeaponTrait
    {
        public TravellerWeaponTrait(TravellerWeaponTraits trait)
        {
            WeaponTrait = trait;
        }

        public TravellerWeaponTraits WeaponTrait { get; set; }

        public string TraitText()
        {
            return AnyTraitText(WeaponTrait);
        }

        public static string AnyTraitText(TravellerWeaponTraits weaponTrait)
        {
            return weaponTrait switch
            {
                TravellerWeaponTraits.None => "No Trait",
                TravellerWeaponTraits.AP_X =>
                    "This weapon has the ability to punch through armour through the use of specially shaped ammunition or high technology. It will ignore an amount of Armour equal to the AP score listed. " +
                    "Spacecraft Scale targets ignore the AP trait unless the weapon making the attack is also Spacecraft Scale.",
                TravellerWeaponTraits.AP_1 => "This weapon ignores 1 point of armour.",
                TravellerWeaponTraits.AP_2 => "This weapon ignores 2 points of armour.",
                TravellerWeaponTraits.AP_3 => "This weapon ignores 3 points of armour.",
                TravellerWeaponTraits.AP_4 => "This weapon ignores 4 points of armour.",
                TravellerWeaponTraits.AP_5 => "This weapon ignores 5 points of armour.",
                TravellerWeaponTraits.AP_6 => "This weapon ignores 6 points of armour.",
                TravellerWeaponTraits.AP_7 => "This weapon ignores 7 points of armour.",
                TravellerWeaponTraits.AP_8 => "This weapon ignores 8 points of armour.",
                TravellerWeaponTraits.AP_9 => "This weapon ignores 9 points of armour.",
                TravellerWeaponTraits.AP_10 => "This weapon ignores 10 points of armour.",

                TravellerWeaponTraits.Artillery =>
                    "Artillery weapons shoot projectiles along a ballistic trajectory, allowing them to ‘lob’ shots at targets that are out of sight. " +
                    "When firing at a target that can be seen, these Artillery weapons follow the usual rules for ranged attacks.When attempting indirect fire at a " +
                    "target that cannot be physically seen, the attack suffers a DM-2 penalty. In addition, if the precise location of the targets is not known " +
                    "(enemies are behind a wall or have ducked down into a trench, for example) then the attack will land 1D metres in a random " +
                    "direction away from them for every 100 metres or part of the target is from the attacker, minus the Effect of the attack roll. " +
                    "A negative Effect will, of course, add to this distance instead.It is worth remembering that knowing where targets may be does " +
                    "not necessarily mean they need to be physically seen. The use of sensors, as described on page 150 of the Traveller Core Rulebook, " +
                    "can provide a very good indication where enemies are lurking. ",

                TravellerWeaponTraits.Auto_X =>
                    "These weapons fire multiple rounds with every pull of the trigger, filling the air with a hail of fire. A weapon with the Auto trait can make" +
                    " attacks in three fire modes: single, burst, and full auto.Single: Attacks are made using the normal combat rules.Burst: Add the Auto score to damage. " +
                    "This uses a number of rounds equal to the Auto score.Full Auto: Make a number of attacks equal to the Auto score. These attacks can be made against separate targets so" +
                    " long as they are all within six metres of one another. Full auto uses a number of rounds equal to three times the Auto score.A weapon cannot use " +
                    "the Auto trait in the same action as the Scope trait or aiming action.",
                TravellerWeaponTraits.Auto_1 => "Make up to 1 Automatic attacks",
                TravellerWeaponTraits.Auto_2 => "Make up to 2 Automatic attacks",
                TravellerWeaponTraits.Auto_3 => "Make up to 3 Automatic attacks",
                TravellerWeaponTraits.Auto_5 => "Make up to 5 Automatic attacks",

                TravellerWeaponTraits.Blast_X =>
                    "This weapon has an explosive component or is otherwise able to affect targets spread across a wide area. " +
                    "Upon a successful attack, damage is rolled against every target within the weapon’s Blast score in metres. " +
                    "Dodge Reactions may not be made against a Blast weapon, but targets may dive for cover. Cover may be taken " +
                    "advantage of if it lies between a target and the centre of the weapon’s Blast.",
                TravellerWeaponTraits.Blast_0 =>
                    "Explodes, upon successful attack roll damage against everyone within 0 meters.",
                TravellerWeaponTraits.Blast_1 =>
                    "Explodes, upon successful attack roll damage against everyone within 1 meter.",
                TravellerWeaponTraits.Blast_2 =>
                    "Explodes, upon successful attack roll damage against everyone within 2 meters.",
                TravellerWeaponTraits.Blast_3 =>
                    "Explodes, upon successful attack roll damage against everyone within 3 meters.",
                TravellerWeaponTraits.Blast_4 =>
                    "Explodes, upon successful attack roll damage against everyone within 4 meters.",
                TravellerWeaponTraits.Blast_5 =>
                    "Explodes, upon successful attack roll damage against everyone within 5 meters.",
                TravellerWeaponTraits.Blast_6 =>
                    "Explodes, upon successful attack roll damage against everyone within 6 meters.",
                TravellerWeaponTraits.Blast_9 =>
                    "Explodes, upon successful attack roll damage against everyone within 9 meters.",
                TravellerWeaponTraits.Blast_10 =>
                    "Explodes, upon successful attack roll damage against everyone within 10 meters.",
                TravellerWeaponTraits.Blast_12 =>
                    "Explodes, upon successful attack roll damage against everyone within 12 meters.",
                TravellerWeaponTraits.Blast_15 =>
                    "Explodes, upon successful attack roll damage against everyone within 15 meters.",
                TravellerWeaponTraits.Blast_20 =>
                    "Explodes, upon successful attack roll damage against everyone within 20 meters.",
                TravellerWeaponTraits.Blast_25 =>
                    "Explodes, upon successful attack roll damage against everyone within 25 meters.",
                TravellerWeaponTraits.Blast_30 =>
                    "Explodes, upon successful attack roll damage against everyone within 30 meters.",
                TravellerWeaponTraits.Blast_50 =>
                    "Explodes, upon successful attack roll damage against everyone within 50 meters.",
                TravellerWeaponTraits.Blast_100 =>
                    "Explodes, upon successful attack roll damage against everyone within 100 meters.",
                TravellerWeaponTraits.Blast_1000 =>
                    "Explodes, upon successful attack roll damage against everyone within 1000 meters.",


                TravellerWeaponTraits.Bulky =>
                    "A Bulky weapon has a powerful recoil or is simply extremely heavy – this makes it difficult to use effectively in combat by someone of a weak physical stature. " +
                    "A Traveller using a Bulky weapon must have STR 9 or higher to use it without penalty. Otherwise, all attack rolls will have a negative DM equal to " +
                    "the difference between their STR DM and +1.",

                TravellerWeaponTraits.Dangerous =>
                    "This weapon can be as lethal to the Traveller using it as his intended target. " +
                    "If an attack roll is made by this weapon with an Effect of -5 or worse, it explodes. " +
                    "Its damage is inflicted upon the Traveller firing it, and the weapon is rendered inoperable",

                TravellerWeaponTraits.Fire =>
                    "This weapon sets a target on fire, causing damage every round after the initial attack. " +
                    "A target can only be set on fire by one Fire weapon at a time – use the highest damage Fire weapon. " +
                    "Left to its own devices, a fire will extinguish itself on a 2D roll of 8+, rolled for at the start of " +
                    "every round. However, the referee may rule it continues to burn so long as flammable material is " +
                    "present. A Traveller may use a Significant Action to extinguish requiring an Average (8+) DEX check." +
                    " The Traveller gains DM+2 if they are using firefighting equipment",

                TravellerWeaponTraits.One_Use =>
                    "This weapon is designed to be used just once, completely expending its energy or ammunition " +
                    "in one go and then being rendered useless.",

                TravellerWeaponTraits.Radiation =>
                    "When a Radiation weapon is fired, anyone close to the firer, target and the line of fire " +
                    "in-between the two will receive 2D x 20 rads, multiplied by 5 for Spacecraft scale weapons. " +
                    "This effect extends from the firer, target and line of fire a distance in metres equal to the" +
                    " number of dice the weapon rolls for damage. If the fusion weapon is Destructive, this distance" +
                    " becomes ten times the number of dice rolled for damage.",

                TravellerWeaponTraits.Scope =>
                    "The weapon has been fitted with vision-enhancing sights, allowing it to put shots on target " +
                    "from far greater ranges. A weapon with the Scope trait ignores the rule that limits all attacks " +
                    "made at a range greater than 100 metres are automatically Extreme Range," +
                    " so long as the Traveller aims before shooting.",

                TravellerWeaponTraits.Smart =>
                    "This weapon has intelligent or semi-intelligent rounds that are able to guide themselves onto a " +
                    "target. They gain a DM to their attack rolls equal to the difference between their TL and that of" +
                    " the target, to a minimum of DM+1 and a maximum of DM+6.",

                TravellerWeaponTraits.Silent =>
                    "Most projectile weapons require a noisy discharge of chemical, heat or kinetic energy" +
                    " in order to attack, but this weapon channels " +
                    "or removes the excess sound energy also created. Any attempts to detect the sound of this" +
                    " weapon firing suffer DM-6",

                TravellerWeaponTraits.Smasher => "This weapon is particularly heavy and carries a great deal of" +
                                                 " momentum when it is swung. A Traveller attacked by a Smasher weapon may not attempt to parry it",

                TravellerWeaponTraits.Stun =>
                    "These weapons are designed to deal non-lethal damage, incapacitating a living target rather than " +
                    "killing it. Damage is only deducted from END, taking into account any armour. If the target’s END " +
                    "is reduced to 0, the target will be incapacitated and unable to perform any actions for a number of " +
                    "rounds by which the damage exceeded his END. " +
                    "Damage received from Stun weapons is completely healed by one hour of rest.",

                TravellerWeaponTraits.VeryBulky =>
                    "Some weapons are designed only for the strongest combatants. A Traveller using a Very " +
                    "Bulky weapon must have STR 12 or higher to use it without penalty." +
                    " Otherwise, all attack rolls will have a negative DM equal to the difference between " +
                    "their STR DM and +2.",

                TravellerWeaponTraits.VeryDangerous =>
                    "Only a madman uses a weapon with the reputation of this one. If an attack roll " +
                    "is made by this weapon with an Effect of -3 or worse, " +
                    "it explodes. Its damage is inflicted upon the Traveller firing it, and the weapon is" +
                    " rendered inoperable",

                TravellerWeaponTraits.Void => "Draws power from the void, has that mystical other-plane flair to it.",

                TravellerWeaponTraits.Zero_G => "This weapon has little or no recoil," +
                                                " allowing it to be used in low or zero gravity situations without requiring an" +
                                                " Athletics (dexterity) check.",
                _ => "None"
            };
        }
    }
}