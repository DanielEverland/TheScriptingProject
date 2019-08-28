using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DirectionalOutputSocket : IDirectionalOutputSocket
{
    public IReadOnlyList<IDirectionalInputSocket> Targets => targets;

    [JsonProperty]
    private List<IDirectionalInputSocket> targets = null;
}
public class DirectionalOutputSocket<T> : DirectionalOutputSocket, IDirectionalOutputSocket<T>
{

}