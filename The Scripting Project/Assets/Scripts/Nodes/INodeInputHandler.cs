using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INodeInputHandler
{
    IReadOnlyList<IDirectionalInputSocket> InputSockets { get; }
}
