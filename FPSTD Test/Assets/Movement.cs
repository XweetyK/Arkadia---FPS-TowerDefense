using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	[SerializeField] private float vel=8;
	[SerializeField] private float spe=80;
	float transX;
	float transZ;
	float rotX;
	float rotY;
	RaycastHit info;

	void Start(){
		Screen.lockCursor = true;
	}
	void Update () {
		transZ = Input.GetAxis ("Vertical") * vel * Time.deltaTime;
		transX = Input.GetAxis ("Horizontal") * vel * Time.deltaTime;
		rotX = Input.GetAxis ("Mouse Y") * spe * Time.deltaTime;
		rotY = Input.GetAxis ("Mouse X") * spe * Time.deltaTime;
		transform.GetChild (0).Rotate (-rotX, 0, 0);
		transform.Translate (transX, 0, transZ);
		transform.Rotate (0, rotY, 0);

	}
}
