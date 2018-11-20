using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPC : IInput
{
    public bool GetFireButton()
    {
        return Input.GetButton("Fire1");
    }

    public float GetHorizontalAxis()
    {
        return Input.GetAxis("Horizontal");
    }

}
