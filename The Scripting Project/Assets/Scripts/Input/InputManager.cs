using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private DefaultInputGroup defaultGroup;

    private IInputGroup currentInputGroup;

    private void Awake()
    {
        currentInputGroup = defaultGroup;
    }
    private void Update()
    {
        currentInputGroup.PollInput();
    }
}
