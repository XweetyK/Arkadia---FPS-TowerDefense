using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAndroid : IInput
{
	public bool GetFire1Button(){
		return SimpleInput.GetKeyDown (KeyCode.Q);
	}
	public bool GetFire2Button(){
		return SimpleInput.GetKeyDown (KeyCode.W);
	}
	public bool GetFire3Button(){
		return SimpleInput.GetKeyDown (KeyCode.E);
	}
	public bool GetJumpButton(){
		return SimpleInput.GetKeyDown (KeyCode.Space);
	}
	public bool GetMapButton(){
		return SimpleInput.GetKeyDown (KeyCode.M);
	}
	public float GetHorizontalAxis()
	{
		return SimpleInput.GetAxis ("Android X");
	}
	public float GetVerticalAxis()
	{
		return SimpleInput.GetAxis ("Android Y");
	}
	public float GetHorizontalKeyAxis()
	{
		return SimpleInput.GetAxis ("Horizontal");
	}
	public float GetVerticalKeyAxis()
	{
		return SimpleInput.GetAxis ("Vertical");
	}

}
