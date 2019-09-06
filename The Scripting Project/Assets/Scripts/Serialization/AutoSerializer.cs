using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSerializer : MonoBehaviour
{
    [SerializeField]
    private GraphConstructor constructor;

    private void Start()
    {
        if(!GraphUtility.IsDebugGraphAvailable)
        {
            Debug.Log("No debug graph available");
            return;
        }

        DirectedGraph graph = (DirectedGraph)GraphUtility.LoadDebugGraph();

        constructor.CreateGraph(graph);
    }
    private void OnApplicationQuit()
    {
        GraphUtility.SaveCurrentGraph();
    }
}
