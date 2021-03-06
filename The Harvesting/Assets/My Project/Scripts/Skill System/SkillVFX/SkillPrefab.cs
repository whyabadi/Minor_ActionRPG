using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    //[RequireComponent(typeof(SkillVFXParametersScript))]
   
    public abstract class SkillPrefab : MonoBehaviour
    {
        [HideInInspector]
        protected ICharacterCore _performer;
        public List<Skill> ImpactSkills = new List<Skill>();
        protected List<ICharacterCore> monstersInCollider = new List<ICharacterCore>();
        protected int NumberOfEnemiesHit = 0;

        [HideInInspector]
        public List<SkillAction> SkillActions = new List<SkillAction>();

        public void TriggerSkillActions(ICharacterCore attacker, ICharacterCore receiver)
        {
            if (SkillActions.Count != 0)
            {
                foreach (SkillAction action in SkillActions)
                {
                    TriggerSkillAction(attacker, receiver, action);
                    NumberOfEnemiesHit++;

                    if (action.ContinousDamage)
                    {
                        StartCoroutine(TriggerContinuous(action));
                    }
                }
            }
        }

        public void TriggerSkillAction(ICharacterCore attacker, ICharacterCore receiver, SkillAction action)
        {
            receiver.CombatController.ReceiveSkillAction(action, attacker, out _);

        }

        public IEnumerator TriggerContinuous(SkillAction action)
        {
            float tickRate = action.TickRatePerSecond;
            if(tickRate == 0f)
            {
                yield break;
            }
            while (true)
            {
                foreach (ICharacterCore receiver in monstersInCollider)
                {
                    // FIX HERE FOR CONTINUOUS HEALS OR ENHANCEMENTS
                    if (_performer != receiver)
                    {
                        receiver.CombatController.ReceiveSkillAction(action, _performer, out _);
                    }
                }
                yield return new WaitForSeconds(1f / tickRate);

            }
        }

        public void OnDestroy()
        {
            StopAllCoroutines();
        }

        public void Initialize(ICharacterCore performer)
        {
            _performer = performer;
        }
    }
}