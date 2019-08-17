using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class LogicCube : ILogicCube
{
    [JsonIgnore]
    public DataContainer Data { get { return data; } }

    [JsonProperty]
    private DataContainer data = new DataContainer();
}
