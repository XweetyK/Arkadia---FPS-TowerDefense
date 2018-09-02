using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	[SerializeField] private float vel=8;
	[SerializeField] private float spe=80;
	[SerializeField] private GameObject gmManagerPref;
	[SerializeField] private GameObject[] _base;
	GameModeManager _gmManager;
	float transX;
	float transZ;
	float rotX;
	float rotY;
	private int cont;
	RaycastHit info;

	void Start(){
		Screen.lockCursor = true;
		_gmManager = gmManagerPref.GetComponent<GameModeManager> ();
		cont = 0;
	}
	void Update () {
		switch (_gmManager.GameMode) {
		case GameModeManager.GAMEMODE.WALLBUILDER:
			transZ = Input.GetAxis ("Vertical") * vel * Time.deltaTime;
			transX = Input.GetAxis ("Horizontal") * vel * Time.deltaTime;
			rotX = Input.GetAxis ("Mouse Y") * spe * Time.deltaTime;
			rotY = Input.GetAxis ("Mouse X") * spe * Time.deltaTime;
			transform.GetChild (0).Rotate (-rotX, 0, 0);
			transform.Translate (transX, 0, transZ);
			transform.Rotate (0, rotY, 0);
			if (Input.GetButtonDown("Jump")) {
				_gmManager.GameMode = GameModeManager.GAMEMODE.DESTROYER;
			}
			break;
		case GameModeManager.GAMEMODE.DESTROYER:
			rotX = Input.GetAxis ("Mouse Y") * spe * Time.deltaTime;
			rotY = Input.GetAxis ("Mouse X") * spe * Time.deltaTime;
			transform.GetChild (0).Rotate (-rotX, 0, 0);
			transform.Rotate (0, rotY, 0);
			transform.position = (_base [cont].transform.position) + (new Vector3 (0.0f, 2.0f, 0.0f));
			if (Input.GetButtonDown ("Fire3")) {
				if (cont != (_base.Length - 1)) {
					cont++;
				} else {
					cont = 0;
				}
			}
			if (Input.GetButtonDown ("Jump")) {
				_gmManager.GameMode = GameModeManager.GAMEMODE.WALLBUILDER;
				transform.position = (new Vector3 (0.0f, 1.5f, 0.0f));
			}
			break;
		}
	}
}
