using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    static InputManager instance = null;

    IInput input;

    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InputManager>();
            }

            return instance;
        }
    }
	
    // Use this for initialization
	void Awake ()
    {
        instance = this;

        /*if (Application.platform == RuntimePlatform.Android)
        {
            input = new InputAndroid();
        }
        else
        {
            input = new InputPC();
        }*/

#if UNITY_ANDROID
        input = new InputAndroid();
#else
        input = new InputPC();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
#endif
    }

    public float GetHorizontalAxis()
    {
        return input.GetHorizontalAxis();
    }
	public float GetVerticalAxis()
	{
		return input.GetVerticalAxis();
	}

}
