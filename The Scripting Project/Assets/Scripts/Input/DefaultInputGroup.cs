using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultInputGroup : IInputGroup
{
    public void PollInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Debug.Log("Test");
    }
}
