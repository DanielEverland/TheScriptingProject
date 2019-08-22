using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class Node : INode
{
    [JsonIgnore]
    public Vector2 Position { get => position; set => position = value; }
    [JsonIgnore]
    public Quaternion Rotation { get => rotation; set => rotation = value; }

    [JsonProperty]
    private Vector2 position;
    [JsonProperty]
    private Quaternion rotation;
}
