using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
   // [CreateAssetMenu(fileName = "new direct skill action", menuName = "Data/Skills/Skill Actions/Direct Skill Action")]
    public class DirectSkillAction
    {
        [Tooltip("This action uses the Multiplier and the Attribute fields.")]
        public SkillElement Element;

        public  void Activate(Character attacker, Character receiver)
        {
            throw new System.NotImplementedException();
        }
    }
}