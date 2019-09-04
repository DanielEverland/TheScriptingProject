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

        string serializedObject = Serializer.Serialize(testGraph);
        Debug.Log(serializedObject);

        IGraph deserializedGraph = Serializer.Deserialize<DirectedGraph>(serializedObject);

        constructor.CreateGraph(deserializedGraph);
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
