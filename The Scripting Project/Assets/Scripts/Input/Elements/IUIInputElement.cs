using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIInputElement
{
    RectTransform rectTransform { get; }

    void UpdateUIElement();
    bool ShouldDisable();
}
