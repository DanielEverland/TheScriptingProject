using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGraph
{
    INode StartNode { get; }
    IReadOnlyList<INode> AllNodes { get; }

    void AddNode(INode node);
}
