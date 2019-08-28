using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDirectionalOutputSocket : ISocket
{
    IDirectionalInputSocket Target { get; }
}
public interface IDirectionalOutputSocket<T> : ISocket<T>, IDirectionalOutputSocket
{
}
