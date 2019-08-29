using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : Node, INodeOutputHandler
{
    public StartNode()
    {
        outputSockets = new List<IDirectionalOutputSocket>()
        {
            new DirectionalOutputSocket(),
        };
    }

    public IReadOnlyList<IDirectionalOutputSocket> OutputSockets => outputSockets;

    private List<IDirectionalOutputSocket> outputSockets;
}
