using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Input Systems")]
    public FloatingJoystick _floatingJoystick;

    public float GetHorizontalValue()
    {
        return _floatingJoystick.Horizontal;
    }
    public float GetVerticalValue()
    {
        return _floatingJoystick.Vertical;
    }
}
