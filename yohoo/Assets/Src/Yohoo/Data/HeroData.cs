using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HeroData
{
    public string dbName;
    public string Model;
    public string SoundSet;
    public string IdleExpression;
    public string HeroID;
    public string Enabled;
    public string HeroUnlockOrder;
    public string Role;
    public string Rolelevels;
    public string Complexity;
    public string Team;
    public string Portrait;
    public string ModelScale;
    public string HeroGlowColor;
    public string PickSound;
    public string BanSound;
    public string CMEnabled;
    public string NameAliases;
    public string url;
    public string LastHitChallengeRival;
    public string HeroSelectSoundEffect;

    // Abilities
    //-------------------------------------------------------------------------------------------------------------
    public string Ability1;
    public string Ability2;
    public string Ability3;
    public string Ability4;

    // Armor
    //-------------------------------------------------------------------------------------------------------------
    public string ArmorPhysical;

    // Attack
    //-------------------------------------------------------------------------------------------------------------
    public string AttackCapabilities;
    public string AttackDamageMin
    {
        get
        {
            return "";
        }
    }
    public string AttackDamageMax;
    public string AttackRate;
    public string AttackAnimationPoint;
    public string AttackAcquisitionRange;
    public string AttackRange;
    public string ProjectileSpeed;

    // Attributes
    //-------------------------------------------------------------------------------------------------------------
    public string AttributePrimary;
    public string AttributeBaseStrength;
    public string AttributeStrengthGain;
    public string AttributeBaseIntelligence;
    public string AttributeIntelligenceGain;
    public string AttributeBaseAgility;
    public string AttributeAgilityGain;

    // Movement
    //-------------------------------------------------------------------------------------------------------------
    public string MovementSpeed;
    public string MovementTurnRate;
    public string BoundsHullName;
    public string HealthBarOffset;
    public string particle_folder;
    public string GameSoundsFile;
    public string VoiceFile;
}
