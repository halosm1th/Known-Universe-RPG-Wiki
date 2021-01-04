using System;

namespace TravellerWiki.Data.Charcters
{
    public class TravellerSkill
    {
        public enum TravellerSkills
        {
            Admin,
            Advocate,
            Animals,
            Animals_Handling,
            Animals_Training,
            Animals_Veterinary,
            Art,
            Art_Holography,
            Art_Instrument,
            Art_Preformer,
            Art_VisualMedia,
            Art_Write,
            Astrogation,
            Athletics,
            Athletics_Dexterity,
            Athletics_Endurance,
            Athletics_Strength,
            Broker,
            Carouse,
            Circle,
            Circle_Abyss,
            Circle_Aether,
            Circle_Material,
            Circle_Nether,
            Circle_Void,
            Deception,
            Diplomat,
            Drive,
            Drive_HoverCraft,
            Drive_Mole,
            Drive_Track,
            Drive_Walker,
            Drive_Wheel,
            Electronics,
            Electronics_Comms,
            Electronics_Computers,
            Electronics_RemoteOps,
            Electronics_Sensors,
            Engineer,
            Engineer_JDrive,
            Engineer_LifeSupport,
            Engineer_MDrive,
            Engineer_Power,
            Explosives,
            Flyer,
            Flyer_Airship,
            Flyer_Grav,
            Flyer_Ornithopter,
            Flyer_Roter,
            Flyer_Wing,
            FreeForm,
            FreeForm_Abyss,
            FreeForm_Aether,
            FreeForm_Material,
            FreeForm_Nether,
            FreeForm_Void,
            Gambler,
            GunCombat,
            GunCombat_Archaic,
            GunCombat_Energy,
            GunCombat_Slug,
            Gunner,
            Gunner_Capital,
            Gunner_Ortillery,
            Gunner_Screen,
            Gunner_Turret,
            HeavyWeapons,
            HeavyWeapons_Artillery,
            HeavyWeapons_ManPortable,
            HeavyWeapons_Vehicle,
            Investigate,
            JackOfAllTrades,
            Language,
            Language_AxiosCommon,
            Language_AxiosPolitical,
            Langauge_Britannian,
            Language_Common,
            Langauge_ElderTongue,
            Language_FederationCommon,
            Language_germushian,
            Langauge_HighImperial,
            Language_HighVersian,
            Langauge_Jedi,
            Langauge_LowImperial,
            Langauge_LowVersian,
            Langauge_Sigmarian,
            Language_Tekka,
            Language_TradersCant,
            Langauge_Utopian,
            Language_Witcher,
            Langauge_XiaoMing,
            Leadership,
            Luck,
            Mechanic,
            Medic,
            Melee,
            Melee_Unarmed,
            Melee_Blade,
            Melee_Bludgeon,
            Melee_Natural,
            Melee_Void,
            Navigation,
            Persuade,
            Pilot,
            Pilot_CapitalShips,
            Pilot_SmallCraft,
            Pilot_Spacecraft,
            Profession,
            Profession_Belter,
            Profession_Biologicals,
            Profession_CivilEngineering,
            Profession_Construction,
            Profession_Hydroponics,
            Profession_Polymers,
            Recon,
            Science,
            Science_Archaeology,
            Science_Astronomy,
            Science_Biology,
            Science_Chemistry,
            Science_Cosmology,
            Science_Cybernetics,
            Science_Economics,
            Science_Genetics,
            Science_History,
            Science_Linguistics,
            Science_Philosophy,
            Science_Physics,
            Science_Planetology,
            Science_Psychology,
            Science_Robotics,
            Science_Sophontology,
            Science_Voidology,
            Science_Xenology,
            Seafarer,
            Seafarer_OceanShips,
            Seafarer_Personal,
            Seafarer_Sail,
            Seafarer_Submarine,
            SigmarsAid,
            SigmarsAir,
            SigmarsFreeze,
            SigmarsFlame,
            SigmarsGuidance,
            SigamrsHand,
            SigmarsKnowledge,
            SigmarsLight,
            SigmarsWater,
            Stealth,
            Steward,
            StreetWise,
            Survival,
            Tactics,
            Tactics_Military,
            Tactics_Naval,
            VaccSuit

        }

        public TravellerSkills SkillName { get; set; }
        public int SkillValue { get; set; }

