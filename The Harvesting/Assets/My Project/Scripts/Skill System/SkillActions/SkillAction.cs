using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    /// <summary>
    /// Skill Actions are the individual effects of Skills. 
    /// </summary>

    [System.Serializable]
    public class SkillAction
    {
        //Activation
        [Header("Activation")]
        public SkillActionTriggerCondition TriggerCondition;
        [Range(0, 100)]
        public float TriggerChance = 100f;
        [Space(20)]

        public bool ContinousDamage = false;
        public float TickRatePerSecond = 1f;

        public SkillActionType Type;
        public Modifier Modifier;
        public SkillActionElement Element;
        public CharacterState CharacterStatusEffect;
        public StatusEffect DamageStatusEffect;
        public GameObject OnMonsterEffect;
        public Attribute ResourceToDrain;
        public float DrainAmount;
        public bool IsDrainAmountPercentage = false;

        public SkillPrefab SkillVFX;
    }
}