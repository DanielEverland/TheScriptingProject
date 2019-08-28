using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : DirectionalNode
{
    protected override void CreateOutputSockets(List<IDirectionalOutputSocket> list)
    {
        list.Add(new DirectionalOutputSocket());
    }
}
