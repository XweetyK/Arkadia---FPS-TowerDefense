using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseChange : MonoBehaviour {

	private SceneChange _scene;

	void Awake(){
		_scene = FindObjectOfType<SceneChange>();
	}
	void Update () {
		if (Input.anyKey) {
			_scene.MainMenu ();
		}
	}
}
