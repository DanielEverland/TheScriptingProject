using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public abstract class Node : INode
{
    [JsonIgnore]
    public Vector2 Position { get => position; set => position = value; }
    [JsonIgnore]
    public Vector2 Size => Vector2.one;

    [JsonProperty]
    private Vector2 position;
}
