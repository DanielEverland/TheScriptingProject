using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectedGraph : IDirectedGraph
{
    public DirectedGraph()
    {
        startNode = new StartNode();
    }

    public INode StartNode => startNode;

    private StartNode startNode;
}
