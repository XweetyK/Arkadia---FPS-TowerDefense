using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPC : IInput
{
	public float GetHorizontalAxis()
	{
		return Input.GetAxis ("Mouse X");
	}
	public float GetVerticalAxis()
	{
		return Input.GetAxis ("Mouse Y");
	}

}