        public TravellerSkill(TravellerSkills name, int baseValue = 0)
        {
            SkillName = name;
            SkillValue = baseValue;
        }
        public void IncreaseSkill(TravellerSkills skill, int amountToIncreaseBy)
        {
            switch (skill)
            {
                case TravellerSkills.Animals:
                    if (SkillName == TravellerSkills.Animals_Handling)
                    {
                        SkillValue += amountToIncreaseBy;
                    }else if (SkillName == TravellerSkills.Animals_Training)
                    {
                        
                    }else if (SkillName == TravellerSkills.Animals_Veterinary)
                    {

                    }
                    break;
                case TravellerSkills.Animals_Handling:
                    break;
                case TravellerSkills.Animals_Training:
                    break;
                case TravellerSkills.Animals_Veterinary:
                    break;
                case TravellerSkills.Art:
                    break;
                case TravellerSkills.Art_Holography:
                    break;
                case TravellerSkills.Art_Instrument:
                    break;
                case TravellerSkills.Art_Preformer:
                    break;
                case TravellerSkills.Art_VisualMedia:
                    break;
                case TravellerSkills.Art_Write:
                    break;
                case TravellerSkills.Athletics:
                    break;
                case TravellerSkills.Athletics_Dexterity:
                    break;
                case TravellerSkills.Athletics_Endurance:
                    break;
                case TravellerSkills.Athletics_Strength:
                    break;
                case TravellerSkills.Circle:
                    break;
                case TravellerSkills.Circle_Abyss:
                    break;
                case TravellerSkills.Circle_Aether:
                    break;
                case TravellerSkills.Circle_Material:
                    break;
                case TravellerSkills.Circle_Nether:
                    break;
                case TravellerSkills.Circle_Void:
                case TravellerSkills.Drive:
                    break;
                case TravellerSkills.Drive_HoverCraft:
                    break;
                case TravellerSkills.Drive_Mole:
                    break;
                case TravellerSkills.Drive_Track:
                    break;
                case TravellerSkills.Drive_Walker:
                    break;
                case TravellerSkills.Drive_Wheel:
                    break;
                case TravellerSkills.Electronics:
                    break;
                case TravellerSkills.Electronics_Comms:
                    break;
                case TravellerSkills.Electronics_Computers:
                    break;
                case TravellerSkills.Electronics_RemoteOps:
                    break;
                case TravellerSkills.Electronics_Sensors:
                    break;
                case TravellerSkills.Engineer:
                    break;
                case TravellerSkills.Engineer_JDrive:
                    break;
                case TravellerSkills.Engineer_LifeSupport:
                    break;
                case TravellerSkills.Engineer_MDrive:
                    break;
                case TravellerSkills.Engineer_Power:
                    break;
                case TravellerSkills.Flyer:
                    break;
                case TravellerSkills.Flyer_Airship:
                    break;
                case TravellerSkills.Flyer_Grav:
                    break;
                case TravellerSkills.Flyer_Ornithopter:
                    break;
                case TravellerSkills.Flyer_Roter:
                    break;
                case TravellerSkills.Flyer_Wing:
                    break;
                case TravellerSkills.FreeForm:
                    break;
                case TravellerSkills.FreeForm_Abyss:
                    break;
                case TravellerSkills.FreeForm_Aether:
                    break;
                case TravellerSkills.FreeForm_Material:
                    break;
                case TravellerSkills.FreeForm_Nether:
                    break;
                case TravellerSkills.FreeForm_Void:
                    break;
                case TravellerSkills.GunCombat:
                    break;
                case TravellerSkills.GunCombat_Archaic:
                    break;
                case TravellerSkills.GunCombat_Energy:
                    break;
                case TravellerSkills.GunCombat_Slug:
                    break;
                case TravellerSkills.Gunner:
                    break;
                case TravellerSkills.Gunner_Capital:
                    break;
                case TravellerSkills.Gunner_Ortillery:
                    break;
                case TravellerSkills.Gunner_Screen:
                    break;
                case TravellerSkills.Gunner_Turret:
                    break;
                case TravellerSkills.HeavyWeapons:
                    break;
                case TravellerSkills.HeavyWeapons_Artillery:
                    break;
                case TravellerSkills.HeavyWeapons_ManPortable:
                    break;
                case TravellerSkills.HeavyWeapons_Vehicle:
                    break;
                case TravellerSkills.Language:
                    break;
                case TravellerSkills.Language_AxiosCommon:
                    break;
                case TravellerSkills.Language_AxiosPolitical:
                    break;
                case TravellerSkills.Langauge_Britannian:
                    break;
                case TravellerSkills.Language_Common:
                    break;
                case TravellerSkills.Langauge_ElderTongue:
                    break;
                case TravellerSkills.Language_FederationCommon:
                    break;
                case TravellerSkills.Language_germushian:
                    break;
                case TravellerSkills.Langauge_HighImperial:
                    break;
                case TravellerSkills.Language_HighVersian:
                    break;
                case TravellerSkills.Langauge_Jedi:
                    break;
                case TravellerSkills.Langauge_LowImperial:
                    break;
                case TravellerSkills.Langauge_LowVersian:
                    break;
                case TravellerSkills.Langauge_Sigmarian:
                    break;
                case TravellerSkills.Language_Tekka:
                    break;
                case TravellerSkills.Language_TradersCant:
                    break;
                case TravellerSkills.Langauge_Utopian:
                    break;
                case TravellerSkills.Language_Witcher:
                    break;
                case TravellerSkills.Langauge_XiaoMing:
                    break;
                case TravellerSkills.Melee:
                    break;
                case TravellerSkills.Melee_Unarmed:
                    break;
                case TravellerSkills.Melee_Blade:
                    break;
                case TravellerSkills.Melee_Bludgeon:
                    break;
                case TravellerSkills.Melee_Natural:
                    break;
                case TravellerSkills.Melee_Void:
                    break;
                case TravellerSkills.Pilot:
                    break;
                case TravellerSkills.Pilot_CapitalShips:
                    break;
                case TravellerSkills.Pilot_SmallCraft:
                    break;
                case TravellerSkills.Pilot_Spacecraft:
                    break;
                case TravellerSkills.Profession:
                    break;
                case TravellerSkills.Profession_Belter:
                    break;
                case TravellerSkills.Profession_Biologicals:
                    break;
                case TravellerSkills.Profession_CivilEngineering:
                    break;
                case TravellerSkills.Profession_Construction:
                    break;
                case TravellerSkills.Profession_Hydroponics:
                    break;
                case TravellerSkills.Profession_Polymers:
                    break;
                case TravellerSkills.Science:
                    break;
                case TravellerSkills.Science_Archaeology:
                    break;
                case TravellerSkills.Science_Astronomy:
                    break;
                case TravellerSkills.Science_Biology:
                    break;
                case TravellerSkills.Science_Chemistry:
                    break;
                case TravellerSkills.Science_Cosmology:
                    break;
                case TravellerSkills.Science_Cybernetics:
                    break;
                case TravellerSkills.Science_Economics:
                    break;
                case TravellerSkills.Science_Genetics:
                    break;
                case TravellerSkills.Science_History:
                    break;
                case TravellerSkills.Science_Linguistics:
                    break;
                case TravellerSkills.Science_Philosophy:
                    break;
                case TravellerSkills.Science_Physics:
                    break;
                case TravellerSkills.Science_Planetology:
                    break;
                case TravellerSkills.Science_Psychology:
                    break;
                case TravellerSkills.Science_Robotics:
                    break;
                case TravellerSkills.Science_Sophontology:
                    break;
                case TravellerSkills.Science_Voidology:
                    break;
                case TravellerSkills.Science_Xenology:
                    break;
                case TravellerSkills.Seafarer:
                    break;
                case TravellerSkills.Seafarer_OceanShips:
                    break;
                case TravellerSkills.Seafarer_Personal:
                    break;
                case TravellerSkills.Seafarer_Sail:
                    break;
                case TravellerSkills.Seafarer_Submarine:
                    break;
                case TravellerSkills.SigmarsAid:
                    break;
                case TravellerSkills.SigmarsAir:
                    break;
                case TravellerSkills.SigmarsFreeze:
                    break;
                case TravellerSkills.SigmarsFlame:
                    break;
                case TravellerSkills.SigmarsGuidance:
                    break;
                case TravellerSkills.SigamrsHand:
                    break;
                case TravellerSkills.SigmarsKnowledge:
                    break;
                case TravellerSkills.SigmarsLight:
                    break;
                case TravellerSkills.SigmarsWater:
                    break;
                case TravellerSkills.Tactics:
                    break;
                case TravellerSkills.Tactics_Military:
                    break;
                case TravellerSkills.Tactics_Naval:
                    break;
                default:
                    SkillValue += amountToIncreaseBy;
                    break;
            }
        }
    }
}