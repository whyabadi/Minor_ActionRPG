using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IExperiencePointsGiver
    {
        int ExperiencePoints { get; }
    }
}