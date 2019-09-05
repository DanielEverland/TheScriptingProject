using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorElement : MonoBehaviour
{
    [SerializeField]
    private SocketElement socketPrefab = null;

    public void AddSocket(ISocket socket)
    {
        SocketElement instance = Instantiate(socketPrefab);
        instance.transform.SetParent(transform);

        instance.Initialize(socket);
    }
}
