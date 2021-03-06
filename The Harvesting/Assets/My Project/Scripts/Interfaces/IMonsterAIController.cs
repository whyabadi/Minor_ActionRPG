using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IMonsterAIController : ICharacterAIController
    {
        new IMonsterCore Core { get; }
        MonsterAI MonsterAI { get; }
        void Initialize(IMonsterCore core, MonsterAI monsterAI);
    }
}