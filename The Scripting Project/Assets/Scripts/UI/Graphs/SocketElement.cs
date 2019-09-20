using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketElement : MonoBehaviour, IUIInputElement
{
    public RectTransform rectTransform => (RectTransform)transform;

    public void Initialize(ISocket socket)
    {

    }

    public bool ShouldDisable()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateUIElement()
    {
        throw new System.NotImplementedException();
    }
}
