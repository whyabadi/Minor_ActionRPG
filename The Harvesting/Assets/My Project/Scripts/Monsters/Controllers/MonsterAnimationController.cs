using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    [RequireComponent(typeof(MonsterCore))]
    public class MonsterAnimationController : CharacterAnimationController, IMonsterAnimationController
    {
        new public IMonsterCore Core { get; protected set; }

        private bool deathAnimationPlayed = false;

        // Update is called once per frame

        private void HandleAnimations()
        {
           /* if(deathAnimationPlayed == true)
            {
                return;
            }

            if(_combatController.Dead(_combatController.CurrentCharacterState()))
            {
                var monsterNavMesh = GetComponent<NavMeshAgent>();
                monsterNavMesh.enabled = false;
                var rigidBody = GetComponentInChildren<Rigidbody>();
                var collider = GetComponentInChildren<Collider>();
                Destroy(rigidBody);
                Destroy(collider);
                _animator.SetTrigger("Death");
                deathAnimationPlayed = true;
                return;
            }

            _animator.SetBool("Stunned", _combatController.Stunned(_combatController.CurrentCharacterState()));
            _animator.SetBool("Running", _movementController.IsRunning());
           */
            
        }

        public void AddEffect(GameObject effect, float duration)
        {
            if(effect != null)
            {
                var spawn = Instantiate(effect, transform);
                Destroy(spawn, duration);
            }
        }
        public void Initialize(IMonsterCore core, Animator animator)
        {
            Core = core;
            base.Initialize(core, animator);
        }
    }
}