using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDirectionalInputSocket : ISocket
{
}
public interface IDirectionalInputSocket<T> : ISocket<T>, IDirectionalInputSocket
{
}