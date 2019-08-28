using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDirectionalNode : INode
{
    IReadOnlyList<IDirectionalOutputSocket> OutputSockets { get; }
    IReadOnlyList<IDirectionalInputSocket> InputSockets { get; }
}
