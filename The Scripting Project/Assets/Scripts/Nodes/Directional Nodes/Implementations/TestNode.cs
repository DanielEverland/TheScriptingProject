using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNode : DirectionalNode
{
    protected override void CreateInputSockets(List<IDirectionalInputSocket> list)
    {
        list.Add(new DirectionalInputSocket());
    }
    protected override void CreateOutputSockets(List<IDirectionalOutputSocket> list)
    {
        list.Add(new DirectionalOutputSocket());
    }
}
