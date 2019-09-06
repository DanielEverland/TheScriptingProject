using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphConstructor : MonoBehaviour
{
    public static IGraph CurrentGraph { get; private set; }

    [SerializeField]
    private Transform graphCanvas;
    [SerializeField]
    private NodeElement nodePrefab;

    private GameObject currentGraphObject;

    public void CreateGraph(IGraph graph)
    {
        if (currentGraphObject != null)
            DestroyCurrentGraphObject();

        currentGraphObject = CreateGraphObject();
        CurrentGraph = graph;

        foreach (INode node in graph.AllNodes)
        {
            CreateNodeElement(node);
        }
    }
    private NodeElement CreateNodeElement(INode node)
    {
        NodeElement instance = Instantiate(nodePrefab);
        instance.transform.SetParent(currentGraphObject.transform);

        instance.Initialize(node);

        return instance;
    }
    private void DestroyCurrentGraphObject()
    {
        Destroy(currentGraphObject);
    }
    private GameObject CreateGraphObject()
    {
        GameObject graphObject = new GameObject("Graph Object");
        graphObject.transform.SetParent(graphCanvas);

        RectTransform rectTrans = graphObject.AddComponent<RectTransform>();
        rectTrans.anchorMin = Vector2.zero;
        rectTrans.anchorMax = Vector2.one;

        rectTrans.offsetMax = Vector2.zero;
        rectTrans.offsetMin = Vector2.zero;

        return graphObject;
    }
}
