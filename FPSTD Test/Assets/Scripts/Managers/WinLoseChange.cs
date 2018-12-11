using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseChange : MonoBehaviour {

	private SceneChange _scene;
	[SerializeField] Text _text;

	void Awake(){
		#if UNITY_ANDROID
		_text.text= "Touch to continue";
		#else
		_text.text = "Press any key";
		#endif
			
		_scene = FindObjectOfType<SceneChange>();
	}
	void Update () {
		if (Input.anyKey) {
			_scene.MainMenu ();
		}
	}
}
