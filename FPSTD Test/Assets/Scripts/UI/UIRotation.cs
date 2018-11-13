using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRotation : MonoBehaviour {

	private GameObject _mainCamera;
	void Start(){
		_mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
	}

	void Update(){
		transform.rotation = _mainCamera.transform.rotation;
	}
}
