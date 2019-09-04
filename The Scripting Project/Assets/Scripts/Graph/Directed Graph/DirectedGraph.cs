using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectedGraph : IDirectedGraph
{
    public DirectedGraph()
    {
        startNode = new StartNode();
        AddNode(startNode);
    }

    public INode StartNode => startNode;
    public IReadOnlyList<INode> AllNodes => allNodes;

    private StartNode startNode;
    private List<INode> allNodes = new List<INode>();

    public void AddNode(INode node)
    {
        allNodes.Add(node);
    }
}
