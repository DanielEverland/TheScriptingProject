using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputSocket : IOutputSocket
{

}
public class OutputSocket<T> : OutputSocket, IOutputSocket<T>
{

}