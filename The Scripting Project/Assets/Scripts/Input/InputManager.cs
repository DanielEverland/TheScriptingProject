using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private IInputGroup currentInputGroup;

    private void Awake()
    {
        currentInputGroup = new DefaultInputGroup();
    }
    private void Update()
    {
        currentInputGroup.PollInput();
    }
}
