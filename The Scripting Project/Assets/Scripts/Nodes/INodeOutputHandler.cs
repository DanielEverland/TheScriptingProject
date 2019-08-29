using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INodeOutputHandler
{
    IReadOnlyList<IDirectionalOutputSocket> OutputSockets { get; }
}
