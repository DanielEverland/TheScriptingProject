using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : Node, INodeOutputHandler, INodeInputHandler
{
    public StartNode()
    {
        outputSockets = new List<IDirectionalOutputSocket>()
        {
            new DirectionalOutputSocket(),
        };
        inputSockets = new List<IDirectionalInputSocket>()
        {
            new DirectionalInputSocket(),
        };
    }

    public IReadOnlyList<IDirectionalOutputSocket> OutputSockets => outputSockets;

    public IReadOnlyList<IDirectionalInputSocket> InputSockets => inputSockets;

    private List<IDirectionalOutputSocket> outputSockets;
    private List<IDirectionalInputSocket> inputSockets;
}
