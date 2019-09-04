using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphTester : MonoBehaviour
{
    [SerializeField]
    private GraphConstructor constructor;

    private void Awake()
    {
        IGraph testGraph = GetTestGraph();

        constructor.CreateGraph(testGraph);
        constructor.CreateGraph(testGraph);
    }
    private IGraph GetTestGraph()
    {
        DirectedGraph graph = new DirectedGraph();

        TestNode node = new TestNode();
        node.Position += new Vector2(1, 0);

        graph.AddNode(node);

        return graph;
    }
}
