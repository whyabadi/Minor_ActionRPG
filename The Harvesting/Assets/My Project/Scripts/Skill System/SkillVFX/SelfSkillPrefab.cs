using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class SelfSkillPrefab : SkillPrefab
    {
        public float Duration = 5f;
        void Start()
        {
            Destroy(gameObject, Duration);
            TriggerSkillActions(_performer, _performer);
        }

    }
}