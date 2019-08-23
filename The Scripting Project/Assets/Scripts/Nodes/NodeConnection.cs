using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Type = System.Type;

public class NodeConnection<T>
{
    public Type Type => typeof(T);

}
