using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewGraph : MonoBehaviour
{
    [SerializeField]
    private GraphConstructor constructor;

    public void Create()
    {
        constructor.CreateGraph(DirectedGraph.CreateGraphWithStartNode());
    }
}
