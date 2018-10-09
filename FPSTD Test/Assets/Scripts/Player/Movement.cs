using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

	[SerializeField] private float vel=8;
	[SerializeField] private float spe=80;
	[SerializeField] private GameModeManager _gmManager;
	[SerializeField] private RawImage UI;
	[SerializeField] private GameObject[] _base;
	float transX;
	float transZ;
	float rotX;
	float rotY;
	private int cont;
	RaycastHit info;

	void Start(){
		cont = 0;
	}

	void OnEnable()
	{
		GameManager.GetInstance ().AddListener (OnWaveEndEvent, GameManager.GameEvent.WaveEnd);
	}

	void OnDisable()
	{
		if (GameManager.GetInstance ()) {
			GameManager.GetInstance ().RemoveListener (OnWaveEndEvent, GameManager.GameEvent.WaveEnd);
		}
	}


	void OnWaveEndEvent(GameManager.GameEvent evt)
	{
		Debug.Log ("OnWave End");
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
			break;
		}
		if (Input.GetButtonDown ("Map")) {
			UI.GetComponent<RawImage> ().enabled= (!UI.GetComponent<RawImage> ().IsActive());
		}
	}
}
