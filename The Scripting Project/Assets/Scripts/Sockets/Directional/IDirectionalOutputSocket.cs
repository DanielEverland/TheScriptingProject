using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDirectionalOutputSocket : ISocket
{
    IReadOnlyList<IDirectionalInputSocket> Targets { get; }
}
public interface IDirectionalOutputSocket<T> : ISocket<T>, IDirectionalOutputSocket
{
}
