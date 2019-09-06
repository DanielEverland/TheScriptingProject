using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGraph : MonoBehaviour
{
    [SerializeField]
    private GraphConstructor constructor;

    public void Load()
    {
        DirectedGraph graph = (DirectedGraph)GraphUtility.LoadDebugGraph();

        constructor.CreateGraph(graph);
    }
}
