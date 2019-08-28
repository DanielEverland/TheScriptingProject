using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DirectionalOutputSocket : IDirectionalOutputSocket
{
    public IDirectionalInputSocket Target => target;

    [JsonProperty]
    private IDirectionalInputSocket target = null;
}
public class DirectionalOutputSocket<T> : DirectionalOutputSocket, IDirectionalOutputSocket<T>
{

}