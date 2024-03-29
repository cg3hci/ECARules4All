﻿using UnityEngine;

namespace ECARules4All.RuleEngine
{
    /// <summary>
    /// <b>Environment</b> objects represent inanimated elements that configure the scene, like buildings, vegetation etc...
    /// Or elements that decorate or furnish a room.
    /// </summary>
    [ECARules4All("environment")]
    [RequireComponent(typeof(ECAObject))]
    [DisallowMultipleComponent]
    public class Environment : MonoBehaviour
    {
    }

}
