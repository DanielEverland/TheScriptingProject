using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DirectedGraph : IDirectedGraph
{
    public INode StartNode => allNodes[0];
    public IReadOnlyList<INode> AllNodes => allNodes;

    [JsonProperty]
    private List<INode> allNodes = new List<INode>();

    public void AddNode(INode node)
    {
        allNodes.Add(node);
    }
    public static DirectedGraph CreateGraphWithStartNode()
    {
        DirectedGraph newGraph = new DirectedGraph();

        newGraph.AddNode(new StartNode());

        return newGraph;
    }
}
