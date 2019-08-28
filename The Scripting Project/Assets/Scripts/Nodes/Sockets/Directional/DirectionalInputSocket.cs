using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalInputSocket : IDirectionalInputSocket
{
}

public class DirectionalInputSocket<T> : DirectionalInputSocket, IDirectionalInputSocket<T>
{
}
