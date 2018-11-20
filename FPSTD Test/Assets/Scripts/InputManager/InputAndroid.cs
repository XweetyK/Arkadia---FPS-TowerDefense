using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAndroid : IInput
{
    public float GetHorizontalAxis()
    {
		return SimpleInput.GetAxis ("Android X");
    }
	public float GetVerticalAxis()
	{
		return SimpleInput.GetAxis ("Android Y");
	}

}
