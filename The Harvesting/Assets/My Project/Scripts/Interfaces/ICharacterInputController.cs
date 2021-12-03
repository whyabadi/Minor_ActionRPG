using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface  ICharacterInputController
    {
        InputKeyData InputKeyData { get; }
        ICharacterCore Core { get; }
        bool MouseClick(out Vector3 point);
    }
}