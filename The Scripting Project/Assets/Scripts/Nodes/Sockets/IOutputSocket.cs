using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOutputSocket : ISocket
{
}
public interface IOutputSocket<T> : ISocket<T>
{
}
