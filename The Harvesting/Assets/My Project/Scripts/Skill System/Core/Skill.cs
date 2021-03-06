using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="new skill", menuName ="Data/Skills/Skill")]
    public class Skill : ScriptableObject
    {
        [Header("SKILL DESCRIPTION")]
        public Sprite Icon;
        public string Name;
        [TextArea(5,15)]
        public string Description;
        public int ManaCost = 0;
        public float RechargeTime = 0f;
        [Space(20)]

        [Header("VISUAL EFFECT")]
        public SkillPrefab DefaultVFXPrefab;
        public SkillSpawnLocation PlayerSpawnLocation = SkillSpawnLocation.Center;
        [Space(20)]

        [Header("ACTIVATION")]
        [Range(0, 100)]
        public float TriggerChance = 100f;
        public SkillTriggerCondition TriggerCondition;

        public bool FaceDirection = true;
        public bool IsMelee = false;
        public bool IsSpell = true;
        public bool IsMovementSkill = false;
        public bool RemovesRoot = false;
        public bool RemovesStun = false;
        public bool CanBeUsedWhileStunned = false;
        public bool RemovesSilence = false;

        public bool IsCastOnSelf = false;
        public CharacterAnimationData PlayerAnimation;


        public Skill ImpactSkill;

        [Header("If Action's VFX Prefab is empty, then default one is used.")]
        public List<SkillAction> Actions;
        
        public void Spawn(ICharacterCore activator, Transform location)
        {
            if(Random.Range(0,100) > TriggerChance && !TriggerCondition.Evaluate(activator))
            {
                return;
            }

            SkillPrefab spawn;
            if (DefaultVFXPrefab != null)
            {
                spawn = Instantiate(DefaultVFXPrefab, location);
                if (!IsCastOnSelf)
                {
                    spawn.gameObject.transform.SetParent(null);
                }
                spawn.Initialize(activator);

                foreach(SkillAction action in Actions)
                {
                    if (Random.Range(0, 100) > action.TriggerChance && (action.TriggerCondition == null ||  !action.TriggerCondition.Evaluate(action, activator)) )
                    {
                        continue;
                    } 


                    if (action.SkillVFX == null)
                    {
                        spawn.SkillActions.Add(action);
                    } else
                    {
                        var vfxSpawn = Instantiate(action.SkillVFX, location);
                        vfxSpawn.transform.parent = null;
                        vfxSpawn.SkillActions.Add(action);
                        vfxSpawn.Initialize(activator);
                    }
                }
            }

        }
    }
}