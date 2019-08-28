using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalNode : Node, IDirectionalNode
{
    public DirectionalNode()
    {
        outputSockets = new List<IDirectionalOutputSocket>();
        CreateOutputSockets(outputSockets);

        inputSockets = new List<IDirectionalInputSocket>();
        CreateInputSockets(inputSockets);
    }

    public IReadOnlyList<IDirectionalOutputSocket> OutputSockets => outputSockets;
    public IReadOnlyList<IDirectionalInputSocket> InputSockets => inputSockets;

    private List<IDirectionalOutputSocket> outputSockets;
    private List<IDirectionalInputSocket> inputSockets;

    protected virtual void CreateOutputSockets(List<IDirectionalOutputSocket> list) { }
    protected virtual void CreateInputSockets(List<IDirectionalInputSocket> list) { }
}