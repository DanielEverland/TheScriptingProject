using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Node : INode
{
    public DataContainer Data { get { return data; } }

    private DataContainer data = new DataContainer();
}
