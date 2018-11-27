using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPC : IInput
{
	public bool GetFire1Button(){
		return Input.GetButtonDown ("Fire1");
	}
	public bool GetFire2Button(){
		return Input.GetButtonDown ("Fire2");
	}
	public bool GetFire3Button(){
		return Input.GetButtonDown ("Fire3");
	}
	public bool GetJumpButton(){
		return Input.GetButtonDown ("Jump");
	}
	public bool GetShiftButton(){
		return Input.GetButtonDown ("Shift");
	}
	public bool GetMapButton(){
		return Input.GetButtonDown ("Map");
	}
	public float GetHorizontalAxis()
	{
		return Input.GetAxis ("Mouse X");
	}
	public float GetVerticalAxis()
	{
		return Input.GetAxis ("Mouse Y");
	}
	public float GetHorizontalKeyAxis()
	{
		return Input.GetAxis ("Horizontal");
	}
	public float GetVerticalKeyAxis()
	{
		return Input.GetAxis ("Vertical");
	}

}
